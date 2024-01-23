import axios from "axios";

function RequestAPI(url, body, headers){
    return axios.put(url, body,headers)
}

export default RequestAPI