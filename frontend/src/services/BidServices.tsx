import axios from 'axios';
import { handleError } from '../handlers/ErrorHandler';
import { BidGet, BidPost } from '../models/Bid';

const api = 'http://localhost:5256/backend/bid';

export const placeBidApi = async (auctionId: number, amount: number) => {
  try {
    const token = localStorage.getItem('token');

    const data = await axios.post<BidPost>(
      api,
      {
        auctionId: auctionId,
        amount: amount,
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    return data;
  } catch (error) {
    handleError(error);
  }
};

export const getBidsByAuctionApi = async (auctionId: number) => {
  try {
    const data = await axios.get<BidGet>(`${api}/auction/${auctionId}`);
    return data;
  } catch (error) {
    handleError(error);
  }
};
