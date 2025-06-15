import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../Classes/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(public http: HttpClient) { }

  GetbyDepartmentId(id: number): Observable<Array<Category>> {
    return this.http.get<Array<Category>>(`https://localhost:7107/api/Category/GetByDepartmentId/${id}`)
  }
  GetById(id: number): Observable<Category> {
    return this.http.get<Category>(`https://localhost:7107/api/Category/GetById/${id}`);
  }
}
