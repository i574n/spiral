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
fn spiralMain() i32 {
    var v0: u8 = undefined; _ = &v0;
    var v1: u8 = undefined; _ = &v1;
    var v2: u32 = undefined; _ = &v2;
    var v3: u64 = undefined; _ = &v3;
    var v4: i8 = undefined; _ = &v4;
    var v5: i8 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: i64 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v10: i64 = undefined; _ = &v10;
    var v11: u8 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: u32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v15: u32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: u64 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v19: u64 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: u64 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: i8 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: i64 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: u32 = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: i32 = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    v0 = @as(u8, 250);
    v1 = @as(u8, 10);
    v2 = @as(u32, 4294967295);
    v3 = @as(u64, 18446744073709551615);
    v4 = @as(i8, 127);
    v5 = @as(i8, 1);
    v6 = @as(i32, 7);
    v7 = @as(i32, 2);
    v8 = @as(i64, 9223372036854775807);
    v9 = -%v6;
    v10 = -%v8;
    v11 = v0 +% v1;
    v12 = v11 == @as(u8, 4);
    if (v12) {
        v13 = v2 +% @as(u32, 1);
        v14 = v13 == @as(u32, 0);
        if (v14) {
            v15 = v2 *% v2;
            v16 = v15 == @as(u32, 1);
            if (v16) {
                v17 = v3 +% @as(u64, 1);
                v18 = v17 == @as(u64, 0);
                if (v18) {
                    v19 = v3 *% v3;
                    v20 = v19 == @as(u64, 1);
                    if (v20) {
                        v21 = @divTrunc(v3, @as(u64, 3));
                        v22 = v21 == @as(u64, 6148914691236517205);
                        if (v22) {
                            v23 = v4 +% v5;
                            v24 = v23 < @as(i8, 0);
                            if (v24) {
                                v25 = @divTrunc(v9, v7);
                                v26 = v25 == @as(i32, -3);
                                if (v26) {
                                    v27 = @rem(v9, v7);
                                    v28 = v27 == @as(i32, -1);
                                    if (v28) {
                                        v29 = @rem(v10, @as(i64, 10));
                                        v30 = v29 == @as(i64, -7);
                                        if (v30) {
                                            v31 = std.math.shr(@TypeOf(v2), v2, @as(i32, 28));
                                            v32 = v31 == @as(u32, 15);
                                            if (v32) {
                                                v33 = std.math.shr(@TypeOf(v9), v9, @as(i32, 1));
                                                v34 = v33 == @as(i32, -4);
                                                if (v34) {
                                                    return @as(i32, 0);
                                                } else {
                                                    return @as(i32, 12);
                                                }
                                            } else {
                                                return @as(i32, 11);
                                            }
                                        } else {
                                            return @as(i32, 10);
                                        }
                                    } else {
                                        return @as(i32, 9);
                                    }
                                } else {
                                    return @as(i32, 8);
                                }
                            } else {
                                return @as(i32, 7);
                            }
                        } else {
                            return @as(i32, 6);
                        }
                    } else {
                        return @as(i32, 5);
                    }
                } else {
                    return @as(i32, 4);
                }
            } else {
                return @as(i32, 3);
            }
        } else {
            return @as(i32, 2);
        }
    } else {
        return @as(i32, 1);
    }
}
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
