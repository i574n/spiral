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
    let v0: number = 2;
    let v1: Array<number> = new Array<number>(v0).fill(0);
    let v2: number = 7;
    spiral_array_set(v1, 0, v2);
    let v3: boolean = true;
    let v6: US0;
    if (v3) {
        v6 = US0_Held(v1);
    } else {
        v6 = US0_Missing();
    }
    switch (v6.tag) {
        case 1: {
            let v7: Array<number> = v6.f0;
            let v8: number = spiral_array_index(v7, 0);
            let v9: boolean = v8 === 7;
            if (v9) {
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
