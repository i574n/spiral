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
const US0 = struct { tag: i32 };
fn US0_North() US0 {
    return US0{ .tag = 0 };
}
fn US0_East() US0 {
    return US0{ .tag = 1 };
}
fn US0_South() US0 {
    return US0{ .tag = 2 };
}
fn US0_West() US0 {
    return US0{ .tag = 3 };
}
fn spiralMain() i32 {
    var v8: US0 = undefined; _ = &v8;
    var v16: US0 = undefined; _ = &v16;
    var v18: bool = undefined; _ = &v18;
    var tmp5: i32 = undefined; _ = &tmp5;
    var v19: i32 = undefined; _ = &v19;
    var v21: i32 = undefined; _ = &v21;
    var v23: i32 = undefined; _ = &v23;
    var v27: i32 = undefined; _ = &v27;
    const v0: US0 = US0_North();
    switch (v0.tag) {
        1 => {
            v8 = US0_South();
        },
        0 => {
            v8 = US0_East();
        },
        2 => {
            v8 = US0_West();
        },
        3 => {
            v8 = US0_North();
        },
        else => unreachable,
    }
    switch (v8.tag) {
        1 => {
            v16 = US0_South();
        },
        0 => {
            v16 = US0_East();
        },
        2 => {
            v16 = US0_West();
        },
        3 => {
            v16 = US0_North();
        },
        else => unreachable,
    }
    const v17: US0 = US0_South();
    tmp5 = if ((v16.tag == v17.tag)) v16.tag else -1;
    switch (tmp5) {
        1 => {
            v18 = true;
        },
        0 => {
            v18 = true;
        },
        2 => {
            v18 = true;
        },
        3 => {
            v18 = true;
        },
        else => {
            v18 = false;
        },
    }
    if (v18) {
        v19 = @as(i32, 100);
    } else {
        v19 = @as(i32, 0);
    }
    switch (v0.tag) {
        1 => {
            v21 = @as(i32, 2);
        },
        0 => {
            v21 = @as(i32, 1);
        },
        else => {
            v21 = @as(i32, 7);
        },
    }
    switch (v8.tag) {
        1 => {
            v23 = @as(i32, 2);
        },
        0 => {
            v23 = @as(i32, 1);
        },
        else => {
            v23 = @as(i32, 7);
        },
    }
    const v24: i32 = v23 *% @as(i32, 3);
    const v25: i32 = v21 +% v24;
    switch (v16.tag) {
        1 => {
            v27 = @as(i32, 2);
        },
        0 => {
            v27 = @as(i32, 1);
        },
        else => {
            v27 = @as(i32, 7);
        },
    }
    const v28: i32 = v27 *% @as(i32, 9);
    const v29: i32 = v25 +% v28;
    const v30: i32 = v29 +% v19;
    return v30;
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
