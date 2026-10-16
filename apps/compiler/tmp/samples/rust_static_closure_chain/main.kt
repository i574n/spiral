sealed interface UH0 { val tag: Int }
data class UH0_Cons(val f0: ULong, val f1: () -> UH0) : UH0 { override val tag: Int = 0 }
class UH0_Nil : UH0 { override val tag: Int = 1 }
fun closure79(): () -> UH0 {
    fun body(): UH0 {
        return UH0_Nil()
    }
    return { body() }
}
fun closure78(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure79()
        return UH0_Cons(1uL, v0)
    }
    return { body() }
}
fun closure77(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure78()
        return UH0_Cons(2uL, v0)
    }
    return { body() }
}
fun closure76(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure77()
        return UH0_Cons(3uL, v0)
    }
    return { body() }
}
fun closure75(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure76()
        return UH0_Cons(4uL, v0)
    }
    return { body() }
}
fun closure74(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure75()
        return UH0_Cons(5uL, v0)
    }
    return { body() }
}
fun closure73(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure74()
        return UH0_Cons(6uL, v0)
    }
    return { body() }
}
fun closure72(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure73()
        return UH0_Cons(7uL, v0)
    }
    return { body() }
}
fun closure71(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure72()
        return UH0_Cons(8uL, v0)
    }
    return { body() }
}
fun closure70(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure71()
        return UH0_Cons(9uL, v0)
    }
    return { body() }
}
fun closure69(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure70()
        return UH0_Cons(10uL, v0)
    }
    return { body() }
}
fun closure68(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure69()
        return UH0_Cons(11uL, v0)
    }
    return { body() }
}
fun closure67(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure68()
        return UH0_Cons(12uL, v0)
    }
    return { body() }
}
fun closure66(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure67()
        return UH0_Cons(13uL, v0)
    }
    return { body() }
}
fun closure65(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure66()
        return UH0_Cons(14uL, v0)
    }
    return { body() }
}
fun closure64(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure65()
        return UH0_Cons(15uL, v0)
    }
    return { body() }
}
fun closure63(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure64()
        return UH0_Cons(16uL, v0)
    }
    return { body() }
}
fun closure62(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure63()
        return UH0_Cons(17uL, v0)
    }
    return { body() }
}
fun closure61(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure62()
        return UH0_Cons(18uL, v0)
    }
    return { body() }
}
fun closure60(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure61()
        return UH0_Cons(19uL, v0)
    }
    return { body() }
}
fun closure59(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure60()
        return UH0_Cons(20uL, v0)
    }
    return { body() }
}
fun closure58(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure59()
        return UH0_Cons(21uL, v0)
    }
    return { body() }
}
fun closure57(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure58()
        return UH0_Cons(22uL, v0)
    }
    return { body() }
}
fun closure56(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure57()
        return UH0_Cons(23uL, v0)
    }
    return { body() }
}
fun closure55(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure56()
        return UH0_Cons(24uL, v0)
    }
    return { body() }
}
fun closure54(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure55()
        return UH0_Cons(25uL, v0)
    }
    return { body() }
}
fun closure53(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure54()
        return UH0_Cons(26uL, v0)
    }
    return { body() }
}
fun closure52(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure53()
        return UH0_Cons(27uL, v0)
    }
    return { body() }
}
fun closure51(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure52()
        return UH0_Cons(28uL, v0)
    }
    return { body() }
}
fun closure50(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure51()
        return UH0_Cons(29uL, v0)
    }
    return { body() }
}
fun closure49(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure50()
        return UH0_Cons(30uL, v0)
    }
    return { body() }
}
fun closure48(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure49()
        return UH0_Cons(31uL, v0)
    }
    return { body() }
}
fun closure47(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure48()
        return UH0_Cons(32uL, v0)
    }
    return { body() }
}
fun closure46(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure47()
        return UH0_Cons(33uL, v0)
    }
    return { body() }
}
fun closure45(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure46()
        return UH0_Cons(34uL, v0)
    }
    return { body() }
}
fun closure44(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure45()
        return UH0_Cons(35uL, v0)
    }
    return { body() }
}
fun closure43(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure44()
        return UH0_Cons(36uL, v0)
    }
    return { body() }
}
fun closure42(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure43()
        return UH0_Cons(37uL, v0)
    }
    return { body() }
}
fun closure41(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure42()
        return UH0_Cons(38uL, v0)
    }
    return { body() }
}
fun closure40(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure41()
        return UH0_Cons(39uL, v0)
    }
    return { body() }
}
fun closure39(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure40()
        return UH0_Cons(40uL, v0)
    }
    return { body() }
}
fun closure38(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure39()
        return UH0_Cons(41uL, v0)
    }
    return { body() }
}
fun closure37(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure38()
        return UH0_Cons(42uL, v0)
    }
    return { body() }
}
fun closure36(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure37()
        return UH0_Cons(43uL, v0)
    }
    return { body() }
}
fun closure35(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure36()
        return UH0_Cons(44uL, v0)
    }
    return { body() }
}
fun closure34(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure35()
        return UH0_Cons(45uL, v0)
    }
    return { body() }
}
fun closure33(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure34()
        return UH0_Cons(46uL, v0)
    }
    return { body() }
}
fun closure32(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure33()
        return UH0_Cons(47uL, v0)
    }
    return { body() }
}
fun closure31(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure32()
        return UH0_Cons(48uL, v0)
    }
    return { body() }
}
fun closure30(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure31()
        return UH0_Cons(49uL, v0)
    }
    return { body() }
}
fun closure29(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure30()
        return UH0_Cons(50uL, v0)
    }
    return { body() }
}
fun closure28(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure29()
        return UH0_Cons(51uL, v0)
    }
    return { body() }
}
fun closure27(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure28()
        return UH0_Cons(52uL, v0)
    }
    return { body() }
}
fun closure26(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure27()
        return UH0_Cons(53uL, v0)
    }
    return { body() }
}
fun closure25(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure26()
        return UH0_Cons(54uL, v0)
    }
    return { body() }
}
fun closure24(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure25()
        return UH0_Cons(55uL, v0)
    }
    return { body() }
}
fun closure23(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure24()
        return UH0_Cons(56uL, v0)
    }
    return { body() }
}
fun closure22(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure23()
        return UH0_Cons(57uL, v0)
    }
    return { body() }
}
fun closure21(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure22()
        return UH0_Cons(58uL, v0)
    }
    return { body() }
}
fun closure20(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure21()
        return UH0_Cons(59uL, v0)
    }
    return { body() }
}
fun closure19(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure20()
        return UH0_Cons(60uL, v0)
    }
    return { body() }
}
fun closure18(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure19()
        return UH0_Cons(61uL, v0)
    }
    return { body() }
}
fun closure17(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure18()
        return UH0_Cons(62uL, v0)
    }
    return { body() }
}
fun closure16(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure17()
        return UH0_Cons(63uL, v0)
    }
    return { body() }
}
fun closure15(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure16()
        return UH0_Cons(64uL, v0)
    }
    return { body() }
}
fun closure14(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure15()
        return UH0_Cons(65uL, v0)
    }
    return { body() }
}
fun closure13(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure14()
        return UH0_Cons(66uL, v0)
    }
    return { body() }
}
fun closure12(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure13()
        return UH0_Cons(67uL, v0)
    }
    return { body() }
}
fun closure11(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure12()
        return UH0_Cons(68uL, v0)
    }
    return { body() }
}
fun closure10(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure11()
        return UH0_Cons(69uL, v0)
    }
    return { body() }
}
fun closure9(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure10()
        return UH0_Cons(70uL, v0)
    }
    return { body() }
}
fun closure8(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure9()
        return UH0_Cons(71uL, v0)
    }
    return { body() }
}
fun closure7(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure8()
        return UH0_Cons(72uL, v0)
    }
    return { body() }
}
fun closure6(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure7()
        return UH0_Cons(73uL, v0)
    }
    return { body() }
}
fun closure5(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure6()
        return UH0_Cons(74uL, v0)
    }
    return { body() }
}
fun closure4(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure5()
        return UH0_Cons(75uL, v0)
    }
    return { body() }
}
fun closure3(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure4()
        return UH0_Cons(76uL, v0)
    }
    return { body() }
}
fun closure2(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure3()
        return UH0_Cons(77uL, v0)
    }
    return { body() }
}
fun closure1(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure2()
        return UH0_Cons(78uL, v0)
    }
    return { body() }
}
fun closure0(): () -> UH0 {
    fun body(): UH0 {
        var v0: () -> UH0 = { throw RuntimeException() }
        v0 = closure1()
        return UH0_Cons(79uL, v0)
    }
    return { body() }
}
fun sp_loop_0(p0: UH0, p1: ULong): ULong {
    var v0: UH0 = p0
    var v1: ULong = p1
    when (v0.tag) {
        0 -> {
            var v2: ULong = (v0 as UH0_Cons).f0
            var v3: () -> UH0 = (v0 as UH0_Cons).f1
            var v4: UH0 = UH0_Cons(0uL, { throw RuntimeException() })
            v4 = v3()
            var v5: ULong = 0uL
            v5 = (v1 + v2)
            return sp_loop_0(v4, v5)
        }
        1 -> {
            return v1
        }
        else -> throw RuntimeException()
    }
}
fun spiral_main(): Int {
    var v0: ULong = 0uL
    v0 = 80uL
    var v1: () -> UH0 = { throw RuntimeException() }
    v1 = closure0()
    var v2: UH0 = UH0_Cons(0uL, { throw RuntimeException() })
    v2 = UH0_Cons(v0, v1)
    var v3: ULong = 0uL
    v3 = 0uL
    var v4: ULong = 0uL
    v4 = sp_loop_0(v2, v3)
    var v5: ULong = 0uL
    v5 = (v4 % 200uL)
    var v6: Int = 0
    v6 = (v5).toInt()
    return v6
}
fun main() {
    System.exit(spiral_main())
}
