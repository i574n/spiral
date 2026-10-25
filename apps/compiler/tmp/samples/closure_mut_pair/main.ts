type Mut0 = { l0: number, l1: string };
function f_c0(v0: Mut0): ((a0: number) => Mut0) {
    return (v1: number): Mut0 => {
        return v0;
    };
}
export function main(): number {
    const v0: number = 3;
    const v1: string = "no";
    const v2: Mut0 = { l0: v0, l1: v1 };
    const v3: ((a0: number) => Mut0) = f_c0(v2);
    let v4: Mut0 = v3(1);
    const v5: number = 7;
    const v6: string = "hi";
    v4.l0 = v5;
    v4.l1 = v6;
    const v7: number = v4.l0;
    const v8: string = v4.l1;
    const v9: boolean = v7 === 7;
    let v11: boolean;
    if (v9) {
        const v10: boolean = v8 === "hi";
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
