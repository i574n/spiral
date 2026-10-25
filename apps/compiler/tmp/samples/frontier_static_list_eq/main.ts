export function main(): number {
    let v0: number = 120;
    let v1: boolean = v0 === 32;
    let v3: boolean;
    if (v1) {
        v3 = true;
    } else {
        let v2: boolean = v0 === 47;
        v3 = v2;
    }
    if (v3) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
