import { Component, inject, input } from '@angular/core';
import { PaddleDto } from '../paddle-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-paddle-card',
  imports: [],
  templateUrl: './paddle-card.html',
  styleUrl: './paddle-card.scss',
})
export class PaddleCard {
  paddle = input.required<PaddleDto>();

  private router = inject(Router);

  routeToPaddleDetail() {
    this.router.navigate(['/paddle'], { queryParams: { id: this.paddle().id } });
    
  }   
}


