//===================================================
// Date         :
// Author       : I Gusti Kade Sugiantara
// Description  :
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React, { useState, useEffect } from "react";
import { useHistory } from "react-router-dom";
import { Button } from "@mui/material";
import Spacer from "../../components/shared/commons/Spacer";
import TableList from "../../components/shared/tables";
import { getPage } from "../../services/master-service";

const MasterList = () => {
  const history = useHistory();

  const [masters, setMaster] = useState([]);
  const [isDesc, setIsDesc] = useState(false);
  const [orderBy, setOrderBy] = useState("masterProperty1");
  const [totalItems, setTotalItems] = useState(0);
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);

  const headers = [
    { id: "masterproperty1", label: "Content 1", isSortable: true },
    { id: "masterproperty2", label: "Content 2", isSortable: true },
    { id: "option", label: "Options", isSortable: false },
  ];
  const loadMaster = async () => {
    let params = {
      search: "",
      pageNumber: page,
      pageSize: pageSize,
      orderBy: orderBy,
      isDescending: isDesc,
    };

    const response = await getPage(params);
    if (response.success) {
      const pagination = JSON.parse(response.pagination);
      const masters = response.data;
      setMaster(masters);
      updatePagination(pagination);
    }
  };

  const sortHandler = (value) => {
    if (orderBy === value) {
      isDesc ? setIsDesc(false) : setIsDesc(true);
    } else {
      setOrderBy(value);
      setIsDesc(false);
    }
  };

  const onPageChange = (newPage) => {
    setPage(newPage + 1);
  };

  const onRowPerPageChange = (event) => {
    setPageSize(parseInt(event.target.value));
  };

  const updatePagination = (pagination) => {
    setTotalItems(pagination.totalItems);
    setPage(pagination.currentPage);
    setPageSize(pagination.pageSize);
  };

  const onAddRecord = () => {
    history.push("/master-form");
  };

  const onUpdateRecord = (id) => {
    history.push("/master-form", { id: id });
  };

  useEffect(() => {
    loadMaster();
    // eslint-disable-next-line
  }, [page, pageSize, orderBy, isDesc]);

  const tableHeader = {
    headers: headers,
    orderBy: orderBy,
    isDesc: isDesc,
    onSortChange: sortHandler,
  };

  const tableBody = {
    records: masters,
    hiddenField: ["id", "details", "commons"],
    onUpdate: (id) => onUpdateRecord(id),
    onDelete: (value) => console.log(value),
  };

  const tableFooter = {
    totalItems: totalItems,
    pageSize: pageSize,
    page: page,
    onPageChange: onPageChange,
    onRowPerPageChange: onRowPerPageChange,
  };

  return (
    <>
      <Button variant="outlined" onClick={onAddRecord}>
        Add Record
      </Button>
      <Spacer height={10} />
      <TableList
        name="master"
        tableHeader={tableHeader}
        tableBody={tableBody}
        tableFooter={tableFooter}
      />
    </>
  );
};

export default MasterList;
