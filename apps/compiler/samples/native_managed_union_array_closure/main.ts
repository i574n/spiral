function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Empty = { readonly tag: 0 };
type US0_Values = { readonly tag: 1, readonly f0: Array<number> };
type US0 = US0_Empty | US0_Values;
const US0_Empty_shared: US0 = { tag: 0 }; function US0_Empty(): US0 { return US0_Empty_shared; }
function US0_Values(f0: Array<number>): US0 { return { tag: 1, f0: f0 }; }
function closure0(): ((a0: number) => US0) {
    return (v0: number): US0 => {
        const v1: boolean = v0 === 0;
        if (v1) {
            return US0_Empty();
        } else {
            const v3: Array<number> = new Array<number>(2).fill(0);
            spiral_array_set(v3, 0, v0);
            const v4: number = (v0 + 1) | 0;
            spiral_array_set(v3, 1, v4);
            return US0_Values(v3);
        }
    };
}
function method0(v0: ((a0: number) => US0)): US0 {
    return v0(0);
}
function score_1(v0: US0): number {
    switch (v0.tag) {
        case 0: {
            return 3;
        }
        case 1: {
            const v1: Array<number> = v0.f0;
            const v2: number = v1.length;
            const v3: number = spiral_array_index(v1, 0);
            const v4: number = (v2 + v3) | 0;
            const v5: number = spiral_array_index(v1, 1);
            const v6: number = (v4 + v5) | 0;
            return v6;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
function method2(v0: ((a0: number) => US0)): US0 {
    return v0(4);
}
export function main(): number {
    const v0: ((a0: number) => US0) = closure0();
    const v1: US0 = method0(v0);
    const v2: number = score_1(v1);
    const v3: US0 = method2(v0);
    const v4: number = score_1(v3);
    const v5: number = (v2 + v4) | 0;
    const v6: number = (v5 + 28) | 0;
    return v6;
}
process.exitCode = main();
