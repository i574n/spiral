fn spiral_abi_libc_memcmp(left: []u8, right: []u8, count: i32) i32 {
    if (count < 0 or @as(usize, @intCast(count)) > left.len or @as(usize, @intCast(count)) > right.len) std.process.exit(3);
    const n: usize = @intCast(count);
    return switch (std.mem.order(u8, left[0..n], right[0..n])) {
        .lt => -1,
        .eq => 0,
        .gt => 1,
    };
}
