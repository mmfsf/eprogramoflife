import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { AuthToken } from './auth/auth.token';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private auth: AuthService, private translate: TranslateService) {
    this.translate.setDefaultLang('en');
    this.translate.use('en');
  }

  ngOnInit(): void {
    if (!AuthToken.isLoggedIn()) {
      this.GetToken();
    }
  }

  public GetToken(): void {
    this.auth.GetToken().subscribe(res => {
      console.log(res.body.access_token);
      AuthToken.Set(res.body);
    });
  }
}
