//===================================================
// Date         : 05 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Table header component submit button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import { Box, TableRow, TableCell } from "@mui/material";
import { ExpandLess, ExpandMore } from "@mui/icons-material";
import * as Colors from "../../../constants/colors";

const TableHeaders = (props) => {
  const { name, headers, orderBy, isDesc, onSortChange } = props;

  const handleSort = (value) => {
    const field = headers.find((obj) => obj.id === value);
    if (!field.isSortable) {
      return;
    }
    onSortChange(value);
  };

  return (
    <>
      <TableRow>
        {headers.length > 0 &&
          headers.map((headCell) => (
            <TableCell
              key={`${name}-${headCell.id}`}
              onClick={() => handleSort(headCell.id)}
              sx={{
                backgroundColor: Colors.primary,
                color: "white",
                fontSize: 18,
                fontWeight: "bold",
              }}
            >
              <Box display="flex" flexDirection="row">
                {headCell.label}
                {headCell.isSortable &&
                  (orderBy === headCell.id ? (
                    isDesc ? (
                      <ExpandLess />
                    ) : (
                      <ExpandMore />
                    )
                  ) : (
                    <ExpandMore />
                  ))}
              </Box>
            </TableCell>
          ))}
      </TableRow>
    </>
  );
};

export default TableHeaders;
