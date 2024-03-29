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
  {
    path: '/aluno',
    title: 'Alunos',
    icon: 'ni-single-02 text-black',
    class: '',
    admin: false
  },
  {
    path: '/pagamento',
    title: 'Pagamentos',
    icon: 'ni-money-coins text-black',
    class: '',
    admin: true
  },
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
    icon: 'ni-badge text-pink',
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
