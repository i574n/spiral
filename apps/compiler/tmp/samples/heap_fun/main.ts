type Heap0 = { readonly l0: ((a0: number) => number), readonly l1: number };
function add_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        let v2: number = (v1 + v0) | 0;
        return v2;
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: ((a0: number) => number) = add_c0(v0);
    let v3: Heap0 = { l0: v2, l1: v1 };
    let v4: ((a0: number) => number) = v3.l0;
    let v5: number = v3.l1;
    let v6: number = v4(0);
    let v7: number = (v6 + v5) | 0;
    let v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
