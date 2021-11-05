//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Error handler helper
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
export const errorHandler = (error) => {
  const status = error?.response?.status ?? null;
  const data = error?.response?.data ?? null;

  switch (status) {
    case 400:
      return {
        success: false,
        errors: data.errors != null ? data.errors : data,
        status: 400,
      };

    case 401:
      return {
        success: false,
        errors: ["Unauthorized"],
        status: 401,
      };

    case 403:
      return {
        success: false,
        errors: ["Forbidden"],
        status: 403,
      };

    case 404:
      return {
        success: false,
        errors: ["Not Found"],
        status: 404,
      };

    case 422:
      return {
        success: false,
        errors: data.errors != null ? data.errors : data,
        status: 422,
      };

    case 500:
      return {
        success: false,
        errors: ["Internal server error"],
        status: 500,
      };

    default:
      return {
        success: false,
        errors: [],
        status: 0,
      };
  }
};
