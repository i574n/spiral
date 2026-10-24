export function main(): number {
    const v0: number = 120;
    const v1: boolean = v0 === 32;
    let v3: boolean;
    if (v1) {
        v3 = true;
    } else {
        const v2: boolean = v0 === 47;
        v3 = v2;
    }
    if (v3) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
