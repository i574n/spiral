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
fn spiralPrint(s: []const u8) void {
    if (s.len > spiral_out_buffer.len - spiral_out_len) spiralFlush();
    if (s.len > spiral_out_buffer.len) {
        spiralWrite(1, s);
        return;
    }
    @memcpy(spiral_out_buffer[spiral_out_len..][0..s.len], s);
    spiral_out_len += s.len;
}
fn spiralFloatText(x: anytype) []u8 {
    var buffer: [std.fmt.float.bufferSize(.decimal, @TypeOf(x))]u8 = undefined;
    const text = std.fmt.float.render(&buffer, x, .{ .mode = .decimal }) catch unreachable;
    return spiral_gpa.dupe(u8, text) catch @panic("out of memory");
}
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    if (@typeInfo(T) == .float) return spiralPrint(spiralFloatText(x));
    const s = switch (@typeInfo(T)) {
        .bool => std.fmt.allocPrint(spiral_gpa, "{}", .{x}),
        else => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
    } catch @panic("out of memory");
    spiralPrint(s);
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
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
fn spiralConcat(a: []const u8, b: []const u8) []const u8 {
    return std.mem.concat(spiral_gpa, u8, &.{ a, b }) catch @panic("out of memory");
}
fn spiralStringSlice(s: []const u8, from: i64, upto: i64) []const u8 {
    const len: i64 = @intCast(s.len);
    if (from < 0 or from > len or upto < from - 1 or upto >= len) std.process.exit(3);
    if (upto < from) return "";
    const a: usize = @intCast(from);
    const b: usize = @intCast(upto + 1);
    if ((s[a] & 0xC0) == 0x80 or (b < s.len and (s[b] & 0xC0) == 0x80)) std.process.exit(3);
    return s[a..b];
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
fn spiralMain() i32 {
    var v0: f64 = undefined; _ = &v0;
    var v1: f64 = undefined; _ = &v1;
    var v2: f64 = undefined; _ = &v2;
    var v3: f64 = undefined; _ = &v3;
    var v4: f64 = undefined; _ = &v4;
    var v5: f64 = undefined; _ = &v5;
    var v6: f32 = undefined; _ = &v6;
    var v7: f64 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v9: f64 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v11: f64 = undefined; _ = &v11;
    var v12: f64 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v23: f64 = undefined; _ = &v23;
    var v14: f64 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: f64 = undefined; _ = &v16;
    var v17: f64 = undefined; _ = &v17;
    var v18: f64 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: f64 = undefined; _ = &v20;
    var v24: bool = undefined; _ = &v24;
    var v25: f64 = undefined; _ = &v25;
    var v26: f64 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v37: f64 = undefined; _ = &v37;
    var v28: f64 = undefined; _ = &v28;
    var v29: bool = undefined; _ = &v29;
    var v30: f64 = undefined; _ = &v30;
    var v31: f64 = undefined; _ = &v31;
    var v32: f64 = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v34: f64 = undefined; _ = &v34;
    var v38: bool = undefined; _ = &v38;
    var v39: f64 = undefined; _ = &v39;
    var v40: f64 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v51: f64 = undefined; _ = &v51;
    var v42: f64 = undefined; _ = &v42;
    var v43: bool = undefined; _ = &v43;
    var v44: f64 = undefined; _ = &v44;
    var v45: f64 = undefined; _ = &v45;
    var v46: f64 = undefined; _ = &v46;
    var v47: bool = undefined; _ = &v47;
    var v48: f64 = undefined; _ = &v48;
    var v52: bool = undefined; _ = &v52;
    var v53: f64 = undefined; _ = &v53;
    var v54: f64 = undefined; _ = &v54;
    var v55: bool = undefined; _ = &v55;
    var v65: f64 = undefined; _ = &v65;
    var v56: f64 = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: f64 = undefined; _ = &v58;
    var v59: f64 = undefined; _ = &v59;
    var v60: f64 = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v62: f64 = undefined; _ = &v62;
    var v66: bool = undefined; _ = &v66;
    var v67: f64 = undefined; _ = &v67;
    var v68: f64 = undefined; _ = &v68;
    var v69: bool = undefined; _ = &v69;
    var v79: f64 = undefined; _ = &v79;
    var v70: f64 = undefined; _ = &v70;
    var v71: bool = undefined; _ = &v71;
    var v72: f64 = undefined; _ = &v72;
    var v73: f64 = undefined; _ = &v73;
    var v74: f64 = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v76: f64 = undefined; _ = &v76;
    var v80: bool = undefined; _ = &v80;
    var v81: f64 = undefined; _ = &v81;
    var v82: f64 = undefined; _ = &v82;
    var v83: f64 = undefined; _ = &v83;
    var v84: bool = undefined; _ = &v84;
    var v85: f32 = undefined; _ = &v85;
    var v86: bool = undefined; _ = &v86;
    v0 = @as(f64, 2.7);
    v1 = @as(f64, 3.2);
    v2 = @as(f64, -2.5);
    v3 = @as(f64, 3.5);
    v4 = @as(f64, 0.5);
    v5 = @as(f64, 1.0);
    v6 = @as(f32, 2.7);
    v7 = @floor(v0);
    v8 = v7 != @as(f64, 2.0);
    if (v8) {
        return @as(i32, 1);
    } else {
        v9 = @ceil(v0);
        v10 = v9 != @as(f64, 3.0);
        if (v10) {
            return @as(i32, 2);
        } else {
            v11 = @floor(v0);
            v12 = v0 - v11;
            v13 = v12 > @as(f64, 0.5);
            if (v13) {
                v14 = v11 + @as(f64, 1.0);
                v23 = v14;
            } else {
                v15 = v12 < @as(f64, 0.5);
                if (v15) {
                    v23 = v11;
                } else {
                    v16 = v11 / @as(f64, 2.0);
                    v17 = @floor(v16);
                    v18 = v17 * @as(f64, 2.0);
                    v19 = v18 == v11;
                    if (v19) {
                        v23 = v11;
                    } else {
                        v20 = v11 + @as(f64, 1.0);
                        v23 = v20;
                    }
                }
            }
            v24 = v23 != @as(f64, 3.0);
            if (v24) {
                return @as(i32, 3);
            } else {
                v25 = @floor(v1);
                v26 = v1 - v25;
                v27 = v26 > @as(f64, 0.5);
                if (v27) {
                    v28 = v25 + @as(f64, 1.0);
                    v37 = v28;
                } else {
                    v29 = v26 < @as(f64, 0.5);
                    if (v29) {
                        v37 = v25;
                    } else {
                        v30 = v25 / @as(f64, 2.0);
                        v31 = @floor(v30);
                        v32 = v31 * @as(f64, 2.0);
                        v33 = v32 == v25;
                        if (v33) {
                            v37 = v25;
                        } else {
                            v34 = v25 + @as(f64, 1.0);
                            v37 = v34;
                        }
                    }
                }
                v38 = v37 != @as(f64, 3.0);
                if (v38) {
                    return @as(i32, 4);
                } else {
                    v39 = @floor(v2);
                    v40 = v2 - v39;
                    v41 = v40 > @as(f64, 0.5);
                    if (v41) {
                        v42 = v39 + @as(f64, 1.0);
                        v51 = v42;
                    } else {
                        v43 = v40 < @as(f64, 0.5);
                        if (v43) {
                            v51 = v39;
                        } else {
                            v44 = v39 / @as(f64, 2.0);
                            v45 = @floor(v44);
                            v46 = v45 * @as(f64, 2.0);
                            v47 = v46 == v39;
                            if (v47) {
                                v51 = v39;
                            } else {
                                v48 = v39 + @as(f64, 1.0);
                                v51 = v48;
                            }
                        }
                    }
                    v52 = v51 != @as(f64, -2.0);
                    if (v52) {
                        return @as(i32, 5);
                    } else {
                        v53 = @floor(v3);
                        v54 = v3 - v53;
                        v55 = v54 > @as(f64, 0.5);
                        if (v55) {
                            v56 = v53 + @as(f64, 1.0);
                            v65 = v56;
                        } else {
                            v57 = v54 < @as(f64, 0.5);
                            if (v57) {
                                v65 = v53;
                            } else {
                                v58 = v53 / @as(f64, 2.0);
                                v59 = @floor(v58);
                                v60 = v59 * @as(f64, 2.0);
                                v61 = v60 == v53;
                                if (v61) {
                                    v65 = v53;
                                } else {
                                    v62 = v53 + @as(f64, 1.0);
                                    v65 = v62;
                                }
                            }
                        }
                        v66 = v65 != @as(f64, 4.0);
                        if (v66) {
                            return @as(i32, 6);
                        } else {
                            v67 = @floor(v4);
                            v68 = v4 - v67;
                            v69 = v68 > @as(f64, 0.5);
                            if (v69) {
                                v70 = v67 + @as(f64, 1.0);
                                v79 = v70;
                            } else {
                                v71 = v68 < @as(f64, 0.5);
                                if (v71) {
                                    v79 = v67;
                                } else {
                                    v72 = v67 / @as(f64, 2.0);
                                    v73 = @floor(v72);
                                    v74 = v73 * @as(f64, 2.0);
                                    v75 = v74 == v67;
                                    if (v75) {
                                        v79 = v67;
                                    } else {
                                        v76 = v67 + @as(f64, 1.0);
                                        v79 = v76;
                                    }
                                }
                            }
                            v80 = v79 != @as(f64, 0.0);
                            if (v80) {
                                return @as(i32, 7);
                            } else {
                                v81 = std.math.atan2(v5, v5);
                                v82 = v81 * @as(f64, 1000.0);
                                v83 = @floor(v82);
                                v84 = v83 != @as(f64, 785.0);
                                if (v84) {
                                    return @as(i32, 8);
                                } else {
                                    v85 = @floor(v6);
                                    v86 = v85 != @as(f32, 2.0);
                                    if (v86) {
                                        return @as(i32, 9);
                                    } else {
                                        return @as(i32, 0);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
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
