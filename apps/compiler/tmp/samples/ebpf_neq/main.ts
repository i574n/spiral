export function main(): number {
    let v0: number = 3;
    let v1: number = 4;
    let v2: number = 1;
    let v3: number = 1;
    let v4: number = 1.5;
    let v5: number = -v4;
    let v6: boolean = v0 !== v1;
    if (v6) {
        let v7: boolean = v2 !== v3;
        if (v7) {
            return 2;
        } else {
            let v8: boolean = v5 === (-1.5);
            if (v8) {
                return 0;
            } else {
                return 3;
            }
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
