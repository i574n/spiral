export function main(): number {
    let v0: number = (-1.5);
    let v1: number = 2;
    let v2: number = Math.fround(v0 / v1);
    let v3: number = (-0.75);
    let v4: number = Math.fround(v0 * v1);
    let v5: number = Math.fround(v4 + 0.5);
    let v6: number = (-2.5);
    let v7: boolean = v2 === v3;
    if (v7) {
        let v8: boolean = v5 === v6;
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
