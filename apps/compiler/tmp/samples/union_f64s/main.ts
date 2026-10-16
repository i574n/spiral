function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Missing = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Array<number> };
type US0 = US0_Missing | US0_Held;
function US0_Missing(): US0 { return { tag: 0 }; }
function US0_Held(f0: Array<number>): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    let v0: Array<number> = new Array<number>(1).fill(0);
    let v1: number = 1.5;
    spiral_array_set(v0, 0, v1);
    let v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Held(v0);
    } else {
        v5 = US0_Missing();
    }
    switch (v5.tag) {
        case 1: {
            let v6: Array<number> = v5.f0;
            let v7: number = spiral_array_index(v6, 0);
            let v8: boolean = v7 === 1.5;
            if (v8) {
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
}
process.exitCode = main();
