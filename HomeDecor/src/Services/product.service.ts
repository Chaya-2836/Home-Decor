import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductInStock } from '../Classes/ProductInStock';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(public http: HttpClient) { }

  GetbyCategoryId(id: number): Observable<Array<ProductInStock>> {
    return this.http.get<Array<ProductInStock>>(`https://localhost:7107/api/ProductInStock/GetByCategoryId/${id}`)
  }
  Filter(
    categoryId: number,
    minPrice?: number,
    maxPrice?: number,
    types?: string[]
  ): Observable<ProductInStock[]> {
    const params: any = { categoryId };

    if (minPrice !== undefined) params.minPrice = minPrice;
    if (maxPrice !== undefined) params.maxPrice = maxPrice;
    if (types && types.length > 0) params.types = types;

    return this.http.get<Array<ProductInStock>>('https://localhost:7107/api/ProductInStock/filter', { params });
  }

  GetById(id: number): Observable<ProductInStock> {
    console.log(id);
    return this.http.get<ProductInStock>(`https://localhost:7107/api/ProductInStock/${id}`);
  }

}
