export function main(): number {
    const v0: number = 1.5;
    const v1: number = (-2);
    const v2: number = (-0.5);
    const v3: number = Math.fround(v0 / v1);
    const v4: number = Math.fround(v2 / v1);
    const v5: boolean = v3 === (-0.75);
    let v7: boolean;
    if (v5) {
        const v6: boolean = v4 === 0.25;
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
