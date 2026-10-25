export function main(): number {
    let v0: number = 7;
    let v1: number = Math.imul(v0, 2);
    let v2: boolean = v1 !== 14;
    if (v2) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
