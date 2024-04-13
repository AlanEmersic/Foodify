import { useParams } from "react-router-dom";

import { ProductCard, useRestaurant } from "features";

function RestaurantDetails() {
  const { id } = useParams();
  const restaurant = useRestaurant(id!);

  return (
    <div className="m-auto flex w-[80%] flex-col items-center justify-center align-middle">
      <img className="mb-6 h-80 w-full rounded-lg object-cover" src={restaurant?.data?.imageUrl} alt=""></img>

      <h1 className="mb-4  text-center text-4xl font-extrabold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-6xl">
        {restaurant?.data?.name}
      </h1>

      <p className="mb-6 text-lg font-normal text-gray-500 sm:px-16 lg:text-xl xl:px-48">{restaurant?.data?.description}</p>

      <div className="grid grid-cols-2 content-center items-center justify-center gap-10">
        {restaurant?.data?.products?.map(product => <ProductCard key={product.id} product={product} />)}
      </div>
    </div>
  );
}

export { RestaurantDetails };
