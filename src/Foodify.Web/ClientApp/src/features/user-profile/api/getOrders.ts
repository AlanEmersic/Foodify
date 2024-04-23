import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { Order } from "features";

const getOrders = async (): Promise<Order[]> => {
  const { data } = await axiosConfig.get("/api/orders");

  return data;
};

export function useOrders() {
  return useQuery<Order[]>({
    queryKey: ["orders"],
    queryFn: () => getOrders(),
    refetchOnWindowFocus: false,
  });
}
