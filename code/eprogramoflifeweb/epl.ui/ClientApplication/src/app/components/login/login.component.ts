import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';
import { Account } from '../../models/account.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent {
  
  error: string;

  constructor(private auth: AuthService, private router: Router) { }

  public login(username: string, password: string): void {
    this.auth.Login(new Account(0, username, password)).subscribe(res => {
      console.log(res.body);
    });
  }
}
