import { Product } from "./Product";

export class ProductInStock{
    
    constructor(public id?:number,
                public product?:Product,
                public quantity?:number
    ) {}
}