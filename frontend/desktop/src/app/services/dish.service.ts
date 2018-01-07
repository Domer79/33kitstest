import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Menu } from '../contracts/contracts';

@Injectable()
export class DishService {

  constructor(
    private http: HttpClient
  ) { }

  getDish(id): Observable<any>{
    return this.http.get(`dish/${id}/getdish`);
  }

  getDishes(): Observable<any>{
    return this.http.get(`dish`);
  }

  getDishesExcept(menu: Menu): Observable<any>{
    return this.http.get(`dish/${menu.Id}/except`);
  }
}
