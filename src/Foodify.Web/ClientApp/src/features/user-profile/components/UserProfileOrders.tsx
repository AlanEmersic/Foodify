import { useNavigate } from "react-router-dom";

import { DateDeliveredIcon, DateOrderedIcon, StatusIcon, TotalPriceIcon } from "assets";
import { Order, ROUTES } from "features";

type UserProfileOrdersProps = {
  orders: Order[];
};

function UserProfileOrders({ orders }: Readonly<UserProfileOrdersProps>) {
  const navigate = useNavigate();

  const handleOnOrderDetailsClick = (id: string) => {
    navigate(`${ROUTES.ORDER_DETAILS.replace(":id", id)}`);
  };

  return (
    <div className="text-lg">
      <h2 className="text-2xl font-semibold">Orders</h2>
      {orders.length === 0 && <p>No orders found.</p>}

      {orders.map(order => (
        <div key={order.id} className="my-5 rounded-lg border-blue-500 bg-slate-100 hover:bg-slate-200 p-4">
          <p className="flex flex-row items-center gap-1">
            <DateOrderedIcon className="h-6 w-6" />
            <span className="font-semibold">Ordered:</span> <span className="text-black">{new Date(order.placedTime).toLocaleString()}</span>
          </p>
          {order.completedTime && (
            <p className="flex flex-row items-center gap-1">
              <DateDeliveredIcon className="h-6 w-6" />
              <span className="font-semibold">Delivered:</span> <span className="text-black">{new Date(order.completedTime).toLocaleString()}</span>
            </p>
          )}
          <p className="flex flex-row items-center gap-1">
            <TotalPriceIcon className="h-6 w-6" />
            <span className="font-semibold">Total price:</span> <span className="text-black">{order.totalPrice} €</span>
          </p>
          <p className="flex flex-row items-center gap-1">
            <StatusIcon className="h-6 w-6" />
            <span className="font-semibold">Status:</span> <span className="text-black">{order.status}</span>
          </p>

          <button
            onClick={() => handleOnOrderDetailsClick(order.id)}
            className="pt-2 block cursor-pointer font-semibold text-blue-400 hover:text-blue-700"
          >
            View details
          </button>
        </div>
      ))}
    </div>
  );
}

export { UserProfileOrders };
