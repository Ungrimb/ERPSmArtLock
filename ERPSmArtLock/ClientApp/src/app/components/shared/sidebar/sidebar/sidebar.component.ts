import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { Users } from '@app/models/users';
import { AuthenticationService } from '@app/_services/authentication.service';
import { UserService } from '@app/_services/user.service';
import { BuildingList } from '@app/models/buildingList';
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
  buildingLists: BuildingList[];

  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService,
    private buildingService: BuildingService
  ) {
    this.user = this.authenticationService.userValue;
   }

  ngOnInit(): void {
    this.getUser();
    this.getBuildings();
  }

  getUser(): void{
    this.loading = true;
    this.userService.getById(this.user.id).pipe(first()).subscribe(user => {
        this.loading = false;
        this.userFromApi = user;
        console.log(this.userFromApi);
    });
  }

  getBuildings(): void{
    // ASyncronous signature subscribe waith for the observable
    // The subscribe() method passes the emitted array to the callback
    this.buildingService.getBuildings().subscribe(
      response => {this.buildingLists = response; console.log(response); },
      error => {console.log('There was a problem to get buildings'); }
    );
  }
}
