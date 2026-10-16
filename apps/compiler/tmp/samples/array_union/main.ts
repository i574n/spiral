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
function US0_None(): US0 { return { tag: 0 }; }
function US0_Some(f0: number): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    let v0: number = 2;
    let v1: Array<US0> = new Array<US0>(v0).fill(undefined as unknown as US0);
    let v2: number = 7;
    let v3: US0 = US0_Some(v2);
    spiral_array_set(v1, 0, v3);
    let v4: US0 = US0_None();
    spiral_array_set(v1, 1, v4);
    let v5: US0 = spiral_array_index(v1, 0);
    switch (v5.tag) {
        case 0: {
            return 1;
            break;
        }
        case 1: {
            let v6: number = v5.f0;
            let v7: US0 = spiral_array_index(v1, 1);
            switch (v7.tag) {
                case 0: {
                    let v8: boolean = v6 === 7;
                    if (v8) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                case 1: {
                    let v10: number = v7.f0;
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
process.exitCode = main();
