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
