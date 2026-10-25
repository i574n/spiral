function method0(v0: boolean): number {
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
function method1(v0: boolean, v1: boolean): number {
    let v2: boolean = v0 && v1;
    if (v2) {
        return 1;
    } else {
        let v3: boolean = v0 || v1;
        if (v3) {
            return 2;
        } else {
            return 3;
        }
    }
}
function method2(v0: boolean): number {
    if (v0) {
        return 1;
    } else {
        return 3;
    }
}
export function main(): number {
    let v0: boolean = true;
    let v1: boolean = false;
    let v2: number = method0(v0);
    let v3: number = method1(v0, v1);
    let v4: number = method2(v1);
    let v5: boolean = v0 === v1;
    let v6: boolean = v5 === false;
    let v7: boolean = v2 === 1;
    let v9: boolean;
    if (v7) {
        let v8: boolean = v3 === 2;
        v9 = v8;
    } else {
        v9 = false;
    }
    let v11: boolean;
    if (v9) {
        let v10: boolean = v4 === 3;
        v11 = v10;
    } else {
        v11 = false;
    }
    let v12: boolean = v11 && v6;
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
