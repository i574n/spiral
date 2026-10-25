export function main(): number {
    let v0: number = 65;
    let v1: number = 66;
    let v2: boolean = v0 === 65;
    if (v2) {
        let v3: boolean = v1 === 66;
        if (v3) {
            let v4: boolean = v0 === v1;
            if (v4) {
                return 2;
            } else {
                return 0;
            }
        } else {
            return 3;
        }
    } else {
        return 1;
    }
}
process.exitCode = main();
