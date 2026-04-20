import { Link } from 'react-router-dom';
import Navbar from '../components/Navbar';
import CartItemComponent from '../components/CartItem';
import { useCartStore } from '../store/cartStore';

export default function CartPage() {
  const { items, clearCart, totalItems, totalPrice } = useCartStore();
  const count = totalItems();
  const total = totalPrice();

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />

      <main className="max-w-5xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {/* Header */}
        <div className="flex items-center justify-between mb-8">
          <div>
            <h1 className="text-3xl font-bold text-gray-900">Carrito de Compras</h1>
            <p className="text-gray-500 mt-1">
              {count > 0
                ? `${count} producto${count !== 1 ? 's' : ''} en tu carrito`
                : 'Tu carrito está vacío'}
            </p>
          </div>
          <Link
            to="/"
            className="text-sm text-primary-600 hover:text-primary-700 font-medium flex items-center gap-1"
          >
            ← Seguir comprando
          </Link>
        </div>

        {/* Empty state */}
        {items.length === 0 && (
          <div className="text-center py-24">
            <div className="text-6xl mb-4">🛒</div>
            <h2 className="text-xl font-semibold text-gray-700 mb-2">
              Tu carrito está vacío
            </h2>
            <p className="text-gray-400 mb-8">
              Agrega productos desde la tienda para comenzar.
            </p>
            <Link
              to="/"
              className="inline-block px-6 py-3 bg-primary-600 hover:bg-primary-700 text-white font-semibold rounded-xl transition-colors"
            >
              Explorar productos
            </Link>
          </div>
        )}

        {/* Cart content */}
        {items.length > 0 && (
          <div className="lg:grid lg:grid-cols-3 lg:gap-8">
            {/* Items list */}
            <div className="lg:col-span-2">
              <div className="bg-white rounded-2xl shadow-sm border border-gray-100 p-6">
                <div className="flex items-center justify-between mb-4">
                  <h2 className="font-semibold text-gray-800">Productos</h2>
                  <button
                    onClick={clearCart}
                    className="text-xs text-red-400 hover:text-red-600 transition-colors"
                  >
                    Vaciar carrito
                  </button>
                </div>

                <div className="divide-y divide-gray-50">
                  {items.map((item) => (
                    <CartItemComponent key={item.product.id} item={item} />
                  ))}
                </div>
              </div>
            </div>

            {/* Order summary */}
            <div className="mt-6 lg:mt-0">
              <div className="bg-white rounded-2xl shadow-sm border border-gray-100 p-6 sticky top-24">
                <h2 className="font-semibold text-gray-800 mb-6">Resumen del pedido</h2>

                <div className="space-y-3 text-sm">
                  <div className="flex justify-between text-gray-500">
                    <span>Subtotal ({count} productos)</span>
                    <span className="font-medium text-gray-700">${total.toFixed(2)}</span>
                  </div>
                  <div className="flex justify-between text-gray-500">
                    <span>Envío</span>
                    <span className="text-green-500 font-medium">Gratis</span>
                  </div>
                  <div className="border-t border-gray-100 pt-3 flex justify-between font-bold text-base text-gray-900">
                    <span>Total</span>
                    <span className="text-primary-600 text-xl">${total.toFixed(2)}</span>
                  </div>
                </div>

                <button className="w-full mt-6 py-3 bg-primary-600 hover:bg-primary-700 text-white font-semibold rounded-xl transition-colors">
                  Proceder al pago
                </button>

                <p className="text-xs text-center text-gray-400 mt-3">
                  Pago seguro · Devoluciones gratuitas
                </p>
              </div>
            </div>
          </div>
        )}
      </main>
    </div>
  );
}
