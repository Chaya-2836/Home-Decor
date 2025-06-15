// cart.service.ts
import { Injectable } from '@angular/core';
import { ProductOrderedPrivate } from '../Classes/ProductOrderedPrivate';
import { HttpClient } from '@angular/common/http';
import { Order } from '../Classes/Order';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  public orderedProducts: ProductOrderedPrivate[] = [];

  constructor(public http: HttpClient) { }

  get cartItems(): ProductOrderedPrivate[] {
    return this.orderedProducts;
  }

  addToCart(item: ProductOrderedPrivate): void {

    const existingProduct = this.orderedProducts.find(op => op.product.product!.sku === item.product.product!.sku);

    if (existingProduct) {
      existingProduct.quantity += item.quantity;
    } else {
      this.orderedProducts.push(item);
    }

  }

  // הסרת מוצר לפי מזהה
  removeItemById(id: number): void {
    this.orderedProducts = this.orderedProducts.filter(item => item.product.id! !== id);
  }

  clearCart(): void {
    this.orderedProducts = [];
  }

  getTotalPrice(): number {
    return this.orderedProducts.reduce((sum, item) =>
      sum + ((item.product.product?.price || 0) * item.quantity), 0);
  }

  AddOrder(o: Order): Observable<Order> {
    return this.http.post<Order>(`https://localhost:7107/api/Order`, o)
  }
}
