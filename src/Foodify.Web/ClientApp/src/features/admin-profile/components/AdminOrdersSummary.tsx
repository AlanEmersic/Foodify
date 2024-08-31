import "chart.js/auto";
import { Line } from "react-chartjs-2";

import { useUsersOrdersSummary } from "features";

function AdminOrdersSummary() {
  const userOrdersSummary = useUsersOrdersSummary();

  return (
    <div className="py-2">
      {userOrdersSummary?.data?.map(userSummary => (
        <div
          key={userSummary.userId}
          className="mb-12 cursor-pointer border-t-2 border-teal-400 p-2 shadow-xl transition duration-500 hover:scale-110"
        >
          <h2 className="mb-4 text-xl font-bold">
            <span className="text-teal-400">{userSummary.email}'s</span> monthly spending
            <div>
              Total amount spent <span className="text-teal-400">{userSummary.totalAmountSpent}</span>€
            </div>
          </h2>

          <Line
            data={{
              labels: userSummary.monthlySpendings.map(ms => ms.month),
              datasets: [
                {
                  label: "Amount spent (€)",
                  data: userSummary.monthlySpendings.map(ms => ms.totalSpent),
                  borderColor: "rgba(75, 192, 192, 1)",
                  backgroundColor: "rgba(75, 192, 192, 0.2)",
                  fill: true,
                },
              ],
            }}
            options={{
              scales: {
                y: {
                  beginAtZero: true,
                  title: {
                    display: true,
                    text: "Amount spent (€)",
                  },
                },
                x: {
                  title: {
                    display: true,
                    text: "Year-Month",
                  },
                },
              },
            }}
          />
        </div>
      ))}
    </div>
  );
}

export { AdminOrdersSummary };
