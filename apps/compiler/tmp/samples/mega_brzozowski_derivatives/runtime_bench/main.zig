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
const UH2 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH2 = undefined };
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
fn method1(p0: u64, p1: i32, p2: *UH1) Tuple0 {
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
fn method7(p0: *UH0, p1: *UH0) US1 {
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
                        v57 = method7(v53, v55);
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
                        v36 = method7(v28, v34);
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
fn method6(p0: *UH0, p1: *UH0) *UH0 {
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
            v4 = method7(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = method6(v0, v3);
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
            v11 = method7(v0, v1);
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
fn method5(p0: *UH0, p1: *UH0) *UH0 {
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
                v4 = method6(v2, v1);
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
                return method6(v0, v1);
            },
        }
    }
}
fn method9(p0: *UH0, p1: *UH0) bool {
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
                        v22 = method9(v18, v20);
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
                        v30 = method9(v26, v28);
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
fn method8(p0: *UH0, p1: *UH0) *UH0 {
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
                                            v14 = method8(v13, v1);
                                            return UH0_4(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = method9(v4, v5);
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
fn method10(p0: *UH0) *UH0 {
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
fn method4(p0: *UH0) *UH0 {
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
            v7 = method4(v5);
            v8 = method4(v6);
            return method5(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = method4(v10);
            v13 = method4(v11);
            return method8(v12, v13);
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
            v16 = method4(v15);
            return method10(v16);
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
fn method12(p0: *UH0) US2 {
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
            v7 = method12(v5);
            v8 = method12(v6);
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
            v18 = method12(v16);
            v19 = method12(v17);
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
fn method11(p0: *UH0, p1: US0) *UH0 {
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
            v21 = method11(v19, v1);
            v22 = method11(v20, v1);
            return method5(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = method12(v24);
            switch (v26.tag) {
                1 => {
                    v31 = method11(v24, v1);
                    return method8(v31, v25);
                },
                0 => {
                    v27 = method11(v24, v1);
                    v28 = method8(v27, v25);
                    v29 = method11(v25, v1);
                    return method5(v28, v29);
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
            v36 = method11(v35, v1);
            v37 = method10(v35);
            return method8(v36, v37);
        },
        else => unreachable,
    }
}
fn method3(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    v2 = method4(v0);
    v3 = method11(v2, v1);
    return method4(v3);
}
fn method2(p0: *UH0, p1: *UH1) bool {
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
                v8 = method3(v0, v6);
                tmp3 = v8;
                tmp4 = v7;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                v2 = method4(v0);
                v3 = method12(v2);
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
fn method0(p0: *UH0, p1: i32, p2: i32, p3: u64, p4: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    var tmp9: *UH0 = undefined; _ = &tmp9;
    var tmp10: i32 = undefined; _ = &tmp10;
    var tmp11: i32 = undefined; _ = &tmp11;
    var tmp12: u64 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_0();
            tmp4 = method1(v3, v1, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = method2(v0, v7);
            if (v9) {
                v10 = v4 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v4;
            }
            v12 = v2 -% @as(i32, 1);
            tmp9 = v0;
            tmp10 = v1;
            tmp11 = v12;
            tmp12 = v8;
            tmp13 = v11;
            v0 = tmp9;
            v1 = tmp10;
            v2 = tmp11;
            v3 = tmp12;
            v4 = tmp13;
            continue;
        } else {
            return v4;
        }
    }
}
fn method14(p0: i32, p1: *UH1) *UH1 {
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
fn method13(p0: *UH0, p1: i32, p2: i32, p3: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v8: i32 = undefined; _ = &v8;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: i32 = undefined; _ = &v16;
    var v15: i32 = undefined; _ = &v15;
    var v17: i32 = undefined; _ = &v17;
    var tmp14: *UH0 = undefined; _ = &tmp14;
    var tmp15: i32 = undefined; _ = &tmp15;
    var tmp16: i32 = undefined; _ = &tmp16;
    var tmp17: i32 = undefined; _ = &tmp17;
    while (true) {
        v4 = v1 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_0();
            v6 = method14(v2, v5);
            v7 = method2(v0, v6);
            if (v7) {
                v8 = v3 +% @as(i32, 1);
                v9 = v8;
            } else {
                v9 = v3;
            }
            v10 = US0_1();
            v11 = UH1_0();
            v12 = UH1_1(v10, v11);
            v13 = method14(v2, v12);
            v14 = method2(v0, v13);
            if (v14) {
                v15 = v9 +% @as(i32, 1);
                v16 = v15;
            } else {
                v16 = v9;
            }
            v17 = v2 +% @as(i32, 1);
            tmp14 = v0;
            tmp15 = v1;
            tmp16 = v17;
            tmp17 = v16;
            v0 = tmp14;
            v1 = tmp15;
            v2 = tmp16;
            v3 = tmp17;
            continue;
        }
    }
}
fn UH2_0() *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 0 });
}
fn UH2_1(a0: *UH0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn method16(p0: *UH2, p1: *UH1) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var tmp7: *UH2 = undefined; _ = &tmp7;
    var tmp8: *UH1 = undefined; _ = &tmp8;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var tmp13: *UH2 = undefined; _ = &tmp13;
    var tmp14: *UH1 = undefined; _ = &tmp14;
    var v9: US0 = undefined; _ = &v9;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v21: US1 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var tmp20: *UH2 = undefined; _ = &tmp20;
    var tmp21: *UH1 = undefined; _ = &tmp21;
    var tmp22: *UH2 = undefined; _ = &tmp22;
    var tmp23: *UH1 = undefined; _ = &tmp23;
    var v39: *UH0 = undefined; _ = &v39;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var tmp27: *UH2 = undefined; _ = &tmp27;
    var tmp28: *UH1 = undefined; _ = &tmp28;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v6 = v0.c1_0;
                v7 = v0.c1_1;
                switch (v6.tag) {
                    3 => {
                        v27 = v6.c3_0;
                        v28 = v6.c3_1;
                        v29 = UH2_1(v27, v7);
                        v30 = method16(v29, v1);
                        if (v30) {
                            return true;
                        } else {
                            v31 = UH2_1(v28, v7);
                            tmp7 = v31;
                            tmp8 = v1;
                            v0 = tmp7;
                            v1 = tmp8;
                            continue;
                        }
                    },
                    4 => {
                        v34 = v6.c4_0;
                        v35 = v6.c4_1;
                        v36 = UH2_1(v35, v7);
                        v37 = UH2_1(v34, v36);
                        tmp13 = v37;
                        tmp14 = v1;
                        v0 = tmp13;
                        v1 = tmp14;
                        continue;
                    },
                    2 => {
                        v9 = v6.c2_0;
                        switch (v1.tag) {
                            1 => {
                                v10 = v1.c1_0;
                                v11 = v1.c1_1;
                                switch (v9.tag) {
                                    1 => {
                                        switch (v10.tag) {
                                            1 => {
                                                v21 = US1_1();
                                            },
                                            0 => {
                                                v21 = US1_2();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    0 => {
                                        switch (v10.tag) {
                                            1 => {
                                                v21 = US1_0();
                                            },
                                            0 => {
                                                v21 = US1_1();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    else => unreachable,
                                }
                                switch (v21.tag) {
                                    1 => {
                                        v22 = true;
                                    },
                                    else => {
                                        v22 = false;
                                    },
                                }
                                if (v22) {
                                    tmp20 = v7;
                                    tmp21 = v11;
                                    v0 = tmp20;
                                    v1 = tmp21;
                                    continue;
                                } else {
                                    return false;
                                }
                            },
                            0 => {
                                return false;
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return false;
                    },
                    1 => {
                        tmp22 = v7;
                        tmp23 = v1;
                        v0 = tmp22;
                        v1 = tmp23;
                        continue;
                    },
                    5 => {
                        v39 = v6.c5_0;
                        v40 = UH2_1(v39, v0);
                        v41 = method16(v40, v1);
                        if (v41) {
                            return true;
                        } else {
                            tmp27 = v7;
                            tmp28 = v1;
                            v0 = tmp27;
                            v1 = tmp28;
                            continue;
                        }
                    },
                    else => unreachable,
                }
            },
            0 => {
                switch (v1.tag) {
                    1 => {
                        v2 = v1.c1_0;
                        v3 = v1.c1_1;
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
fn method15(p0: *UH0, p1: i32, p2: i32, p3: u64, p4: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v9: *UH2 = undefined; _ = &v9;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v13: i32 = undefined; _ = &v13;
    var v12: i32 = undefined; _ = &v12;
    var v14: i32 = undefined; _ = &v14;
    var tmp11: *UH0 = undefined; _ = &tmp11;
    var tmp12: i32 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    var tmp14: u64 = undefined; _ = &tmp14;
    var tmp15: i32 = undefined; _ = &tmp15;
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_0();
            tmp4 = method1(v3, v1, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = UH2_0();
            v10 = UH2_1(v0, v9);
            v11 = method16(v10, v7);
            if (v11) {
                v12 = v4 +% @as(i32, 1);
                v13 = v12;
            } else {
                v13 = v4;
            }
            v14 = v2 -% @as(i32, 1);
            tmp11 = v0;
            tmp12 = v1;
            tmp13 = v14;
            tmp14 = v8;
            tmp15 = v13;
            v0 = tmp11;
            v1 = tmp12;
            v2 = tmp13;
            v3 = tmp14;
            v4 = tmp15;
            continue;
        } else {
            return v4;
        }
    }
}
fn method17(p0: *UH0, p1: i32, p2: i32, p3: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: *UH1 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: i32 = undefined; _ = &v20;
    var v19: i32 = undefined; _ = &v19;
    var v21: i32 = undefined; _ = &v21;
    var tmp18: *UH0 = undefined; _ = &tmp18;
    var tmp19: i32 = undefined; _ = &tmp19;
    var tmp20: i32 = undefined; _ = &tmp20;
    var tmp21: i32 = undefined; _ = &tmp21;
    while (true) {
        v4 = v1 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_0();
            v6 = method14(v2, v5);
            v7 = UH2_0();
            v8 = UH2_1(v0, v7);
            v9 = method16(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = US0_1();
            v13 = UH1_0();
            v14 = UH1_1(v12, v13);
            v15 = method14(v2, v14);
            v16 = UH2_0();
            v17 = UH2_1(v0, v16);
            v18 = method16(v17, v15);
            if (v18) {
                v19 = v11 +% @as(i32, 1);
                v20 = v19;
            } else {
                v20 = v11;
            }
            v21 = v2 +% @as(i32, 1);
            tmp18 = v0;
            tmp19 = v1;
            tmp20 = v21;
            tmp21 = v20;
            v0 = tmp18;
            v1 = tmp19;
            v2 = tmp20;
            v3 = tmp21;
            continue;
        }
    }
}
fn method19(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v8: bool = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var tmp4: i32 = undefined; _ = &tmp4;
    var tmp5: *UH1 = undefined; _ = &tmp5;
    var v5: bool = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var tmp8: i32 = undefined; _ = &tmp8;
    var tmp9: *UH1 = undefined; _ = &tmp9;
    var v2: bool = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                switch (v3.tag) {
                    1 => {
                        v8 = v0 == @as(i32, 0);
                        v9 = @as(i32, 0);
                        tmp4 = v9;
                        tmp5 = v4;
                        v0 = tmp4;
                        v1 = tmp5;
                        continue;
                    },
                    0 => {
                        v5 = v0 == @as(i32, 0);
                        v6 = @as(i32, 1);
                        tmp8 = v6;
                        tmp9 = v4;
                        v0 = tmp8;
                        v1 = tmp9;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 1);
                return v2;
            },
            else => unreachable,
        }
    }
}
fn method18(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    var tmp10: i32 = undefined; _ = &tmp10;
    var tmp11: i32 = undefined; _ = &tmp11;
    var tmp12: u64 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    while (true) {
        v4 = @as(i32, 0) < v1;
        if (v4) {
            v5 = UH1_0();
            tmp4 = method1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = method19(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = v1 -% @as(i32, 1);
            tmp10 = v0;
            tmp11 = v12;
            tmp12 = v7;
            tmp13 = v11;
            v0 = tmp10;
            v1 = tmp11;
            v2 = tmp12;
            v3 = tmp13;
            continue;
        } else {
            return v3;
        }
    }
}
fn method21(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v50: bool = undefined; _ = &v50;
    var v79: i32 = undefined; _ = &v79;
    var v51: bool = undefined; _ = &v51;
    var v52: bool = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v54: bool = undefined; _ = &v54;
    var v55: bool = undefined; _ = &v55;
    var v56: bool = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: bool = undefined; _ = &v58;
    var v59: bool = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v62: bool = undefined; _ = &v62;
    var v63: bool = undefined; _ = &v63;
    var v64: bool = undefined; _ = &v64;
    var tmp18: i32 = undefined; _ = &tmp18;
    var tmp19: *UH1 = undefined; _ = &tmp19;
    var v19: bool = undefined; _ = &v19;
    var v48: i32 = undefined; _ = &v48;
    var v20: bool = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: bool = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var tmp36: i32 = undefined; _ = &tmp36;
    var tmp37: *UH1 = undefined; _ = &tmp37;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v17 = v1.c1_0;
                v18 = v1.c1_1;
                switch (v17.tag) {
                    1 => {
                        v50 = v0 == @as(i32, 0);
                        if (v50) {
                            v79 = @as(i32, 1);
                        } else {
                            v51 = v0 == @as(i32, 1);
                            if (v51) {
                                v79 = @as(i32, 6);
                            } else {
                                v52 = v0 == @as(i32, 2);
                                if (v52) {
                                    v79 = @as(i32, 11);
                                } else {
                                    v53 = v0 == @as(i32, 3);
                                    if (v53) {
                                        v79 = @as(i32, 5);
                                    } else {
                                        v54 = v0 == @as(i32, 4);
                                        if (v54) {
                                            v79 = @as(i32, 1);
                                        } else {
                                            v55 = v0 == @as(i32, 5);
                                            if (v55) {
                                                v79 = @as(i32, 6);
                                            } else {
                                                v56 = v0 == @as(i32, 6);
                                                if (v56) {
                                                    v79 = @as(i32, 13);
                                                } else {
                                                    v57 = v0 == @as(i32, 7);
                                                    if (v57) {
                                                        v79 = @as(i32, 9);
                                                    } else {
                                                        v58 = v0 == @as(i32, 8);
                                                        if (v58) {
                                                            v79 = @as(i32, 5);
                                                        } else {
                                                            v59 = v0 == @as(i32, 9);
                                                            if (v59) {
                                                                v79 = @as(i32, 12);
                                                            } else {
                                                                v60 = v0 == @as(i32, 10);
                                                                if (v60) {
                                                                    v79 = @as(i32, 11);
                                                                } else {
                                                                    v61 = v0 == @as(i32, 11);
                                                                    if (v61) {
                                                                        v79 = @as(i32, 12);
                                                                    } else {
                                                                        v62 = v0 == @as(i32, 12);
                                                                        if (v62) {
                                                                            v79 = @as(i32, 13);
                                                                        } else {
                                                                            v63 = v0 == @as(i32, 13);
                                                                            if (v63) {
                                                                                v79 = @as(i32, 15);
                                                                            } else {
                                                                                v64 = v0 == @as(i32, 14);
                                                                                if (v64) {
                                                                                    v79 = @as(i32, 9);
                                                                                } else {
                                                                                    v79 = @as(i32, 15);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        tmp18 = v79;
                        tmp19 = v18;
                        v0 = tmp18;
                        v1 = tmp19;
                        continue;
                    },
                    0 => {
                        v19 = v0 == @as(i32, 0);
                        if (v19) {
                            v48 = @as(i32, 0);
                        } else {
                            v20 = v0 == @as(i32, 1);
                            if (v20) {
                                v48 = @as(i32, 2);
                            } else {
                                v21 = v0 == @as(i32, 2);
                                if (v21) {
                                    v48 = @as(i32, 3);
                                } else {
                                    v22 = v0 == @as(i32, 3);
                                    if (v22) {
                                        v48 = @as(i32, 4);
                                    } else {
                                        v23 = v0 == @as(i32, 4);
                                        if (v23) {
                                            v48 = @as(i32, 0);
                                        } else {
                                            v24 = v0 == @as(i32, 5);
                                            if (v24) {
                                                v48 = @as(i32, 2);
                                            } else {
                                                v25 = v0 == @as(i32, 6);
                                                if (v25) {
                                                    v48 = @as(i32, 7);
                                                } else {
                                                    v26 = v0 == @as(i32, 7);
                                                    if (v26) {
                                                        v48 = @as(i32, 8);
                                                    } else {
                                                        v27 = v0 == @as(i32, 8);
                                                        if (v27) {
                                                            v48 = @as(i32, 4);
                                                        } else {
                                                            v28 = v0 == @as(i32, 9);
                                                            if (v28) {
                                                                v48 = @as(i32, 10);
                                                            } else {
                                                                v29 = v0 == @as(i32, 10);
                                                                if (v29) {
                                                                    v48 = @as(i32, 3);
                                                                } else {
                                                                    v30 = v0 == @as(i32, 11);
                                                                    if (v30) {
                                                                        v48 = @as(i32, 10);
                                                                    } else {
                                                                        v31 = v0 == @as(i32, 12);
                                                                        if (v31) {
                                                                            v48 = @as(i32, 7);
                                                                        } else {
                                                                            v32 = v0 == @as(i32, 13);
                                                                            if (v32) {
                                                                                v48 = @as(i32, 14);
                                                                            } else {
                                                                                v33 = v0 == @as(i32, 14);
                                                                                if (v33) {
                                                                                    v48 = @as(i32, 8);
                                                                                } else {
                                                                                    v48 = @as(i32, 14);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        tmp36 = v48;
                        tmp37 = v18;
                        v0 = tmp36;
                        v1 = tmp37;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 4);
                if (v2) {
                    return true;
                } else {
                    v3 = v0 == @as(i32, 5);
                    if (v3) {
                        return true;
                    } else {
                        v4 = v0 == @as(i32, 8);
                        if (v4) {
                            return true;
                        } else {
                            v5 = v0 == @as(i32, 9);
                            if (v5) {
                                return true;
                            } else {
                                v6 = v0 == @as(i32, 10);
                                if (v6) {
                                    return true;
                                } else {
                                    v7 = v0 == @as(i32, 12);
                                    if (v7) {
                                        return true;
                                    } else {
                                        v8 = v0 == @as(i32, 14);
                                        if (v8) {
                                            return true;
                                        } else {
                                            v9 = v0 == @as(i32, 15);
                                            return v9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            else => unreachable,
        }
    }
}
fn method20(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    var tmp10: i32 = undefined; _ = &tmp10;
    var tmp11: i32 = undefined; _ = &tmp11;
    var tmp12: u64 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    while (true) {
        v4 = @as(i32, 0) < v1;
        if (v4) {
            v5 = UH1_0();
            tmp4 = method1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = method21(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = v1 -% @as(i32, 1);
            tmp10 = v0;
            tmp11 = v12;
            tmp12 = v7;
            tmp13 = v11;
            v0 = tmp10;
            v1 = tmp11;
            v2 = tmp12;
            v3 = tmp13;
            continue;
        } else {
            return v3;
        }
    }
}
fn method23(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v13: bool = undefined; _ = &v13;
    var v19: i32 = undefined; _ = &v19;
    var v14: bool = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var tmp7: i32 = undefined; _ = &tmp7;
    var tmp8: *UH1 = undefined; _ = &tmp8;
    var v5: bool = undefined; _ = &v5;
    var v11: i32 = undefined; _ = &v11;
    var v6: bool = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var tmp14: i32 = undefined; _ = &tmp14;
    var tmp15: *UH1 = undefined; _ = &tmp15;
    var v2: bool = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                switch (v3.tag) {
                    1 => {
                        v13 = v0 == @as(i32, 0);
                        if (v13) {
                            v19 = @as(i32, 3);
                        } else {
                            v14 = v0 == @as(i32, 1);
                            if (v14) {
                                v19 = @as(i32, 3);
                            } else {
                                v15 = v0 == @as(i32, 2);
                                if (v15) {
                                    v19 = @as(i32, 3);
                                } else {
                                    v16 = v0 == @as(i32, 3);
                                    v19 = @as(i32, 4);
                                }
                            }
                        }
                        tmp7 = v19;
                        tmp8 = v4;
                        v0 = tmp7;
                        v1 = tmp8;
                        continue;
                    },
                    0 => {
                        v5 = v0 == @as(i32, 0);
                        if (v5) {
                            v11 = @as(i32, 1);
                        } else {
                            v6 = v0 == @as(i32, 1);
                            if (v6) {
                                v11 = @as(i32, 2);
                            } else {
                                v7 = v0 == @as(i32, 2);
                                if (v7) {
                                    v11 = @as(i32, 2);
                                } else {
                                    v8 = v0 == @as(i32, 3);
                                    v11 = @as(i32, 4);
                                }
                            }
                        }
                        tmp14 = v11;
                        tmp15 = v4;
                        v0 = tmp14;
                        v1 = tmp15;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 3);
                return v2;
            },
            else => unreachable,
        }
    }
}
fn method22(p0: i32, p1: i32, p2: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v8: i32 = undefined; _ = &v8;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v17: i32 = undefined; _ = &v17;
    var v16: i32 = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    var tmp16: i32 = undefined; _ = &tmp16;
    var tmp17: i32 = undefined; _ = &tmp17;
    var tmp18: i32 = undefined; _ = &tmp18;
    while (true) {
        v3 = v0 < v1;
        if (v3) {
            return v2;
        } else {
            v4 = UH1_0();
            v5 = method14(v1, v4);
            v6 = @as(i32, 0);
            v7 = method23(v6, v5);
            if (v7) {
                v8 = v2 +% @as(i32, 1);
                v9 = v8;
            } else {
                v9 = v2;
            }
            v10 = US0_1();
            v11 = UH1_0();
            v12 = UH1_1(v10, v11);
            v13 = method14(v1, v12);
            v14 = @as(i32, 0);
            v15 = method23(v14, v13);
            if (v15) {
                v16 = v9 +% @as(i32, 1);
                v17 = v16;
            } else {
                v17 = v9;
            }
            v18 = v1 +% @as(i32, 1);
            tmp16 = v0;
            tmp17 = v18;
            tmp18 = v17;
            v0 = tmp16;
            v1 = tmp17;
            v2 = tmp18;
            continue;
        }
    }
}
fn method24(p0: []i32, p1: i32) void {
    var v0: []i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var tmp2: []i32 = undefined; _ = &tmp2;
    var tmp3: i32 = undefined; _ = &tmp3;
    while (true) {
        v2 = v1 < @as(i32, 8192);
        if (v2) {
            v0[spiralIndex(v0.len, v1)] = @as(i32, 0);
            v3 = v1 +% @as(i32, 1);
            tmp2 = v0;
            tmp3 = v3;
            v0 = tmp2;
            v1 = tmp3;
            continue;
        } else {
            return;
        }
    }
}
fn method25(p0: []i32, p1: i32) void {
    var v0: []i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var tmp2: []i32 = undefined; _ = &tmp2;
    var tmp3: i32 = undefined; _ = &tmp3;
    while (true) {
        v2 = v1 < @as(i32, 1);
        if (v2) {
            v0[spiralIndex(v0.len, v1)] = @as(i32, 0);
            v3 = v1 +% @as(i32, 1);
            tmp2 = v0;
            tmp3 = v3;
            v0 = tmp2;
            v1 = tmp3;
            continue;
        } else {
            return;
        }
    }
}
fn method27(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: i32 = p10; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v32: bool = undefined; _ = &v32;
    var v16: bool = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v23: bool = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v33: i32 = undefined; _ = &v33;
    var v34: i32 = undefined; _ = &v34;
    var v37: i32 = undefined; _ = &v37;
    var v38: i32 = undefined; _ = &v38;
    var v39: bool = undefined; _ = &v39;
    var v42: bool = undefined; _ = &v42;
    var v40: i32 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v45: bool = undefined; _ = &v45;
    var v43: i32 = undefined; _ = &v43;
    var v44: bool = undefined; _ = &v44;
    var v46: i32 = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    var tmp30: []i32 = undefined; _ = &tmp30;
    var tmp31: []i32 = undefined; _ = &tmp31;
    var tmp32: []i32 = undefined; _ = &tmp32;
    var tmp33: []i32 = undefined; _ = &tmp33;
    var tmp34: []i32 = undefined; _ = &tmp34;
    var tmp35: []i32 = undefined; _ = &tmp35;
    var tmp36: []i32 = undefined; _ = &tmp36;
    var tmp37: i32 = undefined; _ = &tmp37;
    var tmp38: i32 = undefined; _ = &tmp38;
    var tmp39: i32 = undefined; _ = &tmp39;
    var tmp40: i32 = undefined; _ = &tmp40;
    while (true) {
        v11 = v4[spiralIndex(v4.len, v10)];
        v12 = v11 == @as(i32, 0);
        if (v12) {
            v13 = v6[spiralIndex(v6.len, @as(i32, 0))];
            v14 = v13 < @as(i32, 4096);
            if (v14) {
                v0[spiralIndex(v0.len, v13)] = v7;
                v1[spiralIndex(v1.len, v13)] = v8;
                v2[spiralIndex(v2.len, v13)] = v9;
                v15 = v7 == @as(i32, 1);
                if (v15) {
                    v32 = true;
                } else {
                    v16 = v7 == @as(i32, 5);
                    if (v16) {
                        v32 = true;
                    } else {
                        v17 = v7 == @as(i32, 3);
                        if (v17) {
                            v18 = v3[spiralIndex(v3.len, v8)];
                            v19 = v18 == @as(i32, 1);
                            if (v19) {
                                v32 = true;
                            } else {
                                v20 = v3[spiralIndex(v3.len, v9)];
                                v21 = v20 == @as(i32, 1);
                                v32 = v21;
                            }
                        } else {
                            v23 = v7 == @as(i32, 4);
                            if (v23) {
                                v24 = v3[spiralIndex(v3.len, v8)];
                                v25 = v24 == @as(i32, 1);
                                if (v25) {
                                    v26 = v3[spiralIndex(v3.len, v9)];
                                    v27 = v26 == @as(i32, 1);
                                    v32 = v27;
                                } else {
                                    v32 = false;
                                }
                            } else {
                                v32 = false;
                            }
                        }
                    }
                }
                if (v32) {
                    v33 = @as(i32, 1);
                } else {
                    v33 = @as(i32, 0);
                }
                v3[spiralIndex(v3.len, v13)] = v33;
                v34 = v13 +% @as(i32, 1);
                v4[spiralIndex(v4.len, v10)] = v34;
                v6[spiralIndex(v6.len, @as(i32, 0))] = v34;
                return v13;
            } else {
                spiralFail("brzozowski-interned-store-full");
            }
        } else {
            v37 = v11 -% @as(i32, 1);
            v38 = v0[spiralIndex(v0.len, v37)];
            v39 = v38 == v7;
            if (v39) {
                v40 = v1[spiralIndex(v1.len, v37)];
                v41 = v40 == v8;
                v42 = v41;
            } else {
                v42 = false;
            }
            if (v42) {
                v43 = v2[spiralIndex(v2.len, v37)];
                v44 = v43 == v9;
                v45 = v44;
            } else {
                v45 = false;
            }
            if (v45) {
                return v37;
            } else {
                v46 = v10 +% @as(i32, 1);
                v47 = v46 & @as(i32, 8191);
                tmp30 = v0;
                tmp31 = v1;
                tmp32 = v2;
                tmp33 = v3;
                tmp34 = v4;
                tmp35 = v5;
                tmp36 = v6;
                tmp37 = v7;
                tmp38 = v8;
                tmp39 = v9;
                tmp40 = v47;
                v0 = tmp30;
                v1 = tmp31;
                v2 = tmp32;
                v3 = tmp33;
                v4 = tmp34;
                v5 = tmp35;
                v6 = tmp36;
                v7 = tmp37;
                v8 = tmp38;
                v9 = tmp39;
                v10 = tmp40;
                continue;
            }
        }
    }
}
fn method26(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    v10 = v7 *% @as(i32, 1024);
    v11 = v10 +% v8;
    v12 = v11 *% @as(i32, 4099);
    v13 = v12 +% v9;
    v14 = v13 & @as(i32, 8191);
    return method27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
fn method30(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v16: bool = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v23: bool = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v26: bool = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    v9 = v8 == @as(i32, 0);
    if (v9) {
        return v7;
    } else {
        v10 = v0[spiralIndex(v0.len, v8)];
        v11 = v10 == @as(i32, 3);
        if (v11) {
            v12 = v1[spiralIndex(v1.len, v8)];
            v13 = v7 < v12;
            if (v13) {
                v14 = @as(i32, 3);
                return method26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
            } else {
                v16 = v7 == v12;
                if (v16) {
                    return v8;
                } else {
                    v17 = @as(i32, 3);
                    v18 = v2[spiralIndex(v2.len, v8)];
                    v19 = method30(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    return method26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            v23 = v7 < v8;
            if (v23) {
                v24 = @as(i32, 3);
                return method26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                v26 = v7 == v8;
                if (v26) {
                    return v8;
                } else {
                    v27 = @as(i32, 3);
                    return method26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
fn method29(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var tmp6: []i32 = undefined; _ = &tmp6;
    var tmp7: []i32 = undefined; _ = &tmp7;
    var tmp8: []i32 = undefined; _ = &tmp8;
    var tmp9: []i32 = undefined; _ = &tmp9;
    var tmp10: []i32 = undefined; _ = &tmp10;
    var tmp11: []i32 = undefined; _ = &tmp11;
    var tmp12: []i32 = undefined; _ = &tmp12;
    var tmp13: i32 = undefined; _ = &tmp13;
    var tmp14: i32 = undefined; _ = &tmp14;
    while (true) {
        v9 = v7 == @as(i32, 0);
        if (v9) {
            return v8;
        } else {
            v10 = v0[spiralIndex(v0.len, v7)];
            v11 = v10 == @as(i32, 3);
            if (v11) {
                v12 = v2[spiralIndex(v2.len, v7)];
                v13 = v1[spiralIndex(v1.len, v7)];
                v14 = method30(v0, v1, v2, v3, v4, v5, v6, v13, v8);
                tmp6 = v0;
                tmp7 = v1;
                tmp8 = v2;
                tmp9 = v3;
                tmp10 = v4;
                tmp11 = v5;
                tmp12 = v6;
                tmp13 = v12;
                tmp14 = v14;
                v0 = tmp6;
                v1 = tmp7;
                v2 = tmp8;
                v3 = tmp9;
                v4 = tmp10;
                v5 = tmp11;
                v6 = tmp12;
                v7 = tmp13;
                v8 = tmp14;
                continue;
            } else {
                return method30(v0, v1, v2, v3, v4, v5, v6, v7, v8);
            }
        }
    }
}
fn method31(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v17: bool = undefined; _ = &v17;
    var v15: i32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v24: i32 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: i32 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v31: i32 = undefined; _ = &v31;
    v9 = v7 == @as(i32, 0);
    if (v9) {
        return @as(i32, 0);
    } else {
        v10 = v8 == @as(i32, 0);
        if (v10) {
            return @as(i32, 0);
        } else {
            v11 = v7 == @as(i32, 1);
            if (v11) {
                return v8;
            } else {
                v12 = v8 == @as(i32, 1);
                if (v12) {
                    return v7;
                } else {
                    v13 = v0[spiralIndex(v0.len, v7)];
                    v14 = v13 == @as(i32, 5);
                    if (v14) {
                        v15 = v0[spiralIndex(v0.len, v8)];
                        v16 = v15 == @as(i32, 5);
                        v17 = v16;
                    } else {
                        v17 = false;
                    }
                    if (v17) {
                        v18 = v1[spiralIndex(v1.len, v7)];
                        v19 = v1[spiralIndex(v1.len, v8)];
                        v20 = v18 == v19;
                        if (v20) {
                            return v7;
                        } else {
                            v21 = @as(i32, 4);
                            return method26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                        }
                    } else {
                        v24 = v0[spiralIndex(v0.len, v7)];
                        v25 = v24 == @as(i32, 4);
                        if (v25) {
                            v26 = @as(i32, 4);
                            v27 = v1[spiralIndex(v1.len, v7)];
                            v28 = v2[spiralIndex(v2.len, v7)];
                            v29 = method31(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            return method26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            v31 = @as(i32, 4);
                            return method26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
fn method28(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: *UH0) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: *UH0 = p7; _ = &v7;
    var v14: *UH0 = undefined; _ = &v14;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v8: US0 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    switch (v7.tag) {
        3 => {
            v14 = v7.c3_0;
            v15 = v7.c3_1;
            v16 = method28(v0, v1, v2, v3, v4, v5, v6, v14);
            v17 = method28(v0, v1, v2, v3, v4, v5, v6, v15);
            return method29(v0, v1, v2, v3, v4, v5, v6, v16, v17);
        },
        4 => {
            v19 = v7.c4_0;
            v20 = v7.c4_1;
            v21 = method28(v0, v1, v2, v3, v4, v5, v6, v19);
            v22 = method28(v0, v1, v2, v3, v4, v5, v6, v20);
            return method31(v0, v1, v2, v3, v4, v5, v6, v21, v22);
        },
        2 => {
            v8 = v7.c2_0;
            v9 = @as(i32, 2);
            switch (v8.tag) {
                1 => {
                    v11 = @as(i32, 1);
                },
                0 => {
                    v11 = @as(i32, 0);
                },
                else => unreachable,
            }
            v12 = @as(i32, 0);
            return method26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
        },
        0 => {
            return @as(i32, 0);
        },
        1 => {
            return @as(i32, 1);
        },
        5 => {
            v24 = v7.c5_0;
            v25 = method28(v0, v1, v2, v3, v4, v5, v6, v24);
            v26 = v0[spiralIndex(v0.len, v25)];
            v27 = v26 < @as(i32, 2);
            if (v27) {
                return @as(i32, 1);
            } else {
                v28 = v26 == @as(i32, 5);
                if (v28) {
                    return v25;
                } else {
                    v29 = @as(i32, 5);
                    v30 = @as(i32, 0);
                    return method26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
        },
        else => unreachable,
    }
}
fn method35(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v41: i32 = undefined; _ = &v41;
    var v15: bool = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v19: bool = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v23: i32 = undefined; _ = &v23;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: i32 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: i32 = undefined; _ = &v32;
    var v35: i32 = undefined; _ = &v35;
    var v36: i32 = undefined; _ = &v36;
    var v42: i32 = undefined; _ = &v42;
    var v43: i32 = undefined; _ = &v43;
    v9 = v7 *% @as(i32, 2);
    v10 = v9 +% v8;
    v11 = v5[spiralIndex(v5.len, v10)];
    v12 = v11 == @as(i32, 0);
    if (v12) {
        v13 = v0[spiralIndex(v0.len, v7)];
        v14 = v13 < @as(i32, 2);
        if (v14) {
            v41 = @as(i32, 0);
        } else {
            v15 = v13 == @as(i32, 2);
            if (v15) {
                v16 = v1[spiralIndex(v1.len, v7)];
                v17 = v16 == v8;
                if (v17) {
                    v41 = @as(i32, 1);
                } else {
                    v41 = @as(i32, 0);
                }
            } else {
                v19 = v13 == @as(i32, 3);
                if (v19) {
                    v20 = v1[spiralIndex(v1.len, v7)];
                    v21 = method35(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    v22 = v2[spiralIndex(v2.len, v7)];
                    v23 = method35(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v41 = method29(v0, v1, v2, v3, v4, v5, v6, v21, v23);
                } else {
                    v25 = v13 == @as(i32, 4);
                    if (v25) {
                        v26 = v1[spiralIndex(v1.len, v7)];
                        v27 = v2[spiralIndex(v2.len, v7)];
                        v28 = method35(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        v29 = method31(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        v30 = v3[spiralIndex(v3.len, v26)];
                        v31 = v30 == @as(i32, 1);
                        if (v31) {
                            v32 = method35(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v41 = method29(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            v41 = v29;
                        }
                    } else {
                        v35 = v1[spiralIndex(v1.len, v7)];
                        v36 = method35(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v41 = method31(v0, v1, v2, v3, v4, v5, v6, v36, v7);
                    }
                }
            }
        }
        v42 = v41 +% @as(i32, 1);
        v5[spiralIndex(v5.len, v10)] = v42;
        return v41;
    } else {
        v43 = v11 -% @as(i32, 1);
        return v43;
    }
}
fn method34(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: *UH1 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v15: i32 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var tmp5: []i32 = undefined; _ = &tmp5;
    var tmp6: []i32 = undefined; _ = &tmp6;
    var tmp7: []i32 = undefined; _ = &tmp7;
    var tmp8: []i32 = undefined; _ = &tmp8;
    var tmp9: []i32 = undefined; _ = &tmp9;
    var tmp10: []i32 = undefined; _ = &tmp10;
    var tmp11: []i32 = undefined; _ = &tmp11;
    var tmp12: i32 = undefined; _ = &tmp12;
    var tmp13: *UH1 = undefined; _ = &tmp13;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        v9 = v7 == @as(i32, 0);
        if (v9) {
            return false;
        } else {
            switch (v8.tag) {
                1 => {
                    v12 = v8.c1_0;
                    v13 = v8.c1_1;
                    switch (v12.tag) {
                        1 => {
                            v15 = @as(i32, 1);
                        },
                        0 => {
                            v15 = @as(i32, 0);
                        },
                        else => unreachable,
                    }
                    v16 = method35(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                    tmp5 = v0;
                    tmp6 = v1;
                    tmp7 = v2;
                    tmp8 = v3;
                    tmp9 = v4;
                    tmp10 = v5;
                    tmp11 = v6;
                    tmp12 = v16;
                    tmp13 = v13;
                    v0 = tmp5;
                    v1 = tmp6;
                    v2 = tmp7;
                    v3 = tmp8;
                    v4 = tmp9;
                    v5 = tmp10;
                    v6 = tmp11;
                    v7 = tmp12;
                    v8 = tmp13;
                    continue;
                },
                0 => {
                    v10 = v3[spiralIndex(v3.len, v7)];
                    v11 = v10 == @as(i32, 1);
                    return v11;
                },
                else => unreachable,
            }
        }
    }
}
fn method33(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: *UH1 = p8; _ = &v8;
    return method34(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
fn method32(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: u64, p11: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: u64 = p10; _ = &v10;
    var v11: i32 = p11; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: u64 = undefined; _ = &v15;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v16: bool = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    var v17: i32 = undefined; _ = &v17;
    var v19: i32 = undefined; _ = &v19;
    var tmp9: []i32 = undefined; _ = &tmp9;
    var tmp10: []i32 = undefined; _ = &tmp10;
    var tmp11: []i32 = undefined; _ = &tmp11;
    var tmp12: []i32 = undefined; _ = &tmp12;
    var tmp13: []i32 = undefined; _ = &tmp13;
    var tmp14: []i32 = undefined; _ = &tmp14;
    var tmp15: []i32 = undefined; _ = &tmp15;
    var tmp16: i32 = undefined; _ = &tmp16;
    var tmp17: i32 = undefined; _ = &tmp17;
    var tmp18: i32 = undefined; _ = &tmp18;
    var tmp19: u64 = undefined; _ = &tmp19;
    var tmp20: i32 = undefined; _ = &tmp20;
    while (true) {
        v12 = @as(i32, 0) < v9;
        if (v12) {
            v13 = UH1_0();
            tmp4 = method1(v10, v7, v13);
            v14 = tmp4.f0;
            v15 = tmp4.f1;
            v16 = method33(v0, v1, v2, v3, v4, v5, v6, v8, v14);
            if (v16) {
                v17 = v11 +% @as(i32, 1);
                v18 = v17;
            } else {
                v18 = v11;
            }
            v19 = v9 -% @as(i32, 1);
            tmp9 = v0;
            tmp10 = v1;
            tmp11 = v2;
            tmp12 = v3;
            tmp13 = v4;
            tmp14 = v5;
            tmp15 = v6;
            tmp16 = v7;
            tmp17 = v8;
            tmp18 = v19;
            tmp19 = v15;
            tmp20 = v18;
            v0 = tmp9;
            v1 = tmp10;
            v2 = tmp11;
            v3 = tmp12;
            v4 = tmp13;
            v5 = tmp14;
            v6 = tmp15;
            v7 = tmp16;
            v8 = tmp17;
            v9 = tmp18;
            v10 = tmp19;
            v11 = tmp20;
            continue;
        } else {
            return v11;
        }
    }
}
fn method36(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: i32 = p10; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: i32 = undefined; _ = &v16;
    var v15: i32 = undefined; _ = &v15;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v20: *UH1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v23: i32 = undefined; _ = &v23;
    var v22: i32 = undefined; _ = &v22;
    var v24: i32 = undefined; _ = &v24;
    var tmp14: []i32 = undefined; _ = &tmp14;
    var tmp15: []i32 = undefined; _ = &tmp15;
    var tmp16: []i32 = undefined; _ = &tmp16;
    var tmp17: []i32 = undefined; _ = &tmp17;
    var tmp18: []i32 = undefined; _ = &tmp18;
    var tmp19: []i32 = undefined; _ = &tmp19;
    var tmp20: []i32 = undefined; _ = &tmp20;
    var tmp21: i32 = undefined; _ = &tmp21;
    var tmp22: i32 = undefined; _ = &tmp22;
    var tmp23: i32 = undefined; _ = &tmp23;
    var tmp24: i32 = undefined; _ = &tmp24;
    while (true) {
        v11 = v7 < v9;
        if (v11) {
            return v10;
        } else {
            v12 = UH1_0();
            v13 = method14(v9, v12);
            v14 = method33(v0, v1, v2, v3, v4, v5, v6, v8, v13);
            if (v14) {
                v15 = v10 +% @as(i32, 1);
                v16 = v15;
            } else {
                v16 = v10;
            }
            v17 = US0_1();
            v18 = UH1_0();
            v19 = UH1_1(v17, v18);
            v20 = method14(v9, v19);
            v21 = method33(v0, v1, v2, v3, v4, v5, v6, v8, v20);
            if (v21) {
                v22 = v16 +% @as(i32, 1);
                v23 = v22;
            } else {
                v23 = v16;
            }
            v24 = v9 +% @as(i32, 1);
            tmp14 = v0;
            tmp15 = v1;
            tmp16 = v2;
            tmp17 = v3;
            tmp18 = v4;
            tmp19 = v5;
            tmp20 = v6;
            tmp21 = v7;
            tmp22 = v8;
            tmp23 = v24;
            tmp24 = v23;
            v0 = tmp14;
            v1 = tmp15;
            v2 = tmp16;
            v3 = tmp17;
            v4 = tmp18;
            v5 = tmp19;
            v6 = tmp20;
            v7 = tmp21;
            v8 = tmp22;
            v9 = tmp23;
            v10 = tmp24;
            continue;
        }
    }
}
fn spiralMain() i32 {
    var v0: i32 = undefined; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH0 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: US0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: US0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: US0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: US0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v23: *UH0 = undefined; _ = &v23;
    var v24: US0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: US0 = undefined; _ = &v29;
    var v30: *UH0 = undefined; _ = &v30;
    var v31: US0 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v33: *UH0 = undefined; _ = &v33;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    var v38: u64 = undefined; _ = &v38;
    var v39: i32 = undefined; _ = &v39;
    var v40: i32 = undefined; _ = &v40;
    var v41: i32 = undefined; _ = &v41;
    var v42: i32 = undefined; _ = &v42;
    var v43: US0 = undefined; _ = &v43;
    var v44: *UH0 = undefined; _ = &v44;
    var v45: US0 = undefined; _ = &v45;
    var v46: *UH0 = undefined; _ = &v46;
    var v47: US0 = undefined; _ = &v47;
    var v48: *UH0 = undefined; _ = &v48;
    var v49: *UH0 = undefined; _ = &v49;
    var v50: *UH0 = undefined; _ = &v50;
    var v51: *UH0 = undefined; _ = &v51;
    var v52: US0 = undefined; _ = &v52;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: i32 = undefined; _ = &v55;
    var v56: i32 = undefined; _ = &v56;
    var v57: i32 = undefined; _ = &v57;
    var v58: i32 = undefined; _ = &v58;
    var v59: i32 = undefined; _ = &v59;
    var v60: US0 = undefined; _ = &v60;
    var v61: *UH0 = undefined; _ = &v61;
    var v62: US0 = undefined; _ = &v62;
    var v63: *UH0 = undefined; _ = &v63;
    var v64: *UH0 = undefined; _ = &v64;
    var v65: *UH0 = undefined; _ = &v65;
    var v66: US0 = undefined; _ = &v66;
    var v67: *UH0 = undefined; _ = &v67;
    var v68: *UH0 = undefined; _ = &v68;
    var v69: US0 = undefined; _ = &v69;
    var v70: *UH0 = undefined; _ = &v70;
    var v71: US0 = undefined; _ = &v71;
    var v72: *UH0 = undefined; _ = &v72;
    var v73: *UH0 = undefined; _ = &v73;
    var v74: *UH0 = undefined; _ = &v74;
    var v75: US0 = undefined; _ = &v75;
    var v76: *UH0 = undefined; _ = &v76;
    var v77: US0 = undefined; _ = &v77;
    var v78: *UH0 = undefined; _ = &v78;
    var v79: US0 = undefined; _ = &v79;
    var v80: *UH0 = undefined; _ = &v80;
    var v81: *UH0 = undefined; _ = &v81;
    var v82: US0 = undefined; _ = &v82;
    var v83: *UH0 = undefined; _ = &v83;
    var v84: US0 = undefined; _ = &v84;
    var v85: *UH0 = undefined; _ = &v85;
    var v86: *UH0 = undefined; _ = &v86;
    var v87: US0 = undefined; _ = &v87;
    var v88: *UH0 = undefined; _ = &v88;
    var v89: US0 = undefined; _ = &v89;
    var v90: *UH0 = undefined; _ = &v90;
    var v91: *UH0 = undefined; _ = &v91;
    var v92: *UH0 = undefined; _ = &v92;
    var v93: *UH0 = undefined; _ = &v93;
    var v94: *UH0 = undefined; _ = &v94;
    var v95: *UH0 = undefined; _ = &v95;
    var v96: u64 = undefined; _ = &v96;
    var v97: i32 = undefined; _ = &v97;
    var v98: i32 = undefined; _ = &v98;
    var v99: i32 = undefined; _ = &v99;
    var v100: i32 = undefined; _ = &v100;
    var v101: US0 = undefined; _ = &v101;
    var v102: *UH0 = undefined; _ = &v102;
    var v103: US0 = undefined; _ = &v103;
    var v104: *UH0 = undefined; _ = &v104;
    var v105: US0 = undefined; _ = &v105;
    var v106: *UH0 = undefined; _ = &v106;
    var v107: *UH0 = undefined; _ = &v107;
    var v108: *UH0 = undefined; _ = &v108;
    var v109: *UH0 = undefined; _ = &v109;
    var v110: US0 = undefined; _ = &v110;
    var v111: *UH0 = undefined; _ = &v111;
    var v112: *UH0 = undefined; _ = &v112;
    var v113: i32 = undefined; _ = &v113;
    var v114: i32 = undefined; _ = &v114;
    var v115: i32 = undefined; _ = &v115;
    var v116: bool = undefined; _ = &v116;
    var v118: bool = undefined; _ = &v118;
    var v117: bool = undefined; _ = &v117;
    var v120: bool = undefined; _ = &v120;
    var v119: bool = undefined; _ = &v119;
    var v121: i32 = undefined; _ = &v121;
    var v122: i32 = undefined; _ = &v122;
    var v123: u64 = undefined; _ = &v123;
    var v124: i32 = undefined; _ = &v124;
    var v125: i32 = undefined; _ = &v125;
    var v126: i32 = undefined; _ = &v126;
    var v127: i32 = undefined; _ = &v127;
    var v128: i32 = undefined; _ = &v128;
    var v129: i32 = undefined; _ = &v129;
    var v130: i32 = undefined; _ = &v130;
    var v131: bool = undefined; _ = &v131;
    var v133: bool = undefined; _ = &v133;
    var v132: bool = undefined; _ = &v132;
    var v135: bool = undefined; _ = &v135;
    var v134: bool = undefined; _ = &v134;
    var v136: i32 = undefined; _ = &v136;
    var v137: i32 = undefined; _ = &v137;
    var v138: []i32 = undefined; _ = &v138;
    var v139: []i32 = undefined; _ = &v139;
    var v140: []i32 = undefined; _ = &v140;
    var v141: []i32 = undefined; _ = &v141;
    var v142: []i32 = undefined; _ = &v142;
    var v143: []i32 = undefined; _ = &v143;
    var v144: []i32 = undefined; _ = &v144;
    var v145: i32 = undefined; _ = &v145;
    var v146: i32 = undefined; _ = &v146;
    var v147: i32 = undefined; _ = &v147;
    var v148: i32 = undefined; _ = &v148;
    var v149: i32 = undefined; _ = &v149;
    var v150: i32 = undefined; _ = &v150;
    var v151: i32 = undefined; _ = &v151;
    var v152: i32 = undefined; _ = &v152;
    var v153: i32 = undefined; _ = &v153;
    var v154: i32 = undefined; _ = &v154;
    var v155: i32 = undefined; _ = &v155;
    var v156: bool = undefined; _ = &v156;
    var v158: bool = undefined; _ = &v158;
    var v157: bool = undefined; _ = &v157;
    var v166: []i32 = undefined; _ = &v166;
    var v167: []i32 = undefined; _ = &v167;
    var v168: []i32 = undefined; _ = &v168;
    var v169: []i32 = undefined; _ = &v169;
    var v170: []i32 = undefined; _ = &v170;
    var v171: []i32 = undefined; _ = &v171;
    var v172: []i32 = undefined; _ = &v172;
    var v173: US0 = undefined; _ = &v173;
    var v174: *UH0 = undefined; _ = &v174;
    var v175: US0 = undefined; _ = &v175;
    var v176: *UH0 = undefined; _ = &v176;
    var v177: *UH0 = undefined; _ = &v177;
    var v178: *UH0 = undefined; _ = &v178;
    var v179: US0 = undefined; _ = &v179;
    var v180: *UH0 = undefined; _ = &v180;
    var v181: *UH0 = undefined; _ = &v181;
    var v182: i32 = undefined; _ = &v182;
    var v183: u64 = undefined; _ = &v183;
    var v184: i32 = undefined; _ = &v184;
    var v185: i32 = undefined; _ = &v185;
    var v186: US0 = undefined; _ = &v186;
    var v187: *UH0 = undefined; _ = &v187;
    var v188: US0 = undefined; _ = &v188;
    var v189: *UH0 = undefined; _ = &v189;
    var v190: *UH0 = undefined; _ = &v190;
    var v191: *UH0 = undefined; _ = &v191;
    var v192: US0 = undefined; _ = &v192;
    var v193: *UH0 = undefined; _ = &v193;
    var v194: US0 = undefined; _ = &v194;
    var v195: *UH0 = undefined; _ = &v195;
    var v196: US0 = undefined; _ = &v196;
    var v197: *UH0 = undefined; _ = &v197;
    var v198: *UH0 = undefined; _ = &v198;
    var v199: US0 = undefined; _ = &v199;
    var v200: *UH0 = undefined; _ = &v200;
    var v201: US0 = undefined; _ = &v201;
    var v202: *UH0 = undefined; _ = &v202;
    var v203: *UH0 = undefined; _ = &v203;
    var v204: US0 = undefined; _ = &v204;
    var v205: *UH0 = undefined; _ = &v205;
    var v206: US0 = undefined; _ = &v206;
    var v207: *UH0 = undefined; _ = &v207;
    var v208: *UH0 = undefined; _ = &v208;
    var v209: *UH0 = undefined; _ = &v209;
    var v210: *UH0 = undefined; _ = &v210;
    var v211: *UH0 = undefined; _ = &v211;
    var v212: *UH0 = undefined; _ = &v212;
    var v213: i32 = undefined; _ = &v213;
    var v214: u64 = undefined; _ = &v214;
    var v215: i32 = undefined; _ = &v215;
    var v216: i32 = undefined; _ = &v216;
    var v217: i32 = undefined; _ = &v217;
    var v218: []i32 = undefined; _ = &v218;
    var v219: []i32 = undefined; _ = &v219;
    var v220: []i32 = undefined; _ = &v220;
    var v221: []i32 = undefined; _ = &v221;
    var v222: []i32 = undefined; _ = &v222;
    var v223: []i32 = undefined; _ = &v223;
    var v224: []i32 = undefined; _ = &v224;
    var v225: i32 = undefined; _ = &v225;
    var v226: i32 = undefined; _ = &v226;
    var v227: i32 = undefined; _ = &v227;
    var v228: i32 = undefined; _ = &v228;
    var v229: i32 = undefined; _ = &v229;
    var v230: i32 = undefined; _ = &v230;
    var v231: i32 = undefined; _ = &v231;
    var v232: i32 = undefined; _ = &v232;
    var v233: i32 = undefined; _ = &v233;
    var v234: i32 = undefined; _ = &v234;
    var v235: i32 = undefined; _ = &v235;
    var v236: bool = undefined; _ = &v236;
    var v238: bool = undefined; _ = &v238;
    var v237: bool = undefined; _ = &v237;
    var v246: []i32 = undefined; _ = &v246;
    var v247: []i32 = undefined; _ = &v247;
    var v248: []i32 = undefined; _ = &v248;
    var v249: []i32 = undefined; _ = &v249;
    var v250: []i32 = undefined; _ = &v250;
    var v251: []i32 = undefined; _ = &v251;
    var v252: []i32 = undefined; _ = &v252;
    var v253: US0 = undefined; _ = &v253;
    var v254: *UH0 = undefined; _ = &v254;
    var v255: US0 = undefined; _ = &v255;
    var v256: *UH0 = undefined; _ = &v256;
    var v257: US0 = undefined; _ = &v257;
    var v258: *UH0 = undefined; _ = &v258;
    var v259: *UH0 = undefined; _ = &v259;
    var v260: *UH0 = undefined; _ = &v260;
    var v261: *UH0 = undefined; _ = &v261;
    var v262: US0 = undefined; _ = &v262;
    var v263: *UH0 = undefined; _ = &v263;
    var v264: *UH0 = undefined; _ = &v264;
    var v265: i32 = undefined; _ = &v265;
    var v266: i32 = undefined; _ = &v266;
    var v267: i32 = undefined; _ = &v267;
    var v268: i32 = undefined; _ = &v268;
    var v269: bool = undefined; _ = &v269;
    var v271: bool = undefined; _ = &v271;
    var v270: bool = undefined; _ = &v270;
    var v273: bool = undefined; _ = &v273;
    var v272: bool = undefined; _ = &v272;
    var v274: bool = undefined; _ = &v274;
    var v275: bool = undefined; _ = &v275;
    var v276: bool = undefined; _ = &v276;
    v0 = @as(i32, 200);
    v1 = @as(i32, 32);
    v2 = US0_0();
    v3 = UH0_2(v2);
    v4 = US0_1();
    v5 = UH0_2(v4);
    v6 = UH0_3(v3, v5);
    v7 = UH0_5(v6);
    v8 = US0_0();
    v9 = UH0_2(v8);
    v10 = UH0_4(v7, v9);
    v11 = US0_0();
    v12 = UH0_2(v11);
    v13 = US0_1();
    v14 = UH0_2(v13);
    v15 = UH0_3(v12, v14);
    v16 = UH0_5(v15);
    v17 = US0_1();
    v18 = UH0_2(v17);
    v19 = US0_0();
    v20 = UH0_2(v19);
    v21 = US0_1();
    v22 = UH0_2(v21);
    v23 = UH0_3(v20, v22);
    v24 = US0_0();
    v25 = UH0_2(v24);
    v26 = US0_1();
    v27 = UH0_2(v26);
    v28 = UH0_3(v25, v27);
    v29 = US0_0();
    v30 = UH0_2(v29);
    v31 = US0_1();
    v32 = UH0_2(v31);
    v33 = UH0_3(v30, v32);
    v34 = UH0_4(v28, v33);
    v35 = UH0_4(v23, v34);
    v36 = UH0_4(v18, v35);
    v37 = UH0_4(v16, v36);
    v38 = @as(u64, 1);
    v39 = @as(i32, 0);
    v40 = method0(v10, v1, v0, v38, v39);
    v41 = method0(v37, v1, v0, v38, v39);
    v42 = @as(i32, 16);
    v43 = US0_0();
    v44 = UH0_2(v43);
    v45 = US0_0();
    v46 = UH0_2(v45);
    v47 = US0_0();
    v48 = UH0_2(v47);
    v49 = UH0_4(v46, v48);
    v50 = UH0_3(v44, v49);
    v51 = UH0_5(v50);
    v52 = US0_1();
    v53 = UH0_2(v52);
    v54 = UH0_4(v51, v53);
    v55 = @as(i32, 0);
    v56 = @as(i32, 1);
    v57 = method13(v54, v42, v56, v55);
    v58 = @as(i32, 200);
    v59 = @as(i32, 32);
    v60 = US0_0();
    v61 = UH0_2(v60);
    v62 = US0_1();
    v63 = UH0_2(v62);
    v64 = UH0_3(v61, v63);
    v65 = UH0_5(v64);
    v66 = US0_0();
    v67 = UH0_2(v66);
    v68 = UH0_4(v65, v67);
    v69 = US0_0();
    v70 = UH0_2(v69);
    v71 = US0_1();
    v72 = UH0_2(v71);
    v73 = UH0_3(v70, v72);
    v74 = UH0_5(v73);
    v75 = US0_1();
    v76 = UH0_2(v75);
    v77 = US0_0();
    v78 = UH0_2(v77);
    v79 = US0_1();
    v80 = UH0_2(v79);
    v81 = UH0_3(v78, v80);
    v82 = US0_0();
    v83 = UH0_2(v82);
    v84 = US0_1();
    v85 = UH0_2(v84);
    v86 = UH0_3(v83, v85);
    v87 = US0_0();
    v88 = UH0_2(v87);
    v89 = US0_1();
    v90 = UH0_2(v89);
    v91 = UH0_3(v88, v90);
    v92 = UH0_4(v86, v91);
    v93 = UH0_4(v81, v92);
    v94 = UH0_4(v76, v93);
    v95 = UH0_4(v74, v94);
    v96 = @as(u64, 1);
    v97 = @as(i32, 0);
    v98 = method15(v68, v59, v58, v96, v97);
    v99 = method15(v95, v59, v58, v96, v97);
    v100 = @as(i32, 16);
    v101 = US0_0();
    v102 = UH0_2(v101);
    v103 = US0_0();
    v104 = UH0_2(v103);
    v105 = US0_0();
    v106 = UH0_2(v105);
    v107 = UH0_4(v104, v106);
    v108 = UH0_3(v102, v107);
    v109 = UH0_5(v108);
    v110 = US0_1();
    v111 = UH0_2(v110);
    v112 = UH0_4(v109, v111);
    v113 = @as(i32, 0);
    v114 = @as(i32, 1);
    v115 = method17(v112, v100, v114, v113);
    v116 = v40 == v98;
    if (v116) {
        v117 = v41 == v99;
        v118 = v117;
    } else {
        v118 = false;
    }
    if (v118) {
        v119 = v57 == v115;
        v120 = v119;
    } else {
        v120 = false;
    }
    if (v120) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    v121 = @as(i32, 200);
    v122 = @as(i32, 32);
    v123 = @as(u64, 1);
    v124 = @as(i32, 0);
    v125 = method18(v122, v121, v123, v124);
    v126 = method20(v122, v121, v123, v124);
    v127 = @as(i32, 16);
    v128 = @as(i32, 0);
    v129 = @as(i32, 1);
    v130 = method22(v127, v129, v128);
    v131 = v40 == v125;
    if (v131) {
        v132 = v41 == v126;
        v133 = v132;
    } else {
        v133 = false;
    }
    if (v133) {
        v134 = v57 == v130;
        v135 = v134;
    } else {
        v135 = false;
    }
    if (v135) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    v136 = @as(i32, 200);
    v137 = @as(i32, 32);
    v138 = spiralNewArray(i32, @as(i32, 4096));
    v139 = spiralNewArray(i32, @as(i32, 4096));
    v140 = spiralNewArray(i32, @as(i32, 4096));
    v141 = spiralNewArray(i32, @as(i32, 4096));
    v142 = spiralNewArray(i32, @as(i32, 8192));
    v143 = spiralNewArray(i32, @as(i32, 8192));
    v144 = spiralNewArray(i32, @as(i32, 1));
    v145 = @as(i32, 0);
    _ = method24(v142, v145);
    v146 = @as(i32, 0);
    _ = method24(v143, v146);
    v147 = @as(i32, 0);
    _ = method25(v144, v147);
    v148 = @as(i32, 0);
    v149 = @as(i32, 0);
    v150 = @as(i32, 0);
    v151 = method26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150);
    v152 = @as(i32, 1);
    v153 = @as(i32, 0);
    v154 = @as(i32, 0);
    v155 = method26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154);
    v156 = v151 == @as(i32, 0);
    if (v156) {
        v157 = v155 == @as(i32, 1);
        v158 = v157;
    } else {
        v158 = false;
    }
    if (v158) {
        v166 = v138;
        v167 = v139;
        v168 = v140;
        v169 = v141;
        v170 = v142;
        v171 = v143;
        v172 = v144;
    } else {
        if (spiral_true) spiralFail("brzozowski-interned-store-init");
    }
    v173 = US0_0();
    v174 = UH0_2(v173);
    v175 = US0_1();
    v176 = UH0_2(v175);
    v177 = UH0_3(v174, v176);
    v178 = UH0_5(v177);
    v179 = US0_0();
    v180 = UH0_2(v179);
    v181 = UH0_4(v178, v180);
    v182 = method28(v166, v167, v168, v169, v170, v171, v172, v181);
    v183 = @as(u64, 1);
    v184 = @as(i32, 0);
    v185 = method32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184);
    v186 = US0_0();
    v187 = UH0_2(v186);
    v188 = US0_1();
    v189 = UH0_2(v188);
    v190 = UH0_3(v187, v189);
    v191 = UH0_5(v190);
    v192 = US0_1();
    v193 = UH0_2(v192);
    v194 = US0_0();
    v195 = UH0_2(v194);
    v196 = US0_1();
    v197 = UH0_2(v196);
    v198 = UH0_3(v195, v197);
    v199 = US0_0();
    v200 = UH0_2(v199);
    v201 = US0_1();
    v202 = UH0_2(v201);
    v203 = UH0_3(v200, v202);
    v204 = US0_0();
    v205 = UH0_2(v204);
    v206 = US0_1();
    v207 = UH0_2(v206);
    v208 = UH0_3(v205, v207);
    v209 = UH0_4(v203, v208);
    v210 = UH0_4(v198, v209);
    v211 = UH0_4(v193, v210);
    v212 = UH0_4(v191, v211);
    v213 = method28(v166, v167, v168, v169, v170, v171, v172, v212);
    v214 = @as(u64, 1);
    v215 = @as(i32, 0);
    v216 = method32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215);
    v217 = @as(i32, 16);
    v218 = spiralNewArray(i32, @as(i32, 4096));
    v219 = spiralNewArray(i32, @as(i32, 4096));
    v220 = spiralNewArray(i32, @as(i32, 4096));
    v221 = spiralNewArray(i32, @as(i32, 4096));
    v222 = spiralNewArray(i32, @as(i32, 8192));
    v223 = spiralNewArray(i32, @as(i32, 8192));
    v224 = spiralNewArray(i32, @as(i32, 1));
    v225 = @as(i32, 0);
    _ = method24(v222, v225);
    v226 = @as(i32, 0);
    _ = method24(v223, v226);
    v227 = @as(i32, 0);
    _ = method25(v224, v227);
    v228 = @as(i32, 0);
    v229 = @as(i32, 0);
    v230 = @as(i32, 0);
    v231 = method26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230);
    v232 = @as(i32, 1);
    v233 = @as(i32, 0);
    v234 = @as(i32, 0);
    v235 = method26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234);
    v236 = v231 == @as(i32, 0);
    if (v236) {
        v237 = v235 == @as(i32, 1);
        v238 = v237;
    } else {
        v238 = false;
    }
    if (v238) {
        v246 = v218;
        v247 = v219;
        v248 = v220;
        v249 = v221;
        v250 = v222;
        v251 = v223;
        v252 = v224;
    } else {
        if (spiral_true) spiralFail("brzozowski-interned-store-init");
    }
    v253 = US0_0();
    v254 = UH0_2(v253);
    v255 = US0_0();
    v256 = UH0_2(v255);
    v257 = US0_0();
    v258 = UH0_2(v257);
    v259 = UH0_4(v256, v258);
    v260 = UH0_3(v254, v259);
    v261 = UH0_5(v260);
    v262 = US0_1();
    v263 = UH0_2(v262);
    v264 = UH0_4(v261, v263);
    v265 = method28(v246, v247, v248, v249, v250, v251, v252, v264);
    v266 = @as(i32, 1);
    v267 = @as(i32, 0);
    v268 = method36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267);
    v269 = v40 == v185;
    if (v269) {
        v270 = v41 == v216;
        v271 = v270;
    } else {
        v271 = false;
    }
    if (v271) {
        v272 = v57 == v268;
        v273 = v272;
    } else {
        v273 = false;
    }
    if (v273) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    v274 = v57 == @as(i32, 16);
    if (v274) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-zero-runs-count");
    }
    v275 = v40 == @as(i32, 93);
    if (v275) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-ends-with-zero-count");
    }
    v276 = v41 == @as(i32, 97);
    if (v276) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-fourth-from-end-count");
    }
    return @as(i32, 0);
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
