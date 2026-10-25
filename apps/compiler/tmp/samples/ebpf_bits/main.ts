export function main(): number {
    let v0: number = 4294967295;
    let v1: number = 15;
    let v2: number = (v0 & v1) >>> 0;
    let v3: number = (v0 | v1) >>> 0;
    let v4: number = (v0 ^ v1) >>> 0;
    let v5: number = ~v1 >>> 0;
    let v6: boolean = v2 === 15;
    let v8: boolean;
    if (v6) {
        let v7: boolean = v3 === v0;
        v8 = v7;
    } else {
        v8 = false;
    }
    let v10: boolean;
    if (v8) {
        let v9: boolean = v4 === v5;
        v10 = v9;
    } else {
        v10 = false;
    }
    let v12: boolean;
    if (v10) {
        let v11: boolean = v5 === 4294967280;
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
