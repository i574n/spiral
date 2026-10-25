function method0(v0: number, v1: number): number {
    let v2: number = (v0 + v1) | 0;
    let v3: number = (v2 - 42) | 0;
    return v3;
}
export function main(): number {
    let v0: number = 20;
    let v1: number = 22;
    return method0(v0, v1);
}
process.exitCode = main();
