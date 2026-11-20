function f_c0(v0: Array<number>): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = v0.length;
        const v3: number = (v2 + v1) | 0;
        return v3;
    };
}
export function main(): number {
    const v0: Array<number> = new Array<number>(2).fill(0);
    const v1: ((a0: number) => number) = f_c0(v0);
    return v1(40);
}
process.exitCode = main();
