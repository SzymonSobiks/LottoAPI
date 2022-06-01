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
    DrawNumber1:0,
    DrawNumber2:0,
    DrawNumber3:0,
    DrawNumber4:0,
    DrawNumber5:0}
  ];



  ngOnInit(): void {
  }

  addDraw() {

     // for (let i = 0; i < 5; i++) {
    //   this.draw.numbers[i] = Math.floor(Math.random() * 51);
    // }
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

  

    // this.ngOnInit();

    var val = {
              DrawNumber1:numbers[0],
              DrawNumber2:numbers[1],
              DrawNumber3:numbers[2],
              DrawNumber4:numbers[3],
              DrawNumber5:numbers[4],
              DrawDateTime:formatDate(timestamp)
            };
              // alert(formatDate(timestamp))
              this.service.addDraw(val).subscribe(res=>{
                //alert(res.toString());
              });
    
    this.draw=[
          {drawId: 0,
            DrawNumber1:numbers[0],
            DrawNumber2:numbers[1],
            DrawNumber3:numbers[2],
            DrawNumber4:numbers[3],
            DrawNumber5:numbers[4],
            timestamp: timestamp.toLocaleString().replace(',',' ')
          } //time should be in local not UTC
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
