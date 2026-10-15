import { useState } from "react";

function AddStudent(props) {
  const [name, setName] = useState("");
  const [age, setAge] = useState("");
  const [course, setCourse] = useState("");

  function handleSubmit(event) {
    event.preventDefault();

    // Validation
    if (!name.trim() || !age || !course.trim()) {
      alert("Please fill in all fields");
      return;
    }

    // Send student data to App
    props.onAddStudent({
      name: name.trim(),
      age: Number(age),
      course: course.trim(),
    });

    // Clear form
    setName("");
    setAge("");
    setCourse("");
  }

  return (
    <section className="add-student">
      <h2>Add Student</h2>

      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Enter name"
          value={name}
          onChange={(event) => setName(event.target.value)}
        />

        <input
          type="number"
          placeholder="Enter age"
          value={age}
          onChange={(event) => setAge(event.target.value)}
          min="1"
        />

        <input
          type="text"
          placeholder="Enter course"
          value={course}
          onChange={(event) => setCourse(event.target.value)}
        />

        <button type="submit">
          Add Student
        </button>
      </form>
    </section>
  );
}

export default AddStudent;