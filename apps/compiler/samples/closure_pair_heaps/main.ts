type Heap0 = { readonly l0: number, readonly l1: string };
function f_c0(v0: Heap0, v1: Heap0): ((a0: number) => [Heap0, Heap0]) {
    return (v2: number): [Heap0, Heap0] => {
        return [v0, v1];
    };
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 4;
    const v4: string = "yo";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: ((a0: number) => [Heap0, Heap0]) = f_c0(v2, v5);
    let [v7, v8]: [Heap0, Heap0] = v6(1);
    const v9: number = v7.l0;
    const v10: string = v7.l1;
    const v11: number = v8.l0;
    const v12: string = v8.l1;
    const v13: boolean = v9 === 7;
    let v15: boolean;
    if (v13) {
        const v14: boolean = v10 === "hi";
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        const v16: boolean = v11 === 4;
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        const v18: boolean = v12 === "yo";
        v19 = v18;
    } else {
        v19 = false;
    }
    if (v19) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
