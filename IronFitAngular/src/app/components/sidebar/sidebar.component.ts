import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
  admin: boolean;
}
export const ROUTES: RouteInfo[] = [
  {
    path: '/dashboard',
    title: 'Dashboard',
    icon: 'ni-tv-2 text-primary',
    class: '',
    admin: true
  },
  { path: '/icons', title: 'Icons', icon: 'ni-planet text-blue', class: '', admin: false },
  // { path: '/maps', title: 'Maps', icon: 'ni-pin-3 text-orange', class: '', admin: false },
  {
    path: '/user-profile',
    title: 'User profile',
    icon: 'ni-single-02 text-yellow',
    class: '',
    admin: false
  },
  {
    path: '/aluno',
    title: 'Alunos',
    icon: 'ni-single-02 text-black',
    class: '',
    admin: false
  },
  // {
  //   path: '/tables',
  //   title: 'Tables',
  //   icon: 'ni-bullet-list-67 text-red',
  //   class: '',
  //   admin: false
  // },
  // { path: '/login', title: 'Login', icon: 'ni-key-25 text-info', class: '', admin: false },
  {
    path: '/modalidade',
    title: 'Modalidades',
    icon: 'ni-fat-add text-orange',
    class: '',
    admin: true
  },
  {
    path: '/register',
    title: 'Registrar Funcionário',
    icon: 'ni-circle-08 text-pink',
    class: '',
    admin: true
  }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  public menuItems: any[];
  public isCollapsed = true;
  public userAdmin: boolean;

  constructor(
    private router: Router,
    private authService: AuthService) {}

  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
    });

    this.userAdmin = this.authService.ehAdmin();
  }
}
