type US1_Living = { readonly tag: 0, readonly f0: number, readonly f1: number };
type US1 = US1_Living;
function US1_Living(f0: number, f1: number): US1 { return { tag: 0, f0: f0, f1: f1 }; }
type US2_Fallen = { readonly tag: 1, readonly f0: number };
type US2 = US2_Fallen;
function US2_Fallen(f0: number): US2 { return { tag: 1, f0: f0 }; }
type US0_Survived = { readonly tag: 0, readonly f0: US1 };
type US0_Slain = { readonly tag: 1, readonly f0: US2 };
type US0 = US0_Survived | US0_Slain;
function US0_Survived(f0: US1): US0 { return { tag: 0, f0: f0 }; }
function US0_Slain(f0: US2): US0 { return { tag: 1, f0: f0 }; }
export function main(): number {
    const v0: number = 60;
    const v1: boolean = v0 > 0;
    let v6: US0;
    if (v1) {
        const v2: US1 = US1_Living(v0, 100);
        v6 = US0_Survived(v2);
    } else {
        const v4: US2 = US2_Fallen(100);
        v6 = US0_Slain(v4);
    }
    switch (v6.tag) {
        case 1: {
            const v13: US2 = v6.f0;
            return 2;
        }
        case 0: {
            const v7: US1 = v6.f0;
            switch (v7.tag) {
                case 0: {
                    const v8: number = v7.f0;
                    const v9: number = v7.f1;
                    const v10: boolean = v8 === 60;
                    if (v10) {
                        return 0;
                    } else {
                        return 1;
                    }
                    break;
                }
                default: throw new Error("Compiler error: unreachable union case.");
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
process.exitCode = main();
