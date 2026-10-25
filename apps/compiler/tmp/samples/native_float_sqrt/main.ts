export function main(): number {
    let v0: number = 144;
    let v1: number = 81;
    let v2: number = Math.fround(Math.sqrt(v0));
    let v3: number = Math.sqrt(v1);
    let v4: boolean = v2 === 12;
    let v6: boolean;
    if (v4) {
        let v5: boolean = v3 === 9;
        v6 = v5;
    } else {
        v6 = false;
    }
    if (v6) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
