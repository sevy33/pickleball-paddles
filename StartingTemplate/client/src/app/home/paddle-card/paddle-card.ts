import { Component, input } from '@angular/core';
import { PaddleDto } from '../paddle-service';

@Component({
  selector: 'app-paddle-card',
  imports: [],
  templateUrl: './paddle-card.html',
  styleUrl: './paddle-card.scss',
})
export class PaddleCard {
  paddle = input.required<PaddleDto>();
}
