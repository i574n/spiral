export function main(): number {
    const v1: number = 42;
    const v3: number = (v1 - 42) | 0;
    return v3;
}
process.exitCode = main();
