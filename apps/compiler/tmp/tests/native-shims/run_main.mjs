// Native-tier runner for the TypeScript backend (scripts/test.ps1 -Native, TypeScript rows).
// Runs a generated main.ts in a worker thread with a large stack: C fixtures recurse on an 8 MB+ stack and the Rust
// backend's runner uses a 1 GB thread, while Node's main thread overflows at about 10k frames. The generated module
// ends with `process.exitCode = main();`; inside a worker that becomes the worker's exit code, which is passed on
// (negative codes included, as C's on Windows). An uncaught error (failwith, a bounds check) exits with 1, as C's
// exit(EXIT_FAILURE).
// Usage: node --experimental-strip-types --no-warnings run_main.mjs <main.ts> [stackSizeMb]
import { Worker } from "node:worker_threads";
import { pathToFileURL } from "node:url";
import { resolve } from "node:path";

const worker = new Worker(pathToFileURL(resolve(process.argv[2])), {
    resourceLimits: { stackSizeMb: Number(process.argv[3] ?? 1024) },
});
worker.on("error", (error) => {
    console.error(error);
    process.exitCode = 1;
});
worker.on("exit", (code) => {
    if (process.exitCode === undefined) process.exitCode = code;
});
