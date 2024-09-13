import { Routes } from '@angular/router';
import { ContentComponent, NotFoundComponent } from './layout';

export const routes: Routes = [
   { path: '', component: ContentComponent, pathMatch: 'full' },  
   {path: '**', component: NotFoundComponent},
];
