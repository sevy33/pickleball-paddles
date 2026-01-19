export interface PaddleImage {
  id: number;
  paddleId: number;
  imageUrl: string;
  isPrimary: boolean;
}

export interface PaddleReview {
  id: number;
  paddleId: number;
  reviewerName: string;
  rating: number;
  comment?: string;
  created_at: string;
}

export interface Paddle {
  id: number;
  name: string;
  brand: string;
  price: number;
  description?: string;
  surface_material?: string;
  core_material?: string;
  weight_oz?: number;
  is_approved: boolean;
  images: PaddleImage[];
  reviews: PaddleReview[];
}
