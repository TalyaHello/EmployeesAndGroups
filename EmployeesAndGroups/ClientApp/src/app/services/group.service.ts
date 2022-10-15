import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root',
})
export class GroupService {
  private url = 'https://localhost:7254/api/groups';
  constructor(private http: HttpClient) {}

  getNotManagementGroupEmployees(letterText: string): Observable<Employee[]> {
    return this.http.get<Employee[]>(
      this.url + `/NotManagementGroupEmployees?letterText=${letterText}`
    );
  }
}
