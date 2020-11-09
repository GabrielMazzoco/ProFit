import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { fromEvent } from 'rxjs';
import { map, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { PagamentoService } from 'src/app/services/pagamento.service';

@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamento.component.html',
  styleUrls: ['./pagamento.component.scss']
})
export class PagamentoComponent implements OnInit, AfterViewInit  {
  focus;

  pagamentos = [];

  @ViewChild('searchInput') input: ElementRef;

  constructor(
    private pagamentoService: PagamentoService
  ) { }

  ngOnInit() {
  }

  ngAfterViewInit(): void {
    this.searchInputHandler();
  }

  public searchInputHandler() {
    fromEvent<any>(this.input.nativeElement, 'keyup')
      .pipe(
        map(event => event.target.value),
        debounceTime(500),
        distinctUntilChanged(),
        switchMap(search => {
          return this.pagamentoService.buscarPagamentos(search);
        })
      ).subscribe((data) => {
        this.pagamentos = data;
      });
  }
}
