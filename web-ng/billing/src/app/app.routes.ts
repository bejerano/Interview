import { Routes } from '@angular/router';
import { ContentComponent, NotFoundComponent } from './layout';

export const routes: Routes = [
   {
    path: '/',
    component: ContentComponent
   },
   {path: '**', component: NotFoundComponent},
   {path: '', redirectTo: '/', pathMatch: 'full'}

    
];
