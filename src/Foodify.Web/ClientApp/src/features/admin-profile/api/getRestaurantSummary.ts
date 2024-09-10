import { useQuery } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { RestaurantSummary } from "features";

const getRestaurantSummary = async (id: string): Promise<RestaurantSummary> => {
  const { data } = await axiosConfig.get(`/api/restaurants/${id}/summary`);

  return data;
};

export function useGetRestaurantSummary(id: string) {
  return useQuery<RestaurantSummary>({
    queryKey: ["restaurantSummary", id],
    queryFn: () => getRestaurantSummary(id),
    refetchOnWindowFocus: false,
  });
}
