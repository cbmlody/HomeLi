import { LibraryModule } from './modules/library/library.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';

import { ROUTES } from './app.routes';
import { WelcomeComponent, AppComponent, HeaderComponent, SidebarComponent } from './components';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    HeaderComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule,
    LibraryModule,
    RouterModule.forRoot(ROUTES)
  ],
  bootstrap: [AppComponent],
  providers: []
})
export class AppModule { }
