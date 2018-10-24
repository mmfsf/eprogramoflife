import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

// Services
import { CommonService } from './services/common.service';
import { AuthService } from './services/auth.service';

// Models
import { Token } from './models/token.model';
import { Commitment } from './models/commitment.model';

// Auth
import { AuthToken } from './auth/auth-token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public commitments: Array<Commitment>;
  public rowspan: number;
  
  constructor(private common: CommonService,
    private auth: AuthService,
    private translate: TranslateService) {

    translate.setDefaultLang('en');
    translate.use('en');

    this.commitments = new Array<Commitment>();
    this.rowspan = 10;
  }

  ngOnInit(): void {
    this.auth.GetToken().subscribe(res => {
      AuthToken.Set(res.body);
      this.GetCommitments();
    })
  }

  private GetCommitments() {
    this.common.GetCommitments().subscribe(res => {
      res.body.map(c => {
        this.commitments.push(c);
      });
      this.rowspan = this.commitments.length;
    });
  }

}
