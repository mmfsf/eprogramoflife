import { Component } from '@angular/core';
import * as moment from "moment";
// Models
import { ProgramOfLife } from '../../models/ProgramOfLife';

@Component({
  selector: 'app-programoflife',
  templateUrl: './programoflife.component.html',
  styleUrls: ['./programoflife.component.scss']
})
export class ProgramOfLifeComponent {
  program: ProgramOfLife;

  constructor() {
    this.program = new ProgramOfLife(0);
    this.program.Name = 'My program of life';
    this.program.LastUpdate = moment().toDate();
    this.program.Motto = 'Donec pretium magna vitae felis iaculis, vel interdum magna dapibus. Cras eu mattis risus. Sed molestie nisl sed ante interdum faucibus. Nulla magna erat, sagittis eu dignissim vel, tristique nec elit. Maecenas placerat turpis a varius condimentum. Cras ultrices convallis ante sit amet molestie';
    this.program.Ideal = 'Curabitur iaculis massa eu ipsum iaculis volutpat';
    this.program.Virtue = 'Caritas';

    this.program.Means.push('Etiam convallis maximus laoreet');
    this.program.Means.push('Aliquam erat volutpat');
    this.program.Means.push('Proin varius quis augue a venenatis');

    this.program.Deffects.Dominant = 'Consectetur';
    this.program.Deffects.God.push('Aenean dignissim metus non lacus porttitor sodales');
    this.program.Deffects.God.push('Donec purus nunc, commodo sit amet dictum id, vestibulum in quam');
    this.program.Deffects.God.push('Fusce aliquet massa non tellus hendrerit ultrices');

    this.program.Deffects.Myself.push('Mauris sit amet augue tellus');
    this.program.Deffects.Myself.push('Morbi id fermentum massa, non elementum urna');

    this.program.Deffects.Others.push('Cras non placerat orci');
    this.program.Deffects.Others.push('Praesent bibendum congue posuere');
    this.program.Deffects.Others.push('Vivamus ultricies tortor quam, eu ornare nisl convallis eget');
    this.program.Deffects.Others.push('Maecenas aliquet, leo sit amet tristique malesuada, neque sapien ultricies metus, a accumsan ligula urna ut lectus');
    this.program.Deffects.Others.push('Curabitur eu tincidunt mi');

  }


}
