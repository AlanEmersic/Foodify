export type RestaurantCommand = {
  name: string;
  description: string;
  address: string;
  email: string;
  imageUrl: string;
};

export type ProductCommand = {
  restaurantId: string;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
};

export type MonthlySpending = {
  month: string;
  totalSpent: number;
};

export type UserOrdersSummary = {
  userId: string;
  email: string;
  totalAmountSpent: number;
  monthlySpendings: MonthlySpending[];
};

export type RestaurantSummary = {
  id: string;
  name: number;
  summary: ProductSummary[];
};

export type ProductSummary = {
  productName: string;
  totalQuantity: number;
  sales: Sales[];
};

export type Sales = {
  month: string;
  quantity: number;
};
