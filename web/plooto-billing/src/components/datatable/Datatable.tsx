import { Component } from 'react';
import './datatable.css';

import * as $ from "jquery";
await import('datatables.net');

import { createRoot } from 'react-dom/client';




export const ViewPayment = (props: { id: any, identifier: string, isPayed: boolean, pay: any, view: any }) => {
    return (
        <>
            <div className="inline-flex rounded-md shadow-sm" role="group">
                {!props.isPayed && (<button type="button" className="inline-block rounded bg-success px-6 pb-2 pt-2.5 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#14a44d] transition duration-150 ease-in-out hover:bg-success-600 hover:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] focus:bg-success-600 focus:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] focus:outline-none focus:ring-0 active:bg-success-700 active:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.3),0_4px_18px_0_rgba(20,164,77,0.2)] dark:shadow-[0_4px_9px_-4px_rgba(20,164,77,0.5)] dark:hover:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)] dark:focus:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)] dark:active:shadow-[0_8px_9px_-4px_rgba(20,164,77,0.2),0_4px_18px_0_rgba(20,164,77,0.1)]" onClick={() => props.pay(props.identifier, props.id)}>
                    Pay
                </button>)
                }
                <button type="button"
                    className="inline-block rounded bg-secondary px-6 pb-2 pt-2.5 pl-2 text-xs font-medium uppercase leading-normal text-white shadow-[0_4px_9px_-4px_#e4a11b] transition duration-150 ease-in-out hover:bg-warning-600 hover:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] focus:bg-warning-600 focus:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] focus:outline-none focus:ring-0 active:bg-warning-700 active:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.3),0_4px_18px_0_rgba(228,161,27,0.2)] dark:shadow-[0_4px_9px_-4px_rgba(228,161,27,0.5)] dark:hover:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)] dark:focus:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)] dark:active:shadow-[0_8px_9px_-4px_rgba(228,161,27,0.2),0_4px_18px_0_rgba(228,161,27,0.1)]"
                    onClick={() => props.view(props.identifier, props.id)}
                    >
                    View Payments
                </button>
            </div>
        </>
    )
}


interface DataTableProps {
    pay: (identifier: string, billId: string) => void;
    view: (identifier: string, billId: string) => void;
}

interface DataTableState { }

export class PlootoDataTable extends Component<DataTableProps, DataTableState> {
    el: any;
    
    constructor(props: DataTableProps) {
        super(props);
        this.state = {
        };
    }

    
    componentDidMount() {
        
        if (!this.el) return;

        this.el = $(this.el)    
        const columns = [
            { title: "Bill #", data: "identifier", width: "10%"},
            { title: "Amount", data: "totalDue", width: "20%", render: this.el.DataTable.render.number(null, null, 2, '$') },
            { title: "Vendor", data: "vendor", width: "40%" },
            {
                title: "Paid", data: "status", "width": "5%", render: function (data: string) {

                    if (data == 'Paid') {
                        return '<input type="checkbox" disabled checked class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">';
                    } else {
                        return '<input type="checkbox" disabled class="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600">';
                    }
                    return data;
                }
            },
            { title: "", data: "id" }


        ];

        this.el.DataTable({
            //data: this.props.data,
            columns: columns,
            "ajax": {
                "url": "https://127.0.0.1:7000/api/v1/Billing", // ajax source
                "method": "GET",
                "dataType": "json",               
                "dataSrc": function (json: any) {
                 
                    const json_data = JSON.stringify(json)
                    return JSON.parse(json_data);
                },
                error: function (err: any) {
                    // add toastify
                    console.log(err.message);
                },
            },
            columnDefs: [{
                targets: 4,
                createdCell: (td: HTMLElement | null,  rowData: any) => {
                    if (td) {
                        // Remove text 
                        while (td.hasChildNodes()) {
                            td.removeChild(td.childNodes[0]);
                        }                        
                        const root = document.createElement('div');    
                        td.appendChild(root);
                        const btns = createRoot(root);
                        btns.render(<ViewPayment id={rowData.id} identifier={rowData.identifier} isPayed={rowData.status == 'Paid'} pay={this.props.pay} view={this.props.view}/>);                        
                    }
                },
                orderable: false
            }],
            pagingType: 'numbers',
            pageLength: 5,
            lengthMenu: [5, 15, 25, 35],
            dom: '<"top"lf<"clear">>rt<"bottom"ip<"clear">>',
            order: [[1, 'asc']],
            search: {
                "regex": true
            },
            destroy: true,
            // bProcessing: true,
            // bServerSide: true,

        })       
    }
 
    componentWillUnmount(){
        this.el.find('table').DataTable().destroy(true);
     }

    render() {
        return (
            <div className="shadow-md sm:rounded-lg">
                <table id="bills" className="display" style={{ width: "100%", padding: 1, borderRadius: 2 }} ref={el => this.el = el}>                  
                </table>
            </div>
        );
    }
}

