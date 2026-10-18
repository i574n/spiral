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
    var v13: bool = undefined; _ = &v13;
    var v14: u8 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: u8 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: u8 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: u8 = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    var v35: u8 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v38: u8 = undefined; _ = &v38;
    var v39: bool = undefined; _ = &v39;
    var v40: bool = undefined; _ = &v40;
    var v41: u8 = undefined; _ = &v41;
    var v42: bool = undefined; _ = &v42;
    var v43: bool = undefined; _ = &v43;
    var v44: u8 = undefined; _ = &v44;
    var v45: bool = undefined; _ = &v45;
    var v46: bool = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    var v48: bool = undefined; _ = &v48;
    var v49: bool = undefined; _ = &v49;
    var v50: u8 = undefined; _ = &v50;
    var v51: bool = undefined; _ = &v51;
    var v52: bool = undefined; _ = &v52;
    var v53: u8 = undefined; _ = &v53;
    var v54: bool = undefined; _ = &v54;
    var v55: bool = undefined; _ = &v55;
    var v56: bool = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: i32 = undefined; _ = &v58;
    var v59: bool = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v61: i32 = undefined; _ = &v61;
    var v62: bool = undefined; _ = &v62;
    var v63: bool = undefined; _ = &v63;
    var v64: u8 = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    var v66: bool = undefined; _ = &v66;
    var v67: i32 = undefined; _ = &v67;
    var v68: bool = undefined; _ = &v68;
    var v69: bool = undefined; _ = &v69;
    var v70: u8 = undefined; _ = &v70;
    var v71: bool = undefined; _ = &v71;
    var v72: bool = undefined; _ = &v72;
    var v73: i32 = undefined; _ = &v73;
    var v74: bool = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v76: u8 = undefined; _ = &v76;
    var v77: bool = undefined; _ = &v77;
    var v78: bool = undefined; _ = &v78;
    var v79: u8 = undefined; _ = &v79;
    var v80: bool = undefined; _ = &v80;
    var v81: bool = undefined; _ = &v81;
    var v82: u8 = undefined; _ = &v82;
    var v83: bool = undefined; _ = &v83;
    var v84: bool = undefined; _ = &v84;
    var v85: u8 = undefined; _ = &v85;
    var v86: bool = undefined; _ = &v86;
    var v87: bool = undefined; _ = &v87;
    var v88: i32 = undefined; _ = &v88;
    var v89: bool = undefined; _ = &v89;
    var v90: bool = undefined; _ = &v90;
    var v91: u8 = undefined; _ = &v91;
    var v92: bool = undefined; _ = &v92;
    var v93: bool = undefined; _ = &v93;
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
    v12 = v11 == @as(i32, 7);
    v13 = v12 != true;
    if (v13) {
        return @as(i32, 1);
    } else {
        v14 = v6[spiralIndex(v6.len, @as(i32, 2))];
        v15 = v14 == @as(u8, 34);
        v16 = v15 != true;
        if (v16) {
            return @as(i32, 2);
        } else {
            v17 = @as(i32, @intCast(v7.len));
            v18 = v17 == @as(i32, 0);
            v19 = v18 != true;
            if (v19) {
                return @as(i32, 3);
            } else {
                v20 = @as(i32, @intCast(v8.len));
                v21 = v20 == @as(i32, 4);
                v22 = v21 != true;
                if (v22) {
                    return @as(i32, 4);
                } else {
                    v23 = v8[spiralIndex(v8.len, @as(i32, 1))];
                    v24 = v23 == @as(u8, 92);
                    v25 = v24 != true;
                    if (v25) {
                        return @as(i32, 5);
                    } else {
                        v26 = @as(i32, @intCast(v9.len));
                        v27 = v26 == @as(i32, 83);
                        v28 = v27 != true;
                        if (v28) {
                            return @as(i32, 6);
                        } else {
                            v29 = v9[spiralIndex(v9.len, @as(i32, 5))];
                            v30 = v29 == @as(u8, 10);
                            v31 = v30 != true;
                            if (v31) {
                                return @as(i32, 7);
                            } else {
                                v32 = v9[spiralIndex(v9.len, @as(i32, 37))];
                                v33 = v32 == @as(u8, 10);
                                v34 = v33 != true;
                                if (v34) {
                                    return @as(i32, 8);
                                } else {
                                    v35 = v9[spiralIndex(v9.len, @as(i32, 38))];
                                    v36 = v35 == @as(u8, 10);
                                    v37 = v36 != true;
                                    if (v37) {
                                        return @as(i32, 9);
                                    } else {
                                        v38 = v9[spiralIndex(v9.len, @as(i32, 39))];
                                        v39 = v38 == @as(u8, 36);
                                        v40 = v39 != true;
                                        if (v40) {
                                            return @as(i32, 10);
                                        } else {
                                            v41 = v9[spiralIndex(v9.len, @as(i32, 57))];
                                            v42 = v41 == @as(u8, 105);
                                            v43 = v42 != true;
                                            if (v43) {
                                                return @as(i32, 11);
                                            } else {
                                                v44 = v9[spiralIndex(v9.len, @as(i32, 82))];
                                                v45 = v44 == @as(u8, 100);
                                                v46 = v45 != true;
                                                if (v46) {
                                                    return @as(i32, 12);
                                                } else {
                                                    v47 = @as(i32, @intCast(v10.len));
                                                    v48 = v47 == @as(i32, 11);
                                                    v49 = v48 != true;
                                                    if (v49) {
                                                        return @as(i32, 13);
                                                    } else {
                                                        v50 = v10[spiralIndex(v10.len, @as(i32, 0))];
                                                        v51 = v50 == @as(u8, 10);
                                                        v52 = v51 != true;
                                                        if (v52) {
                                                            return @as(i32, 14);
                                                        } else {
                                                            v53 = v10[spiralIndex(v10.len, @as(i32, 5))];
                                                            v54 = v53 == @as(u8, 10);
                                                            v55 = v54 != true;
                                                            if (v55) {
                                                                return @as(i32, 15);
                                                            } else {
                                                                v56 = v0 == @as(i32, 16);
                                                                v57 = v56 != true;
                                                                if (v57) {
                                                                    return @as(i32, 16);
                                                                } else {
                                                                    v58 = @as(i32, @intCast(v1.len));
                                                                    v59 = v58 == @as(i32, 3);
                                                                    v60 = v59 != true;
                                                                    if (v60) {
                                                                        return @as(i32, 17);
                                                                    } else {
                                                                        v61 = @as(i32, @intCast(v2.len));
                                                                        v62 = v61 == @as(i32, 8);
                                                                        v63 = v62 != true;
                                                                        if (v63) {
                                                                            return @as(i32, 18);
                                                                        } else {
                                                                            v64 = v2[spiralIndex(v2.len, @as(i32, 7))];
                                                                            v65 = v64 == @as(u8, 34);
                                                                            v66 = v65 != true;
                                                                            if (v66) {
                                                                                return @as(i32, 19);
                                                                            } else {
                                                                                v67 = @as(i32, @intCast(v3.len));
                                                                                v68 = v67 == @as(i32, 7);
                                                                                v69 = v68 != true;
                                                                                if (v69) {
                                                                                    return @as(i32, 20);
                                                                                } else {
                                                                                    v70 = v3[spiralIndex(v3.len, @as(i32, 4))];
                                                                                    v71 = v70 == @as(u8, 34);
                                                                                    v72 = v71 != true;
                                                                                    if (v72) {
                                                                                        return @as(i32, 21);
                                                                                    } else {
                                                                                        v73 = @as(i32, @intCast(v4.len));
                                                                                        v74 = v73 == @as(i32, 23);
                                                                                        v75 = v74 != true;
                                                                                        if (v75) {
                                                                                            return @as(i32, 22);
                                                                                        } else {
                                                                                            v76 = v4[spiralIndex(v4.len, @as(i32, 6))];
                                                                                            v77 = v76 == @as(u8, 32);
                                                                                            v78 = v77 != true;
                                                                                            if (v78) {
                                                                                                return @as(i32, 23);
                                                                                            } else {
                                                                                                v79 = v4[spiralIndex(v4.len, @as(i32, 10))];
                                                                                                v80 = v79 == @as(u8, 115);
                                                                                                v81 = v80 != true;
                                                                                                if (v81) {
                                                                                                    return @as(i32, 24);
                                                                                                } else {
                                                                                                    v82 = v4[spiralIndex(v4.len, @as(i32, 17))];
                                                                                                    v83 = v82 == @as(u8, 10);
                                                                                                    v84 = v83 != true;
                                                                                                    if (v84) {
                                                                                                        return @as(i32, 25);
                                                                                                    } else {
                                                                                                        v85 = v4[spiralIndex(v4.len, @as(i32, 22))];
                                                                                                        v86 = v85 == @as(u8, 100);
                                                                                                        v87 = v86 != true;
                                                                                                        if (v87) {
                                                                                                            return @as(i32, 26);
                                                                                                        } else {
                                                                                                            v88 = @as(i32, @intCast(v5.len));
                                                                                                            v89 = v88 == @as(i32, 5);
                                                                                                            v90 = v89 != true;
                                                                                                            if (v90) {
                                                                                                                return @as(i32, 27);
                                                                                                            } else {
                                                                                                                v91 = v5[spiralIndex(v5.len, @as(i32, 3))];
                                                                                                                v92 = v91 == @as(u8, 99);
                                                                                                                v93 = v92 != true;
                                                                                                                if (v93) {
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
