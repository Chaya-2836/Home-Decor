import { Product } from "./Product";

export class ProductOrderedPublic {
  constructor(
    public id: number = 0,
    public ProductSKU: number
    , public quantity: number) {
  }
}
