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
  images: string[];
  specifications: string;
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

/** Devuelve el label en español para un valor de categoría del API. */
export function getCategoryLabel(value: string): string {
  return CATEGORIES.find((c) => c.value === value)?.label ?? value;
}
