import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProgramOfLifeComponent } from './components/programoflife/programoflife.component';
import { LoginComponent } from './components/login/login.component';
import { CommitmentsComponent } from './components/commitments/commitments.component';
import { AuthGuard } from './auth/auth.guard';


const routes: Routes = [
  {
    path: '',
    component: ProgramOfLifeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'commitments',
    component: CommitmentsComponent,
    canActivate: [AuthGuard]
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
