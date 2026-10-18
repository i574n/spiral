export function main(): number {
    let v0: number = 7;
    let v1: number = 5;
    let v2: number = v1 * 2;
    let v3: number = v0;
    let v4: number = (v2 + v3) | 0;
    return v4;
}
process.exitCode = main();
