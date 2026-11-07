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
    var v6: bool = undefined; _ = &v6;
    var v8: bool = undefined; _ = &v8;
    var v7: bool = undefined; _ = &v7;
    var v10: bool = undefined; _ = &v10;
    var v9: bool = undefined; _ = &v9;
    var v12: bool = undefined; _ = &v12;
    var v11: bool = undefined; _ = &v11;
    var v14: bool = undefined; _ = &v14;
    var v13: bool = undefined; _ = &v13;
    var v16: bool = undefined; _ = &v16;
    var v15: bool = undefined; _ = &v15;
    var v18: bool = undefined; _ = &v18;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    const v0: []const u8 = "a";
    const v1: []const u8 = "b";
    const v2: []const u8 = "\xc3\xa9";
    const v3: []const u8 = "\xc3\xa9x";
    const v4: []const u8 = "";
    const v5: bool = std.mem.lessThan(u8, v0, v0);
    if (v5) {
        return @as(i32, 1);
    } else {
        v6 = std.mem.lessThan(u8, v0, v1);
        if (v6) {
            v7 = std.mem.lessThan(u8, v1, v2);
            v8 = v7;
        } else {
            v8 = false;
        }
        if (v8) {
            v9 = std.mem.lessThan(u8, v2, v3);
            v10 = v9;
        } else {
            v10 = false;
        }
        if (v10) {
            v11 = std.mem.lessThan(u8, v4, v0);
            v12 = v11;
        } else {
            v12 = false;
        }
        if (v12) {
            v13 = !std.mem.lessThan(u8, v0, v0);
            v14 = v13;
        } else {
            v14 = false;
        }
        if (v14) {
            v15 = !std.mem.lessThan(u8, v0, v0);
            v16 = v15;
        } else {
            v16 = false;
        }
        if (v16) {
            v17 = std.mem.lessThan(u8, v2, v3);
            v18 = v17;
        } else {
            v18 = false;
        }
        if (v18) {
            v19 = !std.mem.lessThan(u8, v1, v0);
            v20 = v19;
        } else {
            v20 = false;
        }
        if (v20) {
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
