import { useQueryClient } from "@tanstack/react-query";
import clsx from "clsx";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

import { RestaurantCommand, ROUTES, useCreateRestaurant } from "features";

function AdminCreateRestaurant() {
  const navigate = useNavigate();
  const [restaurant, setRestaurant] = useState<RestaurantCommand>({
    name: "",
    description: "",
    address: "",
    email: "",
    imageUrl: "",
  });
  const queryClient = useQueryClient();

  const createRestaurantMutation = useCreateRestaurant();

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setRestaurant({
      ...restaurant,
      [e.target.name]: e.target.value,
    });
  };

  const handleCreateRestaurant = (e: React.FormEvent) => {
    e.preventDefault();

    createRestaurantMutation.mutate(restaurant, {
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ["restaurants"] });
        navigate(ROUTES.ADMIN_PROFILE);
      },
    });
  };

  return (
    <form onSubmit={handleCreateRestaurant} className="m-auto mt-4 flex w-[50%] flex-col items-center rounded bg-white p-4 shadow-md">
      <h2 className="mb-4 text-xl font-semibold">Create new restaurant</h2>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Name</label>
        <input
          type="text"
          name="name"
          value={restaurant.name}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Description</label>
        <textarea
          name="description"
          value={restaurant.description}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Address</label>
        <input
          type="text"
          name="address"
          value={restaurant.address}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Email</label>
        <input
          type="email"
          name="email"
          value={restaurant.email}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Image URL</label>
        <input
          type="url"
          name="imageUrl"
          value={restaurant.imageUrl}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <button
        type="submit"
        className={clsx(
          "rounded-lg px-5 py-2.5 text-center text-lg font-medium text-white",
          !createRestaurantMutation.isPending &&
            restaurant.name &&
            restaurant.description &&
            restaurant.address &&
            restaurant.email &&
            restaurant.imageUrl &&
            "bg-blue-500",
          !createRestaurantMutation.isPending &&
            (!restaurant.name || !restaurant.description || !restaurant.address || !restaurant.email || !restaurant.imageUrl) &&
            "bg-gray-400",
        )}
        disabled={
          createRestaurantMutation.isPending ||
          !restaurant.name ||
          !restaurant.description ||
          !restaurant.address ||
          !restaurant.email ||
          !restaurant.imageUrl
        }
      >
        Create restaurant
      </button>
    </form>
  );
}

export { AdminCreateRestaurant };
