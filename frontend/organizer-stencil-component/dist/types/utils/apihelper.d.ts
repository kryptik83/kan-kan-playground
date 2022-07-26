export declare const apihelper: {
  url: string;
  _getRequestHeaders(): Headers;
  _handleError(_res: any): any;
  _handlApiResponse(_res: any): any;
  _handleContentType(_response: any): any;
  get(_endpoint: string): Promise<void | Response>;
  post(_endpoint: string, _body: any): Promise<void | Response>;
  delete(_endpoint: string, _body: any): Promise<void | Response>;
};
