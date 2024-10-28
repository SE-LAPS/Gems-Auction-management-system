import { useSnapshot } from 'valtio';

import state from '../../../store';
import './sidebar.css';

const FilterSidebar = () => {
  const snap = useSnapshot(state);

  return (
    <div className={`filter-sidebar ${snap.filterSidebar ? 'slide' : ''}`}>
      <div className='auction-sidebar'>
        <div className='single-widget mb-30'>
          <h5 className='widget-title'>Category</h5>
          <div className='checkbox-container'>
            <ul>
              <li>
                <label className='containerss'>
                  <input type='checkbox' />
                  <span className='checkmark'></span>
                  <span>Automotive</span>
                </label>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default FilterSidebar;
