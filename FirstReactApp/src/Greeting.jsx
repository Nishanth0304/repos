// function Greeting(props) {
//   return (
//     <div>
//       <h1>Hello, {props.name}!</h1>
//       <p>Welcome to React.</p>
//     </div>
//   );
// }

// export default Greeting;




import React, { Component } from "react";

class Greeting extends Component {
  render() {
    return (
      <div>
        <h1>Hello, {this.props.name}!</h1>
        <p>Welcome to React.</p>
      </div>
    );
  }
}

export default Greeting;