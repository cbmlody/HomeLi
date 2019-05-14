import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { ClarityModule, ClrVerticalNavModule } from '@clr/angular';
import { NgxSpinnerModule } from 'ngx-spinner';

import { ROUTES } from './app.routes';

import { AppComponent, HeaderComponent, HomeComponent, MenuComponent } from './components';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MenuComponent,
    HomeComponent,
  ],
  imports: [
    // Angular
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(ROUTES),

    // 3rd party
    ClarityModule,
    NgxSpinnerModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
