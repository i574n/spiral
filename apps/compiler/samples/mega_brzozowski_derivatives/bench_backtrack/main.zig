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
var spiral_environ: std.process.Environ = .empty;
var spiral_true: bool = true;
var spiral_out_buffer: [1 << 16]u8 = undefined;
var spiral_out_len: usize = 0;
fn spiralFlush() void {
    if (spiral_out_len == 0) return;
    spiralWrite(1, spiral_out_buffer[0..spiral_out_len]);
    spiral_out_len = 0;
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
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
const UH2 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH2 = undefined };
const US1 = struct { tag: i32 };
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_RegexEmpty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_RegexEpsilon() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 1 };
    };
    return &shared.value;
}
fn UH0_RegexChar(a0: US0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 2, .c2_0 = a0 });
}
fn UH0_RegexAlt(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH0_RegexCat(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH0_RegexStar(a0: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 5, .c5_0 = a0 });
}
fn UH1_InputEmpty() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_InputCons(a0: US0, a1: *UH1) *UH1 {
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
                v11 = US0_BitZero();
                v13 = v11;
            } else {
                v12 = US0_BitOne();
                v13 = v12;
            }
            v14 = UH1_InputCons(v13, v2);
            v0 = v6;
            v1 = v7;
            v2 = v14;
            continue;
        } else {
            return Tuple0{ .f0 = v2, .f1 = v0 };
        }
    }
}
fn UH2_RegexListNil() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_RegexListCons(a0: *UH0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US1_SymbolLess() US1 {
    return US1{ .tag = 0 };
}
fn US1_SymbolSame() US1 {
    return US1{ .tag = 1 };
}
fn US1_SymbolGreater() US1 {
    return US1{ .tag = 2 };
}
fn backtrack_stack_2(p0: *UH2, p1: *UH1) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var v9: US0 = undefined; _ = &v9;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v21: US1 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v39: *UH0 = undefined; _ = &v39;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
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
                        v29 = UH2_RegexListCons(v27, v7);
                        v30 = backtrack_stack_2(v29, v1);
                        if (v30) {
                            return true;
                        } else {
                            v31 = UH2_RegexListCons(v28, v7);
                            v0 = v31;
                            continue;
                        }
                    },
                    4 => {
                        v34 = v6.c4_0;
                        v35 = v6.c4_1;
                        v36 = UH2_RegexListCons(v35, v7);
                        v37 = UH2_RegexListCons(v34, v36);
                        v0 = v37;
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
                                                v21 = US1_SymbolSame();
                                            },
                                            0 => {
                                                v21 = US1_SymbolGreater();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    0 => {
                                        switch (v10.tag) {
                                            1 => {
                                                v21 = US1_SymbolLess();
                                            },
                                            0 => {
                                                v21 = US1_SymbolSame();
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
                                    v0 = v7;
                                    v1 = v11;
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
                        v0 = v7;
                        continue;
                    },
                    5 => {
                        v39 = v6.c5_0;
                        v40 = UH2_RegexListCons(v39, v0);
                        v41 = backtrack_stack_2(v40, v1);
                        if (v41) {
                            return true;
                        } else {
                            v0 = v7;
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
fn loop_0(p0: *UH0, p1: i32, p2: i32, p3: u64, p4: i32) i32 {
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
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_InputEmpty();
            tmp4 = random_bit_input_1(v3, v1, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = UH2_RegexListNil();
            v10 = UH2_RegexListCons(v0, v9);
            v11 = backtrack_stack_2(v10, v7);
            if (v11) {
                v12 = v4 +% @as(i32, 1);
                v13 = v12;
            } else {
                v13 = v4;
            }
            v14 = v2 -% @as(i32, 1);
            v2 = v14;
            v3 = v8;
            v4 = v13;
            continue;
        } else {
            return v4;
        }
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 2000);
    const v1: i32 = @as(i32, 32);
    const v2: US0 = US0_BitZero();
    const v3: *UH0 = UH0_RegexChar(v2);
    const v4: US0 = US0_BitOne();
    const v5: *UH0 = UH0_RegexChar(v4);
    const v6: *UH0 = UH0_RegexAlt(v3, v5);
    const v7: *UH0 = UH0_RegexStar(v6);
    const v8: US0 = US0_BitZero();
    const v9: *UH0 = UH0_RegexChar(v8);
    const v10: *UH0 = UH0_RegexCat(v7, v9);
    const v11: US0 = US0_BitZero();
    const v12: *UH0 = UH0_RegexChar(v11);
    const v13: US0 = US0_BitOne();
    const v14: *UH0 = UH0_RegexChar(v13);
    const v15: *UH0 = UH0_RegexAlt(v12, v14);
    const v16: *UH0 = UH0_RegexStar(v15);
    const v17: US0 = US0_BitOne();
    const v18: *UH0 = UH0_RegexChar(v17);
    const v19: US0 = US0_BitZero();
    const v20: *UH0 = UH0_RegexChar(v19);
    const v21: US0 = US0_BitOne();
    const v22: *UH0 = UH0_RegexChar(v21);
    const v23: *UH0 = UH0_RegexAlt(v20, v22);
    const v24: US0 = US0_BitZero();
    const v25: *UH0 = UH0_RegexChar(v24);
    const v26: US0 = US0_BitOne();
    const v27: *UH0 = UH0_RegexChar(v26);
    const v28: *UH0 = UH0_RegexAlt(v25, v27);
    const v29: US0 = US0_BitZero();
    const v30: *UH0 = UH0_RegexChar(v29);
    const v31: US0 = US0_BitOne();
    const v32: *UH0 = UH0_RegexChar(v31);
    const v33: *UH0 = UH0_RegexAlt(v30, v32);
    const v34: *UH0 = UH0_RegexCat(v28, v33);
    const v35: *UH0 = UH0_RegexCat(v23, v34);
    const v36: *UH0 = UH0_RegexCat(v18, v35);
    const v37: *UH0 = UH0_RegexCat(v16, v36);
    const v38: u64 = @as(u64, 1);
    const v39: i32 = @as(i32, 0);
    const v40: i32 = loop_0(v10, v1, v0, v38, v39);
    const v41: i32 = loop_0(v37, v1, v0, v38, v39);
    const v42: bool = v40 == @as(i32, 997);
    if (v42) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-ends-with-zero-count");
    }
    const v43: bool = v41 == @as(i32, 985);
    if (v43) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-fourth-from-end-count");
    }
    return @as(i32, 0);
}
var spiral_exit_code: i32 = 0;
fn spiralMainThread() void {
    spiral_exit_code = spiralMain();
}
extern "kernel32" fn CreateThread(attributes: ?*anyopaque, stack_size: usize, start: *const fn (?*anyopaque) callconv(.winapi) u32, parameter: ?*anyopaque, flags: u32, id: ?*u32) callconv(.winapi) ?std.os.windows.HANDLE;
extern "kernel32" fn WaitForSingleObject(handle: std.os.windows.HANDLE, milliseconds: u32) callconv(.winapi) u32;
extern "kernel32" fn ExitProcess(code: u32) callconv(.winapi) noreturn;
fn spiralMainThreadReserved(_: ?*anyopaque) callconv(.winapi) u32 {
    spiralMainThread();
    return 0;
}
pub fn main(init: std.process.Init.Minimal) void {
    spiral_gpa = spiral_arena.allocator();
    spiral_environ = init.environ;
    if (@import("builtin").os.tag == .windows) {
        const handle = CreateThread(null, 1 << 30, spiralMainThreadReserved, null, 0x00010000, null) orelse @panic("spiral: could not start the main thread");
        _ = WaitForSingleObject(handle, 0xFFFFFFFF);
    } else {
        const thread = std.Thread.spawn(.{ .stack_size = 1 << 30 }, spiralMainThread, .{}) catch @panic("spiral: could not start the main thread");
        thread.join();
    }
    spiralFlush();
    if (@import("builtin").os.tag == .windows) ExitProcess(@bitCast(spiral_exit_code)) else std.process.exit(@truncate(@as(u32, @bitCast(spiral_exit_code))));
}
