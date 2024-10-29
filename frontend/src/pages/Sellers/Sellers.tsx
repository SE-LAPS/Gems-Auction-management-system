import { Col, Container, Row } from 'react-bootstrap';
import Breadcrumb from '../../components/shared/Breadcrumb/Breadcrumb';
import SellerCard from '../../components/ui/Cards/SellerCard/SellerCard';
import { storeGetApi } from '../../services/StoreServices';
import { useEffect, useState } from 'react';
import { StoreGet } from '../../models/Store';

const Sellers = () => {
  useEffect(() => {
    getStores();
  }, []);

  const [stores, setStores] = useState<StoreGet[] | null | undefined>(null);

  const getStores = async () => {
    try {
      const res = await storeGetApi();

      if (res?.data) {
        const storeArray = Array.isArray(res.data) ? res.data : [res.data];
        setStores(storeArray);
      } else {
        setStores(null);
      }
    } catch (error) {
      console.error('Error Fetching Store' + error);
      setStores(null);
    }
  };
  return (
    <div>
      <Breadcrumb>
        <h1>Sellers</h1>

        <ul className='breadcrumb-list'>
          <li>
            <a href='/'>Home</a>
          </li>
          <li>Sellers</li>
        </ul>
      </Breadcrumb>

      <Container>
        <Row style={{ marginBottom: '60px' }}>
          {stores?.map((store) => (
            <Col xl={3} lg={4} md={6}>
              <SellerCard store={store} key={store.id} />
            </Col>
          ))}
        </Row>
      </Container>
    </div>
  );
};

export default Sellers;
