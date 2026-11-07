type Heap0 = { readonly l0: number };
function f_c0(v0: number, v1: Heap0): ((a0: number) => [Heap0, number]) {
    return (v2: number): [Heap0, number] => {
        const v3: boolean = v2 === 0;
        if (v3) {
            return [v1, 0];
        } else {
            return [v1, v0];
        }
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: Heap0 = { l0: v0 };
    const v3: ((a0: number) => [Heap0, number]) = f_c0(v1, v2);
    let [v4, v5]: [Heap0, number] = v3(1);
    const v6: number = v4.l0;
    const v7: number = (v6 + v5) | 0;
    const v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
