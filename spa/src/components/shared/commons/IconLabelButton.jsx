//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component icon label button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import Button from "@mui/material/Button";

const IconLabelButton = ({
  text,
  icon,
  color,
  variant = "contained",
  height = 40,
  action = () => {},
}) => {
  return (
    <>
      <Button
        sx={{ width: "100%", height: height }}
        variant={variant}
        startIcon={icon}
        color={color}
        onClick={action}
      >
        {text}
      </Button>
    </>
  );
};

export default IconLabelButton;
