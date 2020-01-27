import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProgramOfLifeComponent } from './components/programoflife/programoflife.component';
import { LoginComponent } from './components/login/login.component';
import { CommitmentsComponent } from './components/commitments/commitments.component';


const routes: Routes = [
  {
    path: '',
    component: ProgramOfLifeComponent
  },  
  {
    path: 'commitments',
    component: CommitmentsComponent
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
