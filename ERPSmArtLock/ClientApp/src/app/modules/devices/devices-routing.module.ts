import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DeviceDetailComponent } from './components/device-detail/device-detail.component';
import { DeviceListComponent } from './components/device-list/device-list.component';
import { DeviceAddComponent } from './components/device-add/device-add.component';
import { DeviceUpdateComponent } from './components/device-update/device-update.component';

const routes: Routes = [
    { path: 'deviceDetail/:id', component: DeviceDetailComponent },
    { path: 'devices', component: DeviceListComponent },
    { path: 'adddevice', component: DeviceAddComponent },
    { path: 'updateDevice/:id', component: DeviceUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DeviceRoutingModule{}