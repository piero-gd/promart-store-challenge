import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { toast } from 'sonner';
import { getProductById, getProductsByCategory } from '../api';
import { useCartStore } from '../../cart/store';
import type { Product } from '../../../types';

export type TabId = 'description' | 'specifications';

export function useProductDetail() {
  const { id } = useParams<{ id: string }>();

  const [product, setProduct] = useState<Product | null>(null);
  const [suggested, setSuggested] = useState<Product[]>([]);
  const [quantity, setQuantity] = useState(1);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');
  const [added, setAdded] = useState(false);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [activeTab, setActiveTab] = useState<TabId>('description');

  const addItem = useCartStore((s) => s.addItem);

  useEffect(() => {
    if (!id) return;
    setLoading(true);
    setError('');
    setCurrentIndex(0);
    setQuantity(1);
    setSuggested([]);

    getProductById(Number(id))
      .then((p) => {
        setProduct(p);
        return getProductsByCategory(p.category).then((all) =>
          setSuggested(all.filter((x) => x.id !== p.id).slice(0, 6))
        );
      })
      .catch(() => {
        setError('No se pudo cargar el producto.');
        toast.error('No se pudo cargar el producto. Intenta de nuevo.');
      })
      .finally(() => setLoading(false));
  }, [id]);

  const images = product?.images?.length ? product.images : product ? [product.image] : [];

  const prev = () => setCurrentIndex((i) => (i - 1 + images.length) % images.length);
  const next = () => setCurrentIndex((i) => (i + 1) % images.length);

  const handleAddToCart = () => {
    if (!product) return;
    addItem(product, quantity);
    setAdded(true);
    setTimeout(() => setAdded(false), 2500);
    toast.success(`"${product.title}" agregado al carrito`, {
      description: `${quantity} ${quantity === 1 ? 'unidad' : 'unidades'} · $${(product.price * quantity).toFixed(2)}`,
    });
  };

  return {
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
  };
}
