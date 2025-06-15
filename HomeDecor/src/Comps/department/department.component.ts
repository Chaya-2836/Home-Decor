import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../Services/category.service';
import { Category } from '../../Classes/Category';
import { DepartmentService } from '../../Services/DepartmentService';
import { Department } from '../../Classes/Department';
import { ProductService } from '../../Services/product.service';
import { ProductInStock } from '../../Classes/ProductInStock';
import { ProductDetailsComponent } from '../product-details/product-details.component';

@Component({
  selector: 'department',
  standalone: true,
  imports: [RouterModule, CommonModule, ProductDetailsComponent],
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  constructor(public cs: CategoryService, public ar: ActivatedRoute, public ds: DepartmentService, public ps: ProductService) { }

  ngOnInit(): void {

    this.ar.params.subscribe(params => {
      const id = +params['departmentId'];

      this.cs.GetbyDepartmentId(id).subscribe(c => {
        this.categories = c;

        this.productsWithCategoryId = [];

        this.categories.forEach(category => {
          this.ps.GetbyCategoryId(category.id).subscribe(p => {
            const withCategory = p.map(p => ({
              ...p,
              categoryId: category.id
            }));
            this.productsWithCategoryId.push(...withCategory);
          });
        });

      });

      this.departmentDetailes = this.ds.allDepartments.find(d => d.id == id)!;

    });

  }

  get productsToDisplay() {
    if (this.selectedCategoryIds.length === 0) {
      return this.productsWithCategoryId;
    }
    return this.productsWithCategoryId.filter(p =>
      this.selectedCategoryIds.includes(p.categoryId)
    );
  }

  onCategoryToggle(categoryId: number, event: Event) {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      if (!this.selectedCategoryIds.includes(categoryId)) {
        this.selectedCategoryIds.push(categoryId);
      }
    } else {
      this.selectedCategoryIds = this.selectedCategoryIds.filter(id => id !== categoryId);
    }
  }

  getProductCountForCategory(categoryId: number): number {
    return this.productsWithCategoryId.filter(p => p.categoryId === categoryId).length;
  }


  categories: Array<Category> = [];

  departmentDetailes: Department = new Department()

  // products: Array<ProductInStock> = []

  selectedCategoryIds: number[] = [];

  productsWithCategoryId: Array<ProductInStock & { categoryId: number }> = [];

}
