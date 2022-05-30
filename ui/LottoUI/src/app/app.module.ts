import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewdrawComponent } from './newdraw/newdraw.component';
import { ShowlastDrawComponent } from './newdraw/showlast-draw/showlast-draw.component';
import { AddDrawComponent } from './newdraw/add-draw/add-draw.component';
import { DrawhistoryComponent } from './drawhistory/drawhistory.component';
import { SharedService } from './shared.service';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NewdrawComponent,
    ShowlastDrawComponent,
    AddDrawComponent,
    DrawhistoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
