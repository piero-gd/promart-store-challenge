// ─── Product Types ───────────────────────────────────────────────────────────

export interface ProductRating {
  rate: number;
  count: number;
}

export interface Product {
  id: number;
  title: string;
  price: number;
  description: string;
  category: string;
  image: string;
  rating: ProductRating;
}

// ─── Cart Types ───────────────────────────────────────────────────────────────

export interface CartItem {
  product: Product;
  quantity: number;
}

// ─── Auth Types ───────────────────────────────────────────────────────────────

export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  token: string;
  username: string;
}

// ─── Category Types ───────────────────────────────────────────────────────────

export type Category =
  | 'all'
  | 'electronics'
  | 'jewelery'
  | "men's clothing"
  | "women's clothing";

export const CATEGORIES: { label: string; value: Category }[] = [
  { label: 'Todo', value: 'all' },
  { label: 'Electrónica', value: 'electronics' },
  { label: 'Joyería', value: 'jewelery' },
  { label: 'Ropa Hombre', value: "men's clothing" },
  { label: 'Ropa Mujer', value: "women's clothing" },
];
