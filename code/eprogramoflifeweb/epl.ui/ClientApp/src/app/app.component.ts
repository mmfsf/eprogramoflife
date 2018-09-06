import { Component, OnInit } from '@angular/core';

// Services
import { CommonService } from './services/common.service'
import { AuthService } from './services/auth.service'

// Models
import { Token } from './models/token.model'

// Auth
import { AuthToken } from './auth/auth-token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {  
  title = 'ClientApp';

  constructor(private common: CommonService, private auth: AuthService) { }

  ngOnInit(): void {
    this.auth.GetToken().subscribe(res => { AuthToken.Set(res.body); })
  }

  private GetIdentity() {
    this.common.GetIdentity().subscribe(x => {
      alert(x.body);
    });
  }

}
