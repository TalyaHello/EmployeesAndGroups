import { Component } from '@angular/core';
import { Employee } from '../models/employee';
import { GroupService } from '../services/group.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private groupService: GroupService) {}
  employees: Employee[] = [];
  letterText: string = '';
  getResult: boolean = false;
  employeesNames: string = '';

  send(letterText: string): void {
    this.groupService
      .getNotManagementGroupEmployees(letterText)
      .subscribe((empl) => {
        this.employees = empl;
        this.employeesNames = empl.map((x) => x.fullName).join(', ');
      });
  }
}
