import React, { Component } from "react";

class AddMovie extends Component {
  constructor(props) {
    super(props);

    this.state = {
      name: "",
      genre: "",
      rating: "",
    };
  }

  handleChange = (event) => {
    this.setState({
      [event.target.name]: event.target.value,
    });
  };

  handleSubmit = (event) => {
    event.preventDefault();

    const { name, genre, rating } = this.state;

    if (!name.trim() || !genre.trim() || !rating) {
      alert("Please fill in all fields");
      return;
    }

    this.props.onAddMovie({
      name: name.trim(),
      genre: genre.trim(),
      rating: Number(rating),
    });

    this.setState({
      name: "",
      genre: "",
      rating: "",
    });
  };

  render() {
    return (
      <section className="add-movie">
        <h2>Add Movie</h2>

        <form onSubmit={this.handleSubmit}>
          <input
            type="text"
            name="name"
            placeholder="Enter movie name"
            value={this.state.name}
            onChange={this.handleChange}
          />

          <input
            type="text"
            name="genre"
            placeholder="Enter genre"
            value={this.state.genre}
            onChange={this.handleChange}
          />

          <input
            type="number"
            name="rating"
            placeholder="Enter rating"
            value={this.state.rating}
            onChange={this.handleChange}
            min="0"
            max="10"
            step="0.1"
          />

          <button type="submit">
            Add Movie
          </button>
        </form>
      </section>
    );
  }
}

export default AddMovie;