import { useState } from 'react';
import { toast } from 'sonner';
import { useCartStore } from '../store';

const MODAL_OUT_DURATION = 200;

export function useCart() {
  const items = useCartStore((s) => s.items);
  const clearCart = useCartStore((s) => s.clearCart);
  const count = useCartStore((s) =>
    s.items.reduce((sum, i) => sum + i.quantity, 0)
  );
  const total = useCartStore((s) =>
    s.items.reduce((sum, i) => sum + i.product.price * i.quantity, 0)
  );

  const [showClearConfirm, setShowClearConfirm] = useState(false);
  const [isClosing, setIsClosing] = useState(false);

  const closeModal = () => {
    setIsClosing(true);
    setTimeout(() => {
      setShowClearConfirm(false);
      setIsClosing(false);
    }, MODAL_OUT_DURATION);
  };

  const handleClearCart = () => {
    clearCart();
    closeModal();
    toast.success('Carrito vaciado');
  };

  return {
    items,
    count,
    total,
    showClearConfirm,
    setShowClearConfirm,
    isClosing,
    closeModal,
    handleClearCart,
  };
}
