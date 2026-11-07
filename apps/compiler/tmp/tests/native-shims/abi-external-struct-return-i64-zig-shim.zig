fn spiral_abi_libc_lldiv_pack(numerator: i64, denominator: i64) i64 {
    return @divTrunc(numerator, denominator) * denominator + @rem(numerator, denominator);
}
