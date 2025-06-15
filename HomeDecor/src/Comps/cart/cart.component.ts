import { Component, OnInit } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { CartService } from '../../Services/Cart.service';
import { ProductOrderedPrivate } from '../../Classes/ProductOrderedPrivate';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CurrencyPipe, RouterLink, RouterOutlet],
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  orderedItems: ProductOrderedPrivate[] = [];

  constructor(public CartS: CartService) {}

  ngOnInit(): void {
    this.orderedItems = this.CartS.cartItems;
  }

  getTotalPrice(): number {
    return this.CartS.getTotalPrice();
  }

  removeItem(itemId: number): void {
    this.CartS.removeItemById(itemId);
    this.orderedItems = this.CartS.cartItems;
  }

  increaseQuantity(item: ProductOrderedPrivate) {
    item.quantity++;
  }

  decreaseQuantity(item: ProductOrderedPrivate) {
    if (item.quantity > 1) {
      item.quantity--;
    }
  }

  getSubtotal(): number {
    return this.getTotalPrice() * 0.82;
  }

  getVat(): number {
    return this.getTotalPrice() * 0.18;
  }
}
