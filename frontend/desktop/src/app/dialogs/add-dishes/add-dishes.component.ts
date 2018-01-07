import { Component, OnInit, Input } from '@angular/core';
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { DishService } from '../../services/dish.service';
import { Dish, Menu } from '../../contracts/contracts';

@Component({
  selector: 'app-add-dishes',
  templateUrl: './add-dishes.component.html',
  styleUrls: ['./add-dishes.component.scss']
})
export class AddDishesComponent implements OnInit {
  dishes;
  selectedDishes = [];
  @Input() menu:Menu;

  constructor(
    public activeModal: NgbActiveModal,
    private dishService: DishService
  ) { }

  ngOnInit() {
    this.dishService.getDishesExcept(this.menu).subscribe(res => {
      this.dishes = res;
    });
  }

  setCount(event, dish){
    dish.dishCount = event.target.options[event.target.selectedIndex].value * 1;

    if (dish.dishCount == 0){
      let dishes = this.selectedDishes.filter(item => {
        return item.dishCount !== undefined && item.dishCount !== 0;
      });

      this.selectedDishes = dishes;
      return;
    }

    this.selectedDishes.push(dish);
  }
}
