function method1(v0: number, v1: number): number {
    tail: while (true) {
        let v2: number = (v0 - 1) | 0;
        let v3: number = Math.fround(v1 + 1.5);
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
function method0(v0: number, v1: number): number {
    let v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method1(v0, v1);
    }
}
export function main(): number {
    let v0: number = 4;
    let v1: number = 0;
    let v2: number = method0(v0, v1);
    let v3: boolean = v2 === 6;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
