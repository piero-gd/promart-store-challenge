import { Link } from 'react-router-dom';
import type { Product } from '../../../types';

interface Props {
  product: Product;
}

export default function SuggestedCard({ product }: Props) {
  return (
    <Link
      to={`/products/${product.id}`}
      className="flex-shrink-0 w-44 bg-white rounded-2xl border border-gray-100 overflow-hidden hover:shadow-md hover:-translate-y-0.5 transition-all duration-200 group"
    >
      <div className="h-40 bg-gray-50 flex items-center justify-center p-3">
        <img
          src={product.image}
          alt={product.title}
          className="max-h-full max-w-full object-contain mix-blend-multiply group-hover:scale-105 transition-transform duration-300"
          loading="lazy"
        />
      </div>
      <div className="p-3 space-y-1">
        <p className="text-xs text-gray-500 truncate capitalize">{product.category}</p>
        <p className="text-sm font-semibold text-gray-800 line-clamp-2 leading-snug">{product.title}</p>
        <p className="text-sm font-bold text-primary-600">${product.price.toFixed(2)}</p>
      </div>
    </Link>
  );
}
