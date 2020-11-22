import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeviceRoutingModule } from './devices-routing.module';

import { DeviceAddComponent } from './components/device-add/device-add.component';
import { DeviceDetailComponent } from './components/device-detail/device-detail.component';
import { DeviceListComponent } from './components/device-list/device-list.component';
import { DeviceUpdateComponent } from './components/device-update/device-update.component';



@NgModule({
  declarations: [DeviceAddComponent, DeviceDetailComponent, DeviceListComponent, DeviceUpdateComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DeviceRoutingModule
  ],
  exports: [
    DeviceAddComponent,
    DeviceDetailComponent,
    DeviceUpdateComponent,
    DeviceListComponent
  ]
})
export class DevicesModule { }
