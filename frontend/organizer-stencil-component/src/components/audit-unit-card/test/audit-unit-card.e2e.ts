import { newE2EPage } from '@stencil/core/testing';

describe('audit-unit-card', () => {
  it('renders', async () => {
    const page = await newE2EPage();
    await page.setContent('<audit-unit-card></audit-unit-card>');

    const element = await page.find('audit-unit-card');
    expect(element).toHaveClass('hydrated');
  });
});
