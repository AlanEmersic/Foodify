import { useQueryClient } from "@tanstack/react-query";
import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

import { ROUTES, useDeleteRestaurant, useRestaurant } from "features";

function AdminEditRestaurant() {
  const { id } = useParams();
  const queryClient = useQueryClient();
  const navigate = useNavigate();

  const restaurant = useRestaurant(id!);
  const deleteRestaurantMutation = useDeleteRestaurant();

  const [updatedRestaurant, setUpdatedRestaurant] = useState({
    name: restaurant?.data?.name,
    description: restaurant?.data?.description,
    address: restaurant?.data?.address,
    email: restaurant?.data?.email,
    imageUrl: restaurant?.data?.imageUrl,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setUpdatedRestaurant({
      ...updatedRestaurant,
      [e.target.name]: e.target.value,
    });
  };

  const handleDeleteRestaurant = () => {
    if (window.confirm("Are you sure you want to delete this restaurant?")) {
      deleteRestaurantMutation.mutate(id!, {
        onSuccess: () => {
          queryClient.invalidateQueries({ queryKey: ["restaurants"] });
          navigate(ROUTES.ADMIN_PROFILE);
        },
      });
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
  };

  if (restaurant.isLoading || !restaurant.data) {
    return <div className="m-auto flex justify-center">Loading...</div>;
  }

  return (
    <form onSubmit={handleSubmit} className="m-auto mt-4 flex w-[50%] flex-col items-center rounded bg-white p-4 shadow-md">
      <h2 className="mb-4 text-xl font-semibold">Edit restaurant</h2>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Name</label>
        <input
          type="text"
          name="name"
          value={updatedRestaurant.name}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="mb-4">
        <label className="block text-sm font-medium text-gray-700">Description</label>
        <textarea
          name="description"
          value={updatedRestaurant.description}
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
          value={updatedRestaurant.address}
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
          value={updatedRestaurant.email}
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
          value={updatedRestaurant.imageUrl}
          onChange={handleChange}
          className="mt-1 w-full rounded border border-gray-300 p-2"
          required
        />
      </div>

      <div className="flex justify-between gap-8">
        <button type="submit" className="rounded bg-blue-500 p-2 text-white hover:bg-blue-600">
          Update restaurant
        </button>
        <button type="button" onClick={handleDeleteRestaurant} className="rounded bg-red-500 p-2 text-white hover:bg-red-600">
          Delete restaurant
        </button>
      </div>
    </form>
  );
}

export { AdminEditRestaurant };
