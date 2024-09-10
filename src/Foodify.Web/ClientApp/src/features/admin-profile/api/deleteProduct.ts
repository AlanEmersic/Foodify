import { useMutation } from "@tanstack/react-query";

import { axiosConfig } from "config";

const deleteProduct = async (id: string): Promise<void> => {
  const { data } = await axiosConfig.delete(`/api/products/${id}`);

  return data;
};

export function useDeleteProduct() {
  return useMutation({ mutationFn: deleteProduct });
}
