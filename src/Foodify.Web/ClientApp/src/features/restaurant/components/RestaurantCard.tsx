import { Restaurant } from "features";

type RestaurantProps = {
  restaurant: Restaurant;
};

function RestaurantCard({ restaurant }: Readonly<RestaurantProps>) {
  const time = Math.round((Math.random() * 20) / 5) * 5 + 20;

  return (
    <div className="m-5 flex h-[400px] transform cursor-pointer flex-col justify-between rounded-lg border border-gray-200 bg-white p-5 shadow-md transition duration-500 hover:scale-110">
      <div className="h-1/2 w-full overflow-hidden">
        <img className="h-full w-full rounded-lg object-cover" src={restaurant.imageUrl} alt="" />
      </div>
      <div className="flex flex-1 flex-col justify-between pt-5">
        <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-90">{restaurant.name}</h5>
        <p className="mb-3 font-normal text-gray-700">{restaurant.description}</p>
        <div className="mt-3 flex items-end justify-between">
          <p className="flex w-24 cursor-pointer flex-row items-center rounded-lg bg-cyan-700 px-3 py-2 text-center text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-blue-300">
            Order
            <svg className="ms-2 h-3.5 w-3.5 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 14 10">
              <path stroke="currentColor" strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M1 5h12m0 0L9 1m4 4L9 9" />
            </svg>
          </p>

          <p className="cursor-pointer justify-end rounded-lg bg-cyan-100 px-3 text-cyan-500">
            {time} - {time + 10} min
          </p>
        </div>
      </div>
    </div>
  );
}

export { RestaurantCard };
