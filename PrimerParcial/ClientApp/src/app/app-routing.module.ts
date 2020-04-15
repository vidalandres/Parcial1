import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SearchComponent } from '../app/cliente/search/search.component';
import { RecordComponent } from '../app/cliente/record/record.component';

import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'record',
    component: RecordComponent
  },
  {
    path: 'search',
    component: SearchComponent
  },
  { 
    path: '', 
    component: RecordComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
