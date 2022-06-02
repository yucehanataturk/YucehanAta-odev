import { Component, OnInit } from '@angular/core';
import { CourseModule } from '../Model/Course';

import { DataService } from 'src/app/services/data.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit-Course',
  templateUrl: './edit-Course.component.html',
  styleUrls: ['./edit-Course.component.css']
})
export class EditCourseComponent implements OnInit {

  id = this.actRoute.snapshot.params['CourseId'];
  status: boolean = false;
  clickEvent(){
      this.status = !this.status;       
  }

  message: string = '';
  editCourse: CourseModule = new CourseModule();

  constructor(private dataService: DataService, private actRoute: ActivatedRoute, private route:Router) { }

  ngOnInit(): void {
  }
editCourse(id:any, data:any){
  if(window.confirm('Yes, Please..!')){
    this.dataService.updateCourses(this.id, data).subscribe((res:any) =>{
        this.message = res;
        this.route.navigateByUrl('admin');
    })
  }
}
   
     
  }


