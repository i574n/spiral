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
    var v10: bool = undefined; _ = &v10;
    var v8: f64 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v12: bool = undefined; _ = &v12;
    var v11: bool = undefined; _ = &v11;
    var v14: bool = undefined; _ = &v14;
    var v13: bool = undefined; _ = &v13;
    var v16: bool = undefined; _ = &v16;
    var v15: bool = undefined; _ = &v15;
    var v18: bool = undefined; _ = &v18;
    var v17: bool = undefined; _ = &v17;
    const v0: f32 = @as(f32, 2.0);
    const v1: f32 = @as(f32, 3.0);
    const v2: f64 = @as(f64, 2.0);
    const v3: f64 = @as(f64, 3.0);
    const v4: f32 = @as(f32, 3.1415927);
    const v5: f64 = @as(f64, 3.141592653589793);
    const v6: f32 = std.math.pow(@TypeOf(v0), v0, v1);
    const v7: bool = v6 == @as(f32, 8.0);
    if (v7) {
        v8 = std.math.pow(@TypeOf(v2), v2, v3);
        v9 = v8 == @as(f64, 8.0);
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
        v11 = v4 > @as(f32, 3.0);
        v12 = v11;
    } else {
        v12 = false;
    }
    if (v12) {
        v13 = v4 < @as(f32, 4.0);
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
        v15 = v5 > @as(f64, 3.0);
        v16 = v15;
    } else {
        v16 = false;
    }
    if (v16) {
        v17 = v5 < @as(f64, 4.0);
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
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
