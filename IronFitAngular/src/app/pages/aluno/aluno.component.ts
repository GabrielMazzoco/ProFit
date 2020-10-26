import { AfterViewInit, Component, ElementRef, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { AlunoService } from 'src/app/services/aluno.service';
import { map, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { fromEvent } from 'rxjs';
import { ModalidadeService } from 'src/app/services/modalidade.service';
import { Aluno } from './aluno.model';

@Component({
  selector: 'app-aluno',
  templateUrl: './aluno.component.html',
  styleUrls: ['./aluno.component.scss']
})
export class AlunoComponent implements OnInit, AfterViewInit {
  focus;
  editar = false;

  alunos = [];
  modalidades = [];

  closeResult: string;
  @ViewChild('classic3') public templateref: TemplateRef<any>;
  @ViewChild('searchInput') input: ElementRef;

  aluno: Aluno = new Aluno();

  constructor(
    private alunoService: AlunoService,
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
      this.open();
    });
  }

  open() {
    this.modalService
      .open(this.templateref, {
        windowClass: 'modal',
        size: 'lg',
        centered: true,
      })
      .result.then(
        () => {
          this.aluno = new Aluno();
          this.editar = false;
        },
        () => {
          this.aluno = new Aluno();
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
