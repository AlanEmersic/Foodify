export type NavigationItemNameType = "Home" | "My profile" | "About" | "Log In" | "Log Out" | "Register";

export type NavigationItemType = {
  id?: number;
  name: NavigationItemNameType;
  link: string;
};

export const ROUTES = {
  HOME: "/",
  MY_PROFILE: "/profile",
  ABOUT: "/about",
  LOG_IN: "/login",
  LOG_OUT: "/logout",
  REGISTER: "/register",
  RESTAURANT_DETAILS: "/restaurant/:id",
};

export const NAVIGATION_ITEMS: NavigationItemType[] = [
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
