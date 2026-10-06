#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
#![recursion_limit = "512"]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum UH0 {
    UH0_0(u64, Rc<dyn Fn() -> Rc<UH0>>),
    UH0_1,
}
impl UH0 {
    fn tag(&self) -> i32 {
        match self {
            UH0::UH0_0(..) => 0,
            UH0::UH0_1 => 1,
        }
    }
}
fn closure79() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_1); } CASE.with(|case| case.clone()) }
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure78() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure79();
        Rc::new(UH0::UH0_0(1u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure77() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure78();
        Rc::new(UH0::UH0_0(2u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure76() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure77();
        Rc::new(UH0::UH0_0(3u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure75() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure76();
        Rc::new(UH0::UH0_0(4u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure74() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure75();
        Rc::new(UH0::UH0_0(5u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure73() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure74();
        Rc::new(UH0::UH0_0(6u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure72() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure73();
        Rc::new(UH0::UH0_0(7u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure71() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure72();
        Rc::new(UH0::UH0_0(8u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure70() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure71();
        Rc::new(UH0::UH0_0(9u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure69() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure70();
        Rc::new(UH0::UH0_0(10u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure68() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure69();
        Rc::new(UH0::UH0_0(11u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure67() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure68();
        Rc::new(UH0::UH0_0(12u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure66() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure67();
        Rc::new(UH0::UH0_0(13u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure65() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure66();
        Rc::new(UH0::UH0_0(14u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure64() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure65();
        Rc::new(UH0::UH0_0(15u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure63() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure64();
        Rc::new(UH0::UH0_0(16u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure62() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure63();
        Rc::new(UH0::UH0_0(17u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure61() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure62();
        Rc::new(UH0::UH0_0(18u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure60() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure61();
        Rc::new(UH0::UH0_0(19u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure59() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure60();
        Rc::new(UH0::UH0_0(20u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure58() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure59();
        Rc::new(UH0::UH0_0(21u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure57() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure58();
        Rc::new(UH0::UH0_0(22u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure56() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure57();
        Rc::new(UH0::UH0_0(23u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure55() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure56();
        Rc::new(UH0::UH0_0(24u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure54() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure55();
        Rc::new(UH0::UH0_0(25u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure53() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure54();
        Rc::new(UH0::UH0_0(26u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure52() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure53();
        Rc::new(UH0::UH0_0(27u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure51() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure52();
        Rc::new(UH0::UH0_0(28u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure50() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure51();
        Rc::new(UH0::UH0_0(29u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure49() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure50();
        Rc::new(UH0::UH0_0(30u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure48() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure49();
        Rc::new(UH0::UH0_0(31u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure47() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure48();
        Rc::new(UH0::UH0_0(32u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure46() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure47();
        Rc::new(UH0::UH0_0(33u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure45() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure46();
        Rc::new(UH0::UH0_0(34u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure44() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure45();
        Rc::new(UH0::UH0_0(35u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure43() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure44();
        Rc::new(UH0::UH0_0(36u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure42() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure43();
        Rc::new(UH0::UH0_0(37u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure41() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure42();
        Rc::new(UH0::UH0_0(38u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure40() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure41();
        Rc::new(UH0::UH0_0(39u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure39() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure40();
        Rc::new(UH0::UH0_0(40u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure38() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure39();
        Rc::new(UH0::UH0_0(41u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure37() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure38();
        Rc::new(UH0::UH0_0(42u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure36() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure37();
        Rc::new(UH0::UH0_0(43u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure35() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure36();
        Rc::new(UH0::UH0_0(44u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure34() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure35();
        Rc::new(UH0::UH0_0(45u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure33() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure34();
        Rc::new(UH0::UH0_0(46u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure32() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure33();
        Rc::new(UH0::UH0_0(47u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure31() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure32();
        Rc::new(UH0::UH0_0(48u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure30() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure31();
        Rc::new(UH0::UH0_0(49u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure29() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure30();
        Rc::new(UH0::UH0_0(50u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure28() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure29();
        Rc::new(UH0::UH0_0(51u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure27() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure28();
        Rc::new(UH0::UH0_0(52u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure26() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure27();
        Rc::new(UH0::UH0_0(53u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure25() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure26();
        Rc::new(UH0::UH0_0(54u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure24() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure25();
        Rc::new(UH0::UH0_0(55u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure23() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure24();
        Rc::new(UH0::UH0_0(56u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure22() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure23();
        Rc::new(UH0::UH0_0(57u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure21() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure22();
        Rc::new(UH0::UH0_0(58u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure20() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure21();
        Rc::new(UH0::UH0_0(59u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure19() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure20();
        Rc::new(UH0::UH0_0(60u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure18() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure19();
        Rc::new(UH0::UH0_0(61u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure17() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure18();
        Rc::new(UH0::UH0_0(62u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure16() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure17();
        Rc::new(UH0::UH0_0(63u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure15() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure16();
        Rc::new(UH0::UH0_0(64u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure14() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure15();
        Rc::new(UH0::UH0_0(65u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure13() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure14();
        Rc::new(UH0::UH0_0(66u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure12() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure13();
        Rc::new(UH0::UH0_0(67u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure11() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure12();
        Rc::new(UH0::UH0_0(68u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure10() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure11();
        Rc::new(UH0::UH0_0(69u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure9() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure10();
        Rc::new(UH0::UH0_0(70u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure8() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure9();
        Rc::new(UH0::UH0_0(71u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure7() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure8();
        Rc::new(UH0::UH0_0(72u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure6() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure7();
        Rc::new(UH0::UH0_0(73u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure5() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure6();
        Rc::new(UH0::UH0_0(74u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure4() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure5();
        Rc::new(UH0::UH0_0(75u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure3() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure4();
        Rc::new(UH0::UH0_0(76u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure2() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure3();
        Rc::new(UH0::UH0_0(77u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure1() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure2();
        Rc::new(UH0::UH0_0(78u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn closure0() -> Rc<dyn Fn() -> Rc<UH0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn() -> Rc<UH0>> = Rc::new(move || -> Rc<UH0> {
        let mut v0: Rc<dyn Fn() -> Rc<UH0>> = closure1();
        Rc::new(UH0::UH0_0(79u64, v0.clone()))
    }); }
    CLOSURE.with(|closure| closure.clone())
}
fn method0(mut v0: Rc<UH0>, mut v1: u64) -> u64 {
    loop {
        match &*v0 {
            UH0::UH0_0(v2, v3) => { // Cons
                let mut v2: u64 = v2.clone();
                let mut v3: Rc<dyn Fn() -> Rc<UH0>> = v3.clone();
                let mut v4: Rc<UH0> = v3();
                let mut v5: u64 = v1 + v2;
                (v0, v1) = (v4.clone(), v5);
                continue;
            }
            UH0::UH0_1 => { // Nil
                return v1;
            }
            _ => unreachable!(),
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: u64 = 80u64;
    let mut v1: Rc<dyn Fn() -> Rc<UH0>> = closure0();
    let mut v2: Rc<UH0> = Rc::new(UH0::UH0_0(v0, v1.clone()));
    let mut v3: u64 = 0u64;
    let mut v4: u64 = method0(v2.clone(), v3);
    let mut v5: u64 = v4 % 200u64;
    let mut v6: i32 = (v5 as i32);
    v6
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
