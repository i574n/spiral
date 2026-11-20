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
fn spiralMain() i32 {
    var v13: bool = undefined; _ = &v13;
    var v12: bool = undefined; _ = &v12;
    var v15: bool = undefined; _ = &v15;
    var v14: bool = undefined; _ = &v14;
    var v17: bool = undefined; _ = &v17;
    var v16: bool = undefined; _ = &v16;
    var v19: bool = undefined; _ = &v19;
    var v18: bool = undefined; _ = &v18;
    var v21: bool = undefined; _ = &v21;
    var v20: bool = undefined; _ = &v20;
    const v0: i32 = @as(i32, 7);
    const v1: i32 = @as(i32, -2);
    const v2: i32 = @as(i32, -7);
    const v3: u32 = @as(u32, 100);
    const v4: u32 = @as(u32, 7);
    const v5: i32 = @divTrunc(v0, v1);
    const v6: i32 = @rem(v0, v1);
    const v7: i32 = @divTrunc(v2, v1);
    const v8: i32 = @rem(v2, v1);
    const v9: u32 = @divTrunc(v3, v4);
    const v10: u32 = @rem(v3, v4);
    const v11: bool = v5 == @as(i32, -3);
    if (v11) {
        v12 = v6 == @as(i32, 1);
        v13 = v12;
    } else {
        v13 = false;
    }
    if (v13) {
        v14 = v7 == @as(i32, 3);
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15) {
        v16 = v8 == @as(i32, -1);
        v17 = v16;
    } else {
        v17 = false;
    }
    if (v17) {
        v18 = v9 == @as(u32, 14);
        v19 = v18;
    } else {
        v19 = false;
    }
    if (v19) {
        v20 = v10 == @as(u32, 2);
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
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
