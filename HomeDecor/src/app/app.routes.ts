import { Routes } from '@angular/router';
import { HomeComponent } from '../Comps/home/home.component';
import { DepartmentComponent } from '../Comps/department/department.component';
import { CategoryComponent } from '../Comps/category/category.component';
import { ProductComponent } from '../Comps/product/product.component';
import { PayComponent } from '../Comps/pay/pay.component';
import { CartComponent } from '../Comps/cart/cart.component';

export const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'department/:departmentId', component:DepartmentComponent},
    {path:'category/:category', component:CategoryComponent},
    {path:'product/:id', component:ProductComponent},
    {path:'shoppingCart', component:CartComponent, children:[    {path:'pay', component:PayComponent},
]},
];
