export function main(): number {
    let v0: number = 1.5;
    let v1: number = (-2);
    let v2: number = (-0.5);
    let v3: number = Math.fround(v0 / v1);
    let v4: number = Math.fround(v2 / v1);
    let v5: boolean = v3 === (-0.75);
    let v7: boolean;
    if (v5) {
        let v6: boolean = v4 === 0.25;
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
