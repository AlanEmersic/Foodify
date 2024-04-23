import { Product } from "features";

export type User = {
  id: string;
  email: string;
  address: string;
  phone: string;
  roles: string[];
  subscriptionType: string;
};

export type Order = {
  id: string;
  totalPrice: number;
  placedTime: string;
  completedTime?: string;
  status: string;
  orderItems?: OrderItem[];
};

export type OrderItem = {
  id: string;
  orderId: string;
  productId: string;
  quantity: number;
  price: number;
  product: Product;
};
