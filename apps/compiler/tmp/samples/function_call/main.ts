function method0(v0: number, v1: number): number {
    const v2: number = (v0 + v1) | 0;
    const v3: number = (v2 - 42) | 0;
    return v3;
}
export function main(): number {
    const v0: number = 20;
    const v1: number = 22;
    return method0(v0, v1);
}
process.exitCode = main();
