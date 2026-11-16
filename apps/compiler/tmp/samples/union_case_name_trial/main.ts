function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_Circle = { readonly tag: 0, readonly f0: number };
type US0_Square = { readonly tag: 1, readonly f0: number };
type US0_Dot = { readonly tag: 2 };
type US0 = US0_Circle | US0_Square | US0_Dot;
function US0_Circle(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_Square(f0: number): US0 { return { tag: 1, f0: f0 }; }
const US0_Dot_shared: US0 = { tag: 2 }; function US0_Dot(): US0 { return US0_Dot_shared; }
export function main(): number {
    const v0: number = 1.5;
    const v1: US0 = US0_Circle(v0);
    const v2: number = 2.5;
    const v3: US0 = US0_Square(v2);
    const v4: US0 = US0_Dot();
    const v8: string = "Circle";
    const v9: string = "Square";
    const v10: string = "Dot";
    const v11: Array<string> = [v8, v9, v10];
    const v12: number = v1.tag;
    const v13: string = spiral_array_index(v11, v12);
    const v14: boolean = v13 === "Circle";
    let v19: boolean;
    if (v14) {
        const v15: Array<string> = [v8, v9, v10];
        const v16: number = v3.tag;
        const v17: string = spiral_array_index(v15, v16);
        const v18: boolean = v17 === "Square";
        v19 = v18;
    } else {
        v19 = false;
    }
    let v24: boolean;
    if (v19) {
        const v20: Array<string> = [v8, v9, v10];
        const v21: number = v4.tag;
        const v22: string = spiral_array_index(v20, v21);
        const v23: boolean = v22 === "Dot";
        v24 = v23;
    } else {
        v24 = false;
    }
    if (v24) {
        return 42;
    } else {
        return 1;
    }
}
process.exitCode = main();
