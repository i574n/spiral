function f_c0(v0: number, v1: string, v2: boolean): ((a0: number) => [number, string, boolean]) {
    return (v3: number): [number, string, boolean] => {
        const v4: boolean = v3 === 0;
        if (v4) {
            const v5: string = "no";
            return [0, v5, false];
        } else {
            return [v0, v1, v2];
        }
    };
}
export function main(): number {
    const v0: number = 4000000000;
    const v1: string = "hi";
    const v2: boolean = true;
    const v3: ((a0: number) => [number, string, boolean]) = f_c0(v0, v1, v2);
    let [v4, v5, v6]: [number, string, boolean] = v3(1);
    const v7: boolean = v4 === 4000000000;
    let v9: boolean;
    if (v7) {
        const v8: boolean = v5 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    const v10: boolean = v9 && v6;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
