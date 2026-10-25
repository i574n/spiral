function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Array<string>, readonly f1: boolean };
type US0 = US0_None | US0_Held;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Held(f0: Array<string>, f1: boolean): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: Array<string> = v0.f0;
            let v2: boolean = v0.f1;
            let v3: string = spiral_array_index(v1, 0);
            let v4: boolean = v3 === "hi";
            let v5: boolean = v4 && v2;
            if (v5) {
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
export function main(): number {
    let v0: Array<string> = new Array<string>(1).fill("");
    let v1: string = "hi";
    spiral_array_set(v0, 0, v1);
    let v2: boolean = true;
    let v5: US0;
    if (v2) {
        v5 = US0_Held(v0, v2);
    } else {
        v5 = US0_None();
    }
    return score_0(v5);
}
process.exitCode = main();
