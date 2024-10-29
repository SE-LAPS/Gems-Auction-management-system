import { Container } from 'react-bootstrap';
import { useSnapshot } from 'valtio';

import './profile.css';
import { buyerDashboard } from '../../data/buyerDashboard';
import DashboardSidebar from '../../components/shared/Sidebars/DashboardSidebar';
import Breadcrumb from '../../components/shared/Breadcrumb/Breadcrumb';
import Dashboard from '../Dashboard/Dashboard';
import MyAuction from '../Dashboard/MyAuction/MyAuction';
import state from '../../store';
import BidButton from '../../components/ui/Buttons/BidButton/BidButton';
import AddArt from '../Dashboard/AddArt/AddArt';
import { sellerDashboard } from '../../data/sellerDashboard';
import Arts from '../Dashboard/Arts/Arts';
import { useAuth } from '../../context/useAuth';
import StartAuction from '../Dashboard/StartAuction/StartAuction';
import Auctions from '../Dashboard/Auctions/Auctions';

const Profile = () => {
  const { logout } = useAuth();

  const snap = useSnapshot(state);

  const storeId = localStorage.getItem('storeId');

  const handleLogout = () => {
    logout();
  };

  const renderComponent = () => {
    if (storeId === '0' && snap.switchToSeller === false) {
      switch (snap.dashboardSelected) {
        case 'Dashboard':
          return <Dashboard />;
        case 'MyAuction':
          return <MyAuction />;
        case 'Logout':
          handleLogout();
          break;
        default:
          return <Dashboard />;
      }
    } else {
      switch (snap.dashboardSelected) {
        case 'Dashboard':
          return <Dashboard />;
        case 'MyArts':
          return <Arts />;
        case 'AddArt':
          return <AddArt />;
        case 'Auctions':
          return <Auctions />;
        case 'StartAuction':
          return <StartAuction />;
        default:
          <Dashboard />;
      }
    }
  };

  const handleSwitch = () => {
    if (snap.switchToSeller == true) {
      state.switchToSeller = false;
    } else {
      state.switchToSeller = true;
    }
    state.dashboardSelected = 'Dashboard';
  };

  return (
    <div>
      <Breadcrumb>
        <h1>Profile</h1>

        <ul className='breadcrumb-list'>
          <li>
            <a href='/'>Home</a>
          </li>
          <li>Profile</li>
        </ul>
      </Breadcrumb>

      <div className='dashboard-section mb-60 pt-60'>
        <Container>
          {storeId != '0' && snap.switchToSeller == false ? (
            <BidButton
              text='Switch to Seller'
              size='lg'
              variant='nonActive'
              onClick={handleSwitch}
            />
          ) : (
            <BidButton
              text='Switch to Buyer'
              size='lg'
              variant='nonActive'
              onClick={handleSwitch}
            />
          )}
          <div className='dashboard-wrapper'>
            <DashboardSidebar
              links={snap.switchToSeller ? sellerDashboard : buyerDashboard}
            />

            <div className='dashboard-content-wrap'>{renderComponent()}</div>
          </div>
        </Container>
      </div>
    </div>
  );
};

export default Profile;
