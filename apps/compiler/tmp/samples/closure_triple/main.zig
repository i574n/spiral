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
const Tuple0 = struct { f0: i32, f1: []const u8, f2: bool };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) Tuple0 };
const ClosureEnv0 = struct { v0: i32, v1: []const u8, v2: bool, pad: u8 = 0 };
fn f_c0(ctx: *anyopaque, p3: i32) Tuple0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: i32 = env.v0; _ = &v0;
    var v1: []const u8 = env.v1; _ = &v1;
    var v2: bool = env.v2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v5: []const u8 = undefined; _ = &v5;
    const v4: bool = v3 == @as(i32, 0);
    if (v4) {
        v5 = "no";
        return Tuple0{ .f0 = @as(i32, 0), .f1 = v5, .f2 = false };
    } else {
        return Tuple0{ .f0 = v0, .f1 = v1, .f2 = v2 };
    }
}
fn closureCreate0(p0: i32, p1: []const u8, p2: bool) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, .v1 = p1, .v2 = p2, }), .call = &f_c0 };
}
fn spiralMain() i32 {
    var tmp7: Tuple0 = undefined; _ = &tmp7;
    var v9: bool = undefined; _ = &v9;
    var v8: bool = undefined; _ = &v8;
    const v0: i32 = @as(i32, 7);
    const v1: []const u8 = "hi";
    const v2: bool = true;
    const v3: Fun0 = closureCreate0(v0, v1, v2);
    tmp7 = v3.call(v3.ctx, @as(i32, 1));
    const v4: i32 = tmp7.f0;
    const v5: []const u8 = tmp7.f1;
    const v6: bool = tmp7.f2;
    const v7: bool = v4 == @as(i32, 7);
    if (v7) {
        v8 = std.mem.eql(u8, v5, "hi");
        v9 = v8;
    } else {
        v9 = false;
    }
    const v10: bool = (v9 and v6);
    if (v10) {
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
