import { useNavigate } from 'react-router-dom';
import { XMarkIcon, ShoppingCartIcon, TrashIcon } from '@heroicons/react/24/outline';
import { toast } from 'sonner';
import { useCartStore } from '../store';
import { getCategoryLabel } from '../../../types';

interface Props {
  open: boolean;
  onClose: () => void;
}

export default function MiniCart({ open, onClose }: Props) {
  const items = useCartStore((s) => s.items);
  const removeItem = useCartStore((s) => s.removeItem);
  const total = useCartStore((s) =>
    s.items.reduce((sum, i) => sum + i.product.price * i.quantity, 0)
  );
  const count = useCartStore((s) =>
    s.items.reduce((sum, i) => sum + i.quantity, 0)
  );

  const navigate = useNavigate();

  const goToCart = () => {
    navigate('/cart');
    onClose();
  };

  return (
    <>
      {/* ── Mobile backdrop ───────────────────────────────────────────────── */}
      <div
        aria-hidden="true"
        onClick={onClose}
        className={`
          sm:hidden fixed inset-0 z-40 bg-black/40 backdrop-blur-sm
          transition-opacity duration-300
          ${open ? 'opacity-100 pointer-events-auto' : 'opacity-0 pointer-events-none'}
        `}
      />

      {/* ── Panel ─────────────────────────────────────────────────────────── */}
      {/*
        Mobile  (< sm): fixed right drawer — slides in from the right
        Desktop (sm+):  absolute dropdown  — fades + scales from top-right
      */}
      <div
        role="dialog"
        aria-modal="true"
        aria-label="Carrito rápido"
        aria-hidden={!open}
        className={[
          // Mobile base: full-height right drawer
          'fixed top-0 right-0 z-50',
          'h-dvh w-[320px] max-w-[85vw]',
          'flex flex-col bg-white shadow-2xl',
          'transition-transform duration-300 ease-in-out',
          // Desktop overrides: absolute dropdown below cart button
          'sm:absolute sm:top-full sm:right-0',
          'sm:h-auto sm:max-h-[72vh] sm:w-80',
          'sm:rounded-2xl sm:border sm:border-gray-100 sm:mt-2',
          'sm:transition-all sm:duration-200 sm:ease-out sm:origin-top-right',
          // Open / closed state
          open
            ? 'translate-x-0 sm:opacity-100 sm:scale-100 sm:pointer-events-auto'
            : 'translate-x-full sm:translate-x-0 sm:opacity-0 sm:scale-95 pointer-events-none',
        ].join(' ')}
      >
        {/* ── Drag handle (mobile only) ─────────────────────────────────── */}
        <div className="sm:hidden flex justify-center pt-3 pb-1 flex-shrink-0">
          <div className="w-10 h-1 rounded-full bg-gray-200" />
        </div>

        {/* ── Header ───────────────────────────────────────────────────────── */}
        <div className="flex items-center justify-between px-5 py-4 border-b border-gray-100 flex-shrink-0">
          <div className="flex items-center gap-2">
            <ShoppingCartIcon className="w-5 h-5 text-primary-600" />
            <h2 className="font-semibold text-gray-900">Mi carrito</h2>
            {count > 0 && (
              <span className="text-xs font-bold bg-primary-600 text-white rounded-full px-1.5 py-0.5 leading-none min-w-[1.25rem] text-center">
                {count > 99 ? '99+' : count}
              </span>
            )}
          </div>
          <button
            onClick={onClose}
            className="p-1.5 rounded-lg text-gray-400 hover:text-gray-600 hover:bg-gray-100 transition-colors"
            aria-label="Cerrar carrito"
          >
            <XMarkIcon className="w-5 h-5" />
          </button>
        </div>

        {/* ── Empty state ──────────────────────────────────────────────────── */}
        {items.length === 0 ? (
          <div className="flex-1 flex flex-col items-center justify-center gap-3 py-12 px-5">
            <div className="w-16 h-16 rounded-full bg-gray-50 flex items-center justify-center">
              <ShoppingCartIcon className="w-8 h-8 text-gray-300" />
            </div>
            <p className="text-sm text-gray-500 text-center">Tu carrito está vacío</p>
            <button
              onClick={onClose}
              className="text-sm text-primary-600 hover:text-primary-700 font-medium transition-colors"
            >
              Seguir comprando →
            </button>
          </div>
        ) : (
          <>
            {/* ── Items list ─────────────────────────────────────────────── */}
            <ul className="flex-1 overflow-y-auto divide-y divide-gray-50 px-4 py-1 scrollbar-hide">
              {items.map(({ product, quantity }) => (
                <li key={product.id} className="flex items-center gap-3 py-3">
                  {/* Thumbnail */}
                  <div className="w-14 h-14 flex-shrink-0 rounded-xl bg-gray-50 border border-gray-100 p-1.5">
                    <img
                      src={product.image}
                      alt={product.title}
                      className="w-full h-full object-contain mix-blend-multiply"
                      loading="lazy"
                    />
                  </div>

                  {/* Info */}
                  <div className="flex-1 min-w-0 space-y-0.5">
                    <p className="text-xs font-medium text-gray-800 line-clamp-2 leading-snug">
                      {product.title}
                    </p>
                    <p className="text-xs text-gray-400">
                      {getCategoryLabel(product.category)}
                    </p>
                    <div className="flex items-center justify-between pt-0.5">
                      <span className="text-xs text-gray-400">
                        {quantity} × ${product.price.toFixed(2)}
                      </span>
                      <span className="text-xs font-bold text-primary-600">
                        ${(product.price * quantity).toFixed(2)}
                      </span>
                    </div>
                  </div>

                  {/* Remove */}
                  <button
                    onClick={() => {
                      removeItem(product.id);
                      toast.success('Producto eliminado del carrito');
                    }}
                    className="flex-shrink-0 p-1.5 text-gray-300 hover:text-red-500 hover:bg-red-50 rounded-lg transition-all"
                    aria-label={`Eliminar ${product.title}`}
                  >
                    <TrashIcon className="w-4 h-4" />
                  </button>
                </li>
              ))}
            </ul>

            {/* ── Footer ─────────────────────────────────────────────────── */}
            <div className="border-t border-gray-100 px-5 py-4 space-y-3 flex-shrink-0">
              <div className="flex items-center justify-between">
                <span className="text-sm text-gray-500">
                  Total ({count} {count === 1 ? 'producto' : 'productos'})
                </span>
                <span className="text-base font-bold text-gray-900">
                  ${total.toFixed(2)}
                </span>
              </div>
              <button
                onClick={goToCart}
                className="w-full py-3 bg-primary-600 hover:bg-primary-700 active:bg-primary-700 text-white text-sm font-semibold rounded-xl transition-colors"
              >
                Ver carrito completo
              </button>
              <button
                onClick={onClose}
                className="w-full py-2 text-sm text-gray-400 hover:text-gray-600 transition-colors"
              >
                Seguir comprando
              </button>
            </div>
          </>
        )}
      </div>
    </>
  );
}
