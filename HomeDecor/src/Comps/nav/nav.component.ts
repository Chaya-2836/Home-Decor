import { Component, OnInit } from '@angular/core';
import { DepartmentService } from '../../Services/DepartmentService';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CartService } from '../../Services/Cart.service';

@Component({
  selector: 'app-nav',
  imports: [RouterModule, CommonModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent implements OnInit {
  constructor(public DepartmentS: DepartmentService, public cs: CartService) { }
  ngOnInit(): void {
    this.DepartmentS.getAll().subscribe(
      succ => { this.DepartmentS.allDepartments = succ }
    )
  }
}
