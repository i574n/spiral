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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32, c1_0: i32 = undefined, c2_0: bool = undefined };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) i32 };
const ClosureEnv0 = struct { v0: US0, pad: u8 = 0 };
fn US0_Idle() US0 {
    return US0{ .tag = 0 };
}
fn US0_Hit(a0: i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn US0_Flag(a0: bool) US0 {
    return US0{ .tag = 2, .c2_0 = a0 };
}
fn score_0(p0: US0) i32 {
    var v0: US0 = p0; _ = &v0;
    var v2: bool = undefined; _ = &v2;
    var v1: i32 = undefined; _ = &v1;
    switch (v0.tag) {
        2 => {
            v2 = v0.c2_0;
            if (v2) {
                return @as(i32, 11);
            } else {
                return @as(i32, 5);
            }
        },
        1 => {
            v1 = v0.c1_0;
            return v1;
        },
        0 => {
            return @as(i32, 3);
        },
        else => unreachable,
    }
}
fn closure0(ctx: *anyopaque, p1: i32) i32 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: US0 = env.v0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: i32 = score_0(v0);
    const v3: i32 = v2 +% v1;
    return v3;
}
fn closureCreate0(p0: US0) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, }), .call = &closure0 };
}
fn method1(p0: Fun0) i32 {
    var v0: Fun0 = p0; _ = &v0;
    return v0.call(v0.ctx, @as(i32, 31));
}
fn spiralMain() i32 {
    var v7: US0 = undefined; _ = &v7;
    var v3: bool = undefined; _ = &v3;
    const v0: i32 = @as(i32, 2);
    const v1: bool = v0 == @as(i32, 0);
    if (v1) {
        v7 = US0_Idle();
    } else {
        v3 = v0 == @as(i32, 1);
        if (v3) {
            v7 = US0_Hit(@as(i32, 7));
        } else {
            v7 = US0_Flag(true);
        }
    }
    const v8: Fun0 = closureCreate0(v7);
    return method1(v8);
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
