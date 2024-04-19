import { Navigate, Outlet } from "react-router-dom";

import { ROUTES } from "features";
import { useAuthStore } from "stores";

function ProtectedRoute() {
  const { token } = useAuthStore();

  if (!token) {
    return <Navigate to={ROUTES.LOG_IN} replace />;
  }

  return <Outlet />;
}

export { ProtectedRoute };
