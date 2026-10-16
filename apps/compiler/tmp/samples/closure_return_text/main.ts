function g_c1(v0: string, v1: number): ((a0: number) => string) {
    return (v2: number): string => {
        let v3: boolean = v1 === 0;
        if (v3) {
            let v4: string = "no";
            return v4;
        } else {
            return v0;
        }
    };
}
function f_c0(v0: string): ((a0: number) => ((a0: number) => string)) {
    return (v1: number): ((a0: number) => string) => {
        return g_c1(v0, v1);
    };
}
export function main(): number {
    let v0: string = "hi";
    let v1: ((a0: number) => ((a0: number) => string)) = f_c0(v0);
    let v2: ((a0: number) => string) = v1(1);
    let v3: string = v2(0);
    let v4: boolean = v3 === "hi";
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
