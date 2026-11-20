export function main(): number {
    const v0: number = 42;
    const v1: number = (v0 - 42) | 0;
    return v1;
}
process.exitCode = main();
