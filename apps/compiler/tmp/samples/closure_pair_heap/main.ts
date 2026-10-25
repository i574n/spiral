type Heap0 = { readonly l0: number };
function f_c0(v0: Heap0, v1: Heap0): ((a0: number) => [Heap0, Heap0]) {
    return (v2: number): [Heap0, Heap0] => {
        let v3: boolean = v2 === 0;
        if (v3) {
            return [v1, v0];
        } else {
            return [v0, v1];
        }
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: Heap0 = { l0: v0 };
    let v3: Heap0 = { l0: v1 };
    let v4: ((a0: number) => [Heap0, Heap0]) = f_c0(v2, v3);
    let [v5, v6]: [Heap0, Heap0] = v4(1);
    let v7: number = v5.l0;
    let v8: number = v6.l0;
    let v9: number = (v7 + v8) | 0;
    let v10: boolean = v9 === 7;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
