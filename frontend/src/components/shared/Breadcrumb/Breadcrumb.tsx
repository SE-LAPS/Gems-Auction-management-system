import { Col, Container, Row } from 'react-bootstrap';
import './breadcrumb.css';

type BreadcumbProps = {
  children: React.ReactNode;
};

const Breadcrumb = ({ children }: BreadcumbProps) => {
  return (
    <div className='breadcrumb'>
      <Container>
        <Row>
          <Col lg={12} className='bread-col'>
            <div className='banner-content'>{children}</div>
          </Col>
        </Row>
      </Container>
    </div>
  );
};

export default Breadcrumb;
