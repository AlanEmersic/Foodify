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
