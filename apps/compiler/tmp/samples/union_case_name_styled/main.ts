function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type US0_DeepBlue = { readonly tag: 0 };
type US0_LightGreen = { readonly tag: 1, readonly f0: number };
type US0_Red = { readonly tag: 2 };
type US0 = US0_DeepBlue | US0_LightGreen | US0_Red;
const US0_DeepBlue_shared: US0 = { tag: 0 }; function US0_DeepBlue(): US0 { return US0_DeepBlue_shared; }
function US0_LightGreen(f0: number): US0 { return { tag: 1, f0: f0 }; }
const US0_Red_shared: US0 = { tag: 2 }; function US0_Red(): US0 { return US0_Red_shared; }
export function main(): number {
    const v0: number = 0.5;
    const v1: US0 = US0_LightGreen(v0);
    const v2: US0 = US0_DeepBlue();
    const v3: US0 = US0_Red();
    const v4: string = "deep_blue";
    const v5: string = "light_green";
    const v6: string = "red";
    const v7: Array<string> = [v4, v5, v6];
    const v8: number = v1.tag;
    const v9: string = spiral_array_index(v7, v8);
    const v10: boolean = v9 === "light_green";
    let v17: boolean;
    if (v10) {
        const v11: string = "deep-blue";
        const v12: string = "light-green";
        const v13: Array<string> = [v11, v12, v6];
        const v14: number = v2.tag;
        const v15: string = spiral_array_index(v13, v14);
        const v16: boolean = v15 === "deep-blue";
        v17 = v16;
    } else {
        v17 = false;
    }
    let v23: boolean;
    if (v17) {
        const v18: string = "deepblue";
        const v19: string = "lightgreen";
        const v20: Array<string> = [v18, v19, v6];
        const v21: string = spiral_array_index(v20, v8);
        const v22: boolean = v21 === "lightgreen";
        v23 = v22;
    } else {
        v23 = false;
    }
    let v28: boolean;
    if (v23) {
        const v24: Array<string> = [v4, v5, v6];
        const v25: number = v3.tag;
        const v26: string = spiral_array_index(v24, v25);
        const v27: boolean = v26 === "red";
        v28 = v27;
    } else {
        v28 = false;
    }
    let v35: boolean;
    if (v28) {
        const v29: string = "DeepBlue";
        const v30: string = "LightGreen";
        const v31: string = "Red";
        const v32: Array<string> = [v29, v30, v31];
        const v33: string = spiral_array_index(v32, v8);
        const v34: boolean = v33 === "LightGreen";
        v35 = v34;
    } else {
        v35 = false;
    }
    if (v35) {
        return 42;
    } else {
        return 1;
    }
}
process.exitCode = main();
