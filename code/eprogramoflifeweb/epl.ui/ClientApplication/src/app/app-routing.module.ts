import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProgramOfLifeComponent } from './components/programoflife/programoflife.component';
import { LoginComponent } from './components/login/login.component';
import { CommitmentComponent } from './components/commitment/commitment.component';


const routes: Routes = [
  {
    path: '',
    component: ProgramOfLifeComponent
  },  
  {
    path: 'commitments',
    component: CommitmentComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
