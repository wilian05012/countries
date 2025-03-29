import { AfterViewInit, Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { WorldStatsService } from './services/world-stats.service';
import { WorldStats } from './core/world-stats';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements AfterViewInit {
  worldStats: WorldStats | null = null;

  constructor(private worldStatsService: WorldStatsService) { }  
  
  ngAfterViewInit(): void {
    this.worldStats = this.worldStatsService.getWorldStats();
  }
}
