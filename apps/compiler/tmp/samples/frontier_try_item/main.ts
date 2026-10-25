export function main(): number {
    let v1: number = 42;
    let v3: number = (v1 - 42) | 0;
    return v3;
}
process.exitCode = main();
