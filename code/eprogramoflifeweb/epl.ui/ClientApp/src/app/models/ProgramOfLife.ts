import { Deffects } from '../models/deffects.model';

export class ProgramOfLife {
  id: number;
  Name!: string;
  LastUpdate!: Date;
  Motto!: string;
  Ideal!: string;
  Virtue!: string;
  Means: Array<string>;
  Deffects: Deffects;

  constructor(id: number) {
    this.id = id;
    this.Means = new Array<string>();
    this.Deffects = new Deffects();
  }
}
