//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Private router component
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { Route, Redirect } from "react-router-dom";

const PrivateRoute = ({ component: Component, auth, ...rest }) => (
  <Route
    {...rest}
    render={(props) =>
      !auth ? <Redirect to="/login" /> : <Component {...props} />
    }
  />
);
export default PrivateRoute;
