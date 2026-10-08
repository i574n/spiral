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
const UH0 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH0 = undefined };
const UH2 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH2 = undefined };
const UH1 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: *UH1 = undefined };
const US1 = struct { tag: i32 };
const UH3 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH3 = undefined };
const UH5 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH5 = undefined };
const UH4 = struct { tag: i32, c1_0: *UH5 = undefined, c1_1: *UH4 = undefined };
const US2 = struct { tag: i32 };
const UH6 = struct { tag: i32, c1_0: US2 = undefined, c1_1: *UH6 = undefined };
const UH7 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH7 = undefined, c3_1: *UH7 = undefined, c4_0: *UH7 = undefined, c4_1: *UH7 = undefined, c5_0: *UH7 = undefined };
const US3 = struct { tag: i32 };
const US4 = struct { tag: i32 };
const US5 = struct { tag: i32 };
const UH8 = struct { tag: i32, c2_0: US1 = undefined, c3_0: *UH8 = undefined, c3_1: *UH8 = undefined, c4_0: *UH8 = undefined, c4_1: *UH8 = undefined, c5_0: *UH8 = undefined };
fn US0_0() US0 {
    return US0{ .tag = 0 };
}
fn US0_1() US0 {
    return US0{ .tag = 1 };
}
fn UH0_0() *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 0 });
}
fn UH0_1(a0: US0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH2_0() *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 0 });
}
fn UH2_1(a0: US0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH1_0() *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 0 });
}
fn UH1_1(a0: *UH2, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn method0(p0: *UH0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = method0(v3);
            v5 = UH2_0();
            v6 = UH2_1(v2, v5);
            return UH1_1(v6, v4);
        },
        0 => {
            return UH1_0();
        },
        else => unreachable,
    }
}
fn method2(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = method2(v3, v1);
            return UH1_1(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn method3(p0: US0, p1: *UH1) *UH1 {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = method3(v0, v4);
            v6 = UH2_1(v0, v3);
            return UH1_1(v6, v5);
        },
        0 => {
            return UH1_0();
        },
        else => unreachable,
    }
}
fn method1(p0: *UH0, p1: *UH1) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = method3(v3, v1);
            v6 = method1(v4, v1);
            return method2(v5, v6);
        },
        0 => {
            return UH1_0();
        },
        else => unreachable,
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
fn UH3_0() *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 0 });
}
fn UH3_1(a0: US1, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH5_0() *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 0 });
}
fn UH5_1(a0: US1, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH4_0() *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 0 });
}
fn UH4_1(a0: *UH5, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn method4(p0: *UH3) *UH4 {
    var v0: *UH3 = p0; _ = &v0;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = method4(v3);
            v5 = UH5_0();
            v6 = UH5_1(v2, v5);
            return UH4_1(v6, v4);
        },
        0 => {
            return UH4_0();
        },
        else => unreachable,
    }
}
fn method6(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = method6(v3, v1);
            return UH4_1(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn method7(p0: US1, p1: *UH4) *UH4 {
    var v0: US1 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = method7(v0, v4);
            v6 = UH5_1(v0, v3);
            return UH4_1(v6, v5);
        },
        0 => {
            return UH4_0();
        },
        else => unreachable,
    }
}
fn method5(p0: *UH3, p1: *UH4) *UH4 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = method7(v3, v1);
            v6 = method5(v4, v1);
            return method6(v5, v6);
        },
        0 => {
            return UH4_0();
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
fn US2_2() US2 {
    return US2{ .tag = 2 };
}
fn UH6_0() *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 0 });
}
fn UH6_1(a0: US2, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH7_0() *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 0 });
}
fn UH7_1() *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1 });
}
fn UH7_2(a0: US0) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 2, .c2_0 = a0 });
}
fn UH7_3(a0: *UH7, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH7_4(a0: *UH7, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH7_5(a0: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 5, .c5_0 = a0 });
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
fn US4_0() US4 {
    return US4{ .tag = 0 };
}
fn US4_1() US4 {
    return US4{ .tag = 1 };
}
fn US4_2() US4 {
    return US4{ .tag = 2 };
}
fn method9(p0: i32, p1: *UH2) US3 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v11: US4 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v19: i32 = undefined; _ = &v19;
    var v16: US4 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v22: bool = undefined; _ = &v22;
    var v27: i32 = undefined; _ = &v27;
    var v23: bool = undefined; _ = &v23;
    var v25: bool = undefined; _ = &v25;
    var tmp12: i32 = undefined; _ = &tmp12;
    var tmp13: *UH2 = undefined; _ = &tmp13;
    var v2: bool = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                switch (v6.tag) {
                    1 => {
                        v11 = US4_2();
                    },
                    0 => {
                        v11 = US4_1();
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
                if (v12) {
                    v19 = @as(i32, 0);
                } else {
                    switch (v6.tag) {
                        1 => {
                            v16 = US4_1();
                        },
                        0 => {
                            v16 = US4_0();
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
                        v19 = @as(i32, -1);
                    }
                }
                v20 = v19 < @as(i32, 0);
                if (v20) {
                    return US3_2();
                } else {
                    v22 = v0 == @as(i32, 0);
                    if (v22) {
                        v23 = v19 == @as(i32, 0);
                        if (v23) {
                            v27 = @as(i32, 0);
                        } else {
                            v27 = @as(i32, 1);
                        }
                    } else {
                        v25 = v19 == @as(i32, 0);
                        if (v25) {
                            v27 = @as(i32, 0);
                        } else {
                            v27 = @as(i32, 1);
                        }
                    }
                    tmp12 = v27;
                    tmp13 = v7;
                    v0 = tmp12;
                    v1 = tmp13;
                    continue;
                }
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                if (v2) {
                    return US3_0();
                } else {
                    return US3_1();
                }
            },
            else => unreachable,
        }
    }
}
fn method15(p0: *UH7, p1: *UH7) US4 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v53: *UH7 = undefined; _ = &v53;
    var v54: *UH7 = undefined; _ = &v54;
    var v55: *UH7 = undefined; _ = &v55;
    var v56: *UH7 = undefined; _ = &v56;
    var v57: US4 = undefined; _ = &v57;
    var tmp5: *UH7 = undefined; _ = &tmp5;
    var tmp6: *UH7 = undefined; _ = &tmp6;
    var v28: *UH7 = undefined; _ = &v28;
    var v29: *UH7 = undefined; _ = &v29;
    var v34: *UH7 = undefined; _ = &v34;
    var v35: *UH7 = undefined; _ = &v35;
    var v36: US4 = undefined; _ = &v36;
    var tmp12: *UH7 = undefined; _ = &tmp12;
    var tmp13: *UH7 = undefined; _ = &tmp13;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH7 = undefined; _ = &v44;
    var v45: *UH7 = undefined; _ = &v45;
    var v46: *UH7 = undefined; _ = &v46;
    var v48: *UH7 = undefined; _ = &v48;
    var tmp21: *UH7 = undefined; _ = &tmp21;
    var tmp22: *UH7 = undefined; _ = &tmp22;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = method15(v53, v55);
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
                        return US4_2();
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
                        v36 = method15(v28, v34);
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
                        return US4_2();
                    },
                    0 => {
                        return US4_2();
                    },
                    1 => {
                        return US4_2();
                    },
                    else => {
                        return US4_0();
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
                                        return US4_1();
                                    },
                                    0 => {
                                        return US4_2();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US4_0();
                                    },
                                    0 => {
                                        return US4_1();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US4_2();
                    },
                    1 => {
                        return US4_2();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_1();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_2();
                    },
                    1 => {
                        return US4_1();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US4_0();
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
                        return US4_2();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn method14(p0: *UH7, p1: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH7 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = method15(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = method14(v0, v3);
                    return UH7_3(v2, v6);
                },
                0 => {
                    return UH7_3(v0, v1);
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
            v11 = method15(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH7_3(v1, v0);
                },
                0 => {
                    return UH7_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn method13(p0: *UH7, p1: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var tmp3: *UH7 = undefined; _ = &tmp3;
    var tmp4: *UH7 = undefined; _ = &tmp4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = method14(v2, v1);
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
                return method14(v0, v1);
            },
        }
    }
}
fn method17(p0: *UH7, p1: *UH7) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v18: *UH7 = undefined; _ = &v18;
    var v19: *UH7 = undefined; _ = &v19;
    var v20: *UH7 = undefined; _ = &v20;
    var v21: *UH7 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var tmp5: *UH7 = undefined; _ = &tmp5;
    var tmp6: *UH7 = undefined; _ = &tmp6;
    var v26: *UH7 = undefined; _ = &v26;
    var v27: *UH7 = undefined; _ = &v27;
    var v28: *UH7 = undefined; _ = &v28;
    var v29: *UH7 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var tmp12: *UH7 = undefined; _ = &tmp12;
    var tmp13: *UH7 = undefined; _ = &tmp13;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US4 = undefined; _ = &v15;
    var v34: *UH7 = undefined; _ = &v34;
    var v35: *UH7 = undefined; _ = &v35;
    var tmp19: *UH7 = undefined; _ = &tmp19;
    var tmp20: *UH7 = undefined; _ = &tmp20;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = method17(v18, v20);
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
                        v30 = method17(v26, v28);
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
                                        v15 = US4_1();
                                    },
                                    0 => {
                                        v15 = US4_2();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US4_0();
                                    },
                                    0 => {
                                        v15 = US4_1();
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
fn method16(p0: *UH7, p1: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v12: *UH7 = undefined; _ = &v12;
    var v13: *UH7 = undefined; _ = &v13;
    var v14: *UH7 = undefined; _ = &v14;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH7_0();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH7_0();
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
                                            v14 = method16(v13, v1);
                                            return UH7_4(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = method17(v4, v5);
                                                    if (v6) {
                                                        return UH7_5(v4);
                                                    } else {
                                                        return UH7_4(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH7_4(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH7_4(v0, v1);
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
fn method18(p0: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v3: *UH7 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH7_1();
        },
        1 => {
            return UH7_1();
        },
        5 => {
            v3 = v0.c5_0;
            return UH7_5(v3);
        },
        else => {
            return UH7_5(v0);
        },
    }
}
fn method12(p0: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v7: *UH7 = undefined; _ = &v7;
    var v8: *UH7 = undefined; _ = &v8;
    var v10: *UH7 = undefined; _ = &v10;
    var v11: *UH7 = undefined; _ = &v11;
    var v12: *UH7 = undefined; _ = &v12;
    var v13: *UH7 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH7 = undefined; _ = &v15;
    var v16: *UH7 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = method12(v5);
            v8 = method12(v6);
            return method13(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = method12(v10);
            v13 = method12(v11);
            return method16(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH7_2(v3);
        },
        0 => {
            return UH7_0();
        },
        1 => {
            return UH7_1();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = method12(v15);
            return method18(v16);
        },
        else => unreachable,
    }
}
fn US5_0() US5 {
    return US5{ .tag = 0 };
}
fn US5_1() US5 {
    return US5{ .tag = 1 };
}
fn method20(p0: *UH7) US5 {
    var v0: *UH7 = p0; _ = &v0;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v7: US5 = undefined; _ = &v7;
    var v8: US5 = undefined; _ = &v8;
    var v16: *UH7 = undefined; _ = &v16;
    var v17: *UH7 = undefined; _ = &v17;
    var v18: US5 = undefined; _ = &v18;
    var v19: US5 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH7 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = method20(v5);
            v8 = method20(v6);
            switch (v7.tag) {
                0 => {
                    return US5_0();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US5_0();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US5_1();
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
            v18 = method20(v16);
            v19 = method20(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US5_0();
                        },
                        else => {
                            return US5_1();
                        },
                    }
                },
                else => {
                    return US5_1();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US5_1();
        },
        0 => {
            return US5_1();
        },
        1 => {
            return US5_0();
        },
        5 => {
            v25 = v0.c5_0;
            return US5_0();
        },
        else => unreachable,
    }
}
fn method19(p0: *UH7, p1: US0) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH7 = undefined; _ = &v19;
    var v20: *UH7 = undefined; _ = &v20;
    var v21: *UH7 = undefined; _ = &v21;
    var v22: *UH7 = undefined; _ = &v22;
    var v24: *UH7 = undefined; _ = &v24;
    var v25: *UH7 = undefined; _ = &v25;
    var v26: US5 = undefined; _ = &v26;
    var v31: *UH7 = undefined; _ = &v31;
    var v27: *UH7 = undefined; _ = &v27;
    var v28: *UH7 = undefined; _ = &v28;
    var v29: *UH7 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US4 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH7 = undefined; _ = &v35;
    var v36: *UH7 = undefined; _ = &v36;
    var v37: *UH7 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = method19(v19, v1);
            v22 = method19(v20, v1);
            return method13(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = method20(v24);
            switch (v26.tag) {
                1 => {
                    v31 = method19(v24, v1);
                    return method16(v31, v25);
                },
                0 => {
                    v27 = method19(v24, v1);
                    v28 = method16(v27, v25);
                    v29 = method19(v25, v1);
                    return method13(v28, v29);
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
                            v14 = US4_1();
                        },
                        0 => {
                            v14 = US4_2();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_0();
                        },
                        0 => {
                            v14 = US4_1();
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
                return UH7_1();
            } else {
                return UH7_0();
            }
        },
        0 => {
            return UH7_0();
        },
        1 => {
            return UH7_0();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = method19(v35, v1);
            v37 = method18(v35);
            return method16(v36, v37);
        },
        else => unreachable,
    }
}
fn method11(p0: *UH7, p1: US0) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH7 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    v2 = method12(v0);
    v3 = method19(v2, v1);
    return method12(v3);
}
fn method10(p0: *UH7, p1: *UH2) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH7 = undefined; _ = &v8;
    var tmp3: *UH7 = undefined; _ = &tmp3;
    var tmp4: *UH2 = undefined; _ = &tmp4;
    var v2: *UH7 = undefined; _ = &v2;
    var v3: US5 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = method11(v0, v6);
                tmp3 = v8;
                tmp4 = v7;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                v2 = method12(v0);
                v3 = method20(v2);
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
fn method8(p0: *UH7, p1: *UH1) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v11: bool = undefined; _ = &v11;
    var v7: bool = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var tmp7: *UH7 = undefined; _ = &tmp7;
    var tmp8: *UH1 = undefined; _ = &tmp8;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = @as(i32, 1);
                v5 = method9(v4, v2);
                switch (v5.tag) {
                    0 => {
                        v11 = method10(v0, v2);
                    },
                    2 => {
                        v11 = false;
                    },
                    1 => {
                        v7 = method10(v0, v2);
                        v8 = v7 == false;
                        v11 = v8;
                    },
                    else => unreachable,
                }
                if (v11) {
                    tmp7 = v0;
                    tmp8 = v3;
                    v0 = tmp7;
                    v1 = tmp8;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn UH8_0() *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 0 });
}
fn UH8_1() *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 1 });
}
fn UH8_2(a0: US1) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 2, .c2_0 = a0 });
}
fn UH8_3(a0: *UH8, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH8_4(a0: *UH8, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH8_5(a0: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 5, .c5_0 = a0 });
}
fn method22(p0: i32, p1: *UH5) US3 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v12: US4 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v30: i32 = undefined; _ = &v30;
    var v19: US4 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v26: US4 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v31: bool = undefined; _ = &v31;
    var v33: bool = undefined; _ = &v33;
    var v46: i32 = undefined; _ = &v46;
    var v34: bool = undefined; _ = &v34;
    var v35: bool = undefined; _ = &v35;
    var v37: bool = undefined; _ = &v37;
    var v38: bool = undefined; _ = &v38;
    var v39: bool = undefined; _ = &v39;
    var v41: bool = undefined; _ = &v41;
    var v42: bool = undefined; _ = &v42;
    var tmp19: i32 = undefined; _ = &tmp19;
    var tmp20: *UH5 = undefined; _ = &tmp20;
    var v2: bool = undefined; _ = &v2;
    var v4: bool = undefined; _ = &v4;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v8 = v1.c1_0;
                v9 = v1.c1_1;
                switch (v8.tag) {
                    0 => {
                        v12 = US4_1();
                    },
                    else => {
                        v12 = US4_2();
                    },
                }
                switch (v12.tag) {
                    1 => {
                        v13 = true;
                    },
                    else => {
                        v13 = false;
                    },
                }
                if (v13) {
                    v30 = @as(i32, 0);
                } else {
                    switch (v8.tag) {
                        0 => {
                            v19 = US4_0();
                        },
                        1 => {
                            v19 = US4_1();
                        },
                        2 => {
                            v19 = US4_2();
                        },
                        else => unreachable,
                    }
                    switch (v19.tag) {
                        1 => {
                            v20 = true;
                        },
                        else => {
                            v20 = false;
                        },
                    }
                    if (v20) {
                        v30 = @as(i32, 1);
                    } else {
                        switch (v8.tag) {
                            0 => {
                                v26 = US4_0();
                            },
                            1 => {
                                v26 = US4_0();
                            },
                            2 => {
                                v26 = US4_1();
                            },
                            else => unreachable,
                        }
                        switch (v26.tag) {
                            1 => {
                                v27 = true;
                            },
                            else => {
                                v27 = false;
                            },
                        }
                        if (v27) {
                            v30 = @as(i32, 2);
                        } else {
                            v30 = @as(i32, -1);
                        }
                    }
                }
                v31 = v30 < @as(i32, 0);
                if (v31) {
                    return US3_2();
                } else {
                    v33 = v0 == @as(i32, 0);
                    if (v33) {
                        v34 = v30 == @as(i32, 0);
                        if (v34) {
                            v46 = @as(i32, 0);
                        } else {
                            v35 = v30 == @as(i32, 1);
                            v46 = @as(i32, 0);
                        }
                    } else {
                        v37 = v0 == @as(i32, 1);
                        if (v37) {
                            v38 = v30 == @as(i32, 0);
                            if (v38) {
                                v46 = @as(i32, 0);
                            } else {
                                v39 = v30 == @as(i32, 1);
                                v46 = @as(i32, 0);
                            }
                        } else {
                            v41 = v30 == @as(i32, 0);
                            if (v41) {
                                v46 = @as(i32, 2);
                            } else {
                                v42 = v30 == @as(i32, 1);
                                if (v42) {
                                    v46 = @as(i32, 2);
                                } else {
                                    v46 = @as(i32, 1);
                                }
                            }
                        }
                    }
                    tmp19 = v46;
                    tmp20 = v9;
                    v0 = tmp19;
                    v1 = tmp20;
                    continue;
                }
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                if (v2) {
                    v4 = false;
                } else {
                    v3 = v0 == @as(i32, 1);
                    v4 = v3;
                }
                if (v4) {
                    return US3_0();
                } else {
                    return US3_1();
                }
            },
            else => unreachable,
        }
    }
}
fn method28(p0: *UH8, p1: *UH8) US4 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v59: *UH8 = undefined; _ = &v59;
    var v60: *UH8 = undefined; _ = &v60;
    var v61: *UH8 = undefined; _ = &v61;
    var v62: *UH8 = undefined; _ = &v62;
    var v63: US4 = undefined; _ = &v63;
    var tmp5: *UH8 = undefined; _ = &tmp5;
    var tmp6: *UH8 = undefined; _ = &tmp6;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v40: *UH8 = undefined; _ = &v40;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: US4 = undefined; _ = &v42;
    var tmp12: *UH8 = undefined; _ = &tmp12;
    var tmp13: *UH8 = undefined; _ = &tmp13;
    var v38: US1 = undefined; _ = &v38;
    var v10: US1 = undefined; _ = &v10;
    var v13: US1 = undefined; _ = &v13;
    var v50: *UH8 = undefined; _ = &v50;
    var v51: *UH8 = undefined; _ = &v51;
    var v52: *UH8 = undefined; _ = &v52;
    var v54: *UH8 = undefined; _ = &v54;
    var tmp21: *UH8 = undefined; _ = &tmp21;
    var tmp22: *UH8 = undefined; _ = &tmp22;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = method28(v59, v61);
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
                        return US4_2();
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
                        v42 = method28(v34, v40);
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
                        return US4_2();
                    },
                    0 => {
                        return US4_2();
                    },
                    1 => {
                        return US4_2();
                    },
                    else => {
                        return US4_0();
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
                                        return US4_1();
                                    },
                                    else => {
                                        return US4_0();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US4_2();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_1();
                                                    },
                                                    2 => {
                                                        return US4_0();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_2();
                                                    },
                                                    2 => {
                                                        return US4_1();
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
                        return US4_2();
                    },
                    1 => {
                        return US4_2();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_1();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_2();
                    },
                    1 => {
                        return US4_1();
                    },
                    else => {
                        return US4_0();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US4_0();
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
                        return US4_2();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn method27(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH8 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = method28(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = method27(v0, v3);
                    return UH8_3(v2, v6);
                },
                0 => {
                    return UH8_3(v0, v1);
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
            v11 = method28(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH8_3(v1, v0);
                },
                0 => {
                    return UH8_3(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn method26(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var tmp3: *UH8 = undefined; _ = &tmp3;
    var tmp4: *UH8 = undefined; _ = &tmp4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = method27(v2, v1);
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
                return method27(v0, v1);
            },
        }
    }
}
fn method30(p0: *UH8, p1: *UH8) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v24: *UH8 = undefined; _ = &v24;
    var v25: *UH8 = undefined; _ = &v25;
    var v26: *UH8 = undefined; _ = &v26;
    var v27: *UH8 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var tmp5: *UH8 = undefined; _ = &tmp5;
    var tmp6: *UH8 = undefined; _ = &tmp6;
    var v32: *UH8 = undefined; _ = &v32;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var tmp12: *UH8 = undefined; _ = &tmp12;
    var tmp13: *UH8 = undefined; _ = &tmp13;
    var v4: US1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v21: US4 = undefined; _ = &v21;
    var v40: *UH8 = undefined; _ = &v40;
    var v41: *UH8 = undefined; _ = &v41;
    var tmp19: *UH8 = undefined; _ = &tmp19;
    var tmp20: *UH8 = undefined; _ = &tmp20;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = method30(v24, v26);
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
                        v36 = method30(v32, v34);
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
                                        v21 = US4_1();
                                    },
                                    else => {
                                        v21 = US4_0();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US4_2();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_1();
                                                    },
                                                    2 => {
                                                        v21 = US4_0();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_2();
                                                    },
                                                    2 => {
                                                        v21 = US4_1();
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
fn method29(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: *UH8 = undefined; _ = &v14;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH8_0();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH8_0();
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
                                            v14 = method29(v13, v1);
                                            return UH8_4(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = method30(v4, v5);
                                                    if (v6) {
                                                        return UH8_5(v4);
                                                    } else {
                                                        return UH8_4(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH8_4(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH8_4(v0, v1);
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
fn method31(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v3: *UH8 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH8_1();
        },
        1 => {
            return UH8_1();
        },
        5 => {
            v3 = v0.c5_0;
            return UH8_5(v3);
        },
        else => {
            return UH8_5(v0);
        },
    }
}
fn method25(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v10: *UH8 = undefined; _ = &v10;
    var v11: *UH8 = undefined; _ = &v11;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v3: US1 = undefined; _ = &v3;
    var v15: *UH8 = undefined; _ = &v15;
    var v16: *UH8 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = method25(v5);
            v8 = method25(v6);
            return method26(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = method25(v10);
            v13 = method25(v11);
            return method29(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH8_2(v3);
        },
        0 => {
            return UH8_0();
        },
        1 => {
            return UH8_1();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = method25(v15);
            return method31(v16);
        },
        else => unreachable,
    }
}
fn method33(p0: *UH8) US5 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: US5 = undefined; _ = &v7;
    var v8: US5 = undefined; _ = &v8;
    var v16: *UH8 = undefined; _ = &v16;
    var v17: *UH8 = undefined; _ = &v17;
    var v18: US5 = undefined; _ = &v18;
    var v19: US5 = undefined; _ = &v19;
    var v3: US1 = undefined; _ = &v3;
    var v25: *UH8 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = method33(v5);
            v8 = method33(v6);
            switch (v7.tag) {
                0 => {
                    return US5_0();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US5_0();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US5_1();
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
            v18 = method33(v16);
            v19 = method33(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US5_0();
                        },
                        else => {
                            return US5_1();
                        },
                    }
                },
                else => {
                    return US5_1();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US5_1();
        },
        0 => {
            return US5_1();
        },
        1 => {
            return US5_0();
        },
        5 => {
            v25 = v0.c5_0;
            return US5_0();
        },
        else => unreachable,
    }
}
fn method32(p0: *UH8, p1: US1) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v25: *UH8 = undefined; _ = &v25;
    var v26: *UH8 = undefined; _ = &v26;
    var v27: *UH8 = undefined; _ = &v27;
    var v28: *UH8 = undefined; _ = &v28;
    var v30: *UH8 = undefined; _ = &v30;
    var v31: *UH8 = undefined; _ = &v31;
    var v32: US5 = undefined; _ = &v32;
    var v37: *UH8 = undefined; _ = &v37;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v4: US1 = undefined; _ = &v4;
    var v20: US4 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: *UH8 = undefined; _ = &v42;
    var v43: *UH8 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = method32(v25, v1);
            v28 = method32(v26, v1);
            return method26(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = method33(v30);
            switch (v32.tag) {
                1 => {
                    v37 = method32(v30, v1);
                    return method29(v37, v31);
                },
                0 => {
                    v33 = method32(v30, v1);
                    v34 = method29(v33, v31);
                    v35 = method32(v31, v1);
                    return method26(v34, v35);
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
                            v20 = US4_1();
                        },
                        else => {
                            v20 = US4_0();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_2();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_1();
                                        },
                                        2 => {
                                            v20 = US4_0();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_2();
                                        },
                                        2 => {
                                            v20 = US4_1();
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
                return UH8_1();
            } else {
                return UH8_0();
            }
        },
        0 => {
            return UH8_0();
        },
        1 => {
            return UH8_0();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = method32(v41, v1);
            v43 = method31(v41);
            return method29(v42, v43);
        },
        else => unreachable,
    }
}
fn method24(p0: *UH8, p1: US1) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    v2 = method25(v0);
    v3 = method32(v2, v1);
    return method25(v3);
}
fn method23(p0: *UH8, p1: *UH5) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v6: US1 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var tmp3: *UH8 = undefined; _ = &tmp3;
    var tmp4: *UH5 = undefined; _ = &tmp4;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: US5 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = method24(v0, v6);
                tmp3 = v8;
                tmp4 = v7;
                v0 = tmp3;
                v1 = tmp4;
                continue;
            },
            0 => {
                v2 = method25(v0);
                v3 = method33(v2);
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
fn method21(p0: *UH8, p1: *UH4) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v11: bool = undefined; _ = &v11;
    var v7: bool = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var tmp7: *UH8 = undefined; _ = &tmp7;
    var tmp8: *UH4 = undefined; _ = &tmp8;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = @as(i32, 2);
                v5 = method22(v4, v2);
                switch (v5.tag) {
                    0 => {
                        v11 = method23(v0, v2);
                    },
                    2 => {
                        v11 = false;
                    },
                    1 => {
                        v7 = method23(v0, v2);
                        v8 = v7 == false;
                        v11 = v8;
                    },
                    else => unreachable,
                }
                if (v11) {
                    tmp7 = v0;
                    tmp8 = v3;
                    v0 = tmp7;
                    v1 = tmp8;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn method34(p0: i32, p1: *UH6) US3 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v7: US2 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v11: US4 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v21: i32 = undefined; _ = &v21;
    var v18: US4 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v22: bool = undefined; _ = &v22;
    var v24: bool = undefined; _ = &v24;
    var v28: i32 = undefined; _ = &v28;
    var v25: bool = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var tmp12: i32 = undefined; _ = &tmp12;
    var tmp13: *UH6 = undefined; _ = &tmp13;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v7 = v1.c1_0;
                v8 = v1.c1_1;
                switch (v7.tag) {
                    0 => {
                        v11 = US4_1();
                    },
                    else => {
                        v11 = US4_2();
                    },
                }
                switch (v11.tag) {
                    1 => {
                        v12 = true;
                    },
                    else => {
                        v12 = false;
                    },
                }
                if (v12) {
                    v21 = @as(i32, 0);
                } else {
                    switch (v7.tag) {
                        0 => {
                            v18 = US4_0();
                        },
                        1 => {
                            v18 = US4_1();
                        },
                        2 => {
                            v18 = US4_2();
                        },
                        else => unreachable,
                    }
                    switch (v18.tag) {
                        1 => {
                            v19 = true;
                        },
                        else => {
                            v19 = false;
                        },
                    }
                    if (v19) {
                        v21 = @as(i32, 1);
                    } else {
                        v21 = @as(i32, -1);
                    }
                }
                v22 = v21 < @as(i32, 0);
                if (v22) {
                    return US3_2();
                } else {
                    v24 = v0 == @as(i32, 0);
                    if (v24) {
                        v25 = v21 == @as(i32, 0);
                        v28 = @as(i32, 0);
                    } else {
                        v26 = v21 == @as(i32, 0);
                        if (v26) {
                            v28 = @as(i32, 1);
                        } else {
                            v28 = @as(i32, 0);
                        }
                    }
                    tmp12 = v28;
                    tmp13 = v8;
                    v0 = tmp12;
                    v1 = tmp13;
                    continue;
                }
            },
            0 => {
                v2 = v0 == @as(i32, 0);
                v3 = v2 == false;
                if (v3) {
                    return US3_0();
                } else {
                    return US3_1();
                }
            },
            else => unreachable,
        }
    }
}
fn spiralMain() i32 {
    var v0: US0 = undefined; _ = &v0;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: US0 = undefined; _ = &v8;
    var v9: US0 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: US0 = undefined; _ = &v13;
    var v14: US0 = undefined; _ = &v14;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v20: *UH1 = undefined; _ = &v20;
    var v21: US1 = undefined; _ = &v21;
    var v22: US1 = undefined; _ = &v22;
    var v23: US1 = undefined; _ = &v23;
    var v24: *UH3 = undefined; _ = &v24;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: *UH3 = undefined; _ = &v26;
    var v27: *UH3 = undefined; _ = &v27;
    var v28: *UH4 = undefined; _ = &v28;
    var v29: *UH5 = undefined; _ = &v29;
    var v30: *UH4 = undefined; _ = &v30;
    var v31: US1 = undefined; _ = &v31;
    var v32: US1 = undefined; _ = &v32;
    var v33: US1 = undefined; _ = &v33;
    var v34: *UH3 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v36: *UH3 = undefined; _ = &v36;
    var v37: *UH3 = undefined; _ = &v37;
    var v38: US1 = undefined; _ = &v38;
    var v39: US1 = undefined; _ = &v39;
    var v40: US1 = undefined; _ = &v40;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: *UH3 = undefined; _ = &v42;
    var v43: *UH3 = undefined; _ = &v43;
    var v44: *UH3 = undefined; _ = &v44;
    var v45: *UH4 = undefined; _ = &v45;
    var v46: *UH4 = undefined; _ = &v46;
    var v47: *UH4 = undefined; _ = &v47;
    var v48: US2 = undefined; _ = &v48;
    var v49: *UH6 = undefined; _ = &v49;
    var v50: *UH6 = undefined; _ = &v50;
    var v51: US0 = undefined; _ = &v51;
    var v52: *UH7 = undefined; _ = &v52;
    var v53: US0 = undefined; _ = &v53;
    var v54: *UH7 = undefined; _ = &v54;
    var v55: *UH7 = undefined; _ = &v55;
    var v56: *UH7 = undefined; _ = &v56;
    var v57: US0 = undefined; _ = &v57;
    var v58: *UH7 = undefined; _ = &v58;
    var v59: *UH7 = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v75: bool = undefined; _ = &v75;
    var v61: US1 = undefined; _ = &v61;
    var v62: *UH8 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var v64: *UH8 = undefined; _ = &v64;
    var v65: *UH8 = undefined; _ = &v65;
    var v66: *UH8 = undefined; _ = &v66;
    var v67: US1 = undefined; _ = &v67;
    var v68: *UH8 = undefined; _ = &v68;
    var v69: *UH8 = undefined; _ = &v69;
    var v70: bool = undefined; _ = &v70;
    var v71: i32 = undefined; _ = &v71;
    var v72: US3 = undefined; _ = &v72;
    v0 = US0_0();
    v1 = US0_1();
    v2 = UH0_0();
    v3 = UH0_1(v1, v2);
    v4 = UH0_1(v0, v3);
    v5 = method0(v4);
    v6 = UH2_0();
    v7 = UH1_1(v6, v5);
    v8 = US0_0();
    v9 = US0_1();
    v10 = UH0_0();
    v11 = UH0_1(v9, v10);
    v12 = UH0_1(v8, v11);
    v13 = US0_0();
    v14 = US0_1();
    v15 = UH0_0();
    v16 = UH0_1(v14, v15);
    v17 = UH0_1(v13, v16);
    v18 = method0(v17);
    v19 = method1(v12, v18);
    v20 = method2(v7, v19);
    v21 = US1_0();
    v22 = US1_1();
    v23 = US1_2();
    v24 = UH3_0();
    v25 = UH3_1(v23, v24);
    v26 = UH3_1(v22, v25);
    v27 = UH3_1(v21, v26);
    v28 = method4(v27);
    v29 = UH5_0();
    v30 = UH4_1(v29, v28);
    v31 = US1_0();
    v32 = US1_1();
    v33 = US1_2();
    v34 = UH3_0();
    v35 = UH3_1(v33, v34);
    v36 = UH3_1(v32, v35);
    v37 = UH3_1(v31, v36);
    v38 = US1_0();
    v39 = US1_1();
    v40 = US1_2();
    v41 = UH3_0();
    v42 = UH3_1(v40, v41);
    v43 = UH3_1(v39, v42);
    v44 = UH3_1(v38, v43);
    v45 = method4(v44);
    v46 = method5(v37, v45);
    v47 = method6(v30, v46);
    v48 = US2_2();
    v49 = UH6_0();
    v50 = UH6_1(v48, v49);
    v51 = US0_0();
    v52 = UH7_2(v51);
    v53 = US0_1();
    v54 = UH7_2(v53);
    v55 = UH7_3(v52, v54);
    v56 = UH7_5(v55);
    v57 = US0_0();
    v58 = UH7_2(v57);
    v59 = UH7_4(v56, v58);
    v60 = method8(v59, v20);
    if (v60) {
        v61 = US1_0();
        v62 = UH8_2(v61);
        v63 = US1_1();
        v64 = UH8_2(v63);
        v65 = UH8_3(v62, v64);
        v66 = UH8_5(v65);
        v67 = US1_2();
        v68 = UH8_2(v67);
        v69 = UH8_4(v66, v68);
        v70 = method21(v69, v47);
        if (v70) {
            v71 = @as(i32, 1);
            v72 = method34(v71, v50);
            switch (v72.tag) {
                2 => {
                    v75 = true;
                },
                else => {
                    v75 = false;
                },
            }
        } else {
            v75 = false;
        }
    } else {
        v75 = false;
    }
    if (v75) {
        return @as(i32, 0);
    } else {
        return @as(i32, 1);
    }
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
