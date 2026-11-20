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
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
}
fn spiralCreate(comptime T: type, v: T) *T {
    const p = spiral_gpa.create(T) catch @panic("out of memory");
    p.* = v;
    return p;
}
const US0 = struct { tag: i32 };
const UH0 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH0 = undefined };
const Tuple0 = struct { f0: *UH0, f1: u64 };
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_InputEmpty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_InputCons(a0: US0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn random_bit_input_1(p0: u64, p1: i32, p2: *UH0) Tuple0 {
    var v0: u64 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: *UH0 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: u64 = undefined; _ = &v4;
    var v5: u64 = undefined; _ = &v5;
    var v6: u64 = undefined; _ = &v6;
    var v7: i32 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var v9: u64 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v11: US0 = undefined; _ = &v11;
    var v12: US0 = undefined; _ = &v12;
    var v14: *UH0 = undefined; _ = &v14;
    while (true) {
        v3 = @as(i32, 0) < v1;
        if (v3) {
            v4 = v0 *% @as(u64, 1103515245);
            v5 = v4 +% @as(u64, 12345);
            v6 = v5 & @as(u64, 2147483647);
            v7 = v1 -% @as(i32, 1);
            v8 = std.math.shr(@TypeOf(v6), v6, @as(i32, 16));
            v9 = v8 & @as(u64, 1);
            v10 = v9 == @as(u64, 0);
            if (v10) {
                v11 = US0_BitZero();
                v13 = v11;
            } else {
                v12 = US0_BitOne();
                v13 = v12;
            }
            v14 = UH0_InputCons(v13, v2);
            v0 = v6;
            v1 = v7;
            v2 = v14;
            continue;
        } else {
            return Tuple0{ .f0 = v2, .f1 = v0 };
        }
    }
}
fn run_2(p0: i32, p1: *UH0) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v9: i32 = undefined; _ = &v9;
    var v6: i32 = undefined; _ = &v6;
    var v2: bool = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                switch (v3.tag) {
                    1 => {
                        v9 = @as(i32, 0);
                        v0 = v9;
                        v1 = v4;
                        continue;
                    },
                    0 => {
                        v6 = @as(i32, 1);
                        v0 = v6;
                        v1 = v4;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 1);
                return v2;
            },
            else => unreachable,
        }
    }
}
fn loop_0(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    while (true) {
        v4 = @as(i32, 0) < v1;
        if (v4) {
            v5 = UH0_InputEmpty();
            tmp4 = random_bit_input_1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = run_2(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = v1 -% @as(i32, 1);
            v1 = v12;
            v2 = v7;
            v3 = v11;
            continue;
        } else {
            return v3;
        }
    }
}
fn run_4(p0: i32, p1: *UH0) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH0 = undefined; _ = &v18;
    var v50: bool = undefined; _ = &v50;
    var v79: i32 = undefined; _ = &v79;
    var v51: bool = undefined; _ = &v51;
    var v52: bool = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v54: bool = undefined; _ = &v54;
    var v55: bool = undefined; _ = &v55;
    var v56: bool = undefined; _ = &v56;
    var v57: bool = undefined; _ = &v57;
    var v58: bool = undefined; _ = &v58;
    var v59: bool = undefined; _ = &v59;
    var v60: bool = undefined; _ = &v60;
    var v61: bool = undefined; _ = &v61;
    var v62: bool = undefined; _ = &v62;
    var v63: bool = undefined; _ = &v63;
    var v64: bool = undefined; _ = &v64;
    var v19: bool = undefined; _ = &v19;
    var v48: i32 = undefined; _ = &v48;
    var v20: bool = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: bool = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: bool = undefined; _ = &v32;
    var v33: bool = undefined; _ = &v33;
    var v2: bool = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v17 = v1.c1_0;
                v18 = v1.c1_1;
                switch (v17.tag) {
                    1 => {
                        v50 = v0 == @as(i32, 0);
                        if (v50) {
                            v79 = @as(i32, 1);
                        } else {
                            v51 = v0 == @as(i32, 1);
                            if (v51) {
                                v79 = @as(i32, 6);
                            } else {
                                v52 = v0 == @as(i32, 2);
                                if (v52) {
                                    v79 = @as(i32, 11);
                                } else {
                                    v53 = v0 == @as(i32, 3);
                                    if (v53) {
                                        v79 = @as(i32, 5);
                                    } else {
                                        v54 = v0 == @as(i32, 4);
                                        if (v54) {
                                            v79 = @as(i32, 1);
                                        } else {
                                            v55 = v0 == @as(i32, 5);
                                            if (v55) {
                                                v79 = @as(i32, 6);
                                            } else {
                                                v56 = v0 == @as(i32, 6);
                                                if (v56) {
                                                    v79 = @as(i32, 13);
                                                } else {
                                                    v57 = v0 == @as(i32, 7);
                                                    if (v57) {
                                                        v79 = @as(i32, 9);
                                                    } else {
                                                        v58 = v0 == @as(i32, 8);
                                                        if (v58) {
                                                            v79 = @as(i32, 5);
                                                        } else {
                                                            v59 = v0 == @as(i32, 9);
                                                            if (v59) {
                                                                v79 = @as(i32, 12);
                                                            } else {
                                                                v60 = v0 == @as(i32, 10);
                                                                if (v60) {
                                                                    v79 = @as(i32, 11);
                                                                } else {
                                                                    v61 = v0 == @as(i32, 11);
                                                                    if (v61) {
                                                                        v79 = @as(i32, 12);
                                                                    } else {
                                                                        v62 = v0 == @as(i32, 12);
                                                                        if (v62) {
                                                                            v79 = @as(i32, 13);
                                                                        } else {
                                                                            v63 = v0 == @as(i32, 13);
                                                                            if (v63) {
                                                                                v79 = @as(i32, 15);
                                                                            } else {
                                                                                v64 = v0 == @as(i32, 14);
                                                                                if (v64) {
                                                                                    v79 = @as(i32, 9);
                                                                                } else {
                                                                                    v79 = @as(i32, 15);
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
                        v0 = v79;
                        v1 = v18;
                        continue;
                    },
                    0 => {
                        v19 = v0 == @as(i32, 0);
                        if (v19) {
                            v48 = @as(i32, 0);
                        } else {
                            v20 = v0 == @as(i32, 1);
                            if (v20) {
                                v48 = @as(i32, 2);
                            } else {
                                v21 = v0 == @as(i32, 2);
                                if (v21) {
                                    v48 = @as(i32, 3);
                                } else {
                                    v22 = v0 == @as(i32, 3);
                                    if (v22) {
                                        v48 = @as(i32, 4);
                                    } else {
                                        v23 = v0 == @as(i32, 4);
                                        if (v23) {
                                            v48 = @as(i32, 0);
                                        } else {
                                            v24 = v0 == @as(i32, 5);
                                            if (v24) {
                                                v48 = @as(i32, 2);
                                            } else {
                                                v25 = v0 == @as(i32, 6);
                                                if (v25) {
                                                    v48 = @as(i32, 7);
                                                } else {
                                                    v26 = v0 == @as(i32, 7);
                                                    if (v26) {
                                                        v48 = @as(i32, 8);
                                                    } else {
                                                        v27 = v0 == @as(i32, 8);
                                                        if (v27) {
                                                            v48 = @as(i32, 4);
                                                        } else {
                                                            v28 = v0 == @as(i32, 9);
                                                            if (v28) {
                                                                v48 = @as(i32, 10);
                                                            } else {
                                                                v29 = v0 == @as(i32, 10);
                                                                if (v29) {
                                                                    v48 = @as(i32, 3);
                                                                } else {
                                                                    v30 = v0 == @as(i32, 11);
                                                                    if (v30) {
                                                                        v48 = @as(i32, 10);
                                                                    } else {
                                                                        v31 = v0 == @as(i32, 12);
                                                                        if (v31) {
                                                                            v48 = @as(i32, 7);
                                                                        } else {
                                                                            v32 = v0 == @as(i32, 13);
                                                                            if (v32) {
                                                                                v48 = @as(i32, 14);
                                                                            } else {
                                                                                v33 = v0 == @as(i32, 14);
                                                                                if (v33) {
                                                                                    v48 = @as(i32, 8);
                                                                                } else {
                                                                                    v48 = @as(i32, 14);
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
                        v0 = v48;
                        v1 = v18;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 4);
                if (v2) {
                    return true;
                } else {
                    v3 = v0 == @as(i32, 5);
                    if (v3) {
                        return true;
                    } else {
                        v4 = v0 == @as(i32, 8);
                        if (v4) {
                            return true;
                        } else {
                            v5 = v0 == @as(i32, 9);
                            if (v5) {
                                return true;
                            } else {
                                v6 = v0 == @as(i32, 10);
                                if (v6) {
                                    return true;
                                } else {
                                    v7 = v0 == @as(i32, 12);
                                    if (v7) {
                                        return true;
                                    } else {
                                        v8 = v0 == @as(i32, 14);
                                        if (v8) {
                                            return true;
                                        } else {
                                            v9 = v0 == @as(i32, 15);
                                            return v9;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            else => unreachable,
        }
    }
}
fn loop_3(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: u64 = undefined; _ = &v7;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v8: i32 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    while (true) {
        v4 = @as(i32, 0) < v1;
        if (v4) {
            v5 = UH0_InputEmpty();
            tmp4 = random_bit_input_1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = run_4(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = v1 -% @as(i32, 1);
            v1 = v12;
            v2 = v7;
            v3 = v11;
            continue;
        } else {
            return v3;
        }
    }
}
fn spiralMain() i32 {
    const v0: i32 = @as(i32, 2000);
    const v1: i32 = @as(i32, 32);
    const v2: u64 = @as(u64, 1);
    const v3: i32 = @as(i32, 0);
    const v4: i32 = loop_0(v1, v0, v2, v3);
    const v5: i32 = loop_3(v1, v0, v2, v3);
    const v6: bool = v4 == @as(i32, 997);
    if (v6) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-ends-with-zero-count");
    }
    const v7: bool = v5 == @as(i32, 985);
    if (v7) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-fourth-from-end-count");
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
