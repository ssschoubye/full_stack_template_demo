import { type RouteConfig, index, route } from "@react-router/dev/routes";

export default [
  // Dashboard route
  index("routes/pages/Homepage/Homepage.tsx"),
  
  // Auth routes
  route("login", "routes/Auth/Login.tsx"),
  route("register", "routes/Auth/Register.tsx"),
  
  // Protected routes
  route("doctors", "routes/pages/Doctors.tsx"),
  route("doctor-types", "routes/pages/DoctorType.tsx"),
  route("shift-types", "routes/pages/ShiftType.tsx")
] satisfies RouteConfig;