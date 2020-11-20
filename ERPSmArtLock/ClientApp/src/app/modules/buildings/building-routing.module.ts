import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BuildingDetailComponent } from './components/building-detail/building-detail.component';
import { BuildingListComponent } from './components/building-list/building-list.component';
import { BuildingAddComponent } from './components/building-add/building-add.component';
import { BuildingUpdateComponent } from './components/building-update/building-update.component';

const routes: Routes = [
    { path: 'detail/:id', component: BuildingDetailComponent },
    { path: 'buildings', component: BuildingListComponent },
    { path: 'addbuilding', component: BuildingAddComponent },
    { path: 'update/:id', component: BuildingUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BuildingRoutingModule{}
