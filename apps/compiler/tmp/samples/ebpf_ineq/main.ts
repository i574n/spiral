export function main(): number {
    const v0: number = (-3);
    const v1: number = (-4);
    const v2: number = (-3);
    const v3: number = 4294967295;
    const v4: number = 0;
    const v5: number = 4294967295;
    const v6: number = (-1.5);
    const v7: number = (-0.5);
    const v8: number = (-1.5);
    const v9: boolean = v0 !== v1;
    const v10: boolean = v0 !== v2;
    const v11: boolean = v3 !== v4;
    const v12: boolean = v3 !== v5;
    const v13: boolean = v6 !== v7;
    const v14: boolean = v6 !== v8;
    const v15: boolean = v9 && v11;
    const v16: boolean = v15 && v13;
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
