import React, { Component } from "react";
import Header from "./components/Header";
import AddMovie from "./components/AddMovie";
import MovieList from "./components/MovieList";

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      movies: [
        {
          id: 1,
          name: "Inception",
          genre: "Sci-Fi",
          rating: 9,
        },
        {
          id: 2,
          name: "Interstellar",
          genre: "Sci-Fi",
          rating: 8.5,
        },
        {
          id: 3,
          name: "The Dark Knight",
          genre: "Action",
          rating: 9,
        },
      ],
      searchText: "",
    };
  }

  // Add movie
  addMovie = (newMovie) => {
    this.setState((prevState) => ({
      movies: [
        ...prevState.movies,
        {
          ...newMovie,
          id: Date.now(),
        },
      ],
    }));
  };

  // Delete movie
  deleteMovie = (id) => {
    this.setState((prevState) => ({
      movies: prevState.movies.filter(
        (movie) => movie.id !== id
      ),
    }));
  };

  // Edit movie
  editMovie = (updatedMovie) => {
    this.setState((prevState) => ({
      movies: prevState.movies.map((movie) =>
        movie.id === updatedMovie.id
          ? updatedMovie
          : movie
      ),
    }));
  };

  // Search movie
  handleSearch = (event) => {
    this.setState({
      searchText: event.target.value,
    });
  };

  render() {
    const { movies, searchText } = this.state;

    const filteredMovies = movies.filter((movie) =>
      movie.name
        .toLowerCase()
        .includes(searchText.toLowerCase())
    );

    return (
      <div className="app">
        <Header />

        <AddMovie onAddMovie={this.addMovie} />

        <div className="search-section">
          <h2>Search Movies</h2>

          <input
            type="text"
            placeholder="Search movie..."
            value={searchText}
            onChange={this.handleSearch}
          />
        </div>

        <MovieList
          movies={filteredMovies}
          onDeleteMovie={this.deleteMovie}
          onEditMovie={this.editMovie}
        />
      </div>
    );
  }
}

export default App;