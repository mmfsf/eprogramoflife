import { Component, OnInit } from '@angular/core';
import { AuthToken } from '../../auth/auth.token';

// Models
import { Commitment } from '../../models/commitment.model';
// Services
import { CommonService } from '../../services/common.service';

@Component({
  selector: 'app-commitments',
  templateUrl: './commitments.component.html',
  styleUrls: ['./commitments.component.scss'],
})
export class CommitmentsComponent implements OnInit {
  public commitments: Array<Commitment>;
  public dailyCommitment!: Array<Commitment>;
  public weeklyCommitment!: Array<Commitment>;
  public monthlyCommitment!: Array<Commitment>;
  public yearlyCommitment!: Array<Commitment>;
  public rowspan: number;

  constructor(private common: CommonService) {
    this.commitments = new Array<Commitment>();
    this.rowspan = 10;
  }

  ngOnInit(): void {}

  private GetCommitments() {
    this.common.GetCommitments().subscribe((res) => {
      if (res.body !== null) {
        res.body.map((c) => {
          const commitment: Commitment = {
            id: c.id,
            name: c.name,
            description: c.description,
            frequency: c.frequency,
            pointed: c.pointed,
          };
          this.commitments.push(commitment);
        });
        this.rowspan = this.commitments.length + 5;

        this.dailyCommitment = this.commitments.filter(
          (x) => x.frequency === 0
        );
        this.weeklyCommitment = this.commitments.filter(
          (x) => x.frequency === 1
        );
        this.monthlyCommitment = this.commitments.filter(
          (x) => x.frequency === 2
        );
        this.yearlyCommitment = this.commitments.filter(
          (x) => x.frequency === 4
        );
      }
    });
  }
}
