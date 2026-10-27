fn spiral_abi_libc_div_pack(numerator: i32, denominator: i32) i32 {
    return @divTrunc(numerator, denominator) * 10 + @rem(numerator, denominator);
}
