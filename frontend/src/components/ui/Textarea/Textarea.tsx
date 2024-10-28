import './textarea.css';

type TextareaProps = {
  label?: string;
  id: string;
  name: string;
  placeHolder?: string;
  onChange?: (e: React.ChangeEvent<HTMLTextAreaElement>) => void;
  value?: string;
  error?: string;
};

const Textarea = ({
  label,
  id,
  name,
  placeHolder,
  value,
  onChange,
  error,
}: TextareaProps) => {
  return (
    <div className='form-inner'>
      {label && <label htmlFor={id}>{label}</label>}
      <textarea
        name={name}
        id={id}
        placeholder={placeHolder}
        value={value}
        onChange={onChange}
      ></textarea>
      {error && <span className='error-message'>{error}</span>}
    </div>
  );
};

export default Textarea;
