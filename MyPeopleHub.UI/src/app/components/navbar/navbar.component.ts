import { Component } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  items = [
    {
      label: 'Home',
      icon: 'pi pi-home',
      routerLink: '/'
    },
    {
      label: 'My friends',
      icon: 'pi pi-user',
      routerLink: '/friends'
    },
    {
      label: 'Search',
      icon: 'pi pi-search',
      routerLink: '/people'
    },
  ];
}
