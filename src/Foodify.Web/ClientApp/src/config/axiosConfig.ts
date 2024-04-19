import axios, { AxiosRequestConfig } from "axios";

import { useAuthStore } from "stores";

const API_URL: string = "https://localhost:7024";

const defaultOptions = {
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
};

const instance = axios.create(defaultOptions);

instance.interceptors.request.use(
  (config: AxiosRequestConfig) => {
    const { token } = useAuthStore.getState();

    if (token) {
      config.headers = { ...config.headers, Authorization: `Bearer ${token}` };
    }

    return config;
  },
  error => {
    return Promise.reject(error);
  },
);

export { instance as axiosConfig };
