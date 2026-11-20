function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_None = { readonly tag: 0 };
type US0_Held = { readonly tag: 1, readonly f0: Array<number>, readonly f1: number };
type US0 = US0_None | US0_Held;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Held(f0: Array<number>, f1: number): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            const v1: Array<number> = v0.f0;
            const v2: number = v0.f1;
            const v3: number = spiral_array_index(v1, 0);
            const v4: number = (v3 + v2) | 0;
            const v5: boolean = v4 === 7;
            if (v5) {
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
    const v0: number = 3;
    const v1: number = 4;
    const v2: Array<number> = new Array<number>(1).fill(0);
    spiral_array_set(v2, 0, v0);
    const v3: boolean = true;
    let v6: US0;
    if (v3) {
        v6 = US0_Held(v2, v1);
    } else {
        v6 = US0_None();
    }
    return score_0(v6);
}
process.exitCode = main();
