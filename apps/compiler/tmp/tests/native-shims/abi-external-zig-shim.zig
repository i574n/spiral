fn spiral_abi_libc_abs(value: i32) i32 {
    return if (value < 0) 0 -% value else value;
}
