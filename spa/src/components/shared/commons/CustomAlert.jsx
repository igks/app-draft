//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Alert component
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { Snackbar, Alert, Slide } from "@mui/material";
import { dismissAlert } from "../../../redux/actions/alert";

const CustomAlert = () => {
  const { isShow, type, message } = useSelector((state) => state.alert.content);
  const [isOpen, setIsOpen] = useState(false);
  const [autoHide, setAutoHide] = useState(0);
  const dispatch = useDispatch();

  useEffect(() => {
    if (isShow) {
      setIsOpen(true);
    } else {
      setIsOpen(false);
    }
    setAutoHide(3000);
  }, [isShow, type, message]);

  const handleClose = () => {
    setIsOpen(false);
    dispatch(dismissAlert());
  };

  function transition(props) {
    return <Slide {...props} direction="left" />;
  }

  return (
    <>
      {type !== "" && (
        <Snackbar
          open={isOpen}
          autoHideDuration={autoHide}
          onClose={handleClose}
          anchorOrigin={{ vertical: "top", horizontal: "right" }}
          TransitionComponent={transition}
        >
          <Alert onClose={handleClose} severity={type} sx={{ width: "100%" }}>
            {message}
          </Alert>
        </Snackbar>
      )}
    </>
  );
};

export default CustomAlert;
