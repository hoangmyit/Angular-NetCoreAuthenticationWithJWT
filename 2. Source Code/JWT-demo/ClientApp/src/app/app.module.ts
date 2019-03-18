import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './modules/app-routing.module';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule   } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// libs
import { NotifierModule } from 'angular-notifier';
// layouts
import { MainLayoutComponent } from './components/shared/main-layout/main-layout.component';
import { PageNotFoundComponent } from './components/shared/page-error/page-not-found/page-not-found.component';
import { UnauthorizedComponent } from './components/shared/page-error/unauthorized/unauthorized.component';
import { AuthInterceptor } from './components/user/auth/auth.interceptor';


@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    PageNotFoundComponent,
    UnauthorizedComponent,
  ],
  imports: [
    RouterModule,
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NotifierModule
  ],
  exports: [
    PageNotFoundComponent,
    MainLayoutComponent,
    UnauthorizedComponent
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
