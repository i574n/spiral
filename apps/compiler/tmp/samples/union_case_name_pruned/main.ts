function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_First = { readonly tag: 1 };
type US0_Second = { readonly tag: 2 };
type US0 = US0_First | US0_Second;
const US0_First_shared: US0 = { tag: 1 }; function US0_First(): US0 { return US0_First_shared; }
const US0_Second_shared: US0 = { tag: 2 }; function US0_Second(): US0 { return US0_Second_shared; }
export function main(): number {
    const v0: US0 = US0_First();
    const v1: US0 = US0_Second();
    const v3: string = "";
    const v4: string = "First";
    const v5: string = "Second";
    const v6: Array<string> = [v3, v4, v5];
    const v7: number = v0.tag;
    const v8: string = spiral_array_index(v6, v7);
    const v9: boolean = v8 === "First";
    let v14: boolean;
    if (v9) {
        const v10: Array<string> = [v3, v4, v5];
        const v11: number = v1.tag;
        const v12: string = spiral_array_index(v10, v11);
        const v13: boolean = v12 === "Second";
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
        return 42;
    } else {
        return 1;
    }
}
process.exitCode = main();
