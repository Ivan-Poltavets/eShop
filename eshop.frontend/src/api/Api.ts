import {ClientBase} from "./Client-base";

export class Client extends ClientBase {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        super();
        this.http = http ? http : window as any;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    /**
     * @param catalogItemId (optional)
     * @return Success
     */
    addItem(catalogItemId: string | undefined, api_version: string): Promise<void> {
        let url_ = this.baseUrl + "/api/Basket/items?";
        if (catalogItemId === null)
            throw new Error("The parameter 'catalogItemId' cannot be null.");
        else if (catalogItemId !== undefined)
            url_ += "catalogItemId=" + encodeURIComponent("" + catalogItemId) + "&";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "POST",
            headers: {
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processAddItem(_response);
        });
    }

    protected processAddItem(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @return Success
     */
    getAllBasketItems(api_version: string): Promise<BasketItem[]> {
        let url_ = this.baseUrl + "/api/Basket/items?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGetAllBasketItems(_response);
        });
    }

    protected processGetAllBasketItems(response: Response): Promise<BasketItem[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as BasketItem[];
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<BasketItem[]>(null as any);
    }

    /**
     * @param basketItemId (optional)
     * @return Success
     */
    removeItem(basketItemId: string | undefined, api_version: string): Promise<void> {
        let url_ = this.baseUrl + "/api/Basket/items?";
        if (basketItemId === null)
            throw new Error("The parameter 'basketItemId' cannot be null.");
        else if (basketItemId !== undefined)
            url_ += "basketItemId=" + encodeURIComponent("" + basketItemId) + "&";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "DELETE",
            headers: {
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processRemoveItem(_response);
        });
    }

    protected processRemoveItem(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @param pageSize (optional)
     * @param pageIndex (optional)
     * @return Success
     */
    getCatalog(pageSize: number | undefined, pageIndex: number | undefined, api_version: string): Promise<CatalogDto[]> {
        let url_ = this.baseUrl + "/api/Catalog?";
        if (pageSize === null)
            throw new Error("The parameter 'pageSize' cannot be null.");
        else if (pageSize !== undefined)
            url_ += "pageSize=" + encodeURIComponent("" + pageSize) + "&";
        if (pageIndex === null)
            throw new Error("The parameter 'pageIndex' cannot be null.");
        else if (pageIndex !== undefined)
            url_ += "pageIndex=" + encodeURIComponent("" + pageIndex) + "&";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGetCatalog(_response);
        });
    }

    protected processGetCatalog(response: Response): Promise<CatalogDto[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as CatalogDto[];
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CatalogDto[]>(null as any);
    }

    /**
     * @return Success
     */
    getCatalogItemById(id: string, api_version: string): Promise<CatalogDto> {
        let url_ = this.baseUrl + "/api/Catalog/{id}?";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGetCatalogItemById(_response);
        });
    }

    protected processGetCatalogItemById(response: Response): Promise<CatalogDto> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as CatalogDto;
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<CatalogDto>(null as any);
    }

    /**
     * @param body (optional)
     * @return Success
     */
    createBrand(api_version: string, body: CatalogBrandDto | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/Catalog/brands?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processCreateBrand(_response);
        });
    }

    protected processCreateBrand(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @param body (optional)
     * @return Success
     */
    createType(api_version: string, body: CatalogTypeDto | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/Catalog/types?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processCreateType(_response);
        });
    }

    protected processCreateType(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @param body (optional)
     * @return Success
     */
    createItem(api_version: string, body: CreateCatalogItemDto | undefined): Promise<void> {
        let url_ = this.baseUrl + "/api/Catalog/items?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_: RequestInit = {
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processCreateItem(_response);
        });
    }

    protected processCreateItem(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @return Success
     */
    getOrders(api_version: string): Promise<Order[]> {
        let url_ = this.baseUrl + "/api/Order/orders?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGetOrders(_response);
        });
    }

    protected processGetOrders(response: Response): Promise<Order[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as Order[];
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Order[]>(null as any);
    }

    /**
     * @return Success
     */
    createOrder(api_version: string): Promise<void> {
        let url_ = this.baseUrl + "/api/Order/orders?";
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "POST",
            headers: {
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processCreateOrder(_response);
        });
    }

    protected processCreateOrder(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(null as any);
    }

    /**
     * @return Success
     */
    getOrder(id: string, api_version: string): Promise<OrderItem[]> {
        let url_ = this.baseUrl + "/api/Order/orders/{id}?";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        if (api_version === undefined || api_version === null)
            throw new Error("The parameter 'api_version' must be defined and cannot be null.");
        else
            url_ += "api-version=" + encodeURIComponent("" + api_version) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_: RequestInit = {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.transformOptions(options_).then(transformedOptions_ => {
            return this.http.fetch(url_, transformedOptions_);
        }).then((_response: Response) => {
            return this.processGetOrder(_response);
        });
    }

    protected processGetOrder(response: Response): Promise<OrderItem[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                result200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver) as OrderItem[];
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<OrderItem[]>(null as any);
    }
}

export interface BasketItem {
    id?: string;
    catalogItemId?: string;
    unitPrice?: number;
    quantity?: number;
    totalPrice?: number;
    customerBasketId?: string;
    customerBasket?: CustomerBasket;
}

export interface CatalogBrandDto {
    brandName?: string | undefined;
}

export interface CatalogDto {
    typeName?: string | undefined;
    brandName?: string | undefined;
    itemName?: string | undefined;
    description?: string | undefined;
    price?: number;
}

export interface CatalogTypeDto {
    typeName?: string | undefined;
}

export interface CreateCatalogItemDto {
    name?: string | undefined;
    description?: string | undefined;
    price?: number;
    quantity?: number;
    catalogBrandId?: string;
    catalogTypeId?: string;
}

export interface CustomerBasket {
    id?: string;
    userId?: string;
    basketItems?: BasketItem[] | undefined;
}

export interface Order {
    id?: string;
    userId?: string;
    totalPrice?: number;
}

export interface OrderItem {
    id?: string;
    catalogItemId?: string;
    unitPrice?: number;
    quantity?: number;
    totalPrice?: number;
    orderId?: string;
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}