import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WishlistService {

  public wishItemList : any =[]
  public productList = new BehaviorSubject<any>([]);

  constructor() { }

  getCourses(){
    return this.productList.asObservable();
  }

  addtoWishlist(Course : any){
    this.wishItemList.push(Course);
    this.productList.next(this.wishItemList);
    
  }

  removeWishlistItem(product: any){
    this.wishItemList.map((a:any, index:any)=>{
      if(product.id=== a.id){
        this.wishItemList.splice(index,1);
      }
    })
    this.productList.next(this.wishItemList);
  }

  removeAllWishlist(){
    this.wishItemList = []
    this.productList.next(this.wishItemList);
  }

}