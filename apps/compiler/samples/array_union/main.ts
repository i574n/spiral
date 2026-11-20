function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_None = { readonly tag: 0 };
type US0_Some = { readonly tag: 1, readonly f0: number };
type US0 = US0_None | US0_Some;
const US0_None_shared: US0 = { tag: 0 }; function US0_None(): US0 { return US0_None_shared; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    const v0: number = 2;
    const v1: Array<US0> = new Array<US0>(v0).fill(undefined as unknown as US0);
    const v2: number = 7;
    const v3: US0 = US0_Some(v2);
    spiral_array_set(v1, 0, v3);
    const v4: US0 = US0_None();
    spiral_array_set(v1, 1, v4);
    const v5: US0 = spiral_array_index(v1, 0);
    switch (v5.tag) {
        case 0: {
            return 1;
        }
        case 1: {
            const v6: number = v5.f0;
            const v7: US0 = spiral_array_index(v1, 1);
            switch (v7.tag) {
                case 0: {
                    const v8: boolean = v6 === 7;
                    if (v8) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                case 1: {
                    const v10: number = v7.f0;
                    return 1;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
