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
fn spiralConv(comptime T: type, x: anytype) T {
    const S = @TypeOf(x);
    if (@typeInfo(T) == .float) {
        if (@typeInfo(S) == .float) return @floatCast(x) else return @floatFromInt(x);
    }
    if (@typeInfo(S) == .float) return @intFromFloat(x);
    const U = @Int(.unsigned, @bitSizeOf(T));
    const wide: i128 = x;
    return @bitCast(@as(U, @truncate(@as(u128, @bitCast(wide)))));
}
fn spiralMain() i32 {
    var v18: bool = undefined; _ = &v18;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    var v22: bool = undefined; _ = &v22;
    var v21: bool = undefined; _ = &v21;
    var v24: bool = undefined; _ = &v24;
    var v23: bool = undefined; _ = &v23;
    var v26: bool = undefined; _ = &v26;
    var v25: bool = undefined; _ = &v25;
    var v28: bool = undefined; _ = &v28;
    var v27: bool = undefined; _ = &v27;
    var v30: bool = undefined; _ = &v30;
    var v29: bool = undefined; _ = &v29;
    const v0: i8 = @as(i8, 100);
    const v1: i8 = v0 +% v0;
    const v2: u8 = @as(u8, 200);
    const v3: u8 = @as(u8, 100);
    const v4: u8 = v2 +% v3;
    const v5: i8 = @as(i8, -8);
    const v6: i8 = std.math.shr(@TypeOf(v5), v5, @as(i32, 1));
    const v7: u8 = std.math.shr(@TypeOf(v2), v2, @as(i32, 1));
    const v8: i16 = @as(i16, 20000);
    const v9: i16 = v8 +% v8;
    const v10: u16 = @as(u16, 40000);
    const v11: u16 = v10 +% v10;
    const v12: i32 = @as(i32, 7);
    const v13: i8 = spiralConv(i8, v12);
    const v14: i8 = @as(i8, 9);
    const v15: i32 = spiralConv(i32, v14);
    const v16: bool = v1 == @as(i8, -56);
    if (v16) {
        v17 = v4 == @as(u8, 44);
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
        v19 = v6 == @as(i8, -4);
        v20 = v19;
    } else {
        v20 = false;
    }
    if (v20) {
        v21 = v7 == @as(u8, 100);
        v22 = v21;
    } else {
        v22 = false;
    }
    if (v22) {
        v23 = v9 == @as(i16, -25536);
        v24 = v23;
    } else {
        v24 = false;
    }
    if (v24) {
        v25 = v11 == @as(u16, 14464);
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        v27 = v13 == @as(i8, 7);
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28) {
        v29 = v15 == @as(i32, 9);
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30) {
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
