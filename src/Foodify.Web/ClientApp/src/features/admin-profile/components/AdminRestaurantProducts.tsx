import { useQueryClient } from "@tanstack/react-query";
import clsx from "clsx";
import { useState } from "react";
import { useParams } from "react-router-dom";

import { AdminAddProductModal, useDeleteProduct, useRestaurant } from "features";

function AdminRestaurantProducts() {
  const { id } = useParams();
  const queryClient = useQueryClient();
  const [isModalOpen, setIsModalOpen] = useState(false);

  const restaurant = useRestaurant(id!);
  const deleteProductMutation = useDeleteProduct();

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  const handleDeleteProduct = (productId: string) => {
    if (window.confirm("Are you sure you want to delete this product?")) {
      deleteProductMutation.mutate(productId, {
        onSuccess: () => {
          queryClient.invalidateQueries({ queryKey: ["restaurant", id] });
        },
      });
    }
  };

  return (
    <div className="m-auto flex w-[80%] flex-col items-center justify-center align-middle">
      <h2 className="mb-4 text-xl font-semibold">Products</h2>

      <div className="my-4">
        <button onClick={toggleModal} className="rounded bg-green-500 p-2 text-white hover:bg-green-600">
          Add Product
        </button>
      </div>

      {restaurant.data?.products?.length === 0 ? (
        <div>
          <p>No products available</p>
          {isModalOpen && <AdminAddProductModal restaurantId={id!} onClose={() => setIsModalOpen(false)} />}
        </div>
      ) : (
        <div className="grid grid-cols-2 content-center items-center justify-center gap-10">
          {restaurant?.data?.products?.map(product => (
            <div
              key={product.id}
              className={clsx(
                "cursor-pointer flex-col items-center rounded-lg border border-gray-200 bg-white shadow hover:bg-gray-100 md:max-w-xl md:flex-row",
                !isModalOpen && "transition duration-200 ease-in-out hover:scale-105",
              )}
            >
              <div className="flex h-[150px] min-w-[570px]">
                <div className="flex flex-col justify-between p-4 leading-normal">
                  <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900">{product.name}</h5>
                  <p className="mb-3 font-normal text-gray-400">{product.description}</p>
                </div>

                <div className="flex w-full justify-end">
                  <img
                    className="h-96 rounded-t-lg object-cover md:h-auto md:w-48 md:rounded-none md:rounded-s-lg"
                    src={product.imageUrl}
                    alt=""
                  />
                </div>
              </div>

              <div className="flex p-5 align-bottom text-2xl font-bold text-blue-400">{product.price} €</div>

              <div className="flex justify-end">
                <button type="button" onClick={() => handleDeleteProduct(product.id)} className="rounded bg-red-500 p-2 text-white hover:bg-red-600">
                  Delete product
                </button>
              </div>
            </div>
          ))}

          {isModalOpen && <AdminAddProductModal restaurantId={id!} onClose={() => setIsModalOpen(false)} />}
        </div>
      )}
    </div>
  );
}

export { AdminRestaurantProducts };
