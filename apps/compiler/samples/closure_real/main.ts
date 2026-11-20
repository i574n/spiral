function f_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: boolean = v1 === 0;
        if (v2) {
            return 0;
        } else {
            return v0;
        }
    };
}
export function main(): number {
    const v0: number = 1.5;
    const v1: ((a0: number) => number) = f_c0(v0);
    const v2: number = v1(1);
    const v3: boolean = v2 === 1.5;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
