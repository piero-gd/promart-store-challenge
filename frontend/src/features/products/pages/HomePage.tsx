import { useProducts } from '../hooks/useProducts';
import type { Category } from '../../../types';
import ProductCard from '../components/ProductCard';
import CategoryFilter from '../components/CategoryFilter';
import Footer from '../../../components/Footer';

export default function HomePage() {
  const { products, selectedCategory, loading, error, handleCategoryChange, retry } = useProducts();

  return (
    <div className="min-h-screen bg-gray-50">

      <main className="max-w-7xl mx-auto px-5 sm:px-6 lg:px-8 py-8">
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
          <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-3 sm:gap-6">
            {Array.from({ length: 8 }).map((_, i) => (
              <div key={i} className="bg-white rounded-2xl border border-gray-100 overflow-hidden animate-pulse flex flex-row sm:flex-col">
                <div className="flex-shrink-0 w-28 sm:w-auto sm:h-52 bg-gray-100" />
                <div className="flex-1 p-3 sm:p-4 space-y-3">
                  <div className="h-3 bg-gray-100 rounded w-1/3" />
                  <div className="h-4 bg-gray-100 rounded w-full" />
                  <div className="h-4 bg-gray-100 rounded w-4/5" />
                  <div className="h-6 bg-gray-100 rounded w-1/4" />
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
              onClick={retry}
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
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-3 sm:gap-6">
              {products.map((product) => (
                <ProductCard key={product.id} product={product} />
              ))}
            </div>
          </>
        )}
      </main>
      <Footer />
    </div>
  );
}
