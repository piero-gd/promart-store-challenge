import { Link, useNavigate } from 'react-router-dom';
import { ShoppingCartIcon, ArrowRightStartOnRectangleIcon } from '@heroicons/react/24/outline';
import { useCartStore } from '../features/cart/store';

export default function Navbar() {
  const navigate = useNavigate();
  const totalItems = useCartStore((s) => s.totalItems());

  const handleLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    navigate('/login');
  };

  const username = localStorage.getItem('username') || '';

  return (
    <header className="bg-white shadow-sm sticky top-0 z-50">
      <div className="max-w-7xl mx-auto px-5 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-16">
          {/* Logo */}
          <Link to="/" className="flex items-center gap-2">
            <span className="text-2xl font-bold text-primary-600">
              Promart
            </span>
            <span className="text-sm font-medium text-gray-400">
              Store
            </span>
          </Link>

          {/* Actions */}
          <div className="flex items-center gap-4">
            {username && (
              <span className="text-sm text-gray-500 hidden sm:block">
                Hola, <strong className="text-gray-700">{username}</strong>
              </span>
            )}

            {/* Cart button */}
            <Link
              to="/cart"
              className="relative p-2 rounded-full hover:bg-gray-100 transition-colors"
              aria-label="Carrito de compras"
            >
              <ShoppingCartIcon className="w-6 h-6 text-gray-600" />
              {totalItems > 0 && (
                <span className="absolute -top-1 -right-1 bg-primary-600 text-white text-xs font-bold rounded-full w-5 h-5 flex items-center justify-center">
                  {totalItems > 99 ? '99+' : totalItems}
                </span>
              )}
            </Link>

            {/* Logout */}
            <button
              onClick={handleLogout}
              className="flex items-center gap-1 text-sm text-gray-500 hover:text-red-500 transition-colors p-2 rounded-lg hover:bg-red-50"
              aria-label="Cerrar sesión"
            >
              <ArrowRightStartOnRectangleIcon className="w-5 h-5" />
              <span className="hidden sm:block">Salir</span>
            </button>
          </div>
        </div>
      </div>
    </header>
  );
}
