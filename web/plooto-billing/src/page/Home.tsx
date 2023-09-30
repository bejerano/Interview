import { DataTable } from "../components/datatable/Datatable";
import Breadcrumb from "../components/header/Breadcrumb";

 

const  Home = () => {
    return (
      <>
           <Breadcrumb pageName="Home" />
            <div className=" w-full flex flex-col">                 
            <DataTable  />
          </div>
      </>
      
    );
  }
  
  export default Home;
  