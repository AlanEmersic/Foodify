export type Restaurant = {
  id: string;
  name: string;
  description: string;
  address: string;
  email: string;
  imageUrl: string;
  products?: Product[];
};

export type Product = {
  id: string;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
};

export type OrderCommand = {
  orderItems: OrderItemCommand[];
};

export type OrderItemCommand = {
  productId: string;
  quantity: number;
  price: number;
};

export type CartItemCommand = {
  productId: string;
  quantity: number;
  price: number;
  product: Product;
};

export type CartCommand = {
  cartItems: CartItemCommand[];
};
