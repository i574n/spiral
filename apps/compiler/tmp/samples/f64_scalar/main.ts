export function main(): number {
    const v0: number = 1.5;
    const v1: number = (-2);
    const v2: number = v0 / v1;
    const v3: number = 1000000;
    const v4: number = v3 * v3;
    const v5: number = v4 * v3;
    const v6: number = v5 * 10000;
    const v7: number = v6 * v6;
    const v8: number = 3;
    const v9: number = v8;
    const v10: number = 2.9;
    const v11: number = (-1.9);
    const v12: number = (v10) | 0;
    const v13: number = (v11) | 0;
    const v14: number = 1.5;
    const v15: number = v14;
    const v16: boolean = v2 === (-0.75);
    let v18: boolean;
    if (v16) {
        const v17: boolean = v7 > v6;
        v18 = v17;
    } else {
        v18 = false;
    }
    let v21: boolean;
    if (v18) {
        const v19: number = v7 * v6;
        const v20: boolean = v7 < v19;
        v21 = v20;
    } else {
        v21 = false;
    }
    let v23: boolean;
    if (v21) {
        const v22: boolean = v9 === 3;
        v23 = v22;
    } else {
        v23 = false;
    }
    let v25: boolean;
    if (v23) {
        const v24: boolean = v12 === 2;
        v25 = v24;
    } else {
        v25 = false;
    }
    let v27: boolean;
    if (v25) {
        const v26: boolean = v13 === (-1);
        v27 = v26;
    } else {
        v27 = false;
    }
    let v29: boolean;
    if (v27) {
        const v28: boolean = v15 === 1.5;
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
