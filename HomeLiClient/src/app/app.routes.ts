import { Routes } from '@angular/router';
import { WelcomeComponent } from './components';
import { BookListComponent } from './modules';

export const ROUTES: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '', component: WelcomeComponent },
  { path: 'library/books', component: BookListComponent }
];
