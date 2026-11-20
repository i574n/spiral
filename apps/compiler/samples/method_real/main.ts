function method0(v0: number): number {
    const v1: boolean = v0 === 0;
    if (v1) {
        return 0;
    } else {
        return 1.5;
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: number = method0(v0);
    const v2: boolean = v1 === 1.5;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
