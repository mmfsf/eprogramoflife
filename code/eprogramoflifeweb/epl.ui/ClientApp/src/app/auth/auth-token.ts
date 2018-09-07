// Models
import { Token } from "../models/token.model";

export class AuthToken {
  private token: Token;

  public static Set(token: Token) {
    sessionStorage.setItem("token_type", token.token_type);
    sessionStorage.setItem("access_token", token.access_token);
  }

  public static GetTokenType(): string {
    return sessionStorage.getItem("token_type");
  }

  public static GetAccessToken(): string {
    return sessionStorage.getItem("access_token");
  }
}
