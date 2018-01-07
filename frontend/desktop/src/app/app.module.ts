import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CustomInterceptor } from './services/http-client.interceptor';

import { AppComponent } from './app.component';
import { HelloWorldComponent } from './hello-world/hello-world.component';
import { AppNavbarComponent } from './app-navbar/app-navbar.component';
import { MenuComponent } from './menu/menu.component';
import { DishComponent } from './dish/dish.component';
import { ProductComponent } from './product/product.component';
import { ProductMovementComponent } from './product-movement/product-movement.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { ImageLoadComponent } from './image-load/image-load.component';
import { MenuDishListComponent } from './menu-dish-list/menu-dish-list.component';
import { MenuService } from './services/menu.service';
import { DishlistService } from './services/dishlist.service';
import { DishService } from './services/dish.service';
import { DialogModule } from './dialogs/dialog/dialog.module';
import { NavbarService } from './services/navbar-service.service';

@NgModule({
  declarations: [
    AppComponent,
    HelloWorldComponent,
    AppNavbarComponent,
    MenuComponent,
    DishComponent,
    ProductComponent,
    ProductMovementComponent,
    ImageLoadComponent,
    MenuDishListComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule.forRoot(),
    AppRoutingModule,
    DialogModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: CustomInterceptor,
      multi: true,
    },
    MenuService,
    DishlistService,
    DishService,
    NavbarService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }  
