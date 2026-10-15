import { useState } from "react";
import Header from "./components/Header";
import AddStudent from "./components/AddStudent";
import StudentList from "./components/StudentList";

function App() {
  const [students, setStudents] = useState([
    {
      id: 1,
      name: "Rahul",
      age: 21,
      course: "React",
    },
    {
      id: 2,
      name: "Priya",
      age: 22,
      course: "Angular",
    },
    {
      id: 3,
      name: "Arun",
      age: 20,
      course: "Python",
    },
  ]);

  // Add student
  function addStudent(newStudent) {
    setStudents((prevStudents) => [
      ...prevStudents,
      {
        ...newStudent,
        id: Date.now(),
      },
    ]);
  }

  // Delete student
  function deleteStudent(id) {
    setStudents((prevStudents) =>
      prevStudents.filter((student) => student.id !== id)
    );
  }

  // Edit student
  function editStudent(updatedStudent) {
    setStudents((prevStudents) =>
      prevStudents.map((student) =>
        student.id === updatedStudent.id
          ? updatedStudent
          : student
      )
    );
  }

  return (
    <div className="app">
      <Header />

      <AddStudent onAddStudent={addStudent} />

      <StudentList
        students={students}
        onDeleteStudent={deleteStudent}
        onEditStudent={editStudent}
      />
    </div>
  );
}

export default App;