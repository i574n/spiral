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
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    const s = switch (@typeInfo(T)) {
        .float => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
        .bool => std.fmt.allocPrint(spiral_gpa, "{}", .{x}),
        else => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
    } catch @panic("out of memory");
    spiralPrint(s);
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
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
fn lcg_0(p0: u64, p1: u64, p2: i32, p3: u64) u64 {
    var v0: u64 = p0; _ = &v0;
    var v1: u64 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: u64 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var tmp4: u64 = undefined; _ = &tmp4;
    var tmp5: u64 = undefined; _ = &tmp5;
    var tmp6: i32 = undefined; _ = &tmp6;
    var tmp7: u64 = undefined; _ = &tmp7;
    while (true) {
        v4 = v2 == @as(i32, 0);
        if (v4) {
            return v3;
        } else {
            v5 = v2 -% @as(i32, 1);
            v6 = v3 *% v0;
            v7 = v6 +% v1;
            tmp4 = v0;
            tmp5 = v1;
            tmp6 = v5;
            tmp7 = v7;
            v0 = tmp4;
            v1 = tmp5;
            v2 = tmp6;
            v3 = tmp7;
            continue;
        }
    }
}
fn spiralMain() i32 {
    var v0: u64 = undefined; _ = &v0;
    var v1: u64 = undefined; _ = &v1;
    var v2: u64 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: u64 = undefined; _ = &v4;
    var v5: i64 = undefined; _ = &v5;
    var v6: i64 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var v8: i64 = undefined; _ = &v8;
    var v9: u64 = undefined; _ = &v9;
    var v10: i64 = undefined; _ = &v10;
    var v11: i64 = undefined; _ = &v11;
    var v12: i64 = undefined; _ = &v12;
    var v13: i64 = undefined; _ = &v13;
    var v14: i64 = undefined; _ = &v14;
    var v15: u64 = undefined; _ = &v15;
    var v16: u64 = undefined; _ = &v16;
    var v17: i64 = undefined; _ = &v17;
    var v18: u64 = undefined; _ = &v18;
    var v19: f64 = undefined; _ = &v19;
    var v20: i64 = undefined; _ = &v20;
    var v21: u32 = undefined; _ = &v21;
    var v22: f64 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    v0 = @as(u64, 42);
    v1 = @as(u64, 6364136223846793005);
    v2 = @as(u64, 1442695040888963407);
    v3 = @as(i32, 1000);
    v4 = lcg_0(v1, v2, v3, v0);
    _ = spiralPrint("lcg "); spiralPrintAny(v4); spiralPrint("\n");
    v5 = @as(i64, 9223372036854775807);
    v6 = @as(i64, -9223372036854775807);
    v7 = @as(u64, 18446744073709551615);
    v8 = v6 -% @as(i64, 1);
    v9 = v7 +% @as(u64, 2);
    _ = spiralPrint("max "); spiralPrintAny(v5); spiralPrint(" min "); spiralPrintAny(v8); spiralPrint(" wrap "); spiralPrintAny(v9); spiralPrint("\n");
    v10 = @as(i64, -9007199254740993);
    v11 = @as(i64, 7);
    v12 = @divTrunc(v10, v11);
    v13 = @rem(v10, v11);
    _ = spiralPrint("div "); spiralPrintAny(v12); spiralPrint(" mod "); spiralPrintAny(v13); spiralPrint("\n");
    v14 = std.math.shr(@TypeOf(v10), v10, @as(i32, 3));
    v15 = std.math.shr(@TypeOf(v4), v4, @as(i32, 60));
    _ = spiralPrint("shl "); spiralPrintAny(@as(i64, 4611686018427387904)); spiralPrint(" shr "); spiralPrintAny(v14); spiralPrint(" ushr "); spiralPrintAny(v15); spiralPrint("\n");
    v16 = v4 & @as(u64, 18446744069414584320);
    v17 = v10 | @as(i64, 255);
    v18 = v4 ^ v1;
    _ = spiralPrint("and "); spiralPrintAny(v16); spiralPrint(" or "); spiralPrintAny(v17); spiralPrint(" xor "); spiralPrintAny(v18); spiralPrint("\n");
    v19 = @as(f64, 1E+18);
    v20 = spiralConv(i64, v19);
    v21 = spiralConv(u32, v4);
    v22 = spiralConv(f64, v10);
    v23 = v22 < @as(f64, 0.0);
    if (v23) {
        v24 = @as(i32, 1);
    } else {
        v24 = @as(i32, 0);
    }
    _ = spiralPrint("conv "); spiralPrintAny(v20); spiralPrint(" "); spiralPrintAny(v21); spiralPrint(" "); spiralPrintAny(v24); spiralPrint("\n");
    v25 = v4 > v1;
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
pub fn main(init: std.process.Init.Minimal) void {
    spiral_gpa = spiral_arena.allocator();
    spiral_environ = init.environ;
    const thread = std.Thread.spawn(.{ .stack_size = 1 << 30 }, spiralMainThread, .{}) catch @panic("spiral: could not start the main thread");
    thread.join();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(spiral_exit_code))));
}
