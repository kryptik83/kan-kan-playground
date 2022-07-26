import { apihelper } from "./apihelper";

export function format(first: string, middle: string, last: string): string {
  return (first || '') + (middle ? ` ${middle}` : '') + (last ? ` ${last}` : '');
}


export function getAuditUnits(): any{
   return apihelper.get('/ng-bff-api/engagements/get-audit-units');
};
