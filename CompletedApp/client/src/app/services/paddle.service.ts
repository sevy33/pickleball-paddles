import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Paddle, PaddleReview } from '../models/paddle.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PaddleService {
  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:5129/api'; 

  getPaddles(search: string = '', minPrice: number | null = null, maxPrice: number | null = null): Observable<Paddle[]> {
    let params = new HttpParams();
    if (search) params = params.set('search', search);
    if (minPrice !== null) params = params.set('minPrice', minPrice);
    if (maxPrice !== null) params = params.set('maxPrice', maxPrice);

    return this.http.get<Paddle[]>(`${this.apiUrl}/paddles`, { params });
  }

  getPaddle(id: number): Observable<Paddle> {
    return this.http.get<Paddle>(`${this.apiUrl}/paddles/${id}`);
  }

  addReview(review: Partial<PaddleReview>): Observable<PaddleReview> {
    return this.http.post<PaddleReview>(`${this.apiUrl}/reviews`, review);
  }
}
