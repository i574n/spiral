export function main(): number {
    const v0: number = NaN;
    const v1: number = NaN;
    const v2: number = 1;
    const v3: number = 1;
    const v4: boolean = Number.isNaN(v0);
    let v6: boolean;
    if (v4) {
        const v5: boolean = Number.isNaN(v1);
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        const v7: boolean = Number.isNaN(v2);
        let v9: boolean;
        if (v7) {
            v9 = true;
        } else {
            const v8: boolean = Number.isNaN(v3);
            v9 = v8;
        }
        if (v9) {
            return 2;
        } else {
            return 0;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
