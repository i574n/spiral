export function main(): number {
    let v0: number = 65536;
    let v1: number = 65536;
    let v2: number = 4294967295;
    let v3: number = 3;
    let v4: number = Math.imul(v0, v1) >>> 0;
    let v5: number = Math.imul(v2, v3) >>> 0;
    let v6: boolean = v4 === 0;
    let v8: boolean;
    if (v6) {
        let v7: boolean = v5 === 4294967293;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
