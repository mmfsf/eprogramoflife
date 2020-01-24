import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { AuthToken } from './auth/auth-token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
    this.GetToken();
  }

  public GetToken(): void {
    this.auth.GetToken().subscribe(res => {
      console.log(res.body.access_token);
      AuthToken.Set(res.body);
    });
  }
}
