import { create } from "zustand";

import { CartItemCommand } from "features";

type CartState = {
  items: CartItemCommand[];
  addItem: (newItem: CartItemCommand) => void;
  updateItem: (productId: string, quantity: number) => void;
  removeItem: (productId: string) => void;
  clearCart: () => void;
};

const useCartStore = create<CartState>(set => ({
  items: [],
  addItem: newItem =>
    set(state => ({
      items: [...state.items, newItem],
    })),
  updateItem: (productId, quantity) =>
    set(state => ({
      items: state.items.map(item => (item.productId === productId ? { ...item, quantity } : item)),
    })),
  removeItem: productId =>
    set(state => ({
      items: state.items.filter(item => item.productId !== productId),
    })),
  clearCart: () => set({ items: [] }),
}));

export { useCartStore };