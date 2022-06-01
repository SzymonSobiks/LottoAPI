import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import {MatSortModule} from '@angular/material/sort';
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



  DrawList:Draw[]=[];

  sortedData: Draw[];

  constructor(private service:SharedService) {
    this.sortedData = this.DrawList.slice();
   }

   sortData(sort: Sort) {
    const data = this.DrawList.slice();
    if (!sort.active || sort.direction === '') {
      this.sortedData = data;
      return;
    }

  this.sortedData = data.sort((a, b) => {
    const isAsc = sort.direction === 'asc';
    switch (sort.active) {
      case 'id':
        return compare(a.DrawId, b.DrawId, isAsc);
      case 'number1':
        return compare(a.DrawNumber1, b.DrawNumber1, isAsc);
      case 'number2':
        return compare(a.DrawNumber2, b.DrawNumber2, isAsc);
      case 'number3':
        return compare(a.DrawNumber3, b.DrawNumber3, isAsc);
      case 'number4':
        return compare(a.DrawNumber4, b.DrawNumber4, isAsc);
      case 'number5':
        return compare(a.DrawNumber5, b.DrawNumber5, isAsc);
      case 'timestamp':
        return compare(a.DrawDateTime, b.DrawDateTime, isAsc);
      default:
        return 0;
    }
  });
}

  ngOnInit(): void {
    this.refreshDrawList();
  }

  refreshDrawList(){
    this.service.getDrawList().subscribe(data=>{
      this.DrawList=data;
      this.sortedData=this.DrawList;
    });
  }

}

function compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
