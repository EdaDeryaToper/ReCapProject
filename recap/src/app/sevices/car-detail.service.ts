import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarDetailResponseModel } from '../models/carDetailResponseModel';

@Injectable({
  providedIn: 'root'
})
export class CarDetailService {
  apiUrl="https://localhost:44340/api/cars/getcardetails"

  constructor(private httpclient:HttpClient) { }
  getCarsDetail():Observable<CarDetailResponseModel>{
    return this.httpclient.get<CarDetailResponseModel>(this.apiUrl);
  }
}
