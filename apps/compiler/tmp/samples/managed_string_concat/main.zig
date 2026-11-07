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
fn spiralConcat(a: []const u8, b: []const u8) []const u8 {
    return std.mem.concat(spiral_gpa, u8, &.{ a, b }) catch @panic("out of memory");
}
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn choose_left_0(p0: bool) []const u8 {
    var v0: bool = p0; _ = &v0;
    var v1: []const u8 = undefined; _ = &v1;
    var v2: []const u8 = undefined; _ = &v2;
    if (v0) {
        v1 = "spi";
        return v1;
    } else {
        v2 = "bad";
        return v2;
    }
}
fn choose_right_1(p0: bool) []const u8 {
    var v0: bool = p0; _ = &v0;
    var v1: []const u8 = undefined; _ = &v1;
    var v2: []const u8 = undefined; _ = &v2;
    if (v0) {
        v1 = "bad";
        return v1;
    } else {
        v2 = "ral";
        return v2;
    }
}
fn spiralMain() i32 {
    var v7: u8 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v9: u8 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    const v0: bool = true;
    const v1: []const u8 = choose_left_0(v0);
    const v2: bool = false;
    const v3: []const u8 = choose_right_1(v2);
    const v4: []const u8 = spiralConcat(v1, v3);
    const v5: i32 = @as(i32, @intCast(v4.len));
    const v6: bool = v5 == @as(i32, 6);
    if (v6) {
        v7 = v4[spiralIndex(v4.len, @as(i32, 0))];
        v8 = v7 == @as(u8, 115);
        if (v8) {
            v9 = v4[spiralIndex(v4.len, @as(i32, 5))];
            v10 = v9 == @as(u8, 108);
            if (v10) {
                return @as(i32, 0);
            } else {
                return @as(i32, 1);
            }
        } else {
            return @as(i32, 2);
        }
    } else {
        return @as(i32, 3);
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
