//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Http request service
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import axios from "axios";
import { errorHandler } from "../helpers/error-handler";

const { REACT_APP_SERVER_DOMAIN } = process.env;

const axiosInstance = axios.create({
  baseURL: REACT_APP_SERVER_DOMAIN,
  headers: { Accept: "application/json", "Content-Type": "application/json" },
  // withCredentials: true,
});

axiosInstance.interceptors.request.use(async (config) => {
  return config;
});

const getData = async (path) => {
  try {
    const response = await axiosInstance.get(path);
    return {
      success: true,
      data: response.data,
      pagination: response?.headers?.pagination ?? null,
    };
  } catch (error) {
    return errorHandler(error);
  }
};

const postData = async (path, data) => {
  try {
    const response = await axiosInstance.post(path, data);
    return {
      success: true,
      data: response.data,
      pagination: response?.headers?.pagination ?? null,
    };
  } catch (error) {
    return errorHandler(error);
  }
};

const putData = async (path, data) => {
  try {
    const response = await axiosInstance.put(path, data);
    return {
      success: true,
      data: response.data,
      pagination: response?.headers?.pagination ?? null,
    };
  } catch (error) {
    return errorHandler(error);
  }
};

const deleteData = async (path) => {
  try {
    await axiosInstance.delete(path);
    return {
      success: true,
      data: null,
      pagination: null,
    };
  } catch (error) {
    return errorHandler(error);
  }
};

export {
  getData as get,
  postData as post,
  putData as put,
  deleteData as delete,
};
