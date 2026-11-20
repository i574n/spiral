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
    var v13: i32 = undefined; _ = &v13;
    var v16: i32 = undefined; _ = &v16;
    var v20: i32 = undefined; _ = &v20;
    var v24: i32 = undefined; _ = &v24;
    var v28: i32 = undefined; _ = &v28;
    var v32: i32 = undefined; _ = &v32;
    var v36: i32 = undefined; _ = &v36;
    var v40: i32 = undefined; _ = &v40;
    var v44: i32 = undefined; _ = &v44;
    var v48: i32 = undefined; _ = &v48;
    var v52: i32 = undefined; _ = &v52;
    var v56: i32 = undefined; _ = &v56;
    var v60: i32 = undefined; _ = &v60;
    var v64: i32 = undefined; _ = &v64;
    var v68: i32 = undefined; _ = &v68;
    const v0: i8 = @as(i8, -128);
    const v1: i16 = @as(i16, -32768);
    const v2: i32 = @as(i32, -5);
    const v3: i64 = @as(i64, -1234567890123);
    const v4: u8 = @as(u8, 255);
    const v5: u16 = @as(u16, 65535);
    const v6: u32 = @as(u32, 4294967295);
    const v7: u64 = @as(u64, 18446744073709551615);
    const v8: bool = true;
    const v9: bool = false;
    const v10: u8 = @as(u8, 97);
    const v11: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v0}) catch @panic("out of memory"));
    const v12: bool = std.mem.eql(u8, v11, "-128");
    if (v12) {
        v13 = @as(i32, 0);
    } else {
        v13 = @as(i32, 1);
    }
    const v14: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v1}) catch @panic("out of memory"));
    const v15: bool = std.mem.eql(u8, v14, "-32768");
    if (v15) {
        v16 = @as(i32, 0);
    } else {
        v16 = @as(i32, 1);
    }
    const v17: i32 = v13 +% v16;
    const v18: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v2}) catch @panic("out of memory"));
    const v19: bool = std.mem.eql(u8, v18, "-5");
    if (v19) {
        v20 = @as(i32, 0);
    } else {
        v20 = @as(i32, 1);
    }
    const v21: i32 = v17 +% v20;
    const v22: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v3}) catch @panic("out of memory"));
    const v23: bool = std.mem.eql(u8, v22, "-1234567890123");
    if (v23) {
        v24 = @as(i32, 0);
    } else {
        v24 = @as(i32, 1);
    }
    const v25: i32 = v21 +% v24;
    const v26: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v4}) catch @panic("out of memory"));
    const v27: bool = std.mem.eql(u8, v26, "255");
    if (v27) {
        v28 = @as(i32, 0);
    } else {
        v28 = @as(i32, 1);
    }
    const v29: i32 = v25 +% v28;
    const v30: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v5}) catch @panic("out of memory"));
    const v31: bool = std.mem.eql(u8, v30, "65535");
    if (v31) {
        v32 = @as(i32, 0);
    } else {
        v32 = @as(i32, 1);
    }
    const v33: i32 = v29 +% v32;
    const v34: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v6}) catch @panic("out of memory"));
    const v35: bool = std.mem.eql(u8, v34, "4294967295");
    if (v35) {
        v36 = @as(i32, 0);
    } else {
        v36 = @as(i32, 1);
    }
    const v37: i32 = v33 +% v36;
    const v38: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{v7}) catch @panic("out of memory"));
    const v39: bool = std.mem.eql(u8, v38, "18446744073709551615");
    if (v39) {
        v40 = @as(i32, 0);
    } else {
        v40 = @as(i32, 1);
    }
    const v41: i32 = v37 +% v40;
    const v42: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{}", .{v8}) catch @panic("out of memory"));
    const v43: bool = std.mem.eql(u8, v42, "true");
    if (v43) {
        v44 = @as(i32, 0);
    } else {
        v44 = @as(i32, 1);
    }
    const v45: i32 = v41 +% v44;
    const v46: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{}", .{v9}) catch @panic("out of memory"));
    const v47: bool = std.mem.eql(u8, v46, "false");
    if (v47) {
        v48 = @as(i32, 0);
    } else {
        v48 = @as(i32, 1);
    }
    const v49: i32 = v45 +% v48;
    const v50: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{c}", .{v10}) catch @panic("out of memory"));
    const v51: bool = std.mem.eql(u8, v50, "a");
    if (v51) {
        v52 = @as(i32, 0);
    } else {
        v52 = @as(i32, 1);
    }
    const v53: i32 = v49 +% v52;
    const v54: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{@as(u8, 7)}) catch @panic("out of memory"));
    const v55: bool = std.mem.eql(u8, v54, "7");
    if (v55) {
        v56 = @as(i32, 0);
    } else {
        v56 = @as(i32, 1);
    }
    const v57: i32 = v53 +% v56;
    const v58: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{}", .{false}) catch @panic("out of memory"));
    const v59: bool = std.mem.eql(u8, v58, "false");
    if (v59) {
        v60 = @as(i32, 0);
    } else {
        v60 = @as(i32, 1);
    }
    const v61: i32 = v57 +% v60;
    const v62: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{c}", .{@as(u8, 122)}) catch @panic("out of memory"));
    const v63: bool = std.mem.eql(u8, v62, "z");
    if (v63) {
        v64 = @as(i32, 0);
    } else {
        v64 = @as(i32, 1);
    }
    const v65: i32 = v61 +% v64;
    const v66: []const u8 = (std.fmt.allocPrint(spiral_gpa, "{d}", .{@as(i64, -3)}) catch @panic("out of memory"));
    const v67: bool = std.mem.eql(u8, v66, "-3");
    if (v67) {
        v68 = @as(i32, 0);
    } else {
        v68 = @as(i32, 1);
    }
    const v69: i32 = v65 +% v68;
    return v69;
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
