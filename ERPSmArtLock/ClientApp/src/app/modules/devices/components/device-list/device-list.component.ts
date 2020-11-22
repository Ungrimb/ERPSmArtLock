import { Component, OnInit } from '@angular/core';
import { Device } from '@app/models/lockList';
import { Location } from '@angular/common';

import { ServicesService } from '../../services/services.service';

@Component({
  selector: 'app-device-list',
  templateUrl: './device-list.component.html',
  styleUrls: ['./device-list.component.scss']
})
export class DeviceListComponent implements OnInit {

  // interface type Building
  devices: Device[];
  isAdmini = false;

 // Dependency injection private property

  constructor(
    private servicesService: ServicesService,
    private location: Location) { }

  ngOnInit(): void {
    this.getDevice();
  }

  goBack(): void {
    this.location.back();
  }

  getDevice(): void{
    // ASyncronous signature subscribe waith for the observable
    // The subscribe() method passes the emitted array to the callback
    this.servicesService.getDevice().subscribe(
      response => {this.devices = response; console.log(response); this.isAdmini = true; },
      error => {console.log('There was a problem to get devices'); }
    );
  }

  delete(id: number): void{
    this.servicesService.deleteDevice(id).subscribe(data => {
      alert('Device with ID ' + id + ' has been deleted');
      location.reload();
    });
  }

}
