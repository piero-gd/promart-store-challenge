import { Link } from 'react-router-dom';
import { ChevronRightIcon } from '@heroicons/react/24/outline';
import type { Product } from '../../../types';

interface Props {
  product: Product;
}

const StarIcon = ({ filled }: { filled: boolean }) => (
  <svg
    className={`w-3.5 h-3.5 ${filled ? 'text-yellow-400' : 'text-gray-200'}`}
    fill="currentColor"
    viewBox="0 0 20 20"
  >
    <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.286 3.957a1 1 0 00.95.69h4.162c.969 0 1.371 1.24.588 1.81l-3.37 2.448a1 1 0 00-.364 1.118l1.287 3.957c.3.921-.755 1.688-1.54 1.118l-3.37-2.448a1 1 0 00-1.175 0l-3.37 2.448c-.784.57-1.838-.197-1.54-1.118l1.287-3.957a1 1 0 00-.363-1.118L2.063 9.384c-.784-.57-.38-1.81.588-1.81h4.162a1 1 0 00.951-.69l1.285-3.957z" />
  </svg>
);

export default function ProductCard({ product }: Props) {
  const stars = Array.from({ length: 5 }, (_, i) => i < Math.round(product.rating.rate));

  return (
    <Link
      to={`/products/${product.id}`}
      className="bg-white rounded-2xl shadow-sm border border-gray-100 overflow-hidden hover:shadow-md hover:-translate-y-0.5 transition-all duration-200 cursor-pointer
        flex flex-row sm:flex-col"
    >
      {/* ── Image ── */}
      <div className="
        flex-shrink-0 flex items-center justify-center bg-gray-50
        w-28 h-auto sm:w-auto sm:h-52
        p-3 sm:p-4
      ">
        <img
          src={product.image}
          alt={product.title}
          className="w-full h-full object-contain mix-blend-multiply"
          loading="lazy"
        />
      </div>

      {/* ── Content ── */}
      <div className="flex flex-col flex-1 p-3 sm:p-4 gap-2 sm:gap-3 min-w-0">
        {/* Category badge */}
        <span className="text-xs font-medium text-primary-600 bg-primary-50 px-2 py-0.5 rounded-full self-start capitalize">
          {product.category}
        </span>

        {/* Title */}
        <h3 className="text-sm font-semibold text-gray-800 leading-snug line-clamp-2 flex-1">
          {product.title}
        </h3>

        {/* Rating — hidden on mobile to save space */}
        <div className="hidden sm:flex items-center gap-1">
          <div className="flex">{stars.map((f, i) => <StarIcon key={i} filled={f} />)}</div>
          <span className="text-xs text-gray-400">({product.rating.count})</span>
        </div>

        {/* Price + CTA */}
        <div className="flex items-center justify-between mt-auto pt-1">
          <p className="text-base sm:text-xl font-bold text-gray-900">
            ${product.price.toFixed(2)}
          </p>
          <ChevronRightIcon className="w-4 h-4 text-gray-400 flex-shrink-0" />
        </div>
      </div>
    </Link>
  );
}
