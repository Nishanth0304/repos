// function Message(props) {
//   return <p>{props.message}</p>;
// }

// export default Message;

import React, { Component } from "react";

class Message extends Component {
  render() {
    return <p>{this.props.message}</p>;
  }
}

export default Message;