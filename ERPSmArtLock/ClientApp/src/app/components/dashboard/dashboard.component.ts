import { Component, OnInit } from '@angular/core';

import { BuildingList } from '@app/models/buildingList';
import { BuildingService } from '../../modules/buildings/services/Building.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: [ './dashboard.component.scss' ]
})
export class DashboardComponent implements OnInit {
  buildingLists: BuildingList[] = [];

  constructor(private buildingService: BuildingService) {}

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getBuildings();
  }

  getBuildings(): void {
    this.buildingService.getBuildings()
      .subscribe(buildings => this.buildingLists = buildings.slice(0, 4));
  }
}
