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
    var v0: i8 = undefined; _ = &v0;
    var v1: i8 = undefined; _ = &v1;
    var v2: i8 = undefined; _ = &v2;
    var v3: i8 = undefined; _ = &v3;
    var v4: i8 = undefined; _ = &v4;
    var v5: i8 = undefined; _ = &v5;
    var v6: i8 = undefined; _ = &v6;
    var v7: i8 = undefined; _ = &v7;
    var v8: i8 = undefined; _ = &v8;
    var v9: u8 = undefined; _ = &v9;
    var v10: u8 = undefined; _ = &v10;
    var v11: u8 = undefined; _ = &v11;
    var v12: u8 = undefined; _ = &v12;
    var v13: u8 = undefined; _ = &v13;
    var v14: u8 = undefined; _ = &v14;
    var v15: u8 = undefined; _ = &v15;
    var v16: u8 = undefined; _ = &v16;
    var v17: u8 = undefined; _ = &v17;
    var v18: i16 = undefined; _ = &v18;
    var v19: i16 = undefined; _ = &v19;
    var v20: i16 = undefined; _ = &v20;
    var v21: i16 = undefined; _ = &v21;
    var v22: i16 = undefined; _ = &v22;
    var v23: u16 = undefined; _ = &v23;
    var v24: u16 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v27: bool = undefined; _ = &v27;
    var v26: bool = undefined; _ = &v26;
    var v29: bool = undefined; _ = &v29;
    var v28: bool = undefined; _ = &v28;
    var v31: bool = undefined; _ = &v31;
    var v30: bool = undefined; _ = &v30;
    var v33: bool = undefined; _ = &v33;
    var v32: bool = undefined; _ = &v32;
    var v35: bool = undefined; _ = &v35;
    var v34: bool = undefined; _ = &v34;
    var v37: bool = undefined; _ = &v37;
    var v36: bool = undefined; _ = &v36;
    var v39: bool = undefined; _ = &v39;
    var v38: bool = undefined; _ = &v38;
    var v41: bool = undefined; _ = &v41;
    var v40: bool = undefined; _ = &v40;
    var v43: bool = undefined; _ = &v43;
    var v42: bool = undefined; _ = &v42;
    var v45: bool = undefined; _ = &v45;
    var v44: bool = undefined; _ = &v44;
    var v47: bool = undefined; _ = &v47;
    var v46: bool = undefined; _ = &v46;
    var v49: bool = undefined; _ = &v49;
    var v48: bool = undefined; _ = &v48;
    var v51: bool = undefined; _ = &v51;
    var v50: bool = undefined; _ = &v50;
    var v53: bool = undefined; _ = &v53;
    var v52: bool = undefined; _ = &v52;
    v0 = @as(i8, 100);
    v1 = @as(i8, 3);
    v2 = v0 *% v1;
    v3 = @as(i8, -8);
    v4 = @as(i8, 2);
    v5 = @divTrunc(v3, v4);
    v6 = @rem(v3, v1);
    v7 = -%v1;
    v8 = std.math.shl(@TypeOf(v0), v0, @as(i32, 1));
    v9 = @as(u8, 200);
    v10 = @as(u8, 3);
    v11 = @divTrunc(v9, v10);
    v12 = @rem(v9, v10);
    v13 = @as(u8, 15);
    v14 = v9 & v13;
    v15 = v9 | v13;
    v16 = v9 ^ v13;
    v17 = ~v13;
    v18 = @as(i16, 20000);
    v19 = @as(i16, 7);
    v20 = @divTrunc(v18, v19);
    v21 = @rem(v18, v19);
    v22 = -%v18;
    v23 = @as(u16, 40000);
    v24 = std.math.shl(@TypeOf(v23), v23, @as(i32, 1));
    v25 = v2 == @as(i8, 44);
    if (v25) {
        v26 = v5 == @as(i8, -4);
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
        v28 = v6 == @as(i8, -2);
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        v30 = v7 == @as(i8, -3);
        v31 = v30;
    } else {
        v31 = false;
    }
    if (v31) {
        v32 = v8 == @as(i8, -56);
        v33 = v32;
    } else {
        v33 = false;
    }
    if (v33) {
        v34 = v11 == @as(u8, 66);
        v35 = v34;
    } else {
        v35 = false;
    }
    if (v35) {
        v36 = v12 == @as(u8, 2);
        v37 = v36;
    } else {
        v37 = false;
    }
    if (v37) {
        v38 = v14 == @as(u8, 8);
        v39 = v38;
    } else {
        v39 = false;
    }
    if (v39) {
        v40 = v15 == @as(u8, 207);
        v41 = v40;
    } else {
        v41 = false;
    }
    if (v41) {
        v42 = v16 == @as(u8, 199);
        v43 = v42;
    } else {
        v43 = false;
    }
    if (v43) {
        v44 = v17 == @as(u8, 240);
        v45 = v44;
    } else {
        v45 = false;
    }
    if (v45) {
        v46 = v20 == @as(i16, 2857);
        v47 = v46;
    } else {
        v47 = false;
    }
    if (v47) {
        v48 = v21 == @as(i16, 1);
        v49 = v48;
    } else {
        v49 = false;
    }
    if (v49) {
        v50 = v22 == @as(i16, -20000);
        v51 = v50;
    } else {
        v51 = false;
    }
    if (v51) {
        v52 = v24 == @as(u16, 14464);
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
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
