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
import { TableRow, TablePagination } from "@mui/material";
import PaginationComponent from "./PaginationComponent";

const TablePaginations = (props) => {
  const { totalItems, pageSize, page, onPageChange, onRowPerPageChange } =
    props;

  return (
    <TableRow>
      <TablePagination
        rowsPerPageOptions={[5, 10, 25, 50, 100]}
        count={totalItems}
        rowsPerPage={pageSize}
        page={page - 1}
        SelectProps={{
          inputProps: {
            "aria-label": "rows per page",
          },
          native: true,
        }}
        onPageChange={onPageChange}
        onRowsPerPageChange={onRowPerPageChange}
        ActionsComponent={PaginationComponent}
      />
    </TableRow>
  );
};

export default TablePaginations;
