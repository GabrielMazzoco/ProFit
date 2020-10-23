import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';

@Injectable()
export class AuthService extends BaseService {
  urlAuth: string;
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(http: HttpClient) {
    super(http);
    this.urlAuth = environment.urlApi + 'auth';
    const token = localStorage.getItem('token');
    if (token) {
      this.decodedToken = this.jwtHelper.decodeToken(token);
    }
  }

  public login(userForLogin: any) {
    return this.post(`${this.urlAuth}/login`, userForLogin).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  public ehAdmin(): boolean {
    return this.decodedToken.Admin === 'True';
  }
}
