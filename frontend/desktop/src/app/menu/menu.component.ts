import { Component, OnInit } from '@angular/core';
import { Menu, DishList, Dish } from '../contracts/contracts';
import { MenuService } from '../services/menu.service';
import { NavbarService } from '../services/navbar-service.service';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import { AddMenuComponent } from '../dialogs/add-menu/add-menu.component';
import { AddDishesComponent } from '../dialogs/add-dishes/add-dishes.component';
import { DishlistService } from '../services/dishlist.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  menus: Menu[];

  constructor(
    private menuService: MenuService,
    private navbarService: NavbarService,
    private dishListService: DishlistService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.menuService.getMenus().subscribe(res => this.menus = (res as Menu[]))

    this.navbarService.getAddMenuClickEvent().subscribe(event => {
      const modalRef = this.modalService.open(AddMenuComponent);
      modalRef.componentInstance.name = 'World';
      modalRef.result.then((res) => {
        res.Date = new Date(res.Date.year, res.Date.month-1, res.Date.day, 5);
        this.menuService.createMenu(res).subscribe(() => {
            this.menuService.getMenus().subscribe(res => this.menus = (res as Menu[]));
        }, err => {
          console.log(err);
        });
      }, rej => {
        console.log(rej);
      })
    });

  }


  addDishes(menu: Menu){
    const modalRef = this.modalService.open(AddDishesComponent);
    modalRef.componentInstance.menu = menu;
    modalRef.result.then(res => {
      var dishList = res.map(item => {
        let dl = new DishList();
        dl.IdMenu = menu.Id;
        dl.IdDish = item.Id;
        dl.DishCount = item.dishCount;
        return dl;
      });
      this.dishListService.createManyDishList(dishList).subscribe(() => {
        this.menuService.getMenus().subscribe(res => this.menus = (res as Menu[]));
      });
    });
  }

}
