import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { BuildingService } from '../../services/building.service';
import { Building } from '@app/models/building';

@Component({
  selector: 'app-building-detail',
  templateUrl: './building-detail.component.html',
  styleUrls: ['./building-detail.component.scss']
})
export class BuildingDetailComponent implements OnInit {
  building: Building;

  constructor(
     private route: ActivatedRoute,
     private buildingService: BuildingService,
     private location: Location
    ) { }

  ngOnInit(): void {
    this.get();
  }

  get(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.buildingService.getOneBuilding(id)
      .subscribe(building => this.building = building);
  }

  goBack(): void {
    // navigate backward one step in the browsers history using Location service i injected previously
    this.location.back();
  }

}


