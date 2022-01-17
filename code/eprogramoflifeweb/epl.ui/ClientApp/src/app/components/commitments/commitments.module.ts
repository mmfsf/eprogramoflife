import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatGridListModule } from '@angular/material/grid-list';
import { SharedModule } from 'src/app/shared.module';

//Components
import { CommitmentComponent } from './commitment/commitment.component';
import { CommitmentsComponent } from './commitments.component';

@NgModule({
  imports: [CommonModule, MatCheckboxModule, MatGridListModule, SharedModule],
  declarations: [CommitmentComponent, CommitmentsComponent],
  exports: [CommitmentsComponent]
})
export class CommitmentsModule {}
