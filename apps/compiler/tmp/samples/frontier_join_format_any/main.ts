type Mut0 = { l0: string };
function method3(v0: Mut0, v1: string): void {
    let v2: string = v0.l0;
    let v3: string = v2 + v1 ;
    v0.l0 = v3;
}
function format_real_2(v0: number): string {
    let v1: string = "";
    let v2: Mut0 = { l0: v1 };
    let v3: string = String(v0);
    method3(v2, v3);
    let v4: string = v2.l0;
    return v4;
}
function method1(): string {
    let v0: string = "Some";
    let v1: string = "(";
    let v2: string = v0 + v1 ;
    let v3: number = 1;
    let v4: string = format_real_2(v3);
    let v5: string = v2 + v4 ;
    let v6: string = ")";
    let v7: string = v5 + v6 ;
    return v7;
}
function method0(): string {
    let v0: string = method1();
    let v1: string = "x: ";
    let v2: string = v1 + v0 ;
    return v2;
}
export function main(): number {
    let v0: string = method0();
    let v1: boolean = v0 === "";
    if (v1) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
