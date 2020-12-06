import * as moment from "moment";
// Models
import { Token } from "../models/token.model";

export class AuthToken {

  public static Set(token: Token) {
    localStorage.setItem("epl_token", JSON.stringify(token));
  }

  public static GetToken(): Token {
    const token = JSON.parse(String(localStorage.getItem("epl_token")));
    return token;
  }

  public static ClearToken() {
    localStorage.clear();
  }

  public static isLoggedIn(): boolean {
    const token = JSON.parse(String(localStorage.getItem("epl_token")));
    return token !== null &&
      !moment().isBefore(token.expires_in);
  }
}
