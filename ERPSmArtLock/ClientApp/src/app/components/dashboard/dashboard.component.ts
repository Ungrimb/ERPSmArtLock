import { Component, OnInit } from '@angular/core';

import { Building } from '@app/models/building';
import { BuildingService } from '../../modules/buildings/services/building.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.scss' ]
})
export class DashboardComponent implements OnInit {
  building: Building[] = [];

  constructor(private buildingService: BuildingService) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getBuilding();
  }

  getBuilding(): void {
    this.buildingService.getBuilding()
      .subscribe(building => this.building = building.slice(0, 4));
  }
}
