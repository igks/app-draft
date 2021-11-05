//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component for warning dialog, call when need to show a warning to user.
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
} from "@mui/material";
import { WarningAmber } from "@mui/icons-material";

const WarningDialog = ({ isOpen, onCancel, onConfirm, message }) => {
  return (
    <>
      <Dialog open={isOpen} onClose={onCancel}>
        <DialogContent>
          <Box
            display="flex"
            flexDirection="row"
            justifyContent="center"
            alignItems="center"
          >
            <WarningAmber color="warning" sx={{ fontSize: 60 }} />
          </Box>
          <DialogContentText>{message}</DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button variant="contained" color="primary" onClick={onConfirm}>
            Confirm
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
};

export default WarningDialog;
