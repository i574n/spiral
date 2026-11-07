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
const US0 = struct { tag: i32, c1_0: f64 = undefined };
fn US0_DeepBlue() US0 {
    return US0{ .tag = 0 };
}
fn US0_LightGreen(a0: f64) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn US0_Red() US0 {
    return US0{ .tag = 2 };
}
fn spiralMain() i32 {
    var tmp8: [][]const u8 = undefined; _ = &tmp8;
    var v17: bool = undefined; _ = &v17;
    var v11: []const u8 = undefined; _ = &v11;
    var v12: []const u8 = undefined; _ = &v12;
    var v13: [][]const u8 = undefined; _ = &v13;
    var tmp16: [][]const u8 = undefined; _ = &tmp16;
    var v14: i32 = undefined; _ = &v14;
    var v15: []const u8 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v23: bool = undefined; _ = &v23;
    var v18: []const u8 = undefined; _ = &v18;
    var v19: []const u8 = undefined; _ = &v19;
    var v20: [][]const u8 = undefined; _ = &v20;
    var tmp24: [][]const u8 = undefined; _ = &tmp24;
    var v21: []const u8 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v28: bool = undefined; _ = &v28;
    var v24: [][]const u8 = undefined; _ = &v24;
    var tmp29: [][]const u8 = undefined; _ = &tmp29;
    var v25: i32 = undefined; _ = &v25;
    var v26: []const u8 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v35: bool = undefined; _ = &v35;
    var v29: []const u8 = undefined; _ = &v29;
    var v30: []const u8 = undefined; _ = &v30;
    var v31: []const u8 = undefined; _ = &v31;
    var v32: [][]const u8 = undefined; _ = &v32;
    var tmp38: [][]const u8 = undefined; _ = &tmp38;
    var v33: []const u8 = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    const v0: f64 = @as(f64, 0.5);
    const v1: US0 = US0_LightGreen(v0);
    const v2: US0 = US0_DeepBlue();
    const v3: US0 = US0_Red();
    const v4: []const u8 = "deep_blue";
    const v5: []const u8 = "light_green";
    const v6: []const u8 = "red";
    tmp8 = spiralNewArray([]const u8, 3);
    tmp8[0] = v4;
    tmp8[1] = v5;
    tmp8[2] = v6;
    const v7: [][]const u8 = tmp8;
    const v8: i32 = spiralConv(i32, v1.tag);
    const v9: []const u8 = v7[spiralIndex(v7.len, v8)];
    const v10: bool = std.mem.eql(u8, v9, "light_green");
    if (v10) {
        v11 = "deep-blue";
        v12 = "light-green";
        tmp16 = spiralNewArray([]const u8, 3);
        tmp16[0] = v11;
        tmp16[1] = v12;
        tmp16[2] = v6;
        v13 = tmp16;
        v14 = spiralConv(i32, v2.tag);
        v15 = v13[spiralIndex(v13.len, v14)];
        v16 = std.mem.eql(u8, v15, "deep-blue");
        v17 = v16;
    } else {
        v17 = false;
    }
    if (v17) {
        v18 = "deepblue";
        v19 = "lightgreen";
        tmp24 = spiralNewArray([]const u8, 3);
        tmp24[0] = v18;
        tmp24[1] = v19;
        tmp24[2] = v6;
        v20 = tmp24;
        v21 = v20[spiralIndex(v20.len, v8)];
        v22 = std.mem.eql(u8, v21, "lightgreen");
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        tmp29 = spiralNewArray([]const u8, 3);
        tmp29[0] = v4;
        tmp29[1] = v5;
        tmp29[2] = v6;
        v24 = tmp29;
        v25 = spiralConv(i32, v3.tag);
        v26 = v24[spiralIndex(v24.len, v25)];
        v27 = std.mem.eql(u8, v26, "red");
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28) {
        v29 = "DeepBlue";
        v30 = "LightGreen";
        v31 = "Red";
        tmp38 = spiralNewArray([]const u8, 3);
        tmp38[0] = v29;
        tmp38[1] = v30;
        tmp38[2] = v31;
        v32 = tmp38;
        v33 = v32[spiralIndex(v32.len, v8)];
        v34 = std.mem.eql(u8, v33, "LightGreen");
        v35 = v34;
    } else {
        v35 = false;
    }
    if (v35) {
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
