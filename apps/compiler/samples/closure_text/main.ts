function f_c0(v0: string): ((a0: number) => string) {
    return (v1: number): string => {
        const v2: boolean = v1 === 0;
        if (v2) {
            const v3: string = "no";
            return v3;
        } else {
            return v0;
        }
    };
}
export function main(): number {
    const v0: string = "hi";
    const v1: ((a0: number) => string) = f_c0(v0);
    const v2: string = v1(1);
    const v3: boolean = v2 === "hi";
    if (v3) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
