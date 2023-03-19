import { Component, OnInit } from '@angular/core';
import { CarDetail } from 'src/app/models/carDetail';
import { CarDetailService } from 'src/app/sevices/car-detail.service';

@Component({
  selector: 'app-cardetail',
  templateUrl: './cardetail.component.html',
  styleUrls: ['./cardetail.component.css']
})
export class CardetailComponent implements OnInit{
  carDetails:CarDetail[]=[]

  constructor(private carDetailService: CarDetailService){}

  ngOnInit():void{
    this.getCarDetail();

  }

  getCarDetail(){
    this.carDetailService.getCarsDetail().subscribe(response=>{this.carDetails=response.data})
    
  }

}
