function g_c1(v0: string, v1: number): ((a0: number) => string) {
    return (v2: number): string => {
        const v3: boolean = v1 === 0;
        if (v3) {
            const v4: string = "no";
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
    const v0: string = "hi";
    const v1: ((a0: number) => ((a0: number) => string)) = f_c0(v0);
    const v2: ((a0: number) => string) = v1(1);
    const v3: string = v2(0);
    const v4: boolean = v3 === "hi";
    if (v4) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
