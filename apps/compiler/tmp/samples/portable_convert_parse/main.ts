type US0_0 = { readonly tag: 0, readonly f0: number };
type US0_1 = { readonly tag: 1 };
type US0 = US0_0 | US0_1;
function US0_0(f0: number): US0 { return { tag: 0, f0: f0 }; }
function US0_1(): US0 { return { tag: 1 }; }
export function main(): number {
    let v0: string = "ff";
    let v35: number = parseInt(v0, 16);
    process.stdout.write(String(v35) + "\n");
    let v67: string = "1011";
    let v86: number = parseInt(v67, 2);
    process.stdout.write(String(v86) + "\n");
    let v91: string = "-42";
    let v133: number = parseInt(v91, 10);
    process.stdout.write(String(v133) + "\n");
    let v138: string = " 123 ";
    let v648: boolean = /^\s*[+-]?\d+\s*$/.test(v138);
    let v649: bigint = (v648 ? BigInt(v138) : 0n);
    let v650: number = Number(BigInt.asIntN(32, v649));
    let v654: boolean;
    if (v648) {
        let v651: boolean = v649 >= (-2147483648n);
        if (v651) {
            let v652: boolean = v649 <= 2147483647n;
            v654 = v652;
        } else {
            v654 = false;
        }
    } else {
        v654 = false;
    }
    let v657: US0;
    if (v654) {
        v657 = US0_0(v650);
    } else {
        v657 = US0_1();
    }
    switch (v657.tag) {
        case 1: {
            let v709: string = "none";
            process.stdout.write(String(v709) + "\n");
            break;
        }
        case 0: {
            let v700: number = v657.f0;
            process.stdout.write(String(v700) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v710: string = "12x";
    let v711: boolean = /^\s*[+-]?\d+\s*$/.test(v710);
    let v712: bigint = (v711 ? BigInt(v710) : 0n);
    let v713: number = Number(BigInt.asIntN(32, v712));
    let v717: boolean;
    if (v711) {
        let v714: boolean = v712 >= (-2147483648n);
        if (v714) {
            let v715: boolean = v712 <= 2147483647n;
            v717 = v715;
        } else {
            v717 = false;
        }
    } else {
        v717 = false;
    }
    let v720: US0;
    if (v717) {
        v720 = US0_0(v713);
    } else {
        v720 = US0_1();
    }
    switch (v720.tag) {
        case 1: {
            let v722: string = "none";
            process.stdout.write(String(v722) + "\n");
            break;
        }
        case 0: {
            let v721: number = v720.f0;
            process.stdout.write(String(v721) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v723: string = "";
    let v724: boolean = /^\s*[+-]?\d+\s*$/.test(v723);
    let v725: bigint = (v724 ? BigInt(v723) : 0n);
    let v726: number = Number(BigInt.asIntN(32, v725));
    let v730: boolean;
    if (v724) {
        let v727: boolean = v725 >= (-2147483648n);
        if (v727) {
            let v728: boolean = v725 <= 2147483647n;
            v730 = v728;
        } else {
            v730 = false;
        }
    } else {
        v730 = false;
    }
    let v733: US0;
    if (v730) {
        v733 = US0_0(v726);
    } else {
        v733 = US0_1();
    }
    switch (v733.tag) {
        case 1: {
            let v735: string = "none";
            process.stdout.write(String(v735) + "\n");
            break;
        }
        case 0: {
            let v734: number = v733.f0;
            process.stdout.write(String(v734) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    let v736: string = "+7";
    let v737: boolean = /^\s*[+-]?\d+\s*$/.test(v736);
    let v738: bigint = (v737 ? BigInt(v736) : 0n);
    let v739: number = Number(BigInt.asIntN(32, v738));
    let v743: boolean;
    if (v737) {
        let v740: boolean = v738 >= (-2147483648n);
        if (v740) {
            let v741: boolean = v738 <= 2147483647n;
            v743 = v741;
        } else {
            v743 = false;
        }
    } else {
        v743 = false;
    }
    let v746: US0;
    if (v743) {
        v746 = US0_0(v739);
    } else {
        v746 = US0_1();
    }
    switch (v746.tag) {
        case 1: {
            let v748: string = "none";
            process.stdout.write(String(v748) + "\n");
            break;
        }
        case 0: {
            let v747: number = v746.f0;
            process.stdout.write(String(v747) + "\n");
            break;
        }
        default: throw new Error("Compiler error: unreachable union case.");
    }
    return 0;
}
process.exitCode = main();
