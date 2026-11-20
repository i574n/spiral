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
    var v21: bool = undefined; _ = &v21;
    var v19: f64 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v23: bool = undefined; _ = &v23;
    var v22: bool = undefined; _ = &v22;
    var v25: bool = undefined; _ = &v25;
    var v24: bool = undefined; _ = &v24;
    var v27: bool = undefined; _ = &v27;
    var v26: bool = undefined; _ = &v26;
    var v29: bool = undefined; _ = &v29;
    var v28: bool = undefined; _ = &v28;
    const v0: f64 = @as(f64, 1.5);
    const v1: f64 = @as(f64, -2.0);
    const v2: f64 = v0 / v1;
    const v3: f64 = @as(f64, 1000000.0);
    const v4: f64 = v3 * v3;
    const v5: f64 = v4 * v3;
    const v6: f64 = v5 * @as(f64, 10000.0);
    const v7: f64 = v6 * v6;
    const v8: i32 = @as(i32, 3);
    const v9: f64 = spiralConv(f64, v8);
    const v10: f64 = @as(f64, 2.9);
    const v11: f64 = @as(f64, -1.9);
    const v12: i32 = spiralConv(i32, v10);
    const v13: i32 = spiralConv(i32, v11);
    const v14: f32 = @as(f32, 1.5);
    const v15: f64 = spiralConv(f64, v14);
    const v16: bool = v2 == @as(f64, -0.75);
    if (v16) {
        v17 = v7 > v6;
        v18 = v17;
    } else {
        v18 = false;
    }
    if (v18) {
        v19 = v7 * v6;
        v20 = v7 < v19;
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
        v22 = v9 == @as(f64, 3.0);
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        v24 = v12 == @as(i32, 2);
        v25 = v24;
    } else {
        v25 = false;
    }
    if (v25) {
        v26 = v13 == @as(i32, -1);
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
        v28 = v15 == @as(f64, 1.5);
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
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
