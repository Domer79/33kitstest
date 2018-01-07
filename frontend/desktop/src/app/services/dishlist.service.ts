import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { DishList } from '../contracts/contracts';

@Injectable()
export class DishlistService {

  constructor(
    private http: HttpClient
  ) { }

  get(): Observable<any>{
    return this.http.get("dishlist");
  }

  getByIdMenu(idMenu): Observable<any>{
    return this.http.get(`dishlist/GetByIdMenu?idmenu=${idMenu}`);
  }

  getDishList(idMenu, idDish): Observable<any>{
    return this.http.get(`dishlist/get?idmenu=${idMenu}&iddish=${idDish}`);
  }

  createDishList(dishList: DishList): Observable<any>{
    return this.http.post(`dishlist`, dishList);
  }

  removeDishList(dishList: DishList): Observable<any>{
    return this.http.delete(`dishlist?idmenu=${dishList.IdMenu}&iddish=${dishList.IdDish}`);
  }

  createManyDishList(dishList: DishList[]): Observable<any>{
    return this.http.post(`dishlist/createmany`, dishList);
  }
}
