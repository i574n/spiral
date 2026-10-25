function sum_0(v0: number): number {
    let v1: boolean = v0 < 1;
    if (v1) {
        return 0;
    } else {
        let v2: number = (v0 - 1) | 0;
        let v3: number = sum_0(v2);
        let v4: number = (v0 + v3) | 0;
        return v4;
    }
}
export function main(): number {
    let v0: number = 4;
    let v1: number = sum_0(v0);
    let v2: boolean = v1 === 10;
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
