import { Component, Input } from '@angular/core';
import { Defects } from 'src/app/models/defects.model';

@Component({
  selector: 'app-defects',
  templateUrl: './defects.component.html',
  styleUrls: ['./defects.component.scss']
})
export class DefectsComponent {
  @Input() defects!: Defects;

  constructor(){}
}
