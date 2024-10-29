import { createBrowserRouter } from 'react-router-dom';
import App from '../App';
import Home from '../pages/Home/Home';
import Login from '../pages/Login/Login';
import Signup from '../pages/Signup/Signup';
import ProtectedRoute from './ProtectedRoute';
import HowtoSell from '../pages/HowtoSell/HowtoSell';
import Profile from '../pages/Profile/Profile';
import CreateStore from '../pages/CreateStore/CreateStore';
import Sellers from '../pages/Sellers/Sellers';
import SellerDetails from '../pages/Sellers/SellerDetails';
import Categories from '../pages/Categories/Categories';
import Auctions from '../pages/Auctions/Auctions';
import AuctionDetails from '../pages/Auctions/AuctionDetails';
import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';

const stripePromise = loadStripe(import.meta.env.VITE_STRIPE_PUBLISHABLE_KEY);

export const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    children: [
      { index: true, element: <Home /> },
      { path: 'how-to-sell', element: <HowtoSell /> },
      { path: 'login', element: <Login /> },
      { path: 'signup', element: <Signup /> },
      { path: 'sellers', element: <Sellers /> },
      { path: 'seller-details', element: <SellerDetails /> },
      { path: 'categories', element: <Categories /> },
      { path: 'auctions', element: <Auctions /> },
      {
        path: 'auction-details',
        element: (
          <Elements stripe={stripePromise}>
            <AuctionDetails />
          </Elements>
        ),
      },
      {
        path: 'dashboard',
        element: (
          <ProtectedRoute>
            <Profile />
          </ProtectedRoute>
        ),
      },
      {
        path: 'create-store',
        element: (
          <ProtectedRoute>
            <CreateStore />
          </ProtectedRoute>
        ),
      },
    ],
  },
]);
