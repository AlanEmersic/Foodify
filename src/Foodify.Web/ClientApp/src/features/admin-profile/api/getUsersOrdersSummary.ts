import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { UserOrdersSummary } from "features";

const getUsersOrdersSummary = async (): Promise<UserOrdersSummary[]> => {
  const { data } = await axiosConfig.get("/api/orders/summary");

  return data;
};

export function useUsersOrdersSummary() {
  return useQuery<UserOrdersSummary[]>({
    queryKey: ["usersOrdersSummary"],
    queryFn: () => getUsersOrdersSummary(),
    refetchOnWindowFocus: false,
  });
}
