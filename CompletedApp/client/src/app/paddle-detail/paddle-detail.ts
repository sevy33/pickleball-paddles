import { Component, inject, input, signal, effect } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PaddleService } from '../services/paddle.service';
import { Paddle, PaddleReview } from '../models/paddle.model';

@Component({
  selector: 'app-paddle-detail',
  imports: [DatePipe, FormsModule],
  templateUrl: './paddle-detail.html',
  styleUrl: './paddle-detail.scss'
})
export class PaddleDetailComponent {
  private paddleService = inject(PaddleService);
  
  id = input.required<string>();
  
  paddle = signal<Paddle | null>(null);
  currentImageIndex = signal(0);
  
  showReviewForm = signal(false);
  newReview: Partial<PaddleReview> = { rating: 5, reviewerName: '', comment: '' };

  constructor() {
    effect(() => {
        const idVal = this.id();
        if(idVal) {
            this.loadPaddle(+idVal);
        }
    });
  }

  loadPaddle(id: number) {
    this.paddleService.getPaddle(id).subscribe(p => {
        this.paddle.set(p);
        this.currentImageIndex.set(0); 
    });
  }
  
  nextImage() {
    const p = this.paddle();
    this.currentImageIndex.update(i => (i + 1) % p!.images.length);
  }
  
  prevImage() {
    const p = this.paddle();
    this.currentImageIndex.update(i => (i - 1 + p!.images.length) % p!.images.length);
  }

  submitReview() {
    const p = this.paddle();
    if(p === null) return;

    this.newReview.paddleId = p.id;
    this.paddleService.addReview(this.newReview).subscribe(() => {
        this.showReviewForm.set(false);
        this.newReview = { rating: 5, reviewerName: '', comment: '' };
        this.loadPaddle(p.id);
    });
  }
}
