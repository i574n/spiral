type Heap0 = { readonly l0: number };
function method0(v0: number, v1: Heap0): [Heap0, number] {
    return [v1, v0];
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v0 };
    let [v3, v4]: [Heap0, number] = method0(v1, v2);
    const v5: number = v3.l0;
    const v6: number = (v5 + v4) | 0;
    const v7: boolean = v6 === 7;
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
