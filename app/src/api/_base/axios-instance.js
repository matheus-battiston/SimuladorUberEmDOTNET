import axios from 'axios';

const URL_API = 'http://localhost:5276';

export const axiosInstance = axios.create({
  baseURL: URL_API,
  timeout: 5000,
  withCredentials: false,
});
