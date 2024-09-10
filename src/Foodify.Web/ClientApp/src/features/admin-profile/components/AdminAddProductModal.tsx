import { useQueryClient } from "@tanstack/react-query";
import clsx from "clsx";
import { useEffect, useState } from "react";

import { ProductCommand, useCreateProduct } from "features";

type AdminAddProductModalProps = {
  restaurantId: string;
  onClose: () => void;
};

function AdminAddProductModal({ restaurantId, onClose }: AdminAddProductModalProps) {
  const [product, setProduct] = useState<ProductCommand>({
    restaurantId,
    name: "",
    description: "",
    price: 0,
    imageUrl: "",
  });
  const [isVisible, setIsVisible] = useState(true);
  const queryClient = useQueryClient();

  const createProductMutation = useCreateProduct();

  useEffect(() => {
    document.body.style.overflow = "hidden";

    return () => {
      document.body.style.overflow = "unset";
    };
  }, []);

  const closeModal = () => {
    setIsVisible(false);
    setTimeout(
      () => {
        onClose();
      },
      isVisible ? 250 : 150,
    );
  };

  const handleModalContentClick = (e: React.MouseEvent) => {
    e.stopPropagation();
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.value,
    });
  };

  const handleCreateProduct = (e: React.FormEvent) => {
    e.preventDefault();

    createProductMutation.mutate(product, {
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ["restaurant", restaurantId] });
        onClose();
      },
    });

    closeModal();
  };

  return (
    <div className="fixed inset-0 z-40 flex items-center justify-center bg-black bg-opacity-50 p-4" onClick={closeModal}>
      <form
        onClick={handleModalContentClick}
        onSubmit={handleCreateProduct}
        className={clsx(
          "relative w-[450px] rounded-2xl bg-white p-4 shadow-xl",
          isVisible && "modal-fade-in duration-250 translate-y-0 transition-transform ease-in",
          !isVisible && "modal-fade-out translate-y-full transform duration-150 ease-linear",
        )}
      >
        <h2 className="mb-4 text-xl font-semibold">Add New Product</h2>
        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700">Name</label>
          <input
            type="text"
            name="name"
            value={product.name}
            onChange={handleChange}
            className="mt-1 w-full rounded border border-gray-300 p-2"
            required
          />
        </div>
        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700">Description</label>
          <textarea
            name="description"
            value={product.description}
            onChange={handleChange}
            className="mt-1 w-full rounded border border-gray-300 p-2"
            required
          />
        </div>
        <div className="mb-4">
          <label className="block text-sm font-medium text-gray-700">Price (€)</label>
          <input
            type="number"
            name="price"
            value={product.price}
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
            value={product.imageUrl}
            onChange={handleChange}
            className="mt-1 w-full rounded border border-gray-300 p-2"
            required
          />
        </div>
        <div className="flex justify-end">
          <button type="submit" className="rounded bg-blue-500 p-2 text-white hover:bg-blue-600">
            Add Product
          </button>
          <button type="button" className="ml-2 rounded bg-gray-300 p-2 text-gray-700 hover:bg-gray-400" onClick={onClose}>
            Cancel
          </button>
        </div>
      </form>
    </div>
  );
}

export { AdminAddProductModal };
