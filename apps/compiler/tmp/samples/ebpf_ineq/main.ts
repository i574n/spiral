export function main(): number {
    let v0: number = (-3);
    let v1: number = (-4);
    let v2: number = (-3);
    let v3: number = 4294967295;
    let v4: number = 0;
    let v5: number = 4294967295;
    let v6: number = (-1.5);
    let v7: number = (-0.5);
    let v8: number = (-1.5);
    let v9: boolean = v0 !== v1;
    let v10: boolean = v0 !== v2;
    let v11: boolean = v3 !== v4;
    let v12: boolean = v3 !== v5;
    let v13: boolean = v6 !== v7;
    let v14: boolean = v6 !== v8;
    let v15: boolean = v9 && v11;
    let v16: boolean = v15 && v13;
    if (v16) {
        if (v10) {
            return 1;
        } else {
            if (v12) {
                return 2;
            } else {
                if (v14) {
                    return 3;
                } else {
                    return 0;
                }
            }
        }
    } else {
        return 4;
    }
}
process.exitCode = main();
