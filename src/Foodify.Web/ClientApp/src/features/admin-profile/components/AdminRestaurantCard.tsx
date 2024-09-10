import { useNavigate } from "react-router-dom";

import { ROUTES, Restaurant } from "features";

type RestaurantCardProps = {
  restaurant: Restaurant;
};

function AdminRestaurantCard({ restaurant }: Readonly<RestaurantCardProps>) {
  const navigate = useNavigate();

  const handleOnRestaurantEditClick = (id: string) => {
    navigate(`${ROUTES.ADMIN_EDIT_RESTAURANT.replace(":id", id)}`);
  };

  const handleOnRestaurantProductsClick = (id: string) => {
    navigate(`${ROUTES.ADMIN_RESTAURANT_PRODUCTS.replace(":id", id)}`);
  };

  const handleOnRestaurantSummaryClick = (id: string) => {
    navigate(`${ROUTES.ADMIN_RESTAURANT_SUMMARY.replace(":id", id)}`);
  };

  return (
    <div className="m-5 flex h-[400px] transform cursor-pointer flex-col justify-between rounded-lg border border-gray-200 bg-white p-5 shadow-md transition duration-500 hover:scale-110">
      <div className="h-1/2 w-full overflow-hidden">
        <img className="h-full w-full rounded-lg object-cover" src={restaurant.imageUrl} alt="" />
      </div>
      <div className="flex flex-1 flex-col justify-between pt-5">
        <h5 className="text-gray-90 mb-2 text-2xl font-bold tracking-tight">{restaurant.name}</h5>
        <p className="mb-3 font-normal text-gray-700">{restaurant.description}</p>
        <div className="mt-3 flex justify-between">
          <div
            className="flex cursor-pointer flex-row items-center rounded-lg bg-orange-400 px-3 py-2 text-center text-sm font-medium text-white hover:bg-orange-500 focus:outline-none focus:ring-4"
            onClick={() => handleOnRestaurantEditClick(restaurant.id)}
          >
            Edit
            <svg className="ms-2 h-3.5 w-3.5 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
              <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9" />
            </svg>
          </div>

          <div
            className="flex cursor-pointer flex-row items-center rounded-lg bg-green-300 px-3 py-2 text-center text-sm font-medium text-white hover:bg-green-500 focus:outline-none focus:ring-4"
            onClick={() => handleOnRestaurantProductsClick(restaurant.id)}
          >
            Products
            <svg className="ms-2 h-3.5 w-3.5 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
              <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9" />
            </svg>
          </div>

          <div
            className="flex cursor-pointer flex-row items-center rounded-lg bg-teal-400 px-3 py-2 text-center text-sm font-medium text-white hover:bg-teal-500 focus:outline-none focus:ring-4"
            onClick={() => handleOnRestaurantSummaryClick(restaurant.id)}
          >
            Summary
            <svg className="ms-2 h-3.5 w-3.5 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
              <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9" />
            </svg>
          </div>
        </div>
      </div>
    </div>
  );
}

export { AdminRestaurantCard };
