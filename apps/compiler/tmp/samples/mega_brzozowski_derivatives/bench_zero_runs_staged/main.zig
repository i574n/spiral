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
const UH0 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH0 = undefined };
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_InputEmpty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_InputCons(a0: US0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn zeros_input_1(p0: i32, p1: *UH0) *UH0 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    while (true) {
        v2 = @as(i32, 0) < v0;
        if (v2) {
            v3 = v0 -% @as(i32, 1);
            v4 = US0_BitZero();
            v5 = UH0_InputCons(v4, v1);
            v0 = v3;
            v1 = v5;
            continue;
        } else {
            return v1;
        }
    }
}
fn run_2(p0: i32, p1: *UH0) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v13: bool = undefined; _ = &v13;
    var v19: i32 = undefined; _ = &v19;
    var v14: bool = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v5: bool = undefined; _ = &v5;
    var v11: i32 = undefined; _ = &v11;
    var v6: bool = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
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
                                    v19 = @as(i32, 4);
                                }
                            }
                        }
                        v0 = v19;
                        v1 = v4;
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
                                    v11 = @as(i32, 4);
                                }
                            }
                        }
                        v0 = v11;
                        v1 = v4;
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
fn loop_0(p0: i32, p1: i32, p2: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v8: i32 = undefined; _ = &v8;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v17: i32 = undefined; _ = &v17;
    var v16: i32 = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    while (true) {
        v3 = v0 < v1;
        if (v3) {
            return v2;
        } else {
            v4 = UH0_InputEmpty();
            v5 = zeros_input_1(v1, v4);
            v6 = @as(i32, 0);
            v7 = run_2(v6, v5);
            if (v7) {
                v8 = v2 +% @as(i32, 1);
                v9 = v8;
            } else {
                v9 = v2;
            }
            v10 = US0_BitOne();
            v11 = UH0_InputEmpty();
            v12 = UH0_InputCons(v10, v11);
            v13 = zeros_input_1(v1, v12);
            v14 = @as(i32, 0);
            v15 = run_2(v14, v13);
            if (v15) {
                v16 = v9 +% @as(i32, 1);
                v17 = v16;
            } else {
                v17 = v9;
            }
            v18 = v1 +% @as(i32, 1);
            v1 = v18;
            v2 = v17;
            continue;
        }
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 26);
    const v1: i32 = @as(i32, 0);
    const v2: i32 = @as(i32, 1);
    const v3: i32 = loop_0(v0, v2, v1);
    const v4: bool = v3 == @as(i32, 26);
    if (v4) {
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
