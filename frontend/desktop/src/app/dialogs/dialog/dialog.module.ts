import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddMenuComponent } from '../add-menu/add-menu.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddDishesComponent } from '../add-dishes/add-dishes.component';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
  ],
  declarations: [
    AddMenuComponent,
    AddDishesComponent,
  ],
  entryComponents: [
    AddMenuComponent,
    AddDishesComponent,
  ]
})
export class DialogModule { }
