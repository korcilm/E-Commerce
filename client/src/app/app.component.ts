import { Component } from '@angular/core';
import { error } from 'selenium-webdriver';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'E-Commerce';
  constructor(private basketService:BasketService,private accountService:AccountService) { }
  ngOnInit(): void {
   this.loadBasket();
   this.loadCurrentUser();
  }

  loadCurrentUser(){
    const token=localStorage.getItem('token');
      this.accountService.loadCurrentUser(token).subscribe(()=>{ 
        console.log('LOaded User');
      },(error)=>{
          console.log(error);
        }
      )
  }

  loadBasket(){
    const basketId=localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(()=>{
        console.log("initialize basket");
      },error=>{
        console.log(error);
      });
    }
  }
}
