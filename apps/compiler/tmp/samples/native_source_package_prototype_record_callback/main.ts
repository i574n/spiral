function closure0(v0: number): ((a0: number, a1: number) => [number, number]) {
    return (v1: number, v2: number): [number, number] => {
        let v3: number = (v1 - 8) | 0;
        let v4: number = (v3 + v0) | 0;
        let v5: number = (v2 - 18) | 0;
        return [v4, v5];
    };
}
function method0(v0: ((a0: number, a1: number) => [number, number])): [number, number] {
    return v0(10, 20);
}
export function main(): number {
    let v0: number = 1;
    let v1: ((a0: number, a1: number) => [number, number]) = closure0(v0);
    let [v2, v3]: [number, number] = method0(v1);
    let v4: number = (10 + v2) | 0;
    let v5: number = (20 + v3) | 0;
    let v6: number = (v4 + v5) | 0;
    let v7: number = (v6 + 7) | 0;
    return v7;
}
process.exitCode = main();
