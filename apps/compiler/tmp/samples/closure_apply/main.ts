function f_c0(): ((a0: number) => number) {
    return (v0: number): number => {
        const v1: number = (v0 + 1) | 0;
        return v1;
    };
}
export function main(): number {
    const v0: ((a0: number) => number) = f_c0();
    const v1: number = v0(6);
    const v2: boolean = v1 === 7;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
