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
fn spiralConv(comptime T: type, x: anytype) T {
    const S = @TypeOf(x);
    if (@typeInfo(T) == .float) {
        if (@typeInfo(S) == .float) return @floatCast(x) else return @floatFromInt(x);
    }
    if (@typeInfo(S) == .float) return @intFromFloat(x);
    const U = @Int(.unsigned, @bitSizeOf(T));
    const wide: i128 = x;
    return @bitCast(@as(U, @truncate(@as(u128, @bitCast(wide)))));
}
fn spiralMain() i32 {
    var v23: bool = undefined; _ = &v23;
    var v22: bool = undefined; _ = &v22;
    var v26: bool = undefined; _ = &v26;
    var v24: bool = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v27: bool = undefined; _ = &v27;
    var v29: bool = undefined; _ = &v29;
    var v28: bool = undefined; _ = &v28;
    var v31: bool = undefined; _ = &v31;
    var v30: bool = undefined; _ = &v30;
    var v33: bool = undefined; _ = &v33;
    var v32: bool = undefined; _ = &v32;
    var v34: bool = undefined; _ = &v34;
    var v36: bool = undefined; _ = &v36;
    var v35: bool = undefined; _ = &v35;
    var v37: bool = undefined; _ = &v37;
    var v39: bool = undefined; _ = &v39;
    var v38: bool = undefined; _ = &v38;
    var v41: bool = undefined; _ = &v41;
    var v40: bool = undefined; _ = &v40;
    var v42: bool = undefined; _ = &v42;
    var v44: bool = undefined; _ = &v44;
    var v43: bool = undefined; _ = &v43;
    const v0: i32 = @as(i32, -2147483648);
    const v1: u32 = @as(u32, 4294967295);
    const v2: i32 = @as(i32, -1);
    const v3: f32 = @as(f32, 0.0);
    const v4: f32 = @as(f32, 1.9);
    const v5: f32 = @as(f32, 2.9);
    const v6: u32 = @as(u32, 4294967294);
    const v7: u32 = @as(u32, 5);
    const v8: u32 = @as(u32, 0);
    const v9: f32 = v3 - v4;
    const v10: u32 = spiralConv(u32, v0);
    const v11: i32 = spiralConv(i32, v10);
    const v12: i32 = spiralConv(i32, v1);
    const v13: u32 = spiralConv(u32, v2);
    const v14: i32 = spiralConv(i32, v9);
    const v15: i32 = spiralConv(i32, v5);
    const v16: u32 = @divTrunc(v10, @as(u32, 2));
    const v17: u32 = @divTrunc(v6, @as(u32, 2));
    const v18: u32 = @rem(v7, @as(u32, 3));
    const v19: u32 = ~v8;
    const v20: u32 = std.math.shr(@TypeOf(v1), v1, @as(i32, 31));
    const v21: bool = v0 < @as(i32, -1);
    if (v21) {
        v22 = v0 <= v0;
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        v24 = v0 > @as(i32, 0);
        v25 = v24 == false;
        v26 = v25;
    } else {
        v26 = false;
    }
    if (v26) {
        v27 = v10 > @as(u32, 1);
        if (v27) {
            v28 = v11 == v0;
            v29 = v28;
        } else {
            v29 = false;
        }
        if (v29) {
            v30 = v12 == v2;
            v31 = v30;
        } else {
            v31 = false;
        }
        if (v31) {
            v32 = v13 == v1;
            v33 = v32;
        } else {
            v33 = false;
        }
        if (v33) {
            v34 = v14 == v2;
            if (v34) {
                v35 = v15 == @as(i32, 2);
                v36 = v35;
            } else {
                v36 = false;
            }
            if (v36) {
                v37 = v16 == @as(u32, 1073741824);
                if (v37) {
                    v38 = v17 == @as(u32, 2147483647);
                    v39 = v38;
                } else {
                    v39 = false;
                }
                if (v39) {
                    v40 = v18 == @as(u32, 2);
                    v41 = v40;
                } else {
                    v41 = false;
                }
                if (v41) {
                    v42 = v19 == v1;
                    if (v42) {
                        v43 = v20 == @as(u32, 1);
                        v44 = v43;
                    } else {
                        v44 = false;
                    }
                    if (v44) {
                        return @as(i32, 0);
                    } else {
                        return @as(i32, 5);
                    }
                } else {
                    return @as(i32, 4);
                }
            } else {
                return @as(i32, 3);
            }
        } else {
            return @as(i32, 2);
        }
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
