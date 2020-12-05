import * as moment from "moment";
// Models
import { Token } from "../models/token.model";

export class AuthToken {

  public static Set(token: Token) {
    localStorage.setItem("epl_token", JSON.stringify(token));
  }

  public static GetToken(): Token {
    var token = JSON.parse(localStorage.getItem("epl_token"));
    return token;
  }

  public static ClearToken() {
    localStorage.clear();
  }

  public static isLoggedIn(): boolean {
    var token = JSON.parse(localStorage.getItem("epl_token"));
   
    return token != null &&
           !moment().isBefore(token.expires_in);
  }
}
