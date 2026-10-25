function method0(v0: number): string {
    const v1: boolean = v0 === 0;
    if (v1) {
        const v2: string = "no";
        return v2;
    } else {
        const v3: string = "hi";
        return v3;
    }
}
export function main(): number {
    const v0: number = 7;
    const v1: string = method0(v0);
    const v2: boolean = v1 === "hi";
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
