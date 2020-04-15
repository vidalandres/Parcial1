import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';

import { LiqService } from '../services/liq.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  liqs:Liquidacion[];

  constructor( private liqSe:LiqService ) {
    this.liqs = new Array<Liquidacion>();
  }

  ngOnInit() {
    this.liqSe.get().subscribe (
      (data) => {
        if(data==null){
          this.liqs = new Array<Liquidacion>();
          this.liqs.push(new Liquidacion);
        }
        else {
          this.liqs = data;
        }
      }
    );
  }

}
