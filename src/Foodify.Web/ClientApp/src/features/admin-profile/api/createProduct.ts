import { useMutation } from "@tanstack/react-query";

import { axiosConfig } from "config";
import { ProductCommand } from "features";

const createProduct = async (command: ProductCommand): Promise<void> => {
  const { data } = await axiosConfig.post(`/api/products`, command);

  return data;
};

export function useCreateProduct() {
  return useMutation({ mutationFn: createProduct });
}
