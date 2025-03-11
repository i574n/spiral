import { test, expect } from "@playwright/test";

test("test", async ({ page }) => {
  await page.goto("https://localhost:5000/");

  await expect(page).toHaveTitle("");
});
