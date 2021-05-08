import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/IProduct';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity:number=1;

  constructor(
    private shopService: ShopService,
    private activateRoute: ActivatedRoute,
    private breadcrumbService: BreadcrumbService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.loadProduct();
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.product, this.quantity);
  }

  incrementQuantity() {
    this.quantity++;
  }
  decrementQuantity() {
    if (this.quantity > 1) {
       this.quantity--;
    }
  }

  loadProduct() {
    this.shopService
      .getProduct(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe((pro) => {
        this.product = pro;
        this.breadcrumbService.set('@shopDetail', this.product.name);
      }),
      console.error();
  }
}
