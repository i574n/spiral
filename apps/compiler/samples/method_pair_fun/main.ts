function left_c0(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: boolean = v0 === 0;
        if (v2) {
            return 0;
        } else {
            const v3: number = (v1 + v0) | 0;
            return v3;
        }
    };
}
function right_c1(v0: number): ((a0: number) => number) {
    return (v1: number): number => {
        const v2: boolean = v0 === 0;
        if (v2) {
            return 0;
        } else {
            const v3: number = (v1 + v0) | 0;
            return v3;
        }
    };
}
function method0(v0: number, v1: number): [((a0: number) => number), ((a0: number) => number)] {
    const v2: ((a0: number) => number) = left_c0(v0);
    const v3: ((a0: number) => number) = right_c1(v1);
    return [v2, v3];
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    let [v2, v3]: [((a0: number) => number), ((a0: number) => number)] = method0(v0, v1);
    const v4: number = v2(0);
    const v5: number = v3(0);
    const v6: number = (v4 + v5) | 0;
    const v7: boolean = v6 === 7;
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
