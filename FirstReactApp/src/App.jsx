// import Greeting from "./Greeting";
// import Message from "./Message";
// import { useState } from "react";

// function App() {
//   const [message, setMessage] = useState("");

//   function handleClick() {
//     setMessage("You clicked the button!");
//   }

//   return (
//     <div>
//       <Greeting name="Nishanth" />

//       <button onClick={handleClick}>
//         Click Me
//       </button>

//       <Message message={message} />
//     </div>
//   );
// }

// export default App;


import React, { Component } from "react";
import Greeting from "./Greeting";
import Message from "./Message";

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      message: ""
    };
  }

  handleClick = () => {
    this.setState({
      message: "You clicked the button!"
    });
  };

  render() {
    return (
      <div>
        <Greeting name="Nishanth" />

        <button onClick={this.handleClick}>
          Click Me
        </button>

        <Message message={this.state.message} />
      </div>
    );
  }
}

export default App;