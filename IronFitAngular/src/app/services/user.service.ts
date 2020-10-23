import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';

@Injectable()
export class UserService extends BaseService {
  urlAuth: string;

  constructor(http: HttpClient) {
    super(http);
    this.urlAuth = environment.urlApi + 'user';
  }

  public registrar(user: any) {
    return this.post(`${this.urlAuth}`, user);
  }
}
