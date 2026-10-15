import React, { Component } from "react";
import Movie from "./Movie";

class MovieList extends Component {
  render() {
    const {
      movies,
      onDeleteMovie,
      onEditMovie,
    } = this.props;

    return (
      <section className="movie-list">
        <h2>Movies</h2>

        {movies.length === 0 ? (
          <p className="no-movies">
            No movies found.
          </p>
        ) : (
          movies.map((movie) => (
            <Movie
              key={movie.id}
              id={movie.id}
              name={movie.name}
              genre={movie.genre}
              rating={movie.rating}
              onDelete={onDeleteMovie}
              onEdit={onEditMovie}
            />
          ))
        )}
      </section>
    );
  }
}

export default MovieList;