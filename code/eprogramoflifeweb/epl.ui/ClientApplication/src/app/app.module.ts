import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatToolbarModule,
  MatListModule,
  MatIconModule,
  MatGridListModule,
  MatFormFieldModule,
  MatCardModule,
  MatProgressSpinnerModule,
  MatInputModule,
  MatMenuModule
} from '@angular/material';

import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

// Interceptors
import { HttpBaseInterceptor } from './inteceptors/http-base.interceptor';

// Services
import { CommonService } from './services/common.service';
import { AuthService } from './services/auth.service';

// Components
import { CommitmentComponent } from './components/commitment/commitment.component';
import { CommitmentsComponent } from './components/commitments/commitments.component';
import { LoginComponent } from './components/login/login.component';
import { ProgramOfLifeComponent } from './components/programoflife/programoflife.component';


export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    CommitmentComponent,
    CommitmentsComponent,
    ProgramOfLifeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatGridListModule,
    MatFormFieldModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatInputModule,
    MatMenuModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    CommonService,
    AuthService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpBaseInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
