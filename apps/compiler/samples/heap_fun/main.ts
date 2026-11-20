type Heap0 = { readonly l0: ((a0: number) => number), readonly l1: number };
function add_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: number = (v1 + v0) | 0;
        return v2;
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: ((a0: number) => number) = add_c0(v0);
    const v3: Heap0 = { l0: v2, l1: v1 };
    const v4: ((a0: number) => number) = v3.l0;
    const v5: number = v3.l1;
    const v6: number = v4(0);
    const v7: number = (v6 + v5) | 0;
    const v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
