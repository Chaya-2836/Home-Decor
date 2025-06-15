import { Product } from "./Product";

export class ProductOrderedWithIdOnly {
  constructor(
    public id: number = 0,
    // public product: Product
    public ProductSKU: number
    , public quantity: number) {
  }
}
