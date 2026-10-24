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
fn spiralPrint(s: []const u8) void {
    if (s.len > spiral_out_buffer.len - spiral_out_len) spiralFlush();
    if (s.len > spiral_out_buffer.len) {
        spiralWrite(1, s);
        return;
    }
    @memcpy(spiral_out_buffer[spiral_out_len..][0..s.len], s);
    spiral_out_len += s.len;
}
fn spiralFloatText(x: anytype) []u8 {
    var buffer: [std.fmt.float.bufferSize(.decimal, @TypeOf(x))]u8 = undefined;
    const text = std.fmt.float.render(&buffer, x, .{ .mode = .decimal }) catch unreachable;
    return spiral_gpa.dupe(u8, text) catch @panic("out of memory");
}
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    if (@typeInfo(T) == .float) return spiralPrint(spiralFloatText(x));
    const s = switch (@typeInfo(T)) {
        .bool => std.fmt.allocPrint(spiral_gpa, "{}", .{x}),
        else => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
    } catch @panic("out of memory");
    spiralPrint(s);
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
fn lcg_0(p0: u64, p1: u64, p2: i32, p3: u64) u64 {
    var v0: u64 = p0; _ = &v0;
    var v1: u64 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: u64 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    while (true) {
        v4 = v2 == @as(i32, 0);
        if (v4) {
            return v3;
        } else {
            v5 = v2 -% @as(i32, 1);
            v6 = v3 *% v0;
            v7 = v6 +% v1;
            v2 = v5;
            v3 = v7;
            continue;
        }
    }
}
fn spiralMain() i32 {
    var v24: i32 = undefined; _ = &v24;
    const v0: u64 = @as(u64, 42);
    const v1: u64 = @as(u64, 6364136223846793005);
    const v2: u64 = @as(u64, 1442695040888963407);
    const v3: i32 = @as(i32, 1000);
    const v4: u64 = lcg_0(v1, v2, v3, v0);
    _ = spiralPrint("lcg "); spiralPrintAny(v4); spiralPrint("\n");
    const v5: i64 = @as(i64, 9223372036854775807);
    const v6: i64 = @as(i64, -9223372036854775807);
    const v7: u64 = @as(u64, 18446744073709551615);
    const v8: i64 = v6 -% @as(i64, 1);
    const v9: u64 = v7 +% @as(u64, 2);
    _ = spiralPrint("max "); spiralPrintAny(v5); spiralPrint(" min "); spiralPrintAny(v8); spiralPrint(" wrap "); spiralPrintAny(v9); spiralPrint("\n");
    const v10: i64 = @as(i64, -9007199254740993);
    const v11: i64 = @as(i64, 7);
    const v12: i64 = @divTrunc(v10, v11);
    const v13: i64 = @rem(v10, v11);
    _ = spiralPrint("div "); spiralPrintAny(v12); spiralPrint(" mod "); spiralPrintAny(v13); spiralPrint("\n");
    const v14: i64 = std.math.shr(@TypeOf(v10), v10, @as(i32, 3));
    const v15: u64 = std.math.shr(@TypeOf(v4), v4, @as(i32, 60));
    _ = spiralPrint("shl "); spiralPrintAny(@as(i64, 4611686018427387904)); spiralPrint(" shr "); spiralPrintAny(v14); spiralPrint(" ushr "); spiralPrintAny(v15); spiralPrint("\n");
    const v16: u64 = v4 & @as(u64, 18446744069414584320);
    const v17: i64 = v10 | @as(i64, 255);
    const v18: u64 = v4 ^ v1;
    _ = spiralPrint("and "); spiralPrintAny(v16); spiralPrint(" or "); spiralPrintAny(v17); spiralPrint(" xor "); spiralPrintAny(v18); spiralPrint("\n");
    const v19: f64 = @as(f64, 1E+18);
    const v20: i64 = spiralConv(i64, v19);
    const v21: u32 = spiralConv(u32, v4);
    const v22: f64 = spiralConv(f64, v10);
    const v23: bool = v22 < @as(f64, 0.0);
    if (v23) {
        v24 = @as(i32, 1);
    } else {
        v24 = @as(i32, 0);
    }
    _ = spiralPrint("conv "); spiralPrintAny(v20); spiralPrint(" "); spiralPrintAny(v21); spiralPrint(" "); spiralPrintAny(v24); spiralPrint("\n");
    const v25: bool = v4 > v1;
    if (v25) {
        return @as(i32, 1);
    } else {
        return @as(i32, 0);
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
