//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  :API service
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
import * as API from "./http-service";
const baseTarget = "master";

export const getPage = async (params) => {
  let target = `${baseTarget}/page`;

  const reqParams = new URLSearchParams();
  reqParams.append("search", params.search ?? "");
  reqParams.append("pageNumber", params.pageNumber ?? 1);
  reqParams.append("pageSize", params.pageSize ?? 5);
  reqParams.append("orderBy", params.orderBy ?? "");
  reqParams.append("isDescending", params.isDescending ?? false);

  if (reqParams) {
    target += `?${reqParams}`;
  }

  const result = await API.get(target);
  return result;
};

export const getOne = async (id) => {
  let target = `${baseTarget}/${id}`;

  const result = await API.get(target);
  return result;
};

export const getAll = async () => {
  let target = baseTarget;

  const result = await API.get(target);
  return result;
};

export const create = async (formData) => {
  let target = baseTarget;

  const result = await API.post(target, formData);
  return result;
};

export const update = async (id, formData) => {
  let target = `${baseTarget}/${id}`;

  const data = formData;
  data.isUpdate = true;
  const result = await API.put(target, data);
  return result;
};

export const remove = async (id) => {
  let target = `${baseTarget}/${id}`;

  const result = await API.delete(target);
  return result;
};
