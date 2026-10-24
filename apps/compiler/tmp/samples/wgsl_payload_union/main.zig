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
const US0 = struct { tag: i32, c0_0: i32 = undefined, c1_0: i32 = undefined, c1_1: i32 = undefined };
fn US0_Circle(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US0_Rect(a0: i32, a1: i32) US0 {
    return US0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 };
}
fn US0_Empty() US0 {
    return US0{ .tag = 2 };
}
fn spiralMain() i32 {
    var v18: bool = undefined; _ = &v18;
    var tmp9: i32 = undefined; _ = &tmp9;
    var v8: i32 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v19: i32 = undefined; _ = &v19;
    var v28: i32 = undefined; _ = &v28;
    var v20: i32 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v23: i32 = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v37: i32 = undefined; _ = &v37;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    var v31: i32 = undefined; _ = &v31;
    var v32: i32 = undefined; _ = &v32;
    var v33: i32 = undefined; _ = &v33;
    var v34: i32 = undefined; _ = &v34;
    var v47: i32 = undefined; _ = &v47;
    var v39: i32 = undefined; _ = &v39;
    var v40: i32 = undefined; _ = &v40;
    var v41: i32 = undefined; _ = &v41;
    var v42: i32 = undefined; _ = &v42;
    var v43: i32 = undefined; _ = &v43;
    var v44: i32 = undefined; _ = &v44;
    const v0: i32 = @as(i32, 2);
    const v1: US0 = US0_Circle(v0);
    const v2: i32 = @as(i32, 3);
    const v3: i32 = @as(i32, 4);
    const v4: US0 = US0_Rect(v2, v3);
    const v5: US0 = US0_Empty();
    const v6: i32 = @as(i32, 2);
    const v7: US0 = US0_Circle(v6);
    tmp9 = if ((v1.tag == v7.tag)) v1.tag else -1;
    switch (tmp9) {
        0 => {
            v8 = v1.c0_0;
            v9 = v7.c0_0;
            v10 = v8 == v9;
            v18 = v10;
        },
        2 => {
            v18 = true;
        },
        1 => {
            v11 = v1.c1_0;
            v12 = v1.c1_1;
            v13 = v7.c1_0;
            v14 = v7.c1_1;
            v15 = v11 == v13;
            if (v15) {
                v16 = v12 == v14;
                v18 = v16;
            } else {
                v18 = false;
            }
        },
        else => {
            v18 = false;
        },
    }
    if (v18) {
        v19 = @as(i32, 100);
    } else {
        v19 = @as(i32, 0);
    }
    switch (v1.tag) {
        0 => {
            v20 = v1.c0_0;
            v21 = @as(i32, 3) *% v20;
            v22 = v21 *% v20;
            v28 = v22;
        },
        2 => {
            v28 = @as(i32, 0);
        },
        1 => {
            v23 = v1.c1_0;
            v24 = v1.c1_1;
            v25 = v23 *% v24;
            v28 = v25;
        },
        else => unreachable,
    }
    switch (v4.tag) {
        0 => {
            v29 = v4.c0_0;
            v30 = @as(i32, 3) *% v29;
            v31 = v30 *% v29;
            v37 = v31;
        },
        2 => {
            v37 = @as(i32, 0);
        },
        1 => {
            v32 = v4.c1_0;
            v33 = v4.c1_1;
            v34 = v32 *% v33;
            v37 = v34;
        },
        else => unreachable,
    }
    const v38: i32 = v28 +% v37;
    switch (v5.tag) {
        0 => {
            v39 = v5.c0_0;
            v40 = @as(i32, 3) *% v39;
            v41 = v40 *% v39;
            v47 = v41;
        },
        2 => {
            v47 = @as(i32, 0);
        },
        1 => {
            v42 = v5.c1_0;
            v43 = v5.c1_1;
            v44 = v42 *% v43;
            v47 = v44;
        },
        else => unreachable,
    }
    const v48: i32 = v38 +% v47;
    const v49: i32 = v48 +% v19;
    return v49;
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
