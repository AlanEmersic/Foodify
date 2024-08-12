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
