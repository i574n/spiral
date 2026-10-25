type Heap0 = { readonly l0: number, readonly l1: number };
export function main(): number {
    let v0: number = 1.5;
    let v1: number = 4000000000;
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = v2.l0;
    let v4: number = v2.l1;
    let v5: boolean = v3 === 1.5;
    let v7: boolean;
    if (v5) {
        let v6: boolean = v4 === 4000000000;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
