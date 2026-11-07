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
fn zeros_input_1(p0: i32, p1: *UH1) *UH1 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    while (true) {
        v2 = @as(i32, 0) < v0;
        if (v2) {
            v3 = v0 -% @as(i32, 1);
            v4 = US0_BitZero();
            v5 = UH1_InputCons(v4, v1);
            v0 = v3;
            v1 = v5;
            continue;
        } else {
            return v1;
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
fn loop_0(p0: *UH0, p1: i32, p2: i32, p3: i32) i32 {
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
    while (true) {
        v4 = v1 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_InputEmpty();
            v6 = zeros_input_1(v2, v5);
            v7 = UH2_RegexListNil();
            v8 = UH2_RegexListCons(v0, v7);
            v9 = backtrack_stack_2(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = US0_BitOne();
            v13 = UH1_InputEmpty();
            v14 = UH1_InputCons(v12, v13);
            v15 = zeros_input_1(v2, v14);
            v16 = UH2_RegexListNil();
            v17 = UH2_RegexListCons(v0, v16);
            v18 = backtrack_stack_2(v17, v15);
            if (v18) {
                v19 = v11 +% @as(i32, 1);
                v20 = v19;
            } else {
                v20 = v11;
            }
            v21 = v2 +% @as(i32, 1);
            v2 = v21;
            v3 = v20;
            continue;
        }
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 26);
    const v1: US0 = US0_BitZero();
    const v2: *UH0 = UH0_RegexChar(v1);
    const v3: US0 = US0_BitZero();
    const v4: *UH0 = UH0_RegexChar(v3);
    const v5: US0 = US0_BitZero();
    const v6: *UH0 = UH0_RegexChar(v5);
    const v7: *UH0 = UH0_RegexCat(v4, v6);
    const v8: *UH0 = UH0_RegexAlt(v2, v7);
    const v9: *UH0 = UH0_RegexStar(v8);
    const v10: US0 = US0_BitOne();
    const v11: *UH0 = UH0_RegexChar(v10);
    const v12: *UH0 = UH0_RegexCat(v9, v11);
    const v13: i32 = @as(i32, 0);
    const v14: i32 = @as(i32, 1);
    const v15: i32 = loop_0(v12, v0, v14, v13);
    const v16: bool = v15 == @as(i32, 26);
    if (v16) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-zero-runs-count");
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
