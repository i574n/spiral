function f_c0(v0: string, v1: string): ((a0: number) => [string, string]) {
    return (v2: number): [string, string] => {
        const v3: boolean = v2 === 0;
        if (v3) {
            const v4: string = "no";
            const v5: string = "nay";
            return [v4, v5];
        } else {
            return [v0, v1];
        }
    };
}
export function main(): number {
    const v0: string = "hi";
    const v1: string = "yo";
    const v2: ((a0: number) => [string, string]) = f_c0(v0, v1);
    let [v3, v4]: [string, string] = v2(1);
    const v5: boolean = v3 === "hi";
    let v7: boolean;
    if (v5) {
        const v6: boolean = v4 === "yo";
        v7 = v6;
    } else {
        v7 = false;
    }
    if (v7) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
