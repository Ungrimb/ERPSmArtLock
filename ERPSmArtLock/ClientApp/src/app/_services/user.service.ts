import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Users } from '@app/models/users';

@Injectable({ providedIn: 'root' })

export class UserService {
    private apiUrl: string;
    constructor(private http: HttpClient) {
        this.apiUrl = 'https://localhost:44301/api';
     }

    // tslint:disable-next-line: typedef
  getAll() {
    return this.http.get<Users[]>('${this.apiUrl}/users');
    }

    // tslint:disable-next-line: typedef
  getById(id: number) {
    return this.http.get<Users>('${this.apiUrl}/users/${id}');
    }
}
