import { UserProfileToken } from '../../../models/User';
import './tables.css';

interface BidsWithUser {
  amount: number;
  userId: string;
  user: UserProfileToken;
}

type Props = {
  bids: BidsWithUser[];
};

const BiddingSummaryAuction = ({ bids }: Props) => {
  return (
    <div className='bidding-summary-wrap'>
      <h6>Bidding Summary</h6>

      <table className='bidding-summary-table'>
        <thead>
          <tr>
            <th>Username</th>
            <th>Amount</th>
            <th>Date</th>
          </tr>
        </thead>
        <tbody>
          {bids.map((bid) => (
            <tr>
              <td data-label='Product name'>{bid.user.userName}</td>
              <td data-label='Amount'>${bid.amount}</td>
              <td data-label='Auction Date'>June 25, 2024</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BiddingSummaryAuction;
