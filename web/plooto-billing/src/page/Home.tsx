import { createSearchParams, useNavigate } from "react-router-dom";
import { PlootoDataTable } from "../components/datatable/Datatable";
import Breadcrumb from "../components/header/Breadcrumb";

 

const  Home = () => {
  const navigate = useNavigate();

  const handlePayClick = (identifier: string, billId: string) => {
    alert('paying bill #:' + identifier + 'id: ' + billId);
    navigate(
        {
            pathname: '/payment',
            search:  createSearchParams({
                id: billId,
                identifier: identifier
            }).toString()
        },
        {replace: true}
    );
}
 

  const handleViewPaymentsClick = (identifier: string, billId: string) => {
    alert('paying bill #:' + identifier + 'id: ' + billId);
    navigate(
        {
            pathname: '/history',
            search:  createSearchParams({
                id: billId,
                identifier: identifier
            }).toString()
        },
        {replace: true}
    );
  };

    return (
      <>
           <Breadcrumb pageName="Home" />
            <div className=" w-full flex flex-col pt-10">                 
               <PlootoDataTable pay={handlePayClick} view={handleViewPaymentsClick} />
          </div>
      </>
      
    );
  }
  
  export default Home;
  