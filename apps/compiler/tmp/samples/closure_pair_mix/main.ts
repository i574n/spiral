function f_c0(v0: number, v1: string): ((a0: number) => [number, string]) {
    return (v2: number): [number, string] => {
        const v3: boolean = v2 === 0;
        if (v3) {
            const v4: string = "no";
            return [0, v4];
        } else {
            return [v0, v1];
        }
    };
}
export function main(): number {
    const v0: number = 7;
    const v1: string = "hi";
    const v2: ((a0: number) => [number, string]) = f_c0(v0, v1);
    let [v3, v4]: [number, string] = v2(1);
    const v5: boolean = v3 === 7;
    let v7: boolean;
    if (v5) {
        const v6: boolean = v4 === "hi";
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
