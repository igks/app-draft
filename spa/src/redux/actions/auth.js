//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication action
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { LOGIN_SUCCESS, LOGOUT_SUCCESS } from "./types";

export const loginSuccess = (payload) => (dispatch) => {
  dispatch({
    type: LOGIN_SUCCESS,
    payload: payload,
  });
};

export const logoutSuccess = () => (dispatch) => {
  dispatch({
    type: LOGOUT_SUCCESS,
  });
};
