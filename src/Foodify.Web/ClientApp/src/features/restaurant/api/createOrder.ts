import { useMutation } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { OrderCommand } from "features";

const createOrder = async (command: OrderCommand): Promise<void> => {
  const { data } = await axiosConfig.post(`/api/orders`, command);

  return data;
};

export function useCreateOrder() {
  return useMutation({ mutationFn: createOrder });
}
