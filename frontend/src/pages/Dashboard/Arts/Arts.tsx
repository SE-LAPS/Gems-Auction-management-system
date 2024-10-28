import { sellerArtPills } from '../../../data/sellerArtPills';
import NavPills from '../../../components/ui/NavPills/NavPills';
import { useEffect, useState } from 'react';
import { Art } from '../../../models/Art';
import { Col, Row } from 'react-bootstrap';
import AuctionCard from '../../../components/ui/Cards/AuctionCard/AuctionCard';
import { getArtsByStore } from '../../../utils/arts';
import Pagination from '../../../components/ui/Pagination/Pagination';
import PaginationItem from '../../../components/ui/Pagination/PaginationItem';

const Arts = () => {
  const [arts, setArts] = useState<Art[] | null | undefined>(null);
  const [pageNumber, setPageNumber] = useState(1);
  const [pageSize] = useState(10);
  const [totalPages, setTotalPages] = useState(1);
  const storeId = localStorage.getItem('storeId');

  useEffect(() => {
    if (storeId) {
      getArtsByStore(
        parseInt(storeId),
        pageNumber,
        pageSize,
        setArts,
        setTotalPages
      );
    }
  }, [storeId, pageNumber, pageSize]);

  const handlePageChange = (page: number) => {
    setPageNumber(page);
  };

  return (
    <div className='my-auction-wrap'>
      <NavPills navpills={sellerArtPills} />

      <Row>
        {arts?.map((art) => (
          <Col xl={4} lg={6}>
            <AuctionCard art={art} />
          </Col>
        ))}
      </Row>

      <div className='mt-60'>
        <Pagination>
          {[...Array(totalPages)].map((_, index) => (
            <PaginationItem
              key={index + 1}
              active={index + 1}
              handleClick={() => handlePageChange(index + 1)}
            >
              {index + 1}
            </PaginationItem>
          ))}
        </Pagination>
      </div>
    </div>
  );
};

export default Arts;
