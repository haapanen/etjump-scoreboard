export class BaseApi {
    protected baseUrl: string;

    constructor(baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    protected fetch<T>(url: string, method: string, data: object | undefined | null): Promise<T> {
        let requestInit: RequestInit = {
            credentials: "same-origin",
            method: method,
            headers: {
                "Content-Type": "application/json"
            }
        };
        if (method === "get") {
            if (data) {
                url = withQuery(url, data);
            }
        } else {
            requestInit.body = JSON.stringify(data);
        }
        return fetch(url, requestInit)
            .then(res => {
                return res.json();
            }).catch(err => {
                alert(err.message);
                throw err;
            }
        );
    }
}

const withQuery = (url: string, params: object) => {
    let query = Object.keys(params)
        .filter(k => params[k] !== undefined)
        .map(k => encodeURIComponent(k) + "=" + encodeURIComponent(params[k]))
        .join("&");
    url += (url.indexOf("?") === -1 ? "?" : "&") + query;
    return url;
};