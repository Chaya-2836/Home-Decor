import { ProductOrderedPublic } from "./ProductOrderedPublic";

export class Order {
    constructor(
        public id: number = 0,
        // public orderDate: Date = new Date(),
        public customerFirstName: string = "",
        public phone: string = "",
        public customerLastName: string = "",
        public customerEmail: string = "",
        public ordered: Array<ProductOrderedPublic>
    ) { }
}