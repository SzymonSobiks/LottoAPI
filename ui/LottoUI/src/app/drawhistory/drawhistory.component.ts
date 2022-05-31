import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import {Sort} from '@angular/material/sort';

export interface Draw {
  DrawId: number;
  DrawNumber1: number;
  DrawNumber2: number;
  DrawNumber3: number;
  DrawNumber4: number;
  DrawNumber5: number;
  DrawDateTime: Date;
}

@Component({
  selector: 'app-drawhistory',
  templateUrl: './drawhistory.component.html',
  styleUrls: ['./drawhistory.component.css']
})
export class DrawhistoryComponent implements OnInit {

  constructor(private service:SharedService) { }

  DrawList:any=[];

  ngOnInit(): void {
    this.refreshDrawList();
  }

  refreshDrawList(){
    this.service.getDrawList().subscribe(data=>{
      this.DrawList=data;
    });
  }

}
