function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Missing = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Array<string> };
type US0 = US0_Missing | US0_Held;
function US0_Missing(): US0 { return { tag: 0 }; }
function US0_Held(f0: Array<string>): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    let v0: Array<string> = new Array<string>(1).fill("");
    let v1: string = "hi";
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
            let v6: Array<string> = v5.f0;
            let v7: string = spiral_array_index(v6, 0);
            let v8: boolean = v7 === "hi";
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
