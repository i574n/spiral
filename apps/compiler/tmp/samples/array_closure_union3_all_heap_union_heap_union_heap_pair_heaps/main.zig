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
const Heap0 = struct { l0: i32, l1: []const u8 };
const Heap1 = struct { l0: *Heap0, l1: *Heap0 };
const Heap2 = struct { l0: *Heap1, l1: i32 };
const US0 = struct { tag: i32, c1_0: *Heap2 = undefined };
const Heap3 = struct { l0: US0 };
const US1 = struct { tag: i32, c1_0: *Heap3 = undefined, c2_0: i32 = undefined };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) US1 };
const ClosureEnv0 = struct { v0: US1, v1: i32, pad: u8 = 0 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate1(a0: *Heap0, a1: *Heap0) *Heap1 {
    return spiralCreate(Heap1, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate2(a0: *Heap1, a1: i32) *Heap2 {
    return spiralCreate(Heap2, .{ .l0 = a0, .l1 = a1 });
}
fn US0_None() US0 {
    return US0{ .tag = 0 };
}
fn US0_Held(a0: *Heap2) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn heapCreate3(a0: US0) *Heap3 {
    return spiralCreate(Heap3, .{ .l0 = a0 });
}
fn US1_Absent() US1 {
    return US1{ .tag = 0 };
}
fn US1_Box(a0: *Heap3) US1 {
    return US1{ .tag = 1, .c1_0 = a0 };
}
fn US1_Mark(a0: i32) US1 {
    return US1{ .tag = 2, .c2_0 = a0 };
}
fn f_c0(ctx: *anyopaque, p2: i32) US1 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: US1 = env.v0; _ = &v0;
    var v1: i32 = env.v1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v5: bool = undefined; _ = &v5;
    v3 = v2 == @as(i32, 0);
    if (v3) {
        return US1_Absent();
    } else {
        v5 = v2 == @as(i32, 1);
        if (v5) {
            return v0;
        } else {
            return US1_Mark(v1);
        }
    }
}
fn closureCreate0(p0: US1, p1: i32) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, .v1 = p1, }), .call = &f_c0 };
}
fn score_0(p0: US1) i32 {
    var v0: US1 = p0; _ = &v0;
    var v3: *Heap3 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *Heap2 = undefined; _ = &v5;
    var v6: *Heap1 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: *Heap0 = undefined; _ = &v8;
    var v9: *Heap0 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: []const u8 = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: []const u8 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: bool = undefined; _ = &v16;
    var v15: bool = undefined; _ = &v15;
    var v18: bool = undefined; _ = &v18;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    var v22: bool = undefined; _ = &v22;
    var v21: bool = undefined; _ = &v21;
    var v1: i32 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            return @as(i32, 1);
        },
        1 => {
            v3 = v0.c1_0;
            v4 = v3.l0;
            switch (v4.tag) {
                1 => {
                    v5 = v4.c1_0;
                    v6 = v5.l0;
                    v7 = v5.l1;
                    v8 = v6.l0;
                    v9 = v6.l1;
                    v10 = v8.l0;
                    v11 = v8.l1;
                    v12 = v9.l0;
                    v13 = v9.l1;
                    v14 = v10 == @as(i32, 7);
                    if (v14) {
                        v15 = std.mem.eql(u8, v11, "hi");
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    if (v16) {
                        v17 = v12 == @as(i32, 4);
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    if (v18) {
                        v19 = std.mem.eql(u8, v13, "yo");
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    if (v20) {
                        v21 = v7 == @as(i32, 2);
                        v22 = v21;
                    } else {
                        v22 = false;
                    }
                    if (v22) {
                        return @as(i32, 0);
                    } else {
                        return @as(i32, 1);
                    }
                },
                0 => {
                    return @as(i32, 1);
                },
                else => unreachable,
            }
        },
        2 => {
            v1 = v0.c2_0;
            return @as(i32, 1);
        },
        else => unreachable,
    }
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
    var v9: bool = undefined; _ = &v9;
    var v12: US0 = undefined; _ = &v12;
    var v13: *Heap3 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v17: US1 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: Fun0 = undefined; _ = &v19;
    var v20: []US1 = undefined; _ = &v20;
    var v21: US1 = undefined; _ = &v21;
    var v22: US1 = undefined; _ = &v22;
    var v23: US1 = undefined; _ = &v23;
    var v24: US1 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: US1 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: US1 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v32: bool = undefined; _ = &v32;
    var v31: bool = undefined; _ = &v31;
    var v34: bool = undefined; _ = &v34;
    var v33: bool = undefined; _ = &v33;
    v0 = @as(i32, 7);
    v1 = "hi";
    v2 = heapCreate0(v0, v1);
    v3 = @as(i32, 4);
    v4 = "yo";
    v5 = heapCreate0(v3, v4);
    v6 = heapCreate1(v2, v5);
    v7 = @as(i32, 2);
    v8 = heapCreate2(v6, v7);
    v9 = true;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    v13 = heapCreate3(v12);
    v14 = true;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Mark(@as(i32, 1));
    }
    v18 = @as(i32, 3);
    v19 = closureCreate0(v17, v18);
    v20 = spiralNewArray(US1, @as(i32, 3));
    v21 = v19.call(v19.ctx, @as(i32, 1));
    v20[spiralIndex(v20.len, @as(i32, 0))] = v21;
    v22 = v19.call(v19.ctx, @as(i32, 2));
    v20[spiralIndex(v20.len, @as(i32, 1))] = v22;
    v23 = v19.call(v19.ctx, @as(i32, 0));
    v20[spiralIndex(v20.len, @as(i32, 2))] = v23;
    v24 = v20[spiralIndex(v20.len, @as(i32, 0))];
    v25 = score_0(v24);
    v26 = v20[spiralIndex(v20.len, @as(i32, 1))];
    v27 = score_0(v26);
    v28 = v20[spiralIndex(v20.len, @as(i32, 2))];
    v29 = score_0(v28);
    v30 = v25 == @as(i32, 0);
    if (v30) {
        v31 = v27 == @as(i32, 1);
        v32 = v31;
    } else {
        v32 = false;
    }
    if (v32) {
        v33 = v29 == @as(i32, 1);
        v34 = v33;
    } else {
        v34 = false;
    }
    if (v34) {
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
