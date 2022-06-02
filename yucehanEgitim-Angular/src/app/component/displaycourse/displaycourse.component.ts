import { Component, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { ActivatedRoute, Router } from '@angular/router';
import {MatSnackBarModule, MatSnackBar} from '@angular/material/snack-bar';
import { WishlistService } from 'src/app/services/wishlist.service';
import { CartService } from 'src/app/services/cart.service';
import { Observable } from 'rxjs';
import { CourseModule } from 'src/app/admin/Model/Course';
 

@Component({
  selector: 'app-displayCourse',
  templateUrl: './displayCourse.component.html',
  styleUrls: ['./displayCourse.component.css']
})
export class DisplayCourseComponent implements OnInit {


 public products: any;
 public categoryProducts: any;

 public categories: any;

 public catName: any;

 public Courses: any;
 public subCategories: any;

  LoggedInUserDetails = localStorage.getItem('user');
  
  

isShow = false; 

 searchKey:string = "";
  
isLoggedIn  = localStorage.getItem("token");
public CourseId: any;
public catId: any;
 
 

  constructor(private dataService: DataService, private activateRoute:ActivatedRoute,
    private route: Router,private matSnackBar: MatSnackBar, private wishlistService: WishlistService,
    private cartService:CartService
   
    ) {
    this.catName= activateRoute.snapshot.paramMap.get('catName');
    this.CourseId = activateRoute.snapshot.paramMap.get('CourseId');
    this.catId= activateRoute.snapshot.paramMap.get('catId');
   }

  ngOnInit(): void {
    this.dataService.getCourses().subscribe(response =>{
      this.Courses = response;
    })
    this.dataService.getCategories().subscribe(data =>{
      this.categories = data;
    })
    this.dataService.getCoursesById(this.CourseId).subscribe(data =>{
      this.subCategories = data;
    })

    this.dataService.getCategoriesById(this.catId).subscribe(data =>{
      this.products = data;
    })

    // this.Courses.forEach((a:any) => {
    //   Object.assign(a,{quantity:1,total:a.price})
    // });

    this.cartService.search.subscribe((val:any) =>{
      this.searchKey = val;
    })
  }

   
  addToWish( Course: any) {
    // if (localStorage.getItem('token') === null) {
    //   this.matSnackBar.open('Please Login first', 'ok', {
    //     duration: 5000
    //   });
    //   this.route.navigateByUrl('login');
    // }
    // this.matSnackBar.open("LoggedIn");
    this.wishlistService.addtoWishlist(Course);
    alert("Course is added to wishlist!");
    }


  // onCategorySelected(catId: any){
  //   this.dataService.getProductById(catId).subscribe(response => {
  //     this.products = response.data;
  //   })
  // }


  addtocart(Course: any){
     
    this.cartService.addtoCart(Course);
    // this.route.navigateByUrl('cart-component');
  }


  OnCategorySelect(catId:any){
    this.dataService.getCoursesByCatId(catId).subscribe(response =>{
      this.Courses = response;
    })
  }
  // onCategorySelected(catId: any){
  //   this.dataService.getProductById(catId).subscribe(response => {
  //     this.products = response.data;
  //   })
  // }
  onclick(){
    this.route.navigateByUrl('Courses');
  }

  addCourse: CourseModule = new CourseModule();
  //add to cart handler
  handleAddToCart(Course: CourseModule, CourseId:any,userDetails:any ): void{
    if(window.confirm('Successfully Added!!')){
      this.cartService.addProductToCart(CourseId,userDetails).subscribe((Course:{}) =>{
        this.route.navigate(['/Courses'])
      })
    }
    this.cartService.updateCarts(Course);
  }


  
}
