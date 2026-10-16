export function main(): number {
    let v0: number = (-1);
    let v1: number = (-8);
    let v2: number = ~v0;
    let v3: number = ~v1;
    let v4: boolean = v2 === 0;
    let v6: boolean;
    if (v4) {
        let v5: boolean = v3 === 7;
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
