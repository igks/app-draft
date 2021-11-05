//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Navigation router
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { useSelector } from "react-redux";
import { Switch } from "react-router-dom";
import { Box } from "@mui/material";
import PrivateRoute from "./PrivateRoute";
import Dashboard from "../pages/main/Dashboard";

const NavigationRoute = () => {
  const isAuthenticated = useSelector((state) => state.auth.isAuthenticated);
  const containerHeigh = window.innerHeight - 120 - 80;

  return (
    <>
      <Box
        sx={{
          height: containerHeigh,
          overflow: "scroll",
          position: "relative",
        }}
      >
        <Switch>
          <PrivateRoute
            exact
            path="/dashboard"
            component={Dashboard}
            auth={isAuthenticated}
          />
        </Switch>
      </Box>
    </>
  );
};

export default NavigationRoute;
