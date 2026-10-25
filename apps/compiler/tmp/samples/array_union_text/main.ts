function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_None = { readonly tag: 0 };
type US0_Both = { readonly tag: 1, readonly f0: string, readonly f1: string };
type US0 = US0_None | US0_Both;
function US0_None(): US0 { return { tag: 0 }; }
function US0_Both(f0: string, f1: string): US0 { return { tag: 1, f0: f0, f1: f1 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v1: string = v0.f0;
            let v2: string = v0.f1;
            let v3: boolean = v1 === "hi";
            let v5: boolean;
            if (v3) {
                let v4: boolean = v2 === "yo";
                v5 = v4;
            } else {
                v5 = false;
            }
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
    let v0: Array<US0> = new Array<US0>(1).fill(undefined as unknown as US0);
    let v1: string = "hi";
    let v2: string = "yo";
    let v3: boolean = true;
    let v6: US0;
    if (v3) {
        v6 = US0_Both(v1, v2);
    } else {
        v6 = US0_None();
    }
    spiral_array_set(v0, 0, v6);
    let v7: US0 = spiral_array_index(v0, 0);
    return score_0(v7);
}
process.exitCode = main();
