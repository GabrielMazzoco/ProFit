import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { ModalidadeComponent } from 'src/app/pages/modalidade/modalidade.component';
import { AlunoComponent } from 'src/app/pages/aluno/aluno.component';
import { PagamentoComponent } from 'src/app/pages/pagamento/pagamento.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'modalidade',     component: ModalidadeComponent },
    { path: 'aluno',          component: AlunoComponent },
    { path: 'pagamento',      component: PagamentoComponent }
];
