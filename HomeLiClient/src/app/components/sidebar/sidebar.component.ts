import { Component, OnInit } from '@angular/core';

const baseUrl = 'http://localhost:4200/';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.less']
})

export class SidebarComponent implements OnInit {
  public sidebarItems;

  constructor() {
    this.sidebarItems = [
      {
        title: 'Dashboard',
        icon: 'home',
        path: baseUrl
      },
      {
        title: 'Books',
        icon: 'book',
        path: `${baseUrl}library/books`
      }
    ];
  }

  ngOnInit() {
  }

}
