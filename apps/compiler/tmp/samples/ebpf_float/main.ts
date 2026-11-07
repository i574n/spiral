export function main(): number {
    const v0: number = (-1.5);
    const v1: number = 2;
    const v2: number = Math.fround(v0 / v1);
    const v3: number = (-0.75);
    const v4: number = Math.fround(v0 * v1);
    const v5: number = Math.fround(v4 + 0.5);
    const v6: number = (-2.5);
    const v7: boolean = v2 === v3;
    if (v7) {
        const v8: boolean = v5 === v6;
        if (v8) {
            return 0;
        } else {
            return 2;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
