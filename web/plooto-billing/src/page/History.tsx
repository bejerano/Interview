import { useSearchParams } from "react-router-dom";
import Breadcrumb from "../components/header/Breadcrumb";

const History = () => {
  const [searchParams ] = useSearchParams();
  //  const id = searchParams.get("id");
  const identifier = searchParams.get("identifier");


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
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
              <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                Apple MacBook Pro 17"
              </th>

              <td className="px-6 py-4">
                $2999
              </td>
              <td className="px-6 py-4">
                2021-07-01
              </td>
            </tr>
            <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 hover:bg-gray-50 dark:hover:bg-gray-600">
              <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                Microsoft Surface Pro
              </th>

              <td className="px-6 py-4">
                $1999
              </td>
              <td className="px-6 py-4">
                2021-07-01
              </td>

            </tr>
            <tr className="bg-white dark:bg-gray-800 hover:bg-gray-50 dark:hover:bg-gray-600">
              <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                Magic Mouse 2
              </th>
              <td className="px-6 py-4">
                $99
              </td>
              <td className="px-6 py-4">
                2021-07-01
              </td>

            </tr>
          </tbody>
        </table>
      </div>
    </>
  );
}

export default History;