export function main(): number {
    const v0: number = 6;
    const v1: number = 7;
    const v2: number = (v0 + v1) | 0;
    return v2;
}
process.exitCode = main();
