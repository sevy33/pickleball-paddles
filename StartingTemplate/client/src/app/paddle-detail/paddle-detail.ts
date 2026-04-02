import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaddleDto, PaddleService } from '../home/paddle-service';

@Component({
  selector: 'app-paddle-detail',
  imports: [],
  templateUrl: './paddle-detail.html',
  styleUrl: './paddle-detail.scss',
})
export class PaddleDetail implements OnInit {

  private activatedRoute = inject(ActivatedRoute);

  private paddleService = inject(PaddleService);

  paddleId = signal<number>(0);

  paddleDto = signal<PaddleDto | null>(null);

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(params => {
      this.paddleId.set(Number(params['id']));
      this.getPaddle();
    });
  }

  getPaddle() {
    this.paddleService.getPaddle(this.paddleId()).subscribe(paddle => {
      this.paddleDto.set(paddle);
    });
  }

}
