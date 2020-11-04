import { Component, OnInit, Input } from '@angular/core';

import { BuildingList } from '@app/models/buildingList';
@Component({
  selector: 'app-carrousel',
  templateUrl: './carrousel.component.html',
  styleUrls: ['./carrousel.component.scss']
})
export class CarrouselComponent implements OnInit {
  @Input()  buildingLists: BuildingList[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
