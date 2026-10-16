type Heap0 = { readonly l0: number };
function method0(v0: Heap0): Heap0 {
    return v0;
}
export function main(): number {
    let v0: number = 7;
    let v1: Heap0 = { l0: v0 };
    let v2: Heap0 = method0(v1);
    let v3: number = v2.l0;
    let v4: boolean = v3 === 7;
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
