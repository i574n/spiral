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
    var v13: u32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v15: u32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: u64 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v19: u64 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: u64 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: i8 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: i64 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: u32 = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: i32 = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    const v0: u8 = @as(u8, 250);
    const v1: u8 = @as(u8, 10);
    const v2: u32 = @as(u32, 4294967295);
    const v3: u64 = @as(u64, 18446744073709551615);
    const v4: i8 = @as(i8, 127);
    const v5: i8 = @as(i8, 1);
    const v6: i32 = @as(i32, 7);
    const v7: i32 = @as(i32, 2);
    const v8: i64 = @as(i64, 9223372036854775807);
    const v9: i32 = -%v6;
    const v10: i64 = -%v8;
    const v11: u8 = v0 +% v1;
    const v12: bool = v11 == @as(u8, 4);
    if (v12) {
        v13 = v2 +% @as(u32, 1);
        v14 = v13 == @as(u32, 0);
        if (v14) {
            v15 = v2 *% v2;
            v16 = v15 == @as(u32, 1);
            if (v16) {
                v17 = v3 +% @as(u64, 1);
                v18 = v17 == @as(u64, 0);
                if (v18) {
                    v19 = v3 *% v3;
                    v20 = v19 == @as(u64, 1);
                    if (v20) {
                        v21 = @divTrunc(v3, @as(u64, 3));
                        v22 = v21 == @as(u64, 6148914691236517205);
                        if (v22) {
                            v23 = v4 +% v5;
                            v24 = v23 < @as(i8, 0);
                            if (v24) {
                                v25 = @divTrunc(v9, v7);
                                v26 = v25 == @as(i32, -3);
                                if (v26) {
                                    v27 = @rem(v9, v7);
                                    v28 = v27 == @as(i32, -1);
                                    if (v28) {
                                        v29 = @rem(v10, @as(i64, 10));
                                        v30 = v29 == @as(i64, -7);
                                        if (v30) {
                                            v31 = std.math.shr(@TypeOf(v2), v2, @as(i32, 28));
                                            v32 = v31 == @as(u32, 15);
                                            if (v32) {
                                                v33 = std.math.shr(@TypeOf(v9), v9, @as(i32, 1));
                                                v34 = v33 == @as(i32, -4);
                                                if (v34) {
                                                    return @as(i32, 0);
                                                } else {
                                                    return @as(i32, 12);
                                                }
                                            } else {
                                                return @as(i32, 11);
                                            }
                                        } else {
                                            return @as(i32, 10);
                                        }
                                    } else {
                                        return @as(i32, 9);
                                    }
                                } else {
                                    return @as(i32, 8);
                                }
                            } else {
                                return @as(i32, 7);
                            }
                        } else {
                            return @as(i32, 6);
                        }
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
