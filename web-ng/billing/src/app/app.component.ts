import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContentComponent, FooterComponent } from './layout';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { bootstrapApplication } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ContentComponent, FooterComponent],
 
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',

})
export class AppComponent implements OnInit{
  title = 'billing';

  constructor(private router: Router) {}

  ngOnInit() {
   console.log('OnInit');
  }
}

bootstrapApplication(AppComponent, {
  providers: [provideRouter(routes)],
});
