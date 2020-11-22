import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Device } from '@app/models/lockList';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
 // URL to web api
 private url: string;
 public device: Device;

 httpOptions = {
   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
 };
  constructor(private http: HttpClient) {
    this.url = 'https://localhost:44301/api/devices';
   }
   // observer design pattern is a behavioral pattern.
// This pattern is used when there is is one to many relationship between objects such is one is
// modified the othe has to be notified
  getDevice(): Observable<Device[]>{
    return this.http.get<Device[]>(this.url)
    .pipe(
      catchError(this.handleError<Device[]>('GetAll', []))
    );
  }

  getOneDevice(id: number): Observable<Device> {
    // return of(EMPLOYEES.find(employee => employee.EmployeeId === id));
    const url = `${this.url}/${id}`;
    return this.http.get<Device>(url)
      .pipe(
        catchError(this.handleError<Device>(`Get id=${id}`))
    );
  }

  addDevice(device: Device): Observable<Device>{
    return this.http.post<Device>(this.url, device, this.httpOptions)
      .pipe(
        catchError(this.handleError<any>('AddDevice'))
    );
  }

  updateDevice(device: Device): Observable<Device>{
    const url = `${this.url}/${device.id}`;
    return this.http.put<Device>(url, device, this.httpOptions).pipe(
          catchError(this.handleError<any>('updateDevice'))
      );
  }

  deleteDevice(id: number): Observable<Device>{
    const url = `${this.url}/${id}`;
    return this.http.delete<Device>(url);
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
