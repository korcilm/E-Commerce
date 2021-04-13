import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/IPagination';
import { IProductBrand } from '../shared/models/IProductBrand';
import { IProductType } from '../shared/models/IProductType';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl="http://localhost:10093/api/";
  constructor(private http:HttpClient) { }

  getProducts(brandId? : number,typeId? : number){
    let params=new HttpParams();
    if (brandId) {
      params=params.append('brandId',brandId.toString());
    }
    if (typeId) {
      params=params.append('typeId',typeId.toString());
    }

    return this.http.get<IPagination>(this.baseUrl + 'Product',{observe:'response',params}).pipe(
      map(response=>{
        return response.body;
      })
    );
  }
  getBrands(){
    return this.http.get<IProductBrand[]>(this.baseUrl + 'Product/brands');
  }
  getTypes(){
    return this.http.get<IProductType[]>(this.baseUrl + 'Product/types');
  }
}
