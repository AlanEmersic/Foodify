import "chart.js/auto";
import { Bar } from "react-chartjs-2";
import { useParams } from "react-router-dom";

import { useGetRestaurantSummary } from "features";

const options = {
  scales: {
    y: {
      beginAtZero: true,
      title: {
        display: true,
        text: "Quantity sold",
      },
    },
    x: {
      title: {
        display: true,
        text: "Year-Month",
      },
    },
  },
};

function AdminRestaurantSummary() {
  const { id } = useParams();

  const restaurantSummary = useGetRestaurantSummary(id!);

  if (restaurantSummary.isLoading || !restaurantSummary.data) {
    return <div className="m-auto flex justify-center">Loading...</div>;
  }

  return (
    <div className="grid-row-12 m-auto mt-10 grid w-[50%] gap-10 py-2">
      <h1 className="text-xl font-bold md:text-2xl">
        Restaurant <span className="text-teal-400">{restaurantSummary.data.name}</span>
      </h1>

      {restaurantSummary.data.summary.map(productSummary => (
        <div
          key={productSummary.id}
          className="mb-12 cursor-pointer border-t-2 border-teal-400 p-2 shadow-xl transition duration-500 hover:scale-110"
        >
          <h2 className="mb-4 text-xl font-bold">{productSummary.name} sales</h2>
          <h4 className="mb-4 text-base font-bold text-teal-700">ID: {productSummary.id}</h4>
          <h4 className="mb-4 text-base font-bold text-teal-700">Total quantity sold: {productSummary.totalQuantity}</h4>
          <Bar
            data={{
              labels: productSummary.sales.map(ms => ms.month),
              datasets: [
                {
                  label: "Quantity sold",
                  data: productSummary.sales.map(ms => ms.quantity),
                  borderColor: "rgba(75, 192, 192, 1)",
                  backgroundColor: "rgba(75, 192, 192, 0.2)",
                  borderWidth: 1,
                },
              ],
            }}
            options={options}
          />
        </div>
      ))}
    </div>
  );
}

export { AdminRestaurantSummary };
