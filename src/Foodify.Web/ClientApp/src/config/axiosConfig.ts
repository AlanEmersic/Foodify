import axios, { InternalAxiosRequestConfig } from "axios";

const API_URL: string = "https://localhost:7024";

const defaultOptions = {
  baseURL: API_URL,
  headers: {
    "Content-Type": "application/json",
  },
};

const instance = axios.create(defaultOptions);

instance.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    return config;
  },
  error => {
    return Promise.reject(error);
  },
);

export { instance as axiosConfig };
