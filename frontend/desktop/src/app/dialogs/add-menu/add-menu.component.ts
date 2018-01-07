import { Component, OnInit, Input } from '@angular/core';
import {NgbModal, NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import { Menu } from '../../contracts/contracts';

@Component({
  selector: 'add-menu',
  templateUrl: './add-menu.component.html',
  styleUrls: ['./add-menu.component.scss']
})
export class AddMenuComponent implements OnInit {
  @Input() name: string
  constructor(
    public activeModal: NgbActiveModal,
  ) { }

  ngOnInit() {
  }


  menu: Menu = new Menu();
}
