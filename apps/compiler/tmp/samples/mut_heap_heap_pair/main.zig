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
const Heap0 = struct { l0: i32, l1: []const u8 };
const Heap1 = struct { l0: *Heap0, l1: *Heap0 };
const Heap2 = struct { l0: *Heap1, l1: i32 };
const Mut3 = struct { l0: *Heap2 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate1(a0: *Heap0, a1: *Heap0) *Heap1 {
    return spiralCreate(Heap1, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate2(a0: *Heap1, a1: i32) *Heap2 {
    return spiralCreate(Heap2, .{ .l0 = a0, .l1 = a1 });
}
fn mutCreate3(a0: *Heap2) *Mut3 {
    return spiralCreate(Mut3, .{ .l0 = a0 });
}
fn spiralMain() i32 {
    var v0: i32 = undefined; _ = &v0;
    var v1: []const u8 = undefined; _ = &v1;
    var v2: *Heap0 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: []const u8 = undefined; _ = &v4;
    var v5: *Heap0 = undefined; _ = &v5;
    var v6: *Heap1 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: *Heap2 = undefined; _ = &v8;
    var v9: *Mut3 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: []const u8 = undefined; _ = &v11;
    var v12: *Heap0 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: []const u8 = undefined; _ = &v14;
    var v15: *Heap0 = undefined; _ = &v15;
    var v16: *Heap1 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: *Heap2 = undefined; _ = &v18;
    var v19: *Heap2 = undefined; _ = &v19;
    var v20: *Heap1 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: *Heap0 = undefined; _ = &v22;
    var v23: *Heap0 = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: []const u8 = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: []const u8 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v30: bool = undefined; _ = &v30;
    var v29: bool = undefined; _ = &v29;
    var v32: bool = undefined; _ = &v32;
    var v31: bool = undefined; _ = &v31;
    var v34: bool = undefined; _ = &v34;
    var v33: bool = undefined; _ = &v33;
    var v36: bool = undefined; _ = &v36;
    var v35: bool = undefined; _ = &v35;
    v0 = @as(i32, 1);
    v1 = "no";
    v2 = heapCreate0(v0, v1);
    v3 = @as(i32, 2);
    v4 = "zz";
    v5 = heapCreate0(v3, v4);
    v6 = heapCreate1(v2, v5);
    v7 = @as(i32, 3);
    v8 = heapCreate2(v6, v7);
    v9 = mutCreate3(v8);
    v10 = @as(i32, 7);
    v11 = "hi";
    v12 = heapCreate0(v10, v11);
    v13 = @as(i32, 4);
    v14 = "yo";
    v15 = heapCreate0(v13, v14);
    v16 = heapCreate1(v12, v15);
    v17 = @as(i32, 2);
    v18 = heapCreate2(v16, v17);
    v9.l0 = v18;
    v19 = v9.l0;
    v20 = v19.l0;
    v21 = v19.l1;
    v22 = v20.l0;
    v23 = v20.l1;
    v24 = v22.l0;
    v25 = v22.l1;
    v26 = v23.l0;
    v27 = v23.l1;
    v28 = v24 == @as(i32, 7);
    if (v28) {
        v29 = std.mem.eql(u8, v25, "hi");
        v30 = v29;
    } else {
        v30 = false;
    }
    if (v30) {
        v31 = v26 == @as(i32, 4);
        v32 = v31;
    } else {
        v32 = false;
    }
    if (v32) {
        v33 = std.mem.eql(u8, v27, "yo");
        v34 = v33;
    } else {
        v34 = false;
    }
    if (v34) {
        v35 = v21 == @as(i32, 2);
        v36 = v35;
    } else {
        v36 = false;
    }
    if (v36) {
        return @as(i32, 0);
    } else {
        return @as(i32, 1);
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
