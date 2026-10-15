import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from './models/employee';

@Component({
  selector: 'app-root',
  imports: [FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  employees: Employee[] = [
    {
      id: 1,
      name: 'Nishanth',
      email: 'nishanth@gmail.com',
      department: 'IT',
      salary: 60000
      
    },
    {
      id: 2,
      name: 'Ayush',
      email: 'ayush@gmail.com',
      department: 'HR',
      salary: 55000
    },
    {
      id: 3,
      name: 'Vikas',
      email: 'vikas@gmail.com',
      department: 'Finance',
      salary: 50000
    }
  ];

  employee: Employee = {
    id: 0,
    name: '',
    email: '',
    department: '',
    salary: 0
  };

  editingId: number | null = null;

  addEmployee() {

    if (!this.employee.name || !this.employee.department) {
      return;
    }

    if (this.editingId === null) {

      const newEmployee: Employee = {
        id: this.employees.length + 1,
        name: this.employee.name,
        email: this.employee.email,
        department: this.employee.department,
        salary: this.employee.salary
      };

      this.employees.push(newEmployee);

    } else {

      const index = this.employees.findIndex(
        e => e.id === this.editingId
      );

      if (index !== -1) {
        this.employees[index] = {
          id: this.editingId,
          name: this.employee.name,
          email: this.employee.email,
          department: this.employee.department,
          salary: this.employee.salary
        };
      }
    }

    this.clearForm();
  }

  editEmployee(employee: Employee) {

    this.employee = {
      id: employee.id,
      name: employee.name,
      email: employee.email,
      department: employee.department,
      salary: employee.salary
    };

    this.editingId = employee.id;
  }

  deleteEmployee(id: number) {

    this.employees = this.employees.filter(
      employee => employee.id !== id
    );
  }

  clearForm() {

    this.employee = {
      id: 0,
      name: '',
      email: '',
      department: '',
      salary: 0
    };

    this.editingId = null;
  }
}
