import axios from "axios";

function RequestAPI(url, body){
    return axios.put(url, body)
}

export default RequestAPI