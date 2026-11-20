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
const Heap0 = struct { l0: i32 };
const US0 = struct { tag: i32, c1_0: i32 = undefined };
const Tuple0 = struct { f0: US0, f1: *Heap0 };
fn heapCreate0(a0: i32) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0 });
}
fn US0_None() US0 {
    return US0{ .tag = 0 };
}
fn US0_Some(a0: i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0 };
}
fn method0(p0: i32, p1: *Heap0) Tuple0 {
    var v0: i32 = p0; _ = &v0;
    var v1: *Heap0 = p1; _ = &v1;
    const v2: US0 = US0_Some(v0);
    return Tuple0{ .f0 = v2, .f1 = v1 };
}
fn spiralMain() i32 {
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    var v5: i32 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    const v0: i32 = @as(i32, 3);
    const v1: i32 = @as(i32, 4);
    const v2: *Heap0 = heapCreate0(v1);
    tmp5 = method0(v0, v2);
    const v3: US0 = tmp5.f0;
    const v4: *Heap0 = tmp5.f1;
    switch (v3.tag) {
        0 => {
            return @as(i32, 1);
        },
        1 => {
            v5 = v3.c1_0;
            v6 = v4.l0;
            v7 = v5 +% v6;
            v8 = v7 == @as(i32, 7);
            if (v8) {
                return @as(i32, 0);
            } else {
                return @as(i32, 1);
            }
        },
        else => unreachable,
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
