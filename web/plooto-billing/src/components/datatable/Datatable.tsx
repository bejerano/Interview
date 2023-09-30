import { Component, ReactNode, useState } from 'react';
import './datatable.css';
import ReactDOM from 'react-dom';

import $ from 'jquery';
import { createSearchParams, useNavigate } from 'react-router-dom';
$.Datatable = import('datatables.net');



export const ViewPayment = (props: { id: any, identifier:string, isPayed: boolean }) => {
    const [billId] = useState(props.id);
    //const navigate = useNavigate();

    const handlePay = () => {
        alert('paying bill #:'+ props.identifier + 'id: ' + billId);
        // navigate(
        //     {
        //         pathname: '/payment',
        //         search:  createSearchParams({
        //             id: billId,
        //             identifier: props.identifier
        //         }).toString()
        //     }
        // );
    }

    return (
        <>
            <div className="inline-flex rounded-md shadow-sm" role="group">
                { !props.isPayed && (<button type="button" className="inline-block rounded bg-success px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#14a44d] transition duration-150 ease-in-out hover:bg-success-600 hover:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] focus:bg-success-600 focus:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] focus:outline-none focus:ring-0 active:bg-success-700 active:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] dark:shadow-[0_4px_9px_-4px_rgba(20,164,77,0.5)] dark:hover:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)] dark:focus:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)] dark:active:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)]">
                    Pay
                </button>)
                }
                <button type="button"
                    className="inline-block rounded bg-secondary px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#e4a11b] transition duration-150 ease-in-out hover:bg-warning-600 hover:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] focus:bg-warning-600 focus:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] focus:outline-none focus:ring-0 active:bg-warning-700 active:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] dark:shadow-[0_4px_9px_-4px_rgba(228,161,27,0.5)] dark:hover:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)] dark:focus:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)] dark:active:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)]"
                    onClick={handlePay}>
                    View Payments
                </button>
            </div>
        </>
    )
}


interface DataTableProps {
}

interface DataTableState { }





export class DataTable extends Component<DataTableProps, DataTableState> {
    el: any;

   
      

    componentDidMount() {
        this.el = $(this.el)

        const columns = [
            { title: "Bill #", data: "identifier", width: "10%" },
            { title: "Amount", data: "totalDue", width: "20%", render: this.el.DataTable.render.number( null, null, 2, '$' )},
            { title: "Vendor", data: "vendor" },
            { title: "Paid", data: "status", "width": "5%", render: function (data: string,type: any,row: any) {
               console.log(data);
                if (data == 'Paid') {
                  return '<input type="checkbox" disabled checked class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">';
                } else {
                  return '<input type="checkbox" disabled class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">';
                }
              return data;
          }   },
            { title: ""}
            
           
          ];

        this.el.DataTable({
            //data: this.props.data,
            columns: columns,
            "ajax": {
                "url": "https://127.0.0.1:7000/api/v1/Billing", // ajax source
                "method": "GET",
                "dataType": "json",
                // "success": (resp: any) => {                     
                //     return resp;
                // },
                "dataSrc": function (json: any) {
                    debugger
                    const json_data = JSON.stringify(json)
                    return JSON.parse(json_data);
                },
                error: function (err: any) {
                    debugger;
                },
            },
            columnDefs: [{
                targets: 4,
                createdCell: (td: HTMLElement | null, cellData: any, rowData: any, row: any, col: any) => {
                    if (td) {
                        const root = document.createElement('div');
                        td.appendChild(root);
                        ReactDOM.render(<ViewPayment id={rowData.id} identifier={rowData.identifier} isPayed={ rowData.status == 'Paid'} />, root);
                    }
                }
            }],
            pagingType: 'full_numbers',
            pageLength: 10,
            lengthMenu: [15, 20, 30],
            dom: 'Bfrtip',
            order: [[1, 'asc']],
            destroy: true,
            // bProcessing: true,
            // bServerSide: true,

        })
    }

    componentWillUnmount() {
    }

    render() {
        return (
            <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
                <table id="example" className="display w-full text-sm text-left text-gray-700 dark:text-gray-400" style={{ width: "100%", padding: 15, borderRadius: 5 }} ref={el => this.el = el}>
                    {/* <thead>
        <tr>
            <th>Subscriber ID</th>
            <th>Install Location</th>
            <th>Subscriber Name</th>
            <th>some data</th>
        </tr>
    </thead> */}
                </table>
            </div>
        );
    }
}

