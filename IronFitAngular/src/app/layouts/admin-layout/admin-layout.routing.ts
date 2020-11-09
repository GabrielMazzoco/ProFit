import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { ModalidadeComponent } from 'src/app/pages/modalidade/modalidade.component';
import { AlunoComponent } from 'src/app/pages/aluno/aluno.component';
import { PagamentoComponent } from 'src/app/pages/pagamento/pagamento.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user-profile',   component: UserProfileComponent },
    { path: 'tables',         component: TablesComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'maps',           component: MapsComponent },
    { path: 'modalidade',     component: ModalidadeComponent },
    { path: 'aluno',          component: AlunoComponent },
    { path: 'pagamento',      component: PagamentoComponent }
];
