type Heap0 = { readonly l0: number };
function f_c0(v0: Heap0, v1: Heap0): ((a0: number) => [Heap0, Heap0]) {
    return (v2: number): [Heap0, Heap0] => {
        const v3: boolean = v2 === 0;
        if (v3) {
            return [v1, v0];
        } else {
            return [v0, v1];
        }
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v0 };
    const v3: Heap0 = { l0: v1 };
    const v4: ((a0: number) => [Heap0, Heap0]) = f_c0(v2, v3);
    let [v5, v6]: [Heap0, Heap0] = v4(1);
    const v7: number = v5.l0;
    const v8: number = v6.l0;
    const v9: number = (v7 + v8) | 0;
    const v10: boolean = v9 === 7;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
