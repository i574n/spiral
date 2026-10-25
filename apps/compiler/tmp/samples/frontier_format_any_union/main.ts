type Mut0 = { l0: string };
function method2(v0: Mut0, v1: string): void {
    let v2: string = v0.l0;
    let v3: string = v2 + v1 ;
    v0.l0 = v3;
}
function format_real_1(v0: number): string {
    let v1: string = "";
    let v2: Mut0 = { l0: v1 };
    let v3: string = String(v0);
    method2(v2, v3);
    let v4: string = v2.l0;
    return v4;
}
function method0(): string {
    let v0: string = "Some";
    let v1: string = "(";
    let v2: string = v0 + v1 ;
    let v3: number = 1;
    let v4: string = format_real_1(v3);
    let v5: string = v2 + v4 ;
    let v6: string = ")";
    let v7: string = v5 + v6 ;
    return v7;
}
export function main(): number {
    let v0: string = method0();
    let v1: string = "x: ";
    let v2: string = v1 + v0 ;
    let v3: boolean = v2 === "";
    if (v3) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
