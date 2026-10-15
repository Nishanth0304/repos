import argparse
import csv
import json
import re
import time
from datetime import datetime, timezone
from html import unescape
from pathlib import Path

import requests
from bs4 import BeautifulSoup


# ============================================================
# Configuration
# ============================================================

BASE_URL = "https://www.glossier.com"

COUNTRY_ENDPOINTS = {
    "us": f"{BASE_URL}/collections/all/products.json",
    "in": f"{BASE_URL}/en-in/collections/all/products.json",
}

OUTPUT_FILES = {
    "us": Path("output/glossier_products_us.csv"),
    "in": Path("output/glossier_products_in.csv"),
}

PAGE_SIZE = 250

REQUEST_DELAY = 0.5

DESCRIPTION_REQUEST_DELAY = 0.2


HEADERS = {
    "User-Agent": (
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) "
        "AppleWebKit/537.36 (KHTML, like Gecko) "
        "Chrome/154.0.0.0 Safari/537.36"
    ),
    "Accept": "application/json",
}


# ============================================================
# HTTP Helpers
# ============================================================

def fetch_json(url, params=None):
    """
    Fetch JSON data from a URL.
    """

    response = requests.get(
        url,
        headers=HEADERS,
        params=params,
        timeout=30,
    )

    response.raise_for_status()

    return response.json()


def get_scraped_at():
    """
    Return the current UTC timestamp in ISO 8601 format.
    """

    return datetime.now(
        timezone.utc
    ).isoformat()


# ============================================================
# Description Helpers
# ============================================================

def clean_description(html):
    """
    Convert HTML description into readable plain text.
    """

    if not html:
        return ""

    html = unescape(html)

    soup = BeautifulSoup(
        html,
        "html.parser",
    )

    # Add spacing around common HTML elements
    # before extracting text.
    for tag in soup.find_all(
        ["br", "p", "li", "div"]
    ):
        tag.insert_before(" ")
        tag.insert_after(" ")

    text = soup.get_text(
        " ",
        strip=True,
    )

    # Normalize repeated whitespace.
    text = re.sub(
        r"\s+",
        " ",
        text,
    ).strip()

    # Fix words that are joined together
    # in some source descriptions.
    text = re.sub(
        r"\bAwardedthe\b",
        "Awarded the",
        text,
        flags=re.IGNORECASE,
    )

    text = re.sub(
        r"\bandtaste\b",
        "and taste",
        text,
        flags=re.IGNORECASE,
    )

    text = re.sub(
        r"\blipbalm\b",
        "lip balm",
        text,
        flags=re.IGNORECASE,
    )

    return text


def fetch_product_page_description(handle):
    """
    Fetch the individual product HTML page and extract
    the main product description.

    Extraction order:
    1. #description-item
    2. Product tagline inside .pv-details__tagline

    If neither exists, return an empty string.
    """

    if not handle:
        return ""

    url = get_product_url(handle)

    try:
        time.sleep(
            DESCRIPTION_REQUEST_DELAY
        )

        response = requests.get(
            url,
            headers={
                **HEADERS,
                "Accept": "text/html",
            },
            timeout=30,
        )

        response.raise_for_status()

        soup = BeautifulSoup(
            response.text,
            "html.parser",
        )

        # ----------------------------------------------------
        # First choice:
        # Full product description
        # ----------------------------------------------------

        description = soup.select_one(
            "#description-item"
        )

        if description:

            text = clean_description(
                str(description)
            )

            if text:
                return text

        # ----------------------------------------------------
        # Second choice:
        # Product tagline
        # ----------------------------------------------------

        tagline = soup.select_one(
            ".pv-details__tagline"
        )

        if tagline:

            text = clean_description(
                str(tagline)
            )

            if text:
                return text

        # ----------------------------------------------------
        # No description exposed by the page
        # ----------------------------------------------------

        return ""

    except requests.RequestException as exc:

        print(
            f"  Warning: could not fetch description "
            f"for {url}: {exc}"
        )

        return ""


def get_product_description(product):
    """
    Get the product description.

    First:
        Use body_html from the structured JSON.

    Fallback:
        If body_html is empty, fetch the individual
        product page and extract #description-item.
    """

    description_html = product.get(
        "body_html",
        "",
    )

    if description_html.strip():

        return clean_description(
            description_html
        )

    print(
        f"  Fetching HTML description: "
        f"{product.get('title', '')}"
    )

    return fetch_product_page_description(
        product.get(
            "handle",
            "",
        )
    )


# ============================================================
# Product Helpers
# ============================================================

def get_product_url(handle):
    """
    Build the public product URL from the Shopify handle.
    """

    return f"{BASE_URL}/products/{handle}"


def get_images(product):
    """
    Return all available product image URLs.
    """

    images = []

    for image in product.get(
        "images",
        [],
    ):

        src = image.get(
            "src"
        )

        if src:
            images.append(src)

    return images


# ============================================================
# Product Parsing
# ============================================================

def parse_product(product):
    """
    Convert one parent product into one CSV row
    for every product variant.
    """

    variants = product.get(
        "variants",
        [],
    )

    rows = []

    for variant in variants:

        row = {
            "product_name": product.get(
                "title",
                "",
            ),

            "product_id": str(
                product.get(
                    "id",
                    "",
                )
            ),

            "variant_id": str(
                variant.get(
                    "id",
                    "",
                )
            ),

            "variant_name": variant.get(
                "title",
                "",
            ),

            "image": get_images(
                product
            ),

            "url": get_product_url(
                product.get(
                    "handle",
                    "",
                )
            ),

            "price": variant.get(
                "price",
                "",
            ),

            "description": get_product_description(
                product
            ),

            "scraped_at": get_scraped_at(),
        }

        rows.append(
            row
        )

    return rows


# ============================================================
# Scraping
# ============================================================

def scrape_all_products(country):
    """
    Retrieve all parent products from the selected
    Glossier storefront.

    Pagination continues until an empty products
    list is returned.
    """

    collection_url = COUNTRY_ENDPOINTS[
        country
    ]

    all_products = []

    page = 1

    while True:

        print(
            f"Fetching {country.upper()} "
            f"collection page {page}..."
        )

        data = fetch_json(
            collection_url,
            params={
                "limit": PAGE_SIZE,
                "page": page,
            },
        )

        products = data.get(
            "products",
            [],
        )

        print(
            f"  Products returned: "
            f"{len(products)}"
        )

        if not products:
            break

        all_products.extend(
            products
        )

        page += 1

        # Avoid making requests too quickly.
        time.sleep(
            REQUEST_DELAY
        )

    return all_products


# ============================================================
# Deduplication
# ============================================================

def remove_duplicates(products):
    """
    Remove duplicate product variants using variant_id.

    The variant ID is used because each variant represents
    a unique sellable configuration.
    """

    unique_products = {}

    for product in products:

        variant_id = product.get(
            "variant_id",
            "",
        )

        if variant_id:

            unique_products[
                variant_id
            ] = product

    return list(
        unique_products.values()
    )


# ============================================================
# CSV Output
# ============================================================

def save_csv(products, country):
    """
    Save scraped products to a country-specific CSV.
    """

    output_file = OUTPUT_FILES[
        country
    ]

    output_file.parent.mkdir(
        parents=True,
        exist_ok=True,
    )

    fieldnames = [
        "product_name",
        "product_id",
        "variant_id",
        "variant_name",
        "image",
        "url",
        "price",
        "description",
        "scraped_at",
    ]

    with output_file.open(
        "w",
        newline="",
        encoding="utf-8-sig",
    ) as file:

        writer = csv.DictWriter(
            file,
            fieldnames=fieldnames,
        )

        writer.writeheader()

        for product in products:

            row = product.copy()

            # Store multiple image URLs as JSON
            # inside a single CSV cell.
            row["image"] = json.dumps(
                row["image"],
                ensure_ascii=False,
            )

            writer.writerow(
                row
            )

    return output_file


# ============================================================
# Main
# ============================================================

def main():

    parser = argparse.ArgumentParser(
        description="Glossier product scraper"
    )

    parser.add_argument(
        "--country",
        choices=["us", "in"],
        default="us",
        help="Storefront country: us or in",
    )

    args = parser.parse_args()

    country = args.country

    print(
        "Starting Glossier scraper..."
    )

    print(
        f"Selected storefront: "
        f"{country.upper()}"
    )

    print(
        f"Endpoint: "
        f"{COUNTRY_ENDPOINTS[country]}"
    )

    print()

    # --------------------------------------------------------
    # Step 1: Retrieve parent products
    # --------------------------------------------------------

    raw_products = scrape_all_products(
        country
    )

    print()

    print(
        f"Total parent products retrieved: "
        f"{len(raw_products)}"
    )

    # --------------------------------------------------------
    # Step 2: Expand product variants
    # --------------------------------------------------------

    products = []

    for product in raw_products:

        variant_rows = parse_product(
            product
        )

        products.extend(
            variant_rows
        )

    print()

    print(
        f"Total product variants generated: "
        f"{len(products)}"
    )

    # --------------------------------------------------------
    # Step 3: Remove duplicate variants
    # --------------------------------------------------------

    products = remove_duplicates(
        products
    )

    print(
        f"Unique product variants after "
        f"deduplication: {len(products)}"
    )

    # --------------------------------------------------------
    # Step 4: Save CSV
    # --------------------------------------------------------

    output_file = save_csv(
        products,
        country,
    )

    print()

    print(
        f"CSV created successfully: "
        f"{output_file}"
    )


if __name__ == "__main__":
    main()