import { Component, Prop, State, h } from '@stencil/core';
//import { timeStamp } from 'console';
import { isNil } from 'lodash';

@Component({
  tag: 'audit-unit-properties',
  styleUrl: 'audit-unit-properties.css',
  shadow: true,
})
export class AuditUnitProperties {
  @Prop() name: string;
  @Prop() parentid: string;
  @Prop() date: string;
  @Prop() open = false;
  @State() modalOpen: boolean = false;

  constructor() {
    this.closeProperties = this.closeProperties.bind(this);
  }

  closeProperties(_event: any) {
    //console.log(event.target);
    this.open = false;
  }

  render() {
    this.modalOpen = this.open;
    if (!this.modalOpen || isNil(this.modalOpen)) return null;
    console.log(this.date);
    return (
      <div class="modal">
        <div class="modal-content">
          <span id="close" onClick={this.closeProperties}>
            x
          </span>
          <table class="tbl">
            <tr>
              <td class="lbl txt">Name</td>
              <td class="txt">{this.name}</td>
            </tr>
            <tr>
              <td class="lbl txt">ParentAuditUnitId</td>
              <td class="txt">{this.parentid}</td>
            </tr>
            <tr>
              <td class="lbl txt">Created On</td>
              <td class="txt">{new Date(this.date).toDateString()}</td>
            </tr>
          </table>
        </div>
      </div>
    );
  }
}
