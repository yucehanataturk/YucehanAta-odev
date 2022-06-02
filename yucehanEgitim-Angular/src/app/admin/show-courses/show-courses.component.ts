import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-show-Courses',
  templateUrl: './show-Courses.component.html',
  styleUrls: ['./show-Courses.component.css']
})
export class ShowCoursesComponent implements OnInit {
  status: boolean = false;
  clickEvent(){
      this.status = !this.status;       
  }

  isAdminLoggedIn: boolean = true;
  constructor(private router: Router, private matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
  }
onClick(){
  this.router.navigate(['edit-Course'])
}

SignOut(){
  localStorage.clear();
  this.isAdminLoggedIn = false;
  this.router.navigateByUrl("admin");
}

SignIn(){
  if(localStorage.getItem("token")=== null){
    this.matSnackBar.open("Please Login First",'ok',{
      duration: 5000
    });
    this.router.navigateByUrl("login");
  }
}

}
