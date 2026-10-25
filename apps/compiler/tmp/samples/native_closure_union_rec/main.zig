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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque) *UH0 };
const UH0 = struct { tag: i32, c0_0: u64 = undefined, c0_1: Fun0 = undefined };
const ClosureEnv0 = struct { v0: u64, pad: u8 = 0 };
fn UH0_Cons(a0: u64, a1: Fun0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH0_Nil() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 1 };
    };
    return &shared.value;
}
fn closure0(ctx: *anyopaque) *UH0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: u64 = env.v0; _ = &v0;
    const v1: u64 = v0 -% @as(u64, 1);
    return build_0(v1);
}
fn closureCreate0(p0: u64) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, }), .call = &closure0 };
}
fn build_0(p0: u64) *UH0 {
    var v0: u64 = p0; _ = &v0;
    var v3: Fun0 = undefined; _ = &v3;
    const v1: bool = v0 == @as(u64, 0);
    if (v1) {
        return UH0_Nil();
    } else {
        v3 = closureCreate0(v0);
        return UH0_Cons(v0, v3);
    }
}
fn sum_1(p0: *UH0, p1: u64) u64 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: u64 = p1; _ = &v1;
    var v2: u64 = undefined; _ = &v2;
    var v3: Fun0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: u64 = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            0 => {
                v2 = v0.c0_0;
                v3 = v0.c0_1;
                v4 = v3.call(v3.ctx);
                v5 = v1 +% v2;
                v0 = v4;
                v1 = v5;
                continue;
            },
            1 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn spiralMain() i32 {
    const v0: u64 = @as(u64, 10);
    const v1: *UH0 = build_0(v0);
    const v2: u64 = @as(u64, 0);
    const v3: u64 = sum_1(v1, v2);
    const v4: i32 = @as(i32, 5);
    const v5: i32 = spiralConv(i32, v3);
    const v6: i32 = v4 *% @as(i32, 2);
    const v7: i32 = v4 +% v6;
    const v8: i32 = v5 +% v7;
    return v8;
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
