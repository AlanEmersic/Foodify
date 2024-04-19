import { QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter, Route, Routes } from "react-router-dom";

import { queryClient } from "config";
import { Login, Navigation, ROUTES, Register, RestaurantDetails, RestaurantList } from "features";

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
          <Route path={"*"} element={<RestaurantList />} />
        </Routes>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
