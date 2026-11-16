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
const US0 = struct { tag: i32, c0_0: f64 = undefined, c1_0: f64 = undefined };
fn US0_Circle(a0: f64) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_Square(a0: f64) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn US0_Dot() US0 {
    return US0{ .tag = 2 };
}
fn spiralMain() i32 {
    var tmp9: [][]const u8 = undefined; _ = &tmp9;
    var v19: bool = undefined; _ = &v19;
    var v15: [][]const u8 = undefined; _ = &v15;
    var tmp15: [][]const u8 = undefined; _ = &tmp15;
    var v16: i32 = undefined; _ = &v16;
    var v17: []const u8 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v24: bool = undefined; _ = &v24;
    var v20: [][]const u8 = undefined; _ = &v20;
    var tmp21: [][]const u8 = undefined; _ = &tmp21;
    var v21: i32 = undefined; _ = &v21;
    var v22: []const u8 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    const v0: f64 = @as(f64, 1.5);
    const v1: US0 = US0_Circle(v0);
    const v2: f64 = @as(f64, 2.5);
    const v3: US0 = US0_Square(v2);
    const v4: US0 = US0_Dot();
    const v8: []const u8 = "Circle";
    const v9: []const u8 = "Square";
    const v10: []const u8 = "Dot";
    tmp9 = spiralNewArray([]const u8, 3);
    tmp9[0] = v8;
    tmp9[1] = v9;
    tmp9[2] = v10;
    const v11: [][]const u8 = tmp9;
    const v12: i32 = spiralConv(i32, v1.tag);
    const v13: []const u8 = v11[spiralIndex(v11.len, v12)];
    const v14: bool = std.mem.eql(u8, v13, "Circle");
    if (v14) {
        tmp15 = spiralNewArray([]const u8, 3);
        tmp15[0] = v8;
        tmp15[1] = v9;
        tmp15[2] = v10;
        v15 = tmp15;
        v16 = spiralConv(i32, v3.tag);
        v17 = v15[spiralIndex(v15.len, v16)];
        v18 = std.mem.eql(u8, v17, "Square");
        v19 = v18;
    } else {
        v19 = false;
    }
    if (v19) {
        tmp21 = spiralNewArray([]const u8, 3);
        tmp21[0] = v8;
        tmp21[1] = v9;
        tmp21[2] = v10;
        v20 = tmp21;
        v21 = spiralConv(i32, v4.tag);
        v22 = v20[spiralIndex(v20.len, v21)];
        v23 = std.mem.eql(u8, v22, "Dot");
        v24 = v23;
    } else {
        v24 = false;
    }
    if (v24) {
        return @as(i32, 42);
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
