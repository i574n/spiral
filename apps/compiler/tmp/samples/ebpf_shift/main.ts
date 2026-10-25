export function main(): number {
    let v0: number = (-8);
    let v1: number = 3;
    let v2: number = 1;
    let v3: number = 4294967295;
    let v4: number = 4;
    let v5: number = v0 >> v2;
    let v6: number = v1 << v2;
    let v7: number = v3 >>> v4;
    let v8: number = (v3 << v2) >>> 0;
    let v9: boolean = v5 === (-4);
    if (v9) {
        let v10: boolean = v6 === 6;
        if (v10) {
            let v11: boolean = v7 === 268435455;
            if (v11) {
                let v12: boolean = v8 === 4294967294;
                if (v12) {
                    return 0;
                } else {
                    return 4;
                }
            } else {
                return 3;
            }
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
