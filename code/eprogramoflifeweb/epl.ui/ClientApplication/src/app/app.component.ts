import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { AuthToken } from './auth/auth-token';
import { CommonService } from './services/common.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  token: string;

  constructor(private auth: AuthService, private common: CommonService) {
    this.token = 'No token';
  }

  public GetToken(): void {
    this.auth.GetToken().subscribe(res => {
      AuthToken.Set(res.body);
      this.token = res.body.access_token;
    });
  }

  public Test(): void {
    this.common.ProgramAll().subscribe(res => {
      console.log(res);
    });
  }
}
