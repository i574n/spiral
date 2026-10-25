function closure1(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = Math.imul(v0, 10);
        const v3: number = (v2 + v1) | 0;
        return v3;
    };
}
function f_c0(): ((a0: number) => ((a0: number) => number)) {
    return (v0: number): ((a0: number) => number) => {
        return closure1(v0);
    };
}
export function main(): number {
    const v0: ((a0: number) => ((a0: number) => number)) = f_c0();
    const v1: ((a0: number) => number) = v0(3);
    const v2: number = v1(4);
    const v3: boolean = v2 === 34;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
