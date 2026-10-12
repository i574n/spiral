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
fn method2(p0: i32, p1: []const u8) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: []const u8 = p1; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    v2 = v0 -% @as(i32, 1);
    v3 = v2 == @as(i32, 0);
    if (v3) {
        v4 = @as(i32, @intCast(v1.len));
        return v4;
    } else {
        return method1(v2, v1);
    }
}
fn method1(p0: i32, p1: []const u8) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: []const u8 = p1; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    v2 = v0 -% @as(i32, 1);
    v3 = v2 == @as(i32, 0);
    if (v3) {
        return @as(i32, 99);
    } else {
        return method2(v2, v1);
    }
}
fn method0(p0: i32, p1: []const u8) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: []const u8 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v5: i32 = undefined; _ = &v5;
    var v3: i32 = undefined; _ = &v3;
    var v6: i32 = undefined; _ = &v6;
    v2 = v0 == @as(i32, 0);
    if (v2) {
        v3 = @as(i32, @intCast(v1.len));
        v5 = v3;
    } else {
        v5 = method1(v0, v1);
    }
    v6 = v5 -% @as(i32, 2);
    return v6;
}
fn spiralMain() i32 {
    var v0: i32 = undefined; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v5: []const u8 = undefined; _ = &v5;
    var v3: []const u8 = undefined; _ = &v3;
    var v4: []const u8 = undefined; _ = &v4;
    v0 = @as(i32, 1000000);
    v1 = @rem(v0, @as(i32, 2));
    v2 = v1 == @as(i32, 0);
    if (v2) {
        v3 = "ok";
        v5 = v3;
    } else {
        v4 = "go";
        v5 = v4;
    }
    return method0(v0, v5);
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
