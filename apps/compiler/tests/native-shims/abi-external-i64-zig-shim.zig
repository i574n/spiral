fn spiral_abi_libc_llabs(value: i64) i64 {
    return if (value < 0) 0 -% value else value;
}
