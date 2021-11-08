//===================================================
// Date         : 05 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Shared component submit button
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import React from "react";
import SpinnerGif from "../../images/spinner.gif";
const Spinner = ({ width, height }) => {
  return (
    <div>
      <img src={SpinnerGif} alt="" width={width} height={height} />
    </div>
  );
};

export default Spinner;
