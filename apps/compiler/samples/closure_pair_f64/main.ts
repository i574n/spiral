function f_c0(v0: number): ((a0: number) => [number, number]) {
    return (v1: number): [number, number] => {
        const v2: boolean = v1 === 0;
        if (v2) {
            return [0, 0];
        } else {
            return [v0, 2.5];
        }
    };
}
export function main(): number {
    const v0: number = 1.5;
    const v1: ((a0: number) => [number, number]) = f_c0(v0);
    let [v2, v3]: [number, number] = v1(1);
    const v4: boolean = v2 === 1.5;
    let v6: boolean;
    if (v4) {
        const v5: boolean = v3 === 2.5;
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
