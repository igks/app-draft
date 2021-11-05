//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : index reducer, combine all reducer in one root
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import { combineReducers } from "redux";
import auth from "./auth";
import alert from "./alert";

export default combineReducers({
  auth,
  alert,
});
