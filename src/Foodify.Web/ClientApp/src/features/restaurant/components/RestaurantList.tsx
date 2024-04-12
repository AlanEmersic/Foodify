import { RestaurantCard, useRestaurants } from "features";

function RestaurantList() {
  const restaurants = useRestaurants();

  return (
    <div className="m-auto grid w-[80%] grid-cols-3 content-center items-center justify-center gap-5 p-0">
      {restaurants?.data?.map(restaurant => <RestaurantCard key={restaurant.id} restaurant={restaurant}></RestaurantCard>)}
    </div>
  );
}

export { RestaurantList };
