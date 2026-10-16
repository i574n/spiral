type Heap0 = { readonly l0: number };
function g_c1(v0: Heap0, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: number = v0.l0;
        let v4: boolean = v1 === 0;
        if (v4) {
            return 0;
        } else {
            return v3;
        }
    };
}
function f_c0(v0: Heap0): ((a0: number) => ((a0: number) => number)) {
    return (v1: number): ((a0: number) => number) => {
        return g_c1(v0, v1);
    };
}
export function main(): number {
    let v0: number = 7;
    let v1: Heap0 = { l0: v0 };
    let v2: ((a0: number) => ((a0: number) => number)) = f_c0(v1);
    let v3: ((a0: number) => number) = v2(1);
    let v4: number = v3(0);
    let v5: boolean = v4 === 7;
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
