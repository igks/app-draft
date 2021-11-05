//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component for give a space between a component.
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { Box } from "@mui/material";

const Spacer = ({ width = 0, height = 0 }) => {
  return <Box sx={{ width: width, height: height }} />;
};

export default Spacer;
