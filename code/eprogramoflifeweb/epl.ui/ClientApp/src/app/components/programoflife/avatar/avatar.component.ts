import { Input, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ProgramOfLife } from 'src/app/models/ProgramOfLife';

@Component({
  selector: 'app-avatar',
  templateUrl: './avatar.component.html',
  styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent implements OnInit {
  @Input() programOfLife!: ProgramOfLife;

  constructor() {
  }

  ngOnInit(): void {
  }
}
