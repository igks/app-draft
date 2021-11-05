//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Alert action
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { SHOW_ALERT, DISMISS_ALERT } from "./types";

export const showAlert = (type, message) => (dispatch) => {
  dispatch({
    type: SHOW_ALERT,
    payload: {
      isShow: true,
      type: type,
      message: message,
    },
  });
};

export const dismissAlert = () => (dispatch) => {
  dispatch({
    type: DISMISS_ALERT,
    payload: {
      isShow: false,
      type: "",
      message: "",
    },
  });
};
