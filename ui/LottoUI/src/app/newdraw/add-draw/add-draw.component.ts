import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-draw',
  templateUrl: './add-draw.component.html',
  styleUrls: ['./add-draw.component.css']
})
export class AddDrawComponent implements OnInit {

  isFirstDraw: any  = true;
  text = 'Draw!';

  constructor(private service:SharedService) { }

 

  draw:any=[
    {name: 'defaultDraw', drawId: 0, numbers: 0, timestamp: '30/05/2022 00:00:00'}
  ];



  ngOnInit(): void {
  }

  addDraw() {

     // for (let i = 0; i < 5; i++) {
    //   this.draw.numbers[i] = Math.floor(Math.random() * 51);
    // }

    var number = Math.floor(Math.random() * 51);

    const dateNow = new Date();

    var timestamp = dateNow;

  

    // this.ngOnInit();

    var val = {
              DrawNumber:number,DrawDateTime:timestamp};

              this.service.addDraw(val).subscribe(res=>{
                alert(res.toString());
              });
    
    this.draw=[
          {drawId: 0, numbers: number, timestamp: timestamp.toLocaleString().replace(',', '')}
    ];

    if(this.isFirstDraw){
        this.text = 'Draw again!';
        this.isFirstDraw = false;
    }
  }

}
