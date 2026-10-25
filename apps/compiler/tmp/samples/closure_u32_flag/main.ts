function f_c0(v0: number, v1: string, v2: boolean): ((a0: number) => [number, string, boolean]) {
    return (v3: number): [number, string, boolean] => {
        let v4: boolean = v3 === 0;
        if (v4) {
            let v5: string = "no";
            return [0, v5, false];
        } else {
            return [v0, v1, v2];
        }
    };
}
export function main(): number {
    let v0: number = 4000000000;
    let v1: string = "hi";
    let v2: boolean = true;
    let v3: ((a0: number) => [number, string, boolean]) = f_c0(v0, v1, v2);
    let [v4, v5, v6]: [number, string, boolean] = v3(1);
    let v7: boolean = v4 === 4000000000;
    let v9: boolean;
    if (v7) {
        let v8: boolean = v5 === "hi";
        v9 = v8;
    } else {
        v9 = false;
    }
    let v10: boolean = v9 && v6;
    if (v10) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
