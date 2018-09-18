export class Commitment {
  id: number;
  name: string;
  frequency: number;

  constructor(id: number, name: string, frequency: number) {
    this.id = id;
    this.name = name;
    this.frequency = frequency;
  }
}
