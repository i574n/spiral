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
    var v0: i32 = undefined; _ = &v0;
    var v1: []const u8 = undefined; _ = &v1;
    var v2: []const u8 = undefined; _ = &v2;
    var v3: []const u8 = undefined; _ = &v3;
    var v4: []const u8 = undefined; _ = &v4;
    var v5: []const u8 = undefined; _ = &v5;
    var v6: []const u8 = undefined; _ = &v6;
    var v7: []const u8 = undefined; _ = &v7;
    var v8: []const u8 = undefined; _ = &v8;
    var v9: []const u8 = undefined; _ = &v9;
    var v10: []const u8 = undefined; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: u8 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v15: i32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v19: u8 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: u8 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: u8 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: u8 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: u8 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: u8 = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: u8 = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    var v35: i32 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v37: u8 = undefined; _ = &v37;
    var v38: bool = undefined; _ = &v38;
    var v39: u8 = undefined; _ = &v39;
    var v40: bool = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v42: i32 = undefined; _ = &v42;
    var v43: bool = undefined; _ = &v43;
    var v44: i32 = undefined; _ = &v44;
    var v45: bool = undefined; _ = &v45;
    var v46: u8 = undefined; _ = &v46;
    var v47: bool = undefined; _ = &v47;
    var v48: i32 = undefined; _ = &v48;
    var v49: bool = undefined; _ = &v49;
    var v50: u8 = undefined; _ = &v50;
    var v51: bool = undefined; _ = &v51;
    var v52: i32 = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v54: u8 = undefined; _ = &v54;
    var v55: bool = undefined; _ = &v55;
    var v56: u8 = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: u8 = undefined; _ = &v58;
    var v59: bool = undefined; _ = &v59;
    var v60: u8 = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v62: i32 = undefined; _ = &v62;
    var v63: bool = undefined; _ = &v63;
    var v64: u8 = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    v0 = @as(i32, 16);
    v1 = "x\ny";
    v2 = "say \"hi\"";
    v3 = "a \"\"\" b";
    v4 = "first\n    second\n\nthird";
    v5 = "ab\ncd";
    v6 = "a \"b\" c";
    v7 = "";
    v8 = "a\\nb";
    v9 = "first\n(* not a comment *)\n// nor this\n\n$\"not a macro\" !x\ninl fake () = 1\n  indented";
    v10 = "\ntop\n\nlevel";
    v11 = @as(i32, @intCast(v6.len));
    v12 = v11 != @as(i32, 7);
    if (v12) {
        return @as(i32, 1);
    } else {
        v13 = v6[spiralIndex(v6.len, @as(i32, 2))];
        v14 = v13 != @as(u8, 34);
        if (v14) {
            return @as(i32, 2);
        } else {
            v15 = @as(i32, @intCast(v7.len));
            v16 = v15 != @as(i32, 0);
            if (v16) {
                return @as(i32, 3);
            } else {
                v17 = @as(i32, @intCast(v8.len));
                v18 = v17 != @as(i32, 4);
                if (v18) {
                    return @as(i32, 4);
                } else {
                    v19 = v8[spiralIndex(v8.len, @as(i32, 1))];
                    v20 = v19 != @as(u8, 92);
                    if (v20) {
                        return @as(i32, 5);
                    } else {
                        v21 = @as(i32, @intCast(v9.len));
                        v22 = v21 != @as(i32, 83);
                        if (v22) {
                            return @as(i32, 6);
                        } else {
                            v23 = v9[spiralIndex(v9.len, @as(i32, 5))];
                            v24 = v23 != @as(u8, 10);
                            if (v24) {
                                return @as(i32, 7);
                            } else {
                                v25 = v9[spiralIndex(v9.len, @as(i32, 37))];
                                v26 = v25 != @as(u8, 10);
                                if (v26) {
                                    return @as(i32, 8);
                                } else {
                                    v27 = v9[spiralIndex(v9.len, @as(i32, 38))];
                                    v28 = v27 != @as(u8, 10);
                                    if (v28) {
                                        return @as(i32, 9);
                                    } else {
                                        v29 = v9[spiralIndex(v9.len, @as(i32, 39))];
                                        v30 = v29 != @as(u8, 36);
                                        if (v30) {
                                            return @as(i32, 10);
                                        } else {
                                            v31 = v9[spiralIndex(v9.len, @as(i32, 57))];
                                            v32 = v31 != @as(u8, 105);
                                            if (v32) {
                                                return @as(i32, 11);
                                            } else {
                                                v33 = v9[spiralIndex(v9.len, @as(i32, 82))];
                                                v34 = v33 != @as(u8, 100);
                                                if (v34) {
                                                    return @as(i32, 12);
                                                } else {
                                                    v35 = @as(i32, @intCast(v10.len));
                                                    v36 = v35 != @as(i32, 11);
                                                    if (v36) {
                                                        return @as(i32, 13);
                                                    } else {
                                                        v37 = v10[spiralIndex(v10.len, @as(i32, 0))];
                                                        v38 = v37 != @as(u8, 10);
                                                        if (v38) {
                                                            return @as(i32, 14);
                                                        } else {
                                                            v39 = v10[spiralIndex(v10.len, @as(i32, 5))];
                                                            v40 = v39 != @as(u8, 10);
                                                            if (v40) {
                                                                return @as(i32, 15);
                                                            } else {
                                                                v41 = v0 != @as(i32, 16);
                                                                if (v41) {
                                                                    return @as(i32, 16);
                                                                } else {
                                                                    v42 = @as(i32, @intCast(v1.len));
                                                                    v43 = v42 != @as(i32, 3);
                                                                    if (v43) {
                                                                        return @as(i32, 17);
                                                                    } else {
                                                                        v44 = @as(i32, @intCast(v2.len));
                                                                        v45 = v44 != @as(i32, 8);
                                                                        if (v45) {
                                                                            return @as(i32, 18);
                                                                        } else {
                                                                            v46 = v2[spiralIndex(v2.len, @as(i32, 7))];
                                                                            v47 = v46 != @as(u8, 34);
                                                                            if (v47) {
                                                                                return @as(i32, 19);
                                                                            } else {
                                                                                v48 = @as(i32, @intCast(v3.len));
                                                                                v49 = v48 != @as(i32, 7);
                                                                                if (v49) {
                                                                                    return @as(i32, 20);
                                                                                } else {
                                                                                    v50 = v3[spiralIndex(v3.len, @as(i32, 4))];
                                                                                    v51 = v50 != @as(u8, 34);
                                                                                    if (v51) {
                                                                                        return @as(i32, 21);
                                                                                    } else {
                                                                                        v52 = @as(i32, @intCast(v4.len));
                                                                                        v53 = v52 != @as(i32, 23);
                                                                                        if (v53) {
                                                                                            return @as(i32, 22);
                                                                                        } else {
                                                                                            v54 = v4[spiralIndex(v4.len, @as(i32, 6))];
                                                                                            v55 = v54 != @as(u8, 32);
                                                                                            if (v55) {
                                                                                                return @as(i32, 23);
                                                                                            } else {
                                                                                                v56 = v4[spiralIndex(v4.len, @as(i32, 10))];
                                                                                                v57 = v56 != @as(u8, 115);
                                                                                                if (v57) {
                                                                                                    return @as(i32, 24);
                                                                                                } else {
                                                                                                    v58 = v4[spiralIndex(v4.len, @as(i32, 17))];
                                                                                                    v59 = v58 != @as(u8, 10);
                                                                                                    if (v59) {
                                                                                                        return @as(i32, 25);
                                                                                                    } else {
                                                                                                        v60 = v4[spiralIndex(v4.len, @as(i32, 22))];
                                                                                                        v61 = v60 != @as(u8, 100);
                                                                                                        if (v61) {
                                                                                                            return @as(i32, 26);
                                                                                                        } else {
                                                                                                            v62 = @as(i32, @intCast(v5.len));
                                                                                                            v63 = v62 != @as(i32, 5);
                                                                                                            if (v63) {
                                                                                                                return @as(i32, 27);
                                                                                                            } else {
                                                                                                                v64 = v5[spiralIndex(v5.len, @as(i32, 3))];
                                                                                                                v65 = v64 != @as(u8, 99);
                                                                                                                if (v65) {
                                                                                                                    return @as(i32, 28);
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
