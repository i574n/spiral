type SpiralFptr0 = fn(i32) -> i32;
fn f(value: i32) -> i32 {
    value + 2
}
fn main() {
    let x: i32 = 40;
    let p: SpiralFptr0 = f;
    std::process::exit((p(x)) as i32);
}
