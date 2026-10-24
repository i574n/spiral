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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32, c1_0: []const u8 = undefined, c1_1: []i32 = undefined };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) US0 };
const ClosureEnv0 = struct { pad: u8 = 0 };
fn US0_Empty() US0 {
    return US0{ .tag = 0 };
}
fn US0_Item(a0: []const u8, a1: []i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 };
}
fn closure0(ctx: *anyopaque, p0: i32) US0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: i32 = p0; _ = &v0;
    var v3: []i32 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: []const u8 = undefined; _ = &v5;
    const v1: bool = v0 == @as(i32, 0);
    if (v1) {
        return US0_Empty();
    } else {
        v3 = spiralNewArray(i32, @as(i32, 2));
        v3[spiralIndex(v3.len, @as(i32, 0))] = v0;
        v4 = v0 +% @as(i32, 1);
        v3[spiralIndex(v3.len, @as(i32, 1))] = v4;
        v5 = "hi";
        return US0_Item(v5, v3);
    }
}
fn closureCreate0() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ }), .call = &closure0 };
}
fn method0(p0: Fun0) US0 {
    var v0: Fun0 = p0; _ = &v0;
    return v0.call(v0.ctx, @as(i32, 0));
}
fn method1(p0: Fun0) US0 {
    var v0: Fun0 = p0; _ = &v0;
    return v0.call(v0.ctx, @as(i32, 4));
}
fn spiralMain() i32 {
    var v12: i32 = undefined; _ = &v12;
    var v2: []const u8 = undefined; _ = &v2;
    var v3: []i32 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: i32 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v24: i32 = undefined; _ = &v24;
    var v14: []const u8 = undefined; _ = &v14;
    var v15: []i32 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    const v0: Fun0 = closureCreate0();
    const v1: US0 = method0(v0);
    switch (v1.tag) {
        0 => {
            v12 = @as(i32, 3);
        },
        1 => {
            v2 = v1.c1_0;
            v3 = v1.c1_1;
            v4 = @as(i32, @intCast(v2.len));
            v5 = @as(i32, @intCast(v3.len));
            v6 = v4 +% v5;
            v7 = v3[spiralIndex(v3.len, @as(i32, 0))];
            v8 = v6 +% v7;
            v9 = v3[spiralIndex(v3.len, @as(i32, 1))];
            v10 = v8 +% v9;
            v12 = v10;
        },
        else => unreachable,
    }
    const v13: US0 = method1(v0);
    switch (v13.tag) {
        0 => {
            v24 = @as(i32, 3);
        },
        1 => {
            v14 = v13.c1_0;
            v15 = v13.c1_1;
            v16 = @as(i32, @intCast(v14.len));
            v17 = @as(i32, @intCast(v15.len));
            v18 = v16 +% v17;
            v19 = v15[spiralIndex(v15.len, @as(i32, 0))];
            v20 = v18 +% v19;
            v21 = v15[spiralIndex(v15.len, @as(i32, 1))];
            v22 = v20 +% v21;
            v24 = v22;
        },
        else => unreachable,
    }
    const v25: i32 = v12 +% v24;
    const v26: i32 = v25 +% @as(i32, 26);
    return v26;
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
