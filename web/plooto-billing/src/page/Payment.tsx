import { useNavigate, useSearchParams } from 'react-router-dom';
import { useState } from 'react';
import { toast } from 'react-toastify';
import { Toaster } from 'react-hot-toast';
import Breadcrumb from '../components/header/Breadcrumb';

export function DropdownComponent(props: { id:string, onChange: any }) {
  const _handleChange = (event: any) => {
    const { value } = event.target;
    props.onChange(value);
  };
  return (
    <div className="relative w-full lg:max-w-sm mt-10">
      <select
        id={props.id}
        className="w-full p-2.5 text-gray-500 bg-white border rounded-md shadow-sm outline-none appearance-none focus:border-indigo-600"
        onChange={_handleChange}
      >
        <option value={1}>Bank Tranfer</option>
        <option value={2}>Email Tranfer</option>
        <option value={3}>Credit Card</option>
      </select>
    </div>
  );
}

const apiUrl = `${import.meta.env.VITE_BASE_URL}/billing/payment`;

function Payment() {
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);
  const [amount, setAmount] = useState('');
  const [debitDate, setDebitDate] = useState('');
  const [paymentMethod, setPaymentMethod] = useState('');

  const navigate = useNavigate();
  const [searchParams] = useSearchParams();

  const id = searchParams.get('id');
  const identifier = searchParams.get('identifier');

  const handleSubmit = async (_event: any) => {
    _event.preventDefault();
    setLoading(true);
    debugger;

    const payload = {
      billId: id,
      amount,
      debitDate,
      paymentMethod,
    };

    const rawResponse = fetch(apiUrl, {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(payload),
    });

    rawResponse.then((res) => res.json())
      .then((_data: any) => {
        debugger;
        toast.info(_data.message, {
          position: toast.POSITION.TOP_RIGHT,
        });

        setLoading(false);
      }).catch((_err: any) => {
        toast.error('Your payment didnt process, try again!', {
          position: toast.POSITION.TOP_RIGHT,
        });
        setError(_err);
        setLoading(false);
      });
  };

  return (
    <>
      <Breadcrumb pageName="Payment" />
      <div className="h-56 grid grid-cols-2 gap-4 content-center pt-10">

        <div>
          {' '}
          <span className="mb-4 text-2xl font-extrabold leading-none tracking-tight text-gray-900 md:text-2xl lg:text-6xl dark:text-white">
            Payment for
          </span>
        </div>
        <div>
          <p className="mb-6 text-lg font-normal text-gray-500 lg:text-xl sm:px-16 xl:px-48 dark:text-gray-400">
            Bill #
            {identifier}
          </p>
        </div>
      </div>

      <div className="w-full max-w-sm p-4 bg-white border border-gray-200 rounded-lg shadow sm:p-6 md:p-8 dark:bg-gray-800 dark:border-gray-700">
        { error && <Toaster /> }
        <form onSubmit={handleSubmit}>
          <div className="relative z-0 w-full mb-6 group">
            <input
              type="number"
              name="floating_email"
              id="floating_email"
              className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
              placeholder="0.00"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              required
            />
            <label htmlFor="floating_email" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Amount</label>
          </div>
          <div className="relative z-0 w-full mb-6 group">
            <input
              type="date"
              name="floating_password"
              id="floating_password"
              className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
              placeholder=" "
              min="<?= date('Y-m-d'); ?>"
              value={debitDate}
              onChange={(e) => setDebitDate(e.target.value)}
              required
            />
            <label
              htmlFor="floating_password"
              className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
            >
              Debit Date
            </label>
          </div>
          <div className="relative z-0 w-full mb-6 group">
            <label htmlFor="pm" className=" peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-8 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-8">Payment Method</label>
            <DropdownComponent id="pm" onChange={setPaymentMethod} />
          </div>

          <button type="submit" className="text-white bg-success hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Submit</button>
          <button
            type="button"
            className="text-white bg-warning hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
            onClick={() => navigate('/')}
          >
            Cancel
          </button>
        </form>
      </div>

    </>
  );
}

export default Payment;
