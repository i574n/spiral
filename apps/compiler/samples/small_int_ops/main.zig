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
    var v27: bool = undefined; _ = &v27;
    var v26: bool = undefined; _ = &v26;
    var v29: bool = undefined; _ = &v29;
    var v28: bool = undefined; _ = &v28;
    var v31: bool = undefined; _ = &v31;
    var v30: bool = undefined; _ = &v30;
    var v33: bool = undefined; _ = &v33;
    var v32: bool = undefined; _ = &v32;
    var v35: bool = undefined; _ = &v35;
    var v34: bool = undefined; _ = &v34;
    var v37: bool = undefined; _ = &v37;
    var v36: bool = undefined; _ = &v36;
    var v39: bool = undefined; _ = &v39;
    var v38: bool = undefined; _ = &v38;
    var v41: bool = undefined; _ = &v41;
    var v40: bool = undefined; _ = &v40;
    var v43: bool = undefined; _ = &v43;
    var v42: bool = undefined; _ = &v42;
    var v45: bool = undefined; _ = &v45;
    var v44: bool = undefined; _ = &v44;
    var v47: bool = undefined; _ = &v47;
    var v46: bool = undefined; _ = &v46;
    var v49: bool = undefined; _ = &v49;
    var v48: bool = undefined; _ = &v48;
    var v51: bool = undefined; _ = &v51;
    var v50: bool = undefined; _ = &v50;
    var v53: bool = undefined; _ = &v53;
    var v52: bool = undefined; _ = &v52;
    const v0: i8 = @as(i8, 100);
    const v1: i8 = @as(i8, 3);
    const v2: i8 = v0 *% v1;
    const v3: i8 = @as(i8, -8);
    const v4: i8 = @as(i8, 2);
    const v5: i8 = @divTrunc(v3, v4);
    const v6: i8 = @rem(v3, v1);
    const v7: i8 = -%v1;
    const v8: i8 = std.math.shl(@TypeOf(v0), v0, @as(i32, 1));
    const v9: u8 = @as(u8, 200);
    const v10: u8 = @as(u8, 3);
    const v11: u8 = @divTrunc(v9, v10);
    const v12: u8 = @rem(v9, v10);
    const v13: u8 = @as(u8, 15);
    const v14: u8 = v9 & v13;
    const v15: u8 = v9 | v13;
    const v16: u8 = v9 ^ v13;
    const v17: u8 = ~v13;
    const v18: i16 = @as(i16, 20000);
    const v19: i16 = @as(i16, 7);
    const v20: i16 = @divTrunc(v18, v19);
    const v21: i16 = @rem(v18, v19);
    const v22: i16 = -%v18;
    const v23: u16 = @as(u16, 40000);
    const v24: u16 = std.math.shl(@TypeOf(v23), v23, @as(i32, 1));
    const v25: bool = v2 == @as(i8, 44);
    if (v25) {
        v26 = v5 == @as(i8, -4);
        v27 = v26;
    } else {
        v27 = false;
    }
    if (v27) {
        v28 = v6 == @as(i8, -2);
        v29 = v28;
    } else {
        v29 = false;
    }
    if (v29) {
        v30 = v7 == @as(i8, -3);
        v31 = v30;
    } else {
        v31 = false;
    }
    if (v31) {
        v32 = v8 == @as(i8, -56);
        v33 = v32;
    } else {
        v33 = false;
    }
    if (v33) {
        v34 = v11 == @as(u8, 66);
        v35 = v34;
    } else {
        v35 = false;
    }
    if (v35) {
        v36 = v12 == @as(u8, 2);
        v37 = v36;
    } else {
        v37 = false;
    }
    if (v37) {
        v38 = v14 == @as(u8, 8);
        v39 = v38;
    } else {
        v39 = false;
    }
    if (v39) {
        v40 = v15 == @as(u8, 207);
        v41 = v40;
    } else {
        v41 = false;
    }
    if (v41) {
        v42 = v16 == @as(u8, 199);
        v43 = v42;
    } else {
        v43 = false;
    }
    if (v43) {
        v44 = v17 == @as(u8, 240);
        v45 = v44;
    } else {
        v45 = false;
    }
    if (v45) {
        v46 = v20 == @as(i16, 2857);
        v47 = v46;
    } else {
        v47 = false;
    }
    if (v47) {
        v48 = v21 == @as(i16, 1);
        v49 = v48;
    } else {
        v49 = false;
    }
    if (v49) {
        v50 = v22 == @as(i16, -20000);
        v51 = v50;
    } else {
        v51 = false;
    }
    if (v51) {
        v52 = v24 == @as(u16, 14464);
        v53 = v52;
    } else {
        v53 = false;
    }
    if (v53) {
        return @as(i32, 0);
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
