function g_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: boolean = v0 === 0;
        if (v2) {
            return 0;
        } else {
            const v3: number = (v1 + v0) | 0;
            return v3;
        }
    };
}
function method0(v0: number): ((a0: number) => number) {
    return g_c0(v0);
}
export function main(): number {
    const v0: number = 7;
    const v1: ((a0: number) => number) = method0(v0);
    const v2: number = v1(0);
    const v3: boolean = v2 === 7;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
