import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { BrowserModule } from '@angular/platform-browser';


import { Users } from '@app/models/users';
import { AuthenticationService } from '@app/_services/authentication.service';
import { UserService } from '@app/_services/user.service';
import { Building } from '@app/models/building';
import { BuildingService } from '../../../../modules/buildings/services/building.service';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent implements OnInit {
  loading = false;
  user: Users;
  userFromApi: Users;
  building: Building[];

  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService,
    private buildingService: BuildingService
  ) {
    this.user = this.authenticationService.currentUserValue;
   }

  ngOnInit(): void {
    this.getUser();
    this.getBuilding();
  }

  getUser(): void {
    //this.loading = true;
    //this.userService.getById(this.user.id).pipe(first()).subscribe(user => {
    this.loading = false;
    this.userFromApi = this.user;
    console.log(this.userFromApi);
    //});
  }

  getBuilding(): void{
    // ASyncronous signature subscribe waith for the observable
    // The subscribe() method passes the emitted array to the callback
    this.buildingService.getBuilding().subscribe(
      response => {this.building = response; console.log(response); },
      error => {console.log('There was a problem to get buildings'); }
    );
  }
}
