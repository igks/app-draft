//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication reducer
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { LOGIN_SUCCESS, LOGOUT_SUCCESS } from "../actions/types";

const initialState = {
  account: {
    username: "",
  },
  isAuthenticated: false,
};

export default function auth(state = initialState, action) {
  const { type, payload } = action;

  switch (type) {
    case LOGIN_SUCCESS:
      return {
        ...state,
        account: payload,
        isAuthenticated: true,
      };

    case LOGOUT_SUCCESS:
      return {
        ...state,
        isAuthenticated: false,
      };
    default:
      return state;
  }
}
