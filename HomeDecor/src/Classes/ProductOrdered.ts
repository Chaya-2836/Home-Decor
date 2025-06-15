import { Product } from "./Product";

export class ProductOrdered {
  constructor(
    public id: number = 0,
    public product: Product,
    // public ProductSKU: number
    public quantity: number = 0) {
  }
}
