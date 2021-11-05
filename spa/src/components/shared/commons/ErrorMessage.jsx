//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component to show error message.
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { Typography } from "@mui/material";

const ErrorMessage = ({ message }) => {
  return (
    <Typography variant="body1" sx={{ color: "red", margin: 0, padding: 0 }}>
      <small>{message}</small>
    </Typography>
  );
};

export default ErrorMessage;
