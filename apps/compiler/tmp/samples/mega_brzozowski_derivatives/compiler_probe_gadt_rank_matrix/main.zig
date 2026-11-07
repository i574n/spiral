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
const US0 = struct { tag: i32, c0_0: i32 = undefined };
const US1 = struct { tag: i32, c0_0: i32 = undefined, c0_1: bool = undefined };
const US2 = struct { tag: i32, c0_0: i32 = undefined };
const US3 = struct { tag: i32, c0_0: bool = undefined, c0_1: i32 = undefined };
const US4 = struct { tag: i32, c0_0: i32 = undefined };
const US5 = struct { tag: i32, c0_0: i32 = undefined, c0_1: bool = undefined };
const US6 = struct { tag: i32, c0_0: bool = undefined };
fn US0_RawA(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn US1_DecidedA(a0: i32, a1: bool) US1 {
    return US1{ .tag = 0, .c0_0 = a0, .c0_1 = a1 };
}
fn decide_a_0(p0: US0) US1 {
    var v0: US0 = p0; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return US1_DecidedA(v1, true);
        },
        else => unreachable,
    }
}
fn US2_RawB(a0: i32) US2 {
    return US2{ .tag = 0, .c0_0 = a0 };
}
fn US3_DecidedB(a0: bool, a1: i32) US3 {
    return US3{ .tag = 0, .c0_0 = a0, .c0_1 = a1 };
}
fn decide_b_1(p0: US2) US3 {
    var v0: US2 = p0; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return US3_DecidedB(true, v1);
        },
        else => unreachable,
    }
}
fn US4_RawC(a0: i32) US4 {
    return US4{ .tag = 0, .c0_0 = a0 };
}
fn US5_DecidedC(a0: i32, a1: bool) US5 {
    return US5{ .tag = 0, .c0_0 = a0, .c0_1 = a1 };
}
fn decide_c_2(p0: US4) US5 {
    var v0: US4 = p0; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return US5_DecidedC(v1, true);
        },
        else => unreachable,
    }
}
fn US6_FinalC(a0: bool) US6 {
    return US6{ .tag = 0, .c0_0 = a0 };
}
fn finalize_c_3(p0: US5) US6 {
    var v0: US5 = p0; _ = &v0;
    var v1: i32 = undefined; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return US6_FinalC(v2);
        },
        else => unreachable,
    }
}
fn spiralMainValue() bool {
    var v12: bool = undefined; _ = &v12;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v15: bool = undefined; _ = &v15;
    var v13: bool = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v17: bool = undefined; _ = &v17;
    var v16: bool = undefined; _ = &v16;
    const v0: i32 = @as(i32, 7);
    const v1: US0 = US0_RawA(v0);
    const v2: US1 = decide_a_0(v1);
    const v3: i32 = @as(i32, 9);
    const v4: US2 = US2_RawB(v3);
    const v5: US3 = decide_b_1(v4);
    const v6: i32 = @as(i32, 11);
    const v7: US4 = US4_RawC(v6);
    const v8: US5 = decide_c_2(v7);
    const v9: US6 = finalize_c_3(v8);
    switch (v2.tag) {
        0 => {
            v10 = v2.c0_0;
            v11 = v2.c0_1;
            v12 = v11;
        },
        else => unreachable,
    }
    switch (v5.tag) {
        0 => {
            v13 = v5.c0_0;
            v14 = v5.c0_1;
            v15 = v13;
        },
        else => unreachable,
    }
    switch (v9.tag) {
        0 => {
            v16 = v9.c0_0;
            v17 = v16;
        },
        else => unreachable,
    }
    const v18: bool = (v12 and v15);
    const v19: bool = (v18 and v17);
    return v19;
}
fn spiralMain() i32 {
    _ = spiralMainValue();
    return 0;
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
