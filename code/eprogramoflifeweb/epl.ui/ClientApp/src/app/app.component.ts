import { Component } from '@angular/core';

import { CommonService } from './services/common.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  token = '';

  constructor(private common: CommonService) { }

  private GetToken() {
    this.common.GetToken().subscribe(x => {
      this.token = x.body.toString();
    });
  }

  private GetIdentity() {
    this.common.GetIdentity(this.token).subscribe(x => {
      alert(x.body);
    });
  }

  private GetValues() {
    this.common.GetValues().subscribe(x => {
      alert(x.body);
    });
  }

}
