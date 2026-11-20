type Heap0 = { readonly l0: number };
function method0(v0: Heap0, v1: Heap0): [Heap0, Heap0] {
    return [v0, v1];
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v0 };
    const v3: Heap0 = { l0: v1 };
    let [v4, v5]: [Heap0, Heap0] = method0(v2, v3);
    const v6: number = v4.l0;
    const v7: number = v5.l0;
    const v8: number = (v6 + v7) | 0;
    const v9: boolean = v8 === 7;
    if (v9) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
