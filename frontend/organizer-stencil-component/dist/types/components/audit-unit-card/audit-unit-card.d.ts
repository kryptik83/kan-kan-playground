export interface AuditUnit {
  name: string;
  engagemetId: string;
  parentAuditUnitId?: string;
  auditUnitId: string;
  lastModified: string;
  isModalOpen: boolean;
}
export declare class AuditUnitCard {
  engagementId: string;
  auditUnits: any[];
  constructor();
  componentWillLoad(): Promise<void>;
  render(): any;
  showModal(event: MouseEvent): void;
}
