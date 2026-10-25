import gleam/int
pub fn spiral_wrap_signed(value: Int, bits: Int) -> Int {
  let half = int.bitwise_shift_left(1, bits - 1)
  int.bitwise_and(value + half, int.bitwise_shift_left(1, bits) - 1) - half
}

pub fn spiral_wrap_unsigned(value: Int, bits: Int) -> Int {
  int.bitwise_and(value, int.bitwise_shift_left(1, bits) - 1)
}

pub type Uh0 {
    Uh0Cons(Int, fn(Nil) -> Uh0)
    Uh0Nil
}
pub fn closure79(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        Uh0Nil
    }
}
pub fn closure78(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure79(Nil)
        Uh0Cons(1, v0)
    }
}
pub fn closure77(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure78(Nil)
        Uh0Cons(2, v0)
    }
}
pub fn closure76(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure77(Nil)
        Uh0Cons(3, v0)
    }
}
pub fn closure75(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure76(Nil)
        Uh0Cons(4, v0)
    }
}
pub fn closure74(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure75(Nil)
        Uh0Cons(5, v0)
    }
}
pub fn closure73(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure74(Nil)
        Uh0Cons(6, v0)
    }
}
pub fn closure72(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure73(Nil)
        Uh0Cons(7, v0)
    }
}
pub fn closure71(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure72(Nil)
        Uh0Cons(8, v0)
    }
}
pub fn closure70(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure71(Nil)
        Uh0Cons(9, v0)
    }
}
pub fn closure69(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure70(Nil)
        Uh0Cons(10, v0)
    }
}
pub fn closure68(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure69(Nil)
        Uh0Cons(11, v0)
    }
}
pub fn closure67(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure68(Nil)
        Uh0Cons(12, v0)
    }
}
pub fn closure66(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure67(Nil)
        Uh0Cons(13, v0)
    }
}
pub fn closure65(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure66(Nil)
        Uh0Cons(14, v0)
    }
}
pub fn closure64(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure65(Nil)
        Uh0Cons(15, v0)
    }
}
pub fn closure63(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure64(Nil)
        Uh0Cons(16, v0)
    }
}
pub fn closure62(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure63(Nil)
        Uh0Cons(17, v0)
    }
}
pub fn closure61(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure62(Nil)
        Uh0Cons(18, v0)
    }
}
pub fn closure60(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure61(Nil)
        Uh0Cons(19, v0)
    }
}
pub fn closure59(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure60(Nil)
        Uh0Cons(20, v0)
    }
}
pub fn closure58(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure59(Nil)
        Uh0Cons(21, v0)
    }
}
pub fn closure57(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure58(Nil)
        Uh0Cons(22, v0)
    }
}
pub fn closure56(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure57(Nil)
        Uh0Cons(23, v0)
    }
}
pub fn closure55(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure56(Nil)
        Uh0Cons(24, v0)
    }
}
pub fn closure54(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure55(Nil)
        Uh0Cons(25, v0)
    }
}
pub fn closure53(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure54(Nil)
        Uh0Cons(26, v0)
    }
}
pub fn closure52(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure53(Nil)
        Uh0Cons(27, v0)
    }
}
pub fn closure51(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure52(Nil)
        Uh0Cons(28, v0)
    }
}
pub fn closure50(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure51(Nil)
        Uh0Cons(29, v0)
    }
}
pub fn closure49(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure50(Nil)
        Uh0Cons(30, v0)
    }
}
pub fn closure48(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure49(Nil)
        Uh0Cons(31, v0)
    }
}
pub fn closure47(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure48(Nil)
        Uh0Cons(32, v0)
    }
}
pub fn closure46(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure47(Nil)
        Uh0Cons(33, v0)
    }
}
pub fn closure45(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure46(Nil)
        Uh0Cons(34, v0)
    }
}
pub fn closure44(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure45(Nil)
        Uh0Cons(35, v0)
    }
}
pub fn closure43(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure44(Nil)
        Uh0Cons(36, v0)
    }
}
pub fn closure42(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure43(Nil)
        Uh0Cons(37, v0)
    }
}
pub fn closure41(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure42(Nil)
        Uh0Cons(38, v0)
    }
}
pub fn closure40(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure41(Nil)
        Uh0Cons(39, v0)
    }
}
pub fn closure39(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure40(Nil)
        Uh0Cons(40, v0)
    }
}
pub fn closure38(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure39(Nil)
        Uh0Cons(41, v0)
    }
}
pub fn closure37(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure38(Nil)
        Uh0Cons(42, v0)
    }
}
pub fn closure36(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure37(Nil)
        Uh0Cons(43, v0)
    }
}
pub fn closure35(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure36(Nil)
        Uh0Cons(44, v0)
    }
}
pub fn closure34(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure35(Nil)
        Uh0Cons(45, v0)
    }
}
pub fn closure33(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure34(Nil)
        Uh0Cons(46, v0)
    }
}
pub fn closure32(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure33(Nil)
        Uh0Cons(47, v0)
    }
}
pub fn closure31(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure32(Nil)
        Uh0Cons(48, v0)
    }
}
pub fn closure30(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure31(Nil)
        Uh0Cons(49, v0)
    }
}
pub fn closure29(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure30(Nil)
        Uh0Cons(50, v0)
    }
}
pub fn closure28(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure29(Nil)
        Uh0Cons(51, v0)
    }
}
pub fn closure27(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure28(Nil)
        Uh0Cons(52, v0)
    }
}
pub fn closure26(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure27(Nil)
        Uh0Cons(53, v0)
    }
}
pub fn closure25(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure26(Nil)
        Uh0Cons(54, v0)
    }
}
pub fn closure24(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure25(Nil)
        Uh0Cons(55, v0)
    }
}
pub fn closure23(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure24(Nil)
        Uh0Cons(56, v0)
    }
}
pub fn closure22(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure23(Nil)
        Uh0Cons(57, v0)
    }
}
pub fn closure21(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure22(Nil)
        Uh0Cons(58, v0)
    }
}
pub fn closure20(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure21(Nil)
        Uh0Cons(59, v0)
    }
}
pub fn closure19(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure20(Nil)
        Uh0Cons(60, v0)
    }
}
pub fn closure18(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure19(Nil)
        Uh0Cons(61, v0)
    }
}
pub fn closure17(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure18(Nil)
        Uh0Cons(62, v0)
    }
}
pub fn closure16(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure17(Nil)
        Uh0Cons(63, v0)
    }
}
pub fn closure15(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure16(Nil)
        Uh0Cons(64, v0)
    }
}
pub fn closure14(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure15(Nil)
        Uh0Cons(65, v0)
    }
}
pub fn closure13(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure14(Nil)
        Uh0Cons(66, v0)
    }
}
pub fn closure12(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure13(Nil)
        Uh0Cons(67, v0)
    }
}
pub fn closure11(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure12(Nil)
        Uh0Cons(68, v0)
    }
}
pub fn closure10(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure11(Nil)
        Uh0Cons(69, v0)
    }
}
pub fn closure9(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure10(Nil)
        Uh0Cons(70, v0)
    }
}
pub fn closure8(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure9(Nil)
        Uh0Cons(71, v0)
    }
}
pub fn closure7(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure8(Nil)
        Uh0Cons(72, v0)
    }
}
pub fn closure6(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure7(Nil)
        Uh0Cons(73, v0)
    }
}
pub fn closure5(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure6(Nil)
        Uh0Cons(74, v0)
    }
}
pub fn closure4(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure5(Nil)
        Uh0Cons(75, v0)
    }
}
pub fn closure3(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure4(Nil)
        Uh0Cons(76, v0)
    }
}
pub fn closure2(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure3(Nil)
        Uh0Cons(77, v0)
    }
}
pub fn closure1(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure2(Nil)
        Uh0Cons(78, v0)
    }
}
pub fn closure0(capt: Nil) -> fn(Nil) -> Uh0 {
    fn (dom) {
        let v0 = closure1(Nil)
        Uh0Cons(79, v0)
    }
}
pub fn loop_0(v0: Uh0, v1: Int) -> Int {
    case v0  {
        Uh0Cons(v2, v3) -> {
            let v4 = v3(Nil)
            let v5 = spiral_wrap_unsigned(v1 + v2, 64)
            loop_0(v4, v5)
        }
        Uh0Nil -> {
            v1
        }
    }
}
pub fn main() {
    let v0 = 80
    let v1 = closure0(Nil)
    let v2 = Uh0Cons(v0, v1)
    let v3 = 0
    let v4 = loop_0(v2, v3)
    let v5 = v4 % 200
    let v6 = spiral_wrap_signed(v5, 32)
    v6
}
