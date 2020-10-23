import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';

@Injectable()
export class ModalidadeService extends BaseService {
  urlAuth: string;

  constructor(http: HttpClient) {
    super(http);
    this.urlAuth = environment.urlApi + 'modalidade';
  }

  public buscarModalidades() {
    return this.get(this.urlAuth);
  }

  public buscarModalidade(id: number) {
    return this.get(`${this.urlAuth}/${id}`);
  }

  public criarModalidade(modalidade: any) {
    return this.post(this.urlAuth, modalidade);
  }

  public editarModalidade(modalidade: any) {
    return this.put(this.urlAuth, modalidade);
  }

  public inativarModalidade(id: number) {
    return this.delete(`${this.urlAuth}/${id}`);
  }
}
