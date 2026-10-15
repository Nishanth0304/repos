import Student from "./Student";

function StudentList(props) {
  return (
    <section className="student-list">
      <h2>Students</h2>

      {props.students.length === 0 ? (
        <p className="no-students">
          No students found.
        </p>
      ) : (
        props.students.map((student) => (
          <Student
            key={student.id}
            id={student.id}
            name={student.name}
            age={student.age}
            course={student.course}
            onDelete={props.onDeleteStudent}
            onEdit={props.onEditStudent}
          />
        ))
      )}
    </section>
  );
}

export default StudentList;