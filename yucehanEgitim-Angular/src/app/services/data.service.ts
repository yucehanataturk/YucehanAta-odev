import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  Course = [

  CATEGORY = [

  constructor(private http:HttpClient) { }

  getCourses() {
    return this.http.get<any>('http://localhost:52232/Course');
  }

  getCoursesById(CourseId:any):Observable<any>{
    return this.http.get<any>('http://localhost:52232/Course/'+CourseId);
  }

  getCategories(): Observable<any> {
    return this.http.get<any>('http://localhost:52232/category');
  }

  getCategoriesById(catId:any):Observable<any>{
    return this.http.get<any>('http://localhost:52232/category/'+catId);
  }

  getUsers(): Observable<any>{
    return this.http.get<any>('http://localhost:52232/api/user');
  }

  addCategory(data:any):Observable<any>{
    return this.http.post<any>('http://localhost:52232/category',data);
  }
  addCourses(data:any):Observable<any>{
    return this.http.post<any>('http://localhost:52232/Course',data);
  }

  deleteCategory(id:number){
    return this.http.delete<any>('http://localhost:52232/category/'+id);
  }

  updateCategory(id:number, data:any):Observable<any>{
    return this.http.put<any>('http://localhost:52232/category/'+id, data);
  }
  updateCourses(id:number, data:any):Observable<any>{
    return this.http.put<any>('http://localhost:52232/Course/'+id, data);
  }


  getCoursesByCatId(catId:number):Observable<any>{
    return this.http.get<any>('http://localhost:52232/CourseByCatId/'+catId);
  }

  setSearchCourseData(){
    
  }
}
