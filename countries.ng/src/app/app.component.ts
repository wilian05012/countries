import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiClientService } from './services/api-client.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  constructor(private apiClient: ApiClientService) {}
}
