import { Link, useNavigate } from 'react-router-dom';
import { useCartStore } from '../store/cartStore';

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
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex items-center justify-between h-16">
          {/* Logo */}
          <Link to="/" className="flex items-center gap-2">
            <span className="text-2xl font-bold text-primary-600">
              Promart
            </span>
            <span className="text-sm font-medium text-gray-400 hidden sm:block">
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
              <svg className="w-6 h-6 text-gray-600" fill="none" stroke="currentColor" strokeWidth={1.5} viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 00-3 3h15.75m-12.75-3h11.218c1.121-2.3 2.1-4.684 2.83-7.08a60.026 60.026 0 00-17.5 0c.83 2.396 1.8 4.8 2.83 7.08zm0 0 1.5 5.25M17.25 14.25l1.5 5.25M3 3l1.125 4.218" />
              </svg>
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
              <svg className="w-5 h-5" fill="none" stroke="currentColor" strokeWidth={1.5} viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" d="M15.75 9V5.25A2.25 2.25 0 0013.5 3h-6a2.25 2.25 0 00-2.25 2.25v13.5A2.25 2.25 0 007.5 21h6a2.25 2.25 0 002.25-2.25V15M12 9l-3 3m0 0l3 3m-3-3h12.75" />
              </svg>
              <span className="hidden sm:block">Salir</span>
            </button>
          </div>
        </div>
      </div>
    </header>
  );
}
