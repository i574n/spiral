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
const Tuple0 = struct { f0: *Heap0, f1: *Heap0 };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) Tuple0 };
const ClosureEnv0 = struct { v0: *Heap0, v1: *Heap0, pad: u8 = 0 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn f_c0(ctx: *anyopaque, p2: i32) Tuple0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *Heap0 = env.v0; _ = &v0;
    var v1: *Heap0 = env.v1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    return Tuple0{ .f0 = v0, .f1 = v1 };
}
fn closureCreate0(p0: *Heap0, p1: *Heap0) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, .v1 = p1, }), .call = &f_c0 };
}
fn spiralMain() i32 {
    var tmp9: Tuple0 = undefined; _ = &tmp9;
    var v15: bool = undefined; _ = &v15;
    var v14: bool = undefined; _ = &v14;
    var v17: bool = undefined; _ = &v17;
    var v16: bool = undefined; _ = &v16;
    var v19: bool = undefined; _ = &v19;
    var v18: bool = undefined; _ = &v18;
    const v0: i32 = @as(i32, 7);
    const v1: []const u8 = "hi";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 4);
    const v4: []const u8 = "yo";
    const v5: *Heap0 = heapCreate0(v3, v4);
    const v6: Fun0 = closureCreate0(v2, v5);
    tmp9 = v6.call(v6.ctx, @as(i32, 1));
    const v7: *Heap0 = tmp9.f0;
    const v8: *Heap0 = tmp9.f1;
    const v9: i32 = v7.l0;
    const v10: []const u8 = v7.l1;
    const v11: i32 = v8.l0;
    const v12: []const u8 = v8.l1;
    const v13: bool = v9 == @as(i32, 7);
    if (v13) {
        v14 = std.mem.eql(u8, v10, "hi");
        v15 = v14;
    } else {
        v15 = false;
    }
    if (v15) {
        v16 = v11 == @as(i32, 4);
        v17 = v16;
    } else {
        v17 = false;
    }
    if (v17) {
        v18 = std.mem.eql(u8, v12, "yo");
        v19 = v18;
    } else {
        v19 = false;
    }
    if (v19) {
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
