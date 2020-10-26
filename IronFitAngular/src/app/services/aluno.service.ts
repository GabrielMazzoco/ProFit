import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';

@Injectable()
export class AlunoService extends BaseService {
  urlAuth: string;

  constructor(http: HttpClient) {
    super(http);
    this.urlAuth = environment.urlApi + 'aluno';
  }

  public buscarAlunos(nome: string) {
    if (nome) {
      return this.get(`${this.urlAuth}/filter/${nome}`);
    }
    return this.get(`${this.urlAuth}/filter/ `);
  }

  public buscarAluno(id: number) {
    return this.get(`${this.urlAuth}/${id}`);
  }

  public criarAluno(aluno: any) {
    return this.post(this.urlAuth, aluno);
  }

  public editarAluno(aluno: any) {
    return this.put(this.urlAuth, aluno);
  }

  public inativarAluno(id: number) {
    return this.delete(`${this.urlAuth}/${id}`);
  }
}
