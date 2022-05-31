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
    DrawNumber5:0,
    timestamp: '30/05/2022 00:00:00'}
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

    const dateNow = new Date();

    var timestamp = dateNow;

  

    // this.ngOnInit();

    var val = {
              DrawNumber1:numbers[0],
              DrawNumber2:numbers[1],
              DrawNumber3:numbers[2],
              DrawNumber4:numbers[3],
              DrawNumber5:numbers[4],
              DrawDateTime:timestamp};

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
            timestamp: timestamp.toLocaleString().replace(',', '')}
    ];

    if(this.isFirstDraw){
        this.text = 'Draw again!';
        this.isFirstDraw = false;
    }
  }

}
