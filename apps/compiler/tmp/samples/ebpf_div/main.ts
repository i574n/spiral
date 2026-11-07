export function main(): number {
    const v0: number = 7;
    const v1: number = (-2);
    const v2: number = (-7);
    const v3: number = 100;
    const v4: number = 7;
    const v5: number = (v0 / v1) | 0;
    const v6: number = (v0 % v1) | 0;
    const v7: number = (v2 / v1) | 0;
    const v8: number = (v2 % v1) | 0;
    const v9: number = (v3 / v4) >>> 0;
    const v10: number = (v3 % v4) >>> 0;
    const v11: boolean = v5 === (-3);
    let v13: boolean;
    if (v11) {
        const v12: boolean = v6 === 1;
        v13 = v12;
    } else {
        v13 = false;
    }
    let v15: boolean;
    if (v13) {
        const v14: boolean = v7 === 3;
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        const v16: boolean = v8 === (-1);
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        const v18: boolean = v9 === 14;
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        const v20: boolean = v10 === 2;
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
