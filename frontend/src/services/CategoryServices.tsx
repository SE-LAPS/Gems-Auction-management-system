import axios from 'axios';
import { handleError } from '../handlers/ErrorHandler';
import { CategoryGet } from '../models/Category';

const api = 'http://localhost:5256/backend/category';

export const getCategoriesApi = async () => {
  try {
    const data = await axios.get<CategoryGet>(api);
    return data;
  } catch (error) {
    handleError(error);
  }
};
