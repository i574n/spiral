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
const US0 = struct { tag: i32, c0_0: i32 = undefined, c1_0: i32 = undefined, c2_0: i32 = undefined };
fn US0_Circle(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_Square(a0: i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn US0_Tri(a0: i32) US0 {
    return US0{ .tag = 2, .c2_0 = a0 };
}
fn US0_Dot() US0 {
    return US0{ .tag = 3 };
}
fn pick_0(p0: i32) US0 {
    var v0: i32 = p0; _ = &v0;
    var v3: bool = undefined; _ = &v3;
    var v5: bool = undefined; _ = &v5;
    const v1: bool = v0 == @as(i32, 0);
    if (v1) {
        return US0_Circle(@as(i32, 5));
    } else {
        v3 = v0 == @as(i32, 1);
        if (v3) {
            return US0_Square(@as(i32, 4));
        } else {
            v5 = v0 == @as(i32, 2);
            if (v5) {
                return US0_Tri(@as(i32, 7));
            } else {
                return US0_Dot();
            }
        }
    }
}
fn measure_1(p0: US0, p1: i32) i32 {
    var v0: US0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    switch (v0.tag) {
        0 => {
            v2 = v0.c0_0;
            v3 = v2 *% @as(i32, 3);
            return v3;
        },
        else => {
            v4 = v1 *% v1;
            v5 = v4 > @as(i32, 3);
            switch (v0.tag) {
                3 => {
                    return v4;
                },
                1 => {
                    v6 = v0.c1_0;
                    if (v5) {
                        v7 = v6 *% v6;
                        return v7;
                    } else {
                        return v6;
                    }
                },
                2 => {
                    v9 = v0.c2_0;
                    if (v5) {
                        v10 = v9 *% @as(i32, 2);
                        return v10;
                    } else {
                        return v9;
                    }
                },
                else => unreachable,
            }
        },
    }
}
fn measure_tri_2(p0: US0, p1: i32) i32 {
    var v0: US0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            v2 = v0.c0_0;
            return v2;
        },
        3 => {
            return @as(i32, 0);
        },
        1 => {
            v3 = v0.c1_0;
            return v3;
        },
        else => {
            v4 = v1 +% @as(i32, 2);
            switch (v0.tag) {
                2 => {
                    v5 = v0.c2_0;
                    v6 = v5 *% v4;
                    return v6;
                },
                else => unreachable,
            }
        },
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 0);
    const v1: US0 = pick_0(v0);
    const v2: i32 = measure_1(v1, v0);
    const v3: i32 = v0 +% @as(i32, 1);
    const v4: US0 = pick_0(v3);
    const v5: i32 = measure_1(v4, v3);
    const v6: i32 = v2 +% v5;
    const v7: i32 = v0 +% @as(i32, 2);
    const v8: US0 = pick_0(v7);
    const v9: i32 = measure_1(v8, v7);
    const v10: i32 = v6 +% v9;
    const v11: i32 = v0 +% @as(i32, 3);
    const v12: US0 = pick_0(v11);
    const v13: i32 = measure_1(v12, v11);
    const v14: i32 = v10 +% v13;
    const v15: US0 = pick_0(v7);
    const v16: i32 = measure_tri_2(v15, v0);
    const v17: i32 = v14 +% v16;
    const v18: US0 = pick_0(v0);
    const v19: i32 = measure_tri_2(v18, v0);
    const v20: i32 = v17 +% v19;
    return v20;
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
