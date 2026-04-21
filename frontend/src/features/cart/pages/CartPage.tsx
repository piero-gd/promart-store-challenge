import { useState } from 'react';
import { Link } from 'react-router-dom';
import { ShoppingCartIcon, TrashIcon, ExclamationTriangleIcon } from '@heroicons/react/24/outline';
import Navbar from '../../../components/Navbar';
import Footer from '../../../components/Footer';
import CartItemComponent from '../components/CartItem';
import { useCartStore } from '../store';

export default function CartPage() {
  const { items, clearCart, totalItems, totalPrice } = useCartStore();
  const count = totalItems();
  const total = totalPrice();
  const [showClearConfirm, setShowClearConfirm] = useState(false);

  function handleClearCart() {
    clearCart();
    setShowClearConfirm(false);
  }

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />

      <main className="max-w-6xl mx-auto px-5 sm:px-6 lg:px-8 py-8">
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
            <div className="mb-4 flex justify-center"><ShoppingCartIcon className="w-16 h-16 text-gray-300" /></div>
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
                    onClick={() => setShowClearConfirm(true)}
                    className="flex items-center gap-1.5 text-xs text-red-400 hover:text-red-600 hover:bg-red-50 px-2.5 py-1.5 rounded-lg transition-all"
                  >
                    <TrashIcon className="w-3.5 h-3.5" />
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
      <Footer />

      {/* Confirmation modal — clear cart */}
      {showClearConfirm && (
        <div
          className="fixed inset-0 z-50 flex items-center justify-center p-4"
          role="dialog"
          aria-modal="true"
          aria-labelledby="confirm-title"
        >
          {/* Backdrop */}
          <div
            className="absolute inset-0 bg-black/40 backdrop-blur-sm"
            onClick={() => setShowClearConfirm(false)}
          />

          {/* Panel */}
          <div className="relative bg-white rounded-2xl shadow-xl max-w-sm w-full p-6 animate-in fade-in zoom-in-95 duration-150">
            <div className="flex items-center gap-3 mb-4">
              <div className="flex-shrink-0 w-10 h-10 rounded-full bg-red-50 flex items-center justify-center">
                <ExclamationTriangleIcon className="w-5 h-5 text-red-500" />
              </div>
              <div>
                <h3 id="confirm-title" className="font-semibold text-gray-900">¿Vaciar carrito?</h3>
                <p className="text-sm text-gray-500">Se eliminarán todos los productos agregados.</p>
              </div>
            </div>

            <div className="flex gap-3 justify-end mt-6">
              <button
                onClick={() => setShowClearConfirm(false)}
                className="px-4 py-2 text-sm font-medium text-gray-600 hover:text-gray-800 hover:bg-gray-100 rounded-lg transition-colors"
              >
                Cancelar
              </button>
              <button
                onClick={handleClearCart}
                className="flex items-center gap-2 px-4 py-2 text-sm font-semibold text-white bg-red-500 hover:bg-red-600 active:bg-red-700 rounded-lg transition-colors"
              >
                <TrashIcon className="w-4 h-4" />
                Vaciar carrito
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
