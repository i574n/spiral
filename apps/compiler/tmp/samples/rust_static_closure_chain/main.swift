import CRT
import WinSDK
protocol UH0 { var tag: Int32 { get } }
struct UH0_Cons: UH0 { var f0: UInt64; var f1: () -> UH0; var tag: Int32 { 0 } }
struct UH0_Nil: UH0 { var tag: Int32 { 1 } }
func closure79() -> () -> UH0 {
    return { () -> UH0 in
        return UH0_Nil()
    }
}
func closure78() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure79()
        return UH0_Cons(f0: (1 as UInt64), f1: v0)
    }
}
func closure77() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure78()
        return UH0_Cons(f0: (2 as UInt64), f1: v0)
    }
}
func closure76() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure77()
        return UH0_Cons(f0: (3 as UInt64), f1: v0)
    }
}
func closure75() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure76()
        return UH0_Cons(f0: (4 as UInt64), f1: v0)
    }
}
func closure74() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure75()
        return UH0_Cons(f0: (5 as UInt64), f1: v0)
    }
}
func closure73() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure74()
        return UH0_Cons(f0: (6 as UInt64), f1: v0)
    }
}
func closure72() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure73()
        return UH0_Cons(f0: (7 as UInt64), f1: v0)
    }
}
func closure71() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure72()
        return UH0_Cons(f0: (8 as UInt64), f1: v0)
    }
}
func closure70() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure71()
        return UH0_Cons(f0: (9 as UInt64), f1: v0)
    }
}
func closure69() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure70()
        return UH0_Cons(f0: (10 as UInt64), f1: v0)
    }
}
func closure68() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure69()
        return UH0_Cons(f0: (11 as UInt64), f1: v0)
    }
}
func closure67() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure68()
        return UH0_Cons(f0: (12 as UInt64), f1: v0)
    }
}
func closure66() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure67()
        return UH0_Cons(f0: (13 as UInt64), f1: v0)
    }
}
func closure65() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure66()
        return UH0_Cons(f0: (14 as UInt64), f1: v0)
    }
}
func closure64() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure65()
        return UH0_Cons(f0: (15 as UInt64), f1: v0)
    }
}
func closure63() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure64()
        return UH0_Cons(f0: (16 as UInt64), f1: v0)
    }
}
func closure62() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure63()
        return UH0_Cons(f0: (17 as UInt64), f1: v0)
    }
}
func closure61() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure62()
        return UH0_Cons(f0: (18 as UInt64), f1: v0)
    }
}
func closure60() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure61()
        return UH0_Cons(f0: (19 as UInt64), f1: v0)
    }
}
func closure59() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure60()
        return UH0_Cons(f0: (20 as UInt64), f1: v0)
    }
}
func closure58() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure59()
        return UH0_Cons(f0: (21 as UInt64), f1: v0)
    }
}
func closure57() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure58()
        return UH0_Cons(f0: (22 as UInt64), f1: v0)
    }
}
func closure56() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure57()
        return UH0_Cons(f0: (23 as UInt64), f1: v0)
    }
}
func closure55() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure56()
        return UH0_Cons(f0: (24 as UInt64), f1: v0)
    }
}
func closure54() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure55()
        return UH0_Cons(f0: (25 as UInt64), f1: v0)
    }
}
func closure53() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure54()
        return UH0_Cons(f0: (26 as UInt64), f1: v0)
    }
}
func closure52() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure53()
        return UH0_Cons(f0: (27 as UInt64), f1: v0)
    }
}
func closure51() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure52()
        return UH0_Cons(f0: (28 as UInt64), f1: v0)
    }
}
func closure50() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure51()
        return UH0_Cons(f0: (29 as UInt64), f1: v0)
    }
}
func closure49() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure50()
        return UH0_Cons(f0: (30 as UInt64), f1: v0)
    }
}
func closure48() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure49()
        return UH0_Cons(f0: (31 as UInt64), f1: v0)
    }
}
func closure47() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure48()
        return UH0_Cons(f0: (32 as UInt64), f1: v0)
    }
}
func closure46() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure47()
        return UH0_Cons(f0: (33 as UInt64), f1: v0)
    }
}
func closure45() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure46()
        return UH0_Cons(f0: (34 as UInt64), f1: v0)
    }
}
func closure44() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure45()
        return UH0_Cons(f0: (35 as UInt64), f1: v0)
    }
}
func closure43() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure44()
        return UH0_Cons(f0: (36 as UInt64), f1: v0)
    }
}
func closure42() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure43()
        return UH0_Cons(f0: (37 as UInt64), f1: v0)
    }
}
func closure41() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure42()
        return UH0_Cons(f0: (38 as UInt64), f1: v0)
    }
}
func closure40() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure41()
        return UH0_Cons(f0: (39 as UInt64), f1: v0)
    }
}
func closure39() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure40()
        return UH0_Cons(f0: (40 as UInt64), f1: v0)
    }
}
func closure38() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure39()
        return UH0_Cons(f0: (41 as UInt64), f1: v0)
    }
}
func closure37() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure38()
        return UH0_Cons(f0: (42 as UInt64), f1: v0)
    }
}
func closure36() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure37()
        return UH0_Cons(f0: (43 as UInt64), f1: v0)
    }
}
func closure35() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure36()
        return UH0_Cons(f0: (44 as UInt64), f1: v0)
    }
}
func closure34() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure35()
        return UH0_Cons(f0: (45 as UInt64), f1: v0)
    }
}
func closure33() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure34()
        return UH0_Cons(f0: (46 as UInt64), f1: v0)
    }
}
func closure32() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure33()
        return UH0_Cons(f0: (47 as UInt64), f1: v0)
    }
}
func closure31() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure32()
        return UH0_Cons(f0: (48 as UInt64), f1: v0)
    }
}
func closure30() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure31()
        return UH0_Cons(f0: (49 as UInt64), f1: v0)
    }
}
func closure29() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure30()
        return UH0_Cons(f0: (50 as UInt64), f1: v0)
    }
}
func closure28() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure29()
        return UH0_Cons(f0: (51 as UInt64), f1: v0)
    }
}
func closure27() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure28()
        return UH0_Cons(f0: (52 as UInt64), f1: v0)
    }
}
func closure26() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure27()
        return UH0_Cons(f0: (53 as UInt64), f1: v0)
    }
}
func closure25() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure26()
        return UH0_Cons(f0: (54 as UInt64), f1: v0)
    }
}
func closure24() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure25()
        return UH0_Cons(f0: (55 as UInt64), f1: v0)
    }
}
func closure23() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure24()
        return UH0_Cons(f0: (56 as UInt64), f1: v0)
    }
}
func closure22() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure23()
        return UH0_Cons(f0: (57 as UInt64), f1: v0)
    }
}
func closure21() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure22()
        return UH0_Cons(f0: (58 as UInt64), f1: v0)
    }
}
func closure20() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure21()
        return UH0_Cons(f0: (59 as UInt64), f1: v0)
    }
}
func closure19() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure20()
        return UH0_Cons(f0: (60 as UInt64), f1: v0)
    }
}
func closure18() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure19()
        return UH0_Cons(f0: (61 as UInt64), f1: v0)
    }
}
func closure17() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure18()
        return UH0_Cons(f0: (62 as UInt64), f1: v0)
    }
}
func closure16() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure17()
        return UH0_Cons(f0: (63 as UInt64), f1: v0)
    }
}
func closure15() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure16()
        return UH0_Cons(f0: (64 as UInt64), f1: v0)
    }
}
func closure14() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure15()
        return UH0_Cons(f0: (65 as UInt64), f1: v0)
    }
}
func closure13() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure14()
        return UH0_Cons(f0: (66 as UInt64), f1: v0)
    }
}
func closure12() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure13()
        return UH0_Cons(f0: (67 as UInt64), f1: v0)
    }
}
func closure11() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure12()
        return UH0_Cons(f0: (68 as UInt64), f1: v0)
    }
}
func closure10() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure11()
        return UH0_Cons(f0: (69 as UInt64), f1: v0)
    }
}
func closure9() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure10()
        return UH0_Cons(f0: (70 as UInt64), f1: v0)
    }
}
func closure8() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure9()
        return UH0_Cons(f0: (71 as UInt64), f1: v0)
    }
}
func closure7() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure8()
        return UH0_Cons(f0: (72 as UInt64), f1: v0)
    }
}
func closure6() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure7()
        return UH0_Cons(f0: (73 as UInt64), f1: v0)
    }
}
func closure5() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure6()
        return UH0_Cons(f0: (74 as UInt64), f1: v0)
    }
}
func closure4() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure5()
        return UH0_Cons(f0: (75 as UInt64), f1: v0)
    }
}
func closure3() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure4()
        return UH0_Cons(f0: (76 as UInt64), f1: v0)
    }
}
func closure2() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure3()
        return UH0_Cons(f0: (77 as UInt64), f1: v0)
    }
}
func closure1() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure2()
        return UH0_Cons(f0: (78 as UInt64), f1: v0)
    }
}
func closure0() -> () -> UH0 {
    return { () -> UH0 in
        var v0: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
        v0 = closure1()
        return UH0_Cons(f0: (79 as UInt64), f1: v0)
    }
}
func sp_loop_0(_ p0: UH0, _ p1: UInt64) -> UInt64 {
    var v0: UH0 = p0
    var v1: UInt64 = p1
    switch v0.tag {
        case 0:
            var v2: UInt64 = (v0 as! UH0_Cons).f0
            var v3: () -> UH0 = (v0 as! UH0_Cons).f1
            var v4: UH0 = UH0_Cons(f0: (0 as UInt64), f1: { () -> UH0 in fatalError("unreachable closure") })
            v4 = v3()
            var v5: UInt64 = (0 as UInt64)
            v5 = (v1 &+ v2)
            return sp_loop_0(v4, v5)
        case 1:
            return v1
        default:
            fatalError("unreachable union case")
    }
}
func spiral_main() -> Int32 {
    var v0: UInt64 = (0 as UInt64)
    v0 = (80 as UInt64)
    var v1: () -> UH0 = { () -> UH0 in fatalError("unreachable closure") }
    v1 = closure0()
    var v2: UH0 = UH0_Cons(f0: (0 as UInt64), f1: { () -> UH0 in fatalError("unreachable closure") })
    v2 = UH0_Cons(f0: v0, f1: v1)
    var v3: UInt64 = (0 as UInt64)
    v3 = (0 as UInt64)
    var v4: UInt64 = (0 as UInt64)
    v4 = sp_loop_0(v2, v3)
    var v5: UInt64 = (0 as UInt64)
    v5 = (v4 % (200 as UInt64))
    var v6: Int32 = 0
    v6 = Int32(v5)
    return v6
}
nonisolated(unsafe) var spiral_exit_code: Int32 = 0
let spiral_thread = CreateThread(nil, 1 << 30, { _ in spiral_exit_code = spiral_main(); return 0 }, nil, DWORD(STACK_SIZE_PARAM_IS_A_RESERVATION), nil)
WaitForSingleObject(spiral_thread, INFINITE)
exit(spiral_exit_code)
