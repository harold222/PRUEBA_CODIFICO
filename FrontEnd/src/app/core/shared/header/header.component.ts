import { Component, inject } from '@angular/core';
import { NgStyle } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NavigationService } from '../../services/navigation.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbarModule,
    NgStyle
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  public service = inject(NavigationService);
}
