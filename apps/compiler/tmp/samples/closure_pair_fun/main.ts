function right_c1(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: boolean = v1 === 0;
        if (v3) {
            return 0;
        } else {
            let v4: number = (v2 + v0) | 0;
            return v4;
        }
    };
}
function left_c2(v0: number, v1: number): ((a0: number) => number) {
    return (v2: number): number => {
        let v3: boolean = v1 === 0;
        if (v3) {
            return 0;
        } else {
            let v4: number = (v2 + v0) | 0;
            return v4;
        }
    };
}
function f_c0(v0: number, v1: number): ((a0: number) => [((a0: number) => number), ((a0: number) => number)]) {
    return (v2: number): [((a0: number) => number), ((a0: number) => number)] => {
        let v3: boolean = v2 === 0;
        if (v3) {
            let v4: ((a0: number) => number) = right_c1(v1, v2);
            let v5: ((a0: number) => number) = left_c2(v0, v2);
            return [v4, v5];
        } else {
            let v6: ((a0: number) => number) = left_c2(v0, v2);
            let v7: ((a0: number) => number) = right_c1(v1, v2);
            return [v6, v7];
        }
    };
}
export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: ((a0: number) => [((a0: number) => number), ((a0: number) => number)]) = f_c0(v0, v1);
    let [v3, v4]: [((a0: number) => number), ((a0: number) => number)] = v2(1);
    let v5: number = v3(0);
    let v6: number = v4(0);
    let v7: number = (v5 + v6) | 0;
    let v8: boolean = v7 === 7;
    if (v8) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
