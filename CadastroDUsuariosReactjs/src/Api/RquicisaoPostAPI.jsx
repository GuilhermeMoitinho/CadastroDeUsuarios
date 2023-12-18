import axios from "axios";

function RequestAPI(url, body){
    return axios.post(url, body)
}

export default RequestAPI