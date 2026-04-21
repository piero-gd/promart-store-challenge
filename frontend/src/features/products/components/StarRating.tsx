import { StarIcon } from '@heroicons/react/24/solid';

interface Props {
  rate: number;
  count: number;
}

export default function StarRating({ rate, count }: Props) {
  return (
    <div className="flex items-center gap-2">
      <div className="flex gap-0.5">
        {Array.from({ length: 5 }).map((_, i) => (
          <StarIcon
            key={i}
            className={`w-4 h-4 ${i < Math.round(rate) ? 'text-yellow-400' : 'text-gray-200'}`}
          />
        ))}
      </div>
      <span className="text-sm font-medium text-gray-700">{rate.toFixed(1)}</span>
      <span className="text-sm text-gray-400">({count} reseñas)</span>
    </div>
  );
}
