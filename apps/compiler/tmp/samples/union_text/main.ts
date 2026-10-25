type US0_Text = { readonly tag: 0, readonly f0: string };
type US0_Code = { readonly tag: 1, readonly f0: number };
type US0 = US0_Text | US0_Code;
function US0_Text(f0: string): US0 { return { tag: 0, f0: f0 }; }
function US0_Code(f0: number): US0 { return { tag: 1, f0: f0 }; }
function score_0(v0: US0): number {
    switch (v0.tag) {
        case 1: {
            let v4: number = v0.f0;
            return v4;
            break;
        }
        case 0: {
            let v1: string = v0.f0;
            let v2: boolean = v1 === "hi";
            if (v2) {
                return 2;
            } else {
                return 3;
            }
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
}
export function main(): number {
    let v0: boolean = true;
    let v1: string = "hi";
    let v4: US0;
    if (v0) {
        v4 = US0_Text(v1);
    } else {
        v4 = US0_Code(1);
    }
    let v7: US0;
    if (v0) {
        v7 = US0_Code(5);
    } else {
        v7 = US0_Text(v1);
    }
    let v8: number = score_0(v4);
    let v9: boolean = v8 === 2;
    let v12: boolean;
    if (v9) {
        let v10: number = score_0(v7);
        let v11: boolean = v10 === 5;
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
        return 0;
    } else {
        return 1;
    }
}
process.exitCode = main();
