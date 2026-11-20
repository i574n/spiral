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
const US0 = struct { tag: i32, c1_0: f64 = undefined, c1_1: f64 = undefined, c1_2: f64 = undefined };
fn method0(p0: i32) bool {
    var v0: i32 = p0; _ = &v0;
    const v1: bool = v0 < @as(i32, 3);
    return v1;
}
fn method1(p0: i32) bool {
    var v0: i32 = p0; _ = &v0;
    const v1: bool = v0 < @as(i32, 7040);
    return v1;
}
fn US0_Hidden() US0 {
    return US0{ .tag = 0 };
}
fn US0_Visible(a0: f64, a1: f64, a2: f64) US0 {
    return US0{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 };
}
fn method2(p0: []i32, p1: f64, p2: f64, p3: f64) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: f64 = p1; _ = &v1;
    var v2: f64 = p2; _ = &v2;
    var v3: f64 = p3; _ = &v3;
    var v50: bool = undefined; _ = &v50;
    var v49: bool = undefined; _ = &v49;
    var v52: bool = undefined; _ = &v52;
    var v51: bool = undefined; _ = &v51;
    var v54: bool = undefined; _ = &v54;
    var v53: bool = undefined; _ = &v53;
    var v57: US0 = undefined; _ = &v57;
    var v58: f64 = undefined; _ = &v58;
    var v59: f64 = undefined; _ = &v59;
    var v60: f64 = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v63: bool = undefined; _ = &v63;
    var v62: bool = undefined; _ = &v62;
    var v65: bool = undefined; _ = &v65;
    var v64: bool = undefined; _ = &v64;
    var v66: i32 = undefined; _ = &v66;
    var v67: i32 = undefined; _ = &v67;
    var v68: i32 = undefined; _ = &v68;
    var v69: i32 = undefined; _ = &v69;
    const v4: f64 = @sin(v1);
    const v5: f64 = @as(f64, 20.0) * v4;
    const v6: f64 = @sin(v2);
    const v7: f64 = v5 * v6;
    const v8: f64 = @cos(v3);
    const v9: f64 = v7 * v8;
    const v10: f64 = @cos(v1);
    const v11: f64 = @as(f64, -20.0) * v10;
    const v12: f64 = v11 * v6;
    const v13: f64 = v12 * v8;
    const v14: f64 = v9 - v13;
    const v15: f64 = @as(f64, 20.0) * v10;
    const v16: f64 = @sin(v3);
    const v17: f64 = v15 * v16;
    const v18: f64 = v14 + v17;
    const v19: f64 = @as(f64, -20.0) * v4;
    const v20: f64 = v19 * v16;
    const v21: f64 = v18 + v20;
    const v22: f64 = @cos(v2);
    const v23: f64 = @as(f64, 20.0) * v22;
    const v24: f64 = v23 * v8;
    const v25: f64 = v21 + v24;
    const v26: f64 = v15 * v8;
    const v27: f64 = v19 * v8;
    const v28: f64 = v26 + v27;
    const v29: f64 = v7 * v16;
    const v30: f64 = v28 - v29;
    const v31: f64 = v12 * v16;
    const v32: f64 = v30 + v31;
    const v33: f64 = v23 * v16;
    const v34: f64 = v32 - v33;
    const v35: f64 = v11 * v22;
    const v36: f64 = v5 * v22;
    const v37: f64 = v35 - v36;
    const v38: f64 = @as(f64, 20.0) * v6;
    const v39: f64 = v37 + v38;
    const v40: f64 = v39 + @as(f64, 100.0);
    const v41: f64 = @as(f64, 1.0) / v40;
    const v42: f64 = @as(f64, 40.0) * v41;
    const v43: f64 = v42 * v25;
    const v44: f64 = v43 * @as(f64, 2.0);
    const v45: f64 = @as(f64, 40.0) + v44;
    const v46: f64 = v42 * v34;
    const v47: f64 = @as(f64, 22.0) + v46;
    const v48: bool = v45 >= @as(f64, 0.0);
    if (v48) {
        v49 = v45 < @as(f64, 160.0);
        v50 = v49;
    } else {
        v50 = false;
    }
    if (v50) {
        v51 = v47 >= @as(f64, 0.0);
        v52 = v51;
    } else {
        v52 = false;
    }
    if (v52) {
        v53 = v47 < @as(f64, 44.0);
        v54 = v53;
    } else {
        v54 = false;
    }
    if (v54) {
        v57 = US0_Visible(v45, v47, v41);
    } else {
        v57 = US0_Hidden();
    }
    switch (v57.tag) {
        1 => {
            v58 = v57.c1_0;
            v59 = v57.c1_1;
            v60 = v57.c1_2;
            v61 = v58 >= @as(f64, 0.0);
            if (v61) {
                v62 = v59 >= @as(f64, 0.0);
                v63 = v62;
            } else {
                v63 = false;
            }
            if (v63) {
                v64 = v60 > @as(f64, 0.0);
                v65 = v64;
            } else {
                v65 = false;
            }
            if (v65) {
                v66 = spiralConv(i32, v58);
                v67 = spiralConv(i32, v59);
                v68 = v67 *% @as(i32, 160);
                v69 = v66 +% v68;
                v0[spiralIndex(v0.len, v69)] = @as(i32, 35);
                return v69;
            } else {
                return @as(i32, 0);
            }
        },
        else => {
            return @as(i32, 0);
        },
    }
}
fn method3(p0: []i32, p1: f64, p2: f64, p3: f64) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: f64 = p1; _ = &v1;
    var v2: f64 = p2; _ = &v2;
    var v3: f64 = p3; _ = &v3;
    var v50: bool = undefined; _ = &v50;
    var v49: bool = undefined; _ = &v49;
    var v52: bool = undefined; _ = &v52;
    var v51: bool = undefined; _ = &v51;
    var v54: bool = undefined; _ = &v54;
    var v53: bool = undefined; _ = &v53;
    var v57: US0 = undefined; _ = &v57;
    var v58: f64 = undefined; _ = &v58;
    var v59: f64 = undefined; _ = &v59;
    var v60: f64 = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v63: bool = undefined; _ = &v63;
    var v62: bool = undefined; _ = &v62;
    var v65: bool = undefined; _ = &v65;
    var v64: bool = undefined; _ = &v64;
    var v66: i32 = undefined; _ = &v66;
    var v67: i32 = undefined; _ = &v67;
    var v68: i32 = undefined; _ = &v68;
    var v69: i32 = undefined; _ = &v69;
    const v4: f64 = @sin(v1);
    const v5: f64 = @as(f64, 10.0) * v4;
    const v6: f64 = @sin(v2);
    const v7: f64 = v5 * v6;
    const v8: f64 = @cos(v3);
    const v9: f64 = v7 * v8;
    const v10: f64 = @cos(v1);
    const v11: f64 = @as(f64, -10.0) * v10;
    const v12: f64 = v11 * v6;
    const v13: f64 = v12 * v8;
    const v14: f64 = v9 - v13;
    const v15: f64 = @as(f64, 10.0) * v10;
    const v16: f64 = @sin(v3);
    const v17: f64 = v15 * v16;
    const v18: f64 = v14 + v17;
    const v19: f64 = @as(f64, -10.0) * v4;
    const v20: f64 = v19 * v16;
    const v21: f64 = v18 + v20;
    const v22: f64 = @cos(v2);
    const v23: f64 = @as(f64, 10.0) * v22;
    const v24: f64 = v23 * v8;
    const v25: f64 = v21 + v24;
    const v26: f64 = v15 * v8;
    const v27: f64 = v19 * v8;
    const v28: f64 = v26 + v27;
    const v29: f64 = v7 * v16;
    const v30: f64 = v28 - v29;
    const v31: f64 = v12 * v16;
    const v32: f64 = v30 + v31;
    const v33: f64 = v23 * v16;
    const v34: f64 = v32 - v33;
    const v35: f64 = v11 * v22;
    const v36: f64 = v5 * v22;
    const v37: f64 = v35 - v36;
    const v38: f64 = @as(f64, 10.0) * v6;
    const v39: f64 = v37 + v38;
    const v40: f64 = v39 + @as(f64, 100.0);
    const v41: f64 = @as(f64, 1.0) / v40;
    const v42: f64 = @as(f64, 40.0) * v41;
    const v43: f64 = v42 * v25;
    const v44: f64 = v43 * @as(f64, 2.0);
    const v45: f64 = @as(f64, 90.0) + v44;
    const v46: f64 = v42 * v34;
    const v47: f64 = @as(f64, 22.0) + v46;
    const v48: bool = v45 >= @as(f64, 0.0);
    if (v48) {
        v49 = v45 < @as(f64, 160.0);
        v50 = v49;
    } else {
        v50 = false;
    }
    if (v50) {
        v51 = v47 >= @as(f64, 0.0);
        v52 = v51;
    } else {
        v52 = false;
    }
    if (v52) {
        v53 = v47 < @as(f64, 44.0);
        v54 = v53;
    } else {
        v54 = false;
    }
    if (v54) {
        v57 = US0_Visible(v45, v47, v41);
    } else {
        v57 = US0_Hidden();
    }
    switch (v57.tag) {
        1 => {
            v58 = v57.c1_0;
            v59 = v57.c1_1;
            v60 = v57.c1_2;
            v61 = v58 >= @as(f64, 0.0);
            if (v61) {
                v62 = v59 >= @as(f64, 0.0);
                v63 = v62;
            } else {
                v63 = false;
            }
            if (v63) {
                v64 = v60 > @as(f64, 0.0);
                v65 = v64;
            } else {
                v65 = false;
            }
            if (v65) {
                v66 = spiralConv(i32, v58);
                v67 = spiralConv(i32, v59);
                v68 = v67 *% @as(i32, 160);
                v69 = v66 +% v68;
                v0[spiralIndex(v0.len, v69)] = @as(i32, 64);
                return v69;
            } else {
                return @as(i32, 0);
            }
        },
        else => {
            return @as(i32, 0);
        },
    }
}
fn method4(p0: []i32, p1: f64, p2: f64, p3: f64) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: f64 = p1; _ = &v1;
    var v2: f64 = p2; _ = &v2;
    var v3: f64 = p3; _ = &v3;
    var v50: bool = undefined; _ = &v50;
    var v49: bool = undefined; _ = &v49;
    var v52: bool = undefined; _ = &v52;
    var v51: bool = undefined; _ = &v51;
    var v54: bool = undefined; _ = &v54;
    var v53: bool = undefined; _ = &v53;
    var v57: US0 = undefined; _ = &v57;
    var v58: f64 = undefined; _ = &v58;
    var v59: f64 = undefined; _ = &v59;
    var v60: f64 = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v63: bool = undefined; _ = &v63;
    var v62: bool = undefined; _ = &v62;
    var v65: bool = undefined; _ = &v65;
    var v64: bool = undefined; _ = &v64;
    var v66: i32 = undefined; _ = &v66;
    var v67: i32 = undefined; _ = &v67;
    var v68: i32 = undefined; _ = &v68;
    var v69: i32 = undefined; _ = &v69;
    const v4: f64 = @sin(v1);
    const v5: f64 = @as(f64, 5.0) * v4;
    const v6: f64 = @sin(v2);
    const v7: f64 = v5 * v6;
    const v8: f64 = @cos(v3);
    const v9: f64 = v7 * v8;
    const v10: f64 = @cos(v1);
    const v11: f64 = @as(f64, -5.0) * v10;
    const v12: f64 = v11 * v6;
    const v13: f64 = v12 * v8;
    const v14: f64 = v9 - v13;
    const v15: f64 = @as(f64, 5.0) * v10;
    const v16: f64 = @sin(v3);
    const v17: f64 = v15 * v16;
    const v18: f64 = v14 + v17;
    const v19: f64 = @as(f64, -5.0) * v4;
    const v20: f64 = v19 * v16;
    const v21: f64 = v18 + v20;
    const v22: f64 = @cos(v2);
    const v23: f64 = @as(f64, 5.0) * v22;
    const v24: f64 = v23 * v8;
    const v25: f64 = v21 + v24;
    const v26: f64 = v15 * v8;
    const v27: f64 = v19 * v8;
    const v28: f64 = v26 + v27;
    const v29: f64 = v7 * v16;
    const v30: f64 = v28 - v29;
    const v31: f64 = v12 * v16;
    const v32: f64 = v30 + v31;
    const v33: f64 = v23 * v16;
    const v34: f64 = v32 - v33;
    const v35: f64 = v11 * v22;
    const v36: f64 = v5 * v22;
    const v37: f64 = v35 - v36;
    const v38: f64 = @as(f64, 5.0) * v6;
    const v39: f64 = v37 + v38;
    const v40: f64 = v39 + @as(f64, 100.0);
    const v41: f64 = @as(f64, 1.0) / v40;
    const v42: f64 = @as(f64, 40.0) * v41;
    const v43: f64 = v42 * v25;
    const v44: f64 = v43 * @as(f64, 2.0);
    const v45: f64 = @as(f64, 120.0) + v44;
    const v46: f64 = v42 * v34;
    const v47: f64 = @as(f64, 22.0) + v46;
    const v48: bool = v45 >= @as(f64, 0.0);
    if (v48) {
        v49 = v45 < @as(f64, 160.0);
        v50 = v49;
    } else {
        v50 = false;
    }
    if (v50) {
        v51 = v47 >= @as(f64, 0.0);
        v52 = v51;
    } else {
        v52 = false;
    }
    if (v52) {
        v53 = v47 < @as(f64, 44.0);
        v54 = v53;
    } else {
        v54 = false;
    }
    if (v54) {
        v57 = US0_Visible(v45, v47, v41);
    } else {
        v57 = US0_Hidden();
    }
    switch (v57.tag) {
        1 => {
            v58 = v57.c1_0;
            v59 = v57.c1_1;
            v60 = v57.c1_2;
            v61 = v58 >= @as(f64, 0.0);
            if (v61) {
                v62 = v59 >= @as(f64, 0.0);
                v63 = v62;
            } else {
                v63 = false;
            }
            if (v63) {
                v64 = v60 > @as(f64, 0.0);
                v65 = v64;
            } else {
                v65 = false;
            }
            if (v65) {
                v66 = spiralConv(i32, v58);
                v67 = spiralConv(i32, v59);
                v68 = v67 *% @as(i32, 160);
                v69 = v66 +% v68;
                v0[spiralIndex(v0.len, v69)] = @as(i32, 43);
                return v69;
            } else {
                return @as(i32, 0);
            }
        },
        else => {
            return @as(i32, 0);
        },
    }
}
fn frame_text_loop_5(p0: []i32, p1: i32, p2: i32, p3: i32, p4: []const u8) []const u8 {
    var v0: []i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: []const u8 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v16: []const u8 = undefined; _ = &v16;
    var v8: []const u8 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: []const u8 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: []const u8 = undefined; _ = &v12;
    var v13: []const u8 = undefined; _ = &v13;
    var v17: []const u8 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v23: bool = undefined; _ = &v23;
    var v22: bool = undefined; _ = &v22;
    var v24: []const u8 = undefined; _ = &v24;
    while (true) {
        v5 = v3 == v2;
        if (v5) {
            return v4;
        } else {
            v6 = v0[spiralIndex(v0.len, v3)];
            v7 = v6 == @as(i32, 35);
            if (v7) {
                v8 = "#";
                v16 = v8;
            } else {
                v9 = v6 == @as(i32, 43);
                if (v9) {
                    v10 = "+";
                    v16 = v10;
                } else {
                    v11 = v6 == @as(i32, 64);
                    if (v11) {
                        v12 = "@";
                        v16 = v12;
                    } else {
                        v13 = ".";
                        v16 = v13;
                    }
                }
            }
            v17 = spiralConcat(v4, v16);
            v18 = v3 +% @as(i32, 1);
            v19 = @rem(v3, v1);
            v20 = v1 -% @as(i32, 1);
            v21 = v19 == v20;
            if (v21) {
                v22 = v18 < v2;
                v23 = v22;
            } else {
                v23 = false;
            }
            if (v23) {
                v24 = spiralConcat(v17, "\n");
                v3 = v18;
                v4 = v24;
                continue;
            } else {
                v3 = v18;
                v4 = v17;
                continue;
            }
        }
    }
}
fn runtime_byte_8(p0: []const u8, p1: i32) u8 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: u8 = v0[spiralIndex(v0.len, v1)];
    return v2;
}
fn utf8_scalar_at_byte_offset_7(p0: []const u8, p1: i32) i32 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v5: bool = undefined; _ = &v5;
    var v7: u8 = undefined; _ = &v7;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: u8 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: bool = undefined; _ = &v20;
    var v19: bool = undefined; _ = &v19;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v23: i32 = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v28: bool = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v32: i32 = undefined; _ = &v32;
    var v33: u8 = undefined; _ = &v33;
    var v34: i32 = undefined; _ = &v34;
    var v35: u8 = undefined; _ = &v35;
    var v36: i32 = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v39: bool = undefined; _ = &v39;
    var v38: bool = undefined; _ = &v38;
    var v40: bool = undefined; _ = &v40;
    var v42: bool = undefined; _ = &v42;
    var v41: bool = undefined; _ = &v41;
    var v43: i32 = undefined; _ = &v43;
    var v44: i32 = undefined; _ = &v44;
    var v45: i32 = undefined; _ = &v45;
    var v46: i32 = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    var v48: i32 = undefined; _ = &v48;
    var v49: i32 = undefined; _ = &v49;
    var v50: bool = undefined; _ = &v50;
    var v52: bool = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v63: bool = undefined; _ = &v63;
    var v64: i32 = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    var v67: i32 = undefined; _ = &v67;
    var v68: u8 = undefined; _ = &v68;
    var v69: i32 = undefined; _ = &v69;
    var v70: i32 = undefined; _ = &v70;
    var v71: u8 = undefined; _ = &v71;
    var v72: i32 = undefined; _ = &v72;
    var v73: u8 = undefined; _ = &v73;
    var v74: i32 = undefined; _ = &v74;
    var v75: bool = undefined; _ = &v75;
    var v77: bool = undefined; _ = &v77;
    var v76: bool = undefined; _ = &v76;
    var v78: bool = undefined; _ = &v78;
    var v80: bool = undefined; _ = &v80;
    var v79: bool = undefined; _ = &v79;
    var v81: bool = undefined; _ = &v81;
    var v83: bool = undefined; _ = &v83;
    var v82: bool = undefined; _ = &v82;
    var v84: i32 = undefined; _ = &v84;
    var v85: i32 = undefined; _ = &v85;
    var v86: i32 = undefined; _ = &v86;
    var v87: i32 = undefined; _ = &v87;
    var v88: i32 = undefined; _ = &v88;
    var v89: i32 = undefined; _ = &v89;
    var v90: i32 = undefined; _ = &v90;
    var v91: i32 = undefined; _ = &v91;
    var v92: i32 = undefined; _ = &v92;
    var v93: i32 = undefined; _ = &v93;
    var v94: bool = undefined; _ = &v94;
    var v96: bool = undefined; _ = &v96;
    const v2: i32 = @as(i32, @intCast(v0.len));
    const v3: bool = v1 < @as(i32, 0);
    if (v3) {
        spiralFail("UTF-8 byte offset is negative.");
    } else {
        v5 = v1 >= v2;
        if (v5) {
            spiralFail("UTF-8 byte offset is outside the string.");
        } else {
            v7 = runtime_byte_8(v0, v1);
            v8 = @as(i32, v7);
            v9 = v8 < @as(i32, 128);
            if (v9) {
                return v8;
            } else {
                v10 = v8 < @as(i32, 194);
                if (v10) {
                    spiralFail("UTF-8 scalar starts with an invalid lead byte.");
                } else {
                    v12 = v8 < @as(i32, 224);
                    if (v12) {
                        v13 = v1 +% @as(i32, 1);
                        v14 = v13 >= v2;
                        if (v14) {
                            spiralFail("UTF-8 sequence is truncated.");
                        } else {
                            v16 = runtime_byte_8(v0, v13);
                            v17 = @as(i32, v16);
                            v18 = v17 < @as(i32, 128);
                            if (v18) {
                                v20 = false;
                            } else {
                                v19 = v17 < @as(i32, 192);
                                v20 = v19;
                            }
                            if (v20) {
                                v21 = v8 -% @as(i32, 192);
                                v22 = v21 *% @as(i32, 64);
                                v23 = v17 -% @as(i32, 128);
                                v24 = v22 +% v23;
                                return v24;
                            } else {
                                spiralFail("UTF-8 sequence has an invalid continuation byte.");
                            }
                        }
                    } else {
                        v28 = v8 < @as(i32, 240);
                        if (v28) {
                            v29 = v1 +% @as(i32, 2);
                            v30 = v29 >= v2;
                            if (v30) {
                                spiralFail("UTF-8 sequence is truncated.");
                            } else {
                                v32 = v1 +% @as(i32, 1);
                                v33 = runtime_byte_8(v0, v32);
                                v34 = @as(i32, v33);
                                v35 = runtime_byte_8(v0, v29);
                                v36 = @as(i32, v35);
                                v37 = v34 < @as(i32, 128);
                                if (v37) {
                                    v39 = false;
                                } else {
                                    v38 = v34 < @as(i32, 192);
                                    v39 = v38;
                                }
                                if (v39) {
                                    v40 = v36 < @as(i32, 128);
                                    if (v40) {
                                        v42 = false;
                                    } else {
                                        v41 = v36 < @as(i32, 192);
                                        v42 = v41;
                                    }
                                    if (v42) {
                                        v43 = v8 -% @as(i32, 224);
                                        v44 = v43 *% @as(i32, 4096);
                                        v45 = v34 -% @as(i32, 128);
                                        v46 = v45 *% @as(i32, 64);
                                        v47 = v44 +% v46;
                                        v48 = v36 -% @as(i32, 128);
                                        v49 = v47 +% v48;
                                        v50 = v49 < @as(i32, 2048);
                                        if (v50) {
                                            spiralFail("UTF-8 sequence is overlong.");
                                        } else {
                                            v52 = v49 >= @as(i32, 55296);
                                            if (v52) {
                                                v53 = v49 <= @as(i32, 57343);
                                                if (v53) {
                                                    spiralFail("UTF-8 sequence encodes a surrogate.");
                                                } else {
                                                    return v49;
                                                }
                                            } else {
                                                return v49;
                                            }
                                        }
                                    } else {
                                        spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                } else {
                                    spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                }
                            }
                        } else {
                            v63 = v8 < @as(i32, 245);
                            if (v63) {
                                v64 = v1 +% @as(i32, 3);
                                v65 = v64 >= v2;
                                if (v65) {
                                    spiralFail("UTF-8 sequence is truncated.");
                                } else {
                                    v67 = v1 +% @as(i32, 1);
                                    v68 = runtime_byte_8(v0, v67);
                                    v69 = @as(i32, v68);
                                    v70 = v1 +% @as(i32, 2);
                                    v71 = runtime_byte_8(v0, v70);
                                    v72 = @as(i32, v71);
                                    v73 = runtime_byte_8(v0, v64);
                                    v74 = @as(i32, v73);
                                    v75 = v69 < @as(i32, 128);
                                    if (v75) {
                                        v77 = false;
                                    } else {
                                        v76 = v69 < @as(i32, 192);
                                        v77 = v76;
                                    }
                                    if (v77) {
                                        v78 = v72 < @as(i32, 128);
                                        if (v78) {
                                            v80 = false;
                                        } else {
                                            v79 = v72 < @as(i32, 192);
                                            v80 = v79;
                                        }
                                        if (v80) {
                                            v81 = v74 < @as(i32, 128);
                                            if (v81) {
                                                v83 = false;
                                            } else {
                                                v82 = v74 < @as(i32, 192);
                                                v83 = v82;
                                            }
                                            if (v83) {
                                                v84 = v8 -% @as(i32, 240);
                                                v85 = v84 *% @as(i32, 262144);
                                                v86 = v69 -% @as(i32, 128);
                                                v87 = v86 *% @as(i32, 4096);
                                                v88 = v85 +% v87;
                                                v89 = v72 -% @as(i32, 128);
                                                v90 = v89 *% @as(i32, 64);
                                                v91 = v88 +% v90;
                                                v92 = v74 -% @as(i32, 128);
                                                v93 = v91 +% v92;
                                                v94 = v93 < @as(i32, 65536);
                                                if (v94) {
                                                    spiralFail("UTF-8 sequence is overlong.");
                                                } else {
                                                    v96 = v93 > @as(i32, 1114111);
                                                    if (v96) {
                                                        spiralFail("UTF-8 scalar is above U+10FFFF.");
                                                    } else {
                                                        return v93;
                                                    }
                                                }
                                            } else {
                                                spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                            }
                                        } else {
                                            spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                        }
                                    } else {
                                        spiralFail("UTF-8 sequence has an invalid continuation byte.");
                                    }
                                }
                            } else {
                                spiralFail("UTF-8 scalar starts with an invalid lead byte.");
                            }
                        }
                    }
                }
            }
        }
    }
}
fn loop_6(p0: []const u8, p1: i32, p2: i32, p3: i32) i32 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: i32 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v13: i32 = undefined; _ = &v13;
    var v9: bool = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v14: i32 = undefined; _ = &v14;
    var v15: i32 = undefined; _ = &v15;
    while (true) {
        v4 = v2 == v1;
        if (v4) {
            return v3;
        } else {
            v5 = v2 > v1;
            if (v5) {
                spiralFail("UTF-8 scalar width exceeds the string.");
            } else {
                v7 = utf8_scalar_at_byte_offset_7(v0, v2);
                v8 = v7 < @as(i32, 128);
                if (v8) {
                    v13 = @as(i32, 1);
                } else {
                    v9 = v7 < @as(i32, 2048);
                    if (v9) {
                        v13 = @as(i32, 2);
                    } else {
                        v10 = v7 < @as(i32, 65536);
                        if (v10) {
                            v13 = @as(i32, 3);
                        } else {
                            v13 = @as(i32, 4);
                        }
                    }
                }
                v14 = v2 +% v13;
                v15 = v3 +% v7;
                v2 = v14;
                v3 = v15;
                continue;
            }
        }
    }
}
fn method9(p0: i32) bool {
    var v0: i32 = p0; _ = &v0;
    const v1: bool = v0 < @as(i32, 4096);
    return v1;
}
fn spiralMain() i32 {
    var v0: []i32 = undefined; _ = &v0;
    var v1: []i32 = undefined; _ = &v1;
    var v2: i32 = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v5: bool = undefined; _ = &v5;
    var v10: f64 = undefined; _ = &v10;
    var v11: f64 = undefined; _ = &v11;
    var v12: f64 = undefined; _ = &v12;
    var v6: bool = undefined; _ = &v6;
    var v13: i32 = undefined; _ = &v13;
    var v15: i32 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: []const u8 = undefined; _ = &v22;
    var v23: []const u8 = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: []const u8 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    var v31: i32 = undefined; _ = &v31;
    var v32: i32 = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v35: bool = undefined; _ = &v35;
    var v34: bool = undefined; _ = &v34;
    var v36: i32 = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v38: i32 = undefined; _ = &v38;
    var v39: i32 = undefined; _ = &v39;
    var v41: i32 = undefined; _ = &v41;
    var v42: i32 = undefined; _ = &v42;
    var v43: i32 = undefined; _ = &v43;
    var v44: i32 = undefined; _ = &v44;
    var v45: i32 = undefined; _ = &v45;
    var v46: i32 = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    var v53: bool = undefined; _ = &v53;
    var v52: bool = undefined; _ = &v52;
    var v55: bool = undefined; _ = &v55;
    var v54: bool = undefined; _ = &v54;
    var v57: bool = undefined; _ = &v57;
    var v56: bool = undefined; _ = &v56;
    v0 = spiralNewArray(i32, @as(i32, 7040));
    v1 = spiralNewArray(i32, @as(i32, 3));
    v2 = @as(i32, 0);
    v3 = @as(i32, 0);
    while (method0(v3)) {
        v5 = v3 == @as(i32, 0);
        if (v5) {
            v10 = @as(f64, 0.0);
            v11 = @as(f64, 0.0);
            v12 = @as(f64, 0.0);
        } else {
            v6 = v3 == @as(i32, 1);
            if (v6) {
                v10 = @as(f64, 0.1);
                v11 = @as(f64, 0.05);
                v12 = @as(f64, 0.02);
            } else {
                v10 = @as(f64, 0.2);
                v11 = @as(f64, 0.1);
                v12 = @as(f64, 0.04);
            }
        }
        v13 = @as(i32, 0);
        while (method1(v13)) {
            v0[spiralIndex(v0.len, v13)] = @as(i32, 46);
            v15 = v13 +% @as(i32, 1);
            v13 = v15;
        }
        v16 = method2(v0, v10, v11, v12);
        v17 = method3(v0, v10, v11, v12);
        v18 = method4(v0, v10, v11, v12);
        v19 = @as(i32, 160);
        v20 = @as(i32, 7040);
        v21 = @as(i32, 0);
        v22 = "";
        v23 = frame_text_loop_5(v0, v19, v20, v21, v22);
        v24 = @as(i32, @intCast(v23.len));
        v25 = @as(i32, 0);
        v26 = @as(i32, 0);
        v27 = loop_6(v23, v24, v25, v26);
        v28 = spiralConcat("\x1b[H", v23);
        _ = spiralPrintAny(v28);
        v29 = v17 *% @as(i32, 3);
        v30 = v16 +% v29;
        v31 = v18 *% @as(i32, 7);
        v32 = v30 +% v31;
        v33 = v24 == @as(i32, 7083);
        if (v33) {
            v34 = v27 == @as(i32, 324274);
            v35 = v34;
        } else {
            v35 = false;
        }
        if (v35) {
            v36 = v32;
        } else {
            v36 = @as(i32, 0);
        }
        v1[spiralIndex(v1.len, v3)] = v36;
        v37 = v3 < @as(i32, 2);
        if (v37) {
            v38 = @as(i32, 0);
            v39 = v3 +% @as(i32, 1);
            while (method9(v38)) {
                v41 = @rem(v38, @as(i32, 17));
                v42 = v39 +% v41;
                v43 = v42 +% @as(i32, 1);
                v44 = @rem(v43, @as(i32, 997));
                v39 = v44;
                v45 = v38 +% @as(i32, 1);
                v38 = v45;
            }
            v46 = v2 +% v39;
            v2 = v46;
        } else {
        }
        v47 = v3 +% @as(i32, 1);
        v3 = v47;
    }
    const v48: i32 = v1[spiralIndex(v1.len, @as(i32, 0))];
    const v49: i32 = v1[spiralIndex(v1.len, @as(i32, 1))];
    const v50: i32 = v1[spiralIndex(v1.len, @as(i32, 2))];
    const v51: bool = v48 == @as(i32, 45702);
    if (v51) {
        v52 = v49 == @as(i32, 43786);
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
        v54 = v50 == @as(i32, 43631);
        v55 = v54;
    } else {
        v55 = false;
    }
    if (v55) {
        v56 = v2 == @as(i32, 1931);
        v57 = v56;
    } else {
        v57 = false;
    }
    if (v57) {
        return @as(i32, 42);
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
