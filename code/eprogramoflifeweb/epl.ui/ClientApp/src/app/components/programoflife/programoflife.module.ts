import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { AvatarComponent } from "./avatar/avatar.component";
import { ProgramOfLifeComponent } from "./programoflife.component";

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    AvatarComponent,
    ProgramOfLifeComponent
  ],
})
export class ProgramOfLifeModule { }
