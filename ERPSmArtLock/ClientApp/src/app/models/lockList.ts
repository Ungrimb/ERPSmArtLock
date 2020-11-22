import { Time } from '@angular/common';
import { Timestamp } from 'rxjs/internal/operators/timestamp';

export interface Device {
    id: number;
    ownerId: number;
    buildingId: number;
    roomName: string;
    checkIn: Time;
    checkOut: Time;
    qrcode: string;
    allowedUsers: number;
    isFavorite: number;
    doubletick: string;
    checkDoubletick: string;
}