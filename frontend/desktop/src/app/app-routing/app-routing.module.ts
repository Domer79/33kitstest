import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from '../menu/menu.component';
import { DishComponent } from '../dish/dish.component';
import { ProductComponent } from '../product/product.component';
import { ProductMovementComponent } from '../product-movement/product-movement.component';
import { ImageLoadComponent } from '../image-load/image-load.component';

const appRoutes: Routes = [
  {
    path: "",
    redirectTo: "/menu",
    pathMatch: "full"
  },
  {
    path: "menu",
    component: MenuComponent
  },
  {
    path: "dish",
    component: DishComponent
  },
  {
    path: "product",
    component: ProductComponent
  },
  {
    path: "productmovement",
    component: ProductMovementComponent
  },
  {
    path: "imagetest",
    component: ImageLoadComponent
  }
]

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes, {
      enableTracing: false
    })
  ],
  declarations: [],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
