function f_c0(): ((a0: number) => [number, number]) {
    return (v0: number): [number, number] => {
        const v1: number = (v0 + 1) | 0;
        return [v0, v1];
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: ((a0: number) => [number, number]) = f_c0();
    let [v2, v3]: [number, number] = v1(v0);
    const v4: boolean = v2 === 3;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === 4;
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
