import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Building } from '@app/models/building';


@Injectable({
  providedIn: 'root'
})
export class BuildingService {
   // URL to web api
  private url: string;
  public building: Building;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor( private http: HttpClient ) {
    this.url = 'https://localhost:44301/api/building';
   }
// observer design pattern is a behavioral pattern.
// This pattern is used when there is is one to many relationship between objects such is one is
// modified the othe has to be notified
  getBuilding(): Observable<Building[]>{
    return this.http.get<Building[]>(this.url)
    .pipe(
      catchError(this.handleError<Building[]>('GetAll', []))
    );
  }

  getOneBuilding(id: number): Observable<Building> {
    // return of(EMPLOYEES.find(employee => employee.EmployeeId === id));
    const url = `${this.url}/${id}`;
    return this.http.get<Building>(url)
      .pipe(
        catchError(this.handleError<Building>(`Get id=${id}`))
    );
  }

  addBuilding(building: Building): Observable<Building>{
    return this.http.post<Building>(this.url, building, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('AddBuilding'))
    );
  }

  updateBuilding(building: Building): Observable<Building>{
    const url = `${this.url}/${building.BuildingId}`;
    return this.http.put<Building>(url, building, this.httpOptions).pipe(
          catchError(this.handleError<any>('updateBuilding'))
      );
  }

  deleteBuilding(id: number): Observable<Building>{
    const url = `${this.url}/${id}`;
    return this.http.delete<Building>(url);
  }

  // tslint:disable-next-line: typedef
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
