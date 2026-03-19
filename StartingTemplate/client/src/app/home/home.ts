import { Component, inject, OnInit, signal } from '@angular/core';
import { PaddleDto, PaddleService } from './paddle-service';
import { CommonModule } from '@angular/common';
import { PaddleCard } from './paddle-card/paddle-card';

@Component({
  selector: 'app-home',
  imports: [CommonModule, PaddleCard],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit {
    private paddleService = inject(PaddleService);

    paddles = signal<PaddleDto[]>([]);
    isLoading = signal(true);

    ngOnInit(): void {
      this.paddleService.getPaddles().subscribe({
        next: (paddles) => {
          this.paddles.set(paddles);
          this.isLoading.set(false);
        },
        error: (err) => {
          console.error(err);
          this.isLoading.set(false);
        }
      });
    }
}
