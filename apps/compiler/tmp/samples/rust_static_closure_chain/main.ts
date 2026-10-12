type UH0_Cons = { readonly tag: 0, readonly f0: bigint, readonly f1: (() => UH0) };
type UH0_Nil = { readonly tag: 1 };
type UH0 = UH0_Cons | UH0_Nil;
function UH0_Cons(f0: bigint, f1: (() => UH0)): UH0 { return { tag: 0, f0: f0, f1: f1 }; }
function UH0_Nil(): UH0 { return { tag: 1 }; }
function closure79(): (() => UH0) {
    return (): UH0 => {
        return UH0_Nil();
    };
}
function closure78(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure79();
        return UH0_Cons(1n, v0);
    };
}
function closure77(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure78();
        return UH0_Cons(2n, v0);
    };
}
function closure76(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure77();
        return UH0_Cons(3n, v0);
    };
}
function closure75(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure76();
        return UH0_Cons(4n, v0);
    };
}
function closure74(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure75();
        return UH0_Cons(5n, v0);
    };
}
function closure73(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure74();
        return UH0_Cons(6n, v0);
    };
}
function closure72(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure73();
        return UH0_Cons(7n, v0);
    };
}
function closure71(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure72();
        return UH0_Cons(8n, v0);
    };
}
function closure70(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure71();
        return UH0_Cons(9n, v0);
    };
}
function closure69(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure70();
        return UH0_Cons(10n, v0);
    };
}
function closure68(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure69();
        return UH0_Cons(11n, v0);
    };
}
function closure67(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure68();
        return UH0_Cons(12n, v0);
    };
}
function closure66(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure67();
        return UH0_Cons(13n, v0);
    };
}
function closure65(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure66();
        return UH0_Cons(14n, v0);
    };
}
function closure64(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure65();
        return UH0_Cons(15n, v0);
    };
}
function closure63(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure64();
        return UH0_Cons(16n, v0);
    };
}
function closure62(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure63();
        return UH0_Cons(17n, v0);
    };
}
function closure61(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure62();
        return UH0_Cons(18n, v0);
    };
}
function closure60(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure61();
        return UH0_Cons(19n, v0);
    };
}
function closure59(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure60();
        return UH0_Cons(20n, v0);
    };
}
function closure58(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure59();
        return UH0_Cons(21n, v0);
    };
}
function closure57(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure58();
        return UH0_Cons(22n, v0);
    };
}
function closure56(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure57();
        return UH0_Cons(23n, v0);
    };
}
function closure55(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure56();
        return UH0_Cons(24n, v0);
    };
}
function closure54(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure55();
        return UH0_Cons(25n, v0);
    };
}
function closure53(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure54();
        return UH0_Cons(26n, v0);
    };
}
function closure52(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure53();
        return UH0_Cons(27n, v0);
    };
}
function closure51(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure52();
        return UH0_Cons(28n, v0);
    };
}
function closure50(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure51();
        return UH0_Cons(29n, v0);
    };
}
function closure49(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure50();
        return UH0_Cons(30n, v0);
    };
}
function closure48(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure49();
        return UH0_Cons(31n, v0);
    };
}
function closure47(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure48();
        return UH0_Cons(32n, v0);
    };
}
function closure46(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure47();
        return UH0_Cons(33n, v0);
    };
}
function closure45(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure46();
        return UH0_Cons(34n, v0);
    };
}
function closure44(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure45();
        return UH0_Cons(35n, v0);
    };
}
function closure43(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure44();
        return UH0_Cons(36n, v0);
    };
}
function closure42(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure43();
        return UH0_Cons(37n, v0);
    };
}
function closure41(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure42();
        return UH0_Cons(38n, v0);
    };
}
function closure40(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure41();
        return UH0_Cons(39n, v0);
    };
}
function closure39(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure40();
        return UH0_Cons(40n, v0);
    };
}
function closure38(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure39();
        return UH0_Cons(41n, v0);
    };
}
function closure37(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure38();
        return UH0_Cons(42n, v0);
    };
}
function closure36(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure37();
        return UH0_Cons(43n, v0);
    };
}
function closure35(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure36();
        return UH0_Cons(44n, v0);
    };
}
function closure34(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure35();
        return UH0_Cons(45n, v0);
    };
}
function closure33(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure34();
        return UH0_Cons(46n, v0);
    };
}
function closure32(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure33();
        return UH0_Cons(47n, v0);
    };
}
function closure31(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure32();
        return UH0_Cons(48n, v0);
    };
}
function closure30(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure31();
        return UH0_Cons(49n, v0);
    };
}
function closure29(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure30();
        return UH0_Cons(50n, v0);
    };
}
function closure28(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure29();
        return UH0_Cons(51n, v0);
    };
}
function closure27(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure28();
        return UH0_Cons(52n, v0);
    };
}
function closure26(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure27();
        return UH0_Cons(53n, v0);
    };
}
function closure25(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure26();
        return UH0_Cons(54n, v0);
    };
}
function closure24(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure25();
        return UH0_Cons(55n, v0);
    };
}
function closure23(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure24();
        return UH0_Cons(56n, v0);
    };
}
function closure22(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure23();
        return UH0_Cons(57n, v0);
    };
}
function closure21(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure22();
        return UH0_Cons(58n, v0);
    };
}
function closure20(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure21();
        return UH0_Cons(59n, v0);
    };
}
function closure19(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure20();
        return UH0_Cons(60n, v0);
    };
}
function closure18(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure19();
        return UH0_Cons(61n, v0);
    };
}
function closure17(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure18();
        return UH0_Cons(62n, v0);
    };
}
function closure16(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure17();
        return UH0_Cons(63n, v0);
    };
}
function closure15(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure16();
        return UH0_Cons(64n, v0);
    };
}
function closure14(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure15();
        return UH0_Cons(65n, v0);
    };
}
function closure13(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure14();
        return UH0_Cons(66n, v0);
    };
}
function closure12(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure13();
        return UH0_Cons(67n, v0);
    };
}
function closure11(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure12();
        return UH0_Cons(68n, v0);
    };
}
function closure10(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure11();
        return UH0_Cons(69n, v0);
    };
}
function closure9(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure10();
        return UH0_Cons(70n, v0);
    };
}
function closure8(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure9();
        return UH0_Cons(71n, v0);
    };
}
function closure7(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure8();
        return UH0_Cons(72n, v0);
    };
}
function closure6(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure7();
        return UH0_Cons(73n, v0);
    };
}
function closure5(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure6();
        return UH0_Cons(74n, v0);
    };
}
function closure4(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure5();
        return UH0_Cons(75n, v0);
    };
}
function closure3(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure4();
        return UH0_Cons(76n, v0);
    };
}
function closure2(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure3();
        return UH0_Cons(77n, v0);
    };
}
function closure1(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure2();
        return UH0_Cons(78n, v0);
    };
}
function closure0(): (() => UH0) {
    return (): UH0 => {
        let v0: (() => UH0) = closure1();
        return UH0_Cons(79n, v0);
    };
}
function loop_0(v0: UH0, v1: bigint): bigint {
    tail: while (true) {
        switch (v0.tag) {
            case 0: {
                let v2: bigint = v0.f0;
                let v3: (() => UH0) = v0.f1;
                let v4: UH0 = v3();
                let v5: bigint = BigInt.asUintN(64, v1 + v2);
                {
                    let t0 = v4;
                    let t1 = v5;
                    v0 = t0;
                    v1 = t1;
                }
                continue tail;
                break;
            }
            case 1: {
                return v1;
                break;
            }
            default: throw new Error("Compiler error: unreachable union case.");
        }
    }
}
export function main(): number {
    let v0: bigint = 80n;
    let v1: (() => UH0) = closure0();
    let v2: UH0 = UH0_Cons(v0, v1);
    let v3: bigint = 0n;
    let v4: bigint = loop_0(v2, v3);
    let v5: bigint = BigInt.asUintN(64, v4 % 200n);
    let v6: number = Number(BigInt.asIntN(32, v5));
    return v6;
}
process.exitCode = main();
