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
fn spiralMain() i32 {
    var v8: bool = undefined; _ = &v8;
    var v6: f64 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v11: bool = undefined; _ = &v11;
    var v9: f32 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v14: bool = undefined; _ = &v14;
    var v12: f64 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v17: bool = undefined; _ = &v17;
    var v15: f32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v20: bool = undefined; _ = &v20;
    var v18: f64 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v23: bool = undefined; _ = &v23;
    var v21: f32 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v26: bool = undefined; _ = &v26;
    var v24: f64 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v29: bool = undefined; _ = &v29;
    var v27: f32 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: bool = undefined; _ = &v32;
    var v30: f64 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    const v0: f32 = @as(f32, 0.0);
    const v1: f32 = @as(f32, 1.0);
    const v2: f64 = @as(f64, 0.0);
    const v3: f64 = @as(f64, 1.0);
    const v4: f32 = @log(v1);
    const v5: bool = v4 == v0;
    if (v5) {
        v6 = @log(v3);
        v7 = v6 == v2;
        v8 = v7;
    } else {
        v8 = false;
    }
    if (v8) {
        v9 = @exp(v0);
        v10 = v9 == v1;
        v11 = v10;
    } else {
        v11 = false;
    }
    if (v11) {
        v12 = @exp(v2);
        v13 = v12 == v3;
        v14 = v13;
    } else {
        v14 = false;
    }
    if (v14) {
        v15 = std.math.tanh(v0);
        v16 = v15 == v0;
        v17 = v16;
    } else {
        v17 = false;
    }
    if (v17) {
        v18 = std.math.tanh(v2);
        v19 = v18 == v2;
        v20 = v19;
    } else {
        v20 = false;
    }
    if (v20) {
        v21 = @sin(v0);
        v22 = v21 == v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        v24 = @sin(v2);
        v25 = v24 == v2;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        v27 = @cos(v0);
        v28 = v27 == v1;
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        v30 = @cos(v2);
        v31 = v30 == v3;
        v32 = v31;
    } else {
        v32 = false;
    }
    if (v32) {
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
