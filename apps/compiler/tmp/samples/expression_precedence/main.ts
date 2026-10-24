function method0(v0: number, v1: number): boolean {
    const v2: number = -v0 ;
    const v3: boolean = v2 <= 0;
    if (v3) {
        const v4: number = Math.imul(v1, 2);
        const v5: number = (v0 + v4) | 0;
        const v6: boolean = v5 >= 9;
        if (v6) {
            return true;
        } else {
            const v7: boolean = v1 === 0;
            return v7;
        }
    } else {
        return false;
    }
}
export function main(): number {
    const v0: number = 3;
    const v1: number = 3;
    const v2: boolean = method0(v0, v1);
    if (v2) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
