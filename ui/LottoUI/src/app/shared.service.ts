import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  
  readonly APIUrl = "http://localhost:5001/api";


  constructor(private http:HttpClient) { }

getDrawList():Observable<any[]>{
  return this.http.get<any>(this.APIUrl+'/draw');
}

addDraw(val:any){
  return this.http.post(this.APIUrl+'/draw',val);
}

}
