import { QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import { queryClient } from "config";
import {
  AdminCreateRestaurant,
  AdminEditRestaurant,
  AdminProfile,
  AdminRestaurantProducts,
  AdminRestaurantSummary,
  CartDetails,
  Login,
  Navigation,
  OrderDetails,
  ROUTES,
  Register,
  RestaurantDetails,
  RestaurantList,
  UserProfile,
} from "features";
import { ProtectedRoute } from "routes";

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Navigation />
        <Routes>
          <Route path={ROUTES.HOME} element={<RestaurantList />} />
          <Route path={ROUTES.LOG_IN} element={<Login />} />
          <Route path={ROUTES.REGISTER} element={<Register />} />
          <Route path={ROUTES.RESTAURANT_DETAILS} element={<RestaurantDetails />} />

          <Route element={<ProtectedRoute />}>
            <Route path={ROUTES.ADMIN_PROFILE} element={<AdminProfile />} />
            <Route path={ROUTES.ADMIN_CREATE_RESTAURANT} element={<AdminCreateRestaurant />} />
            <Route path={ROUTES.ADMIN_EDIT_RESTAURANT} element={<AdminEditRestaurant />} />
            <Route path={ROUTES.ADMIN_RESTAURANT_PRODUCTS} element={<AdminRestaurantProducts />} />
            <Route path={ROUTES.ADMIN_RESTAURANT_SUMMARY} element={<AdminRestaurantSummary />} />
            <Route path={ROUTES.MY_PROFILE} element={<UserProfile />} />
            <Route path={ROUTES.ORDER_DETAILS} element={<OrderDetails />} />
            <Route path={ROUTES.CART} element={<CartDetails />} />
          </Route>

          <Route path={"*"} element={<RestaurantList />} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
