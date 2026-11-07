export function main(): number {
    const v0: number = 2;
    const v1: number = 3;
    const v2: number = 2;
    const v3: number = 3;
    const v4: number = 3.1415927410125732;
    const v5: number = 3.141592653589793;
    const v6: number = Math.fround(Math.pow(v0, v1));
    const v7: boolean = v6 === 8;
    let v10: boolean;
    if (v7) {
        const v8: number = Math.pow(v2, v3);
        const v9: boolean = v8 === 8;
        v10 = v9;
    } else {
        v10 = false;
    }
    let v12: boolean;
    if (v10) {
        const v11: boolean = v4 > 3;
        v12 = v11;
    } else {
        v12 = false;
    }
    let v14: boolean;
    if (v12) {
        const v13: boolean = v4 < 4;
        v14 = v13;
    } else {
        v14 = false;
    }
    let v16: boolean;
    if (v14) {
        const v15: boolean = v5 > 3;
        v16 = v15;
    } else {
        v16 = false;
    }
    let v18: boolean;
    if (v16) {
        const v17: boolean = v5 < 4;
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
