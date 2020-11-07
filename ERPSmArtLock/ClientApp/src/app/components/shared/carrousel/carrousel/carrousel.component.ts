import { Component, OnInit, Input } from '@angular/core';

import { Building } from '@app/models/building';
@Component({
  selector: 'app-carrousel',
  templateUrl: './carrousel.component.html',
  styleUrls: ['./carrousel.component.scss']
})
export class CarrouselComponent implements OnInit {
  @Input()  building: Building[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
