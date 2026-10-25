function method1(v0: number, v1: number): number {
    tail: while (true) {
        let v2: number = (v0 - 1) | 0;
        let v3: number = (v1 + 3) | 0;
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
    if (v2) {
        return v1;
    } else {
        return method1(v0, v1);
    }
}
function method3(v0: number, v1: number): number {
    tail: while (true) {
        let v2: number = (v0 - 1) | 0;
        let v3: number = (v1 - 2) | 0;
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
function method2(v0: number): number {
    let v1: number = 0;
    let v2: boolean = v0 === 0;
    if (v2) {
        return v1;
    } else {
        return method3(v0, v1);
    }
}
export function main(): number {
    let v0: number = 4;
    let v1: number = method0(v0);
    let v2: number = method2(v0);
    let v3: boolean = v1 === 12;
    let v5: boolean;
    if (v3) {
        let v4: boolean = v2 === (-8);
        v5 = v4;
    } else {
        v5 = false;
    }
    if (v5) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
