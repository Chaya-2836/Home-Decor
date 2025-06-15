import { Product } from "./Product";

export class Category {
    constructor(public id: number,
        public name: string,
        public description: string,
        public imageUrl: string,
        public products: Array<Product>) { }
}