function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap0, readonly f1: Heap0, readonly f2: Heap0 };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Heap0, f1: Heap0, f2: Heap0): US0 { return { tag: 1, f0: f0, f1: f1, f2: f2 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Heap0 = v0.f0;
            const v2: Heap0 = v0.f1;
            const v3: Heap0 = v0.f2;
            const v4: number = v1.l0;
            const v5: string = v1.l1;
            const v6: number = v2.l0;
            const v7: string = v2.l1;
            const v8: number = v3.l0;
            const v9: string = v3.l1;
            const v10: boolean = v4 === 7;
            let v12: boolean;
            if (v10) {
                const v11: boolean = v5 === "hi";
                v12 = v11;
            } else {
                v12 = false;
            }
            let v14: boolean;
            if (v12) {
                let v13: boolean = v6 === 4;
                v14 = v13;
            } else {
                v14 = false;
            }
            let v16: boolean;
            if (v14) {
                const v15: boolean = v7 === "yo";
                v16 = v15;
            } else {
                v16 = false;
            }
            let v18: boolean;
            if (v16) {
                const v17: boolean = v8 === 9;
                v18 = v17;
            } else {
                v18 = false;
            }
            let v20: boolean;
            if (v18) {
                const v19: boolean = v9 === "ok";
                v20 = v19;
            } else {
                v20 = false;
            }
            if (v20) {
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
    const v3: number = 4;
    const v4: string = "yo";
    const v5: Heap0 = { l0: v3, l1: v4 };
    const v6: number = 9;
    const v7: string = "ok";
    const v8: Heap0 = { l0: v6, l1: v7 };
    const v9: Array<US0> = new Array<US0>(1).fill(undefined as unknown as US0);
    const v10: boolean = true;
    let v13: US0;
    if (v10) {
        v13 = US0_Held(v2, v5, v8);
    } else {
        v13 = US0_None();
    }
    spiral_array_set(v9, 0, v13);
    let v14: US0 = spiral_array_index(v9, 0);
    return score_0(v14);
}
process.exitCode = main();
