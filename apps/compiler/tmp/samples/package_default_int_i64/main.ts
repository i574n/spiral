export function main(): number {
    let v0: bigint = 3000000000n;
    let v1: boolean = v0 > 2999999999n;
    if (v1) {
        return 7;
    } else {
        return 0;
    }
}
process.exitCode = main();
