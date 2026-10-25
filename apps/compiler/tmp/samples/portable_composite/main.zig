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
const Tuple0 = struct { f0: bool, f1: f32, f2: i32 };
const Tuple1 = struct { f0: i32, f1: i32, f2: bool };
fn method5(p0: i32, p1: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: i32 = v0 *% v1;
    const v3: i32 = v2 +% @as(i32, 5);
    const v4: i32 = @divTrunc(v3, @as(i32, 3));
    return v4;
}
fn method4(p0: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    const v1: i32 = @as(i32, 4);
    const v2: i32 = @as(i32, 4);
    const v3: i32 = method5(v1, v2);
    const v4: i32 = v0 +% v3;
    const v5: i32 = v4 -% @as(i32, 7);
    return v5;
}
fn method6(p0: u32) bool {
    var v0: u32 = p0; _ = &v0;
    const v1: u32 = v0 +% @as(u32, 5);
    const v2: u32 = @rem(v1, @as(u32, 4));
    const v3: bool = v2 == @as(u32, 0);
    return v3;
}
fn method3(p0: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    const v1: u32 = @as(u32, 7);
    const v2: bool = method6(v1);
    if (v2) {
        return method4(v0);
    } else {
        return @as(i32, 1);
    }
}
fn method7(p0: []const u8, p1: []const u8) bool {
    var v0: []const u8 = p0; _ = &v0;
    var v1: []const u8 = p1; _ = &v1;
    const v2: bool = std.mem.eql(u8, v0, v1);
    return v2;
}
fn method2(p0: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    const v1: []const u8 = "spiral";
    const v2: bool = method7(v1, v1);
    if (v2) {
        return method3(v0);
    } else {
        return @as(i32, 1);
    }
}
fn method8(p0: f32) Tuple0 {
    var v0: f32 = p0; _ = &v0;
    const v1: bool = v0 >= @as(f32, 3.5);
    return Tuple0{ .f0 = v1, .f1 = v0, .f2 = @as(i32, 7) };
}
fn method9(p0: bool, p1: f32, p2: i32) i32 {
    var v0: bool = p0; _ = &v0;
    var v1: f32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    if (v0) {
        v3 = v1 >= @as(f32, 3.5);
        if (v3) {
            v4 = v2 -% @as(i32, 7);
            return v4;
        } else {
            return @as(i32, 1);
        }
    } else {
        return @as(i32, 2);
    }
}
fn method1(p0: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    const v1: f32 = @as(f32, 4.0);
    tmp4 = method8(v1);
    const v2: bool = tmp4.f0;
    const v3: f32 = tmp4.f1;
    const v4: i32 = tmp4.f2;
    const v5: i32 = method9(v2, v3, v4);
    const v6: i32 = v0 +% v5;
    return method2(v6);
}
fn method10(p0: i32) Tuple1 {
    var v0: i32 = p0; _ = &v0;
    const v1: i32 = v0 +% @as(i32, 2);
    const v2: bool = v0 > @as(i32, 0);
    return Tuple1{ .f0 = v0, .f1 = v1, .f2 = v2 };
}
fn method11(p0: i32, p1: i32, p2: bool) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: bool = p2; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: i32 = undefined; _ = &v4;
    if (v2) {
        v3 = v0 +% v1;
        v4 = v3 -% @as(i32, 4);
        return v4;
    } else {
        return @as(i32, 1);
    }
}
fn method0(p0: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var tmp4: Tuple1 = undefined; _ = &tmp4;
    const v1: i32 = @as(i32, 1);
    tmp4 = method10(v1);
    const v2: i32 = tmp4.f0;
    const v3: i32 = tmp4.f1;
    const v4: bool = tmp4.f2;
    const v5: i32 = method11(v2, v3, v4);
    const v6: i32 = v0 +% v5;
    return method1(v6);
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 0);
    return method0(v0);
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
