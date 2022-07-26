import { r as registerInstance, h } from './index-8a61f05f.js';
import { l as lodash } from './lodash-99975bff.js';

const auditUnitPropertiesCss = ".modal{display:block;position:fixed;z-index:1;left:0;top:0;width:100%;height:100%;overflow:auto;background-color:rgb(0, 0, 0);background-color:rgba(0, 0, 0, 0.4);}.modal-content{background-color:#fefefe;margin:15% auto;padding:20px;border:1px solid #888;width:50%;height:40%;font-size:20px;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif}.close{color:#aaa;float:right;font-size:28px;font-weight:bold}.close:hover,.close:focus{color:black;text-decoration:none;cursor:pointer}.txt{font-size:12px;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;color:black}.tbl{border:grey solid 1px;padding:10px}.tbl tr td{border:grey solid 2 px;padding:0px;padding-right:50px;align-items:center}#close{display:inline-block;padding:2px 5px;background:#ccc;float:right}#close:hover{cursor:pointer;display:inline-block;padding:2px 5px;background:darkgray;color:black;float:right}";

const AuditUnitProperties = class {
  constructor(hostRef) {
    registerInstance(this, hostRef);
    this.open = false;
    this.modalOpen = false;
    this.closeProperties = this.closeProperties.bind(this);
  }
  closeProperties(_event) {
    //console.log(event.target);
    this.open = false;
  }
  render() {
    this.modalOpen = this.open;
    if (!this.modalOpen || lodash.isNil(this.modalOpen))
      return null;
    console.log(this.date);
    return (h("div", { class: "modal" }, h("div", { class: "modal-content" }, h("span", { id: "close", onClick: this.closeProperties }, "x"), h("table", { class: "tbl" }, h("tr", null, h("td", { class: "lbl txt" }, "Name"), h("td", { class: "txt" }, this.name)), h("tr", null, h("td", { class: "lbl txt" }, "ParentAuditUnitId"), h("td", { class: "txt" }, this.parentid)), h("tr", null, h("td", { class: "lbl txt" }, "Created On"), h("td", { class: "txt" }, new Date(this.date).toDateString()))))));
  }
};
AuditUnitProperties.style = auditUnitPropertiesCss;

export { AuditUnitProperties as audit_unit_properties };
