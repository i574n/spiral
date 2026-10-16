type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
function f_c0(v0: Heap1): ((a0: number) => Heap1) {
    return (v1: number): Heap1 => {
        return v0;
    };
}
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 1;
    let v4: Heap1 = { l0: v2, l1: v3 };
    let v5: ((a0: number) => Heap1) = f_c0(v4);
    let v6: Heap1 = v5(1);
    let v7: Heap0 = v6.l0;
    let v8: number = v6.l1;
    let v9: number = v7.l0;
    let v10: string = v7.l1;
    let v11: boolean = v9 === 7;
    let v13: boolean;
    if (v11) {
        let v12: boolean = v10 === "hi";
        v13 = v12;
    } else {
        v13 = false;
    }
    let v15: boolean;
    if (v13) {
        let v14: boolean = v8 === 1;
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
