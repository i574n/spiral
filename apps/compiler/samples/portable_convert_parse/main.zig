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
const US0 = struct { tag: i32, c0_0: i32 = undefined };
fn US0_Some(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_None() US0 {
    return US0{ .tag = 1 };
}
fn spiralMain() i32 {
    var v13: bool = undefined; _ = &v13;
    var v10: bool = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v16: US0 = undefined; _ = &v16;
    var v18: []const u8 = undefined; _ = &v18;
    var v17: i32 = undefined; _ = &v17;
    var v26: bool = undefined; _ = &v26;
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v29: US0 = undefined; _ = &v29;
    var v31: []const u8 = undefined; _ = &v31;
    var v30: i32 = undefined; _ = &v30;
    var v39: bool = undefined; _ = &v39;
    var v36: bool = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    var v42: US0 = undefined; _ = &v42;
    var v44: []const u8 = undefined; _ = &v44;
    var v43: i32 = undefined; _ = &v43;
    var v52: bool = undefined; _ = &v52;
    var v49: bool = undefined; _ = &v49;
    var v50: bool = undefined; _ = &v50;
    var v55: US0 = undefined; _ = &v55;
    var v57: []const u8 = undefined; _ = &v57;
    var v56: i32 = undefined; _ = &v56;
    const v0: []const u8 = "ff";
    const v1: i32 = (std.fmt.parseInt(i32, std.mem.trim(u8, v0, " \t\r\n"), @intCast(@as(i32, 16))) catch 0);
    spiralPrintAny(v1);
    spiralPrint(&[_]u8{10});
    const v2: []const u8 = "1011";
    const v3: i32 = (std.fmt.parseInt(i32, std.mem.trim(u8, v2, " \t\r\n"), @intCast(@as(i32, 2))) catch 0);
    spiralPrintAny(v3);
    spiralPrint(&[_]u8{10});
    const v4: []const u8 = "-42";
    const v5: i32 = (std.fmt.parseInt(i32, std.mem.trim(u8, v4, " \t\r\n"), @intCast(@as(i32, 10))) catch 0);
    spiralPrintAny(v5);
    spiralPrint(&[_]u8{10});
    const v6: []const u8 = " 123 ";
    const v7: bool = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v6, " \t\r\n"), 10)) |_| true else |_| false);
    const v8: i64 = (std.fmt.parseInt(i64, std.mem.trim(u8, v6, " \t\r\n"), 10) catch 0);
    const v9: i32 = spiralConv(i32, v8);
    if (v7) {
        v10 = v8 >= @as(i64, -2147483648);
        if (v10) {
            v11 = v8 <= @as(i64, 2147483647);
            v13 = v11;
        } else {
            v13 = false;
        }
    } else {
        v13 = false;
    }
    if (v13) {
        v16 = US0_Some(v9);
    } else {
        v16 = US0_None();
    }
    switch (v16.tag) {
        1 => {
            v18 = "none";
            spiralPrintAny(v18);
            spiralPrint(&[_]u8{10});
        },
        0 => {
            v17 = v16.c0_0;
            spiralPrintAny(v17);
            spiralPrint(&[_]u8{10});
        },
        else => unreachable,
    }
    const v19: []const u8 = "12x";
    const v20: bool = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v19, " \t\r\n"), 10)) |_| true else |_| false);
    const v21: i64 = (std.fmt.parseInt(i64, std.mem.trim(u8, v19, " \t\r\n"), 10) catch 0);
    const v22: i32 = spiralConv(i32, v21);
    if (v20) {
        v23 = v21 >= @as(i64, -2147483648);
        if (v23) {
            v24 = v21 <= @as(i64, 2147483647);
            v26 = v24;
        } else {
            v26 = false;
        }
    } else {
        v26 = false;
    }
    if (v26) {
        v29 = US0_Some(v22);
    } else {
        v29 = US0_None();
    }
    switch (v29.tag) {
        1 => {
            v31 = "none";
            spiralPrintAny(v31);
            spiralPrint(&[_]u8{10});
        },
        0 => {
            v30 = v29.c0_0;
            spiralPrintAny(v30);
            spiralPrint(&[_]u8{10});
        },
        else => unreachable,
    }
    const v32: []const u8 = "";
    const v33: bool = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v32, " \t\r\n"), 10)) |_| true else |_| false);
    const v34: i64 = (std.fmt.parseInt(i64, std.mem.trim(u8, v32, " \t\r\n"), 10) catch 0);
    const v35: i32 = spiralConv(i32, v34);
    if (v33) {
        v36 = v34 >= @as(i64, -2147483648);
        if (v36) {
            v37 = v34 <= @as(i64, 2147483647);
            v39 = v37;
        } else {
            v39 = false;
        }
    } else {
        v39 = false;
    }
    if (v39) {
        v42 = US0_Some(v35);
    } else {
        v42 = US0_None();
    }
    switch (v42.tag) {
        1 => {
            v44 = "none";
            spiralPrintAny(v44);
            spiralPrint(&[_]u8{10});
        },
        0 => {
            v43 = v42.c0_0;
            spiralPrintAny(v43);
            spiralPrint(&[_]u8{10});
        },
        else => unreachable,
    }
    const v45: []const u8 = "+7";
    const v46: bool = (if (std.fmt.parseInt(i64, std.mem.trim(u8, v45, " \t\r\n"), 10)) |_| true else |_| false);
    const v47: i64 = (std.fmt.parseInt(i64, std.mem.trim(u8, v45, " \t\r\n"), 10) catch 0);
    const v48: i32 = spiralConv(i32, v47);
    if (v46) {
        v49 = v47 >= @as(i64, -2147483648);
        if (v49) {
            v50 = v47 <= @as(i64, 2147483647);
            v52 = v50;
        } else {
            v52 = false;
        }
    } else {
        v52 = false;
    }
    if (v52) {
        v55 = US0_Some(v48);
    } else {
        v55 = US0_None();
    }
    switch (v55.tag) {
        1 => {
            v57 = "none";
            spiralPrintAny(v57);
            spiralPrint(&[_]u8{10});
        },
        0 => {
            v56 = v55.c0_0;
            spiralPrintAny(v56);
            spiralPrint(&[_]u8{10});
        },
        else => unreachable,
    }
    return @as(i32, 0);
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
