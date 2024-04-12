import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { Restaurant } from "features";

const getRestaurants = async (): Promise<Restaurant[]> => {
  const { data } = await axiosConfig.get("/api/restaurants");

  return data;
};

export function useRestaurants() {
  return useQuery<Restaurant[]>({
    queryKey: ["restaurants"],
    queryFn: () => getRestaurants(),
    refetchOnWindowFocus: false,
  });
}
