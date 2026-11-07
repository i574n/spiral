export function main(): number {
    const v0: number = 20;
    const v1: number = 2;
    const v2: number = Math.imul(v0, v1);
    const v3: number = (v2 + 3) | 0;
    return v3;
}
process.exitCode = main();
