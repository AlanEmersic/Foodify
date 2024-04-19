import { Navigate } from "react-router-dom";

import { ROUTES } from "features";
import { useAuthStore } from "stores";

type ProtectedRouteProps = {
  children: React.ReactNode;
};

function ProtectedRoute({ children }: ProtectedRouteProps) {
  const { token } = useAuthStore();

  if (!token) {
    return <Navigate to={ROUTES.LOG_IN} replace />;
  }

  return <>{children}</>;
}

export { ProtectedRoute };
