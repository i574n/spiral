export function main(): number {
    const v0: number = 144;
    const v1: number = 81;
    const v2: number = Math.fround(Math.sqrt(v0));
    const v3: number = Math.sqrt(v1);
    const v4: boolean = v2 === 12;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === 9;
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
