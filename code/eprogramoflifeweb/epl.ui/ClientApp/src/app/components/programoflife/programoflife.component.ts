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

  constructor() {
  }

  ngOnInit(): void {
  }
}
