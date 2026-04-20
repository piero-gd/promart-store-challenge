import type { Category } from '../types';
import { CATEGORIES } from '../types';

interface Props {
  selected: Category;
  onChange: (category: Category) => void;
}

export default function CategoryFilter({ selected, onChange }: Props) {
  return (
    <div className="flex flex-wrap gap-2">
      {CATEGORIES.map(({ label, value }) => (
        <button
          key={value}
          onClick={() => onChange(value)}
          className={`px-4 py-2 rounded-full text-sm font-medium transition-all duration-200 border ${
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
