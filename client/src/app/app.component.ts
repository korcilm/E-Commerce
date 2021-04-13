import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E-Commerce';
  constructor() { }
  ngOnInit(): void {
    // this.http.get('http://localhost:10093/api/Product').subscribe((response:IPagination)=>{
    //   this.products=response.data;
    // },error=>{
    //   console.log(error);
    // });
  }
}
