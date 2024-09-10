import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { Restaurant } from "features";

const getRestaurant = async (id: string): Promise<Restaurant> => {
  const { data } = await axiosConfig.get(`/api/restaurants/${id}`);

  return data;
};

export function useRestaurant(id: string) {
  return useQuery<Restaurant>({
    queryKey: ["restaurant", id],
    queryFn: () => getRestaurant(id),
    refetchOnWindowFocus: false,
  });
}
