export function main(): number {
    const v0: number = 7;
    const v1: number = 5;
    const v2: number = v1 * 2;
    const v3: number = v0;
    const v4: number = (v2 + v3) | 0;
    return v4;
}
process.exitCode = main();
