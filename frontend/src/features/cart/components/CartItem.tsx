import { TrashIcon } from '@heroicons/react/24/outline';
import type { CartItem as CartItemType } from '../../../types';
import { useCartStore } from '../store';

interface Props {
  item: CartItemType;
}

export default function CartItem({ item }: Props) {
  const { removeItem, updateQuantity } = useCartStore();
  const { product, quantity } = item;

  return (
    <div className="flex items-start gap-4 py-4 border-b border-gray-100 last:border-0">
      {/* Product image */}
      <div className="w-20 h-20 flex-shrink-0 bg-gray-50 rounded-xl p-2 border border-gray-100">
        <img
          src={product.image}
          alt={product.title}
          className="w-full h-full object-contain mix-blend-multiply"
        />
      </div>

      {/* Info */}
      <div className="flex-1 min-w-0">
        <p className="text-sm font-semibold text-gray-800 line-clamp-2 leading-snug">
          {product.title}
        </p>
        <p className="text-xs text-gray-400 mt-0.5 capitalize">{product.category}</p>
        <p className="text-sm font-bold text-primary-600 mt-1">
          ${product.price.toFixed(2)} c/u
        </p>

        {/* Quantity controls */}
        <div className="flex items-center gap-2 mt-2">
          <div className="flex items-center border border-gray-200 rounded-lg overflow-hidden">
            <button
              onClick={() => updateQuantity(product.id, quantity - 1)}
              className="px-2 py-1 text-gray-500 hover:bg-gray-100 transition-colors text-sm"
              aria-label="Disminuir"
            >
              −
            </button>
            <span className="px-3 py-1 text-sm font-medium text-gray-700 min-w-[2rem] text-center">
              {quantity}
            </span>
            <button
              onClick={() => updateQuantity(product.id, quantity + 1)}
              className="px-2 py-1 text-gray-500 hover:bg-gray-100 transition-colors text-sm"
              aria-label="Aumentar"
            >
              +
            </button>
          </div>

          <button
            onClick={() => removeItem(product.id)}
            className="ml-auto p-1.5 text-gray-300 hover:text-red-500 hover:bg-red-50 rounded-lg transition-all"
            aria-label="Eliminar producto"
            title="Eliminar"
          >
            <TrashIcon className="w-4 h-4" />
          </button>
        </div>
      </div>

      {/* Subtotal */}
      <div className="text-right flex-shrink-0">
        <p className="text-sm font-bold text-gray-900">
          ${(product.price * quantity).toFixed(2)}
        </p>
      </div>
    </div>
  );
}
