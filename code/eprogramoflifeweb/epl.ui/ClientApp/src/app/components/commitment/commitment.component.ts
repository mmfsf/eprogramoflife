import { Component, OnInit, Input } from '@angular/core';
import { MatCheckboxChange } from '@angular/material/checkbox'

// Services
import { CommonService } from '../../services/common.service';

// Models
import { Commitment } from '../../models/commitment.model';

@Component({
  selector: 'app-commitment',
  templateUrl: './commitment.component.html',
  styleUrls: ['./commitment.component.scss']
})
export class CommitmentComponent {

  @Input()
    commitment!: Commitment;

  constructor(private common: CommonService) { }

  public check(event: MatCheckboxChange) {
    const id = parseInt(event.source.value);
    this.common.Point(id, event.checked).subscribe(r => {
      console.log(r);
    });
  }
}
