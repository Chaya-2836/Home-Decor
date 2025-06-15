import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../Services/product.service';
import { CategoryService } from '../../Services/category.service';
import { ProductInStock } from '../../Classes/ProductInStock';
import { Category } from '../../Classes/Category';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { ShekelPipe } from '../../ShekelPipe';
import { NgxSliderModule } from '@angular-slider/ngx-slider';
import { Options } from '@angular-slider/ngx-slider';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [FormsModule, CommonModule, ShekelPipe, ProductDetailsComponent, NgxSliderModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  products: ProductInStock[] = [];
  category: Category | undefined;
  categoryId!: number;

  minPrice: number = 0;
  maxPrice: number = 10000;

  priceOptions: Options = {
    floor: 0,
    ceil: 10000,
    step: 10,
    translate: (value: number): string => {
      return value + ' ₪';
    },
  };

  selectedTypes: string[] = [];
  types: string[] = ['Classic', 'Daring', 'Conservative', 'Elegant'];
  typeLabels: { [key: string]: string } = {
    Classic: 'קלאסי',
    Daring: 'נועז',
    Conservative: 'שמרני',
    Elegant: 'אלגנטי'
  };

  selectedSort: 'asc' | 'desc' | undefined = undefined;

  constructor(
    public productS: ProductService,
    public categoryS: CategoryService,
    public ar: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.ar.params.subscribe(params => {
      this.categoryId = +params['category'];

      this.categoryS.GetById(this.categoryId).subscribe(cat => {
        this.category = cat;
      });

      this.loadFilteredProducts();
    });
  }

  loadFilteredProducts() {
    const typesToSend = this.selectedTypes.length > 0 ? this.selectedTypes : undefined;

    this.productS.Filter(
      this.categoryId,
      this.minPrice,
      this.maxPrice,
      typesToSend
    ).subscribe(data => {
      this.products = data;
      this.sortProducts(); // מיון לאחר טעינה
    });
  }

  applyFilters() {
    this.loadFilteredProducts();
  }

  onTypeChange(event: Event) {
    const checkbox = event.target as HTMLInputElement;
    const value = checkbox.value;

    if (checkbox.checked) {
      if (!this.selectedTypes.includes(value)) {
        this.selectedTypes.push(value);
      }
    } else {
      this.selectedTypes = this.selectedTypes.filter(t => t !== value);
    }

    this.applyFilters();
  }

  setSortOrder(order: 'asc' | 'desc' | undefined) {
    this.selectedSort = order;
    this.sortProducts();
  }

  sortProducts() {
    if (!this.selectedSort) return;

    const withProduct = this.products.filter(p => p.product && p.product.price != null);
    const withoutProduct = this.products.filter(p => !p.product || p.product.price == null);

    withProduct.sort((a, b) => {
      const priceA = a.product!.price!;
      const priceB = b.product!.price!;
      return this.selectedSort === 'asc' ? priceA - priceB : priceB - priceA;
    });

    this.products = [...withProduct, ...withoutProduct];
  }}