import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import * as moment from "moment";
// Models
import { ProgramOfLife } from '../../models/ProgramOfLife';

@Component({
  selector: 'app-programoflife',
  templateUrl: './programoflife.component.html',
  styleUrls: ['./programoflife.component.scss']
})
export class ProgramOfLifeComponent implements OnInit {

  programOfLife: ProgramOfLife;

  constructor() {
    this.programOfLife = {
      id: 0,
      Name: 'Marcos Farias',
      LastUpdate: new Date(),
      Motto: 'Lorem Ipsum is simply dummy text of the printing and typesetting industry',
      Ideal: 'Phasellus pellentesque eros varius bibendum tempor',
      Virtue: 'Fusce vel interdum lorem',
      Means: [],
      Defects: {
        id: 0,
        Dominant: 'Cras vitae magna nunc',
        God: ['Neque porro quisquam est qui dolorem ipsum quia dolor sit amet', 'Neque porro quisquam est qui dolorem ipsum quia dolor sit amet'],
        Myself: ['Phasellus sit amet suscipit justo', 'Phasellus sit amet suscipit justo'],
        Others: ['Duis magna dui', 'Duis magna dui', 'Duis magna dui']
      }
    };
  }

  ngOnInit(): void {}
}
