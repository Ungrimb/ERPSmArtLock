import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';

import { BuildingList } from '@app/models/buildingList';
import { BuildingService } from '../../services/building.service';

@Component({
  selector: 'app-building-add',
  templateUrl: './building-add.component.html',
  styleUrls: ['./building-add.component.scss']
})
export class BuildingAddComponent implements OnInit {

  buildingForm: FormGroup;
  building: BuildingList;

  constructor(
    private buildingService: BuildingService,
    private formBuilder: FormBuilder,
    private location: Location) { }

  ngOnInit(): void {
    this.buildingForm = this.formBuilder.group({
      Name: ['', Validators.required],
      LastName: ['', Validators.required],
      PositionJob: ['', Validators.required],
      Salary: ['', Validators.required],
      UserName:  ['', Validators.required],
      Password:  ['', Validators.required]
    });
  }

  goBack(): void {
    this.location.back();
  }

  create(): void {
    const buildingList: BuildingList = Object.assign({}, this.buildingForm.value);
    console.log(buildingList);
    this.buildingService.addBuilding(buildingList)
    .subscribe (() => this.goBack());
  }

}
