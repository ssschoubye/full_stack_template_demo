// components/RequireAuth.tsx
import { useContext } from "react";
import type { ReactNode } from "react";
import { Navigate } from "react-router-dom";
import AuthContext from "../contexts/AuthContext";
import type { AuthContextType } from "../contexts/AuthContext";

export default function RequireAuth({ children }: { children: ReactNode }) {
  const auth = useContext(AuthContext) as AuthContextType;

  if (auth.loading) {
    return <div>Loading...</div>;
  }

  if (!auth.user) {
    // Redirect to login if not authenticated
    return <Navigate to="/login" replace />;
  }

  return <>{children}</>;
}

