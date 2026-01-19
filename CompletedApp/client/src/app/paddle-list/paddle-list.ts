import { Component, inject, signal, effect } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { PaddleService } from '../services/paddle.service';
import { Paddle } from '../models/paddle.model';

@Component({
  selector: 'app-paddle-list',
  imports: [RouterLink, FormsModule],
  templateUrl: './paddle-list.html',
  styleUrl: './paddle-list.scss'
})
export class PaddleListComponent {
  private paddleService = inject(PaddleService);
  
  paddles = signal<Paddle[]>([]);
  searchQuery = signal('');
  minPrice = signal<number | null>(null);
  maxPrice = signal<number | null>(null);

  constructor() {
    effect(() => {
      this.loadPaddles();
    });
  }

  loadPaddles() {
    this.paddleService.getPaddles(this.searchQuery(), this.minPrice(), this.maxPrice())
      .subscribe(paddles => this.paddles.set(paddles));
  }
}
