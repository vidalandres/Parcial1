import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';

import { LiqService } from '../services/liq.service';

@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.css']
})
export class RecordComponent implements OnInit {

  liq:Liquidacion;

  constructor(private liqSe:LiqService) { 
    this.liq = new Liquidacion();
  }

  ngOnInit() {
  }

  add():void{
    console.log(this.liq);
    this.liqSe.post(this.liq).subscribe(
      (data) => {
        if(data!=null) {
          alert('Guardado');
          this.liq = data;
        }
      }
    );
  }

  clear():void{
    this.liq = new Liquidacion();
  }

}
