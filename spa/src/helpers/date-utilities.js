//===================================================
// Date         : 04 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : date formatter helper
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
const stringMonth = [
  "Jan",
  "Feb",
  "Mar",
  "Apr",
  "May",
  "Jun",
  "Jul",
  "Aug",
  "Sep",
  "Oct",
  "Nov",
  "Dec",
];

export const formatDate = (date) => {
  let newDate = new Date(date);
  let year = newDate.getFullYear().toString();
  let month = newDate.getMonth();
  let day =
    newDate.getDate() < 10 ? "0" + newDate.getDate() : newDate.getDate();

  return `${day} ${stringMonth[month]} ${year}`;
};

export const getCurrentDateTime = () => {
  let today = new Date();

  let year = today.getFullYear().toString();
  let month = today.getMonth();
  let day = today.getDate() < 10 ? "0" + today.getDate() : today.getDate();
  let hour = today.getHours();
  let minute = today.getMinutes();
  let second =
    today.getSeconds() < 10 ? "0" + today.getSeconds() : today.getSeconds();

  return `${day} ${stringMonth[month]} ${year}, ${hour}:${minute}:${second} - UTC+7`;
};

export const getCurrentTime = () => {
  let today = new Date();
  let hour = today.getHours() < 10 ? "0" + today.getHours() : today.getHours();
  let minute =
    today.getMinutes() < 10 ? "0" + today.getMinutes() : today.getMinutes();
  return `${hour}:${minute}`;
};
