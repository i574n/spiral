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
fn spiralPrintAny(x: anytype) void {
    const T = @TypeOf(x);
    if (T == []const u8) return spiralPrint(x);
    const s = switch (@typeInfo(T)) {
        .float => std.fmt.allocPrint(spiral_gpa, "{d}", .{x}),
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
    var v9: bool = undefined; _ = &v9;
    var v10: f64 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: f64 = undefined; _ = &v13;
    var v14: f64 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v25: f64 = undefined; _ = &v25;
    var v16: f64 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v18: f64 = undefined; _ = &v18;
    var v19: f64 = undefined; _ = &v19;
    var v20: f64 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: f64 = undefined; _ = &v22;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: f64 = undefined; _ = &v28;
    var v29: f64 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v40: f64 = undefined; _ = &v40;
    var v31: f64 = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: f64 = undefined; _ = &v33;
    var v34: f64 = undefined; _ = &v34;
    var v35: f64 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v37: f64 = undefined; _ = &v37;
    var v41: bool = undefined; _ = &v41;
    var v42: bool = undefined; _ = &v42;
    var v43: f64 = undefined; _ = &v43;
    var v44: f64 = undefined; _ = &v44;
    var v45: bool = undefined; _ = &v45;
    var v55: f64 = undefined; _ = &v55;
    var v46: f64 = undefined; _ = &v46;
    var v47: bool = undefined; _ = &v47;
    var v48: f64 = undefined; _ = &v48;
    var v49: f64 = undefined; _ = &v49;
    var v50: f64 = undefined; _ = &v50;
    var v51: bool = undefined; _ = &v51;
    var v52: f64 = undefined; _ = &v52;
    var v56: bool = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: f64 = undefined; _ = &v58;
    var v59: f64 = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v70: f64 = undefined; _ = &v70;
    var v61: f64 = undefined; _ = &v61;
    var v62: bool = undefined; _ = &v62;
    var v63: f64 = undefined; _ = &v63;
    var v64: f64 = undefined; _ = &v64;
    var v65: f64 = undefined; _ = &v65;
    var v66: bool = undefined; _ = &v66;
    var v67: f64 = undefined; _ = &v67;
    var v71: bool = undefined; _ = &v71;
    var v72: bool = undefined; _ = &v72;
    var v73: f64 = undefined; _ = &v73;
    var v74: f64 = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v85: f64 = undefined; _ = &v85;
    var v76: f64 = undefined; _ = &v76;
    var v77: bool = undefined; _ = &v77;
    var v78: f64 = undefined; _ = &v78;
    var v79: f64 = undefined; _ = &v79;
    var v80: f64 = undefined; _ = &v80;
    var v81: bool = undefined; _ = &v81;
    var v82: f64 = undefined; _ = &v82;
    var v86: bool = undefined; _ = &v86;
    var v87: bool = undefined; _ = &v87;
    var v88: f64 = undefined; _ = &v88;
    var v89: f64 = undefined; _ = &v89;
    var v90: f64 = undefined; _ = &v90;
    var v91: bool = undefined; _ = &v91;
    var v92: bool = undefined; _ = &v92;
    var v93: f32 = undefined; _ = &v93;
    var v94: bool = undefined; _ = &v94;
    var v95: bool = undefined; _ = &v95;
    v0 = @as(f64, 2.7);
    v1 = @as(f64, 3.2);
    v2 = @as(f64, -2.5);
    v3 = @as(f64, 3.5);
    v4 = @as(f64, 0.5);
    v5 = @as(f64, 1.0);
    v6 = @as(f32, 2.7);
    v7 = @floor(v0);
    v8 = v7 == @as(f64, 2.0);
    v9 = v8 != true;
    if (v9) {
        return @as(i32, 1);
    } else {
        v10 = @ceil(v0);
        v11 = v10 == @as(f64, 3.0);
        v12 = v11 != true;
        if (v12) {
            return @as(i32, 2);
        } else {
            v13 = @floor(v0);
            v14 = v0 - v13;
            v15 = v14 > @as(f64, 0.5);
            if (v15) {
                v16 = v13 + @as(f64, 1.0);
                v25 = v16;
            } else {
                v17 = v14 < @as(f64, 0.5);
                if (v17) {
                    v25 = v13;
                } else {
                    v18 = v13 / @as(f64, 2.0);
                    v19 = @floor(v18);
                    v20 = v19 * @as(f64, 2.0);
                    v21 = v20 == v13;
                    if (v21) {
                        v25 = v13;
                    } else {
                        v22 = v13 + @as(f64, 1.0);
                        v25 = v22;
                    }
                }
            }
            v26 = v25 == @as(f64, 3.0);
            v27 = v26 != true;
            if (v27) {
                return @as(i32, 3);
            } else {
                v28 = @floor(v1);
                v29 = v1 - v28;
                v30 = v29 > @as(f64, 0.5);
                if (v30) {
                    v31 = v28 + @as(f64, 1.0);
                    v40 = v31;
                } else {
                    v32 = v29 < @as(f64, 0.5);
                    if (v32) {
                        v40 = v28;
                    } else {
                        v33 = v28 / @as(f64, 2.0);
                        v34 = @floor(v33);
                        v35 = v34 * @as(f64, 2.0);
                        v36 = v35 == v28;
                        if (v36) {
                            v40 = v28;
                        } else {
                            v37 = v28 + @as(f64, 1.0);
                            v40 = v37;
                        }
                    }
                }
                v41 = v40 == @as(f64, 3.0);
                v42 = v41 != true;
                if (v42) {
                    return @as(i32, 4);
                } else {
                    v43 = @floor(v2);
                    v44 = v2 - v43;
                    v45 = v44 > @as(f64, 0.5);
                    if (v45) {
                        v46 = v43 + @as(f64, 1.0);
                        v55 = v46;
                    } else {
                        v47 = v44 < @as(f64, 0.5);
                        if (v47) {
                            v55 = v43;
                        } else {
                            v48 = v43 / @as(f64, 2.0);
                            v49 = @floor(v48);
                            v50 = v49 * @as(f64, 2.0);
                            v51 = v50 == v43;
                            if (v51) {
                                v55 = v43;
                            } else {
                                v52 = v43 + @as(f64, 1.0);
                                v55 = v52;
                            }
                        }
                    }
                    v56 = v55 == @as(f64, -2.0);
                    v57 = v56 != true;
                    if (v57) {
                        return @as(i32, 5);
                    } else {
                        v58 = @floor(v3);
                        v59 = v3 - v58;
                        v60 = v59 > @as(f64, 0.5);
                        if (v60) {
                            v61 = v58 + @as(f64, 1.0);
                            v70 = v61;
                        } else {
                            v62 = v59 < @as(f64, 0.5);
                            if (v62) {
                                v70 = v58;
                            } else {
                                v63 = v58 / @as(f64, 2.0);
                                v64 = @floor(v63);
                                v65 = v64 * @as(f64, 2.0);
                                v66 = v65 == v58;
                                if (v66) {
                                    v70 = v58;
                                } else {
                                    v67 = v58 + @as(f64, 1.0);
                                    v70 = v67;
                                }
                            }
                        }
                        v71 = v70 == @as(f64, 4.0);
                        v72 = v71 != true;
                        if (v72) {
                            return @as(i32, 6);
                        } else {
                            v73 = @floor(v4);
                            v74 = v4 - v73;
                            v75 = v74 > @as(f64, 0.5);
                            if (v75) {
                                v76 = v73 + @as(f64, 1.0);
                                v85 = v76;
                            } else {
                                v77 = v74 < @as(f64, 0.5);
                                if (v77) {
                                    v85 = v73;
                                } else {
                                    v78 = v73 / @as(f64, 2.0);
                                    v79 = @floor(v78);
                                    v80 = v79 * @as(f64, 2.0);
                                    v81 = v80 == v73;
                                    if (v81) {
                                        v85 = v73;
                                    } else {
                                        v82 = v73 + @as(f64, 1.0);
                                        v85 = v82;
                                    }
                                }
                            }
                            v86 = v85 == @as(f64, 0.0);
                            v87 = v86 != true;
                            if (v87) {
                                return @as(i32, 7);
                            } else {
                                v88 = std.math.atan2(v5, v5);
                                v89 = v88 * @as(f64, 1000.0);
                                v90 = @floor(v89);
                                v91 = v90 == @as(f64, 785.0);
                                v92 = v91 != true;
                                if (v92) {
                                    return @as(i32, 8);
                                } else {
                                    v93 = @floor(v6);
                                    v94 = v93 == @as(f32, 2.0);
                                    v95 = v94 != true;
                                    if (v95) {
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
pub fn main() void {
    spiral_gpa = spiral_arena.allocator();
    const code = spiralMain();
    spiralFlush();
    std.process.exit(@truncate(@as(u32, @bitCast(code))));
}
