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
    {drawId: 0, 
    DrawNumber1:"-",
    DrawNumber2:"-",
    DrawNumber3:"-",
    DrawNumber4:"-",
    DrawNumber5:"-"}
  ];



  ngOnInit(): void {
  }

  addDraw() {

    const numbers = [0,0,0,0,0];

    for(let i = 0; i < 5; i++)
    {
      do{
        var rand = Math.floor(Math.random() * 51);
      }
      while(numbers.includes(rand))
      
      numbers[i] = rand;

    }

    var timestamp = new Date;

    var val = {
              DrawNumber1:numbers[0],
              DrawNumber2:numbers[1],
              DrawNumber3:numbers[2],
              DrawNumber4:numbers[3],
              DrawNumber5:numbers[4],
              DrawDateTime:formatDate(timestamp)
            };
              this.service.addDraw(val).subscribe(res=>{
              });
    
    this.draw=[
          {drawId: 0,
            DrawNumber1:numbers[0],
            DrawNumber2:numbers[1],
            DrawNumber3:numbers[2],
            DrawNumber4:numbers[3],
            DrawNumber5:numbers[4],
            timestamp: timestamp.toLocaleString().replace(',',' ')
          }
    ];

    if(this.isFirstDraw){
        this.text = 'Draw again!';
        this.isFirstDraw = false;
    }
  }

}

function formatDate(date: Date) {
  return (
    [
      date.getFullYear(),
      padTo2Digits(date.getMonth() + 1),
      padTo2Digits(date.getDate()),
    ].join('-') +
    ' ' +
    [
      padTo2Digits(date.getHours()),
      padTo2Digits(date.getMinutes()),
      padTo2Digits(date.getSeconds()),
    ].join(':')
  );
}

function padTo2Digits(num: number) {
  return num.toString().padStart(2, '0');
}
