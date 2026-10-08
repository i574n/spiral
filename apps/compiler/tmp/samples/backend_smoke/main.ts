export function main(): number {
    let v0: number = 6;
    let v1: number = 7;
    let v2: number = (v0 + v1) | 0;
    return v2;
}
process.exitCode = main();
