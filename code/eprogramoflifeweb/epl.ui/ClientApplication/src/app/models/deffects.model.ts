export class Deffects {
  id: number;
  Dominant: string;
  God: Array<string>;
  Myself: Array<string>;
  Others: Array<string>;

  constructor() {
    this.God = new Array<string>();
    this.Myself = new Array<string>();
    this.Others = new Array<string>();
  }
}
