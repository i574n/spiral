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
const UH0 = struct { tag: i32, c1_0: i32 = undefined, c1_1: *UH0 = undefined };
fn UH0_Empty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_Box(a0: i32, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn method2(p0: i32) *UH0 {
    var v0: i32 = p0; _ = &v0;
    var v3: *UH0 = undefined; _ = &v3;
    const v1: i32 = v0 -% @as(i32, 1);
    const v2: bool = v1 == @as(i32, 0);
    if (v2) {
        v3 = UH0_Empty();
        return UH0_Box(@as(i32, 7), v3);
    } else {
        return method1(v1);
    }
}
fn method1(p0: i32) *UH0 {
    var v0: i32 = p0; _ = &v0;
    var v3: *UH0 = undefined; _ = &v3;
    const v1: i32 = v0 -% @as(i32, 1);
    const v2: bool = v1 == @as(i32, 0);
    if (v2) {
        v3 = UH0_Empty();
        return UH0_Box(@as(i32, 11), v3);
    } else {
        return method2(v1);
    }
}
fn method0() *UH0 {
    var v2: *UH0 = undefined; _ = &v2;
    const v0: i32 = @as(i32, 1000000);
    const v1: bool = v0 == @as(i32, 0);
    if (v1) {
        v2 = UH0_Empty();
        return UH0_Box(@as(i32, 7), v2);
    } else {
        return method1(v0);
    }
}
fn spiralMain() i32 {
    var v1: i32 = undefined; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    const v0: *UH0 = method0();
    switch (v0.tag) {
        1 => {
            v1 = v0.c1_0;
            v2 = v0.c1_1;
            v3 = v1 == @as(i32, 7);
            if (v3) {
                return @as(i32, 0);
            } else {
                return @as(i32, 3);
            }
        },
        0 => {
            return @as(i32, 1);
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
