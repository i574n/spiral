function method0(v0: number, v1: number, v2: number): number {
    const v3: number = Math.imul(v0, v1);
    const v4: number = (v3 + v2) | 0;
    const v5: number = (v4 - 42) | 0;
    return v5;
}
export function main(): number {
    const v0: number = 5;
    const v1: number = 8;
    const v2: number = 2;
    return method0(v0, v1, v2);
}
process.exitCode = main();
