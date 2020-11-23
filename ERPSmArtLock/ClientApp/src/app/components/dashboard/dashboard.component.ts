import { Component, OnInit } from '@angular/core';

import { Building } from '@app/models/building';
import { BuildingService } from '../../modules/buildings/services/building.service';
import { Device } from '@app/models/lockList';
import { ServicesService } from '../../modules/devices/services/services.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.scss' ]
})
export class DashboardComponent implements OnInit {
  building: Building[] = [];
  devices: Device[] = [];

  constructor(
    private buildingService: BuildingService,
    private devicesService: ServicesService) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getBuilding();
    this.getDevices();
  }

  getBuilding(): void {
    this.buildingService.getBuilding()
      .subscribe(building => this.building = building.slice(0, 4));
  }
  getDevices(): void {
    this.devicesService.getDevice()
      .subscribe(devices => this.devices = devices.slice(0, 4));
  }
}
