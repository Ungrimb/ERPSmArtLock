import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';

import { Building } from '@app/models/building';
import { BuildingService } from '../../services/building.service';

@Component({
  selector: 'app-building-add',
  templateUrl: './building-add.component.html',
  styleUrls: ['./building-add.component.scss']
})
export class BuildingAddComponent implements OnInit {

  buildingForm: FormGroup;
  building: Building;

  constructor(
    private buildingService: BuildingService,
    private formBuilder: FormBuilder,
    private location: Location) { }

  ngOnInit(): void {
    this.buildingForm = this.formBuilder.group({
      Name: ['', Validators.required],
      address: ['', Validators.required],
      Description: ['', Validators.required],
      ownerEmail: ['', Validators.required],
      Rooms:  ['', Validators.required]
    });
  }

  goBack(): void {
    this.location.back();
  }

  create(): void {
    const building: Building = Object.assign({}, this.buildingForm.value);
    console.log(building);
    this.buildingService.addBuilding(building)
    .subscribe (() => this.goBack());
  }

}
