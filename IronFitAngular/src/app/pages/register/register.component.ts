import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  user = { name: '', username: '', password: '', academias: '' };

  constructor(
    private userService: UserService,
    public toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit() {}

  public registrar(): void {
    if (this.user.academias === '') {
      this.toastr.info('Selecione uma Academia');
      return;
    }

    this.userService.registrar(this.user).subscribe(
      () => {
        this.toastr.success('Registrado com sucesso!');
        this.router.navigate(['/login']);
      },
      () => {
        this.toastr.error('Houve um erro ao registrar o usuário');
      }
    );
  }
}
