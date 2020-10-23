import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  user: any = {username: '', password: ''};

  constructor(
    private authService: AuthService,
    public toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  public logar(): void {
    this.authService.login(this.user).subscribe(
      () => this.toastr.success('Logado com sucesso!'),
      () => this.toastr.error('Ocorreu um erro ao tentar logar.'),
      () => this.router.navigate(['/user-profile']));
  }
}
