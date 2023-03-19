import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarResponseModel } from '../models/carResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  apiUrl="https://localhost:44340/api/cars/getall"

  constructor(private httpclient:HttpClient) { }
  getCars():Observable<CarResponseModel>{
    return this.httpclient.get<CarResponseModel>(this.apiUrl)
  }
}
