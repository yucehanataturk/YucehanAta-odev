import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { CourseModule } from '../admin/Model/Course';
import { Cart } from '../admin/Model/cart';
 
 

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList : any =[]
  public productList = new BehaviorSubject<any>([]);
  public search = new BehaviorSubject<string>("");

  private defaultCartItems: any[] = [

];

constructor(private http:HttpClient) { }

private cartItemsList = new BehaviorSubject(this.defaultCartItems);

latestCartItemsList: Observable<any> = this.cartItemsList.asObservable();

 


  getCourses(){
    return this.productList.asObservable();
  }

  setProduct(product : any){
    this.cartItemList.push(...product);
    this.productList.next(product);
  }

  addtoCart(Course : any){
    this.cartItemList.push(Course);
    this.productList.next(this.cartItemsList);
    this.getTotalPrice();
    console.log(this.cartItemList)
  }

  getTotalPrice() : number{
    let grandTotal = 0;
    this.cartItemList.map((a:any)=>{
      grandTotal += a.Price;
    })
    return grandTotal;
  }
  removeCartItem(product: any){
    this.cartItemList.map((a:any, index:any)=>{
      if(product.id=== a.id){
        this.cartItemList.splice(index,1);
      }
    })
    // this.productList.next(this.cartItemList);
  }
  removeAllCart(){
    this.cartItemList = []
    this.productList.next(this.cartItemList);
  }


//Cart CRUD Services
  getCart(){
    return this.http.get<any>('http://localhost:52232/cart');
  }

  getCartById(cartId:number): Observable<any>{
    return this.http.get<any>('http://localhost:52232/cart/'+cartId);
  }

  addCart(data:any):Observable<any>{
    return this.http.post<any>('http://localhost:52232/cart',data);
  }

  updateCart(data:any, cartId:number):Observable<any>{
    return this.http.put<any>('http://localhost:52232/cart/'+cartId,data);
  }


//
updateCarts(Course: any): void{
  this.latestCartItemsList
  .pipe(take(1))
  .subscribe( (cartItems:any) =>{
    const newCartItemsArr = [... cartItems, Course];
    this.cartItemsList.next(newCartItemsArr)
  });
}

getUser = localStorage.getItem('user');

getCartItem() : Observable<Cart[]>{
  return this.http.get<Cart[]>('http://localhost:3000/cart');
}

addProductToCart(product: any, userEmail:string): Observable<any>{
  return this.http.post('http://localhost:3000/cart',{product,userEmail});
}

}
