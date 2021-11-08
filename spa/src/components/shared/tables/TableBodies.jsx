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
import { DeleteForever, Edit } from "@mui/icons-material";
import Spacer from "../commons/Spacer";

const TableBodies = (props) => {
  const { name, records, hiddenField, onUpdate, onDelete } = props;
  return (
    <>
      {records.map((row, index) => (
        <TableRow key={`${name}-${index}`}>
          {Object.keys(row).map(
            (key) =>
              !hiddenField.includes(key.toLowerCase()) && (
                <TableCell
                  key={`${name}-${key}-${index}`}
                  sx={{ whiteSpace: "nowrap" }}
                >
                  {row[key]}
                </TableCell>
              )
          )}
          <TableCell>
            <Box display="flex" flexDirection="row">
              <Edit
                color="info"
                onClick={() => {
                  onUpdate(row.id);
                }}
              />
              <Spacer width={15} height={0} />
              <DeleteForever
                color="error"
                onClick={() => {
                  onDelete(row.id);
                }}
              />
            </Box>
          </TableCell>
        </TableRow>
      ))}
    </>
  );
};

export default TableBodies;
