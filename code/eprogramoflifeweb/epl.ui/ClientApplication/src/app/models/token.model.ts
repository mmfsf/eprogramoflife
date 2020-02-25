export class Token {
  access_token: string;
  expires_in: Date;
  token_type: string;

  constructor(access_token: string, expires_in: Date, token_type: string) {
    this.access_token = access_token;
    this.expires_in = expires_in;
    this.token_type = token_type;
  }
}
