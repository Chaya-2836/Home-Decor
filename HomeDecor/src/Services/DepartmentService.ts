import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Department } from "../Classes/Department";
@Injectable({
    providedIn: 'root'
})
export class DepartmentService{
    constructor(public h:HttpClient) {}
    getAll():Observable<Array<Department>>{
        console.log("in service");
        
        return this.h.get<Array<Department>>(`https://localhost:7107/api/Department`)
    }
    allDepartments:Array<Department> = new Array<Department>()

}