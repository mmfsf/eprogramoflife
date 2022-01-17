import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared.module';
import { CommitmentsModule } from '../commitments/commitments.module';
import { DefectsComponent } from '../defects/defects.component';
import { AvatarComponent } from './avatar/avatar.component';
import { ProgramOfLifeComponent } from './programoflife.component';

@NgModule({
  imports: [CommonModule, CommitmentsModule, SharedModule],
  declarations: [AvatarComponent, DefectsComponent, ProgramOfLifeComponent],
})
export class ProgramOfLifeModule {}
