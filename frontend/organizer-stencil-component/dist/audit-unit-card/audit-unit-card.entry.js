import { r as registerInstance, h } from './index-8a61f05f.js';
import { l as lodash } from './lodash-99975bff.js';

const bffApiUrl = "http://localhost:5001";
const appSettings = {
	bffApiUrl: bffApiUrl
};

const apihelper = {
  url: appSettings.bffApiUrl,
  _getRequestHeaders() {
    return new Headers({
      Accept: 'application/json',
      Authorization: 'bearer ' + getIdToken(),
    });
  },
  _handleError(_res) {
    return _res.ok && !lodash.isNil(_res) ? _res : Promise.reject(_res.statusText);
  },
  _handlApiResponse(_res) {
    if (lodash.isNil(_res) || _res.isSuccessful === false)
      console.error(_res.responseMessage);
    return _res;
  },
  _handleContentType(_response) {
    const contentType = _response.headers.get('content-type');
    if (contentType && contentType.includes('application/json')) {
      return _response.json();
    }
    return Promise.reject("Oops, we haven't got JSON!");
  },
  get(_endpoint) {
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
  post(_endpoint, _body) {
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
  delete(_endpoint, _body) {
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

function format(first, middle, last) {
  return (first || '') + (middle ? ` ${middle}` : '') + (last ? ` ${last}` : '');
}
function getAuditUnits() {
  return apihelper.get('/ng-bff-api/engagements/get-audit-units');
}
;

const auditUnitCardCss = ".flex-container{display:inline-flex;flex-flow:row wrap;justify-content:space-evenly;padding:20px;margin:10px;list-style:none}.flex-item{background:grey;padding:px;width:300px;height:130px;margin-top:10px;line-height:20px;color:white;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;font-weight:bold;font-size:15px;text-align:center;align-self:center;padding-top:60px;text-overflow:ellipsis}.span-item{font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;font-size:10px}";

const AuditUnitCard = class {
  constructor(hostRef) {
    registerInstance(this, hostRef);
    this.showModal = this.showModal.bind(this);
  }
  async componentWillLoad() {
    try {
      var response = await getAuditUnits();
      this.auditUnits = response.auditUnits;
      this.auditUnits.forEach((a) => (a.isModalOpen = false));
      //console.error(this.isModalOpen);
    }
    catch (error) {
      console.log(error);
    }
  }
  render() {
    if (this.auditUnits == null)
      return null;
    console.table(this.auditUnits);
    return (h("div", { class: "audit-unit-card" }, h("h1", null, "Organizer"), h("ul", { class: "flex-container" }, this.auditUnits.map((au) => (h("li", null, h("div", { class: "flex-item" }, "Name: ", au.name, h("br", null), h("span", { id: au.auditUnitId, class: "span-item", onClick: this.showModal }, au.auditUnitId), h("audit-unit-properties", { name: au.name, parentid: au.parentAuditUnitId, date: au.lastModifiedOn, open: au.isModalOpen }))))))));
  }
  showModal(event) {
    var auditUnit = event.currentTarget;
    var newAuditUnits = [];
    this.auditUnits.forEach((au) => {
      au.isModalOpen = au.auditUnitId === auditUnit.id && !au.isModalOpen;
      newAuditUnits.push(au);
    });
    this.auditUnits = newAuditUnits;
  }
};
AuditUnitCard.style = auditUnitCardCss;

export { AuditUnitCard as audit_unit_card };
