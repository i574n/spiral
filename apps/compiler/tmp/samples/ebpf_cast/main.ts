export function main(): number {
    let v0: number = 3;
    let v1: number = (-2);
    let v2: number = 7;
    let v3: number = 2.9000000953674316;
    let v4: number = Math.fround(v0);
    let v5: number = Math.fround(v1);
    let v6: number = Math.fround(v2);
    let v7: number = (v3) >>> 0;
    let v8: boolean = v4 === 3;
    let v10: boolean;
    if (v8) {
        let v9: boolean = v5 === (-2);
        v10 = v9;
    } else {
        v10 = false;
    }
    let v12: boolean;
    if (v10) {
        let v11: boolean = v6 === 7;
        v12 = v11;
    } else {
        v12 = false;
    }
    let v14: boolean;
    if (v12) {
        let v13: boolean = v7 === 2;
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
