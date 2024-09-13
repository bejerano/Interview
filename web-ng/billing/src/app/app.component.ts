import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContentComponent, FooterComponent } from './layout';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ContentComponent, FooterComponent],
 
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',

})
export class AppComponent {
  title = 'billing';
}
