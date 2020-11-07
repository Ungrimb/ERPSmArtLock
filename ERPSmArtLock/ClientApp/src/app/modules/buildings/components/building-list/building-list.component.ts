import { Component, OnInit } from '@angular/core';
import { Building } from '@app/models/building';

import { BuildingService } from '../../services/building.service';

@Component({
  selector: 'app-building',
  templateUrl: './building-list.component.html',
  styleUrls: ['./building-list.component.scss']
})
export class BuildingListComponent implements OnInit {

  // interface type Building
  building: Building[];
  isAdmini = false;

 // Dependency injection private property
 constructor(private buildingService: BuildingService) { }

  ngOnInit(): void {
    this.getBuilding();
  }

  getBuilding(): void{
    // ASyncronous signature subscribe waith for the observable
    // The subscribe() method passes the emitted array to the callback
    this.buildingService.getBuilding().subscribe(
      response => {this.building = response; console.log(response); this.isAdmini = true; },
      error => {console.log('There was a problem to get buildings'); }
    );
  }

  delete(id: number): void{
    this.buildingService.deleteBuilding(id).subscribe(data => {
      alert('Building with ID ' + id + ' has been deleted');
      location.reload();
    });
  }

}
