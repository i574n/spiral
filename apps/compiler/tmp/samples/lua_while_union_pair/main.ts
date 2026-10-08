function spiral_array_index<T>(array: T[], index: number): T {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    return array[index];
}
function spiral_array_set<T>(array: T[], index: number, value: T): void {
    if (!(index >= 0 && index < array.length)) throw new RangeError("array index " + index + " out of bounds for length " + array.length);
    array[index] = value;
}
type Mut0 = { l0: number };
type Mut1 = { l0: number };
type UH0_0 = { readonly tag: 0 };
type UH0_1 = { readonly tag: 1, readonly f0: number, readonly f1: UH0 };
type UH0 = UH0_0 | UH0_1;
function UH0_0(): UH0 { return { tag: 0 }; }
function UH0_1(f0: number, f1: UH0): UH0 { return { tag: 1, f0: f0, f1: f1 }; }
type Mut2 = { l0: UH0 };
function method0(v0: Mut0): boolean {
    let v1: number = v0.l0;
    let v2: boolean = v1 < 3;
    return v2;
}
function method1(v0: Mut1): boolean {
    let v1: number = v0.l0;
    let v2: boolean = v1 < 4;
    return v2;
}
export function main(): number {
    let v0: Array<number> = new Array<number>(3).fill(0);
    let v1: Mut0 = { l0: 0 };
    while (method0(v1)) {
        let v3: number = v1.l0;
        let v4: number = Math.imul(v3, 5);
        spiral_array_set(v0, v3, v4);
        let v5: number = (v3 + 1) | 0;
        v1.l0 = v5;
    }
    let v6: Mut1 = { l0: 0 };
    let v7: Mut1 = { l0: 0 };
    let v8: UH0 = UH0_0();
    let v9: Mut2 = { l0: v8 };
    while (method1(v6)) {
        let v11: number = v6.l0;
        let v12: number = (v11 % 2) | 0;
        let v13: boolean = v12 === 1;
        if (v13) {
            let v14: number = v7.l0;
            let v15: number = (v14 + 1) | 0;
            v7.l0 = v15;
        }
        let v16: UH0 = v9.l0;
        let v17: UH0 = UH0_1(v11, v16);
        v9.l0 = v17;
        let v18: number = (v11 + 1) | 0;
        v6.l0 = v18;
    }
    let v19: UH0 = v9.l0;
    let v38: number;
    switch (v19.tag) {
        case 1: {
            let v20: number = v19.f0;
            let v21: UH0 = v19.f1;
            switch (v21.tag) {
                case 1: {
                    let v22: number = v21.f0;
                    let v23: UH0 = v21.f1;
                    switch (v23.tag) {
                        case 1: {
                            let v24: number = v23.f0;
                            let v25: UH0 = v23.f1;
                            switch (v25.tag) {
                                case 1: {
                                    let v26: number = v25.f0;
                                    let v27: UH0 = v25.f1;
                                    switch (v27.tag) {
                                        case 0: {
                                            let v28: number = Math.imul(v20, 64);
                                            let v29: number = Math.imul(v22, 16);
                                            let v30: number = (v28 + v29) | 0;
                                            let v31: number = Math.imul(v24, 4);
                                            let v32: number = (v30 + v31) | 0;
                                            let v33: number = (v32 + v26) | 0;
                                            v38 = v33;
                                            break;
                                        }
                                        default: {
                                            v38 = (-1);
                                        }
                                    }
                                    break;
                                }
                                default: {
                                    v38 = (-1);
                                }
                            }
                            break;
                        }
                        default: {
                            v38 = (-1);
                        }
                    }
                    break;
                }
                default: {
                    v38 = (-1);
                }
            }
            break;
        }
        default: {
            v38 = (-1);
        }
    }
    let v39: number = v7.l0;
    let v40: number = (v38 + v39) | 0;
    let v41: number = spiral_array_index(v0, 2);
    let v42: number = (v40 + v41) | 0;
    let v43: number = spiral_array_index(v0, 1);
    let v44: number = (v42 - v43) | 0;
    return v44;
}
process.exitCode = main();
