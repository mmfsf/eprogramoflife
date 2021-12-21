import { Deffects } from '../models/deffects.model';

export interface ProgramOfLife {
  id: number;
  Name: string;
  LastUpdate: Date;
  Motto: string;
  Ideal: string;
  Virtue: string;
  Means: Array<string>;
  Deffects: Deffects;
}
