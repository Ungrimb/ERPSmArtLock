// Use to login and logout of the application and allow access to logged in user
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Users } from '@app/models/users';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private url: string;
    private baseUrl: string;
    private currentUserSubject: BehaviorSubject<Users>;
    public currentUser: Observable<Users>;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };

    constructor(
        private router: Router,
        private http: HttpClient
        ){
            this.currentUserSubject =  new BehaviorSubject<Users>(JSON.parse(localStorage.getItem('currentUser')));
            this.currentUser = this.currentUserSubject.asObservable();
            this.url = 'https://localhost:44301/api/users/authenticate';
            this.baseUrl = 'https://localhost:44301/api/users/register';
        }
    public get currentUserValue(): Users {
        return this.currentUserSubject.value;
    }

    // tslint:disable-next-line: typedef
    login(username: string, password: string){
      return this.http.post<Users>(this.url, { username, password },this.httpOptions)
        .pipe(map(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
             return user;
        }
        ));
    }

    // tslint:disable-next-line: typedef
    register(account: Users) {
        return this.http.post(this.baseUrl, account);
    }
    // tslint:disable-next-line: typedef
    logout(){
        // remove user from Local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
        this.router.navigate(['/login']);
    }
}
