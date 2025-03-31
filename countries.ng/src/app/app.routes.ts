import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home', loadComponent: () => import('./pages/home/home.component').then(m => m.HomeComponent)},
    { path: 'countries', loadComponent: () => import('./pages/countries/countries.component').then(m => m.CountriesComponent)},
    { path: '**', redirectTo: 'home' }
];
