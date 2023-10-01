import { useSearchParams } from "react-router-dom";
import Breadcrumb from "../components/header/Breadcrumb";
import { useEffect, useState } from "react";
import Loader from "../components/loader/Loader";

 
import moment from "moment";
import { toast } from "react-toastify";
import { currencyFormat } from "../common/auxiliar";



const History = () => {
  const [searchParams ] = useSearchParams();
  const id = searchParams.get("id");
  const identifier = searchParams.get("identifier");
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);

  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const uri = `https://127.0.0.1:7000/api/v1/billing/${id}`
        const response = await fetch(uri);
        const result = await response.json();
        setData(result); // Assuming the API response is an array of objects
        setLoading(false);
      } catch (error) {
        toast.error('We are experiencing some issues, contact IT!', {
          position: toast.POSITION.TOP_RIGHT
        });
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) {
    return <Loader />;
  }
  return (
    <>
      <Breadcrumb pageName="History" />
      <div className="h-56 grid grid-cols-2 gap-4 content-start pt-10">
      
        <div> <span className="mb-4 text-2xl font-extrabold leading-none tracking-tight text-gray-900 md:text-2xl lg:text-6xl dark:text-white">Payment History
        </span></div>
        <div><p className="mb-6 text-lg font-normal text-gray-500 lg:text-xl sm:px-16 xl:px-48 dark:text-gray-400">Bill # {identifier}</p></div>
      </div>
    
      <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
          <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
            <tr>
              <th scope="col" className="px-6 py-3">
                Payment #
              </th>
              <th scope="col" className="px-6 py-3">
                Amount
              </th>
              <th scope="col" className="px-6 py-3">
                Date
              </th>

            </tr>
          </thead>
          <tbody>
          {data.map((item: any) => (
            <tr key={item.id} className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
              <td className="px-6 py-4">{item.identifier}</td>
              <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white" >{currencyFormat(item.amount)}</th>
              <td className="px-6 py-4">  
                     {moment(item.debitDate).format("MMMM Do YYYY, h:mm:ss a")}                      
              </td>
              {/* Render other properties of the item */}
            </tr>
          ))}            
          </tbody>
        </table>
      </div>
    </>
  );
}

export default History;