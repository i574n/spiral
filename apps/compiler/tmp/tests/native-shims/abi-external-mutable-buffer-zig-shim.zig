fn spiral_abi_libc_memset(array: []u8, byte_value: i32, count: i32) i32 {
    if (count < 0 or @as(usize, @intCast(count)) > array.len) std.process.exit(3);
    @memset(array[0..@as(usize, @intCast(count))], @as(u8, @truncate(@as(u32, @bitCast(byte_value)))));
    return count;
}
