import { Defects } from './defects.model';

export interface ProgramOfLife {
  id: number;
  Name: string;
  LastUpdate: Date;
  Motto: string;
  Ideal: string;
  Virtue: string;
  Means: Array<string>;
  Defects: Defects;
}
