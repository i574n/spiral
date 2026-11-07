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
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn spiralNewArray(comptime T: type, n: anytype) []T {
    const len: usize = @intCast(n);
    const a = spiral_gpa.alloc(T, len) catch @panic("out of memory");
    switch (@typeInfo(T)) {
        .int, .float, .bool => @memset(a, std.mem.zeroes(T)),
        else => if (T == []const u8) @memset(a, ""),
    }
    return a;
}
fn spiralMain() i32 {
    var v1: []i32 = undefined; _ = &v1;
    var v4: []bool = undefined; _ = &v4;
    var v15: i32 = undefined; _ = &v15;
    var v13: bool = undefined; _ = &v13;
    const v0: i32 = @as(i32, 5);
    v1 = spiralNewArray(i32, v0);
    v1[spiralIndex(v1.len, @as(i32, 0))] = @as(i32, 0);
    v1[spiralIndex(v1.len, @as(i32, 1))] = @as(i32, 1);
    v1[spiralIndex(v1.len, @as(i32, 2))] = @as(i32, 4);
    const v2: i32 = @as(i32, 3);
    v1[spiralIndex(v1.len, v2)] = @as(i32, 9);
    const v3: i32 = v2 +% @as(i32, 1);
    v1[spiralIndex(v1.len, v3)] = @as(i32, 16);
    v4 = spiralNewArray(bool, @as(i32, 3));
    v4[spiralIndex(v4.len, @as(i32, 0))] = false;
    v4[spiralIndex(v4.len, @as(i32, 1))] = true;
    v4[spiralIndex(v4.len, @as(i32, 2))] = false;
    const v5: i32 = v1[spiralIndex(v1.len, @as(i32, 1))];
    const v6: i32 = v1[spiralIndex(v1.len, @as(i32, 2))];
    const v7: i32 = v5 +% v6;
    const v8: i32 = v1[spiralIndex(v1.len, @as(i32, 3))];
    const v9: i32 = v7 +% v8;
    const v10: i32 = v1[spiralIndex(v1.len, @as(i32, 4))];
    const v11: i32 = v9 +% v10;
    const v12: bool = v4[spiralIndex(v4.len, @as(i32, 1))];
    if (v12) {
        v13 = v4[spiralIndex(v4.len, @as(i32, 0))];
        if (v13) {
            v15 = @as(i32, 0);
        } else {
            v15 = @as(i32, 100);
        }
    } else {
        v15 = @as(i32, 0);
    }
    const v16: i32 = v11 +% v15;
    const v17: i32 = @as(i32, @intCast(v1.len));
    const v18: i32 = v16 +% v17;
    return v18;
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
