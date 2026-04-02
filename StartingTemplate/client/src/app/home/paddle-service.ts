import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PaddleService {
  private http = inject(HttpClient);

  baseUrl = 'http://localhost:5067';

  getPaddles() {
    return this.http.get<PaddleDto[]>(`${this.baseUrl}/api/paddles`);
  }

  getPaddle(id: number) {
    return this.http.get<PaddleDto>(`${this.baseUrl}/api/paddles/paddle`, { params: { id: id.toString() } });
  }
}

export interface PaddleDto {
    id: number;
    name: string;
    brand: string;
    thumbnailUrl: string;
    price: number;
    description: string;
    surfaceMaterial: string;
    coreMaterial: string;
    weightOz: number;
}
