import { Link } from 'react-router-dom';

const YEAR = new Date().getFullYear();

export default function Footer() {
  return (
    <footer className="bg-white border-t border-gray-100 mt-16">
      <div className="max-w-5xl mx-auto px-4 sm:px-6 lg:px-8 py-10">

        {/* Top row */}
        <div className="flex flex-col sm:flex-row sm:items-start sm:justify-between gap-8">

          {/* Brand */}
          <div className="space-y-2">
            <span className="text-lg font-bold text-primary-600 tracking-tight">
              Promart<span className="text-gray-800">Store</span>
            </span>
            <p className="text-xs text-gray-400 max-w-xs leading-relaxed">
              Tu destino de compras online con los mejores productos y la mejor experiencia.
            </p>
          </div>

          {/* Links */}
          <nav aria-label="Footer navigation" className="flex gap-12">
            <div className="space-y-2">
              <p className="text-xs font-semibold text-gray-500 uppercase tracking-wider mb-3">Tienda</p>
              <ul className="space-y-2">
                <li><Link to="/" className="text-sm text-gray-400 hover:text-primary-600 transition-colors">Inicio</Link></li>
                <li><Link to="/cart" className="text-sm text-gray-400 hover:text-primary-600 transition-colors">Carrito</Link></li>
              </ul>
            </div>
            <div className="space-y-2">
              <p className="text-xs font-semibold text-gray-500 uppercase tracking-wider mb-3">Soporte</p>
              <ul className="space-y-2">
                <li><span className="text-sm text-gray-400">Devoluciones gratis</span></li>
                <li><span className="text-sm text-gray-400">Envío en 24–48 h</span></li>
                <li><span className="text-sm text-gray-400">Pago seguro</span></li>
              </ul>
            </div>
          </nav>
        </div>

        {/* Bottom row */}
        <div className="mt-8 pt-6 border-t border-gray-100 flex flex-col sm:flex-row items-center justify-between gap-2">
          <p className="text-xs text-gray-400">
            &copy; {YEAR} PromartStore. Todos los derechos reservados.
          </p>
          <p className="text-xs text-gray-300">
            Prueba técnica &mdash; React + .NET 8
          </p>
        </div>

      </div>
    </footer>
  );
}
