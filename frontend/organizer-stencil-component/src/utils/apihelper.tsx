import appSettings from '../configurations/appSettings.json';
import { isNil } from 'lodash';

export const apihelper = {
  url: appSettings.bffApiUrl,

  _getRequestHeaders() {
    return new Headers({
      Accept: 'application/json',
      Authorization: 'bearer ' + getIdToken(),
    });
  },

  _handleError(_res: any) {
    return _res.ok && !isNil(_res) ? _res : Promise.reject(_res.statusText);
  },

  _handlApiResponse(_res: any) {
    if (isNil(_res) || _res.isSuccessful === false) console.error(_res.responseMessage);

    return _res;
  },

  _handleContentType(_response: any) {
    const contentType = _response.headers.get('content-type');

    if (contentType && contentType.includes('application/json')) {
      return _response.json();
    }

    return Promise.reject("Oops, we haven't got JSON!");
  },

  get(_endpoint: string) {
    return window
      .fetch(this.url + _endpoint, {
        method: 'GET',
        headers: this._getRequestHeaders(),
      })
      .then(this._handleError)
      .then(this._handleContentType)
      .then(this._handlApiResponse)
      .catch(error => console.error(error));
  },

  post(_endpoint: string, _body: any) {
    return window
      .fetch(this.url + _endpoint, {
        method: 'POST',
        headers: this._getRequestHeaders(),
        body: _body,
      })
      .then(this._handleError)
      .then(this._handleContentType)
      .then(this._handlApiResponse)
      .catch(error => console.error(error));
  },

  delete(_endpoint: string, _body: any) {
    return window
      .fetch(this.url + _endpoint, {
        method: 'DELETE',
        headers: this._getRequestHeaders(),
        body: _body,
      })
      .then(this._handleError)
      .then(this._handleContentType)
      .then(this._handlApiResponse)
      .catch(error => console.error(error));
  },
};

function getIdToken() {
  return 'eyJ0eXAiOiJKV1QiLCJraWQiOiJiL082T3ZWdjEreStXZ3JINVVpOVdUaW9MdDA9IiwiYWxnIjoiUlMyNTYifQ.eyJhdF9oYXNoIjoiOXM2X2VINVM4UXN6blNIS2txZzJYUSIsInN1YiI6InZraGFubmEwMDciLCJhdWRpdFRyYWNraW5nSWQiOiJlZGY2Mjk2OC0xNjc1LTQ1MTEtYTI1ZC1kNzA0MGM5NTdjYzQtMTA4OTYzNjIiLCJjb3VudHJ5Y29kZSI6IlVTIiwiaXNzIjoiaHR0cHM6Ly9sb2dpbi1zdGcucHdjLmNvbTo0NDMvb3BlbmFtL29hdXRoMiIsInRva2VuTmFtZSI6ImlkX3Rva2VuIiwidWlkIjoidmtoYW5uYTAwNyIsImFjciI6IjQiLCJhenAiOiJ1cm46YXVyYTp1czpkZXZxYSIsImF1dGhfdGltZSI6MTYyNjQ5MjM2MywiZXhwIjoxNjI2NTI4MzY0LCJpYXQiOjE2MjY0OTIzNjQsImVtYWlsIjoidmlqaXQua2hhbm5hQHVzLnB3Yy5jb20iLCJnaXZlbl9uYW1lIjoiVmlqaXQiLCJub25jZSI6IjEyMyIsInByZWZlcnJlZE1haWwiOiJ2aWppdC5raGFubmFAcHdjLmNvbSIsImF1ZCI6InVybjphdXJhOnVzOmRldnFhIiwidXBuIjoidmlqaXQua2hhbm5hQHVzLnB3Yy5jb20iLCJvcmcuZm9yZ2Vyb2NrLm9wZW5pZGNvbm5lY3Qub3BzIjoiZzM2QkdmWktnTnBXb2YwWHNFZm9jWjlwOEZNIiwic19oYXNoIjoienV6NGp5ekJwa3pDS0tlUmxmS2hSUSIsIm5hbWUiOiJWaWppdCBLaGFubmEiLCJyZWFsbSI6Ii9wd2MiLCJ0b2tlblR5cGUiOiJKV1RUb2tlbiIsImZhbWlseV9uYW1lIjoiS2hhbm5hIn0.oAazM4cxGyH3lZRyiKcYz9o88MHHQ8sZSvLD3ucjTZ6PjfeAp0NxCdygzHEet-gXLJCbhNO0Af9iy8JPplh20FCM-fFCCV_Un8XhzCND-8E6_u7OmXmNOwFmTU1Udv1jhVDUMi465dQvUW3gB566vCnEAKl4URCysuHhJ3nZh48dz8VJJyBby1f8Otlf-x-1NATHI8eg-ZJ_WXbzUgVoav9v4A4c2yJJojBk-HtofEPBuG2BvA1ZVGn5Hxk0cRp_BWLer4EhDp7RVFp9QnWOj2x9R0VfgVYkR9qhtCo6aRQprB7Yryf3jfVeO8v2nUZCqhEa3dKYIHkdYev5Y1QSgw';
}
