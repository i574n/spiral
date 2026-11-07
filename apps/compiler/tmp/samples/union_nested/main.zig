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
const US1 = struct { tag: i32, c0_0: i32 = undefined, c1_0: i32 = undefined };
const US0 = struct { tag: i32, c0_0: US1 = undefined, c1_0: i32 = undefined };
fn US1_A(a0: i32) US1 {
    return US1{ .tag = 0, .c0_0 = a0 };
}
fn US1_B(a0: i32) US1 {
    return US1{ .tag = 1, .c1_0 = a0 };
}
fn US0_Wrap(a0: US1) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_Other(a0: i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn score_inner_1(p0: US1) i32 {
    var v0: US1 = p0; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return v1;
        },
        1 => {
            v2 = v0.c1_0;
            v3 = -%v2;
            return v3;
        },
        else => unreachable,
    }
}
fn score_0(p0: US0) i32 {
    var v0: US0 = p0; _ = &v0;
    var v3: i32 = undefined; _ = &v3;
    var v1: US1 = undefined; _ = &v1;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            return v3;
        },
        0 => {
            v1 = v0.c0_0;
            return score_inner_1(v1);
        },
        else => unreachable,
    }
}
fn spiralMain() i32 {
    var v4: US0 = undefined; _ = &v4;
    var v1: US1 = undefined; _ = &v1;
    var v8: US0 = undefined; _ = &v8;
    var v6: US1 = undefined; _ = &v6;
    var v13: bool = undefined; _ = &v13;
    var v11: i32 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    const v0: bool = true;
    if (v0) {
        v1 = US1_A(@as(i32, 7));
        v4 = US0_Wrap(v1);
    } else {
        v4 = US0_Other(@as(i32, 1));
    }
    if (v0) {
        v8 = US0_Other(@as(i32, 4));
    } else {
        v6 = US1_B(@as(i32, 2));
        v8 = US0_Wrap(v6);
    }
    const v9: i32 = score_0(v4);
    const v10: bool = v9 == @as(i32, 7);
    if (v10) {
        v11 = score_0(v8);
        v12 = v11 == @as(i32, 4);
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        return @as(i32, 0);
    } else {
        return @as(i32, 1);
    }
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
