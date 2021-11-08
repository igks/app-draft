//===================================================
// Date         : 05 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Table list component submit button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import {
  Paper,
  TableContainer,
  Table,
  TableHead,
  TableBody,
  TableFooter,
} from "@mui/material";
import TableHeader from "./TableHeaders";
import TableBodies from "./TableBodies";
import TablePaginations from "./TablePaginations";

const TableList = (props) => {
  const { name } = props.name;
  const { headers, orderBy, isDesc, onSortChange } = props.tableHeader;
  const { records, hiddenField, onUpdate, onDelete } = props.tableBody;
  const { totalItems, pageSize, page, onPageChange, onRowPerPageChange } =
    props.tableFooter;

  return (
    <>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableHeader
              name={name}
              headers={headers}
              orderBy={orderBy}
              isDesc={isDesc}
              onSortChange={onSortChange}
            />
          </TableHead>

          <TableBody>
            <TableBodies
              name={name}
              records={records}
              hiddenField={hiddenField}
              onUpdate={onUpdate}
              onDelete={onDelete}
            />
          </TableBody>

          <TableFooter>
            <TablePaginations
              totalItems={totalItems}
              pageSize={pageSize}
              page={page}
              onPageChange={onPageChange}
              onRowPerPageChange={onRowPerPageChange}
            />
          </TableFooter>
        </Table>
      </TableContainer>
    </>
  );
};

export default TableList;
