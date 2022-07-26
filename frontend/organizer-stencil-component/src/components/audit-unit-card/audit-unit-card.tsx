import { Component, Prop, h, State } from "@stencil/core";
import { getAuditUnits } from "../../utils/utils";

export interface AuditUnit {
  name: string;
  engagemetId: string;
  parentAuditUnitId?: string;
  auditUnitId: string;
  lastModified: string;
  isModalOpen: boolean;
}

@Component({
  tag: "audit-unit-card",
  styleUrl: "audit-unit-card.css",
  shadow: true,
})
export class AuditUnitCard {
  @Prop() engagementId: string;
  @State() auditUnits: any[];

  constructor() {
    this.showModal = this.showModal.bind(this);
  }

  async componentWillLoad() {
    try {
      var response = await getAuditUnits();
      this.auditUnits = response.auditUnits;
      this.auditUnits.forEach((a) => (a.isModalOpen = false));
      //console.error(this.isModalOpen);
    } catch (error) {
      console.log(error);
    }
  }

  render() {
    if (this.auditUnits == null) return null;
    console.table(this.auditUnits);

    return (
      <div class="audit-unit-card">
        <h1>Organizer</h1>
        <ul class="flex-container">
          {this.auditUnits.map((au) => (
            <li>
              <div class="flex-item">
                Name: {au.name}
                <br />
                <span
                  id={au.auditUnitId}
                  class="span-item"
                  onClick={this.showModal}
                >
                  {au.auditUnitId}
                </span>
                <audit-unit-properties
                  name={au.name}
                  parentid={au.parentAuditUnitId}
                  date={au.lastModifiedOn}
                  open={au.isModalOpen}
                ></audit-unit-properties>
              </div>
            </li>
          ))}
        </ul>
      </div>
    );
  }
  showModal(event: MouseEvent) {
    var auditUnit = event.currentTarget as HTMLElement;
    var newAuditUnits: AuditUnit[] = [];
    this.auditUnits.forEach((au) => {
      au.isModalOpen = au.auditUnitId === auditUnit.id && !au.isModalOpen;
      newAuditUnits.push(au);
    });
    this.auditUnits = newAuditUnits;
  }
}
