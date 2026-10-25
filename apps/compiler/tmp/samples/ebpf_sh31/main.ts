export function main(): number {
    let v0: number = 1;
    let v1: number = 0;
    let v2: number = 31;
    let v3: number = (v0 << v2) >>> 0;
    let v4: number = v3 >>> v2;
    let v5: number = (v0 << v1) >>> 0;
    let v6: boolean = v3 === 2147483648;
    let v8: boolean;
    if (v6) {
        let v7: boolean = v4 === 1;
        v8 = v7;
    } else {
        v8 = false;
    }
    let v10: boolean;
    if (v8) {
        let v9: boolean = v5 === 1;
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
