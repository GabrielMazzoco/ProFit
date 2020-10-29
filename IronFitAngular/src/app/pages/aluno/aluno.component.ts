import { AfterViewInit, Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AlunoService } from 'src/app/services/aluno.service';
import { map, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { fromEvent } from 'rxjs';
import { ModalidadeService } from 'src/app/services/modalidade.service';
import { Aluno } from './aluno.model';
import { Pagamento } from './pagamento.model';
import { PagamentoService } from 'src/app/services/pagamento.service';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
})
export class AlunoComponent implements OnInit, AfterViewInit {
  focus;
  editar = false;

  meses = [
    {id: 1, nome: 'Janeiro'},
    {id: 2, nome: 'Fevereiro'},
    {id: 3, nome: 'Março'},
    {id: 4, nome: 'Abril'},
    {id: 5, nome: 'Maio'},
    {id: 6, nome: 'Junho'},
    {id: 7, nome: 'Julho'},
    {id: 8, nome: 'Agosto'},
    {id: 9, nome: 'Setembro'},
    {id: 10, nome: 'Outubro'},
    {id: 11, nome: 'Novembro'},
    {id: 12, nome: 'Dezembro'},
  ];

  alunos = [];
  modalidades = [];

  closeResult: string;
  @ViewChild('classic3') public modalAlunoRef: TemplateRef<any>;
  @ViewChild('classic4') public modalPagamentoRef: TemplateRef<any>;
  @ViewChild('searchInput') input: ElementRef;

  aluno: Aluno = new Aluno();
  pagamento: Pagamento = new Pagamento();

  constructor(
    private alunoService: AlunoService,
    private pagamentoService: PagamentoService,
    private modalidadeService: ModalidadeService,
    private modalService: NgbModal,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.buscarAlunos();
    this.buscarModalidades();
  }

  ngAfterViewInit(): void {
    this.searchInputHandler();
  }

  public salvar(): void {
    if (this.aluno.id === 0) {
      this.salvarAluno();
    } else {
      this.editarAluno();
    }
  }

  public pagar(): void {
    this.pagamento.mesReferencia = Number(this.pagamento.mesReferencia);
    this.pagamentoService.realizarPagamento(this.pagamento).subscribe(
      () => this.toastr.success('Pagamento realizado com sucesso'),
      () => this.toastr.error('Houve um erro ao realizar o pagamento')
    );
  }

  public abrirModalEditar(id: number): void {
    this.editar = true;
    this.alunoService.buscarAluno(id).subscribe(result => {
      this.aluno = result;
      this.aluno.dataNascimento = new Date(result.dataNascimento);
      this.aluno.dataMatricula = new Date(result.dataMatricula);

      this.aluno.dataNascimentoPicker = { year: this.aluno.dataNascimento.getFullYear(),
        month: this.aluno.dataNascimento.getMonth(), day: this.aluno.dataNascimento.getDate() };
      this.aluno.dataMatriculaPicker = { year: this.aluno.dataMatricula.getFullYear(),
        month: this.aluno.dataMatricula.getMonth(), day: this.aluno.dataMatricula.getDate() };
      this.open('modalAlunoRef');
    });
  }

  public abrirModalPagamento(aluno: Aluno): void {
    this.pagamento.idAluno = Number(aluno.id);

    const modalidadeAluno = this.modalidades.find(x => x.id === aluno.idModalidade);

    this.pagamento.valor = modalidadeAluno.valorPadrao;

    this.open('modalPagamentoRef');
  }

  open(modalNome: string) {
    this.modalService
      .open(this[modalNome], {
        windowClass: 'modal',
        size: 'lg',
        centered: true,
      })
      .result.then(
        () => {
          this.aluno = new Aluno();
          this.pagamento = new Pagamento();
          this.editar = false;
        },
        () => {
          this.aluno = new Aluno();
          this.pagamento = new Pagamento();
          this.editar = false;
        }
      );
  }

  private buscarAlunos(): void {
    this.alunoService.buscarAlunos('').subscribe((response) => {
      this.alunos = response;
    });
  }

  private salvarAluno(): void {
    this.converterDados();

    this.alunoService.criarAluno(this.aluno).subscribe(
      () => this.toastr.success('Aluno matriculado com sucesso'),
      () => this.toastr.error('Houve um erro ao matricular o aluno'),
      () => this.buscarAlunos());
  }

  private editarAluno(): void {
    this.converterDados();

    this.alunoService.editarAluno(this.aluno).subscribe(
      () => this.toastr.success('Aluno editado com sucesso'),
      () => this.toastr.error('Houve um erro ao editar o aluno'),
      () => this.buscarAlunos());
  }

  public searchInputHandler() {
    fromEvent<any>(this.input.nativeElement, 'keyup')
      .pipe(
        map(event => event.target.value),
        debounceTime(200),
        distinctUntilChanged(),
        switchMap(search => {
          return this.alunoService.buscarAlunos(search);
        })
      ).subscribe((data) => {
        this.alunos = data;
      });
  }

  private buscarModalidades(): void {
    this.modalidadeService.buscarModalidades().subscribe((response) => {
      this.modalidades = response;
    });
  }

  private converterDados(): void {
    this.aluno.dataNascimento = new Date(this.aluno.dataNascimentoPicker.year,
      this.aluno.dataNascimentoPicker.month, this.aluno.dataNascimentoPicker.day);
    this.aluno.dataMatricula = new Date(this.aluno.dataMatriculaPicker.year,
      this.aluno.dataMatriculaPicker.month, this.aluno.dataMatriculaPicker.day);
    this.aluno.idModalidade = Number(this.aluno.idModalidade);
  }
}
