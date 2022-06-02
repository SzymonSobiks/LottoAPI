import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NewdrawComponent } from './newdraw/newdraw.component';
import { DrawhistoryComponent } from './drawhistory/drawhistory.component';

const routes: Routes = [
  {path:'newdraw',component:NewdrawComponent},
  {path:'drawhistory',component:DrawhistoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
