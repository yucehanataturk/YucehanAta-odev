import { Component, OnInit } from '@angular/core';
import { CourseModule } from 'src/app/admin/Model/Course';
import { CartService } from 'src/app/services/cart.service';
import { DataService } from 'src/app/services/data.service';
import { WishlistService } from 'src/app/services/wishlist.service';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.css']
})
export class WishlistComponent implements OnInit {

  public Courses: any; 
  public products : any = [];
  public Course: CourseModule = new CourseModule();

  constructor(private dataService: DataService, private wishlistService: WishlistService, private cartService: CartService ) { }

  ngOnInit(): void {
    this.wishlistService.getCourses()
    .subscribe(res=>{
      this.Courses = res;
      // this.grandTotal = this.wishlistService.getTotalPrice();
    })
  }

  add(Course: any){
    this.cartService.addtoCart(Course);
    this.wishlistService.removeWishlistItem(Course);
  }

  remove(Course: any){
    this.wishlistService.removeWishlistItem(Course);
  }
}