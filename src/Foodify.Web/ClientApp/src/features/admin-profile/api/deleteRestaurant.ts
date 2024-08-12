import { useMutation } from "@tanstack/react-query";

import { axiosConfig } from "config";

const deleteRestaurant = async (id: string): Promise<void> => {
  const { data } = await axiosConfig.delete(`/api/restaurants/${id}`);

  return data;
};

export function useDeleteRestaurant() {
  return useMutation({ mutationFn: deleteRestaurant });
}
