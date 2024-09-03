// PublicRoute.js
import React, { useContext } from "react";
import { Navigate } from "react-router-dom";
import { AuthContext } from "./AuthContext";

const PublicRoute = ({ element: Component, ...rest }) => {
  const { isAuthenticated } = useContext(AuthContext);

  return isAuthenticated ? <Navigate to="/database" /> : <Component {...rest} />;
};

export default PublicRoute;
