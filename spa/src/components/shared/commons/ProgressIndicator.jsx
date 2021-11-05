//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component for progress indicator, call when waiting of loading some data.
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { Stack, Box, Skeleton } from "@mui/material";
import { blue } from "@mui/material/colors";

const ProgressIndicator = () => {
  const customColor = blue[100];
  return (
    <Box sx={{ width: "100%" }}>
      <Stack spacing={1}>
        <Skeleton
          variant="rectangular"
          width="100%"
          height={80}
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="text"
          width="50%"
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="text"
          width="60%"
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="text"
          width="70%"
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="text"
          width="80%"
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="text"
          width="90%"
          sx={{ backgroundColor: customColor }}
        />
        <Skeleton
          variant="rectangular"
          width="100%"
          height={60}
          sx={{ backgroundColor: customColor }}
        />
      </Stack>
    </Box>
  );
};

export default ProgressIndicator;
