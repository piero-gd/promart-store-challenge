import { useNavigate, Link } from 'react-router-dom';
import {
  ChevronLeftIcon,
  ChevronRightIcon,
  MagnifyingGlassPlusIcon,
  CheckIcon,
  ShoppingCartIcon,
  ExclamationTriangleIcon,
  TruckIcon,
  ArrowUturnLeftIcon,
  TagIcon,
  BuildingStorefrontIcon,
} from '@heroicons/react/24/outline';
import { useProductDetail } from '../hooks/useProductDetail';
import StarRating from '../components/StarRating';
import SuggestedCard from '../components/SuggestedCard';
import { getCategoryLabel } from '../../../types';
import Navbar from '../../../components/Navbar';
import Footer from '../../../components/Footer';

export default function ProductDetailPage() {
  const navigate = useNavigate();
  const {
    product,
    suggested,
    quantity,
    setQuantity,
    loading,
    error,
    added,
    images,
    currentIndex,
    setCurrentIndex,
    prev,
    next,
    activeTab,
    setActiveTab,
    handleAddToCart,
  } = useProductDetail();

  return (
    <div className="min-h-screen bg-gray-50">
      <Navbar />

      <main className="max-w-7xl mx-auto px-5 sm:px-6 lg:px-8 py-6">

        {/* ── Loading skeleton ── */}
        {loading && (
          <div className="animate-pulse space-y-6">
            {/* Breadcrumb skeleton */}
            <div className="flex gap-2">
              {[60, 80, 120].map((w, i) => (
                <div key={i} className="flex items-center gap-2">
                  <div className="h-3 bg-gray-200 rounded" style={{ width: w }} />
                  {i < 2 && <div className="h-3 w-2 bg-gray-200 rounded" />}
                </div>
              ))}
            </div>
            {/* Main content skeleton */}
            <div className="bg-white rounded-2xl p-6 md:p-10 flex flex-col md:flex-row gap-10">
              <div className="flex-shrink-0 w-full md:w-96 space-y-3">
                <div className="h-96 bg-gray-100 rounded-2xl" />
                <div className="flex gap-2">
                  {[1, 2, 3].map((i) => <div key={i} className="w-16 h-16 bg-gray-100 rounded-xl" />)}
                </div>
              </div>
              <div className="flex-1 space-y-4">
                <div className="h-3 bg-gray-100 rounded w-1/3" />
                <div className="h-8 bg-gray-100 rounded w-3/4" />
                <div className="h-6 bg-gray-100 rounded w-1/4" />
                <div className="h-4 bg-gray-100 rounded w-full" />
                <div className="h-4 bg-gray-100 rounded w-5/6" />
                <div className="h-4 bg-gray-100 rounded w-4/6" />
                <div className="h-12 bg-gray-100 rounded-xl w-full mt-4" />
              </div>
            </div>
          </div>
        )}

        {/* ── Error ── */}
        {!loading && error && (
          <div className="text-center py-24 space-y-4">
            <ExclamationTriangleIcon className="w-12 h-12 text-gray-300 mx-auto" />
            <p className="text-gray-500">{error}</p>
            <button onClick={() => navigate('/')} className="px-6 py-2.5 bg-primary-600 text-white rounded-xl hover:bg-primary-700 text-sm font-medium transition-colors">
              Volver a la tienda
            </button>
          </div>
        )}

        {/* ── Product detail ── */}
        {!loading && product && (
          <div className="space-y-8">

            {/* Breadcrumb */}
            <nav className="flex items-center gap-1.5 text-sm text-gray-400">
              <Link to="/" className="hover:text-primary-600 transition-colors">Inicio</Link>
              <ChevronRightIcon className="w-3 h-3" />
              <button onClick={() => navigate(`/?category=${encodeURIComponent(product.category)}`)} className="hover:text-primary-600 transition-colors capitalize">{product.category}</button>
              <ChevronRightIcon className="w-3 h-3" />
              <span className="text-gray-600 font-medium truncate max-w-[200px]">{product.title}</span>
            </nav>

            {/* Main card */}
            <div className="bg-white rounded-2xl shadow-sm border border-gray-100 overflow-hidden">
              <div className="flex flex-col lg:flex-row">

                {/* ─── Carousel column ─── */}
                <div className="lg:w-[480px] flex-shrink-0 p-6 lg:p-8 flex flex-col gap-4 lg:border-r border-gray-100">
                  {/* Main image */}
                  <div className="relative bg-gray-50 rounded-2xl overflow-hidden group" style={{ aspectRatio: '1 / 1' }}>
                    <img
                      key={currentIndex}
                      src={images[currentIndex]}
                      alt={`${product.title} - imagen ${currentIndex + 1}`}
                      className="w-full h-full object-contain p-8 mix-blend-multiply"
                    />
                    {/* Zoom icon */}
                    <button className="absolute top-3 right-3 w-8 h-8 bg-white rounded-full shadow flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity">
                      <MagnifyingGlassPlusIcon className="w-4 h-4 text-gray-500" />
                    </button>
                    {/* Prev / Next */}
                    {images.length > 1 && (
                      <>
                        <button onClick={prev} className="absolute left-3 top-1/2 -translate-y-1/2 w-8 h-8 bg-white rounded-full shadow flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity hover:bg-gray-50" aria-label="Anterior">
                          <ChevronLeftIcon className="w-4 h-4 text-gray-600" />
                        </button>
                        <button onClick={next} className="absolute right-3 top-1/2 -translate-y-1/2 w-8 h-8 bg-white rounded-full shadow flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity hover:bg-gray-50" aria-label="Siguiente">
                          <ChevronRightIcon className="w-4 h-4 text-gray-600" />
                        </button>
                      </>
                    )}
                  </div>

                  {/* Thumbnails */}
                  {images.length > 1 && (
                    <div className="flex gap-2">
                      {images.map((src, i) => (
                        <button
                          key={i}
                          onClick={() => setCurrentIndex(i)}
                          className={`w-16 h-16 rounded-xl border-2 p-1.5 bg-gray-50 transition-all flex-shrink-0 ${
                            i === currentIndex ? 'border-primary-500' : 'border-gray-200 hover:border-gray-300'
                          }`}
                          aria-label={`Ver imagen ${i + 1}`}
                        >
                          <img src={src} alt="" className="w-full h-full object-contain mix-blend-multiply" />
                        </button>
                      ))}
                    </div>
                  )}

                  {/* Dot indicators */}
                  {images.length > 1 && (
                    <div className="flex gap-1.5 justify-center">
                      {images.map((_, i) => (
                        <button
                          key={i}
                          onClick={() => setCurrentIndex(i)}
                          className={`h-1.5 rounded-full transition-all ${
                            i === currentIndex ? 'w-6 bg-primary-500' : 'w-1.5 bg-gray-300 hover:bg-gray-400'
                          }`}
                          aria-label={`Imagen ${i + 1}`}
                        />
                      ))}
                    </div>
                  )}
                </div>

                {/* ─── Info column ─── */}
                <div className="flex-1 p-6 lg:p-8 flex flex-col gap-5">

                  {/* Stars */}
                  <StarRating rate={product.rating.rate} count={product.rating.count} />

                  {/* Title */}
                  <div>
                    <h1 className="text-2xl lg:text-3xl font-bold text-gray-900 leading-tight">
                      {product.title}
                    </h1>
                  </div>

                  {/* Price */}
                  <div className="flex items-baseline gap-3">
                    <span className="text-3xl font-extrabold text-primary-600">
                      ${product.price.toFixed(2)}
                    </span>
                    <span className="text-sm text-gray-400 line-through">
                      ${(product.price * 1.2).toFixed(2)}
                    </span>
                    <span className="text-xs font-semibold text-green-600 bg-green-50 px-2 py-0.5 rounded-full">
                      -17%
                    </span>
                  </div>

                  {/* Description */}
                  <p className="text-sm text-gray-500 leading-relaxed">
                    {product.description}
                  </p>

                  <div className="border-t border-gray-100" />

                  {/* Quantity label + selector */}
                  <div className="space-y-2">
                    <p className="text-sm font-semibold text-gray-700">Cantidad</p>
                    <div className="flex items-center gap-3">
                      <div className="flex items-center border border-gray-200 rounded-xl overflow-hidden">
                        <button
                          onClick={() => setQuantity((q) => Math.max(1, q - 1))}
                          className="w-10 h-10 flex items-center justify-center text-gray-500 hover:bg-gray-100 transition-colors text-xl"
                          aria-label="Disminuir"
                        >
                          −
                        </button>
                        <span className="w-12 text-center text-base font-semibold text-gray-800">
                          {quantity}
                        </span>
                        <button
                          onClick={() => setQuantity((q) => q + 1)}
                          className="w-10 h-10 flex items-center justify-center text-gray-500 hover:bg-gray-100 transition-colors text-xl"
                          aria-label="Aumentar"
                        >
                          +
                        </button>
                      </div>

                      {/* Add to cart */}
                      <button
                        onClick={handleAddToCart}
                        className={`flex-1 py-2.5 rounded-xl font-semibold text-sm transition-all duration-200 flex items-center justify-center gap-2 ${
                          added
                            ? 'bg-green-500 text-white'
                            : 'bg-primary-600 hover:bg-primary-700 text-white shadow-sm shadow-primary-200'
                        }`}
                      >
                        {added ? (
                          <>
                            <CheckIcon className="w-4 h-4" />
                            Agregado
                          </>
                        ) : (
                          <>
                            <ShoppingCartIcon className="w-4 h-4" />
                            Agregar al carrito
                          </>
                        )}
                      </button>
                    </div>

                    {/* Subtotal — only visible when qty > 1 */}
                    {quantity > 1 && (
                      <p className="text-sm text-gray-400 pl-1">
                        Subtotal: <span className="font-semibold text-gray-700">${(product.price * quantity).toFixed(2)}</span>
                      </p>
                    )}
                  </div>

                  {/* Guarantees */}
                  <div className="grid grid-cols-2 gap-2 pt-1">
                    {[
                      { icon: <TruckIcon className="w-4 h-4 text-primary-500" />, label: 'Envío gratis' },
                      { icon: <ArrowUturnLeftIcon className="w-4 h-4 text-primary-500" />, label: 'Devolución 30 días' },
                      { icon: <TagIcon className="w-4 h-4 text-primary-500" />, label: 'Garantía de marca' },
                      { icon: <BuildingStorefrontIcon className="w-4 h-4 text-primary-500" />, label: 'Garantía del fabricante' },
                    ].map(({ icon, label }) => (
                      <div key={label} className="flex items-center gap-2 text-xs text-gray-500 bg-gray-50 rounded-xl px-3 py-2.5">
                        <span className="text-base">{icon}</span>
                        <span>{label}</span>
                      </div>
                    ))}
                  </div>

                </div>
              </div>
            </div>

            {/* ── Suggested products ── */}
            {suggested.length > 0 && (
              <section className="space-y-4">
                <div className="flex items-center justify-between">
                  <h2 className="text-lg font-bold text-gray-900">Productos relacionados</h2>
                  <button
                    onClick={() => navigate('/')}
                    className="text-sm text-primary-600 hover:text-primary-700 font-medium transition-colors"
                  >
                    Ver todos →
                  </button>
                </div>
                <div className="flex gap-4 overflow-x-auto pb-2 scrollbar-hide">
                  {suggested.map((p) => (
                    <SuggestedCard key={p.id} product={p} />
                  ))}
                </div>
              </section>
            )}

            {/* ── Product info tabs ── */}
            <div className="bg-white rounded-2xl border border-gray-100 overflow-hidden">
              {/* Tab headers */}
              <div className="flex border-b border-gray-100">
                <button
                  onClick={() => setActiveTab('description')}
                  className={`flex-shrink-0 px-5 py-3.5 text-sm font-medium transition-colors border-b-2 ${
                    activeTab === 'description'
                      ? 'border-primary-500 text-primary-600'
                      : 'border-transparent text-gray-500 hover:text-gray-700'
                  }`}
                >
                  Descripción
                </button>
                <button
                  onClick={() => setActiveTab('specifications')}
                  className={`flex-shrink-0 px-5 py-3.5 text-sm font-medium transition-colors border-b-2 ${
                    activeTab === 'specifications'
                      ? 'border-primary-500 text-primary-600'
                      : 'border-transparent text-gray-500 hover:text-gray-700'
                  }`}
                >
                  Especificaciones
                </button>
              </div>

              {/* Tab content */}
              <div className="p-6">
                {activeTab === 'description' && (
                  <div className="space-y-6">
                    <p className="text-sm text-gray-600 leading-relaxed">
                      {product.description}
                    </p>
                    <div className="border-t border-gray-100 pt-5">
                      <h4 className="text-xs font-semibold text-gray-400 uppercase tracking-wider mb-4">
                        Información del producto
                      </h4>
                      <div className="grid sm:grid-cols-2 gap-x-8 gap-y-0 divide-y divide-gray-50">
                        {[
                          { label: 'Categoría',      value: getCategoryLabel(product.category) },
                          { label: 'Calificación',   value: `${product.rating.rate} / 5 (${product.rating.count} reseñas)` },
                          { label: 'Precio',         value: `$${product.price.toFixed(2)}` },
                          { label: 'Disponibilidad', value: 'En stock' },
                          { label: 'Envío',          value: 'Gratis en compras mayores a $50' },
                          { label: 'Garantía',       value: '12 meses contra defectos de fabricación' },
                        ].map(({ label, value }) => (
                          <div key={label} className="flex items-center justify-between py-2.5 gap-4">
                            <span className="text-xs font-medium text-gray-400 shrink-0">{label}</span>
                            <span className="text-sm text-gray-700 capitalize text-right">{value}</span>
                          </div>
                        ))}
                      </div>
                    </div>
                  </div>
                )}
                {activeTab === 'specifications' && (
                  <p className="text-sm text-gray-600 leading-relaxed whitespace-pre-line">
                    {product.specifications ?? 'Sin especificaciones disponibles.'}
                  </p>
                )}
              </div>
            </div>

          </div>
        )}
      </main>
      <Footer />
    </div>
  );
}
