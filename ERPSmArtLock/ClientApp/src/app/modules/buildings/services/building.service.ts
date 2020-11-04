import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { BuildingList } from '@app/models/buildingList';


@Injectable({
  providedIn: 'root'
})
export class BuildingService {
   // URL to web api
  private url: string;
  public building: BuildingList;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor( private http: HttpClient ) {
    this.url = 'https://localhost:44301/api/buildings';
   }
// observer design pattern is a behavioral pattern.
// This pattern is used when there is is one to many relationship between objects such is one is
// modified the othe has to be notified
  getBuildings(): Observable<BuildingList[]>{
    return this.http.get<BuildingList[]>(this.url)
    .pipe(
      catchError(this.handleError<BuildingList[]>('GetAll', []))
    );
  }

  getBuilding(id: number): Observable<BuildingList> {
    // return of(EMPLOYEES.find(employee => employee.EmployeeId === id));
    const url = `${this.url}/${id}`;
    return this.http.get<BuildingList>(url)
      .pipe(
        catchError(this.handleError<BuildingList>(`Get id=${id}`))
    );
  }

  addBuilding(buildingList: BuildingList): Observable<BuildingList>{
    return this.http.post<BuildingList>(this.url, buildingList, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('AddBuildingList'))
    );
  }

  updateBuilding(buildingList: BuildingList): Observable<BuildingList>{
    const url = `${this.url}/${buildingList.BuildingId}`;
    return this.http.put<BuildingList>(url, buildingList, this.httpOptions).pipe(
          catchError(this.handleError<any>('updateBuilding'))
      );
  }

  deleteBuilding(id: number): Observable<BuildingList>{
    const url = `${this.url}/${id}`;
    return this.http.delete<BuildingList>(url);
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
