type US0_0 = { readonly tag: 0, readonly f0: number };
type US0_1 = { readonly tag: 1 };
type US0 = US0_0 | US0_1;
function US0_0(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_1(): US0 { return { tag: 1 }; }
export function main(): number {
    let v0: string = "ff";
    let v36: number = parseInt(v0, 16);
    process.stdout.write(String(v36) + "\n");
    let v69: string = "1011";
    let v88: number = parseInt(v69, 2);
    process.stdout.write(String(v88) + "\n");
    let v94: string = "-42";
    let v137: number = parseInt(v94, 10);
    process.stdout.write(String(v137) + "\n");
    let v143: string = " 123 ";
    let v733: boolean = /^\s*[+-]?\d+\s*$/.test(v143);
    let v734: bigint = (v733 ? BigInt(v143) : 0n);
    let v735: number = Number(BigInt.asIntN(32, v734));
    let v739: boolean;
    if (v733) {
        let v736: boolean = v734 >= (-2147483648n);
        if (v736) {
            let v737: boolean = v734 <= 2147483647n;
            v739 = v737;
        } else {
            v739 = false;
        }
    } else {
        v739 = false;
    }
    let v742: US0;
    if (v739) {
        v742 = US0_0(v735);
    } else {
        v742 = US0_1();
    }
    switch (v742.tag) {
        case 1: {
            let v804: string = "none";
            process.stdout.write(String(v804) + "\n");
            break;
        }
        case 0: {
            let v795: number = v742.f0;
            process.stdout.write(String(v795) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v805: string = "12x";
    let v806: boolean = /^\s*[+-]?\d+\s*$/.test(v805);
    let v807: bigint = (v806 ? BigInt(v805) : 0n);
    let v808: number = Number(BigInt.asIntN(32, v807));
    let v812: boolean;
    if (v806) {
        let v809: boolean = v807 >= (-2147483648n);
        if (v809) {
            let v810: boolean = v807 <= 2147483647n;
            v812 = v810;
        } else {
            v812 = false;
        }
    } else {
        v812 = false;
    }
    let v815: US0;
    if (v812) {
        v815 = US0_0(v808);
    } else {
        v815 = US0_1();
    }
    switch (v815.tag) {
        case 1: {
            let v817: string = "none";
            process.stdout.write(String(v817) + "\n");
            break;
        }
        case 0: {
            let v816: number = v815.f0;
            process.stdout.write(String(v816) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v818: string = "";
    let v819: boolean = /^\s*[+-]?\d+\s*$/.test(v818);
    let v820: bigint = (v819 ? BigInt(v818) : 0n);
    let v821: number = Number(BigInt.asIntN(32, v820));
    let v825: boolean;
    if (v819) {
        let v822: boolean = v820 >= (-2147483648n);
        if (v822) {
            let v823: boolean = v820 <= 2147483647n;
            v825 = v823;
        } else {
            v825 = false;
        }
    } else {
        v825 = false;
    }
    let v828: US0;
    if (v825) {
        v828 = US0_0(v821);
    } else {
        v828 = US0_1();
    }
    switch (v828.tag) {
        case 1: {
            let v830: string = "none";
            process.stdout.write(String(v830) + "\n");
            break;
        }
        case 0: {
            let v829: number = v828.f0;
            process.stdout.write(String(v829) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v831: string = "+7";
    let v832: boolean = /^\s*[+-]?\d+\s*$/.test(v831);
    let v833: bigint = (v832 ? BigInt(v831) : 0n);
    let v834: number = Number(BigInt.asIntN(32, v833));
    let v838: boolean;
    if (v832) {
        let v835: boolean = v833 >= (-2147483648n);
        if (v835) {
            let v836: boolean = v833 <= 2147483647n;
            v838 = v836;
        } else {
            v838 = false;
        }
    } else {
        v838 = false;
    }
    let v841: US0;
    if (v838) {
        v841 = US0_0(v834);
    } else {
        v841 = US0_1();
    }
    switch (v841.tag) {
        case 1: {
            let v843: string = "none";
            process.stdout.write(String(v843) + "\n");
            break;
        }
        case 0: {
            let v842: number = v841.f0;
            process.stdout.write(String(v842) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    return 0;
}
process.exitCode = main();
