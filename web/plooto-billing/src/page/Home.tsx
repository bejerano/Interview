import { createSearchParams, useNavigate } from 'react-router-dom';
import { PlootoDataTable } from '../components/datatable/Datatable';
import Breadcrumb from '../components/header/Breadcrumb';

function Home() {
  const navigate = useNavigate();

  const handlePayClick = (identifier: string, billId: string) => {
    navigate(
      {
        pathname: '/payment',
        search: createSearchParams({
          id: billId,
          identifier,
        }).toString(),
      },
      { replace: true },
    );
  };

  const handleViewPaymentsClick = (identifier: string, billId: string) => {
    navigate(
      {
        pathname: '/history',
        search: createSearchParams({
          id: billId,
          identifier,
        }).toString(),
      },
      { replace: true },
    );
  };

  return (
    <>
      <Breadcrumb pageName="Home" />
      <div className=" w-full flex flex-col pt-10">
        <h1 className="mb-4 text-4xl font-extrabold leading-none tracking-tight text-gray-900 md:text-5xl lg:text-6xl dark:text-white">Home</h1>
        <p className="mb-6 text-lg font-normal text-gray-500 lg:text-xl sm:px-16 xl:px-48 dark:text-gray-400">With Plooto's accounts payable and receivable software, spend more time on growing your business.</p>

        <PlootoDataTable pay={handlePayClick} view={handleViewPaymentsClick} />
      </div>
    </>

  );
}

export default Home;
