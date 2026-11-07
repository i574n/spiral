import { test, expect } from "@playwright/test";

test("test", async ({ browser }) => {
  const context = await browser.newContext({ ignoreHTTPSErrors: true });
  const page = await context.newPage();
  await page.goto("https://localhost:5000/");

  await expect(page).toHaveTitle("");
});
