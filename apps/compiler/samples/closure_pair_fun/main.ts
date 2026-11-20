function right_c1(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        const v3: boolean = v1 === 0;
        if (v3) {
            return 0;
        } else {
            const v4: number = (v2 + v0) | 0;
            return v4;
        }
    };
}
function left_c2(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        const v3: boolean = v1 === 0;
        if (v3) {
            return 0;
        } else {
            const v4: number = (v2 + v0) | 0;
            return v4;
        }
    };
}
function f_c0(v0: number, v1: number): ((a0: number) => [((a0: number) => number), ((a0: number) => number)]) {
    return (v2: number): [((a0: number) => number), ((a0: number) => number)] => {
        const v3: boolean = v2 === 0;
        if (v3) {
            const v4: ((a0: number) => number) = right_c1(v1, v2);
            const v5: ((a0: number) => number) = left_c2(v0, v2);
            return [v4, v5];
        } else {
            const v6: ((a0: number) => number) = left_c2(v0, v2);
            const v7: ((a0: number) => number) = right_c1(v1, v2);
            return [v6, v7];
        }
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 4;
    const v2: ((a0: number) => [((a0: number) => number), ((a0: number) => number)]) = f_c0(v0, v1);
    let [v3, v4]: [((a0: number) => number), ((a0: number) => number)] = v2(1);
    const v5: number = v3(0);
    const v6: number = v4(0);
    const v7: number = (v5 + v6) | 0;
    const v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
