import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { Location } from '@angular/common';

import { BuildingList } from '@app/models/buildingList';
import { BuildingService } from '../../services/building.service';


@Component({
  selector: 'app-building-update',
  templateUrl: './building-update.component.html',
  styleUrls: ['./building-update.component.scss']
})
export class BuildingUpdateComponent implements OnInit {

  buildingForm: FormGroup;
  buildingListId: any;
  buildingList: BuildingList;

  constructor(
    private route: ActivatedRoute,
    private buildingService: BuildingService,
    private formBuilder: FormBuilder,
    private location: Location) { }

  ngOnInit(): void {
    this.buildingForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Address: ['', Validators.required],
      Description: ['', Validators.required],
      Image: ['', Validators.required],
      Lat:  ['', Validators.required],
      Lng:  ['', Validators.required]
    });

    this.getBuilding();

    }

    upData(buildingList: BuildingList): any{
      this.buildingForm.patchValue({
        Name: buildingList.BuildingName,
        Address: buildingList.BuildingAddress,
        Description: buildingList.BuildingDescription,
        Image: buildingList.BuildingImage,
        Lat: buildingList.BuildingLat,
        Lng: buildingList.BuildingLng
    });
  }

    getBuilding(): void {
      const id = +this.route.snapshot.paramMap.get('id');
      this.buildingListId = id;
      this.buildingService.getBuilding(this.buildingListId.toString())
        .subscribe(buildingList => {
          this.buildingList = buildingList;
          this.upData(buildingList);
        });
    }
    goBack(): void {
      this.location.back();
    }

    update(): void{
      const buildingList: BuildingList = Object.assign({}, this.buildingForm.value);
      const id = +this.route.snapshot.paramMap.get('id');
      this.buildingListId = id;
      // tslint:disable-next-line: radix
      this.buildingListId = parseInt( this.buildingListId );
      console.log( typeof this.buildingListId);

      buildingList.BuildingId = this.buildingListId;
      this.buildingService.updateBuilding(buildingList)
      .subscribe (() => this.goBack());
    }
}
