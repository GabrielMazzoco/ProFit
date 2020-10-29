import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ModalidadeService } from 'src/app/services/modalidade.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-modalidade',
  templateUrl: './modalidade.component.html',
  styleUrls: ['./modalidade.component.scss'],
})
export class ModalidadeComponent implements OnInit {
  modalidades = [];

  closeResult: string;
  @ViewChild('classic3') public templateref: TemplateRef<any>;

  modalidade = {nome: '', valorPadrao: '', id: 0, idAcademia: 0};

  constructor(
    private modalidadeService: ModalidadeService,
    private modalService: NgbModal,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.buscarModalidades();
  }

  public salvar(): void {
    this.modalidade.idAcademia = Number(this.modalidade.idAcademia);

    if (this.modalidade.idAcademia === 0) { 
      this.toastr.info('Selecione uma Academia.');
      return;
    }

    if (this.modalidade.id === 0) {
      this.salvarModalidade();
    } else {
      this.editarModalidade();
    }
  }

  public inativarModalidade(id: number): void {
    this.modalidadeService.inativarModalidade(id).subscribe(
      () => this.toastr.success('Modalidade inativada com sucesso'),
      () => this.toastr.error('Houve um erro ao inativar a modalidade'),
      () => this.buscarModalidades());
  }

  public abrirModalEditar(id: number): void {
    this.modalidadeService.buscarModalidade(id).subscribe(result => {
      this.modalidade = result;
      this.open();
    });
  }

  open() {
    this.modalService
      .open(this.templateref, {
        windowClass: 'modal',
        size: 'md',
        centered: true,
      })
      .result.then(
        () => this.modalidade = {nome: '', valorPadrao: '', id: 0, idAcademia: 0},
        () => this.modalidade = {nome: '', valorPadrao: '', id: 0, idAcademia: 0}
      );
  }

  private buscarModalidades(): void {
    this.modalidadeService.buscarModalidades().subscribe((response) => {
      this.modalidades = response;
    });
  }

  private salvarModalidade(): void {
    this.modalidadeService.criarModalidade(this.modalidade).subscribe(
      () => this.toastr.success('Modalidade criada com sucesso'),
      () => this.toastr.error('Houve um erro ao cadastrar a modalidade'),
      () => this.buscarModalidades());
  }

  private editarModalidade(): void {
    this.modalidadeService.editarModalidade(this.modalidade).subscribe(
      () => this.toastr.success('Modalidade editada com sucesso'),
      () => this.toastr.error('Houve um erro ao editar a modalidade'),
      () => this.buscarModalidades());
  }
}
