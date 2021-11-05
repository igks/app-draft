//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component submit button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import {
  Button,
  Box,
  CircularProgress,
  Typography,
  Stack,
} from "@mui/material";

const SubmitButton = ({
  text,
  icon,
  color,
  variant = "contained",
  height = 40,
  action = () => {},
  isSubmit = false,
  showLoadingText = true,
}) => {
  return (
    <>
      {!isSubmit ? (
        <Button
          sx={{ width: "100%", height: height }}
          variant={variant}
          startIcon={icon}
          color={color}
          onClick={action}
        >
          {text}
        </Button>
      ) : (
        <Box
          display="flex"
          flexDirection="row"
          justifyContent="center"
          alignItems="center"
          sx={{
            width: "100%",
            height: height,
            border: "1px solid grey",
            borderRadius: 1,
            backgroundColor: "grey.500",
          }}
        >
          <Stack sx={{ color: "white" }}>
            <CircularProgress color="inherit" size={height * 0.6} />
          </Stack>
          {showLoadingText && (
            <Typography
              sx={{ marginLeft: 3, color: "white", fontWeight: "bold" }}
            >
              Submitting...
            </Typography>
          )}
        </Box>
      )}
    </>
  );
};

export default SubmitButton;
