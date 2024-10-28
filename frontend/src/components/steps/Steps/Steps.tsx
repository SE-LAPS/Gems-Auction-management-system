import { Col, Row } from 'react-bootstrap';

import './steps.css';
import Step from '../Step/Step';

type StepType = {
  stepNo: number;
  stepType: string;
  desc: string;
  link: string;
};

type Props = {
  steps: StepType[];
};

const Steps: React.FC<Props> = ({ steps }) => {
  return (
    <div className='steps'>
      {steps.map((step) => {
        let right = false;

        if (step.stepNo % 2 === 0) {
          right = true;
        } else {
          right = false;
        }

        return (
          <Row style={{ marginBottom: 25, justifyContent: right ? 'end' : '' }}>
            <Col lg={5} md={6}>
              <Step step={step} key={step.stepNo} right={right} />
            </Col>
          </Row>
        );
      })}
    </div>
  );
};

export default Steps;
