function method1(v0: number, v1: number): number {
    tail: while (true) {
        let v2: number = (v0 - 1) | 0;
        let v3: number = (v1 + v0) | 0;
        let v4: boolean = v2 === 0;
        if (v4) {
            return v3;
        } else {
            {
                let t0 = v2;
                let t1 = v3;
                v0 = t0;
                v1 = t1;
            }
            continue tail;
        }
    }
}
function method0(v0: number): number {
    let v1: number = 0;
    let v2: boolean = v0 === 0;
    let v4: number;
    if (v2) {
        v4 = v1;
    } else {
        v4 = method1(v0, v1);
    }
    let v5: number = (v4 - 55) | 0;
    return v5;
}
export function main(): number {
    let v0: number = 10;
    return method0(v0);
}
process.exitCode = main();
