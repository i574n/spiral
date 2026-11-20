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
const Mut1 = struct { l0: *Heap0, l1: *Heap0 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn mutCreate1(a0: *Heap0, a1: *Heap0) *Mut1 {
    return spiralCreate(Mut1, .{ .l0 = a0, .l1 = a1 });
}
fn spiralMain() i32 {
    var v7: []*Mut1 = undefined; _ = &v7;
    var v14: *Mut1 = undefined; _ = &v14;
    var v23: bool = undefined; _ = &v23;
    var v22: bool = undefined; _ = &v22;
    var v25: bool = undefined; _ = &v25;
    var v24: bool = undefined; _ = &v24;
    var v27: bool = undefined; _ = &v27;
    var v26: bool = undefined; _ = &v26;
    const v0: i32 = @as(i32, 1);
    const v1: []const u8 = "no";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 2);
    const v4: []const u8 = "zz";
    const v5: *Heap0 = heapCreate0(v3, v4);
    const v6: *Mut1 = mutCreate1(v2, v5);
    v7 = spiralNewArray(*Mut1, @as(i32, 1));
    v7[spiralIndex(v7.len, @as(i32, 0))] = v6;
    const v8: i32 = @as(i32, 7);
    const v9: []const u8 = "hi";
    const v10: *Heap0 = heapCreate0(v8, v9);
    const v11: i32 = @as(i32, 4);
    const v12: []const u8 = "yo";
    const v13: *Heap0 = heapCreate0(v11, v12);
    v14 = v7[spiralIndex(v7.len, @as(i32, 0))];
    v14.l0 = v10;
    v14.l1 = v13;
    const v15: *Heap0 = v14.l0;
    const v16: *Heap0 = v14.l1;
    const v17: i32 = v15.l0;
    const v18: []const u8 = v15.l1;
    const v19: i32 = v16.l0;
    const v20: []const u8 = v16.l1;
    const v21: bool = v17 == @as(i32, 7);
    if (v21) {
        v22 = std.mem.eql(u8, v18, "hi");
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        v24 = v19 == @as(i32, 4);
        v25 = v24;
    } else {
        v25 = false;
    }
    if (v25) {
        v26 = std.mem.eql(u8, v20, "yo");
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
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
