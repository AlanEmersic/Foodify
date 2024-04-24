import { useParams } from "react-router-dom";

import { useOrder } from "features";

function OrderDetails() {
  const { id } = useParams();
  const order = useOrder(id!);

  return (
    <>
      {order.isFetching && <p>Loading...</p>}

      {order.data && (
        <div className="mx-auto max-w-4xl p-5">
          <h2 className="text-2xl font-bold">Order Details</h2>
          <div className="my-4">
            <p>
              <strong>Order ID:</strong> {order.data.id}
            </p>
            <p>
              <strong>Status:</strong> {order.data.status}
            </p>
            <p>
              <strong>Placed:</strong> {new Date(order.data.placedTime).toLocaleString()}
            </p>
            <p>
              <strong>Completed:</strong> {new Date(order.data.completedTime!).toLocaleString()}
            </p>
            <p>
              <strong>Total Price:</strong> {order.data.totalPrice.toFixed(2)} €
            </p>

            <button className="mt-4 rounded bg-blue-500 px-4 py-2 font-bold text-white hover:bg-blue-700" onClick={() => window.history.back()}>
              Back to user profile
            </button>
          </div>

          <div className="mt-4">
            <h3 className="text-xl font-semibold">Items</h3>
            {order.data.orderItems!.map(item => (
              <div key={item.id} className="my-2 rounded-lg border bg-slate-50 p-3 hover:bg-slate-100">
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
              </div>
            ))}
          </div>
        </div>
      )}
    </>
  );
}

export { OrderDetails };
