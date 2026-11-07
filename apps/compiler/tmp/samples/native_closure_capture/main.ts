function f_c0(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        const v3: number = (v0 + v1) | 0;
        const v4: number = (v3 + v2) | 0;
        return v4;
    };
}
export function main(): number {
    const v0: number = 1;
    const v1: number = 2;
    const v2: ((a0: number) => number) = f_c0(v0, v1);
    return v2(39);
}
process.exitCode = main();
