fn spiral_abi_libc_strlen(value: []const u8) i32 {
    return @intCast(std.mem.indexOfScalar(u8, value, 0) orelse value.len);
}
