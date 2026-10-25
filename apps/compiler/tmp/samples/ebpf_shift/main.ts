export function main(): number {
    const v0: number = (-8);
    const v1: number = 3;
    const v2: number = 1;
    const v3: number = 4294967295;
    const v4: number = 4;
    const v5: number = v0 >> v2;
    const v6: number = v1 << v2;
    const v7: number = v3 >>> v4;
    const v8: number = (v3 << v2) >>> 0;
    const v9: boolean = v5 === (-4);
    if (v9) {
        const v10: boolean = v6 === 6;
        if (v10) {
            const v11: boolean = v7 === 268435455;
            if (v11) {
                const v12: boolean = v8 === 4294967294;
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
