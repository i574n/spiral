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
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32, c0_0: i32 = undefined };
const UH0 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH0 = undefined };
fn US0_Vowel(a0: i32) US0 {
    return US0{ .tag = 0, .c0_0 = a0 };
}
fn UH0_Nil() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_Cons(a0: US0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn method0(p0: *UH0, p1: *UH0) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var tmp0: i32 = undefined; _ = &tmp0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v9: bool = undefined; _ = &v9;
    var tmp6: i32 = undefined; _ = &tmp6;
    var v6: i32 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        tmp0 = if ((v1.tag == v0.tag)) v1.tag else -1;
        switch (tmp0) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = v0.c1_0;
                v5 = v0.c1_1;
                tmp6 = if ((v2.tag == v4.tag)) v2.tag else -1;
                switch (tmp6) {
                    0 => {
                        v6 = v2.c0_0;
                        v7 = v4.c0_0;
                        v8 = v6 == v7;
                        v9 = v8;
                    },
                    else => {
                        v9 = false;
                    },
                }
                if (v9) {
                    v0 = v5;
                    v1 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => {
                return false;
            },
        }
    }
}
fn spiralMain() i32 {
    var v17: bool = undefined; _ = &v17;
    var tmp15: i32 = undefined; _ = &tmp15;
    var v14: i32 = undefined; _ = &v14;
    var v15: i32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v23: bool = undefined; _ = &v23;
    var v21: bool = undefined; _ = &v21;
    var tmp21: i32 = undefined; _ = &tmp21;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v22: bool = undefined; _ = &v22;
    var v30: bool = undefined; _ = &v30;
    var v27: bool = undefined; _ = &v27;
    var tmp28: i32 = undefined; _ = &tmp28;
    var v24: i32 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v38: bool = undefined; _ = &v38;
    var v34: bool = undefined; _ = &v34;
    var tmp34: i32 = undefined; _ = &tmp34;
    var v31: i32 = undefined; _ = &v31;
    var v32: i32 = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v36: bool = undefined; _ = &v36;
    var v37: bool = undefined; _ = &v37;
    const v0: i32 = @as(i32, 1);
    const v1: US0 = US0_Vowel(v0);
    const v2: i32 = @as(i32, 1);
    const v3: US0 = US0_Vowel(v2);
    const v4: i32 = @as(i32, 2);
    const v5: US0 = US0_Vowel(v4);
    const v6: *UH0 = UH0_Nil();
    const v7: *UH0 = UH0_Cons(v5, v6);
    const v8: *UH0 = UH0_Cons(v1, v7);
    const v9: *UH0 = UH0_Nil();
    const v10: *UH0 = UH0_Cons(v5, v9);
    const v11: *UH0 = UH0_Cons(v3, v10);
    const v12: *UH0 = UH0_Nil();
    const v13: *UH0 = UH0_Cons(v1, v12);
    tmp15 = if ((v1.tag == v3.tag)) v1.tag else -1;
    switch (tmp15) {
        0 => {
            v14 = v1.c0_0;
            v15 = v3.c0_0;
            v16 = v14 == v15;
            v17 = v16;
        },
        else => {
            v17 = false;
        },
    }
    if (v17) {
        tmp21 = if ((v1.tag == v5.tag)) v1.tag else -1;
        switch (tmp21) {
            0 => {
                v18 = v1.c0_0;
                v19 = v5.c0_0;
                v20 = v18 == v19;
                v21 = v20;
            },
            else => {
                v21 = false;
            },
        }
        v22 = v21 == false;
        v23 = v22;
    } else {
        v23 = false;
    }
    if (v23) {
        tmp28 = if ((v1.tag == v3.tag)) v1.tag else -1;
        switch (tmp28) {
            0 => {
                v24 = v1.c0_0;
                v25 = v3.c0_0;
                v26 = v24 == v25;
                v27 = v26;
            },
            else => {
                v27 = false;
            },
        }
        if (v27) {
            v30 = method0(v11, v8);
        } else {
            v30 = false;
        }
    } else {
        v30 = false;
    }
    if (v30) {
        tmp34 = if ((v1.tag == v5.tag)) v1.tag else -1;
        switch (tmp34) {
            0 => {
                v31 = v1.c0_0;
                v32 = v5.c0_0;
                v33 = v31 == v32;
                v34 = v33;
            },
            else => {
                v34 = false;
            },
        }
        if (v34) {
            v36 = method0(v13, v8);
        } else {
            v36 = false;
        }
        v37 = v36 == false;
        v38 = v37;
    } else {
        v38 = false;
    }
    if (v38) {
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
