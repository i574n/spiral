export function main(): number {
    const v0: string = "a";
    const v1: string = "b";
    const v2: string = "é";
    const v3: string = "éx";
    const v4: string = "";
    const v5: boolean = v0 < v0;
    if (v5) {
        return 1;
    } else {
        const v6: boolean = v0 < v1;
        let v8: boolean;
        if (v6) {
            const v7: boolean = v1 < v2;
            v8 = v7;
        } else {
            v8 = false;
        }
        let v10: boolean;
        if (v8) {
            const v9: boolean = v2 < v3;
            v10 = v9;
        } else {
            v10 = false;
        }
        let v12: boolean;
        if (v10) {
            const v11: boolean = v4 < v0;
            v12 = v11;
        } else {
            v12 = false;
        }
        let v14: boolean;
        if (v12) {
            const v13: boolean = v0 <= v0;
            v14 = v13;
        } else {
            v14 = false;
        }
        let v16: boolean;
        if (v14) {
            const v15: boolean = v0 >= v0;
            v16 = v15;
        } else {
            v16 = false;
        }
        let v18: boolean;
        if (v16) {
            const v17: boolean = v3 > v2;
            v18 = v17;
        } else {
            v18 = false;
        }
        let v20: boolean;
        if (v18) {
            const v19: boolean = v1 >= v0;
            v20 = v19;
        } else {
            v20 = false;
        }
        if (v20) {
            return 0;
        } else {
            return 1;
        }
    }
}
process.exitCode = main();
