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
const Heap1 = struct { l0: *Heap0, l1: i32 };
const Heap2 = struct { l0: *Heap1, l1: i32 };
const Mut3 = struct { l0: *Heap2 };
fn heapCreate0(a0: i32, a1: []const u8) *Heap0 {
    return spiralCreate(Heap0, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate1(a0: *Heap0, a1: i32) *Heap1 {
    return spiralCreate(Heap1, .{ .l0 = a0, .l1 = a1 });
}
fn heapCreate2(a0: *Heap1, a1: i32) *Heap2 {
    return spiralCreate(Heap2, .{ .l0 = a0, .l1 = a1 });
}
fn mutCreate3(a0: *Heap2) *Mut3 {
    return spiralCreate(Mut3, .{ .l0 = a0 });
}
fn spiralMain() i32 {
    var v7: *Mut3 = undefined; _ = &v7;
    var v24: bool = undefined; _ = &v24;
    var v23: bool = undefined; _ = &v23;
    var v26: bool = undefined; _ = &v26;
    var v25: bool = undefined; _ = &v25;
    var v28: bool = undefined; _ = &v28;
    var v27: bool = undefined; _ = &v27;
    const v0: i32 = @as(i32, 3);
    const v1: []const u8 = "no";
    const v2: *Heap0 = heapCreate0(v0, v1);
    const v3: i32 = @as(i32, 1);
    const v4: *Heap1 = heapCreate1(v2, v3);
    const v5: i32 = @as(i32, 2);
    const v6: *Heap2 = heapCreate2(v4, v5);
    v7 = mutCreate3(v6);
    const v8: i32 = @as(i32, 7);
    const v9: []const u8 = "hi";
    const v10: *Heap0 = heapCreate0(v8, v9);
    const v11: i32 = @as(i32, 4);
    const v12: *Heap1 = heapCreate1(v10, v11);
    const v13: i32 = @as(i32, 5);
    const v14: *Heap2 = heapCreate2(v12, v13);
    v7.l0 = v14;
    const v15: *Heap2 = v7.l0;
    const v16: *Heap1 = v15.l0;
    const v17: i32 = v15.l1;
    const v18: *Heap0 = v16.l0;
    const v19: i32 = v16.l1;
    const v20: i32 = v18.l0;
    const v21: []const u8 = v18.l1;
    const v22: bool = v20 == @as(i32, 7);
    if (v22) {
        v23 = std.mem.eql(u8, v21, "hi");
        v24 = v23;
    } else {
        v24 = false;
    }
    if (v24) {
        v25 = v19 == @as(i32, 4);
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        v27 = v17 == @as(i32, 5);
        v28 = v27;
    } else {
        v28 = false;
    }
    if (v28) {
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
