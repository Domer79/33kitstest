import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { Router, NavigationStart } from '@angular/router';
import { Observable } from "rxjs/Observable";
import { Navigation } from 'selenium-webdriver';
import { NavbarService } from '../services/navbar-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './app-navbar.component.html',
  styleUrls: ['./app-navbar.component.scss']
})
export class AppNavbarComponent implements OnInit {
  url: string;

  constructor(
    private router: Router,
    private navbarService: NavbarService
  ) { }

  ngOnInit() {
    this.router.events.subscribe((r:NavigationStart) => {
      this.url = r.url;
    });
  }

  addMenu(event){
    this.navbarService.addMenuClick(event);
  }

  devMode = !environment.production;
}
