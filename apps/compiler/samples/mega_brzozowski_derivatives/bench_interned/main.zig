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
const US0 = struct { tag: i32 };
const UH0 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH0 = undefined, c3_1: *UH0 = undefined, c4_0: *UH0 = undefined, c4_1: *UH0 = undefined, c5_0: *UH0 = undefined };
const UH1 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH1 = undefined };
const Tuple0 = struct { f0: *UH1, f1: u64 };
fn loop_0(p0: []i32, p1: i32) void {
    var v0: []i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    while (true) {
        v2 = v1 < @as(i32, 8192);
        if (v2) {
            v0[spiralIndex(v0.len, v1)] = @as(i32, 0);
            v3 = v1 +% @as(i32, 1);
            v1 = v3;
            continue;
        } else {
            return;
        }
    }
}
fn loop_1(p0: []i32, p1: i32) void {
    var v0: []i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    while (true) {
        v2 = v1 < @as(i32, 1);
        if (v2) {
            v0[spiralIndex(v0.len, v1)] = @as(i32, 0);
            v3 = v1 +% @as(i32, 1);
            v1 = v3;
            continue;
        } else {
            return;
        }
    }
}
fn probe_3(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: i32 = p10; _ = &v10;
    var v11: i32 = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v32: bool = undefined; _ = &v32;
    var v16: bool = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v23: bool = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v33: i32 = undefined; _ = &v33;
    var v34: i32 = undefined; _ = &v34;
    var v37: i32 = undefined; _ = &v37;
    var v38: i32 = undefined; _ = &v38;
    var v39: bool = undefined; _ = &v39;
    var v42: bool = undefined; _ = &v42;
    var v40: i32 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v45: bool = undefined; _ = &v45;
    var v43: i32 = undefined; _ = &v43;
    var v44: bool = undefined; _ = &v44;
    var v46: i32 = undefined; _ = &v46;
    var v47: i32 = undefined; _ = &v47;
    while (true) {
        v11 = v4[spiralIndex(v4.len, v10)];
        v12 = v11 == @as(i32, 0);
        if (v12) {
            v13 = v6[spiralIndex(v6.len, @as(i32, 0))];
            v14 = v13 < @as(i32, 4096);
            if (v14) {
                v0[spiralIndex(v0.len, v13)] = v7;
                v1[spiralIndex(v1.len, v13)] = v8;
                v2[spiralIndex(v2.len, v13)] = v9;
                v15 = v7 == @as(i32, 1);
                if (v15) {
                    v32 = true;
                } else {
                    v16 = v7 == @as(i32, 5);
                    if (v16) {
                        v32 = true;
                    } else {
                        v17 = v7 == @as(i32, 3);
                        if (v17) {
                            v18 = v3[spiralIndex(v3.len, v8)];
                            v19 = v18 == @as(i32, 1);
                            if (v19) {
                                v32 = true;
                            } else {
                                v20 = v3[spiralIndex(v3.len, v9)];
                                v21 = v20 == @as(i32, 1);
                                v32 = v21;
                            }
                        } else {
                            v23 = v7 == @as(i32, 4);
                            if (v23) {
                                v24 = v3[spiralIndex(v3.len, v8)];
                                v25 = v24 == @as(i32, 1);
                                if (v25) {
                                    v26 = v3[spiralIndex(v3.len, v9)];
                                    v27 = v26 == @as(i32, 1);
                                    v32 = v27;
                                } else {
                                    v32 = false;
                                }
                            } else {
                                v32 = false;
                            }
                        }
                    }
                }
                if (v32) {
                    v33 = @as(i32, 1);
                } else {
                    v33 = @as(i32, 0);
                }
                v3[spiralIndex(v3.len, v13)] = v33;
                v34 = v13 +% @as(i32, 1);
                v4[spiralIndex(v4.len, v10)] = v34;
                v6[spiralIndex(v6.len, @as(i32, 0))] = v34;
                return v13;
            } else {
                spiralFail("brzozowski-interned-store-full");
            }
        } else {
            v37 = v11 -% @as(i32, 1);
            v38 = v0[spiralIndex(v0.len, v37)];
            v39 = v38 == v7;
            if (v39) {
                v40 = v1[spiralIndex(v1.len, v37)];
                v41 = v40 == v8;
                v42 = v41;
            } else {
                v42 = false;
            }
            if (v42) {
                v43 = v2[spiralIndex(v2.len, v37)];
                v44 = v43 == v9;
                v45 = v44;
            } else {
                v45 = false;
            }
            if (v45) {
                return v37;
            } else {
                v46 = v10 +% @as(i32, 1);
                v47 = v46 & @as(i32, 8191);
                v10 = v47;
                continue;
            }
        }
    }
}
fn interned_node_2(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    const v10: i32 = v7 *% @as(i32, 1024);
    const v11: i32 = v10 +% v8;
    const v12: i32 = v11 *% @as(i32, 4099);
    const v13: i32 = v12 +% v9;
    const v14: i32 = v13 & @as(i32, 8191);
    return probe_3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_RegexEmpty() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_RegexEpsilon() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 1 };
    };
    return &shared.value;
}
fn UH0_RegexChar(a0: US0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 2, .c2_0 = a0 });
}
fn UH0_RegexAlt(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH0_RegexCat(a0: *UH0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH0_RegexStar(a0: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 5, .c5_0 = a0 });
}
fn interned_alt_insert_6(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v16: bool = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v23: bool = undefined; _ = &v23;
    var v24: i32 = undefined; _ = &v24;
    var v26: bool = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    const v9: bool = v8 == @as(i32, 0);
    if (v9) {
        return v7;
    } else {
        v10 = v0[spiralIndex(v0.len, v8)];
        v11 = v10 == @as(i32, 3);
        if (v11) {
            v12 = v1[spiralIndex(v1.len, v8)];
            v13 = v7 < v12;
            if (v13) {
                v14 = @as(i32, 3);
                return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
            } else {
                v16 = v7 == v12;
                if (v16) {
                    return v8;
                } else {
                    v17 = @as(i32, 3);
                    v18 = v2[spiralIndex(v2.len, v8)];
                    v19 = interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            v23 = v7 < v8;
            if (v23) {
                v24 = @as(i32, 3);
                return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                v26 = v7 == v8;
                if (v26) {
                    return v8;
                } else {
                    v27 = @as(i32, 3);
                    return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
fn interned_make_alt_5(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    while (true) {
        v9 = v7 == @as(i32, 0);
        if (v9) {
            return v8;
        } else {
            v10 = v0[spiralIndex(v0.len, v7)];
            v11 = v10 == @as(i32, 3);
            if (v11) {
                v12 = v2[spiralIndex(v2.len, v7)];
                v13 = v1[spiralIndex(v1.len, v7)];
                v14 = interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v13, v8);
                v7 = v12;
                v8 = v14;
                continue;
            } else {
                return interned_alt_insert_6(v0, v1, v2, v3, v4, v5, v6, v7, v8);
            }
        }
    }
}
fn interned_make_cat_7(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v10: bool = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v17: bool = undefined; _ = &v17;
    var v15: i32 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    var v19: i32 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v24: i32 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: i32 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v31: i32 = undefined; _ = &v31;
    const v9: bool = v7 == @as(i32, 0);
    if (v9) {
        return @as(i32, 0);
    } else {
        v10 = v8 == @as(i32, 0);
        if (v10) {
            return @as(i32, 0);
        } else {
            v11 = v7 == @as(i32, 1);
            if (v11) {
                return v8;
            } else {
                v12 = v8 == @as(i32, 1);
                if (v12) {
                    return v7;
                } else {
                    v13 = v0[spiralIndex(v0.len, v7)];
                    v14 = v13 == @as(i32, 5);
                    if (v14) {
                        v15 = v0[spiralIndex(v0.len, v8)];
                        v16 = v15 == @as(i32, 5);
                        v17 = v16;
                    } else {
                        v17 = false;
                    }
                    if (v17) {
                        v18 = v1[spiralIndex(v1.len, v7)];
                        v19 = v1[spiralIndex(v1.len, v8)];
                        v20 = v18 == v19;
                        if (v20) {
                            return v7;
                        } else {
                            v21 = @as(i32, 4);
                            return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                        }
                    } else {
                        v24 = v0[spiralIndex(v0.len, v7)];
                        v25 = v24 == @as(i32, 4);
                        if (v25) {
                            v26 = @as(i32, 4);
                            v27 = v1[spiralIndex(v1.len, v7)];
                            v28 = v2[spiralIndex(v2.len, v7)];
                            v29 = interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            v31 = @as(i32, 4);
                            return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
fn interned_of_regex_raw_4(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: *UH0) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: *UH0 = p7; _ = &v7;
    var v14: *UH0 = undefined; _ = &v14;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: i32 = undefined; _ = &v17;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v8: US0 = undefined; _ = &v8;
    var v9: i32 = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v12: i32 = undefined; _ = &v12;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: i32 = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    switch (v7.tag) {
        3 => {
            v14 = v7.c3_0;
            v15 = v7.c3_1;
            v16 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v14);
            v17 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v15);
            return interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v16, v17);
        },
        4 => {
            v19 = v7.c4_0;
            v20 = v7.c4_1;
            v21 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v19);
            v22 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v20);
            return interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v21, v22);
        },
        2 => {
            v8 = v7.c2_0;
            v9 = @as(i32, 2);
            switch (v8.tag) {
                1 => {
                    v11 = @as(i32, 1);
                },
                0 => {
                    v11 = @as(i32, 0);
                },
                else => unreachable,
            }
            v12 = @as(i32, 0);
            return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
        },
        0 => {
            return @as(i32, 0);
        },
        1 => {
            return @as(i32, 1);
        },
        5 => {
            v24 = v7.c5_0;
            v25 = interned_of_regex_raw_4(v0, v1, v2, v3, v4, v5, v6, v24);
            v26 = v0[spiralIndex(v0.len, v25)];
            v27 = v26 < @as(i32, 2);
            if (v27) {
                return @as(i32, 1);
            } else {
                v28 = v26 == @as(i32, 5);
                if (v28) {
                    return v25;
                } else {
                    v29 = @as(i32, 5);
                    v30 = @as(i32, 0);
                    return interned_node_2(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
        },
        else => unreachable,
    }
}
fn UH1_InputEmpty() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_InputCons(a0: US0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn random_bit_input_9(p0: u64, p1: i32, p2: *UH1) Tuple0 {
    var v0: u64 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
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
    var v14: *UH1 = undefined; _ = &v14;
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
            v14 = UH1_InputCons(v13, v2);
            v0 = v6;
            v1 = v7;
            v2 = v14;
            continue;
        } else {
            return Tuple0{ .f0 = v2, .f1 = v0 };
        }
    }
}
fn interned_derivative_raw_12(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v13: i32 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v41: i32 = undefined; _ = &v41;
    var v15: bool = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    var v19: bool = undefined; _ = &v19;
    var v20: i32 = undefined; _ = &v20;
    var v21: i32 = undefined; _ = &v21;
    var v22: i32 = undefined; _ = &v22;
    var v23: i32 = undefined; _ = &v23;
    var v25: bool = undefined; _ = &v25;
    var v26: i32 = undefined; _ = &v26;
    var v27: i32 = undefined; _ = &v27;
    var v28: i32 = undefined; _ = &v28;
    var v29: i32 = undefined; _ = &v29;
    var v30: i32 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v32: i32 = undefined; _ = &v32;
    var v35: i32 = undefined; _ = &v35;
    var v36: i32 = undefined; _ = &v36;
    var v42: i32 = undefined; _ = &v42;
    var v43: i32 = undefined; _ = &v43;
    const v9: i32 = v7 *% @as(i32, 2);
    const v10: i32 = v9 +% v8;
    const v11: i32 = v5[spiralIndex(v5.len, v10)];
    const v12: bool = v11 == @as(i32, 0);
    if (v12) {
        v13 = v0[spiralIndex(v0.len, v7)];
        v14 = v13 < @as(i32, 2);
        if (v14) {
            v41 = @as(i32, 0);
        } else {
            v15 = v13 == @as(i32, 2);
            if (v15) {
                v16 = v1[spiralIndex(v1.len, v7)];
                v17 = v16 == v8;
                if (v17) {
                    v41 = @as(i32, 1);
                } else {
                    v41 = @as(i32, 0);
                }
            } else {
                v19 = v13 == @as(i32, 3);
                if (v19) {
                    v20 = v1[spiralIndex(v1.len, v7)];
                    v21 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    v22 = v2[spiralIndex(v2.len, v7)];
                    v23 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v41 = interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v21, v23);
                } else {
                    v25 = v13 == @as(i32, 4);
                    if (v25) {
                        v26 = v1[spiralIndex(v1.len, v7)];
                        v27 = v2[spiralIndex(v2.len, v7)];
                        v28 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        v29 = interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        v30 = v3[spiralIndex(v3.len, v26)];
                        v31 = v30 == @as(i32, 1);
                        if (v31) {
                            v32 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v41 = interned_make_alt_5(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            v41 = v29;
                        }
                    } else {
                        v35 = v1[spiralIndex(v1.len, v7)];
                        v36 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v41 = interned_make_cat_7(v0, v1, v2, v3, v4, v5, v6, v36, v7);
                    }
                }
            }
        }
        v42 = v41 +% @as(i32, 1);
        v5[spiralIndex(v5.len, v10)] = v42;
        return v41;
    } else {
        v43 = v11 -% @as(i32, 1);
        return v43;
    }
}
fn loop_11(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: *UH1 = p8; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v15: i32 = undefined; _ = &v15;
    var v16: i32 = undefined; _ = &v16;
    var v10: i32 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        v9 = v7 == @as(i32, 0);
        if (v9) {
            return false;
        } else {
            switch (v8.tag) {
                1 => {
                    v12 = v8.c1_0;
                    v13 = v8.c1_1;
                    switch (v12.tag) {
                        1 => {
                            v15 = @as(i32, 1);
                        },
                        0 => {
                            v15 = @as(i32, 0);
                        },
                        else => unreachable,
                    }
                    v16 = interned_derivative_raw_12(v0, v1, v2, v3, v4, v5, v6, v7, v15);
                    v7 = v16;
                    v8 = v13;
                    continue;
                },
                0 => {
                    v10 = v3[spiralIndex(v3.len, v7)];
                    v11 = v10 == @as(i32, 1);
                    return v11;
                },
                else => unreachable,
            }
        }
    }
}
fn interned_accepts_10(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: *UH1 = p8; _ = &v8;
    return loop_11(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
fn loop_8(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: u64, p11: i32) i32 {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: i32 = p8; _ = &v8;
    var v9: i32 = p9; _ = &v9;
    var v10: u64 = p10; _ = &v10;
    var v11: i32 = p11; _ = &v11;
    var v12: bool = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: u64 = undefined; _ = &v15;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v16: bool = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    var v17: i32 = undefined; _ = &v17;
    var v19: i32 = undefined; _ = &v19;
    while (true) {
        v12 = @as(i32, 0) < v9;
        if (v12) {
            v13 = UH1_InputEmpty();
            tmp4 = random_bit_input_9(v10, v7, v13);
            v14 = tmp4.f0;
            v15 = tmp4.f1;
            v16 = interned_accepts_10(v0, v1, v2, v3, v4, v5, v6, v8, v14);
            if (v16) {
                v17 = v11 +% @as(i32, 1);
                v18 = v17;
            } else {
                v18 = v11;
            }
            v19 = v9 -% @as(i32, 1);
            v9 = v19;
            v10 = v15;
            v11 = v18;
            continue;
        } else {
            return v11;
        }
    }
}
fn spiralMain() i32 {
    var v22: bool = undefined; _ = &v22;
    var v21: bool = undefined; _ = &v21;
    var v30: []i32 = undefined; _ = &v30;
    var v31: []i32 = undefined; _ = &v31;
    var v32: []i32 = undefined; _ = &v32;
    var v33: []i32 = undefined; _ = &v33;
    var v34: []i32 = undefined; _ = &v34;
    var v35: []i32 = undefined; _ = &v35;
    var v36: []i32 = undefined; _ = &v36;
    const v0: i32 = @as(i32, 2000);
    const v1: i32 = @as(i32, 32);
    const v2: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v3: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v4: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v5: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v6: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v7: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v8: []i32 = spiralNewArray(i32, @as(i32, 1));
    const v9: i32 = @as(i32, 0);
    _ = loop_0(v6, v9);
    const v10: i32 = @as(i32, 0);
    _ = loop_0(v7, v10);
    const v11: i32 = @as(i32, 0);
    _ = loop_1(v8, v11);
    const v12: i32 = @as(i32, 0);
    const v13: i32 = @as(i32, 0);
    const v14: i32 = @as(i32, 0);
    const v15: i32 = interned_node_2(v2, v3, v4, v5, v6, v7, v8, v12, v13, v14);
    const v16: i32 = @as(i32, 1);
    const v17: i32 = @as(i32, 0);
    const v18: i32 = @as(i32, 0);
    const v19: i32 = interned_node_2(v2, v3, v4, v5, v6, v7, v8, v16, v17, v18);
    const v20: bool = v15 == @as(i32, 0);
    if (v20) {
        v21 = v19 == @as(i32, 1);
        v22 = v21;
    } else {
        v22 = false;
    }
    if (v22) {
        v30 = v2;
        v31 = v3;
        v32 = v4;
        v33 = v5;
        v34 = v6;
        v35 = v7;
        v36 = v8;
    } else {
        if (spiral_true) spiralFail("brzozowski-interned-store-init");
    }
    const v37: US0 = US0_BitZero();
    const v38: *UH0 = UH0_RegexChar(v37);
    const v39: US0 = US0_BitOne();
    const v40: *UH0 = UH0_RegexChar(v39);
    const v41: *UH0 = UH0_RegexAlt(v38, v40);
    const v42: *UH0 = UH0_RegexStar(v41);
    const v43: US0 = US0_BitZero();
    const v44: *UH0 = UH0_RegexChar(v43);
    const v45: *UH0 = UH0_RegexCat(v42, v44);
    const v46: i32 = interned_of_regex_raw_4(v30, v31, v32, v33, v34, v35, v36, v45);
    const v47: u64 = @as(u64, 1);
    const v48: i32 = @as(i32, 0);
    const v49: i32 = loop_8(v30, v31, v32, v33, v34, v35, v36, v1, v46, v0, v47, v48);
    const v50: US0 = US0_BitZero();
    const v51: *UH0 = UH0_RegexChar(v50);
    const v52: US0 = US0_BitOne();
    const v53: *UH0 = UH0_RegexChar(v52);
    const v54: *UH0 = UH0_RegexAlt(v51, v53);
    const v55: *UH0 = UH0_RegexStar(v54);
    const v56: US0 = US0_BitOne();
    const v57: *UH0 = UH0_RegexChar(v56);
    const v58: US0 = US0_BitZero();
    const v59: *UH0 = UH0_RegexChar(v58);
    const v60: US0 = US0_BitOne();
    const v61: *UH0 = UH0_RegexChar(v60);
    const v62: *UH0 = UH0_RegexAlt(v59, v61);
    const v63: US0 = US0_BitZero();
    const v64: *UH0 = UH0_RegexChar(v63);
    const v65: US0 = US0_BitOne();
    const v66: *UH0 = UH0_RegexChar(v65);
    const v67: *UH0 = UH0_RegexAlt(v64, v66);
    const v68: US0 = US0_BitZero();
    const v69: *UH0 = UH0_RegexChar(v68);
    const v70: US0 = US0_BitOne();
    const v71: *UH0 = UH0_RegexChar(v70);
    const v72: *UH0 = UH0_RegexAlt(v69, v71);
    const v73: *UH0 = UH0_RegexCat(v67, v72);
    const v74: *UH0 = UH0_RegexCat(v62, v73);
    const v75: *UH0 = UH0_RegexCat(v57, v74);
    const v76: *UH0 = UH0_RegexCat(v55, v75);
    const v77: i32 = interned_of_regex_raw_4(v30, v31, v32, v33, v34, v35, v36, v76);
    const v78: u64 = @as(u64, 1);
    const v79: i32 = @as(i32, 0);
    const v80: i32 = loop_8(v30, v31, v32, v33, v34, v35, v36, v1, v77, v0, v78, v79);
    const v81: bool = v49 == @as(i32, 997);
    if (v81) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-ends-with-zero-count");
    }
    const v82: bool = v80 == @as(i32, 985);
    if (v82) {
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
