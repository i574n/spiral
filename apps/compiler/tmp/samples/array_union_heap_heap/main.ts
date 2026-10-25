function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap1 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap1): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Heap1 = v0.f0;
            const v2: Heap0 = v1.l0;
            const v3: number = v1.l1;
            const v4: number = v2.l0;
            const v5: string = v2.l1;
            const v6: boolean = v4 === 7;
            let v8: boolean;
            if (v6) {
                const v7: boolean = v5 === "hi";
                v8 = v7;
            } else {
                v8 = false;
            }
            let v10: boolean;
            if (v8) {
                let v9: boolean = v3 === 1;
                v10 = v9;
            } else {
                v10 = false;
            }
            if (v10) {
                return 0;
            } else {
                return 1;
            }
            break;
        }
        case 0: {
            return 1;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: Heap0 = { l0: v0, l1: v1 };
    const v3: number = 1;
    const v4: Heap1 = { l0: v2, l1: v3 };
    const v5: Array<US0> = new Array<US0>(1).fill(undefined as unknown as US0);
    const v6: boolean = true;
    let v9: US0;
    if (v6) {
        v9 = US0_Held(v4);
    } else {
        v9 = US0_None();
    }
    spiral_array_set(v5, 0, v9);
    let v10: US0 = spiral_array_index(v5, 0);
    return score_0(v10);
}
process.exitCode = main();
