import { useNavigate } from "react-router-dom";

import { ROUTES, useCreateOrder } from "features";
import { useCartStore } from "stores";
import { MinusIcon, PlusIcon } from "assets";

function CartDetails() {
  const navigate = useNavigate();

  const createOrderMutation = useCreateOrder();
  const cart = useCartStore();

  const handleCheckout = () => {
    createOrderMutation.mutate(
      { orderItems: cart.items },
      {
        onSuccess() {
          cart.clearCart();
          navigate(ROUTES.HOME);
        },
      },
    );
  };

  return (
    <div className="m-auto flex w-[80%] flex-col items-center">
      <h1 className="text-2xl font-extrabold">Cart</h1>
      <div>
        {cart.items.length !== 0 && <h3 className="text-xl font-semibold">Items</h3>}
        {cart.items.map(item => (
          <div className="mt-4" key={item.productId}>
            <div key={item.productId} className="my-2 rounded-lg border bg-slate-50 p-3 hover:bg-slate-100">
              <img src={item.product.imageUrl} alt={item.product.name} className="float-left mr-4 max-w-[200px] object-cover" />
              <p>
                <strong>Product:</strong> {item.product.name}
              </p>
              <p>
                <strong>Quantity:</strong> {item.quantity}
              </p>
              <p>
                <strong>Price per item:</strong> {item.price.toFixed(2)} €
              </p>
              <p>
                <strong>Description:</strong> {item.product.description}
              </p>

              <div className="mt-2 flex justify-end gap-4">
                <button
                  onClick={() => cart.updateItem(item.productId, item.quantity - 1)}
                  className="rounded bg-blue-200 px-4 py-2 font-bold text-white hover:bg-blue-300"
                >
                  <MinusIcon className="h-6 w-6 fill-blue-500" />
                </button>
                <button
                  onClick={() => cart.updateItem(item.productId, item.quantity + 1)}
                  className="rounded bg-blue-200 px-4 py-2 font-bold text-white hover:bg-blue-300"
                >
                  <PlusIcon className="h-6 w-6 fill-blue-500" />
                </button>
                <button
                  onClick={() => cart.removeItem(item.productId)}
                  className="rounded bg-red-200 px-4 py-2 font-bold text-red-500 hover:bg-red-300"
                >
                  Remove
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>

      {cart.items.length === 0 && <p className="text-xl">Your cart is empty.</p>}

      {cart.items.length !== 0 && (
        <>
          <div className="mt-4">
            <p className="text-xl font-semibold">
              <strong>Total price:</strong> {cart.items.reduce((acc, item) => acc + item.price * item.quantity, 0).toFixed(2)} €
            </p>
          </div>

          <div className="flex mx-auto justify-end gap-10 w-[40%]">
            <button onClick={handleCheckout} className="my-4 rounded-md bg-blue-100 px-2 py-1 text-center text-xl text-blue-500 md:hover:bg-blue-200">
              Checkout
            </button>

            <button onClick={cart.clearCart} className="my-4 rounded-md bg-red-100 px-2 py-1 text-center text-xl text-red-500 md:hover:bg-red-200">
              Clear Cart
            </button>
          </div>
        </>
      )}
    </div>
  );
}

export { CartDetails };
