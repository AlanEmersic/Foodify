import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { Order } from "features";

const getOrder = async (id: string): Promise<Order> => {
  const { data } = await axiosConfig.get(`/api/orders/${id}`);

  return data;
};

export function useOrder(id: string) {
  return useQuery<Order>({
    queryKey: ["order"],
    queryFn: () => getOrder(id),
    refetchOnWindowFocus: false,
  });
}
