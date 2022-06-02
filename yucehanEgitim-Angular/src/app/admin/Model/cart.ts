import { CourseModule } from '../Model/Course';

export class Cart {
    id ?:number;
    productId ?: number;
    productName ?:string;
    qty ?:number;
    price?:number;
    productDesc ?:string;
    productImage ?:string;

    constructor(id:number, product:CourseModule, qty=1){
        this.id = id;
        this.productName = product.Title;
        this.productDesc = product.Description;
        this.price = product.Price;
        this.qty = qty;
        this.productImage = product.imageName;
    }

}
