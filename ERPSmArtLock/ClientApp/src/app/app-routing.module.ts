import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AdminComponent } from './admin/admin/admin.component';
import { LoginComponent } from './login/login/login.component';
import { AuthGuard } from './_helpers/auth.guard';
import { RegisterComponent } from './register/register/register.component';
import { Role } from './models/enums/role';

const routes: Routes = [
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent,  canActivate: [AuthGuard] },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'building',
    loadChildren: () => import('./modules/buildings/building.module').then(m => m.BuildingModule)
  },
  {
    path: 'devices',
    loadChildren: () => import('./modules/devices/devices.module').then(m => m.DevicesModule)
  },
  // {
  //   path: 'sales',
  //   loadChildren: () => import('./modules/sales/components/orders.module').then(m => m.OrdersModule)
  // },
  // {
  //   path: 'crm',
  //   loadChildren: () => import('./modules/crm/crm.module').then(m => m.CrmModule)
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

