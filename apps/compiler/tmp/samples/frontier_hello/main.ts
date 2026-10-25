export function main(): number {
    let v0: number = 42;
    let v1: number = (v0 - 42) | 0;
    return v1;
}
process.exitCode = main();
