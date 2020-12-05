export class Commitment {
  id: string;
  name: string;
  description: string;
  frequency: number;
  pointed: boolean

  constructor(id: string, name: string, description: string, frequency: number, pointed: boolean) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.frequency = frequency;
    this.pointed = pointed;
  }
}

export enum Frequency {
  Daily,
  Weekly,
  Monthly,
  Yearly
}
