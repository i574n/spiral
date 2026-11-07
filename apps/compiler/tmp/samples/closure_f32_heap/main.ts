type Heap0 = { readonly l0: number, readonly l1: string };
function f_c0(v0: Heap0): ((a0: number) => Heap0) {
    return (v1: number): Heap0 => {
        return v0;
    };
}
export function main(): number {
    const v0: number = 1.5;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: ((a0: number) => Heap0) = f_c0(v2);
    const v4: Heap0 = v3(1);
    const v5: number = v4.l0;
    const v6: string = v4.l1;
    const v7: boolean = v5 === 1.5;
    let v9: boolean;
    if (v7) {
        const v8: boolean = v6 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    if (v9) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
