import { Component } from '@angular/core';
import { NavComponent } from '../nav/nav.component';

@Component({
  selector: 'app-content',
  standalone: true,
  imports: [
    NavComponent
  ],
  templateUrl: './content.component.html',
  styleUrl: './content.component.css'
})
export class ContentComponent {

}
