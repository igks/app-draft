//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component for confirmation dialog, call when confirmation needed from user to execute any action.
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import {
  Box,
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
} from "@mui/material";
import { InfoOutlined } from "@mui/icons-material";

const ConfirmationDialog = ({ isOpen, onCancel, onConfirm, message }) => {
  return (
    <>
      <Dialog open={isOpen} onClose={onCancel}>
        <Box
          container
          display="flex"
          flexDirection="row"
          justifyContent="space-around"
          alignItems="center"
        >
          <DialogTitle>Action Confirmation</DialogTitle>
          <InfoOutlined color="error" sx={{ fontSize: 35 }} />
        </Box>
        <DialogContent>
          <DialogContentText>{message}</DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button variant="outlined" color="error" onClick={onCancel}>
            Cancel
          </Button>
          <Button variant="contained" color="primary" onClick={onConfirm}>
            Confirm
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default ConfirmationDialog;
