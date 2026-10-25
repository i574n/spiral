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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const Heap0 = struct { l0: i32, l1: []const u8 };
const US0 = struct { tag: i32, c1_0: *Heap0 = undefined, c1_1: *Heap0 = undefined };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn US0_None() US0 {
    return US0{ .tag = 0 };
}
fn US0_Held(a0: *Heap0, a1: *Heap0) US0 {
    return US0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 };
}
fn score_0(p0: US0) i32 {
    var v0: US0 = p0; _ = &v0;
    var v1: *Heap0 = undefined; _ = &v1;
    var v2: *Heap0 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: []const u8 = undefined; _ = &v4;
    var v5: i32 = undefined; _ = &v5;
    var v6: []const u8 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: bool = undefined; _ = &v9;
    var v8: bool = undefined; _ = &v8;
    var v11: bool = undefined; _ = &v11;
    var v10: bool = undefined; _ = &v10;
    var v13: bool = undefined; _ = &v13;
    var v12: bool = undefined; _ = &v12;
    switch (v0.tag) {
        1 => {
            v1 = v0.c1_0;
            v2 = v0.c1_1;
            v3 = v1.l0;
            v4 = v1.l1;
            v5 = v2.l0;
            v6 = v2.l1;
            v7 = v3 == @as(i32, 7);
            if (v7) {
                v8 = std.mem.eql(u8, v4, "hi");
                v9 = v8;
            } else {
                v9 = false;
            }
            if (v9) {
                v10 = v5 == @as(i32, 4);
                v11 = v10;
            } else {
                v11 = false;
            }
            if (v11) {
                v12 = std.mem.eql(u8, v6, "yo");
                v13 = v12;
            } else {
                v13 = false;
            }
            if (v13) {
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
}
fn spiralMain() i32 {
    var v9: US0 = undefined; _ = &v9;
    const v0: i32 = @as(i32, 7);
    const v1: []const u8 = "hi";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 4);
    const v4: []const u8 = "yo";
    const v5: *Heap0 = heapCreate0(v3, v4);
    const v6: bool = true;
    if (v6) {
        v9 = US0_Held(v2, v5);
    } else {
        v9 = US0_None();
    }
    return score_0(v9);
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
