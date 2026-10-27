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
const UH0 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH0 = undefined, c3_1: *UH0 = undefined, c4_0: *UH0 = undefined, c4_1: *UH0 = undefined, c5_0: *UH0 = undefined };
const US1 = struct { tag: i32 };
const UH1 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH1 = undefined };
const UH2 = struct { tag: i32, c0_0: US0 = undefined };
const UH3 = struct { tag: i32, c0_0: *UH2 = undefined, c0_1: *UH2 = undefined };
const UH4 = struct { tag: i32, c0_0: *UH3 = undefined };
const UH5 = struct { tag: i32, c0_0: *UH4 = undefined, c0_1: *UH2 = undefined };
const UH6 = struct { tag: i32, c1_0: *UH6 = undefined };
const Fun1 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH0) *UH0 };
const Fun0 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH0) Fun1 };
const ClosureEnv0 = struct { pad: u8 = 0 };
const ClosureEnv1 = struct { v0: *UH0, pad: u8 = 0 };
const Fun3 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH0) bool };
const Fun2 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH0) Fun3 };
const ClosureEnv2 = struct { pad: u8 = 0 };
const ClosureEnv3 = struct { v0: *UH0, pad: u8 = 0 };
const UH10 = struct { tag: i32 };
const UH9 = struct { tag: i32, c0_0: *UH10 = undefined, c1_0: *UH10 = undefined };
const UH8 = struct { tag: i32, c0_0: *UH9 = undefined };
const UH7 = struct { tag: i32, c0_0: *UH8 = undefined, c1_0: *UH10 = undefined };
const US3 = struct { tag: i32, c1_0: *UH7 = undefined };
const US2 = struct { tag: i32, c1_0: US3 = undefined };
const US4 = struct { tag: i32, c1_0: *UH7 = undefined };
const US5 = struct { tag: i32, c1_0: *UH8 = undefined };
const US6 = struct { tag: i32, c1_0: *UH9 = undefined };
const US7 = struct { tag: i32, c1_0: *UH10 = undefined };
const US8 = struct { tag: i32 };
const UH11 = struct { tag: i32, c2_0: US8 = undefined, c3_0: *UH11 = undefined, c3_1: *UH11 = undefined, c4_0: *UH11 = undefined, c4_1: *UH11 = undefined, c5_0: *UH11 = undefined };
const UH12 = struct { tag: i32, c1_0: *UH11 = undefined, c1_1: *UH12 = undefined };
const UH13 = struct { tag: i32, c0_0: US8 = undefined };
const UH14 = struct { tag: i32, c0_0: *UH13 = undefined };
const Fun5 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH11) *UH11 };
const Fun4 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH11) Fun5 };
const ClosureEnv4 = struct { pad: u8 = 0 };
const ClosureEnv5 = struct { v0: *UH11, pad: u8 = 0 };
const Fun7 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH11) bool };
const Fun6 = struct { ctx: *anyopaque, call: *const fn (*anyopaque, *UH11) Fun7 };
const ClosureEnv6 = struct { pad: u8 = 0 };
const ClosureEnv7 = struct { v0: *UH11, pad: u8 = 0 };
const UH15 = struct { tag: i32, c0_0: *UH10 = undefined };
const US10 = struct { tag: i32, c1_0: *UH15 = undefined };
const US9 = struct { tag: i32, c1_0: US10 = undefined };
const US11 = struct { tag: i32, c1_0: *UH15 = undefined };
const UH16 = struct { tag: i32, c0_0: *UH13 = undefined, c0_1: *UH13 = undefined };
const UH17 = struct { tag: i32, c0_0: *UH16 = undefined };
const UH18 = struct { tag: i32, c0_0: *UH17 = undefined, c0_1: *UH13 = undefined };
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
fn US1_SymbolLess() US1 {
    return US1{ .tag = 0 };
}
fn US1_SymbolSame() US1 {
    return US1{ .tag = 1 };
}
fn US1_SymbolGreater() US1 {
    return US1{ .tag = 2 };
}
fn regex_compare_3(p0: *UH0, p1: *UH0) US1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: *UH0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: US1 = undefined; _ = &v57;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: US1 = undefined; _ = &v36;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH0 = undefined; _ = &v44;
    var v45: *UH0 = undefined; _ = &v45;
    var v46: *UH0 = undefined; _ = &v46;
    var v48: *UH0 = undefined; _ = &v48;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = regex_compare_3(v53, v55);
                        switch (v57.tag) {
                            1 => {
                                v0 = v54;
                                v1 = v56;
                                continue;
                            },
                            else => {
                                return v57;
                            },
                        }
                    },
                    else => {
                        return US1_SymbolGreater();
                    },
                }
            },
            4 => {
                v28 = v0.c4_0;
                v29 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_compare_3(v28, v34);
                        switch (v36.tag) {
                            1 => {
                                v0 = v29;
                                v1 = v35;
                                continue;
                            },
                            else => {
                                return v36;
                            },
                        }
                    },
                    2 => {
                        v32 = v1.c2_0;
                        return US1_SymbolGreater();
                    },
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolGreater();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            1 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US1_SymbolSame();
                                    },
                                    0 => {
                                        return US1_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US1_SymbolLess();
                                    },
                                    0 => {
                                        return US1_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolGreater();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US1_SymbolSame();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolSame();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US1_SymbolLess();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        v0 = v44;
                        v1 = v48;
                        continue;
                    },
                    else => {
                        return US1_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_2(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH0 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_3(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_2(v0, v3);
                    return UH0_RegexAlt(v2, v6);
                },
                0 => {
                    return UH0_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_3(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH0_RegexAlt(v1, v0);
                },
                0 => {
                    return UH0_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_1(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_2(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_2(v0, v1);
            },
        }
    }
}
fn regex_equal_5(p0: *UH0, p1: *UH0) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US1 = undefined; _ = &v15;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = regex_equal_5(v18, v20);
                        if (v22) {
                            v0 = v19;
                            v1 = v21;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v26 = v0.c4_0;
                v27 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v28 = v1.c4_0;
                        v29 = v1.c4_1;
                        v30 = regex_equal_5(v26, v28);
                        if (v30) {
                            v0 = v27;
                            v1 = v29;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            1 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US1_SymbolSame();
                                    },
                                    0 => {
                                        v15 = US1_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US1_SymbolLess();
                                    },
                                    0 => {
                                        v15 = US1_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v15.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v34 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v35 = v1.c5_0;
                        v0 = v34;
                        v1 = v35;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_4(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH0_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH0_RegexEmpty();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_4(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_5(v4, v5);
                                                    if (v6) {
                                                        return UH0_RegexStar(v4);
                                                    } else {
                                                        return UH0_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH0_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH0_RegexCat(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_6(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v3: *UH0 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH0_RegexEpsilon();
        },
        1 => {
            return UH0_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH0_RegexStar(v3);
        },
        else => {
            return UH0_RegexStar(v0);
        },
    }
}
fn normalize_0(p0: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH0 = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_0(v5);
            v8 = normalize_0(v6);
            return make_alt_1(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_0(v10);
            v13 = normalize_0(v11);
            return make_cat_4(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH0_RegexChar(v3);
        },
        0 => {
            return UH0_RegexEmpty();
        },
        1 => {
            return UH0_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_0(v15);
            return make_star_6(v16);
        },
        else => unreachable,
    }
}
fn UH1_RegexListNil() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_RegexListCons(a0: *UH0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn regex_list_contains_10(p0: *UH0, p1: *UH1) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_5(v0, v2);
                if (v4) {
                    return true;
                } else {
                    v1 = v3;
                    continue;
                }
            },
            0 => {
                return false;
            },
            else => unreachable,
        }
    }
}
fn antimirov_insert_unique_9(p0: *UH0, p1: *UH1) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    const v2: *UH0 = normalize_0(v0);
    const v3: bool = regex_list_contains_10(v2, v1);
    if (v3) {
        return v1;
    } else {
        return UH1_RegexListCons(v2, v1);
    }
}
fn antimirov_union_8(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = antimirov_insert_unique_9(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn antimirov_map_cat_right_11(p0: *UH1, p1: *UH0) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = make_cat_4(v3, v1);
            v6 = antimirov_map_cat_right_11(v4, v1);
            return antimirov_insert_unique_9(v5, v6);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_residual_support_7(p0: *UH0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: *UH1 = undefined; _ = &v10;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: *UH1 = undefined; _ = &v15;
    var v16: *UH1 = undefined; _ = &v16;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v18: *UH0 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = antimirov_residual_support_7(v7);
            v10 = antimirov_residual_support_7(v8);
            return antimirov_union_8(v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = antimirov_residual_support_7(v12);
            v15 = antimirov_map_cat_right_11(v14, v13);
            v16 = antimirov_residual_support_7(v13);
            return antimirov_union_8(v15, v16);
        },
        2 => {
            v3 = v0.c2_0;
            v4 = UH0_RegexEpsilon();
            v5 = UH1_RegexListNil();
            return UH1_RegexListCons(v4, v5);
        },
        0 => {
            return UH1_RegexListNil();
        },
        1 => {
            return UH1_RegexListNil();
        },
        5 => {
            v18 = v0.c5_0;
            v19 = antimirov_residual_support_7(v18);
            v20 = UH0_RegexStar(v18);
            return antimirov_map_cat_right_11(v19, v20);
        },
        else => unreachable,
    }
}
fn regex_list_distinct_12(p0: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = undefined; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_list_contains_10(v1, v2);
                if (v3) {
                    return false;
                } else {
                    v0 = v2;
                    continue;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn UH2_PositionTreeChar(a0: US0) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 0, .c0_0 = a0 });
}
fn UH3_PositionTreeAlt(a0: *UH2, a1: *UH2) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH4_PositionTreeStar(a0: *UH3) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 0, .c0_0 = a0 });
}
fn UH5_PositionTreeCat(a0: *UH4, a1: *UH2) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH6_StateBudgetZero() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_StateBudgetSucc(a0: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0 });
}
fn state_budget_add_14(p0: *UH6, p1: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = state_budget_add_14(v2, v1);
            return UH6_StateBudgetSucc(v3);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_17(p0: *UH2) *UH6 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = UH6_StateBudgetZero();
            return UH6_StateBudgetSucc(v2);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_16(p0: *UH3) *UH6 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = antimirov_position_tree_budget_17(v1);
            v4 = antimirov_position_tree_budget_17(v2);
            return state_budget_add_14(v3, v4);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_15(p0: *UH4) *UH6 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return antimirov_position_tree_budget_16(v1);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_13(p0: *UH5) *UH6 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = antimirov_position_tree_budget_15(v1);
            v4 = antimirov_position_tree_budget_17(v2);
            return state_budget_add_14(v3, v4);
        },
        else => unreachable,
    }
}
fn regex_position_count_18(p0: *UH0) *UH6 {
    var v0: *UH0 = p0; _ = &v0;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v9: *UH6 = undefined; _ = &v9;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH6 = undefined; _ = &v13;
    var v14: *UH6 = undefined; _ = &v14;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v16: *UH0 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_18(v6);
                v9 = regex_position_count_18(v7);
                return state_budget_add_14(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_18(v11);
                v14 = regex_position_count_18(v12);
                return state_budget_add_14(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH6_StateBudgetZero();
                return UH6_StateBudgetSucc(v4);
            },
            0 => {
                return UH6_StateBudgetZero();
            },
            1 => {
                return UH6_StateBudgetZero();
            },
            5 => {
                v16 = v0.c5_0;
                v0 = v16;
                continue;
            },
            else => unreachable,
        }
    }
}
fn state_budget_same_19(p0: *UH6, p1: *UH6) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                switch (v1.tag) {
                    1 => {
                        v4 = v1.c1_0;
                        v0 = v3;
                        v1 = v4;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn closure1(ctx: *anyopaque, p1: *UH0) *UH0 {
    const env: *ClosureEnv1 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *UH0 = env.v0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    const v2: *UH0 = make_cat_4(v0, v1);
    return normalize_0(v2);
}
fn closureCreate1(p0: *UH0) Fun1 {
    return .{ .ctx = spiralCreate(ClosureEnv1, .{ .v0 = p0, }), .call = &closure1 };
}
fn closure0(ctx: *anyopaque, p0: *UH0) Fun1 {
    const env: *ClosureEnv0 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: *UH0 = p0; _ = &v0;
    return closureCreate1(v0);
}
fn closureCreate0() Fun0 {
    return .{ .ctx = spiralCreate(ClosureEnv0, .{ }), .call = &closure0 };
}
fn closure3(ctx: *anyopaque, p1: *UH0) bool {
    const env: *ClosureEnv3 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *UH0 = env.v0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    return regex_equal_5(v0, v1);
}
fn closureCreate3(p0: *UH0) Fun3 {
    return .{ .ctx = spiralCreate(ClosureEnv3, .{ .v0 = p0, }), .call = &closure3 };
}
fn closure2(ctx: *anyopaque, p0: *UH0) Fun3 {
    const env: *ClosureEnv2 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: *UH0 = p0; _ = &v0;
    return closureCreate3(v0);
}
fn closureCreate2() Fun2 {
    return .{ .ctx = spiralCreate(ClosureEnv2, .{ }), .call = &closure2 };
}
fn UH10_OriginSlotChar() *UH10 {
    const shared = struct {
        var value: UH10 = UH10{ .tag = 0 };
    };
    return &shared.value;
}
fn UH9_OriginSlotAltLeft(a0: *UH10) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 0, .c0_0 = a0 });
}
fn UH9_OriginSlotAltRight(a0: *UH10) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 1, .c1_0 = a0 });
}
fn UH8_OriginSlotStar(a0: *UH9) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 0, .c0_0 = a0 });
}
fn UH7_OriginSlotCatLeft(a0: *UH8) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 0, .c0_0 = a0 });
}
fn UH7_OriginSlotCatRight(a0: *UH10) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0 });
}
fn US3_SupportSlotRoot() US3 {
    return US3{ .tag = 0 };
}
fn US3_SupportSlotOrigin(a0: *UH7) US3 {
    return US3{ .tag = 1, .c1_0 = a0 };
}
fn US2_SupportSlotMissing() US2 {
    return US2{ .tag = 0 };
}
fn US2_SupportSlotFound(a0: US3) US2 {
    return US2{ .tag = 1, .c1_0 = a0 };
}
fn US4_OriginSlotMissing() US4 {
    return US4{ .tag = 0 };
}
fn US4_OriginSlotFound(a0: *UH7) US4 {
    return US4{ .tag = 1, .c1_0 = a0 };
}
fn US5_OriginSlotMissing() US5 {
    return US5{ .tag = 0 };
}
fn US5_OriginSlotFound(a0: *UH8) US5 {
    return US5{ .tag = 1, .c1_0 = a0 };
}
fn US6_OriginSlotMissing() US6 {
    return US6{ .tag = 0 };
}
fn US6_OriginSlotFound(a0: *UH9) US6 {
    return US6{ .tag = 1, .c1_0 = a0 };
}
fn US7_OriginSlotMissing() US7 {
    return US7{ .tag = 0 };
}
fn US7_OriginSlotFound(a0: *UH10) US7 {
    return US7{ .tag = 1, .c1_0 = a0 };
}
fn antimirov_support_covered_by_typed_slots_20(p0: Fun0, p1: Fun2, p2: *UH0, p3: *UH5, p4: *UH1) bool {
    var v0: Fun0 = p0; _ = &v0;
    var v1: Fun2 = p1; _ = &v1;
    var v2: *UH0 = p2; _ = &v2;
    var v3: *UH5 = p3; _ = &v3;
    var v4: *UH1 = p4; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: Fun3 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v106: US2 = undefined; _ = &v106;
    var v9: US3 = undefined; _ = &v9;
    var v99: US4 = undefined; _ = &v99;
    var v11: *UH4 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v15: *UH0 = undefined; _ = &v15;
    var v13: US0 = undefined; _ = &v13;
    var v16: Fun1 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: *UH0 = undefined; _ = &v18;
    var v75: US5 = undefined; _ = &v75;
    var v19: *UH3 = undefined; _ = &v19;
    var v29: *UH0 = undefined; _ = &v29;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v24: *UH0 = undefined; _ = &v24;
    var v22: US0 = undefined; _ = &v22;
    var v27: *UH0 = undefined; _ = &v27;
    var v25: US0 = undefined; _ = &v25;
    var v30: *UH0 = undefined; _ = &v30;
    var v31: Fun1 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v68: US6 = undefined; _ = &v68;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v45: US7 = undefined; _ = &v45;
    var v35: US0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: Fun1 = undefined; _ = &v37;
    var v38: *UH0 = undefined; _ = &v38;
    var v39: Fun3 = undefined; _ = &v39;
    var v40: bool = undefined; _ = &v40;
    var v41: *UH10 = undefined; _ = &v41;
    var v46: *UH10 = undefined; _ = &v46;
    var v47: *UH9 = undefined; _ = &v47;
    var v59: US7 = undefined; _ = &v59;
    var v49: US0 = undefined; _ = &v49;
    var v50: *UH0 = undefined; _ = &v50;
    var v51: Fun1 = undefined; _ = &v51;
    var v52: *UH0 = undefined; _ = &v52;
    var v53: Fun3 = undefined; _ = &v53;
    var v54: bool = undefined; _ = &v54;
    var v55: *UH10 = undefined; _ = &v55;
    var v60: *UH10 = undefined; _ = &v60;
    var v61: *UH9 = undefined; _ = &v61;
    var v69: *UH9 = undefined; _ = &v69;
    var v70: *UH8 = undefined; _ = &v70;
    var v76: *UH8 = undefined; _ = &v76;
    var v77: *UH7 = undefined; _ = &v77;
    var v90: US7 = undefined; _ = &v90;
    var v79: US0 = undefined; _ = &v79;
    var v80: *UH0 = undefined; _ = &v80;
    var v81: Fun1 = undefined; _ = &v81;
    var v82: *UH0 = undefined; _ = &v82;
    var v83: *UH0 = undefined; _ = &v83;
    var v84: Fun3 = undefined; _ = &v84;
    var v85: bool = undefined; _ = &v85;
    var v86: *UH10 = undefined; _ = &v86;
    var v91: *UH10 = undefined; _ = &v91;
    var v92: *UH7 = undefined; _ = &v92;
    var v100: *UH7 = undefined; _ = &v100;
    var v101: US3 = undefined; _ = &v101;
    var v107: US3 = undefined; _ = &v107;
    var v108: Fun3 = undefined; _ = &v108;
    var v167: *UH0 = undefined; _ = &v167;
    var v109: *UH7 = undefined; _ = &v109;
    var v110: *UH4 = undefined; _ = &v110;
    var v111: *UH2 = undefined; _ = &v111;
    var v112: *UH8 = undefined; _ = &v112;
    var v115: *UH0 = undefined; _ = &v115;
    var v113: US0 = undefined; _ = &v113;
    var v116: Fun1 = undefined; _ = &v116;
    var v117: *UH0 = undefined; _ = &v117;
    var v118: *UH0 = undefined; _ = &v118;
    var v119: *UH3 = undefined; _ = &v119;
    var v120: *UH9 = undefined; _ = &v120;
    var v130: *UH0 = undefined; _ = &v130;
    var v121: *UH2 = undefined; _ = &v121;
    var v122: *UH2 = undefined; _ = &v122;
    var v125: *UH0 = undefined; _ = &v125;
    var v123: US0 = undefined; _ = &v123;
    var v128: *UH0 = undefined; _ = &v128;
    var v126: US0 = undefined; _ = &v126;
    var v131: *UH0 = undefined; _ = &v131;
    var v132: Fun1 = undefined; _ = &v132;
    var v133: *UH0 = undefined; _ = &v133;
    var v134: *UH2 = undefined; _ = &v134;
    var v135: *UH2 = undefined; _ = &v135;
    var v136: *UH10 = undefined; _ = &v136;
    var v137: US0 = undefined; _ = &v137;
    var v138: *UH0 = undefined; _ = &v138;
    var v139: Fun1 = undefined; _ = &v139;
    var v143: *UH10 = undefined; _ = &v143;
    var v144: US0 = undefined; _ = &v144;
    var v145: *UH0 = undefined; _ = &v145;
    var v146: Fun1 = undefined; _ = &v146;
    var v155: *UH10 = undefined; _ = &v155;
    var v156: US0 = undefined; _ = &v156;
    var v157: *UH0 = undefined; _ = &v157;
    var v158: Fun1 = undefined; _ = &v158;
    var v159: *UH0 = undefined; _ = &v159;
    var v168: bool = undefined; _ = &v168;
    while (true) {
        switch (v4.tag) {
            1 => {
                v5 = v4.c1_0;
                v6 = v4.c1_1;
                v7 = v1.call(v1.ctx, v2);
                v8 = v7.call(v7.ctx, v5);
                if (v8) {
                    v9 = US3_SupportSlotRoot();
                    v106 = US2_SupportSlotFound(v9);
                } else {
                    switch (v3.tag) {
                        0 => {
                            v11 = v3.c0_0;
                            v12 = v3.c0_1;
                            switch (v12.tag) {
                                0 => {
                                    v13 = v12.c0_0;
                                    v15 = UH0_RegexChar(v13);
                                },
                                else => unreachable,
                            }
                            v16 = v0.call(v0.ctx, v15);
                            v17 = UH0_RegexEpsilon();
                            v18 = v16.call(v16.ctx, v17);
                            switch (v11.tag) {
                                0 => {
                                    v19 = v11.c0_0;
                                    switch (v19.tag) {
                                        0 => {
                                            v20 = v19.c0_0;
                                            v21 = v19.c0_1;
                                            switch (v20.tag) {
                                                0 => {
                                                    v22 = v20.c0_0;
                                                    v24 = UH0_RegexChar(v22);
                                                },
                                                else => unreachable,
                                            }
                                            switch (v21.tag) {
                                                0 => {
                                                    v25 = v21.c0_0;
                                                    v27 = UH0_RegexChar(v25);
                                                },
                                                else => unreachable,
                                            }
                                            v29 = UH0_RegexAlt(v24, v27);
                                        },
                                        else => unreachable,
                                    }
                                    v30 = UH0_RegexStar(v29);
                                    v31 = v0.call(v0.ctx, v30);
                                    v32 = v31.call(v31.ctx, v18);
                                    switch (v19.tag) {
                                        0 => {
                                            v33 = v19.c0_0;
                                            v34 = v19.c0_1;
                                            switch (v33.tag) {
                                                0 => {
                                                    v35 = v33.c0_0;
                                                    v36 = UH0_RegexEpsilon();
                                                    v37 = v0.call(v0.ctx, v36);
                                                    v38 = v37.call(v37.ctx, v32);
                                                    v39 = v1.call(v1.ctx, v5);
                                                    v40 = v39.call(v39.ctx, v38);
                                                    if (v40) {
                                                        v41 = UH10_OriginSlotChar();
                                                        v45 = US7_OriginSlotFound(v41);
                                                    } else {
                                                        v45 = US7_OriginSlotMissing();
                                                    }
                                                },
                                                else => unreachable,
                                            }
                                            switch (v45.tag) {
                                                1 => {
                                                    v46 = v45.c1_0;
                                                    v47 = UH9_OriginSlotAltLeft(v46);
                                                    v68 = US6_OriginSlotFound(v47);
                                                },
                                                0 => {
                                                    switch (v34.tag) {
                                                        0 => {
                                                            v49 = v34.c0_0;
                                                            v50 = UH0_RegexEpsilon();
                                                            v51 = v0.call(v0.ctx, v50);
                                                            v52 = v51.call(v51.ctx, v32);
                                                            v53 = v1.call(v1.ctx, v5);
                                                            v54 = v53.call(v53.ctx, v52);
                                                            if (v54) {
                                                                v55 = UH10_OriginSlotChar();
                                                                v59 = US7_OriginSlotFound(v55);
                                                            } else {
                                                                v59 = US7_OriginSlotMissing();
                                                            }
                                                        },
                                                        else => unreachable,
                                                    }
                                                    switch (v59.tag) {
                                                        1 => {
                                                            v60 = v59.c1_0;
                                                            v61 = UH9_OriginSlotAltRight(v60);
                                                            v68 = US6_OriginSlotFound(v61);
                                                        },
                                                        0 => {
                                                            v68 = US6_OriginSlotMissing();
                                                        },
                                                        else => unreachable,
                                                    }
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        else => unreachable,
                                    }
                                    switch (v68.tag) {
                                        1 => {
                                            v69 = v68.c1_0;
                                            v70 = UH8_OriginSlotStar(v69);
                                            v75 = US5_OriginSlotFound(v70);
                                        },
                                        0 => {
                                            v75 = US5_OriginSlotMissing();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                            switch (v75.tag) {
                                1 => {
                                    v76 = v75.c1_0;
                                    v77 = UH7_OriginSlotCatLeft(v76);
                                    v99 = US4_OriginSlotFound(v77);
                                },
                                0 => {
                                    switch (v12.tag) {
                                        0 => {
                                            v79 = v12.c0_0;
                                            v80 = UH0_RegexEpsilon();
                                            v81 = v0.call(v0.ctx, v80);
                                            v82 = UH0_RegexEpsilon();
                                            v83 = v81.call(v81.ctx, v82);
                                            v84 = v1.call(v1.ctx, v5);
                                            v85 = v84.call(v84.ctx, v83);
                                            if (v85) {
                                                v86 = UH10_OriginSlotChar();
                                                v90 = US7_OriginSlotFound(v86);
                                            } else {
                                                v90 = US7_OriginSlotMissing();
                                            }
                                        },
                                        else => unreachable,
                                    }
                                    switch (v90.tag) {
                                        1 => {
                                            v91 = v90.c1_0;
                                            v92 = UH7_OriginSlotCatRight(v91);
                                            v99 = US4_OriginSlotFound(v92);
                                        },
                                        0 => {
                                            v99 = US4_OriginSlotMissing();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v99.tag) {
                        1 => {
                            v100 = v99.c1_0;
                            v101 = US3_SupportSlotOrigin(v100);
                            v106 = US2_SupportSlotFound(v101);
                        },
                        0 => {
                            v106 = US2_SupportSlotMissing();
                        },
                        else => unreachable,
                    }
                }
                switch (v106.tag) {
                    1 => {
                        v107 = v106.c1_0;
                        v108 = v1.call(v1.ctx, v5);
                        switch (v107.tag) {
                            1 => {
                                v109 = v107.c1_0;
                                switch (v3.tag) {
                                    0 => {
                                        v110 = v3.c0_0;
                                        v111 = v3.c0_1;
                                        switch (v109.tag) {
                                            0 => {
                                                v112 = v109.c0_0;
                                                switch (v111.tag) {
                                                    0 => {
                                                        v113 = v111.c0_0;
                                                        v115 = UH0_RegexChar(v113);
                                                    },
                                                    else => unreachable,
                                                }
                                                v116 = v0.call(v0.ctx, v115);
                                                v117 = UH0_RegexEpsilon();
                                                v118 = v116.call(v116.ctx, v117);
                                                switch (v110.tag) {
                                                    0 => {
                                                        v119 = v110.c0_0;
                                                        switch (v112.tag) {
                                                            0 => {
                                                                v120 = v112.c0_0;
                                                                switch (v119.tag) {
                                                                    0 => {
                                                                        v121 = v119.c0_0;
                                                                        v122 = v119.c0_1;
                                                                        switch (v121.tag) {
                                                                            0 => {
                                                                                v123 = v121.c0_0;
                                                                                v125 = UH0_RegexChar(v123);
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                        switch (v122.tag) {
                                                                            0 => {
                                                                                v126 = v122.c0_0;
                                                                                v128 = UH0_RegexChar(v126);
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                        v130 = UH0_RegexAlt(v125, v128);
                                                                    },
                                                                    else => unreachable,
                                                                }
                                                                v131 = UH0_RegexStar(v130);
                                                                v132 = v0.call(v0.ctx, v131);
                                                                v133 = v132.call(v132.ctx, v118);
                                                                switch (v119.tag) {
                                                                    0 => {
                                                                        v134 = v119.c0_0;
                                                                        v135 = v119.c0_1;
                                                                        switch (v120.tag) {
                                                                            0 => {
                                                                                v136 = v120.c0_0;
                                                                                switch (v134.tag) {
                                                                                    0 => {
                                                                                        v137 = v134.c0_0;
                                                                                        switch (v136.tag) {
                                                                                            0 => {
                                                                                                v138 = UH0_RegexEpsilon();
                                                                                                v139 = v0.call(v0.ctx, v138);
                                                                                                v167 = v139.call(v139.ctx, v133);
                                                                                            },
                                                                                            else => unreachable,
                                                                                        }
                                                                                    },
                                                                                    else => unreachable,
                                                                                }
                                                                            },
                                                                            1 => {
                                                                                v143 = v120.c1_0;
                                                                                switch (v135.tag) {
                                                                                    0 => {
                                                                                        v144 = v135.c0_0;
                                                                                        switch (v143.tag) {
                                                                                            0 => {
                                                                                                v145 = UH0_RegexEpsilon();
                                                                                                v146 = v0.call(v0.ctx, v145);
                                                                                                v167 = v146.call(v146.ctx, v133);
                                                                                            },
                                                                                            else => unreachable,
                                                                                        }
                                                                                    },
                                                                                    else => unreachable,
                                                                                }
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                    },
                                                                    else => unreachable,
                                                                }
                                                            },
                                                            else => unreachable,
                                                        }
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            1 => {
                                                v155 = v109.c1_0;
                                                switch (v111.tag) {
                                                    0 => {
                                                        v156 = v111.c0_0;
                                                        switch (v155.tag) {
                                                            0 => {
                                                                v157 = UH0_RegexEpsilon();
                                                                v158 = v0.call(v0.ctx, v157);
                                                                v159 = UH0_RegexEpsilon();
                                                                v167 = v158.call(v158.ctx, v159);
                                                            },
                                                            else => unreachable,
                                                        }
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                v167 = v2;
                            },
                            else => unreachable,
                        }
                        v168 = v108.call(v108.ctx, v167);
                        if (v168) {
                            v4 = v6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    0 => {
                        return false;
                    },
                    else => unreachable,
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn US8_TriA() US8 {
    return US8{ .tag = 0 };
}
fn US8_TriB() US8 {
    return US8{ .tag = 1 };
}
fn US8_TriC() US8 {
    return US8{ .tag = 2 };
}
fn UH11_RegexEmpty() *UH11 {
    const shared = struct {
        var value: UH11 = UH11{ .tag = 0 };
    };
    return &shared.value;
}
fn UH11_RegexEpsilon() *UH11 {
    const shared = struct {
        var value: UH11 = UH11{ .tag = 1 };
    };
    return &shared.value;
}
fn UH11_RegexChar(a0: US8) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 2, .c2_0 = a0 });
}
fn UH11_RegexAlt(a0: *UH11, a1: *UH11) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH11_RegexCat(a0: *UH11, a1: *UH11) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH11_RegexStar(a0: *UH11) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 5, .c5_0 = a0 });
}
fn regex_compare_24(p0: *UH11, p1: *UH11) US1 {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v59: *UH11 = undefined; _ = &v59;
    var v60: *UH11 = undefined; _ = &v60;
    var v61: *UH11 = undefined; _ = &v61;
    var v62: *UH11 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var v34: *UH11 = undefined; _ = &v34;
    var v35: *UH11 = undefined; _ = &v35;
    var v40: *UH11 = undefined; _ = &v40;
    var v41: *UH11 = undefined; _ = &v41;
    var v42: US1 = undefined; _ = &v42;
    var v38: US8 = undefined; _ = &v38;
    var v10: US8 = undefined; _ = &v10;
    var v13: US8 = undefined; _ = &v13;
    var v50: *UH11 = undefined; _ = &v50;
    var v51: *UH11 = undefined; _ = &v51;
    var v52: *UH11 = undefined; _ = &v52;
    var v54: *UH11 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_24(v59, v61);
                        switch (v63.tag) {
                            1 => {
                                v0 = v60;
                                v1 = v62;
                                continue;
                            },
                            else => {
                                return v63;
                            },
                        }
                    },
                    else => {
                        return US1_SymbolGreater();
                    },
                }
            },
            4 => {
                v34 = v0.c4_0;
                v35 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v40 = v1.c4_0;
                        v41 = v1.c4_1;
                        v42 = regex_compare_24(v34, v40);
                        switch (v42.tag) {
                            1 => {
                                v0 = v35;
                                v1 = v41;
                                continue;
                            },
                            else => {
                                return v42;
                            },
                        }
                    },
                    2 => {
                        v38 = v1.c2_0;
                        return US1_SymbolGreater();
                    },
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolGreater();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            2 => {
                v10 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v13 = v1.c2_0;
                        switch (v10.tag) {
                            0 => {
                                switch (v13.tag) {
                                    0 => {
                                        return US1_SymbolSame();
                                    },
                                    else => {
                                        return US1_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US1_SymbolGreater();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US1_SymbolSame();
                                                    },
                                                    2 => {
                                                        return US1_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US1_SymbolGreater();
                                                    },
                                                    2 => {
                                                        return US1_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                    },
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolGreater();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US1_SymbolSame();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US1_SymbolGreater();
                    },
                    1 => {
                        return US1_SymbolSame();
                    },
                    else => {
                        return US1_SymbolLess();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US1_SymbolLess();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        v0 = v50;
                        v1 = v54;
                        continue;
                    },
                    else => {
                        return US1_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_23(p0: *UH11, p1: *UH11) *UH11 {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v2: *UH11 = undefined; _ = &v2;
    var v3: *UH11 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH11 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_24(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_23(v0, v3);
                    return UH11_RegexAlt(v2, v6);
                },
                0 => {
                    return UH11_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
        0 => {
            return v0;
        },
        else => {
            v11 = regex_compare_24(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH11_RegexAlt(v1, v0);
                },
                0 => {
                    return UH11_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_22(p0: *UH11, p1: *UH11) *UH11 {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v2: *UH11 = undefined; _ = &v2;
    var v3: *UH11 = undefined; _ = &v3;
    var v4: *UH11 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_23(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_23(v0, v1);
            },
        }
    }
}
fn regex_equal_26(p0: *UH11, p1: *UH11) bool {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v24: *UH11 = undefined; _ = &v24;
    var v25: *UH11 = undefined; _ = &v25;
    var v26: *UH11 = undefined; _ = &v26;
    var v27: *UH11 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH11 = undefined; _ = &v32;
    var v33: *UH11 = undefined; _ = &v33;
    var v34: *UH11 = undefined; _ = &v34;
    var v35: *UH11 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US8 = undefined; _ = &v4;
    var v5: US8 = undefined; _ = &v5;
    var v21: US1 = undefined; _ = &v21;
    var v40: *UH11 = undefined; _ = &v40;
    var v41: *UH11 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_26(v24, v26);
                        if (v28) {
                            v0 = v25;
                            v1 = v27;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            4 => {
                v32 = v0.c4_0;
                v33 = v0.c4_1;
                switch (v1.tag) {
                    4 => {
                        v34 = v1.c4_0;
                        v35 = v1.c4_1;
                        v36 = regex_equal_26(v32, v34);
                        if (v36) {
                            v0 = v33;
                            v1 = v35;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            2 => {
                v4 = v0.c2_0;
                switch (v1.tag) {
                    2 => {
                        v5 = v1.c2_0;
                        switch (v4.tag) {
                            0 => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US1_SymbolSame();
                                    },
                                    else => {
                                        v21 = US1_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US1_SymbolGreater();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US1_SymbolSame();
                                                    },
                                                    2 => {
                                                        v21 = US1_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US1_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v21 = US1_SymbolSame();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                }
                            },
                        }
                        switch (v21.tag) {
                            1 => {
                                return true;
                            },
                            else => {
                                return false;
                            },
                        }
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    1 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
            5 => {
                v40 = v0.c5_0;
                switch (v1.tag) {
                    5 => {
                        v41 = v1.c5_0;
                        v0 = v40;
                        v1 = v41;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn make_cat_25(p0: *UH11, p1: *UH11) *UH11 {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v12: *UH11 = undefined; _ = &v12;
    var v13: *UH11 = undefined; _ = &v13;
    var v14: *UH11 = undefined; _ = &v14;
    var v4: *UH11 = undefined; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH11_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH11_RegexEmpty();
                },
                else => {
                    switch (v0.tag) {
                        1 => {
                            return v1;
                        },
                        else => {
                            switch (v1.tag) {
                                1 => {
                                    return v0;
                                },
                                else => {
                                    switch (v0.tag) {
                                        4 => {
                                            v12 = v0.c4_0;
                                            v13 = v0.c4_1;
                                            v14 = make_cat_25(v13, v1);
                                            return UH11_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_26(v4, v5);
                                                    if (v6) {
                                                        return UH11_RegexStar(v4);
                                                    } else {
                                                        return UH11_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH11_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH11_RegexCat(v0, v1);
                                        },
                                    }
                                },
                            }
                        },
                    }
                },
            }
        },
    }
}
fn make_star_27(p0: *UH11) *UH11 {
    var v0: *UH11 = p0; _ = &v0;
    var v3: *UH11 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH11_RegexEpsilon();
        },
        1 => {
            return UH11_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH11_RegexStar(v3);
        },
        else => {
            return UH11_RegexStar(v0);
        },
    }
}
fn normalize_21(p0: *UH11) *UH11 {
    var v0: *UH11 = p0; _ = &v0;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: *UH11 = undefined; _ = &v6;
    var v7: *UH11 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    var v10: *UH11 = undefined; _ = &v10;
    var v11: *UH11 = undefined; _ = &v11;
    var v12: *UH11 = undefined; _ = &v12;
    var v13: *UH11 = undefined; _ = &v13;
    var v3: US8 = undefined; _ = &v3;
    var v15: *UH11 = undefined; _ = &v15;
    var v16: *UH11 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_21(v5);
            v8 = normalize_21(v6);
            return make_alt_22(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_21(v10);
            v13 = normalize_21(v11);
            return make_cat_25(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH11_RegexChar(v3);
        },
        0 => {
            return UH11_RegexEmpty();
        },
        1 => {
            return UH11_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_21(v15);
            return make_star_27(v16);
        },
        else => unreachable,
    }
}
fn UH12_RegexListNil() *UH12 {
    const shared = struct {
        var value: UH12 = UH12{ .tag = 0 };
    };
    return &shared.value;
}
fn UH12_RegexListCons(a0: *UH11, a1: *UH12) *UH12 {
    return spiralCreate(UH12, UH12{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn regex_list_contains_31(p0: *UH11, p1: *UH12) bool {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    var v2: *UH11 = undefined; _ = &v2;
    var v3: *UH12 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_26(v0, v2);
                if (v4) {
                    return true;
                } else {
                    v1 = v3;
                    continue;
                }
            },
            0 => {
                return false;
            },
            else => unreachable,
        }
    }
}
fn antimirov_insert_unique_30(p0: *UH11, p1: *UH12) *UH12 {
    var v0: *UH11 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    const v2: *UH11 = normalize_21(v0);
    const v3: bool = regex_list_contains_31(v2, v1);
    if (v3) {
        return v1;
    } else {
        return UH12_RegexListCons(v2, v1);
    }
}
fn antimirov_union_29(p0: *UH12, p1: *UH12) *UH12 {
    var v0: *UH12 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    var v2: *UH11 = undefined; _ = &v2;
    var v3: *UH12 = undefined; _ = &v3;
    var v4: *UH12 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = antimirov_insert_unique_30(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn antimirov_map_cat_right_32(p0: *UH12, p1: *UH11) *UH12 {
    var v0: *UH12 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v3: *UH11 = undefined; _ = &v3;
    var v4: *UH12 = undefined; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = make_cat_25(v3, v1);
            v6 = antimirov_map_cat_right_32(v4, v1);
            return antimirov_insert_unique_30(v5, v6);
        },
        0 => {
            return UH12_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_residual_support_28(p0: *UH11) *UH12 {
    var v0: *UH11 = p0; _ = &v0;
    var v7: *UH11 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    var v9: *UH12 = undefined; _ = &v9;
    var v10: *UH12 = undefined; _ = &v10;
    var v12: *UH11 = undefined; _ = &v12;
    var v13: *UH11 = undefined; _ = &v13;
    var v14: *UH12 = undefined; _ = &v14;
    var v15: *UH12 = undefined; _ = &v15;
    var v16: *UH12 = undefined; _ = &v16;
    var v3: US8 = undefined; _ = &v3;
    var v4: *UH11 = undefined; _ = &v4;
    var v5: *UH12 = undefined; _ = &v5;
    var v18: *UH11 = undefined; _ = &v18;
    var v19: *UH12 = undefined; _ = &v19;
    var v20: *UH11 = undefined; _ = &v20;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = antimirov_residual_support_28(v7);
            v10 = antimirov_residual_support_28(v8);
            return antimirov_union_29(v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = antimirov_residual_support_28(v12);
            v15 = antimirov_map_cat_right_32(v14, v13);
            v16 = antimirov_residual_support_28(v13);
            return antimirov_union_29(v15, v16);
        },
        2 => {
            v3 = v0.c2_0;
            v4 = UH11_RegexEpsilon();
            v5 = UH12_RegexListNil();
            return UH12_RegexListCons(v4, v5);
        },
        0 => {
            return UH12_RegexListNil();
        },
        1 => {
            return UH12_RegexListNil();
        },
        5 => {
            v18 = v0.c5_0;
            v19 = antimirov_residual_support_28(v18);
            v20 = UH11_RegexStar(v18);
            return antimirov_map_cat_right_32(v19, v20);
        },
        else => unreachable,
    }
}
fn regex_list_distinct_33(p0: *UH12) bool {
    var v0: *UH12 = p0; _ = &v0;
    var v1: *UH11 = undefined; _ = &v1;
    var v2: *UH12 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_list_contains_31(v1, v2);
                if (v3) {
                    return false;
                } else {
                    v0 = v2;
                    continue;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn UH13_PositionTreeChar(a0: US8) *UH13 {
    return spiralCreate(UH13, UH13{ .tag = 0, .c0_0 = a0 });
}
fn UH14_PositionTreeStar(a0: *UH13) *UH14 {
    return spiralCreate(UH14, UH14{ .tag = 0, .c0_0 = a0 });
}
fn antimirov_position_tree_budget_35(p0: *UH13) *UH6 {
    var v0: *UH13 = p0; _ = &v0;
    var v1: US8 = undefined; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = UH6_StateBudgetZero();
            return UH6_StateBudgetSucc(v2);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_34(p0: *UH14) *UH6 {
    var v0: *UH14 = p0; _ = &v0;
    var v1: *UH13 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return antimirov_position_tree_budget_35(v1);
        },
        else => unreachable,
    }
}
fn regex_position_count_36(p0: *UH11) *UH6 {
    var v0: *UH11 = p0; _ = &v0;
    var v6: *UH11 = undefined; _ = &v6;
    var v7: *UH11 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v9: *UH6 = undefined; _ = &v9;
    var v11: *UH11 = undefined; _ = &v11;
    var v12: *UH11 = undefined; _ = &v12;
    var v13: *UH6 = undefined; _ = &v13;
    var v14: *UH6 = undefined; _ = &v14;
    var v3: US8 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v16: *UH11 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_36(v6);
                v9 = regex_position_count_36(v7);
                return state_budget_add_14(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_36(v11);
                v14 = regex_position_count_36(v12);
                return state_budget_add_14(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH6_StateBudgetZero();
                return UH6_StateBudgetSucc(v4);
            },
            0 => {
                return UH6_StateBudgetZero();
            },
            1 => {
                return UH6_StateBudgetZero();
            },
            5 => {
                v16 = v0.c5_0;
                v0 = v16;
                continue;
            },
            else => unreachable,
        }
    }
}
fn closure5(ctx: *anyopaque, p1: *UH11) *UH11 {
    const env: *ClosureEnv5 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *UH11 = env.v0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    const v2: *UH11 = make_cat_25(v0, v1);
    return normalize_21(v2);
}
fn closureCreate5(p0: *UH11) Fun5 {
    return .{ .ctx = spiralCreate(ClosureEnv5, .{ .v0 = p0, }), .call = &closure5 };
}
fn closure4(ctx: *anyopaque, p0: *UH11) Fun5 {
    const env: *ClosureEnv4 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: *UH11 = p0; _ = &v0;
    return closureCreate5(v0);
}
fn closureCreate4() Fun4 {
    return .{ .ctx = spiralCreate(ClosureEnv4, .{ }), .call = &closure4 };
}
fn closure7(ctx: *anyopaque, p1: *UH11) bool {
    const env: *ClosureEnv7 = @ptrCast(@alignCast(ctx)); _ = &env;
    var v0: *UH11 = env.v0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    return regex_equal_26(v0, v1);
}
fn closureCreate7(p0: *UH11) Fun7 {
    return .{ .ctx = spiralCreate(ClosureEnv7, .{ .v0 = p0, }), .call = &closure7 };
}
fn closure6(ctx: *anyopaque, p0: *UH11) Fun7 {
    const env: *ClosureEnv6 = @ptrCast(@alignCast(ctx)); _ = &env;

    var v0: *UH11 = p0; _ = &v0;
    return closureCreate7(v0);
}
fn closureCreate6() Fun6 {
    return .{ .ctx = spiralCreate(ClosureEnv6, .{ }), .call = &closure6 };
}
fn UH15_OriginSlotStar(a0: *UH10) *UH15 {
    return spiralCreate(UH15, UH15{ .tag = 0, .c0_0 = a0 });
}
fn US10_SupportSlotRoot() US10 {
    return US10{ .tag = 0 };
}
fn US10_SupportSlotOrigin(a0: *UH15) US10 {
    return US10{ .tag = 1, .c1_0 = a0 };
}
fn US9_SupportSlotMissing() US9 {
    return US9{ .tag = 0 };
}
fn US9_SupportSlotFound(a0: US10) US9 {
    return US9{ .tag = 1, .c1_0 = a0 };
}
fn US11_OriginSlotMissing() US11 {
    return US11{ .tag = 0 };
}
fn US11_OriginSlotFound(a0: *UH15) US11 {
    return US11{ .tag = 1, .c1_0 = a0 };
}
fn antimirov_support_covered_by_typed_slots_37(p0: Fun4, p1: Fun6, p2: *UH11, p3: *UH14, p4: *UH12) bool {
    var v0: Fun4 = p0; _ = &v0;
    var v1: Fun6 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH14 = p3; _ = &v3;
    var v4: *UH12 = p4; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    var v7: Fun7 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v43: US9 = undefined; _ = &v43;
    var v9: US10 = undefined; _ = &v9;
    var v36: US11 = undefined; _ = &v36;
    var v11: *UH13 = undefined; _ = &v11;
    var v14: *UH11 = undefined; _ = &v14;
    var v12: US8 = undefined; _ = &v12;
    var v15: *UH11 = undefined; _ = &v15;
    var v16: Fun5 = undefined; _ = &v16;
    var v17: *UH11 = undefined; _ = &v17;
    var v18: *UH11 = undefined; _ = &v18;
    var v29: US7 = undefined; _ = &v29;
    var v19: US8 = undefined; _ = &v19;
    var v20: *UH11 = undefined; _ = &v20;
    var v21: Fun5 = undefined; _ = &v21;
    var v22: *UH11 = undefined; _ = &v22;
    var v23: Fun7 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    var v25: *UH10 = undefined; _ = &v25;
    var v30: *UH10 = undefined; _ = &v30;
    var v31: *UH15 = undefined; _ = &v31;
    var v37: *UH15 = undefined; _ = &v37;
    var v38: US10 = undefined; _ = &v38;
    var v44: US10 = undefined; _ = &v44;
    var v45: Fun7 = undefined; _ = &v45;
    var v65: *UH11 = undefined; _ = &v65;
    var v46: *UH15 = undefined; _ = &v46;
    var v47: *UH13 = undefined; _ = &v47;
    var v48: *UH10 = undefined; _ = &v48;
    var v51: *UH11 = undefined; _ = &v51;
    var v49: US8 = undefined; _ = &v49;
    var v52: *UH11 = undefined; _ = &v52;
    var v53: Fun5 = undefined; _ = &v53;
    var v54: *UH11 = undefined; _ = &v54;
    var v55: *UH11 = undefined; _ = &v55;
    var v56: US8 = undefined; _ = &v56;
    var v57: *UH11 = undefined; _ = &v57;
    var v58: Fun5 = undefined; _ = &v58;
    var v66: bool = undefined; _ = &v66;
    while (true) {
        switch (v4.tag) {
            1 => {
                v5 = v4.c1_0;
                v6 = v4.c1_1;
                v7 = v1.call(v1.ctx, v2);
                v8 = v7.call(v7.ctx, v5);
                if (v8) {
                    v9 = US10_SupportSlotRoot();
                    v43 = US9_SupportSlotFound(v9);
                } else {
                    switch (v3.tag) {
                        0 => {
                            v11 = v3.c0_0;
                            switch (v11.tag) {
                                0 => {
                                    v12 = v11.c0_0;
                                    v14 = UH11_RegexChar(v12);
                                },
                                else => unreachable,
                            }
                            v15 = UH11_RegexStar(v14);
                            v16 = v0.call(v0.ctx, v15);
                            v17 = UH11_RegexEpsilon();
                            v18 = v16.call(v16.ctx, v17);
                            switch (v11.tag) {
                                0 => {
                                    v19 = v11.c0_0;
                                    v20 = UH11_RegexEpsilon();
                                    v21 = v0.call(v0.ctx, v20);
                                    v22 = v21.call(v21.ctx, v18);
                                    v23 = v1.call(v1.ctx, v5);
                                    v24 = v23.call(v23.ctx, v22);
                                    if (v24) {
                                        v25 = UH10_OriginSlotChar();
                                        v29 = US7_OriginSlotFound(v25);
                                    } else {
                                        v29 = US7_OriginSlotMissing();
                                    }
                                },
                                else => unreachable,
                            }
                            switch (v29.tag) {
                                1 => {
                                    v30 = v29.c1_0;
                                    v31 = UH15_OriginSlotStar(v30);
                                    v36 = US11_OriginSlotFound(v31);
                                },
                                0 => {
                                    v36 = US11_OriginSlotMissing();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v36.tag) {
                        1 => {
                            v37 = v36.c1_0;
                            v38 = US10_SupportSlotOrigin(v37);
                            v43 = US9_SupportSlotFound(v38);
                        },
                        0 => {
                            v43 = US9_SupportSlotMissing();
                        },
                        else => unreachable,
                    }
                }
                switch (v43.tag) {
                    1 => {
                        v44 = v43.c1_0;
                        v45 = v1.call(v1.ctx, v5);
                        switch (v44.tag) {
                            1 => {
                                v46 = v44.c1_0;
                                switch (v3.tag) {
                                    0 => {
                                        v47 = v3.c0_0;
                                        switch (v46.tag) {
                                            0 => {
                                                v48 = v46.c0_0;
                                                switch (v47.tag) {
                                                    0 => {
                                                        v49 = v47.c0_0;
                                                        v51 = UH11_RegexChar(v49);
                                                    },
                                                    else => unreachable,
                                                }
                                                v52 = UH11_RegexStar(v51);
                                                v53 = v0.call(v0.ctx, v52);
                                                v54 = UH11_RegexEpsilon();
                                                v55 = v53.call(v53.ctx, v54);
                                                switch (v47.tag) {
                                                    0 => {
                                                        v56 = v47.c0_0;
                                                        switch (v48.tag) {
                                                            0 => {
                                                                v57 = UH11_RegexEpsilon();
                                                                v58 = v0.call(v0.ctx, v57);
                                                                v65 = v58.call(v58.ctx, v55);
                                                            },
                                                            else => unreachable,
                                                        }
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                v65 = v2;
                            },
                            else => unreachable,
                        }
                        v66 = v45.call(v45.ctx, v65);
                        if (v66) {
                            v4 = v6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    0 => {
                        return false;
                    },
                    else => unreachable,
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn UH16_PositionTreeAlt(a0: *UH13, a1: *UH13) *UH16 {
    return spiralCreate(UH16, UH16{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH17_PositionTreeStar(a0: *UH16) *UH17 {
    return spiralCreate(UH17, UH17{ .tag = 0, .c0_0 = a0 });
}
fn UH18_PositionTreeCat(a0: *UH17, a1: *UH13) *UH18 {
    return spiralCreate(UH18, UH18{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn antimirov_position_tree_budget_40(p0: *UH16) *UH6 {
    var v0: *UH16 = p0; _ = &v0;
    var v1: *UH13 = undefined; _ = &v1;
    var v2: *UH13 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = antimirov_position_tree_budget_35(v1);
            v4 = antimirov_position_tree_budget_35(v2);
            return state_budget_add_14(v3, v4);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_39(p0: *UH17) *UH6 {
    var v0: *UH17 = p0; _ = &v0;
    var v1: *UH16 = undefined; _ = &v1;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            return antimirov_position_tree_budget_40(v1);
        },
        else => unreachable,
    }
}
fn antimirov_position_tree_budget_38(p0: *UH18) *UH6 {
    var v0: *UH18 = p0; _ = &v0;
    var v1: *UH17 = undefined; _ = &v1;
    var v2: *UH13 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = antimirov_position_tree_budget_39(v1);
            v4 = antimirov_position_tree_budget_35(v2);
            return state_budget_add_14(v3, v4);
        },
        else => unreachable,
    }
}
fn antimirov_support_covered_by_typed_slots_41(p0: Fun4, p1: Fun6, p2: *UH11, p3: *UH18, p4: *UH12) bool {
    var v0: Fun4 = p0; _ = &v0;
    var v1: Fun6 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH18 = p3; _ = &v3;
    var v4: *UH12 = p4; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    var v7: Fun7 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v106: US2 = undefined; _ = &v106;
    var v9: US3 = undefined; _ = &v9;
    var v99: US4 = undefined; _ = &v99;
    var v11: *UH17 = undefined; _ = &v11;
    var v12: *UH13 = undefined; _ = &v12;
    var v15: *UH11 = undefined; _ = &v15;
    var v13: US8 = undefined; _ = &v13;
    var v16: Fun5 = undefined; _ = &v16;
    var v17: *UH11 = undefined; _ = &v17;
    var v18: *UH11 = undefined; _ = &v18;
    var v75: US5 = undefined; _ = &v75;
    var v19: *UH16 = undefined; _ = &v19;
    var v29: *UH11 = undefined; _ = &v29;
    var v20: *UH13 = undefined; _ = &v20;
    var v21: *UH13 = undefined; _ = &v21;
    var v24: *UH11 = undefined; _ = &v24;
    var v22: US8 = undefined; _ = &v22;
    var v27: *UH11 = undefined; _ = &v27;
    var v25: US8 = undefined; _ = &v25;
    var v30: *UH11 = undefined; _ = &v30;
    var v31: Fun5 = undefined; _ = &v31;
    var v32: *UH11 = undefined; _ = &v32;
    var v68: US6 = undefined; _ = &v68;
    var v33: *UH13 = undefined; _ = &v33;
    var v34: *UH13 = undefined; _ = &v34;
    var v45: US7 = undefined; _ = &v45;
    var v35: US8 = undefined; _ = &v35;
    var v36: *UH11 = undefined; _ = &v36;
    var v37: Fun5 = undefined; _ = &v37;
    var v38: *UH11 = undefined; _ = &v38;
    var v39: Fun7 = undefined; _ = &v39;
    var v40: bool = undefined; _ = &v40;
    var v41: *UH10 = undefined; _ = &v41;
    var v46: *UH10 = undefined; _ = &v46;
    var v47: *UH9 = undefined; _ = &v47;
    var v59: US7 = undefined; _ = &v59;
    var v49: US8 = undefined; _ = &v49;
    var v50: *UH11 = undefined; _ = &v50;
    var v51: Fun5 = undefined; _ = &v51;
    var v52: *UH11 = undefined; _ = &v52;
    var v53: Fun7 = undefined; _ = &v53;
    var v54: bool = undefined; _ = &v54;
    var v55: *UH10 = undefined; _ = &v55;
    var v60: *UH10 = undefined; _ = &v60;
    var v61: *UH9 = undefined; _ = &v61;
    var v69: *UH9 = undefined; _ = &v69;
    var v70: *UH8 = undefined; _ = &v70;
    var v76: *UH8 = undefined; _ = &v76;
    var v77: *UH7 = undefined; _ = &v77;
    var v90: US7 = undefined; _ = &v90;
    var v79: US8 = undefined; _ = &v79;
    var v80: *UH11 = undefined; _ = &v80;
    var v81: Fun5 = undefined; _ = &v81;
    var v82: *UH11 = undefined; _ = &v82;
    var v83: *UH11 = undefined; _ = &v83;
    var v84: Fun7 = undefined; _ = &v84;
    var v85: bool = undefined; _ = &v85;
    var v86: *UH10 = undefined; _ = &v86;
    var v91: *UH10 = undefined; _ = &v91;
    var v92: *UH7 = undefined; _ = &v92;
    var v100: *UH7 = undefined; _ = &v100;
    var v101: US3 = undefined; _ = &v101;
    var v107: US3 = undefined; _ = &v107;
    var v108: Fun7 = undefined; _ = &v108;
    var v167: *UH11 = undefined; _ = &v167;
    var v109: *UH7 = undefined; _ = &v109;
    var v110: *UH17 = undefined; _ = &v110;
    var v111: *UH13 = undefined; _ = &v111;
    var v112: *UH8 = undefined; _ = &v112;
    var v115: *UH11 = undefined; _ = &v115;
    var v113: US8 = undefined; _ = &v113;
    var v116: Fun5 = undefined; _ = &v116;
    var v117: *UH11 = undefined; _ = &v117;
    var v118: *UH11 = undefined; _ = &v118;
    var v119: *UH16 = undefined; _ = &v119;
    var v120: *UH9 = undefined; _ = &v120;
    var v130: *UH11 = undefined; _ = &v130;
    var v121: *UH13 = undefined; _ = &v121;
    var v122: *UH13 = undefined; _ = &v122;
    var v125: *UH11 = undefined; _ = &v125;
    var v123: US8 = undefined; _ = &v123;
    var v128: *UH11 = undefined; _ = &v128;
    var v126: US8 = undefined; _ = &v126;
    var v131: *UH11 = undefined; _ = &v131;
    var v132: Fun5 = undefined; _ = &v132;
    var v133: *UH11 = undefined; _ = &v133;
    var v134: *UH13 = undefined; _ = &v134;
    var v135: *UH13 = undefined; _ = &v135;
    var v136: *UH10 = undefined; _ = &v136;
    var v137: US8 = undefined; _ = &v137;
    var v138: *UH11 = undefined; _ = &v138;
    var v139: Fun5 = undefined; _ = &v139;
    var v143: *UH10 = undefined; _ = &v143;
    var v144: US8 = undefined; _ = &v144;
    var v145: *UH11 = undefined; _ = &v145;
    var v146: Fun5 = undefined; _ = &v146;
    var v155: *UH10 = undefined; _ = &v155;
    var v156: US8 = undefined; _ = &v156;
    var v157: *UH11 = undefined; _ = &v157;
    var v158: Fun5 = undefined; _ = &v158;
    var v159: *UH11 = undefined; _ = &v159;
    var v168: bool = undefined; _ = &v168;
    while (true) {
        switch (v4.tag) {
            1 => {
                v5 = v4.c1_0;
                v6 = v4.c1_1;
                v7 = v1.call(v1.ctx, v2);
                v8 = v7.call(v7.ctx, v5);
                if (v8) {
                    v9 = US3_SupportSlotRoot();
                    v106 = US2_SupportSlotFound(v9);
                } else {
                    switch (v3.tag) {
                        0 => {
                            v11 = v3.c0_0;
                            v12 = v3.c0_1;
                            switch (v12.tag) {
                                0 => {
                                    v13 = v12.c0_0;
                                    v15 = UH11_RegexChar(v13);
                                },
                                else => unreachable,
                            }
                            v16 = v0.call(v0.ctx, v15);
                            v17 = UH11_RegexEpsilon();
                            v18 = v16.call(v16.ctx, v17);
                            switch (v11.tag) {
                                0 => {
                                    v19 = v11.c0_0;
                                    switch (v19.tag) {
                                        0 => {
                                            v20 = v19.c0_0;
                                            v21 = v19.c0_1;
                                            switch (v20.tag) {
                                                0 => {
                                                    v22 = v20.c0_0;
                                                    v24 = UH11_RegexChar(v22);
                                                },
                                                else => unreachable,
                                            }
                                            switch (v21.tag) {
                                                0 => {
                                                    v25 = v21.c0_0;
                                                    v27 = UH11_RegexChar(v25);
                                                },
                                                else => unreachable,
                                            }
                                            v29 = UH11_RegexAlt(v24, v27);
                                        },
                                        else => unreachable,
                                    }
                                    v30 = UH11_RegexStar(v29);
                                    v31 = v0.call(v0.ctx, v30);
                                    v32 = v31.call(v31.ctx, v18);
                                    switch (v19.tag) {
                                        0 => {
                                            v33 = v19.c0_0;
                                            v34 = v19.c0_1;
                                            switch (v33.tag) {
                                                0 => {
                                                    v35 = v33.c0_0;
                                                    v36 = UH11_RegexEpsilon();
                                                    v37 = v0.call(v0.ctx, v36);
                                                    v38 = v37.call(v37.ctx, v32);
                                                    v39 = v1.call(v1.ctx, v5);
                                                    v40 = v39.call(v39.ctx, v38);
                                                    if (v40) {
                                                        v41 = UH10_OriginSlotChar();
                                                        v45 = US7_OriginSlotFound(v41);
                                                    } else {
                                                        v45 = US7_OriginSlotMissing();
                                                    }
                                                },
                                                else => unreachable,
                                            }
                                            switch (v45.tag) {
                                                1 => {
                                                    v46 = v45.c1_0;
                                                    v47 = UH9_OriginSlotAltLeft(v46);
                                                    v68 = US6_OriginSlotFound(v47);
                                                },
                                                0 => {
                                                    switch (v34.tag) {
                                                        0 => {
                                                            v49 = v34.c0_0;
                                                            v50 = UH11_RegexEpsilon();
                                                            v51 = v0.call(v0.ctx, v50);
                                                            v52 = v51.call(v51.ctx, v32);
                                                            v53 = v1.call(v1.ctx, v5);
                                                            v54 = v53.call(v53.ctx, v52);
                                                            if (v54) {
                                                                v55 = UH10_OriginSlotChar();
                                                                v59 = US7_OriginSlotFound(v55);
                                                            } else {
                                                                v59 = US7_OriginSlotMissing();
                                                            }
                                                        },
                                                        else => unreachable,
                                                    }
                                                    switch (v59.tag) {
                                                        1 => {
                                                            v60 = v59.c1_0;
                                                            v61 = UH9_OriginSlotAltRight(v60);
                                                            v68 = US6_OriginSlotFound(v61);
                                                        },
                                                        0 => {
                                                            v68 = US6_OriginSlotMissing();
                                                        },
                                                        else => unreachable,
                                                    }
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        else => unreachable,
                                    }
                                    switch (v68.tag) {
                                        1 => {
                                            v69 = v68.c1_0;
                                            v70 = UH8_OriginSlotStar(v69);
                                            v75 = US5_OriginSlotFound(v70);
                                        },
                                        0 => {
                                            v75 = US5_OriginSlotMissing();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                            switch (v75.tag) {
                                1 => {
                                    v76 = v75.c1_0;
                                    v77 = UH7_OriginSlotCatLeft(v76);
                                    v99 = US4_OriginSlotFound(v77);
                                },
                                0 => {
                                    switch (v12.tag) {
                                        0 => {
                                            v79 = v12.c0_0;
                                            v80 = UH11_RegexEpsilon();
                                            v81 = v0.call(v0.ctx, v80);
                                            v82 = UH11_RegexEpsilon();
                                            v83 = v81.call(v81.ctx, v82);
                                            v84 = v1.call(v1.ctx, v5);
                                            v85 = v84.call(v84.ctx, v83);
                                            if (v85) {
                                                v86 = UH10_OriginSlotChar();
                                                v90 = US7_OriginSlotFound(v86);
                                            } else {
                                                v90 = US7_OriginSlotMissing();
                                            }
                                        },
                                        else => unreachable,
                                    }
                                    switch (v90.tag) {
                                        1 => {
                                            v91 = v90.c1_0;
                                            v92 = UH7_OriginSlotCatRight(v91);
                                            v99 = US4_OriginSlotFound(v92);
                                        },
                                        0 => {
                                            v99 = US4_OriginSlotMissing();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v99.tag) {
                        1 => {
                            v100 = v99.c1_0;
                            v101 = US3_SupportSlotOrigin(v100);
                            v106 = US2_SupportSlotFound(v101);
                        },
                        0 => {
                            v106 = US2_SupportSlotMissing();
                        },
                        else => unreachable,
                    }
                }
                switch (v106.tag) {
                    1 => {
                        v107 = v106.c1_0;
                        v108 = v1.call(v1.ctx, v5);
                        switch (v107.tag) {
                            1 => {
                                v109 = v107.c1_0;
                                switch (v3.tag) {
                                    0 => {
                                        v110 = v3.c0_0;
                                        v111 = v3.c0_1;
                                        switch (v109.tag) {
                                            0 => {
                                                v112 = v109.c0_0;
                                                switch (v111.tag) {
                                                    0 => {
                                                        v113 = v111.c0_0;
                                                        v115 = UH11_RegexChar(v113);
                                                    },
                                                    else => unreachable,
                                                }
                                                v116 = v0.call(v0.ctx, v115);
                                                v117 = UH11_RegexEpsilon();
                                                v118 = v116.call(v116.ctx, v117);
                                                switch (v110.tag) {
                                                    0 => {
                                                        v119 = v110.c0_0;
                                                        switch (v112.tag) {
                                                            0 => {
                                                                v120 = v112.c0_0;
                                                                switch (v119.tag) {
                                                                    0 => {
                                                                        v121 = v119.c0_0;
                                                                        v122 = v119.c0_1;
                                                                        switch (v121.tag) {
                                                                            0 => {
                                                                                v123 = v121.c0_0;
                                                                                v125 = UH11_RegexChar(v123);
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                        switch (v122.tag) {
                                                                            0 => {
                                                                                v126 = v122.c0_0;
                                                                                v128 = UH11_RegexChar(v126);
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                        v130 = UH11_RegexAlt(v125, v128);
                                                                    },
                                                                    else => unreachable,
                                                                }
                                                                v131 = UH11_RegexStar(v130);
                                                                v132 = v0.call(v0.ctx, v131);
                                                                v133 = v132.call(v132.ctx, v118);
                                                                switch (v119.tag) {
                                                                    0 => {
                                                                        v134 = v119.c0_0;
                                                                        v135 = v119.c0_1;
                                                                        switch (v120.tag) {
                                                                            0 => {
                                                                                v136 = v120.c0_0;
                                                                                switch (v134.tag) {
                                                                                    0 => {
                                                                                        v137 = v134.c0_0;
                                                                                        switch (v136.tag) {
                                                                                            0 => {
                                                                                                v138 = UH11_RegexEpsilon();
                                                                                                v139 = v0.call(v0.ctx, v138);
                                                                                                v167 = v139.call(v139.ctx, v133);
                                                                                            },
                                                                                            else => unreachable,
                                                                                        }
                                                                                    },
                                                                                    else => unreachable,
                                                                                }
                                                                            },
                                                                            1 => {
                                                                                v143 = v120.c1_0;
                                                                                switch (v135.tag) {
                                                                                    0 => {
                                                                                        v144 = v135.c0_0;
                                                                                        switch (v143.tag) {
                                                                                            0 => {
                                                                                                v145 = UH11_RegexEpsilon();
                                                                                                v146 = v0.call(v0.ctx, v145);
                                                                                                v167 = v146.call(v146.ctx, v133);
                                                                                            },
                                                                                            else => unreachable,
                                                                                        }
                                                                                    },
                                                                                    else => unreachable,
                                                                                }
                                                                            },
                                                                            else => unreachable,
                                                                        }
                                                                    },
                                                                    else => unreachable,
                                                                }
                                                            },
                                                            else => unreachable,
                                                        }
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            1 => {
                                                v155 = v109.c1_0;
                                                switch (v111.tag) {
                                                    0 => {
                                                        v156 = v111.c0_0;
                                                        switch (v155.tag) {
                                                            0 => {
                                                                v157 = UH11_RegexEpsilon();
                                                                v158 = v0.call(v0.ctx, v157);
                                                                v159 = UH11_RegexEpsilon();
                                                                v167 = v158.call(v158.ctx, v159);
                                                            },
                                                            else => unreachable,
                                                        }
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                v167 = v2;
                            },
                            else => unreachable,
                        }
                        v168 = v108.call(v108.ctx, v167);
                        if (v168) {
                            v4 = v6;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    0 => {
                        return false;
                    },
                    else => unreachable,
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn spiralMainValue() []const u8 {
    var v37: bool = undefined; _ = &v37;
    var v25: US0 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: US0 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH3 = undefined; _ = &v29;
    var v30: *UH4 = undefined; _ = &v30;
    var v31: US0 = undefined; _ = &v31;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH5 = undefined; _ = &v33;
    var v34: *UH6 = undefined; _ = &v34;
    var v35: *UH6 = undefined; _ = &v35;
    var v51: bool = undefined; _ = &v51;
    var v39: Fun0 = undefined; _ = &v39;
    var v40: Fun2 = undefined; _ = &v40;
    var v41: US0 = undefined; _ = &v41;
    var v42: *UH2 = undefined; _ = &v42;
    var v43: US0 = undefined; _ = &v43;
    var v44: *UH2 = undefined; _ = &v44;
    var v45: *UH3 = undefined; _ = &v45;
    var v46: *UH4 = undefined; _ = &v46;
    var v47: US0 = undefined; _ = &v47;
    var v48: *UH2 = undefined; _ = &v48;
    var v49: *UH5 = undefined; _ = &v49;
    var v89: bool = undefined; _ = &v89;
    var v77: US0 = undefined; _ = &v77;
    var v78: *UH2 = undefined; _ = &v78;
    var v79: US0 = undefined; _ = &v79;
    var v80: *UH2 = undefined; _ = &v80;
    var v81: *UH3 = undefined; _ = &v81;
    var v82: *UH4 = undefined; _ = &v82;
    var v83: US0 = undefined; _ = &v83;
    var v84: *UH2 = undefined; _ = &v84;
    var v85: *UH5 = undefined; _ = &v85;
    var v86: *UH6 = undefined; _ = &v86;
    var v87: *UH6 = undefined; _ = &v87;
    var v103: bool = undefined; _ = &v103;
    var v91: Fun0 = undefined; _ = &v91;
    var v92: Fun2 = undefined; _ = &v92;
    var v93: US0 = undefined; _ = &v93;
    var v94: *UH2 = undefined; _ = &v94;
    var v95: US0 = undefined; _ = &v95;
    var v96: *UH2 = undefined; _ = &v96;
    var v97: *UH3 = undefined; _ = &v97;
    var v98: *UH4 = undefined; _ = &v98;
    var v99: US0 = undefined; _ = &v99;
    var v100: *UH2 = undefined; _ = &v100;
    var v101: *UH5 = undefined; _ = &v101;
    var v124: bool = undefined; _ = &v124;
    var v118: US8 = undefined; _ = &v118;
    var v119: *UH13 = undefined; _ = &v119;
    var v120: *UH14 = undefined; _ = &v120;
    var v121: *UH6 = undefined; _ = &v121;
    var v122: *UH6 = undefined; _ = &v122;
    var v132: bool = undefined; _ = &v132;
    var v126: Fun4 = undefined; _ = &v126;
    var v127: Fun6 = undefined; _ = &v127;
    var v128: US8 = undefined; _ = &v128;
    var v129: *UH13 = undefined; _ = &v129;
    var v130: *UH14 = undefined; _ = &v130;
    var v170: bool = undefined; _ = &v170;
    var v158: US8 = undefined; _ = &v158;
    var v159: *UH13 = undefined; _ = &v159;
    var v160: US8 = undefined; _ = &v160;
    var v161: *UH13 = undefined; _ = &v161;
    var v162: *UH16 = undefined; _ = &v162;
    var v163: *UH17 = undefined; _ = &v163;
    var v164: US8 = undefined; _ = &v164;
    var v165: *UH13 = undefined; _ = &v165;
    var v166: *UH18 = undefined; _ = &v166;
    var v167: *UH6 = undefined; _ = &v167;
    var v168: *UH6 = undefined; _ = &v168;
    var v184: bool = undefined; _ = &v184;
    var v172: Fun4 = undefined; _ = &v172;
    var v173: Fun6 = undefined; _ = &v173;
    var v174: US8 = undefined; _ = &v174;
    var v175: *UH13 = undefined; _ = &v175;
    var v176: US8 = undefined; _ = &v176;
    var v177: *UH13 = undefined; _ = &v177;
    var v178: *UH16 = undefined; _ = &v178;
    var v179: *UH17 = undefined; _ = &v179;
    var v180: US8 = undefined; _ = &v180;
    var v181: *UH13 = undefined; _ = &v181;
    var v182: *UH18 = undefined; _ = &v182;
    const v0: US0 = US0_BitZero();
    const v1: *UH0 = UH0_RegexChar(v0);
    const v2: US0 = US0_BitOne();
    const v3: *UH0 = UH0_RegexChar(v2);
    const v4: *UH0 = UH0_RegexAlt(v1, v3);
    const v5: *UH0 = UH0_RegexStar(v4);
    const v6: US0 = US0_BitZero();
    const v7: *UH0 = UH0_RegexChar(v6);
    const v8: *UH0 = UH0_RegexCat(v5, v7);
    const v9: *UH0 = normalize_0(v8);
    const v10: *UH0 = normalize_0(v9);
    const v11: *UH1 = antimirov_residual_support_7(v10);
    const v12: *UH1 = antimirov_insert_unique_9(v10, v11);
    const v13: bool = regex_list_distinct_12(v12);
    const v14: US0 = US0_BitZero();
    const v15: *UH0 = UH0_RegexChar(v14);
    const v16: US0 = US0_BitOne();
    const v17: *UH0 = UH0_RegexChar(v16);
    const v18: *UH0 = UH0_RegexAlt(v15, v17);
    const v19: *UH0 = UH0_RegexStar(v18);
    const v20: US0 = US0_BitZero();
    const v21: *UH0 = UH0_RegexChar(v20);
    const v22: *UH0 = UH0_RegexCat(v19, v21);
    const v23: *UH0 = normalize_0(v22);
    const v24: bool = regex_equal_5(v23, v9);
    if (v24) {
        v25 = US0_BitZero();
        v26 = UH2_PositionTreeChar(v25);
        v27 = US0_BitOne();
        v28 = UH2_PositionTreeChar(v27);
        v29 = UH3_PositionTreeAlt(v26, v28);
        v30 = UH4_PositionTreeStar(v29);
        v31 = US0_BitZero();
        v32 = UH2_PositionTreeChar(v31);
        v33 = UH5_PositionTreeCat(v30, v32);
        v34 = antimirov_position_tree_budget_13(v33);
        v35 = regex_position_count_18(v9);
        v37 = state_budget_same_19(v34, v35);
    } else {
        v37 = false;
    }
    const v38: bool = (v37 and v13);
    if (v38) {
        v39 = closureCreate0();
        v40 = closureCreate2();
        v41 = US0_BitZero();
        v42 = UH2_PositionTreeChar(v41);
        v43 = US0_BitOne();
        v44 = UH2_PositionTreeChar(v43);
        v45 = UH3_PositionTreeAlt(v42, v44);
        v46 = UH4_PositionTreeStar(v45);
        v47 = US0_BitZero();
        v48 = UH2_PositionTreeChar(v47);
        v49 = UH5_PositionTreeCat(v46, v48);
        v51 = antimirov_support_covered_by_typed_slots_20(v39, v40, v9, v49, v12);
    } else {
        v51 = false;
    }
    if (v51) {
    } else {
        if (spiral_true) spiralFail("bit Antimirov support must fit the typed root-plus-position slot universe");
    }
    const v52: US0 = US0_BitZero();
    const v53: *UH0 = UH0_RegexChar(v52);
    const v54: US0 = US0_BitOne();
    const v55: *UH0 = UH0_RegexChar(v54);
    const v56: *UH0 = UH0_RegexAlt(v53, v55);
    const v57: *UH0 = UH0_RegexStar(v56);
    const v58: US0 = US0_BitZero();
    const v59: *UH0 = UH0_RegexChar(v58);
    const v60: *UH0 = UH0_RegexCat(v57, v59);
    const v61: *UH0 = normalize_0(v60);
    const v62: *UH0 = normalize_0(v61);
    const v63: *UH1 = antimirov_residual_support_7(v62);
    const v64: *UH1 = antimirov_insert_unique_9(v62, v63);
    const v65: bool = regex_list_distinct_12(v64);
    const v66: US0 = US0_BitZero();
    const v67: *UH0 = UH0_RegexChar(v66);
    const v68: US0 = US0_BitOne();
    const v69: *UH0 = UH0_RegexChar(v68);
    const v70: *UH0 = UH0_RegexAlt(v67, v69);
    const v71: *UH0 = UH0_RegexStar(v70);
    const v72: US0 = US0_BitOne();
    const v73: *UH0 = UH0_RegexChar(v72);
    const v74: *UH0 = UH0_RegexCat(v71, v73);
    const v75: *UH0 = normalize_0(v74);
    const v76: bool = regex_equal_5(v75, v61);
    if (v76) {
        v77 = US0_BitZero();
        v78 = UH2_PositionTreeChar(v77);
        v79 = US0_BitOne();
        v80 = UH2_PositionTreeChar(v79);
        v81 = UH3_PositionTreeAlt(v78, v80);
        v82 = UH4_PositionTreeStar(v81);
        v83 = US0_BitOne();
        v84 = UH2_PositionTreeChar(v83);
        v85 = UH5_PositionTreeCat(v82, v84);
        v86 = antimirov_position_tree_budget_13(v85);
        v87 = regex_position_count_18(v61);
        v89 = state_budget_same_19(v86, v87);
    } else {
        v89 = false;
    }
    const v90: bool = (v89 and v65);
    if (v90) {
        v91 = closureCreate0();
        v92 = closureCreate2();
        v93 = US0_BitZero();
        v94 = UH2_PositionTreeChar(v93);
        v95 = US0_BitOne();
        v96 = UH2_PositionTreeChar(v95);
        v97 = UH3_PositionTreeAlt(v94, v96);
        v98 = UH4_PositionTreeStar(v97);
        v99 = US0_BitOne();
        v100 = UH2_PositionTreeChar(v99);
        v101 = UH5_PositionTreeCat(v98, v100);
        v103 = antimirov_support_covered_by_typed_slots_20(v91, v92, v61, v101, v64);
    } else {
        v103 = false;
    }
    const v104: bool = v103 == false;
    if (v104) {
    } else {
        if (spiral_true) spiralFail("same-cardinality forged typed position tree must not certify the source regex");
    }
    const v105: US8 = US8_TriA();
    const v106: *UH11 = UH11_RegexChar(v105);
    const v107: *UH11 = UH11_RegexStar(v106);
    const v108: *UH11 = normalize_21(v107);
    const v109: *UH11 = normalize_21(v108);
    const v110: *UH12 = antimirov_residual_support_28(v109);
    const v111: *UH12 = antimirov_insert_unique_30(v109, v110);
    const v112: bool = regex_list_distinct_33(v111);
    const v113: US8 = US8_TriA();
    const v114: *UH11 = UH11_RegexChar(v113);
    const v115: *UH11 = UH11_RegexStar(v114);
    const v116: *UH11 = normalize_21(v115);
    const v117: bool = regex_equal_26(v116, v108);
    if (v117) {
        v118 = US8_TriA();
        v119 = UH13_PositionTreeChar(v118);
        v120 = UH14_PositionTreeStar(v119);
        v121 = antimirov_position_tree_budget_34(v120);
        v122 = regex_position_count_36(v108);
        v124 = state_budget_same_19(v121, v122);
    } else {
        v124 = false;
    }
    const v125: bool = (v124 and v112);
    if (v125) {
        v126 = closureCreate4();
        v127 = closureCreate6();
        v128 = US8_TriA();
        v129 = UH13_PositionTreeChar(v128);
        v130 = UH14_PositionTreeStar(v129);
        v132 = antimirov_support_covered_by_typed_slots_37(v126, v127, v108, v130, v111);
    } else {
        v132 = false;
    }
    if (v132) {
    } else {
        if (spiral_true) spiralFail("ternary star support must fit the typed root-plus-position slot universe");
    }
    const v133: US8 = US8_TriA();
    const v134: *UH11 = UH11_RegexChar(v133);
    const v135: US8 = US8_TriB();
    const v136: *UH11 = UH11_RegexChar(v135);
    const v137: *UH11 = UH11_RegexAlt(v134, v136);
    const v138: *UH11 = UH11_RegexStar(v137);
    const v139: US8 = US8_TriC();
    const v140: *UH11 = UH11_RegexChar(v139);
    const v141: *UH11 = UH11_RegexCat(v138, v140);
    const v142: *UH11 = normalize_21(v141);
    const v143: *UH11 = normalize_21(v142);
    const v144: *UH12 = antimirov_residual_support_28(v143);
    const v145: *UH12 = antimirov_insert_unique_30(v143, v144);
    const v146: bool = regex_list_distinct_33(v145);
    const v147: US8 = US8_TriA();
    const v148: *UH11 = UH11_RegexChar(v147);
    const v149: US8 = US8_TriB();
    const v150: *UH11 = UH11_RegexChar(v149);
    const v151: *UH11 = UH11_RegexAlt(v148, v150);
    const v152: *UH11 = UH11_RegexStar(v151);
    const v153: US8 = US8_TriC();
    const v154: *UH11 = UH11_RegexChar(v153);
    const v155: *UH11 = UH11_RegexCat(v152, v154);
    const v156: *UH11 = normalize_21(v155);
    const v157: bool = regex_equal_26(v156, v142);
    if (v157) {
        v158 = US8_TriA();
        v159 = UH13_PositionTreeChar(v158);
        v160 = US8_TriB();
        v161 = UH13_PositionTreeChar(v160);
        v162 = UH16_PositionTreeAlt(v159, v161);
        v163 = UH17_PositionTreeStar(v162);
        v164 = US8_TriC();
        v165 = UH13_PositionTreeChar(v164);
        v166 = UH18_PositionTreeCat(v163, v165);
        v167 = antimirov_position_tree_budget_38(v166);
        v168 = regex_position_count_36(v142);
        v170 = state_budget_same_19(v167, v168);
    } else {
        v170 = false;
    }
    const v171: bool = (v170 and v146);
    if (v171) {
        v172 = closureCreate4();
        v173 = closureCreate6();
        v174 = US8_TriA();
        v175 = UH13_PositionTreeChar(v174);
        v176 = US8_TriB();
        v177 = UH13_PositionTreeChar(v176);
        v178 = UH16_PositionTreeAlt(v175, v177);
        v179 = UH17_PositionTreeStar(v178);
        v180 = US8_TriC();
        v181 = UH13_PositionTreeChar(v180);
        v182 = UH18_PositionTreeCat(v179, v181);
        v184 = antimirov_support_covered_by_typed_slots_41(v172, v173, v142, v182, v145);
    } else {
        v184 = false;
    }
    if (v184) {
    } else {
        if (spiral_true) spiralFail("ternary cat/alt/star support must fit the typed root-plus-position slot universe");
    }
    const v185: []const u8 = "brzozowski-antimirov-typed-slot-bound-green";
    return v185;
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
