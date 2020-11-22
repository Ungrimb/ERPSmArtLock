import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { Location } from '@angular/common';

import { Building } from '@app/models/building';
import { BuildingService } from '../../services/building.service';


@Component({
  selector: 'app-building-update',
  templateUrl: './building-update.component.html',
  styleUrls: ['./building-update.component.scss']
})
export class BuildingUpdateComponent implements OnInit {

  buildingForm: FormGroup;
  buildingId: any;
  building: Building;

  constructor(
    private route: ActivatedRoute,
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

    this.getOneBuilding();

    }

    upData(building: Building): any{
      this.buildingForm.patchValue({
        Name: building.BuildingName,
        Address: building.BuildingAddress,
        Description: building.BuildingDescription,
        ownerEmail: building.BuildingOwnerEmail,
        Rooms: building.BuildingRooms
    });
  }

    getOneBuilding(): void {
      const id = +this.route.snapshot.paramMap.get('id');
      this.buildingId = id;
      this.buildingService.getOneBuilding(this.buildingId.toString())
        .subscribe(building => {
          this.building = building;
          this.upData(building);
        });
    }
    goBack(): void {
      this.location.back();
    }

    update(): void{
      const building: Building = Object.assign({}, this.buildingForm.value);
      const id = +this.route.snapshot.paramMap.get('id');
      this.buildingId = id;
      // tslint:disable-next-line: radix
      this.buildingId = parseInt( this.buildingId );
      console.log( typeof this.buildingId);

      building.BuildingId = this.buildingId;
      this.buildingService.updateBuilding(building)
      .subscribe (() => this.goBack());
    }
}
