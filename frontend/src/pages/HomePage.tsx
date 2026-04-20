import { useState, useEffect, useCallback } from 'react';
import { getProducts, getProductsByCategory } from '../api/products';
import type { Product, Category } from '../types';
import ProductCard from '../components/ProductCard';
import CategoryFilter from '../components/CategoryFilter';
import Navbar from '../components/Navbar';

export default function HomePage() {
  const [products, setProducts] = useState<Product[]>([]);
  const [selectedCategory, setSelectedCategory] = useState<Category>('all');
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

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />

      <main className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {/* Page header */}
        <div className="mb-8">
          <h1 className="text-3xl font-bold text-gray-900">Nuestros Productos</h1>
          <p className="text-gray-500 mt-1">Descubre nuestra selección de productos</p>
        </div>

        {/* Category filter */}
        <div className="mb-8">
          <CategoryFilter
            selected={selectedCategory}
            onChange={handleCategoryChange}
          />
        </div>

        {/* Loading skeleton */}
        {loading && (
          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
            {Array.from({ length: 8 }).map((_, i) => (
              <div key={i} className="bg-white rounded-2xl border border-gray-100 overflow-hidden animate-pulse">
                <div className="h-52 bg-gray-100" />
                <div className="p-4 space-y-3">
                  <div className="h-3 bg-gray-100 rounded w-1/3" />
                  <div className="h-4 bg-gray-100 rounded w-full" />
                  <div className="h-4 bg-gray-100 rounded w-4/5" />
                  <div className="h-6 bg-gray-100 rounded w-1/4" />
                  <div className="h-10 bg-gray-100 rounded-lg" />
                </div>
              </div>
            ))}
          </div>
        )}

        {/* Error state */}
        {!loading && error && (
          <div className="text-center py-16">
            <p className="text-red-500 text-lg">{error}</p>
            <button
              onClick={() => fetchProducts(selectedCategory)}
              className="mt-4 px-6 py-2 bg-primary-600 text-white rounded-xl hover:bg-primary-700 transition-colors"
            >
              Reintentar
            </button>
          </div>
        )}

        {/* Empty state */}
        {!loading && !error && products.length === 0 && (
          <div className="text-center py-16">
            <p className="text-gray-400 text-lg">No hay productos en esta categoría.</p>
          </div>
        )}

        {/* Product grid */}
        {!loading && !error && products.length > 0 && (
          <>
            <p className="text-sm text-gray-400 mb-4">
              {products.length} producto{products.length !== 1 ? 's' : ''} encontrado{products.length !== 1 ? 's' : ''}
            </p>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
              {products.map((product) => (
                <ProductCard key={product.id} product={product} />
              ))}
            </div>
          </>
        )}
      </main>
    </div>
  );
}
