function count_down_0(v0: number, v1: number): number {
    tail: while (true) {
        const v2: boolean = 0 < v0;
        if (v2) {
            const v3: number = (v0 - 1) | 0;
            const v4: number = (v1 + 1) | 0;
            v0 = v3;
            v1 = v4;
            continue tail;
        } else {
            return v1;
        }
    }
}
export function main(): number {
    let v0: number = 5000;
    let v1: number = 0;
    const v2: number = count_down_0(v0, v1);
    const v3: boolean = v2 === 5000;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
