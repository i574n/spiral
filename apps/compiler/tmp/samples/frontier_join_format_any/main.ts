type Mut0 = { l0: string };
function method3(v0: Mut0, v1: string): void {
    const v2: string = v0.l0;
    const v3: string = v2 + v1;
    v0.l0 = v3;
}
function format_real_2(v0: number): string {
    const v1: string = "";
    const v2: Mut0 = { l0: v1 };
    const v3: string = String(v0);
    method3(v2, v3);
    const v4: string = v2.l0;
    return v4;
}
function method1(): string {
    let v0: number = 1;
    const v1: string = format_real_2(v0);
    const v2: string = "Some(" + v1;
    const v3: string = v2 + ")";
    return v3;
}
function method0(): string {
    let v0: string = method1();
    const v1: string = "x: " + v0;
    return v1;
}
export function main(): number {
    let v0: string = method0();
    const v1: boolean = v0 === "";
    if (v1) {
        return 1;
    } else {
        return 0;
    }
}
process.exitCode = main();
