type Heap0 = { readonly l0: number };
function f_c0(v0: number, v1: Heap0): ((a0: number) => [Heap0, number]) {
    return (v2: number): [Heap0, number] => {
        let v3: boolean = v2 === 0;
        if (v3) {
            return [v1, 0];
        } else {
            return [v1, v0];
        }
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: Heap0 = { l0: v0 };
    let v3: ((a0: number) => [Heap0, number]) = f_c0(v1, v2);
    let [v4, v5]: [Heap0, number] = v3(1);
    let v6: number = v4.l0;
    let v7: number = (v6 + v5) | 0;
    let v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
