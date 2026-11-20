export function main(): number {
    const v0: number = (-1);
    const v1: number = (-8);
    const v2: number = ~v0;
    const v3: number = ~v1;
    const v4: boolean = v2 === 0;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === 7;
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
