import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { Users } from '@app/models/users';
import { UserService } from '@app/_services/user.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  loading = false;
  users: Users[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loading = true;
    this.userService.getAll().pipe(first()).subscribe(users => {
      this.loading = false;
      this.users = users;
  });
  }

}
