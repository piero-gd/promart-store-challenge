import { useState } from 'react';
import type { Product } from '../types';
import { useCartStore } from '../store/cartStore';

interface Props {
  product: Product;
}

export default function ProductCard({ product }: Props) {
  const [quantity, setQuantity] = useState(1);
  const [added, setAdded] = useState(false);
  const addItem = useCartStore((s) => s.addItem);

  const handleAdd = () => {
    addItem(product, quantity);
    setAdded(true);
    setTimeout(() => setAdded(false), 1500);
    setQuantity(1);
  };

  return (
    <div className="bg-white rounded-2xl shadow-sm border border-gray-100 flex flex-col overflow-hidden hover:shadow-md transition-shadow duration-200">
      {/* Product Image */}
      <div className="flex items-center justify-center h-52 bg-gray-50 p-4">
        <img
          src={product.image}
          alt={product.title}
          className="h-full w-auto object-contain mix-blend-multiply"
          loading="lazy"
        />
      </div>

      {/* Content */}
      <div className="flex flex-col flex-1 p-4 gap-3">
        {/* Category badge */}
        <span className="text-xs font-medium text-primary-600 bg-primary-50 px-2 py-0.5 rounded-full self-start capitalize">
          {product.category}
        </span>

        {/* Title */}
        <h3 className="text-sm font-semibold text-gray-800 leading-snug line-clamp-2 flex-1">
          {product.title}
        </h3>

        {/* Rating */}
        <div className="flex items-center gap-1">
          <div className="flex">
            {Array.from({ length: 5 }).map((_, i) => (
              <svg
                key={i}
                className={`w-3.5 h-3.5 ${
                  i < Math.round(product.rating.rate)
                    ? 'text-yellow-400'
                    : 'text-gray-200'
                }`}
                fill="currentColor"
                viewBox="0 0 20 20"
              >
                <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.286 3.957a1 1 0 00.95.69h4.162c.969 0 1.371 1.24.588 1.81l-3.37 2.448a1 1 0 00-.364 1.118l1.287 3.957c.3.921-.755 1.688-1.54 1.118l-3.37-2.448a1 1 0 00-1.175 0l-3.37 2.448c-.784.57-1.838-.197-1.54-1.118l1.287-3.957a1 1 0 00-.363-1.118L2.063 9.384c-.784-.57-.38-1.81.588-1.81h4.162a1 1 0 00.951-.69l1.285-3.957z" />
              </svg>
            ))}
          </div>
          <span className="text-xs text-gray-400">({product.rating.count})</span>
        </div>

        {/* Price */}
        <p className="text-xl font-bold text-gray-900">
          ${product.price.toFixed(2)}
        </p>

        {/* Quantity + Add button */}
        <div className="flex items-center gap-2 mt-auto">
          {/* Quantity selector */}
          <div className="flex items-center border border-gray-200 rounded-lg overflow-hidden">
            <button
              onClick={() => setQuantity((q) => Math.max(1, q - 1))}
              className="px-2 py-1 text-gray-500 hover:bg-gray-100 transition-colors"
              aria-label="Disminuir cantidad"
            >
              −
            </button>
            <span className="px-3 py-1 text-sm font-medium text-gray-700 min-w-[2rem] text-center">
              {quantity}
            </span>
            <button
              onClick={() => setQuantity((q) => q + 1)}
              className="px-2 py-1 text-gray-500 hover:bg-gray-100 transition-colors"
              aria-label="Aumentar cantidad"
            >
              +
            </button>
          </div>

          {/* Add to cart */}
          <button
            onClick={handleAdd}
            className={`flex-1 py-2 px-3 rounded-lg text-sm font-semibold transition-all duration-200 ${
              added
                ? 'bg-green-500 text-white'
                : 'bg-primary-600 hover:bg-primary-700 text-white'
            }`}
          >
            {added ? '✓ Agregado' : 'Agregar'}
          </button>
        </div>
      </div>
    </div>
  );
}
