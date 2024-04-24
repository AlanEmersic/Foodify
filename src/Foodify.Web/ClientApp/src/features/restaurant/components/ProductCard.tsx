import clsx from "clsx";
import { useState } from "react";

import { Product, ProductModal } from "features";
import { useCartStore } from "stores";

type ProductCardProps = {
  product: Product;
};

function ProductCard({ product }: Readonly<ProductCardProps>) {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const cart = useCartStore();

  const toggleModal = () => {
    setIsModalOpen(!isModalOpen);
  };

  const handleAddToCart = (quantity: number) => {
    if (cart.items.some(item => item.productId === product.id)) {
      cart.updateItem(product.id, quantity);
    } else {
      cart.addItem({ productId: product.id, quantity: quantity, price: product.price, product: product });
    }
  };

  return (
    <div
      className={clsx(
        "cursor-pointer flex-col items-center rounded-lg border border-gray-200 bg-white shadow hover:bg-gray-100 md:max-w-xl md:flex-row",
        !isModalOpen && "transition duration-200 ease-in-out hover:scale-105",
      )}
    >
      <div onClick={toggleModal} className="flex h-[150px]">
        <div className="flex flex-col justify-between p-4 leading-normal">
          <h5 className="mb-2 text-2xl font-bold tracking-tight text-gray-900">{product.name}</h5>
          <p className="mb-3 font-normal text-gray-400">{product.description}</p>
        </div>

        <img className="h-96 w-full rounded-t-lg object-cover md:h-auto md:w-48 md:rounded-none md:rounded-s-lg" src={product.imageUrl} alt="" />
      </div>

      <div className="flex p-5 align-bottom text-2xl font-bold text-blue-400">{product.price} €</div>

      {isModalOpen && (
        <ProductModal
          product={product}
          onClose={() => setIsModalOpen(false)}
          onAddToCart={handleAddToCart}
          addedProductQuantity={cart.items.find(item => item.productId === product.id)?.quantity}
        />
      )}
    </div>
  );
}

export { ProductCard };
