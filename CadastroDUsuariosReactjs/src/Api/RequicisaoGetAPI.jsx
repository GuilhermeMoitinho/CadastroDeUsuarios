import axios from 'axios';

async function RequestGetAPI(url, headers) {
   return await axios.get(url, headers);
     
  }  


export default RequestGetAPI;
