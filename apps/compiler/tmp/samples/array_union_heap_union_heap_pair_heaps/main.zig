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
const US1 = struct { tag: i32, c1_0: *Heap3 = undefined };
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
fn score_0(p0: US1) i32 {
    var v0: US1 = p0; _ = &v0;
    var v1: *Heap3 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *Heap2 = undefined; _ = &v3;
    var v4: *Heap1 = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: *Heap0 = undefined; _ = &v6;
    var v7: *Heap0 = undefined; _ = &v7;
    var v8: i32 = undefined; _ = &v8;
    var v9: []const u8 = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: []const u8 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v14: bool = undefined; _ = &v14;
    var v13: bool = undefined; _ = &v13;
    var v16: bool = undefined; _ = &v16;
    var v15: bool = undefined; _ = &v15;
    var v18: bool = undefined; _ = &v18;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    switch (v0.tag) {
        0 => {
            return @as(i32, 1);
        },
        1 => {
            v1 = v0.c1_0;
            v2 = v1.l0;
            switch (v2.tag) {
                1 => {
                    v3 = v2.c1_0;
                    v4 = v3.l0;
                    v5 = v3.l1;
                    v6 = v4.l0;
                    v7 = v4.l1;
                    v8 = v6.l0;
                    v9 = v6.l1;
                    v10 = v7.l0;
                    v11 = v7.l1;
                    v12 = v8 == @as(i32, 7);
                    if (v12) {
                        v13 = std.mem.eql(u8, v9, "hi");
                        v14 = v13;
                    } else {
                        v14 = false;
                    }
                    if (v14) {
                        v15 = v10 == @as(i32, 4);
                        v16 = v15;
                    } else {
                        v16 = false;
                    }
                    if (v16) {
                        v17 = std.mem.eql(u8, v11, "yo");
                        v18 = v17;
                    } else {
                        v18 = false;
                    }
                    if (v18) {
                        v19 = v5 == @as(i32, 2);
                        v20 = v19;
                    } else {
                        v20 = false;
                    }
                    if (v20) {
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
        else => unreachable,
    }
}
fn spiralMain() i32 {
    var v12: US0 = undefined; _ = &v12;
    var v17: US1 = undefined; _ = &v17;
    var v18: []US1 = undefined; _ = &v18;
    const v0: i32 = @as(i32, 7);
    const v1: []const u8 = "hi";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 4);
    const v4: []const u8 = "yo";
    const v5: *Heap0 = heapCreate0(v3, v4);
    const v6: *Heap1 = heapCreate1(v2, v5);
    const v7: i32 = @as(i32, 2);
    const v8: *Heap2 = heapCreate2(v6, v7);
    const v9: bool = true;
    if (v9) {
        v12 = US0_Held(v8);
    } else {
        v12 = US0_None();
    }
    const v13: *Heap3 = heapCreate3(v12);
    const v14: bool = true;
    if (v14) {
        v17 = US1_Box(v13);
    } else {
        v17 = US1_Absent();
    }
    v18 = spiralNewArray(US1, @as(i32, 1));
    v18[spiralIndex(v18.len, @as(i32, 0))] = v17;
    const v19: US1 = v18[spiralIndex(v18.len, @as(i32, 0))];
    return score_0(v19);
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
