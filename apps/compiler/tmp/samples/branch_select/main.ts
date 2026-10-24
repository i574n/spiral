export function main(): number {
    const v0: number = 5;
    const v1: boolean = v0 === 5;
    if (v1) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
