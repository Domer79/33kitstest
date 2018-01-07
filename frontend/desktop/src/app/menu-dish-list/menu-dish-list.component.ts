import { Component, OnInit, Input } from '@angular/core';
import { Menu, DishList } from '../contracts/contracts';
import { MenuService } from '../services/menu.service';
import { DishlistService } from '../services/dishlist.service';

@Component({
  selector: 'menu-dish-list',
  templateUrl: './menu-dish-list.component.html',
  styleUrls: ['./menu-dish-list.component.scss'],
  inputs: ['menu']
})
export class MenuDishListComponent implements OnInit {

  constructor(
    private menuService: MenuService,
    private dishListService: DishlistService
  ) { }

  //@Input()
  menu: Menu;
  dishList: DishList[];

  ngOnInit() {
    this.dishListService.getByIdMenu(this.menu.Id).subscribe(res => this.dishList = (res as DishList[]));
  }

}
