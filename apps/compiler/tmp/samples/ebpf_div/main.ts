export function main(): number {
    let v0: number = 7;
    let v1: number = (-2);
    let v2: number = (-7);
    let v3: number = 100;
    let v4: number = 7;
    let v5: number = (v0 / v1) | 0;
    let v6: number = (v0 % v1) | 0;
    let v7: number = (v2 / v1) | 0;
    let v8: number = (v2 % v1) | 0;
    let v9: number = (v3 / v4) >>> 0;
    let v10: number = (v3 % v4) >>> 0;
    let v11: boolean = v5 === (-3);
    let v13: boolean;
    if (v11) {
        let v12: boolean = v6 === 1;
        v13 = v12;
    } else {
        v13 = false;
    }
    let v15: boolean;
    if (v13) {
        let v14: boolean = v7 === 3;
        v15 = v14;
    } else {
        v15 = false;
    }
    let v17: boolean;
    if (v15) {
        let v16: boolean = v8 === (-1);
        v17 = v16;
    } else {
        v17 = false;
    }
    let v19: boolean;
    if (v17) {
        let v18: boolean = v9 === 14;
        v19 = v18;
    } else {
        v19 = false;
    }
    let v21: boolean;
    if (v19) {
        let v20: boolean = v10 === 2;
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
