export interface Commitment {
  id: string;
  name: string;
  description: string;
  frequency: number;
  pointed: boolean;
}

export enum Frequency {
  Daily,
  Weekly,
  Monthly,
  Yearly
}
