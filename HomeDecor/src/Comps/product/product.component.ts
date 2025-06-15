import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductInStock } from '../../Classes/ProductInStock';
import { ProductService } from '../../Services/product.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ShekelPipe } from '../../ShekelPipe';
import { CartService } from '../../Services/Cart.service';
import { ProductOrderedPrivate } from '../../Classes/ProductOrderedPrivate';
import { Location } from '@angular/common';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule, CommonModule, ShekelPipe],
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  productInStock: ProductInStock = new ProductInStock();
  selectedQuantity: number = 0;

  constructor(
    private ar: ActivatedRoute,
    private ps: ProductService,
    private cs: CartService,
    public l: Location
  ) { }

  ngOnInit(): void {
    this.ar.params.subscribe(params => {
      const id = +params['id'];
      this.ps.GetById(id).subscribe(p => {
        this.productInStock = p;
        this.selectedQuantity = this.productInStock.quantity! > 0 ? 1 : 0;
      });
    });
  }

  increaseQuantity() {
    if (this.selectedQuantity < (this.productInStock.quantity ?? 1)) {
      this.selectedQuantity++;
    }
  }

  decreaseQuantity() {
    if (this.selectedQuantity > 1) {
      this.selectedQuantity--;
    }
  }

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
    const translateX = cartRect.left - imageRect.left - 200;
    const translateY = cartRect.top - imageRect.top - 200;
    const scale = 0.1; // אפשר להתאים לפי הגודל

    requestAnimationFrame(() => {
      clone.style.transform = `translate(${translateX}px, ${translateY}px) scale(${scale})`;
      clone.style.opacity = '0.5';
    });

    setTimeout(() => {
      clone.remove();
    }, 500)

    setTimeout(() => {
      this.cs.addToCart(new ProductOrderedPrivate(0, this.productInStock!, this.selectedQuantity))
    }, 250)

    setTimeout(() => {
      this.l.back()
    }, 800)

  }

}
