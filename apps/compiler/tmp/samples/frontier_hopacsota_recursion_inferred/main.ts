function count_0(v0: number): number {
    tail: while (true) {
        let v1: boolean = v0 <= 0;
        if (v1) {
            return 0;
        } else {
            let v2: number = (v0 - 1) | 0;
            v0 = v2;
            continue tail;
        }
    }
}
export function main(): number {
    let v0: number = 5;
    return count_0(v0);
}
process.exitCode = main();
