import { useState, useEffect, useCallback } from 'react';
import { useSearchParams } from 'react-router-dom';
import { getProducts, getProductsByCategory } from '../api';
import type { Product, Category } from '../../../types';
import { CATEGORIES } from '../../../types';

export function useProducts() {
  const [searchParams] = useSearchParams();

  const initialCategory = (): Category => {
    const param = searchParams.get('category');
    const valid = CATEGORIES.map((c) => c.value);
    return valid.includes(param as Category) ? (param as Category) : 'all';
  };

  const [products, setProducts] = useState<Product[]>([]);
  const [selectedCategory, setSelectedCategory] = useState<Category>(initialCategory);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const fetchProducts = useCallback(async (category: Category) => {
    setLoading(true);
    setError('');
    try {
      const data =
        category === 'all'
          ? await getProducts()
          : await getProductsByCategory(category);
      setProducts(data);
    } catch {
      setError('No se pudieron cargar los productos. Intenta de nuevo.');
    } finally {
      setLoading(false);
    }
  }, []);

  useEffect(() => {
    fetchProducts(selectedCategory);
  }, [selectedCategory, fetchProducts]);

  const handleCategoryChange = (category: Category) => {
    setSelectedCategory(category);
  };

  const retry = () => fetchProducts(selectedCategory);

  return {
    products,
    selectedCategory,
    loading,
    error,
    handleCategoryChange,
    retry,
  };
}
