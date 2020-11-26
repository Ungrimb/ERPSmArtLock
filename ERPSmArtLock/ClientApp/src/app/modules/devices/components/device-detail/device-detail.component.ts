  import { Component, OnInit } from '@angular/core';
  import { ActivatedRoute } from '@angular/router';
  import { Location } from '@angular/common';
  
  import { ServicesService } from '../../services/services.service';
  import { Device } from '@app/models/lockList';
  
  @Component({
    selector: 'app-device-detail',
  templateUrl: './device-detail.component.html',
  styleUrls: ['./device-detail.component.scss']
  })
  export class DeviceDetailComponent implements OnInit {
    devices: Device;
  
    constructor(
       private route: ActivatedRoute,
       private servicesService: ServicesService,
       private location: Location
      ) { }
  
    ngOnInit(): void {
      this.get();
    }
  
    get(): void {
      const id = +this.route.snapshot.paramMap.get('id');
      this.servicesService.getOneDevice(id)
        .subscribe(devices => this.devices = devices);
    }
  
    goBack(): void {
      // navigate backward one step in the browsers history using Location service i injected previously
      this.location.back();
    }
  
  }
