import { useState } from "react";

function Student(props) {
  const [isEditing, setIsEditing] = useState(false);

  const [name, setName] = useState(props.name);
  const [age, setAge] = useState(props.age);
  const [course, setCourse] = useState(props.course);

  function handleSave() {
    if (!name.trim() || !age || !course.trim()) {
      alert("Please fill in all fields");
      return;
    }

    props.onEdit({
      id: props.id,
      name: name.trim(),
      age: Number(age),
      course: course.trim(),
    });

    setIsEditing(false);
  }

  function handleCancel() {
    setName(props.name);
    setAge(props.age);
    setCourse(props.course);

    setIsEditing(false);
  }

  return (
    <div className="student-card">

      {isEditing ? (
        <>
          <input
            type="text"
            value={name}
            onChange={(event) => setName(event.target.value)}
          />

          <input
            type="number"
            value={age}
            onChange={(event) => setAge(event.target.value)}
          />

          <input
            type="text"
            value={course}
            onChange={(event) => setCourse(event.target.value)}
          />

          <button onClick={handleSave}>
            Save
          </button>

          <button onClick={handleCancel}>
            Cancel
          </button>
        </>
      ) : (
        <>
          <h3>{props.name}</h3>

          <p>
            <strong>Age:</strong> {props.age}
          </p>

          <p>
            <strong>Course:</strong> {props.course}
          </p>

          <button className="edit-button" onClick={() => setIsEditing(true)}>
            Edit
          </button>

          <button
            className="delete-button"
            onClick={() => props.onDelete(props.id)}
          >
            Delete
          </button>
        </>
      )}

    </div>
  );
}

export default Student;