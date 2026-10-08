function method5(v0: number, v1: number): number {
    let v2: number = Math.imul(v0, v1);
    let v3: number = (v2 + 5) | 0;
    let v4: number = (v3 / 3) | 0;
    return v4;
}
function method4(v0: number): number {
    let v1: number = 4;
    let v2: number = 4;
    let v3: number = method5(v1, v2);
    let v4: number = (v0 + v3) | 0;
    let v5: number = (v4 - 7) | 0;
    return v5;
}
function method6(v0: number): boolean {
    let v1: number = (v0 + 5) >>> 0;
    let v2: number = (v1 % 4) >>> 0;
    let v3: boolean = v2 === 0;
    return v3;
}
function method3(v0: number): number {
    let v1: number = 7;
    let v2: boolean = method6(v1);
    if (v2) {
        return method4(v0);
    } else {
        return 1;
    }
}
function method7(v0: string): boolean {
    return true;
}
function method2(v0: number): number {
    let v1: string = "spiral";
    let v2: boolean = method7(v1);
    if (v2) {
        return method3(v0);
    } else {
        return 1;
    }
}
function method8(v0: number): [boolean, number, number] {
    let v1: boolean = v0 >= 3.5;
    return [v1, v0, 7];
}
function method9(v0: boolean, v1: number, v2: number): number {
    if (v0) {
        let v3: boolean = v1 >= 3.5;
        if (v3) {
            let v4: number = (v2 - 7) | 0;
            return v4;
        } else {
            return 1;
        }
    } else {
        return 2;
    }
}
function method1(v0: number): number {
    let v1: number = 4;
    let [v2, v3, v4]: [boolean, number, number] = method8(v1);
    let v5: number = method9(v2, v3, v4);
    let v6: number = (v0 + v5) | 0;
    return method2(v6);
}
function method10(v0: number): [number, number, boolean] {
    let v1: number = (v0 + 2) | 0;
    let v2: boolean = v0 > 0;
    return [v0, v1, v2];
}
function method11(v0: number, v1: number, v2: boolean): number {
    if (v2) {
        let v3: number = (v0 + v1) | 0;
        let v4: number = (v3 - 4) | 0;
        return v4;
    } else {
        return 1;
    }
}
function method0(v0: number): number {
    let v1: number = 1;
    let [v2, v3, v4]: [number, number, boolean] = method10(v1);
    let v5: number = method11(v2, v3, v4);
    let v6: number = (v0 + v5) | 0;
    return method1(v6);
}
export function main(): number {
    let v0: number = 0;
    return method0(v0);
}
process.exitCode = main();
