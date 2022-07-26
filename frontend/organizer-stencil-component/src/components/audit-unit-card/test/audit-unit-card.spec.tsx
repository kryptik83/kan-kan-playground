import { newSpecPage } from '@stencil/core/testing';
import { AuditUnitCard } from '../audit-unit-card';

describe('audit-unit-card', () => {
  it('renders', async () => {
    const page = await newSpecPage({
      components: [AuditUnitCard],
      html: `<audit-unit-card></audit-unit-card>`,
    });
    expect(page.root).toEqualHtml(`
      <audit-unit-card>
        <mock:shadow-root>
          <slot></slot>
        </mock:shadow-root>
      </audit-unit-card>
    `);
  });
});
