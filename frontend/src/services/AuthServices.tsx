import axios from 'axios';
import { handleError } from '../handlers/ErrorHandler';
import { UserProfileToken } from '../models/User';

const api = 'http://localhost:5256/backend/';

export const loginAPI = async (username: string, password: string) => {
  try {
    const data = await axios.post<UserProfileToken>(api + 'account/login', {
      username: username,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const registerAPI = async (
  email: string,
  username: string,
  phoneNumber: string,
  password: string
) => {
  try {
    const data = await axios.post<UserProfileToken>(api + 'account/register', {
      email: email,
      username: username,
      phoneNumber: phoneNumber,
      password: password,
    });
    return data;
  } catch (error) {
    handleError(error);
  }
};

export const getUserByIdApi = async (userId: string) => {
  try {
    const data = await axios.get<UserProfileToken>(`${api}account/${userId}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
