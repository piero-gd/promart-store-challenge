import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { Toaster } from 'sonner';
import LoginPage from './features/auth/pages/LoginPage';
import HomePage from './features/products/pages/HomePage';
import CartPage from './features/cart/pages/CartPage';
import ProductDetailPage from './features/products/pages/ProductDetailPage';
import ScrollToTop from './components/ScrollToTop';
import Layout from './components/Layout';

export default function App() {
  return (
    <BrowserRouter>
      <ScrollToTop />
      <Toaster
        position="top-right"
        richColors
        closeButton
        duration={3500}
        toastOptions={{
          classNames: {
            toast: 'font-sans text-sm rounded-xl shadow-lg',
          },
        }}
      />
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route element={<Layout />}>
          <Route path="/" element={<HomePage />} />
          <Route path="/cart" element={<CartPage />} />
          <Route path="/products/:id" element={<ProductDetailPage />} />
        </Route>
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  );
}
