import { ProductInStock } from "./ProductInStock";

export class ProductOrderedPrivate {
  constructor(
    public id: number = 0,
    public product: ProductInStock,
    public quantity: number) {
  }
}
