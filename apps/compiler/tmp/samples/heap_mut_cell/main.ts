type Mut0 = { l0: number, l1: string };
type Heap0 = { readonly l0: Mut0 };
export function main(): number {
    let v0: number = 3;
    let v1: string = "no";
    let v2: Mut0 = { l0: v0, l1: v1 };
    let v3: Heap0 = { l0: v2 };
    let v4: Mut0 = v3.l0;
    let v5: number = 7;
    let v6: string = "hi";
    v4.l0 = v5;
    v4.l1 = v6;
    let v7: number = v4.l0;
    let v8: string = v4.l1;
    let v9: boolean = v7 === 7;
    let v11: boolean;
    if (v9) {
        let v10: boolean = v8 === "hi";
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
