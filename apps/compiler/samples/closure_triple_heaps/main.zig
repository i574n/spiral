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
const Tuple0 = struct { f0: *Heap0, f1: *Heap0, f2: *Heap0 };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, i32) Tuple0 };
const ClosureEnv0 = struct { v0: *Heap0, v1: *Heap0, v2: *Heap0, pad: u8 = 0 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn f_c0(ctx: *anyopaque, p3: i32) Tuple0 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *Heap0 = env.v0; _ = &v0;
    var v1: *Heap0 = env.v1; _ = &v1;
    var v2: *Heap0 = env.v2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    return Tuple0{ .f0 = v0, .f1 = v1, .f2 = v2 };
}
fn closureCreate0(p0: *Heap0, p1: *Heap0, p2: *Heap0) Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ .v0 = p0, .v1 = p1, .v2 = p2, }), .call = &f_c0 };
}
fn spiralMain() i32 {
    var tmp13: Tuple0 = undefined; _ = &tmp13;
    var v21: bool = undefined; _ = &v21;
    var v20: bool = undefined; _ = &v20;
    var v23: bool = undefined; _ = &v23;
    var v22: bool = undefined; _ = &v22;
    var v25: bool = undefined; _ = &v25;
    var v24: bool = undefined; _ = &v24;
    var v27: bool = undefined; _ = &v27;
    var v26: bool = undefined; _ = &v26;
    var v29: bool = undefined; _ = &v29;
    var v28: bool = undefined; _ = &v28;
    const v0: i32 = @as(i32, 7);
    const v1: []const u8 = "hi";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 4);
    const v4: []const u8 = "yo";
    const v5: *Heap0 = heapCreate0(v3, v4);
    const v6: i32 = @as(i32, 9);
    const v7: []const u8 = "ok";
    const v8: *Heap0 = heapCreate0(v6, v7);
    const v9: Fun0 = closureCreate0(v2, v5, v8);
    tmp13 = v9.call(v9.ctx, @as(i32, 1));
    const v10: *Heap0 = tmp13.f0;
    const v11: *Heap0 = tmp13.f1;
    const v12: *Heap0 = tmp13.f2;
    const v13: i32 = v10.l0;
    const v14: []const u8 = v10.l1;
    const v15: i32 = v11.l0;
    const v16: []const u8 = v11.l1;
    const v17: i32 = v12.l0;
    const v18: []const u8 = v12.l1;
    const v19: bool = v13 == @as(i32, 7);
    if (v19) {
        v20 = std.mem.eql(u8, v14, "hi");
        v21 = v20;
    } else {
        v21 = false;
    }
    if (v21) {
        v22 = v15 == @as(i32, 4);
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        v24 = std.mem.eql(u8, v16, "yo");
        v25 = v24;
    } else {
        v25 = false;
    }
    if (v25) {
        v26 = v17 == @as(i32, 9);
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
        v28 = std.mem.eql(u8, v18, "ok");
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
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
