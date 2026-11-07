export function main(): number {
    const v0: number = 1;
    const v1: boolean = v0 === 1;
    if (v1) {
        throw new Error("bo$om");
    } else {
        return 0;
    }
}
process.exitCode = main();
