function method0(v0: number, v1: number): number {
    tail: while (true) {
        let v2: boolean = 0 < v0;
        if (v2) {
            let v3: number = (v0 - 1) | 0;
            let v4: number = (v1 + 1) | 0;
            {
                let t0 = v3;
                let t1 = v4;
                v0 = t0;
                v1 = t1;
            }
            continue tail;
        } else {
            return v1;
        }
    }
}
export function main(): number {
    let v0: number = 5000;
    let v1: number = 0;
    let v2: number = method0(v0, v1);
    let v3: boolean = v2 === 5000;
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
