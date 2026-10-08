const std = @import("std");
const builtin = @import("builtin");
var spiral_arena = std.heap.ArenaAllocator.init(std.heap.page_allocator);
extern "kernel32" fn GetStdHandle(id: u32) callconv(.winapi) ?*anyopaque;
extern "kernel32" fn WriteFile(handle: ?*anyopaque, buffer: [*]const u8, length: u32, written: ?*u32, overlapped: ?*anyopaque) callconv(.winapi) i32;
fn spiralWrite(stream: u2, bytes: []const u8) void {
    if (builtin.os.tag == .windows) {
        const handle = GetStdHandle(if (stream == 1) 0xFFFFFFF5 else 0xFFFFFFF4);
        var rest = bytes;
        while (rest.len > 0) {
            var written: u32 = 0;
            const chunk: u32 = @intCast(@min(rest.len, 1 << 30));
            if (WriteFile(handle, rest.ptr, chunk, &written, null) == 0) return;
            rest = rest[written..];
        }
    } else if (builtin.os.tag == .linux) {
        var rest = bytes;
        while (rest.len > 0) {
            const n = std.os.linux.write(stream, rest.ptr, rest.len);
            if (@as(isize, @bitCast(n)) <= 0) return;
            rest = rest[n..];
        }
    } else {
        _ = std.c.write(stream, bytes.ptr, bytes.len);
    }
}
pub const panic = std.debug.FullPanic(spiralPanic);
fn spiralPanic(message: []const u8, _: ?usize) noreturn {
    spiralFlush();
    spiralWrite(2, message);
    spiralWrite(2, "\n");
    std.process.exit(3);
}
var spiral_gpa: std.mem.Allocator = undefined;
var spiral_true: bool = true;
var spiral_out_buffer: [1 << 16]u8 = undefined;
var spiral_out_len: usize = 0;
fn spiralFlush() void {
    if (spiral_out_len == 0) return;
    spiralWrite(1, spiral_out_buffer[0..spiral_out_len]);
    spiral_out_len = 0;
}
fn spiralPrint(s: []const u8) void {
    if (s.len > spiral_out_buffer.len - spiral_out_len) spiralFlush();
    if (s.len > spiral_out_buffer.len) {
        spiralWrite(1, s);
        return;
    }
    @memcpy(spiral_out_buffer[spiral_out_len..][0..s.len], s);
    spiral_out_len += s.len;
}
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    const s = switch (@typeInfo(T)) {
        .float => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
        .bool => std.fmt.allocPrint(spiral_gpa, "{}", .{x}),
        else => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
    } catch @panic("out of memory");
    spiralPrint(s);
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
}
fn spiralConv(comptime T: type, x: anytype) T {
    const S = @TypeOf(x);
    if (@typeInfo(T) == .float) {
        if (@typeInfo(S) == .float) return @floatCast(x) else return @floatFromInt(x);
    }
    if (@typeInfo(S) == .float) return @intFromFloat(x);
    const U = @Int(.unsigned, @bitSizeOf(T));
    const wide: i128 = x;
    return @bitCast(@as(U, @truncate(@as(u128, @bitCast(wide)))));
}
fn spiralConcat(a: []const u8, b: []const u8) []const u8 {
    return std.mem.concat(spiral_gpa, u8, &.{ a, b }) catch @panic("out of memory");
}
fn spiralStringSlice(s: []const u8, from: i64, upto: i64) []const u8 {
    const len: i64 = @intCast(s.len);
    if (from < 0 or from > len or upto < from - 1 or upto >= len) std.process.exit(3);
    if (upto < from) return "";
    const a: usize = @intCast(from);
    const b: usize = @intCast(upto + 1);
    if ((s[a] & 0xC0) == 0x80 or (b < s.len and (s[b] & 0xC0) == 0x80)) std.process.exit(3);
    return s[a..b];
}
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn spiralNewArray(comptime T: type, n: anytype) []T {
    const len: usize = @intCast(n);
    const a = spiral_gpa.alloc(T, len) catch @panic("out of memory");
    switch (@typeInfo(T)) {
        .int, .float, .bool => @memset(a, std.mem.zeroes(T)),
        else => if (T == []const u8) @memset(a, ""),
    }
    return a;
}
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32 };
const UH0 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH0 = undefined, c3_1: *UH0 = undefined, c4_0: *UH0 = undefined, c4_1: *UH0 = undefined, c5_0: *UH0 = undefined };
const UH1 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH1 = undefined };
const Tuple0 = struct { f0: *UH1, f1: u64 };
const US1 = struct { tag: i32 };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
const UH2 = struct { tag: i32, c2_0: US3 = undefined, c3_0: *UH2 = undefined, c3_1: *UH2 = undefined, c4_0: *UH2 = undefined, c4_1: *UH2 = undefined, c5_0: *UH2 = undefined };
const UH3 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH3 = undefined };
fn US0_0() US0 {
    return US0{ .tag = 0 };
}
fn US0_1() US0 {
    return US0{ .tag = 1 };
}
fn UH0_0() *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 0 });
}
fn UH0_1() *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1 });
}
fn UH0_2(a0: US0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 2, .c2_0 = a0 });
}
fn UH0_3(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH0_4(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH0_5(a0: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 5, .c5_0 = a0 });
}
fn UH1_0() *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 0 });
}
fn UH1_1(a0: US0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn random_bit_input_1(p0: u64, p1: i32, p2: *UH1) Tuple0 {
    var v0: u64 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: u64 = undefined; _ = &v4;
    var v5: u64 = undefined; _ = &v5;
    var v6: u64 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var v9: u64 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v11: US0 = undefined; _ = &v11;
    var v12: US0 = undefined; _ = &v12;
    var v14: *UH1 = undefined; _ = &v14;
    var tmp12: u64 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    var tmp14: *UH1 = undefined; _ = &tmp14;
    while (true) {
        v3 = @as(i32, 0) < v1;
        if (v3) {
            v4 = v0 *% @as(u64, 1103515245);
            v5 = v4 +% @as(u64, 12345);
            v6 = v5 & @as(u64, 2147483647);
            v7 = v1 -% @as(i32, 1);
            v8 = std.math.shr(@TypeOf(v6), v6, @as(i32, 16));
            v9 = v8 & @as(u64, 1);
            v10 = v9 == @as(u64, 0);
            if (v10) {
                v11 = US0_0();
                v13 = v11;
            } else {
                v12 = US0_1();
                v13 = v12;
            }
            v14 = UH1_1(v13, v2);
            tmp12 = v6;
            tmp13 = v7;
            tmp14 = v14;
            v0 = tmp12;
            v1 = tmp13;
            v2 = tmp14;
            continue;
        } else {
            return Tuple0{ .f0 = v2, .f1 = v0 };
        }
    }
}
fn US1_0() US1 {
    return US1{ .tag = 0 };
}
fn US1_1() US1 {
    return US1{ .tag = 1 };
}
fn US1_2() US1 {
    return US1{ .tag = 2 };
}
fn run_2(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v19: i32 = undefined; _ = &v19;
    var v10: US1 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v16: US1 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var tmp8: i32 = undefined; _ = &tmp8;
    var tmp9: *UH1 = undefined; _ = &tmp9;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = v0 == @as(i32, 0);
                if (v6) {
                    switch (v4.tag) {
                        1 => {
                            v10 = US1_2();
                        },
                        0 => {
                            v10 = US1_1();
                        },
                        else => unreachable,
                    }
                    switch (v10.tag) {
                        1 => {
                            v11 = true;
                        },
                        else => {
                            v11 = false;
                        },
                    }
                    if (v11) {
                        v19 = @as(i32, 1);
                    } else {
                        v19 = @as(i32, 0);
                    }
                } else {
                    switch (v4.tag) {
                        1 => {
                            v16 = US1_2();
                        },
                        0 => {
                            v16 = US1_1();
                        },
                        else => unreachable,
                    }
                    switch (v16.tag) {
                        1 => {
                            v17 = true;
                        },
                        else => {
                            v17 = false;
                        },
                    }
                    if (v17) {
                        v19 = @as(i32, 1);
                    } else {
                        v19 = @as(i32, 0);
                    }
                }
                tmp8 = v19;
                tmp9 = v5;
                v0 = tmp8;
                v1 = tmp9;
                continue;
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                v3 = v2 == false;
                return v3;
            },
            else => unreachable,
        }
    }
}
fn regex_compare_8(p0: *UH0, p1: *UH0) US1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: *UH0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: US1 = undefined; _ = &v57;
    var tmp5: *UH0 = undefined; _ = &tmp5;
    var tmp6: *UH0 = undefined; _ = &tmp6;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: US1 = undefined; _ = &v36;
    var tmp12: *UH0 = undefined; _ = &tmp12;
    var tmp13: *UH0 = undefined; _ = &tmp13;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH0 = undefined; _ = &v44;
    var v45: *UH0 = undefined; _ = &v45;
    var v46: *UH0 = undefined; _ = &v46;
    var v48: *UH0 = undefined; _ = &v48;
    var tmp21: *UH0 = undefined; _ = &tmp21;
    var tmp22: *UH0 = undefined; _ = &tmp22;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = regex_compare_8(v53, v55);
                        switch (v57.tag) {
                            1 => {
                                tmp5 = v54;
                                tmp6 = v56;
                                v0 = tmp5;
                                v1 = tmp6;
                                continue;
                            },
                            else => {
                                return v57;
                            },
                        }
                    },
                    else => {
                        return US1_2();
                    },
                }
            },
            4 => {
                v28 = v0.c4_0;
                v29 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_compare_8(v28, v34);
                        switch (v36.tag) {
                            1 => {
                                tmp12 = v29;
                                tmp13 = v35;
                                v0 = tmp12;
                                v1 = tmp13;
                                continue;
                            },
                            else => {
                                return v36;
                            },
                        }
                    },
                    2 => {
                        v32 = v1.c2_0;
                        return US1_2();
                    },
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_2();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            1 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US1_1();
                                    },
                                    0 => {
                                        return US1_2();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US1_0();
                                    },
                                    0 => {
                                        return US1_1();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_2();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US1_1();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_1();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US1_0();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        tmp21 = v44;
                        tmp22 = v48;
                        v0 = tmp21;
                        v1 = tmp22;
                        continue;
                    },
                    else => {
                        return US1_2();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_7(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH0 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_8(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_7(v0, v3);
                    return UH0_3(v2, v6);
                },
                0 => {
                    return UH0_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_8(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH0_3(v1, v0);
                },
                0 => {
                    return UH0_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_6(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var tmp3: *UH0 = undefined; _ = &tmp3;
    var tmp4: *UH0 = undefined; _ = &tmp4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_7(v2, v1);
                tmp3 = v3;
                tmp4 = v4;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_7(v0, v1);
            },
        }
    }
}
fn regex_equal_10(p0: *UH0, p1: *UH0) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var tmp5: *UH0 = undefined; _ = &tmp5;
    var tmp6: *UH0 = undefined; _ = &tmp6;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var tmp12: *UH0 = undefined; _ = &tmp12;
    var tmp13: *UH0 = undefined; _ = &tmp13;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US1 = undefined; _ = &v15;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var tmp19: *UH0 = undefined; _ = &tmp19;
    var tmp20: *UH0 = undefined; _ = &tmp20;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = regex_equal_10(v18, v20);
                        if (v22) {
                            tmp5 = v19;
                            tmp6 = v21;
                            v0 = tmp5;
                            v1 = tmp6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v26 = v0.c4_0;
                v27 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v28 = v1.c4_0;
                        v29 = v1.c4_1;
                        v30 = regex_equal_10(v26, v28);
                        if (v30) {
                            tmp12 = v27;
                            tmp13 = v29;
                            v0 = tmp12;
                            v1 = tmp13;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            1 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US1_1();
                                    },
                                    0 => {
                                        v15 = US1_2();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US1_0();
                                    },
                                    0 => {
                                        v15 = US1_1();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v15.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v34 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v35 = v1.c5_0;
                        tmp19 = v34;
                        tmp20 = v35;
                        v0 = tmp19;
                        v1 = tmp20;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_9(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH0_0();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH0_0();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_9(v13, v1);
                                            return UH0_4(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_10(v4, v5);
                                                    if (v6) {
                                                        return UH0_5(v4);
                                                    } else {
                                                        return UH0_4(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH0_4(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH0_4(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_11(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v3: *UH0 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH0_1();
        },
        1 => {
            return UH0_1();
        },
        5 => {
            v3 = v0.c5_0;
            return UH0_5(v3);
        },
        else => {
            return UH0_5(v0);
        },
    }
}
fn normalize_5(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_5(v5);
            v8 = normalize_5(v6);
            return make_alt_6(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_5(v10);
            v13 = normalize_5(v11);
            return make_cat_9(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH0_2(v3);
        },
        0 => {
            return UH0_0();
        },
        1 => {
            return UH0_1();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_5(v15);
            return make_star_11(v16);
        },
        else => unreachable,
    }
}
fn US2_0() US2 {
    return US2{ .tag = 0 };
}
fn US2_1() US2 {
    return US2{ .tag = 1 };
}
fn nullable_13(p0: *UH0) US2 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH0 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_13(v5);
            v8 = nullable_13(v6);
            switch (v7.tag) {
                0 => {
                    return US2_0();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_0();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_1();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
        },
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_13(v16);
            v19 = nullable_13(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_0();
                        },
                        else => {
                            return US2_1();
                        },
                    }
                },
                else => {
                    return US2_1();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_1();
        },
        0 => {
            return US2_1();
        },
        1 => {
            return US2_0();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_0();
        },
        else => unreachable,
    }
}
fn derivative_12(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
    var v31: *UH0 = undefined; _ = &v31;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US1 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_12(v19, v1);
            v22 = derivative_12(v20, v1);
            return make_alt_6(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_13(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_12(v24, v1);
                    return make_cat_9(v31, v25);
                },
                0 => {
                    v27 = derivative_12(v24, v1);
                    v28 = make_cat_9(v27, v25);
                    v29 = derivative_12(v25, v1);
                    return make_alt_6(v28, v29);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                1 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US1_1();
                        },
                        0 => {
                            v14 = US1_2();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US1_0();
                        },
                        0 => {
                            v14 = US1_1();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
            }
            switch (v14.tag) {
                1 => {
                    v15 = true;
                },
                else => {
                    v15 = false;
                },
            }
            if (v15) {
                return UH0_1();
            } else {
                return UH0_0();
            }
        },
        0 => {
            return UH0_0();
        },
        1 => {
            return UH0_0();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = derivative_12(v35, v1);
            v37 = make_star_11(v35);
            return make_cat_9(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_4(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    v2 = normalize_5(v0);
    v3 = derivative_12(v2, v1);
    return normalize_5(v3);
}
fn accepts_3(p0: *UH0, p1: *UH1) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var tmp3: *UH0 = undefined; _ = &tmp3;
    var tmp4: *UH1 = undefined; _ = &tmp4;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = canonical_derivative_4(v0, v6);
                tmp3 = v8;
                tmp4 = v7;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                v2 = normalize_5(v0);
                v3 = nullable_13(v2);
                switch (v3.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn loop_0(p0: i32, p1: *UH0, p2: i32, p3: u64, p4: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v9: i32 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v13: bool = undefined; _ = &v13;
    var v12: bool = undefined; _ = &v12;
    var v14: i32 = undefined; _ = &v14;
    var v16: i32 = undefined; _ = &v16;
    var v15: i32 = undefined; _ = &v15;
    var tmp13: i32 = undefined; _ = &tmp13;
    var tmp14: *UH0 = undefined; _ = &tmp14;
    var tmp15: i32 = undefined; _ = &tmp15;
    var tmp16: u64 = undefined; _ = &tmp16;
    var tmp17: i32 = undefined; _ = &tmp17;
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_0();
            tmp4 = random_bit_input_1(v3, v0, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = @as(i32, 0);
            v10 = run_2(v9, v7);
            v11 = accepts_3(v1, v7);
            if (v10) {
                v13 = v11;
            } else {
                v12 = false == v11;
                v13 = v12;
            }
            if (v13) {
                v14 = v2 -% @as(i32, 1);
                if (v10) {
                    v15 = v4 +% @as(i32, 1);
                    v16 = v15;
                } else {
                    v16 = v4;
                }
                tmp13 = v0;
                tmp14 = v1;
                tmp15 = v14;
                tmp16 = v8;
                tmp17 = v16;
                v0 = tmp13;
                v1 = tmp14;
                v2 = tmp15;
                v3 = tmp16;
                v4 = tmp17;
                continue;
            } else {
                spiralFail("brzozowski-compiled-core-disagrees-on-random-input");
            }
        } else {
            return v4;
        }
    }
}
fn zeros_input_15(p0: i32, p1: *UH1) *UH1 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var tmp4: i32 = undefined; _ = &tmp4;
    var tmp5: *UH1 = undefined; _ = &tmp5;
    while (true) {
        v2 = @as(i32, 0) < v0;
        if (v2) {
            v3 = v0 -% @as(i32, 1);
            v4 = US0_0();
            v5 = UH1_1(v4, v1);
            tmp4 = v3;
            tmp5 = v5;
            v0 = tmp4;
            v1 = tmp5;
            continue;
        } else {
            return v1;
        }
    }
}
fn run_16(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v26: i32 = undefined; _ = &v26;
    var v11: US1 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v17: US1 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v22: US1 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var tmp11: i32 = undefined; _ = &tmp11;
    var tmp12: *UH1 = undefined; _ = &tmp12;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v5 = v1.c1_0;
                v6 = v1.c1_1;
                v7 = v0 == @as(i32, 0);
                if (v7) {
                    switch (v5.tag) {
                        1 => {
                            v11 = US1_2();
                        },
                        0 => {
                            v11 = US1_1();
                        },
                        else => unreachable,
                    }
                    switch (v11.tag) {
                        1 => {
                            v12 = true;
                        },
                        else => {
                            v12 = false;
                        },
                    }
                    v26 = @as(i32, 1);
                } else {
                    v13 = v0 == @as(i32, 1);
                    if (v13) {
                        switch (v5.tag) {
                            1 => {
                                v17 = US1_2();
                            },
                            0 => {
                                v17 = US1_1();
                            },
                            else => unreachable,
                        }
                        switch (v17.tag) {
                            1 => {
                                v18 = true;
                            },
                            else => {
                                v18 = false;
                            },
                        }
                        v26 = @as(i32, 1);
                    } else {
                        switch (v5.tag) {
                            1 => {
                                v22 = US1_2();
                            },
                            0 => {
                                v22 = US1_1();
                            },
                            else => unreachable,
                        }
                        switch (v22.tag) {
                            1 => {
                                v23 = true;
                            },
                            else => {
                                v23 = false;
                            },
                        }
                        if (v23) {
                            v26 = @as(i32, 2);
                        } else {
                            v26 = @as(i32, 0);
                        }
                    }
                }
                tmp11 = v26;
                tmp12 = v6;
                v0 = tmp11;
                v1 = tmp12;
                continue;
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                if (v2) {
                    return true;
                } else {
                    v3 = v0 == @as(i32, 1);
                    return false;
                }
            },
            else => unreachable,
        }
    }
}
fn loop_14(p0: i32, p1: *UH0, p2: i32, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: bool = undefined; _ = &v11;
    var v10: bool = undefined; _ = &v10;
    var v15: i32 = undefined; _ = &v15;
    var v12: i32 = undefined; _ = &v12;
    var v16: US0 = undefined; _ = &v16;
    var v17: *UH1 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v24: bool = undefined; _ = &v24;
    var v23: bool = undefined; _ = &v23;
    var v28: i32 = undefined; _ = &v28;
    var v25: i32 = undefined; _ = &v25;
    var v29: i32 = undefined; _ = &v29;
    var tmp22: i32 = undefined; _ = &tmp22;
    var tmp23: *UH0 = undefined; _ = &tmp23;
    var tmp24: i32 = undefined; _ = &tmp24;
    var tmp25: i32 = undefined; _ = &tmp25;
    while (true) {
        v4 = v0 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_0();
            v6 = zeros_input_15(v2, v5);
            v7 = @as(i32, 2);
            v8 = run_16(v7, v6);
            v9 = accepts_3(v1, v6);
            if (v8) {
                v11 = v9;
            } else {
                v10 = false == v9;
                v11 = v10;
            }
            if (v11) {
                if (v8) {
                    v12 = v3 +% @as(i32, 1);
                    v15 = v12;
                } else {
                    v15 = v3;
                }
            } else {
                if (spiral_true) spiralFail("brzozowski-compiled-core-disagrees-on-zero-run");
            }
            v16 = US0_1();
            v17 = UH1_0();
            v18 = UH1_1(v16, v17);
            v19 = zeros_input_15(v2, v18);
            v20 = @as(i32, 2);
            v21 = run_16(v20, v19);
            v22 = accepts_3(v1, v19);
            if (v21) {
                v24 = v22;
            } else {
                v23 = false == v22;
                v24 = v23;
            }
            if (v24) {
                if (v21) {
                    v25 = v15 +% @as(i32, 1);
                    v28 = v25;
                } else {
                    v28 = v15;
                }
            } else {
                if (spiral_true) spiralFail("brzozowski-compiled-core-disagrees-on-zero-run");
            }
            v29 = v2 +% @as(i32, 1);
            tmp22 = v0;
            tmp23 = v1;
            tmp24 = v29;
            tmp25 = v28;
            v0 = tmp22;
            v1 = tmp23;
            v2 = tmp24;
            v3 = tmp25;
            continue;
        }
    }
}
fn US3_0() US3 {
    return US3{ .tag = 0 };
}
fn US3_1() US3 {
    return US3{ .tag = 1 };
}
fn US3_2() US3 {
    return US3{ .tag = 2 };
}
fn UH2_0() *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 0 });
}
fn UH2_1() *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1 });
}
fn UH2_2(a0: US3) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 2, .c2_0 = a0 });
}
fn UH2_3(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH2_4(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH2_5(a0: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 5, .c5_0 = a0 });
}
fn UH3_0() *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 0 });
}
fn UH3_1(a0: US3, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn run_17(p0: i32, p1: *UH3) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v5: US3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v47: i32 = undefined; _ = &v47;
    var v10: US1 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v17: US1 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v21: bool = undefined; _ = &v21;
    var v24: US1 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v31: US1 = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v36: US1 = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v43: US1 = undefined; _ = &v43;
    var v44: bool = undefined; _ = &v44;
    var tmp17: i32 = undefined; _ = &tmp17;
    var tmp18: *UH3 = undefined; _ = &tmp18;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v5 = v1.c1_0;
                v6 = v1.c1_1;
                v7 = v0 == @as(i32, 0);
                if (v7) {
                    switch (v5.tag) {
                        0 => {
                            v10 = US1_1();
                        },
                        else => {
                            v10 = US1_2();
                        },
                    }
                    switch (v10.tag) {
                        1 => {
                            v11 = true;
                        },
                        else => {
                            v11 = false;
                        },
                    }
                    if (v11) {
                        v47 = @as(i32, 0);
                    } else {
                        switch (v5.tag) {
                            0 => {
                                v17 = US1_0();
                            },
                            1 => {
                                v17 = US1_1();
                            },
                            2 => {
                                v17 = US1_2();
                            },
                            else => unreachable,
                        }
                        switch (v17.tag) {
                            1 => {
                                v18 = true;
                            },
                            else => {
                                v18 = false;
                            },
                        }
                        if (v18) {
                            v47 = @as(i32, 0);
                        } else {
                            v47 = @as(i32, 1);
                        }
                    }
                } else {
                    v21 = v0 == @as(i32, 1);
                    if (v21) {
                        switch (v5.tag) {
                            0 => {
                                v24 = US1_1();
                            },
                            else => {
                                v24 = US1_2();
                            },
                        }
                        switch (v24.tag) {
                            1 => {
                                v25 = true;
                            },
                            else => {
                                v25 = false;
                            },
                        }
                        if (v25) {
                            v47 = @as(i32, 2);
                        } else {
                            switch (v5.tag) {
                                0 => {
                                    v31 = US1_0();
                                },
                                1 => {
                                    v31 = US1_1();
                                },
                                2 => {
                                    v31 = US1_2();
                                },
                                else => unreachable,
                            }
                            switch (v31.tag) {
                                1 => {
                                    v32 = true;
                                },
                                else => {
                                    v32 = false;
                                },
                            }
                            v47 = @as(i32, 2);
                        }
                    } else {
                        switch (v5.tag) {
                            0 => {
                                v36 = US1_1();
                            },
                            else => {
                                v36 = US1_2();
                            },
                        }
                        switch (v36.tag) {
                            1 => {
                                v37 = true;
                            },
                            else => {
                                v37 = false;
                            },
                        }
                        if (v37) {
                            v47 = @as(i32, 2);
                        } else {
                            switch (v5.tag) {
                                0 => {
                                    v43 = US1_0();
                                },
                                1 => {
                                    v43 = US1_1();
                                },
                                2 => {
                                    v43 = US1_2();
                                },
                                else => unreachable,
                            }
                            switch (v43.tag) {
                                1 => {
                                    v44 = true;
                                },
                                else => {
                                    v44 = false;
                                },
                            }
                            v47 = @as(i32, 2);
                        }
                    }
                }
                tmp17 = v47;
                tmp18 = v6;
                v0 = tmp17;
                v1 = tmp18;
                continue;
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                if (v2) {
                    return false;
                } else {
                    v3 = v0 == @as(i32, 1);
                    return v3;
                }
            },
            else => unreachable,
        }
    }
}
fn regex_compare_23(p0: *UH2, p1: *UH2) US1 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v59: *UH2 = undefined; _ = &v59;
    var v60: *UH2 = undefined; _ = &v60;
    var v61: *UH2 = undefined; _ = &v61;
    var v62: *UH2 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var tmp5: *UH2 = undefined; _ = &tmp5;
    var tmp6: *UH2 = undefined; _ = &tmp6;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: US1 = undefined; _ = &v42;
    var tmp12: *UH2 = undefined; _ = &tmp12;
    var tmp13: *UH2 = undefined; _ = &tmp13;
    var v38: US3 = undefined; _ = &v38;
    var v10: US3 = undefined; _ = &v10;
    var v13: US3 = undefined; _ = &v13;
    var v50: *UH2 = undefined; _ = &v50;
    var v51: *UH2 = undefined; _ = &v51;
    var v52: *UH2 = undefined; _ = &v52;
    var v54: *UH2 = undefined; _ = &v54;
    var tmp21: *UH2 = undefined; _ = &tmp21;
    var tmp22: *UH2 = undefined; _ = &tmp22;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_23(v59, v61);
                        switch (v63.tag) {
                            1 => {
                                tmp5 = v60;
                                tmp6 = v62;
                                v0 = tmp5;
                                v1 = tmp6;
                                continue;
                            },
                            else => {
                                return v63;
                            },
                        }
                    },
                    else => {
                        return US1_2();
                    },
                }
            },
            4 => {
                v34 = v0.c4_0;
                v35 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v40 = v1.c4_0;
                        v41 = v1.c4_1;
                        v42 = regex_compare_23(v34, v40);
                        switch (v42.tag) {
                            1 => {
                                tmp12 = v35;
                                tmp13 = v41;
                                v0 = tmp12;
                                v1 = tmp13;
                                continue;
                            },
                            else => {
                                return v42;
                            },
                        }
                    },
                    2 => {
                        v38 = v1.c2_0;
                        return US1_2();
                    },
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_2();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            0 => {
                                switch (v13.tag) {
                                    0 => {
                                        return US1_1();
                                    },
                                    else => {
                                        return US1_0();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US1_2();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US1_1();
                                                    },
                                                    2 => {
                                                        return US1_0();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US1_2();
                                                    },
                                                    2 => {
                                                        return US1_1();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                    },
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_2();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US1_1();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US1_2();
                    },
                    1 => {
                        return US1_1();
                    },
                    else => {
                        return US1_0();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US1_0();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        tmp21 = v50;
                        tmp22 = v54;
                        v0 = tmp21;
                        v1 = tmp22;
                        continue;
                    },
                    else => {
                        return US1_2();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_22(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH2 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_23(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_22(v0, v3);
                    return UH2_3(v2, v6);
                },
                0 => {
                    return UH2_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_23(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH2_3(v1, v0);
                },
                0 => {
                    return UH2_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_21(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var tmp3: *UH2 = undefined; _ = &tmp3;
    var tmp4: *UH2 = undefined; _ = &tmp4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_22(v2, v1);
                tmp3 = v3;
                tmp4 = v4;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_22(v0, v1);
            },
        }
    }
}
fn regex_equal_25(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var tmp5: *UH2 = undefined; _ = &tmp5;
    var tmp6: *UH2 = undefined; _ = &tmp6;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var tmp12: *UH2 = undefined; _ = &tmp12;
    var tmp13: *UH2 = undefined; _ = &tmp13;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v21: US1 = undefined; _ = &v21;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    var tmp19: *UH2 = undefined; _ = &tmp19;
    var tmp20: *UH2 = undefined; _ = &tmp20;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_25(v24, v26);
                        if (v28) {
                            tmp5 = v25;
                            tmp6 = v27;
                            v0 = tmp5;
                            v1 = tmp6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v32 = v0.c4_0;
                v33 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_equal_25(v32, v34);
                        if (v36) {
                            tmp12 = v33;
                            tmp13 = v35;
                            v0 = tmp12;
                            v1 = tmp13;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            0 => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US1_1();
                                    },
                                    else => {
                                        v21 = US1_0();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US1_2();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US1_1();
                                                    },
                                                    2 => {
                                                        v21 = US1_0();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US1_2();
                                                    },
                                                    2 => {
                                                        v21 = US1_1();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v21.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v40 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v41 = v1.c5_0;
                        tmp19 = v40;
                        tmp20 = v41;
                        v0 = tmp19;
                        v1 = tmp20;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_24(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH2_0();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH2_0();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_24(v13, v1);
                                            return UH2_4(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_25(v4, v5);
                                                    if (v6) {
                                                        return UH2_5(v4);
                                                    } else {
                                                        return UH2_4(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH2_4(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH2_4(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_26(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v3: *UH2 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH2_1();
        },
        1 => {
            return UH2_1();
        },
        5 => {
            v3 = v0.c5_0;
            return UH2_5(v3);
        },
        else => {
            return UH2_5(v0);
        },
    }
}
fn normalize_20(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v3: US3 = undefined; _ = &v3;
    var v15: *UH2 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_20(v5);
            v8 = normalize_20(v6);
            return make_alt_21(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_20(v10);
            v13 = normalize_20(v11);
            return make_cat_24(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH2_2(v3);
        },
        0 => {
            return UH2_0();
        },
        1 => {
            return UH2_1();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_20(v15);
            return make_star_26(v16);
        },
        else => unreachable,
    }
}
fn nullable_28(p0: *UH2) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US3 = undefined; _ = &v3;
    var v25: *UH2 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_28(v5);
            v8 = nullable_28(v6);
            switch (v7.tag) {
                0 => {
                    return US2_0();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_0();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_1();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
        },
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_28(v16);
            v19 = nullable_28(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_0();
                        },
                        else => {
                            return US2_1();
                        },
                    }
                },
                else => {
                    return US2_1();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_1();
        },
        0 => {
            return US2_1();
        },
        1 => {
            return US2_0();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_0();
        },
        else => unreachable,
    }
}
fn derivative_27(p0: *UH2, p1: US3) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH2 = undefined; _ = &v37;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH2 = undefined; _ = &v42;
    var v43: *UH2 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_27(v25, v1);
            v28 = derivative_27(v26, v1);
            return make_alt_21(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_28(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_27(v30, v1);
                    return make_cat_24(v37, v31);
                },
                0 => {
                    v33 = derivative_27(v30, v1);
                    v34 = make_cat_24(v33, v31);
                    v35 = derivative_27(v31, v1);
                    return make_alt_21(v34, v35);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                0 => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US1_1();
                        },
                        else => {
                            v20 = US1_0();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US1_2();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US1_1();
                                        },
                                        2 => {
                                            v20 = US1_0();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US1_2();
                                        },
                                        2 => {
                                            v20 = US1_1();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                    }
                },
            }
            switch (v20.tag) {
                1 => {
                    v21 = true;
                },
                else => {
                    v21 = false;
                },
            }
            if (v21) {
                return UH2_1();
            } else {
                return UH2_0();
            }
        },
        0 => {
            return UH2_0();
        },
        1 => {
            return UH2_0();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_27(v41, v1);
            v43 = make_star_26(v41);
            return make_cat_24(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_19(p0: *UH2, p1: US3) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    v2 = normalize_20(v0);
    v3 = derivative_27(v2, v1);
    return normalize_20(v3);
}
fn accepts_18(p0: *UH2, p1: *UH3) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v6: US3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var tmp3: *UH2 = undefined; _ = &tmp3;
    var tmp4: *UH3 = undefined; _ = &tmp4;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = canonical_derivative_19(v0, v6);
                tmp3 = v8;
                tmp4 = v7;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                v2 = normalize_20(v0);
                v3 = nullable_28(v2);
                switch (v3.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn spiralMain() i32 {
    var v0: i32 = undefined; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: US0 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: u64 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: US0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: US0 = undefined; _ = &v18;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: US0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v23: *UH0 = undefined; _ = &v23;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: US0 = undefined; _ = &v25;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: i32 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: US3 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: US3 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: US3 = undefined; _ = &v38;
    var v39: *UH2 = undefined; _ = &v39;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: US3 = undefined; _ = &v41;
    var v42: US3 = undefined; _ = &v42;
    var v43: US3 = undefined; _ = &v43;
    var v44: US3 = undefined; _ = &v44;
    var v45: *UH3 = undefined; _ = &v45;
    var v46: *UH3 = undefined; _ = &v46;
    var v47: *UH3 = undefined; _ = &v47;
    var v48: *UH3 = undefined; _ = &v48;
    var v49: *UH3 = undefined; _ = &v49;
    var v50: US3 = undefined; _ = &v50;
    var v51: US3 = undefined; _ = &v51;
    var v52: US3 = undefined; _ = &v52;
    var v53: US3 = undefined; _ = &v53;
    var v54: *UH3 = undefined; _ = &v54;
    var v55: *UH3 = undefined; _ = &v55;
    var v56: *UH3 = undefined; _ = &v56;
    var v57: *UH3 = undefined; _ = &v57;
    var v58: *UH3 = undefined; _ = &v58;
    var v59: i32 = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v62: bool = undefined; _ = &v62;
    var v68: bool = undefined; _ = &v68;
    var v63: i32 = undefined; _ = &v63;
    var v64: bool = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    var v66: bool = undefined; _ = &v66;
    v0 = @as(i32, 200);
    v1 = @as(i32, 32);
    v2 = @as(i32, 16);
    v3 = US0_0();
    v4 = UH0_2(v3);
    v5 = US0_1();
    v6 = UH0_2(v5);
    v7 = UH0_3(v4, v6);
    v8 = UH0_5(v7);
    v9 = US0_0();
    v10 = UH0_2(v9);
    v11 = UH0_4(v8, v10);
    v12 = @as(u64, 1);
    v13 = @as(i32, 0);
    v14 = loop_0(v1, v11, v0, v12, v13);
    v15 = v14 == @as(i32, 93);
    if (v15) {
    } else {
        if (spiral_true) spiralFail("brzozowski-compiled-ends-with-zero-count");
    }
    v16 = US0_0();
    v17 = UH0_2(v16);
    v18 = US0_0();
    v19 = UH0_2(v18);
    v20 = US0_0();
    v21 = UH0_2(v20);
    v22 = UH0_4(v19, v21);
    v23 = UH0_3(v17, v22);
    v24 = UH0_5(v23);
    v25 = US0_1();
    v26 = UH0_2(v25);
    v27 = UH0_4(v24, v26);
    v28 = @as(i32, 1);
    v29 = @as(i32, 0);
    v30 = loop_14(v2, v27, v28, v29);
    v31 = v30 == @as(i32, 16);
    if (v31) {
    } else {
        if (spiral_true) spiralFail("brzozowski-compiled-zero-runs-count");
    }
    v32 = US3_0();
    v33 = UH2_2(v32);
    v34 = US3_1();
    v35 = UH2_2(v34);
    v36 = UH2_3(v33, v35);
    v37 = UH2_5(v36);
    v38 = US3_2();
    v39 = UH2_2(v38);
    v40 = UH2_4(v37, v39);
    v41 = US3_0();
    v42 = US3_1();
    v43 = US3_0();
    v44 = US3_2();
    v45 = UH3_0();
    v46 = UH3_1(v44, v45);
    v47 = UH3_1(v43, v46);
    v48 = UH3_1(v42, v47);
    v49 = UH3_1(v41, v48);
    v50 = US3_0();
    v51 = US3_1();
    v52 = US3_0();
    v53 = US3_1();
    v54 = UH3_0();
    v55 = UH3_1(v53, v54);
    v56 = UH3_1(v52, v55);
    v57 = UH3_1(v51, v56);
    v58 = UH3_1(v50, v57);
    v59 = @as(i32, 0);
    v60 = run_17(v59, v49);
    if (v60) {
        v62 = accepts_18(v40, v49);
    } else {
        v62 = false;
    }
    if (v62) {
        v63 = @as(i32, 0);
        v64 = run_17(v63, v58);
        if (v64) {
            v68 = false;
        } else {
            v65 = accepts_18(v40, v58);
            v66 = v65 == false;
            v68 = v66;
        }
    } else {
        v68 = false;
    }
    if (v68) {
        return @as(i32, 0);
    } else {
        spiralFail("brzozowski-compiled-ternary-disagrees");
    }
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
