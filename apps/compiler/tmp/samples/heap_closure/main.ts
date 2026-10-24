type Heap0 = { readonly l0: ((a0: number) => number) };
function f_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = (v1 + v0) | 0;
        return v2;
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: ((a0: number) => number) = f_c0(v0);
    const v2: Heap0 = { l0: v1 };
    const v3: ((a0: number) => number) = v2.l0;
    const v4: number = v3(4);
    const v5: boolean = v4 === 7;
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
