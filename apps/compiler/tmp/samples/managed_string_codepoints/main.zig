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
fn runtime_byte_0(p0: []const u8, p1: i32) u8 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    const v2: u8 = v0[spiralIndex(v0.len, v1)];
    return v2;
}
fn codepoint_length_loop_1(p0: []const u8, p1: u8, p2: u8, p3: i32, p4: i32, p5: i32) i32 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: u8 = p1; _ = &v1;
    var v2: u8 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: i32 = p5; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v7: u8 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v10: bool = undefined; _ = &v10;
    var v9: bool = undefined; _ = &v9;
    var v12: i32 = undefined; _ = &v12;
    var v11: i32 = undefined; _ = &v11;
    var v13: i32 = undefined; _ = &v13;
    while (true) {
        v6 = v3 == v5;
        if (v6) {
            return v4;
        } else {
            v7 = v0[spiralIndex(v0.len, v3)];
            v8 = v7 < v1;
            if (v8) {
                v10 = false;
            } else {
                v9 = v7 < v2;
                v10 = v9;
            }
            if (v10) {
                v12 = v4;
            } else {
                v11 = v4 +% @as(i32, 1);
                v12 = v11;
            }
            v13 = v3 +% @as(i32, 1);
            v3 = v13;
            v4 = v12;
            continue;
        }
    }
}
fn codepoint_byte_offset_loop_2(p0: []const u8, p1: u8, p2: u8, p3: i32, p4: i32, p5: i32, p6: i32) i32 {
    var v0: []const u8 = p0; _ = &v0;
    var v1: u8 = p1; _ = &v1;
    var v2: u8 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: i32 = p5; _ = &v5;
    var v6: i32 = p6; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v8: u8 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: bool = undefined; _ = &v11;
    var v10: bool = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    var v14: bool = undefined; _ = &v14;
    var v15: i32 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    while (true) {
        v7 = v4 == v6;
        if (v7) {
            return v6;
        } else {
            v8 = v0[spiralIndex(v0.len, v4)];
            v9 = v8 < v1;
            if (v9) {
                v11 = false;
            } else {
                v10 = v8 < v2;
                v11 = v10;
            }
            if (v11) {
                v12 = v4 +% @as(i32, 1);
                v4 = v12;
                continue;
            } else {
                v14 = v5 == v3;
                if (v14) {
                    return v4;
                } else {
                    v15 = v4 +% @as(i32, 1);
                    v16 = v5 +% @as(i32, 1);
                    v4 = v15;
                    v5 = v16;
                    continue;
                }
            }
        }
    }
}
fn spiralMain() i32 {
    var v91: i32 = undefined; _ = &v91;
    var v92: bool = undefined; _ = &v92;
    var v93: bool = undefined; _ = &v93;
    var v94: i32 = undefined; _ = &v94;
    var v95: bool = undefined; _ = &v95;
    var v96: bool = undefined; _ = &v96;
    var v97: i32 = undefined; _ = &v97;
    var v98: bool = undefined; _ = &v98;
    var v99: bool = undefined; _ = &v99;
    const v0: []const u8 = "\xc3\x80";
    const v1: i32 = @as(i32, 1);
    const v2: u8 = runtime_byte_0(v0, v1);
    const v3: []const u8 = "\xc2\xa9";
    const v4: i32 = @as(i32, 0);
    const v5: u8 = runtime_byte_0(v3, v4);
    const v6: []const u8 = "A\xc3\xa9\xce\xbb\xf0\x9f\x99\x82Z";
    const v7: i32 = @as(i32, 0);
    const v8: i32 = @as(i32, 0);
    const v9: i32 = @as(i32, 10);
    const v10: i32 = codepoint_length_loop_1(v6, v2, v5, v7, v8, v9);
    const v11: i32 = @as(i32, 1);
    const v12: u8 = runtime_byte_0(v0, v11);
    const v13: i32 = @as(i32, 0);
    const v14: u8 = runtime_byte_0(v3, v13);
    const v15: i32 = @as(i32, 1);
    const v16: i32 = @as(i32, 0);
    const v17: i32 = @as(i32, 0);
    const v18: i32 = @as(i32, 10);
    const v19: i32 = codepoint_byte_offset_loop_2(v6, v12, v14, v15, v16, v17, v18);
    const v20: i32 = @as(i32, 1);
    const v21: u8 = runtime_byte_0(v0, v20);
    const v22: i32 = @as(i32, 0);
    const v23: u8 = runtime_byte_0(v3, v22);
    const v24: i32 = @as(i32, 2);
    const v25: i32 = @as(i32, 0);
    const v26: i32 = @as(i32, 0);
    const v27: i32 = @as(i32, 10);
    const v28: i32 = codepoint_byte_offset_loop_2(v6, v21, v23, v24, v25, v26, v27);
    const v29: i32 = v28 -% @as(i32, 1);
    const v30: []const u8 = spiralStringSlice("A\xc3\xa9\xce\xbb\xf0\x9f\x99\x82Z", @as(i64, v19), @as(i64, v29));
    const v31: i32 = @as(i32, 1);
    const v32: u8 = runtime_byte_0(v0, v31);
    const v33: i32 = @as(i32, 0);
    const v34: u8 = runtime_byte_0(v3, v33);
    const v35: i32 = @as(i32, 3);
    const v36: i32 = @as(i32, 0);
    const v37: i32 = @as(i32, 0);
    const v38: i32 = @as(i32, 10);
    const v39: i32 = codepoint_byte_offset_loop_2(v6, v32, v34, v35, v36, v37, v38);
    const v40: i32 = @as(i32, 1);
    const v41: u8 = runtime_byte_0(v0, v40);
    const v42: i32 = @as(i32, 0);
    const v43: u8 = runtime_byte_0(v3, v42);
    const v44: i32 = @as(i32, 4);
    const v45: i32 = @as(i32, 0);
    const v46: i32 = @as(i32, 0);
    const v47: i32 = @as(i32, 10);
    const v48: i32 = codepoint_byte_offset_loop_2(v6, v41, v43, v44, v45, v46, v47);
    const v49: i32 = v48 -% @as(i32, 1);
    const v50: []const u8 = spiralStringSlice("A\xc3\xa9\xce\xbb\xf0\x9f\x99\x82Z", @as(i64, v39), @as(i64, v49));
    const v51: i32 = @as(i32, 1);
    const v52: u8 = runtime_byte_0(v0, v51);
    const v53: i32 = @as(i32, 0);
    const v54: u8 = runtime_byte_0(v3, v53);
    const v55: i32 = @as(i32, 1);
    const v56: i32 = @as(i32, 0);
    const v57: i32 = @as(i32, 0);
    const v58: i32 = @as(i32, 10);
    const v59: i32 = codepoint_byte_offset_loop_2(v6, v52, v54, v55, v56, v57, v58);
    const v60: i32 = @as(i32, 1);
    const v61: u8 = runtime_byte_0(v0, v60);
    const v62: i32 = @as(i32, 0);
    const v63: u8 = runtime_byte_0(v3, v62);
    const v64: i32 = @as(i32, 4);
    const v65: i32 = @as(i32, 0);
    const v66: i32 = @as(i32, 0);
    const v67: i32 = @as(i32, 10);
    const v68: i32 = codepoint_byte_offset_loop_2(v6, v61, v63, v64, v65, v66, v67);
    const v69: i32 = v68 -% @as(i32, 1);
    const v70: []const u8 = spiralStringSlice("A\xc3\xa9\xce\xbb\xf0\x9f\x99\x82Z", @as(i64, v59), @as(i64, v69));
    const v71: i32 = @as(i32, 1);
    const v72: u8 = runtime_byte_0(v0, v71);
    const v73: i32 = @as(i32, 0);
    const v74: u8 = runtime_byte_0(v3, v73);
    const v75: i32 = @as(i32, 3);
    const v76: i32 = @as(i32, 0);
    const v77: i32 = @as(i32, 0);
    const v78: i32 = @as(i32, 10);
    const v79: i32 = codepoint_byte_offset_loop_2(v6, v72, v74, v75, v76, v77, v78);
    const v80: i32 = @as(i32, 0);
    const v81: u8 = runtime_byte_0(v30, v80);
    const v82: []const u8 = "\xc3\xa9";
    const v83: i32 = @as(i32, 0);
    const v84: u8 = runtime_byte_0(v82, v83);
    const v85: i32 = @as(i32, 3);
    const v86: u8 = runtime_byte_0(v50, v85);
    const v87: []const u8 = "\xf0\x9f\x99\x82";
    const v88: i32 = @as(i32, 3);
    const v89: u8 = runtime_byte_0(v87, v88);
    const v90: bool = v10 == @as(i32, 5);
    if (v90) {
        v91 = @as(i32, @intCast(v30.len));
        v92 = v91 == @as(i32, 2);
        if (v92) {
            v93 = v81 == v84;
            if (v93) {
                v94 = @as(i32, @intCast(v50.len));
                v95 = v94 == @as(i32, 4);
                if (v95) {
                    v96 = v86 == v89;
                    if (v96) {
                        v97 = @as(i32, @intCast(v70.len));
                        v98 = v97 == @as(i32, 8);
                        if (v98) {
                            v99 = v79 == @as(i32, 5);
                            if (v99) {
                                return @as(i32, 0);
                            } else {
                                return @as(i32, 1);
                            }
                        } else {
                            return @as(i32, 2);
                        }
                    } else {
                        return @as(i32, 3);
                    }
                } else {
                    return @as(i32, 4);
                }
            } else {
                return @as(i32, 5);
            }
        } else {
            return @as(i32, 6);
        }
    } else {
        return @as(i32, 7);
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
