import { Component, OnInit } from '@angular/core';
import { CourseModule } from '../Model/Course';
import { DataService } from 'src/app/services/data.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-Course',
  templateUrl: './add-Course.component.html',
  styleUrls: ['./add-Course.component.css']
})
export class AddCourseComponent implements OnInit {
  status: boolean = false;
  clickEvent(){
      this.status = !this.status;       
  }

  
  isAdminLoggedIn = localStorage.getItem('admin');

  addCourse: CourseModule = new CourseModule();
  constructor(private dataService: DataService, private route: Router) { }



  ngOnInit(): void {
  }

  addCourse(data:any){
    if(window.confirm('Basariyla eklendi!!')){
    this.dataService.addCourses(this.addCourse).subscribe((data:{}) =>{
      this.route.navigate(['/admin'])
    })
  }
  }


  SignOut(){
    localStorage.removeItem('admin');
    this.route.navigateByUrl("admin");
  }

  SignIn(){
      this.route.navigateByUrl("adminLogin");
    }
}
