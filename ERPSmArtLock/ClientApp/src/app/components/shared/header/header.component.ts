import { Component } from '@angular/core';
import { Router } from '@angular/router'

import { AuthenticationService } from '../../../_services/authentication.service';
import { Users } from '../../../models/users';
import { Role } from '../../../models/enums/role';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent{
  currentUser: Users;
  title = 'Enterprise Resources Planning';
  constructor(
    private router: Router,
    private authenticationService: AuthenticationService) {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
   }

   // tslint:disable-next-line: typedef
   get isAdmin() {
    return this.currentUser && this.currentUser.role === Role.Admin;
  }

// tslint:disable-next-line: typedef
  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login'])
  }
}
