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
const US0 = struct { tag: i32, c0_0: i32 = undefined };
fn US0_Some(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_None() US0 {
    return US0{ .tag = 1 };
}
fn spiralMain() i32 {
    var v0: []const u8 = undefined; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: []const u8 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: []const u8 = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: []const u8 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v8: i64 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v13: bool = undefined; _ = &v13;
    var v10: bool = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v16: US0 = undefined; _ = &v16;
    var v18: []const u8 = undefined; _ = &v18;
    var v17: i32 = undefined; _ = &v17;
    var v19: []const u8 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: i64 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v26: bool = undefined; _ = &v26;
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v29: US0 = undefined; _ = &v29;
    var v31: []const u8 = undefined; _ = &v31;
    var v30: i32 = undefined; _ = &v30;
    var v32: []const u8 = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v34: i64 = undefined; _ = &v34;
    var v35: i32 = undefined; _ = &v35;
    var v39: bool = undefined; _ = &v39;
    var v36: bool = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v42: US0 = undefined; _ = &v42;
    var v44: []const u8 = undefined; _ = &v44;
    var v43: i32 = undefined; _ = &v43;
    var v45: []const u8 = undefined; _ = &v45;
    var v46: bool = undefined; _ = &v46;
    var v47: i64 = undefined; _ = &v47;
    var v48: i32 = undefined; _ = &v48;
    var v52: bool = undefined; _ = &v52;
    var v49: bool = undefined; _ = &v49;
    var v50: bool = undefined; _ = &v50;
    var v55: US0 = undefined; _ = &v55;
    var v57: []const u8 = undefined; _ = &v57;
    var v56: i32 = undefined; _ = &v56;
    v0 = "ff";
    v1 = (std.fmt.parseInt(i32, std.mem.trim(u8, v0, " \t\r\n"), @intCast(@as(i32, 16))) catch 0);
    { spiralPrintAny(v1); spiralPrint(&[_]u8{10}); }
    v2 = "1011";
    v3 = (std.fmt.parseInt(i32, std.mem.trim(u8, v2, " \t\r\n"), @intCast(@as(i32, 2))) catch 0);
    { spiralPrintAny(v3); spiralPrint(&[_]u8{10}); }
    v4 = "-42";
    v5 = (std.fmt.parseInt(i32, std.mem.trim(u8, v4, " \t\r\n"), @intCast(@as(i32, 10))) catch 0);
    { spiralPrintAny(v5); spiralPrint(&[_]u8{10}); }
    v6 = " 123 ";
    v7 = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v6, " \t\r\n"), 10)) |_| true else |_| false);
    v8 = (std.fmt.parseInt(i64, std.mem.trim(u8, v6, " \t\r\n"), 10) catch 0);
    v9 = spiralConv(i32, v8);
    if (v7) {
        v10 = v8 >= @as(i64, -2147483648);
        if (v10) {
            v11 = v8 <= @as(i64, 2147483647);
            v13 = v11;
        } else {
            v13 = false;
        }
    } else {
        v13 = false;
    }
    if (v13) {
        v16 = US0_Some(v9);
    } else {
        v16 = US0_None();
    }
    switch (v16.tag) {
        1 => {
            v18 = "none";
            { spiralPrintAny(v18); spiralPrint(&[_]u8{10}); }
        },
        0 => {
            v17 = v16.c0_0;
            { spiralPrintAny(v17); spiralPrint(&[_]u8{10}); }
        },
        else => unreachable,
    }
    v19 = "12x";
    v20 = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v19, " \t\r\n"), 10)) |_| true else |_| false);
    v21 = (std.fmt.parseInt(i64, std.mem.trim(u8, v19, " \t\r\n"), 10) catch 0);
    v22 = spiralConv(i32, v21);
    if (v20) {
        v23 = v21 >= @as(i64, -2147483648);
        if (v23) {
            v24 = v21 <= @as(i64, 2147483647);
            v26 = v24;
        } else {
            v26 = false;
        }
    } else {
        v26 = false;
    }
    if (v26) {
        v29 = US0_Some(v22);
    } else {
        v29 = US0_None();
    }
    switch (v29.tag) {
        1 => {
            v31 = "none";
            { spiralPrintAny(v31); spiralPrint(&[_]u8{10}); }
        },
        0 => {
            v30 = v29.c0_0;
            { spiralPrintAny(v30); spiralPrint(&[_]u8{10}); }
        },
        else => unreachable,
    }
    v32 = "";
    v33 = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v32, " \t\r\n"), 10)) |_| true else |_| false);
    v34 = (std.fmt.parseInt(i64, std.mem.trim(u8, v32, " \t\r\n"), 10) catch 0);
    v35 = spiralConv(i32, v34);
    if (v33) {
        v36 = v34 >= @as(i64, -2147483648);
        if (v36) {
            v37 = v34 <= @as(i64, 2147483647);
            v39 = v37;
        } else {
            v39 = false;
        }
    } else {
        v39 = false;
    }
    if (v39) {
        v42 = US0_Some(v35);
    } else {
        v42 = US0_None();
    }
    switch (v42.tag) {
        1 => {
            v44 = "none";
            { spiralPrintAny(v44); spiralPrint(&[_]u8{10}); }
        },
        0 => {
            v43 = v42.c0_0;
            { spiralPrintAny(v43); spiralPrint(&[_]u8{10}); }
        },
        else => unreachable,
    }
    v45 = "+7";
    v46 = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v45, " \t\r\n"), 10)) |_| true else |_| false);
    v47 = (std.fmt.parseInt(i64, std.mem.trim(u8, v45, " \t\r\n"), 10) catch 0);
    v48 = spiralConv(i32, v47);
    if (v46) {
        v49 = v47 >= @as(i64, -2147483648);
        if (v49) {
            v50 = v47 <= @as(i64, 2147483647);
            v52 = v50;
        } else {
            v52 = false;
        }
    } else {
        v52 = false;
    }
    if (v52) {
        v55 = US0_Some(v48);
    } else {
        v55 = US0_None();
    }
    switch (v55.tag) {
        1 => {
            v57 = "none";
            { spiralPrintAny(v57); spiralPrint(&[_]u8{10}); }
        },
        0 => {
            v56 = v55.c0_0;
            { spiralPrintAny(v56); spiralPrint(&[_]u8{10}); }
        },
        else => unreachable,
    }
    return @as(i32, 0);
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
