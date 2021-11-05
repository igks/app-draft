//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Alert reducer
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { SHOW_ALERT, DISMISS_ALERT } from "../actions/types";

const initialState = {
  content: {
    isShow: false,
    type: "",
    message: "",
  },
};

export default function alert(state = initialState, action) {
  const { type, payload } = action;

  switch (type) {
    case SHOW_ALERT:
      return {
        ...state,
        content: payload,
      };
    case DISMISS_ALERT:
      return {
        ...state,
        content: payload,
      };
    default:
      return state;
  }
}
