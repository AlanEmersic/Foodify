export type NavigationItem = {
  id?: number;
  name: "Home" | "About";
  link: string;
};

export const ROUTES = {
  HOME: "/",
  ADMIN_PROFILE: "/admin-profile",
  ADMIN_CREATE_RESTAURANT: "/admin-profile/create-restaurant",
  ADMIN_EDIT_RESTAURANT: "/admin-profile/edit-restaurant/:id",
  ADMIN_RESTAURANT_PRODUCTS: "/admin-profile/restaurant-products/:id",
  ADMIN_RESTAURANT_SUMMARY: "/admin-profile/restaurant/:id/summary",
  MY_PROFILE: "/profile",
  ABOUT: "/about",
  LOG_IN: "/login",
  LOG_OUT: "/logout",
  REGISTER: "/register",
  RESTAURANT_DETAILS: "/restaurant/:id",
  ORDER_DETAILS: "/order/:id",
  CART: "/cart",
};

export const NAVIGATION_ITEMS: NavigationItem[] = [
  {
    id: 1,
    name: "Home",
    link: ROUTES.HOME,
  },
  {
    id: 2,
    name: "About",
    link: ROUTES.ABOUT,
  },
];
