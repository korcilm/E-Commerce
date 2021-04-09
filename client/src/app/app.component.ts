import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IPagination } from './models/IPagination';
import { IProduct } from './models/IProduct';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E-Commerce';
  products:IProduct[];
  constructor(private http:HttpClient) { }
  ngOnInit(): void {
    this.http.get('http://localhost:10093/api/Product').subscribe((response:IPagination)=>{
      this.products=response.data;
    },error=>{
      console.log(error);
    });
  }


}
