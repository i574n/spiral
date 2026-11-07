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
fn spiralStringSlice(s: []const u8, from: i64, upto: i64) []const u8 {
    const len: i64 = @intCast(s.len);
    if (from < 0 or from > len or upto < from - 1 or upto >= len) std.process.exit(3);
    if (upto < from) return "";
    const a: usize = @intCast(from);
    const b: usize = @intCast(upto + 1);
    if ((s[a] & 0xC0) == 0x80 or (b < s.len and (s[b] & 0xC0) == 0x80)) std.process.exit(3);
    return s[a..b];
}
fn spiralIndex(len: usize, i: anytype) usize {
    if (i < 0 or i >= len) std.process.exit(3);
    return @intCast(i);
}
fn spiralMain() i32 {
    var v16: bool = undefined; _ = &v16;
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
    const v0: []const u8 = "\xc3\xa9";
    const v1: i32 = @as(i32, @intCast(v0.len));
    const v2: u8 = v0[spiralIndex(v0.len, @as(i32, 0))];
    const v3: u8 = v0[spiralIndex(v0.len, @as(i32, 1))];
    const v4: []const u8 = "x";
    const v5: []const u8 = spiralConcat(v0, v4);
    const v6: i32 = @as(i32, @intCast(v5.len));
    const v7: []const u8 = "ab";
    const v8: u8 = v7[spiralIndex(v7.len, @as(i32, 0))];
    const v9: []const u8 = spiralStringSlice(v7, @as(i64, @as(i32, 0)), @as(i64, @as(i32, 0)));
    const v10: i32 = @as(i32, @intCast(v9.len));
    const v11: []const u8 = spiralStringSlice(v7, @as(i64, @as(i32, 1)), @as(i64, @as(i32, 0)));
    const v12: i32 = @as(i32, @intCast(v11.len));
    const v13: []const u8 = spiralStringSlice(v0, @as(i64, @as(i32, 0)), @as(i64, @as(i32, 1)));
    const v14: i32 = @as(i32, @intCast(v13.len));
    const v15: bool = v2 == v3;
    if (v15) {
        return @as(i32, 1);
    } else {
        v16 = v1 == @as(i32, 2);
        if (v16) {
            v17 = v8 == @as(u8, 97);
            v18 = v17;
        } else {
            v18 = false;
        }
        if (v18) {
            v19 = v6 == @as(i32, 3);
            v20 = v19;
        } else {
            v20 = false;
        }
        if (v20) {
            v21 = v10 == @as(i32, 1);
            v22 = v21;
        } else {
            v22 = false;
        }
        if (v22) {
            v23 = v12 == @as(i32, 0);
            v24 = v23;
        } else {
            v24 = false;
        }
        if (v24) {
            v25 = v14 == @as(i32, 2);
            v26 = v25;
        } else {
            v26 = false;
        }
        if (v26) {
            return @as(i32, 0);
        } else {
            return @as(i32, 1);
        }
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
