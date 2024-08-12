import { useNavigate } from "react-router-dom";

import { NewRestaurantIcon } from "assets";
import { AdminRestaurantCard, ROUTES, useRestaurants } from "features";

function AdminRestaurantList() {
  const navigate = useNavigate();

  const restaurants = useRestaurants();

  const handleCreateRestaurant = () => {
    navigate(ROUTES.ADMIN_CREATE_RESTAURANT);
  };

  return (
    <div>
      <div
        className="mb-5 flex w-52 cursor-pointer items-center gap-4 rounded-2xl border text-center font-bold text-blue-400 shadow-md transition duration-500 hover:scale-110"
        onClick={handleCreateRestaurant}
      >
        Create new restaurant
        <NewRestaurantIcon className="inline-block h-4 w-4 fill-blue-500" />
      </div>

      <div className="m-auto grid w-full grid-cols-2 content-center items-center justify-center gap-5 p-0">
        {restaurants?.data?.map(restaurant => <AdminRestaurantCard key={restaurant.id} restaurant={restaurant}></AdminRestaurantCard>)}
      </div>
    </div>
  );
}

export { AdminRestaurantList };
