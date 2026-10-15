import React, { Component } from "react";

class Movie extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isEditing: false,
      name: props.name,
      genre: props.genre,
      rating: props.rating,
    };
  }

  handleChange = (event) => {
    this.setState({
      [event.target.name]: event.target.value,
    });
  };

  handleEdit = () => {
    this.setState({
      isEditing: true,
    });
  };

  handleSave = () => {
    const { name, genre, rating } = this.state;

    if (!name.trim() || !genre.trim() || !rating) {
      alert("Please fill in all fields");
      return;
    }

    this.props.onEdit({
      id: this.props.id,
      name: name.trim(),
      genre: genre.trim(),
      rating: Number(rating),
    });

    this.setState({
      isEditing: false,
    });
  };

  handleCancel = () => {
    this.setState({
      isEditing: false,
      name: this.props.name,
      genre: this.props.genre,
      rating: this.props.rating,
    });
  };

  render() {
    const {
      isEditing,
      name,
      genre,
      rating,
    } = this.state;

    return (
      <div className="movie-card">

        {isEditing ? (
          <>
            <input
              type="text"
              name="name"
              value={name}
              onChange={this.handleChange}
            />

            <input
              type="text"
              name="genre"
              value={genre}
              onChange={this.handleChange}
            />

            <input
              type="number"
              name="rating"
              value={rating}
              onChange={this.handleChange}
              min="0"
              max="10"
              step="0.1"
            />

            <div className="button-group">
              <button
                className="save-button"
                onClick={this.handleSave}
              >
                Save
              </button>

              <button
                className="cancel-button"
                onClick={this.handleCancel}
              >
                Cancel
              </button>
            </div>
          </>
        ) : (
          <>
            <h3>{this.props.name}</h3>

            <p>
              <strong>Genre:</strong>{" "}
              {this.props.genre}
            </p>

            <p>
              <strong>Rating:</strong>{" "}
              {this.props.rating}
            </p>

            <div className="button-group">
              <button
                className="edit-button"
                onClick={this.handleEdit}
              >
                Edit
              </button>

              <button
                className="delete-button"
                onClick={() =>
                  this.props.onDelete(this.props.id)
                }
              >
                Delete
              </button>
            </div>
          </>
        )}

      </div>
    );
  }
}

export default Movie;