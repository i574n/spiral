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
const Tuple0 = struct { f0: i32, f1: u32, f2: f32 };
fn method1(p0: i32, p1: u32, p2: f32) Tuple0 {
    var v0: i32 = p0; _ = &v0;
    var v1: u32 = p1; _ = &v1;
    var v2: f32 = p2; _ = &v2;
    return Tuple0{ .f0 = v0, .f1 = v1, .f2 = v2 };
}
fn method0(p0: i32, p1: u32, p2: f32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: u32 = p1; _ = &v1;
    var v2: f32 = p2; _ = &v2;
    var tmp3: Tuple0 = undefined; _ = &tmp3;
    var v8: bool = undefined; _ = &v8;
    var v7: bool = undefined; _ = &v7;
    var v10: bool = undefined; _ = &v10;
    var v9: bool = undefined; _ = &v9;
    tmp3 = method1(v0, v1, v2);
    const v3: i32 = tmp3.f0;
    const v4: u32 = tmp3.f1;
    const v5: f32 = tmp3.f2;
    const v6: bool = v3 == @as(i32, 2);
    if (v6) {
        v7 = v4 == @as(u32, 3);
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        v9 = v5 == @as(f32, 1.5);
        v10 = v9;
    } else {
        v10 = false;
    }
    if (v10) {
        return @as(i32, 0);
    } else {
        return @as(i32, 1);
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 2);
    const v1: u32 = @as(u32, 3);
    const v2: f32 = @as(f32, 1.5);
    return method0(v0, v1, v2);
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
