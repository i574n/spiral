export function main(): number {
    const v0: number = 6;
    const v1: number = 7;
    const v2: number = Math.imul(v0, v1);
    const v3: boolean = v2 === 42;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
