type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 1;
    let v4: Heap1 = { l0: v2, l1: v3 };
    let v5: Heap0 = v4.l0;
    let v6: number = v4.l1;
    let v7: number = v5.l0;
    let v8: string = v5.l1;
    let v9: boolean = v7 === 7;
    let v11: boolean;
    if (v9) {
        let v10: boolean = v8 === "hi";
        v11 = v10;
    } else {
        v11 = false;
    }
    let v13: boolean;
    if (v11) {
        let v12: boolean = v6 === 1;
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
