type Mut0 = { l0: string };
function method2(v0: Mut0, v1: string): void {
    const v2: string = v0.l0;
    const v3: string = v2 + v1 ;
    v0.l0 = v3;
}
function format_real_1(v0: number): string {
    const v1: string = "";
    const v2: Mut0 = { l0: v1 };
    const v3: string = String(v0);
    method2(v2, v3);
    const v4: string = v2.l0;
    return v4;
}
function method0(): string {
    let v0: string = "Some";
    const v1: string = "(";
    const v2: string = v0 + v1 ;
    const v3: number = 1;
    const v4: string = format_real_1(v3);
    const v5: string = v2 + v4 ;
    const v6: string = ")";
    const v7: string = v5 + v6 ;
    return v7;
}
export function main(): number {
    let v0: string = method0();
    const v1: string = "x: ";
    const v2: string = v1 + v0 ;
    const v3: boolean = v2 === "";
    if (v3) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
