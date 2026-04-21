import type { Category } from '../types';
import { CATEGORIES } from '../types';

interface Props {
  selected: Category;
  onChange: (category: Category) => void;
}

export default function CategoryFilter({ selected, onChange }: Props) {
  return (
    /* Mobile: single scrollable row  |  sm+: wrapping row (current desktop behaviour) */
    <div className="flex gap-2 overflow-x-auto sm:overflow-x-visible sm:flex-wrap scrollbar-hide pb-0.5 -mx-5 px-5 sm:mx-0 sm:px-0">
      {CATEGORIES.map(({ label, value }) => (
        <button
          key={value}
          onClick={() => onChange(value)}
          className={`flex-shrink-0 px-3.5 py-1.5 sm:px-4 sm:py-2 rounded-full text-xs sm:text-sm font-medium transition-all duration-200 border ${
            selected === value
              ? 'bg-primary-600 text-white border-primary-600 shadow-sm'
              : 'bg-white text-gray-600 border-gray-200 hover:border-primary-400 hover:text-primary-600'
          }`}
        >
          {label}
        </button>
      ))}
    </div>
  );
}
