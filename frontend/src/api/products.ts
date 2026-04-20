import api from './axiosClient';
import type { Product } from '../types';

export const getProducts = async (): Promise<Product[]> => {
  const { data } = await api.get<Product[]>('/api/products');
  return data;
};

export const getProductsByCategory = async (category: string): Promise<Product[]> => {
  const { data } = await api.get<Product[]>(`/api/products/category/${encodeURIComponent(category)}`);
  return data;
};
