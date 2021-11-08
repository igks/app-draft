//===================================================
// Date         : 05 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Pagination component submit button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import {
  ChevronLeft,
  ChevronRight,
  FirstPage,
  LastPage,
} from "@mui/icons-material";
import { Box, IconButton } from "@mui/material";

const PaginationComponent = (props) => {
  const { count, page, rowsPerPage, onPageChange } = props;

  const firstClicked = () => {
    onPageChange(0);
  };

  const previousClicked = () => {
    onPageChange(page - 1);
  };

  const nextClicked = () => {
    onPageChange(page + 1);
  };

  const lastClicked = () => {
    onPageChange(Math.max(0, Math.ceil(count / rowsPerPage) - 1));
  };

  return (
    <Box display="flex" sx={{ marginLeft: 5 }}>
      <IconButton onClick={firstClicked} disabled={page === 0}>
        <FirstPage />
      </IconButton>
      <IconButton onClick={previousClicked} disabled={page === 0}>
        <ChevronLeft />
      </IconButton>
      <IconButton
        onClick={nextClicked}
        disabled={page >= Math.ceil(count / rowsPerPage) - 1}
      >
        <ChevronRight />
      </IconButton>
      <IconButton
        onClick={lastClicked}
        disabled={page >= Math.ceil(count / rowsPerPage) - 1}
      >
        <LastPage />
      </IconButton>
    </Box>
  );
};

export default PaginationComponent;
