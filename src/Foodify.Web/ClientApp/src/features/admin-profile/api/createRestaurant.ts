import { useMutation } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { RestaurantCommand } from "features";

const createRestaurant = async (command: RestaurantCommand): Promise<void> => {
  const { data } = await axiosConfig.post(`/api/restaurants`, command);

  return data;
};

export function useCreateRestaurant() {
  return useMutation({ mutationFn: createRestaurant });
}
