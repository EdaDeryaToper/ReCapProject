import { Component, OnInit } from '@angular/core';
import { Car } from 'src/app/models/car';
import { CarService } from 'src/app/sevices/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit{
  cars:Car[]=[];

  constructor(private carService:CarService){}
  ngOnInit():void{
    this.getCars();
  
  }
  getCars(){
    this.carService.getCars().subscribe((response: { data: Car[]; }) => {this.cars = response.data});
    
  }

}


