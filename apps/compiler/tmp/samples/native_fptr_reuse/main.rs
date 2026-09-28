type SpiralFptr0 = fn(i32) -> i32;
fn f(value: i32) -> i32 {
    value + 2
}
fn main() {
    let p: SpiralFptr0 = f;
    let a: i32 = p(19);
    let b: i32 = p(19);
    std::process::exit((a + b) as i32);
}
