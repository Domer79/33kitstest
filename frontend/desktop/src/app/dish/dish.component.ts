import { Component, OnInit } from '@angular/core';
import { DishService } from '../services/dish.service';
import { Dish } from '../contracts/contracts';

@Component({
  selector: 'dish',
  templateUrl: './dish.component.html',
  styleUrls: ['./dish.component.scss'],
  inputs: ['id']
})
export class DishComponent implements OnInit {
  dish: Dish;
  id: string;

  constructor(
    private dishService: DishService
  ) { }

  ngOnInit() {
    this.dishService.getDish(this.id).subscribe(res => this.dish = res as Dish);
  }

}
