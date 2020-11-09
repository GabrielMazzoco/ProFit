import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';

@Injectable()
export class PagamentoService extends BaseService {
  urlAuth: string;

  constructor(http: HttpClient) {
    super(http);
    this.urlAuth = environment.urlApi + 'pagamento';
  }

  public realizarPagamento(pagamento: any) {
    return this.post(this.urlAuth, pagamento);
  }

  public buscarPagamentos(nome: string) {
    if (nome) {
      return this.get(`${this.urlAuth}/${nome}`);
    }
    return this.get(`${this.urlAuth}/ `);
  }
}
