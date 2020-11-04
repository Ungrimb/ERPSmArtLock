import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BuildingRoutingModule } from './building-routing.module';

import { BuildingAddComponent } from './components/building-add/building-add.component';
import {BuildingDetailComponent } from './components/building-detail/building-detail.component';
import { BuildingUpdateComponent } from './components/building-update/building-update.component';
import { BuildingListComponent } from './components/building-list/building-list.component';



@NgModule({
  declarations: [
    BuildingAddComponent,
    BuildingDetailComponent,
    BuildingUpdateComponent,
    BuildingListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BuildingRoutingModule
  ],
  exports: [
    BuildingAddComponent,
    BuildingDetailComponent,
    BuildingUpdateComponent,
    BuildingListComponent
  ]
})
export class BuildingModule { }
