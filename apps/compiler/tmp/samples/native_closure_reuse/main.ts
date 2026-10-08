function closure0(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: number = (v0 + v1) | 0;
        let v4: number = (v3 + v2) | 0;
        return v4;
    };
}
export function main(): number {
    let v0: number = 1;
    let v1: number = 2;
    let v2: ((a0: number) => number) = closure0(v0, v1);
    let v3: number = v2(10);
    let v4: number = v2(20);
    let v5: number = v2(3);
    let v6: number = (v3 + v4) | 0;
    let v7: number = (v6 + v5) | 0;
    return v7;
}
process.exitCode = main();
