const BaseUrl = 'https://localhost:7195/api/Pessoa';

const http = {
    get,
    post,
    put,
    del
}

export default http;

function setAuthorizationHeader() {
    const headers = {};
    headers['Accept'] = 'application/json';
    headers['Content-Type'] = 'application/json';
    headers['Authorization'] = localStorage.getItem("autenticacao");
    return headers;
}

async function get(url, id, success, error) {
    const headers = setAuthorizationHeader();
    const req = function () { return fetch(BaseUrl + '/' + url + `${id ? + id : ""}`, { headers }) }

    resolveCallBacks(req, success, error);
}

async function post(url, body, success, error) {
    const headers = setAuthorizationHeader();
    const req = function () { return fetch(BaseUrl + '/' + url, { headers, body, method: "POST", body: JSON.stringify(body) }) }

    resolveCallBacks(req, success, error);

}

function put(url, body, success, error) {
    const headers = setAuthorizationHeader();
    const req = function () { return fetch(BaseUrl + '/' + url, { headers, body, method: "PUT", body: JSON.stringify(body) }) }

    resolveCallBacks(req, success, error);
}

function del(url, success, error) {
    const headers = setAuthorizationHeader();
    const req = function () { return fetch(BaseUrl + '/' + url, { headers, method: "DELETE" }) }

    resolveCallBacks(req, success, error);
}

function resolveCallBacks(request, success, error) {
    request()
        .then(response => {
            if (response.status == 401)
                location.href = "./login.html";
            if (response.status != 200) {
                response.json().then(error => {
                    alert(error.Message);
                })
            } else {
                success(response);
            }
        })
        .catch(error ? error : e => console.log(e))
}