import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuDishListComponent } from './menu-dish-list.component';

describe('MenuDishListComponent', () => {
  let component: MenuDishListComponent;
  let fixture: ComponentFixture<MenuDishListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuDishListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuDishListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
