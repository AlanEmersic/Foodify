import clsx from "clsx";
import { useEffect, useState } from "react";

import { CloseCircleIcon, MinusIcon, PlusIcon } from "assets";
import { Product } from "features";

type ProductModalProps = {
  product: Product;
  onClose: () => void;
  onAddToCart: (quantity: number) => void;
};

function ProductModal({ product, onClose, onAddToCart }: Readonly<ProductModalProps>) {
  const [quantity, setQuantity] = useState(1);
  const [isVisible, setIsVisible] = useState(true);

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

  const decreaseQuantity = () => {
    setQuantity(prevQuantity => (prevQuantity > 1 ? prevQuantity - 1 : 1));
  };

  const increaseQuantity = () => {
    setQuantity(prevQuantity => prevQuantity + 1);
  };

  const handleAddToCart = () => {
    onAddToCart(quantity);
    closeModal();
  };

  return (
    <div onClick={closeModal} className="fixed inset-0 z-40 flex items-center justify-center bg-black bg-opacity-50 p-4">
      <div
        onClick={handleModalContentClick}
        className={clsx(
          "relative w-[450px] rounded-2xl bg-white shadow-xl",
          isVisible && "modal-fade-in duration-250 translate-y-0 transition-transform ease-in",
          !isVisible && "modal-fade-out translate-y-full transform duration-150 ease-linear",
        )}
      >
        <button onClick={closeModal} className="absolute right-0 top-0 mr-4 mt-4">
          <CloseCircleIcon className="h-10 w-10 rounded-3xl bg-white text-gray-500 hover:bg-slate-200" />
        </button>

        <div className="m-auto flex flex-col items-center justify-center align-middle">
          <img className="mb-6 h-80 w-full rounded-t-2xl object-cover" src={product.imageUrl} alt=""></img>

          <h1 className="mb-4 text-center text-4xl font-extrabold leading-none tracking-tight text-gray-900">{product.name}</h1>

          <span className="max-w-[90%] rounded-2xl bg-gray-100 p-3 text-center text-lg font-semibold text-gray-500">{product.description}</span>

          <div className="w-full shadow-xl">
            <div className="flex items-center justify-between gap-5 p-4">
              <div className="flex min-w-36 justify-between rounded-xl bg-blue-400">
                <button onClick={decreaseQuantity} className="px-3 py-1">
                  <MinusIcon className="h-6 w-6 rounded-3xl bg-white fill-blue-400" />
                </button>

                <span className="px-3 py-1 text-white">{quantity}</span>

                <button onClick={increaseQuantity} className="px-3 py-1">
                  <PlusIcon className="h-6 w-6 rounded-3xl bg-white fill-blue-400" />
                </button>
              </div>

              <button onClick={handleAddToCart} className="rounded-xl bg-blue-500 px-6 py-2 text-white">
                Add to order {(product.price * quantity).toFixed(2)} €
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export { ProductModal };
