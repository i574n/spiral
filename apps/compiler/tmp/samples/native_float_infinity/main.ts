export function main(): number {
    let v0: number = Infinity;
    let v1: number = Infinity;
    let v2: number = -v0;
    let v3: number = -v1;
    let v4: number = 1;
    let v5: number = 1;
    let v6: boolean = Number.isNaN(v4);
    let v8: boolean;
    if (v6) {
        v8 = true;
    } else {
        let v7: boolean = Number.isNaN(v5);
        v8 = v7;
    }
    if (v8) {
        return 3;
    } else {
        let v9: boolean = v0 > v4;
        let v11: boolean;
        if (v9) {
            let v10: boolean = v1 > v5;
            v11 = v10;
        } else {
            v11 = false;
        }
        if (v11) {
            let v12: boolean = v2 < 0;
            let v14: boolean;
            if (v12) {
                let v13: boolean = v3 < 0;
                v14 = v13;
            } else {
                v14 = false;
            }
            if (v14) {
                return 0;
            } else {
                return 2;
            }
        } else {
            return 1;
        }
    }
}
process.exitCode = main();
