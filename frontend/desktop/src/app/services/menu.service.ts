import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Menu } from '../contracts/contracts';

@Injectable()
export class MenuService {  
  constructor(
    private http: HttpClient
  ) { }

  getMenus(): Observable<any>{
    return this.http.get("menu");
  }

  getMenu(idMenu): Observable<any>{
    return this.http.get(`menu/getbyid?id=${idMenu}`);
  }

  createMenu(menu: Menu): Observable<any>{
    return this.http.post(`menu`, menu);
  }

  updateMenu(menu: Menu): Observable<any>{
    return this.http.put(`menu/${menu.Id}`, menu);
  }

  removeMenu(id): Observable<any>{
    return this.http.delete(`menu/${id}`)
  }
}
