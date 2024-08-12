import { create } from "zustand";

type AuthState = {
  email: string | null;
  token: string | null;
  isAdmin: boolean;
  login: (email: string, token: string) => void;
  logout: () => void;
};

const useAuthStore = create<AuthState>(set => ({
  email: null,
  token: null,
  isAdmin: false,
  login: (email, token) => set({ email, token }),
  logout: () => set({ email: null, token: null }),
}));

export { useAuthStore };
