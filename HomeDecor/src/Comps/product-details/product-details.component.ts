import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductInStock } from '../../Classes/ProductInStock';
import { RouterLink } from '@angular/router';
import { CartService } from '../../Services/Cart.service';
import { ProductOrderedPrivate } from '../../Classes/ProductOrderedPrivate';

@Component({
  selector: 'product-details',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent {
  @Input() productInStock!: ProductInStock;

  constructor(private cs: CartService) { }

  addToCart(imageElement: HTMLImageElement) {
    const cart = document.getElementById('cart');

    const imageRect = imageElement.getBoundingClientRect();
    const cartRect = cart!.getBoundingClientRect();
    const clone = imageElement.cloneNode(true) as HTMLImageElement;
    clone.classList.add('fly-image');
    clone.style.left = imageRect.left + 'px';
    clone.style.top = imageRect.top + 'px';
    clone.style.width = imageRect.width + 'px';
    clone.style.height = imageRect.height + 'px';

    document.body.appendChild(clone);

    // חישוב המרחק להזזה
    const translateX = cartRect.left - imageRect.left - 90;
    const translateY = cartRect.top - imageRect.top - 87;
    const scale = 0.1; // אפשר להתאים לפי הגודל

    requestAnimationFrame(() => {
      clone.style.transform = `translate(${translateX}px, ${translateY}px) scale(${scale})`;
      clone.style.opacity = '0.5';
    });

    setTimeout(() => {
      clone.remove();
    }, 700)

    setTimeout(() => {
      this.cs.addToCart(new ProductOrderedPrivate(0, this.productInStock!, 1))
    }, 350)

  }
}
