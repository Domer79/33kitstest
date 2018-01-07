import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Rx';
import { Observer } from 'rxjs/Observer';

@Injectable()
export class NavbarService {
  private _addDishesMenuObservable: Observable<Event>;
  private _addDishesMenuObserver: Observer<Event>;
  private _addMenuObserver: Observer<Event>;
  private _addMenuObservable: Observable<Event>;

  constructor() { }

  getAddMenuClickEvent():Observable<Event>{
    return this._addMenuObservable || (this._addMenuObservable = Observable.create(observer => {
      this._addMenuObserver = observer;
    }));
  }

  addMenuClick(event: Event){
    if (this._addMenuObserver)
      this._addMenuObserver.next(event);
  }

  getAddDishesMenuClickEvent():Observable<Event>{
    return this._addDishesMenuObservable || (this._addDishesMenuObservable = Observable.create(observer => {
      this._addDishesMenuObserver = observer;
    }));
  }

  addDishesMenuClick(event: Event){
    if (this._addDishesMenuObserver)
      this._addDishesMenuObserver.next(event);
  }
}
