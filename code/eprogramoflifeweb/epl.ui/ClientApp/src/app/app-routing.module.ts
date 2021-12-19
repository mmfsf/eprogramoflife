import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProgramOfLifeComponent } from './components/programoflife/programoflife.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'programoflife', component: ProgramOfLifeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
