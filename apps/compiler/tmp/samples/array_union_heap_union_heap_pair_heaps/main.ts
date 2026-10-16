function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Heap0 = { readonly l0: number, readonly l1: string };
type Heap1 = { readonly l0: Heap0, readonly l1: Heap0 };
type Heap2 = { readonly l0: Heap1, readonly l1: number };
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Heap2 };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Heap2): US0 { return { tag: 1, f0: f0 }; }
type Heap3 = { readonly l0: US0 };
type US1_Absent = { readonly tag: 0 };
type US1_Box = { readonly tag: 1, readonly f0: Heap3 };
type US1 = US1_Absent | US1_Box;
function US1_Absent(): US1 { return { tag: 0 }; }
function US1_Box(f0: Heap3): US1 { return { tag: 1, f0: f0 }; }
function score_0(v0: US1): number {
    switch (v0.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v1: Heap3 = v0.f0;
            let v2: US0 = v1.l0;
            switch (v2.tag) {
                case 1: {
                    let v3: Heap2 = v2.f0;
                    let v4: Heap1 = v3.l0;
                    let v5: number = v3.l1;
                    let v6: Heap0 = v4.l0;
                    let v7: Heap0 = v4.l1;
                    let v8: number = v6.l0;
                    let v9: string = v6.l1;
                    let v10: number = v7.l0;
                    let v11: string = v7.l1;
                    let v12: boolean = v8 === 7;
                    let v14: boolean;
                    if (v12) {
                        let v13: boolean = v9 === "hi";
                        v14 = v13;
                    } else {
                        v14 = false;
                    }
                    let v16: boolean;
                    if (v14) {
                        let v15: boolean = v10 === 4;
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    let v18: boolean;
                    if (v16) {
                        let v17: boolean = v11 === "yo";
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    let v20: boolean;
                    if (v18) {
                        let v19: boolean = v5 === 2;
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
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: number = 7;
    let v1: string = "hi";
    let v2: Heap0 = { l0: v0, l1: v1 };
    let v3: number = 4;
    let v4: string = "yo";
    let v5: Heap0 = { l0: v3, l1: v4 };
    let v6: Heap1 = { l0: v2, l1: v5 };
    let v7: number = 2;
    let v8: Heap2 = { l0: v6, l1: v7 };
    let v9: boolean = true;
    let v12: US0;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    let v13: Heap3 = { l0: v12 };
    let v14: boolean = true;
    let v17: US1;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Absent();
    }
    let v18: Array<US1> = new Array<US1>(1).fill(undefined as unknown as US1);
    spiral_array_set(v18, 0, v17);
    let v19: US1 = spiral_array_index(v18, 0);
    return score_0(v19);
}
process.exitCode = main();
