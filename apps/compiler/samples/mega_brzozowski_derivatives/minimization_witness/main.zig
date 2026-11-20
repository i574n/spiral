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
const UH1 = struct { tag: i32, c1_0: *UH1 = undefined };
const UH2 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH2 = undefined };
const UH3 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH3 = undefined };
const US2 = struct { tag: i32, c0_0: *UH3 = undefined, c1_0: *UH3 = undefined };
const Tuple0 = struct { f0: *UH3, f1: *UH3 };
const US3 = struct { tag: i32 };
const US4 = struct { tag: i32, c0_0: *UH0 = undefined };
const UH4 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH0 = undefined, c1_2: *UH4 = undefined };
const UH5 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH5 = undefined };
const UH6 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH0 = undefined, c1_2: *UH5 = undefined, c1_3: *UH6 = undefined };
const US5 = struct { tag: i32, c1_0: *UH5 = undefined };
const UH7 = struct { tag: i32, c1_0: *UH5 = undefined, c1_1: *UH7 = undefined };
const Tuple1 = struct { f0: *UH7, f1: *UH7 };
const US6 = struct { tag: i32 };
const UH8 = struct { tag: i32, c2_0: US6 = undefined, c3_0: *UH8 = undefined, c3_1: *UH8 = undefined, c4_0: *UH8 = undefined, c4_1: *UH8 = undefined, c5_0: *UH8 = undefined };
const UH9 = struct { tag: i32, c1_0: US6 = undefined, c1_1: *UH9 = undefined };
const UH10 = struct { tag: i32, c1_0: *UH8 = undefined, c1_1: *UH10 = undefined };
const US7 = struct { tag: i32, c0_0: *UH10 = undefined, c1_0: *UH10 = undefined };
const Tuple2 = struct { f0: *UH10, f1: *UH10 };
const US8 = struct { tag: i32, c0_0: *UH8 = undefined };
const UH11 = struct { tag: i32, c1_0: *UH8 = undefined, c1_1: *UH8 = undefined, c1_2: *UH11 = undefined };
const UH12 = struct { tag: i32, c1_0: US6 = undefined, c1_1: *UH12 = undefined };
const UH13 = struct { tag: i32, c1_0: *UH8 = undefined, c1_1: *UH8 = undefined, c1_2: *UH12 = undefined, c1_3: *UH13 = undefined };
const US9 = struct { tag: i32, c1_0: *UH12 = undefined };
const UH14 = struct { tag: i32, c1_0: *UH12 = undefined, c1_1: *UH14 = undefined };
const Tuple3 = struct { f0: *UH14, f1: *UH14 };
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
fn UH1_StateBudgetZero() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_StateBudgetSucc(a0: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0 });
}
fn state_budget_add_8(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = state_budget_add_8(v2, v1);
            return UH1_StateBudgetSucc(v3);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_position_count_7(p0: *UH0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v16: *UH0 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_7(v6);
                v9 = regex_position_count_7(v7);
                return state_budget_add_8(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_7(v11);
                v14 = regex_position_count_7(v12);
                return state_budget_add_8(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH1_StateBudgetZero();
                return UH1_StateBudgetSucc(v4);
            },
            0 => {
                return UH1_StateBudgetZero();
            },
            1 => {
                return UH1_StateBudgetZero();
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
fn state_budget_pow2_9(p0: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v1: *UH1 = undefined; _ = &v1;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = state_budget_pow2_9(v3);
            return state_budget_add_8(v4, v4);
        },
        0 => {
            v1 = UH1_StateBudgetZero();
            return UH1_StateBudgetSucc(v1);
        },
        else => unreachable,
    }
}
fn UH2_SymbolListNil() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_SymbolListCons(a0: US0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH3_RegexListNil() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 0 };
    };
    return &shared.value;
}
fn UH3_RegexListCons(a0: *UH0, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US2_DfaClosureComplete(a0: *UH3) US2 {
    return US2{ .tag = 0, .c0_0 = a0 };
}
fn US2_DfaClosureBudgetExceeded(a0: *UH3) US2 {
    return US2{ .tag = 1, .c1_0 = a0 };
}
fn US3_Nullable() US3 {
    return US3{ .tag = 0 };
}
fn US3_NonNullable() US3 {
    return US3{ .tag = 1 };
}
fn nullable_14(p0: *UH0) US3 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH0 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_14(v5);
            v8 = nullable_14(v6);
            switch (v7.tag) {
                0 => {
                    return US3_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US3_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US3_NonNullable();
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
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_14(v16);
            v19 = nullable_14(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US3_Nullable();
                        },
                        else => {
                            return US3_NonNullable();
                        },
                    }
                },
                else => {
                    return US3_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US3_NonNullable();
        },
        0 => {
            return US3_NonNullable();
        },
        1 => {
            return US3_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US3_Nullable();
        },
        else => unreachable,
    }
}
fn derivative_13(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US3 = undefined; _ = &v26;
    var v31: *UH0 = undefined; _ = &v31;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US1 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_13(v19, v1);
            v22 = derivative_13(v20, v1);
            return make_alt_1(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_14(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_13(v24, v1);
                    return make_cat_4(v31, v25);
                },
                0 => {
                    v27 = derivative_13(v24, v1);
                    v28 = make_cat_4(v27, v25);
                    v29 = derivative_13(v25, v1);
                    return make_alt_1(v28, v29);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                1 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US1_SymbolSame();
                        },
                        0 => {
                            v14 = US1_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US1_SymbolLess();
                        },
                        0 => {
                            v14 = US1_SymbolSame();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
            }
            switch (v14.tag) {
                1 => {
                    v15 = true;
                },
                else => {
                    v15 = false;
                },
            }
            if (v15) {
                return UH0_RegexEpsilon();
            } else {
                return UH0_RegexEmpty();
            }
        },
        0 => {
            return UH0_RegexEmpty();
        },
        1 => {
            return UH0_RegexEmpty();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = derivative_13(v35, v1);
            v37 = make_star_6(v35);
            return make_cat_4(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_12(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_0(v0);
    const v3: *UH0 = derivative_13(v2, v1);
    return normalize_0(v3);
}
fn regex_list_contains_15(p0: *UH0, p1: *UH3) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
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
fn dfa_enqueue_symbols_11(p0: *UH0, p1: *UH2, p2: *UH3, p3: *UH3) Tuple0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH3 = p2; _ = &v2;
    var v3: *UH3 = p3; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH3 = undefined; _ = &v10;
    var v11: *UH3 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_12(v0, v4);
                v7 = regex_list_contains_15(v6, v2);
                if (v7) {
                    v1 = v5;
                    continue;
                } else {
                    v10 = UH3_RegexListCons(v6, v2);
                    v11 = UH3_RegexListCons(v6, v3);
                    v1 = v5;
                    v2 = v10;
                    v3 = v11;
                    continue;
                }
            },
            0 => {
                return Tuple0{ .f0 = v2, .f1 = v3 };
            },
            else => unreachable,
        }
    }
}
fn dfa_closure_loop_bounded_10(p0: *UH2, p1: *UH1, p2: *UH3, p3: *UH3) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH3 = p2; _ = &v2;
    var v3: *UH3 = p3; _ = &v3;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH3 = undefined; _ = &v9;
    var v10: *UH3 = undefined; _ = &v10;
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                switch (v1.tag) {
                    1 => {
                        v8 = v1.c1_0;
                        tmp5 = dfa_enqueue_symbols_11(v5, v0, v2, v6);
                        v9 = tmp5.f0;
                        v10 = tmp5.f1;
                        v1 = v8;
                        v2 = v9;
                        v3 = v10;
                        continue;
                    },
                    0 => {
                        return US2_DfaClosureBudgetExceeded(v2);
                    },
                    else => unreachable,
                }
            },
            0 => {
                return US2_DfaClosureComplete(v2);
            },
            else => unreachable,
        }
    }
}
fn US4_DfaRepresentativeFound(a0: *UH0) US4 {
    return US4{ .tag = 0, .c0_0 = a0 };
}
fn US4_DfaRepresentativeMissing() US4 {
    return US4{ .tag = 1 };
}
fn UH4_DfaStatePairNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_DfaStatePairCons(a0: *UH0, a1: *UH0, a2: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 });
}
fn dfa_state_pair_list_contains_19(p0: *UH0, p1: *UH0, p2: *UH4) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v11: bool = undefined; _ = &v11;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = v2.c1_2;
                v6 = regex_equal_5(v0, v3);
                if (v6) {
                    v11 = regex_equal_5(v1, v4);
                } else {
                    v8 = regex_equal_5(v0, v4);
                    if (v8) {
                        v11 = regex_equal_5(v1, v3);
                    } else {
                        v11 = false;
                    }
                }
                if (v11) {
                    return true;
                } else {
                    v2 = v5;
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
fn dfa_state_pair_enqueue_symbols_20(p0: *UH0, p1: *UH0, p2: *UH2, p3: *UH4) *UH4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v3: *UH4 = p3; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = canonical_derivative_12(v0, v4);
                v7 = canonical_derivative_12(v1, v4);
                v8 = UH4_DfaStatePairCons(v6, v7, v3);
                v2 = v5;
                v3 = v8;
                continue;
            },
            0 => {
                return v3;
            },
            else => unreachable,
        }
    }
}
fn dfa_bisimulation_work_18(p0: *UH2, p1: *UH4, p2: *UH4) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v8: bool = undefined; _ = &v8;
    var v10: US3 = undefined; _ = &v10;
    var v11: US3 = undefined; _ = &v11;
    var v15: bool = undefined; _ = &v15;
    var v16: *UH4 = undefined; _ = &v16;
    var v17: *UH4 = undefined; _ = &v17;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = v1.c1_2;
                v6 = regex_equal_5(v3, v4);
                if (v6) {
                    v1 = v5;
                    continue;
                } else {
                    v8 = dfa_state_pair_list_contains_19(v3, v4, v2);
                    if (v8) {
                        v1 = v5;
                        continue;
                    } else {
                        v10 = nullable_14(v3);
                        v11 = nullable_14(v4);
                        switch (v10.tag) {
                            1 => {
                                switch (v11.tag) {
                                    1 => {
                                        v15 = true;
                                    },
                                    else => {
                                        v15 = false;
                                    },
                                }
                            },
                            0 => {
                                switch (v11.tag) {
                                    0 => {
                                        v15 = true;
                                    },
                                    else => {
                                        v15 = false;
                                    },
                                }
                            },
                            else => unreachable,
                        }
                        if (v15) {
                            v16 = dfa_state_pair_enqueue_symbols_20(v3, v4, v0, v5);
                            v17 = UH4_DfaStatePairCons(v3, v4, v2);
                            v1 = v16;
                            v2 = v17;
                            continue;
                        } else {
                            return false;
                        }
                    }
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn dfa_find_bisimilar_representative_17(p0: *UH0, p1: *UH3, p2: *UH2) US4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH4 = undefined; _ = &v9;
    var v10: *UH4 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = normalize_0(v0);
                v7 = normalize_0(v4);
                v8 = UH4_DfaStatePairNil();
                v9 = UH4_DfaStatePairCons(v6, v7, v8);
                v10 = UH4_DfaStatePairNil();
                v11 = dfa_bisimulation_work_18(v2, v9, v10);
                if (v11) {
                    return US4_DfaRepresentativeFound(v4);
                } else {
                    v1 = v5;
                    continue;
                }
            },
            0 => {
                return US4_DfaRepresentativeMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_minimize_states_loop_16(p0: *UH3, p1: *UH2, p2: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH3 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: US4 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v8: *UH3 = undefined; _ = &v8;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_17(v3, v2, v1);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v0 = v4;
                        continue;
                    },
                    1 => {
                        v8 = UH3_RegexListCons(v3, v2);
                        v0 = v4;
                        v2 = v8;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn UH5_InputEmpty() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_InputCons(a0: US0, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH6_DfaConstructivePairTraceNil() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_DfaConstructivePairTraceCons(a0: *UH0, a1: *UH0, a2: *UH5, a3: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2, .c1_3 = a3 });
}
fn US5_DfaConstructiveEquivalent() US5 {
    return US5{ .tag = 0 };
}
fn US5_DfaConstructiveDistinguished(a0: *UH5) US5 {
    return US5{ .tag = 1, .c1_0 = a0 };
}
fn dfa_constructive_input_snoc_25(p0: *UH5, p1: US0) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v2: *UH5 = undefined; _ = &v2;
    switch (v0.tag) {
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            v6 = dfa_constructive_input_snoc_25(v5, v1);
            return UH5_InputCons(v4, v6);
        },
        0 => {
            v2 = UH5_InputEmpty();
            return UH5_InputCons(v1, v2);
        },
        else => unreachable,
    }
}
fn dfa_constructive_pair_trace_enqueue_symbols_24(p0: *UH0, p1: *UH0, p2: *UH5, p3: *UH2, p4: *UH6) *UH6 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH2 = p3; _ = &v3;
    var v4: *UH6 = p4; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH6 = undefined; _ = &v10;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                v7 = canonical_derivative_12(v0, v5);
                v8 = canonical_derivative_12(v1, v5);
                v9 = dfa_constructive_input_snoc_25(v2, v5);
                v10 = UH6_DfaConstructivePairTraceCons(v7, v8, v9, v4);
                v3 = v6;
                v4 = v10;
                continue;
            },
            0 => {
                return v4;
            },
            else => unreachable,
        }
    }
}
fn dfa_constructive_distinguishing_work_23(p0: *UH2, p1: *UH6, p2: *UH4) US5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH6 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v10: bool = undefined; _ = &v10;
    var v12: US3 = undefined; _ = &v12;
    var v13: US3 = undefined; _ = &v13;
    var v17: bool = undefined; _ = &v17;
    var v18: *UH6 = undefined; _ = &v18;
    var v19: *UH4 = undefined; _ = &v19;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = v1.c1_2;
                v7 = v1.c1_3;
                v8 = regex_equal_5(v4, v5);
                if (v8) {
                    v1 = v7;
                    continue;
                } else {
                    v10 = dfa_state_pair_list_contains_19(v4, v5, v2);
                    if (v10) {
                        v1 = v7;
                        continue;
                    } else {
                        v12 = nullable_14(v4);
                        v13 = nullable_14(v5);
                        switch (v12.tag) {
                            1 => {
                                switch (v13.tag) {
                                    1 => {
                                        v17 = true;
                                    },
                                    else => {
                                        v17 = false;
                                    },
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    0 => {
                                        v17 = true;
                                    },
                                    else => {
                                        v17 = false;
                                    },
                                }
                            },
                            else => unreachable,
                        }
                        if (v17) {
                            v18 = dfa_constructive_pair_trace_enqueue_symbols_24(v4, v5, v6, v0, v7);
                            v19 = UH4_DfaStatePairCons(v4, v5, v2);
                            v1 = v18;
                            v2 = v19;
                            continue;
                        } else {
                            return US5_DfaConstructiveDistinguished(v6);
                        }
                    }
                }
            },
            0 => {
                return US5_DfaConstructiveEquivalent();
            },
            else => unreachable,
        }
    }
}
fn UH7_InputListNil() *UH7 {
    const shared = struct {
        var value: UH7 = UH7{ .tag = 0 };
    };
    return &shared.value;
}
fn UH7_InputListCons(a0: *UH5, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_list_append_27(p0: *UH7, p1: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_27(v3, v1);
            return UH7_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_28(p0: *UH0, p1: *UH7) *UH7 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_26(v0, v3);
            v6 = consume_right_28(v0, v4);
            return input_list_append_27(v5, v6);
        },
        0 => {
            return UH7_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_32(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v16: US1 = undefined; _ = &v16;
    var v17: bool = undefined; _ = &v17;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v6 = v1.c1_1;
                        switch (v3.tag) {
                            1 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US1_SymbolSame();
                                    },
                                    0 => {
                                        v16 = US1_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US1_SymbolLess();
                                    },
                                    0 => {
                                        v16 = US1_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v16.tag) {
                            1 => {
                                v17 = true;
                            },
                            else => {
                                v17 = false;
                            },
                        }
                        if (v17) {
                            v0 = v4;
                            v1 = v6;
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
fn input_list_contains_31(p0: *UH5, p1: *UH7) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_32(v0, v2);
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
fn input_list_enqueue_new_30(p0: *UH7, p1: *UH7, p2: *UH7) Tuple1 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH7 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_31(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH7_InputListCons(v3, v1);
                    v9 = UH7_InputListCons(v3, v2);
                    v0 = v4;
                    v1 = v8;
                    v2 = v9;
                    continue;
                }
            },
            0 => {
                return Tuple1{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_29(p0: *UH0, p1: *UH7, p2: *UH7) *UH7 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v7: *UH7 = undefined; _ = &v7;
    var tmp5: Tuple1 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_26(v0, v3);
                tmp5 = input_list_enqueue_new_30(v5, v2, v4);
                v6 = tmp5.f0;
                v7 = tmp5.f1;
                v1 = v7;
                v2 = v6;
                continue;
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn language_remainders_26(p0: *UH0, p1: *UH5) *UH7 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH7 = undefined; _ = &v28;
    var v29: *UH7 = undefined; _ = &v29;
    var v31: *UH0 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v33: *UH7 = undefined; _ = &v33;
    var v5: US0 = undefined; _ = &v5;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v18: US1 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH7 = undefined; _ = &v20;
    var v3: *UH7 = undefined; _ = &v3;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH7 = undefined; _ = &v36;
    var v37: *UH7 = undefined; _ = &v37;
    var v38: *UH7 = undefined; _ = &v38;
    var v39: *UH7 = undefined; _ = &v39;
    switch (v0.tag) {
        3 => {
            v26 = v0.c3_0;
            v27 = v0.c3_1;
            v28 = language_remainders_26(v26, v1);
            v29 = language_remainders_26(v27, v1);
            return input_list_append_27(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = language_remainders_26(v31, v1);
            return consume_right_28(v32, v33);
        },
        2 => {
            v5 = v0.c2_0;
            switch (v1.tag) {
                1 => {
                    v7 = v1.c1_0;
                    v8 = v1.c1_1;
                    switch (v5.tag) {
                        1 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US1_SymbolSame();
                                },
                                0 => {
                                    v18 = US1_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US1_SymbolLess();
                                },
                                0 => {
                                    v18 = US1_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v18.tag) {
                        1 => {
                            v19 = true;
                        },
                        else => {
                            v19 = false;
                        },
                    }
                    if (v19) {
                        v20 = UH7_InputListNil();
                        return UH7_InputListCons(v8, v20);
                    } else {
                        return UH7_InputListNil();
                    }
                },
                0 => {
                    return UH7_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH7_InputListNil();
        },
        1 => {
            v3 = UH7_InputListNil();
            return UH7_InputListCons(v1, v3);
        },
        5 => {
            v35 = v0.c5_0;
            v36 = UH7_InputListNil();
            v37 = UH7_InputListCons(v1, v36);
            v38 = UH7_InputListNil();
            v39 = UH7_InputListCons(v1, v38);
            return closure_29(v35, v37, v39);
        },
        else => unreachable,
    }
}
fn dfa_state_distinct_with_witness_against_22(p0: *UH0, p1: *UH3, p2: *UH2) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v9: *UH6 = undefined; _ = &v9;
    var v10: *UH4 = undefined; _ = &v10;
    var v11: US5 = undefined; _ = &v11;
    var v12: *UH5 = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH5 = undefined; _ = &v14;
    var v15: *UH7 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: *UH5 = undefined; _ = &v18;
    var v19: *UH7 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v22: bool = undefined; _ = &v22;
    var v21: bool = undefined; _ = &v21;
    var v23: bool = undefined; _ = &v23;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = normalize_0(v0);
                v6 = normalize_0(v3);
                v7 = UH5_InputEmpty();
                v8 = UH6_DfaConstructivePairTraceNil();
                v9 = UH6_DfaConstructivePairTraceCons(v5, v6, v7, v8);
                v10 = UH4_DfaStatePairNil();
                v11 = dfa_constructive_distinguishing_work_23(v2, v9, v10);
                switch (v11.tag) {
                    1 => {
                        v12 = v11.c1_0;
                        v13 = normalize_0(v0);
                        v14 = UH5_InputEmpty();
                        v15 = language_remainders_26(v13, v12);
                        v16 = input_list_contains_31(v14, v15);
                        v17 = normalize_0(v3);
                        v18 = UH5_InputEmpty();
                        v19 = language_remainders_26(v17, v12);
                        v20 = input_list_contains_31(v18, v19);
                        if (v16) {
                            v22 = v20;
                        } else {
                            v21 = false == v20;
                            v22 = v21;
                        }
                        v23 = v22 == false;
                        if (v23) {
                            v1 = v4;
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
fn dfa_minimal_with_distinguishing_witnesses_21(p0: *UH3, p1: *UH2) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_distinct_with_witness_against_22(v2, v3, v1);
                if (v4) {
                    v0 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn US6_TriA() US6 {
    return US6{ .tag = 0 };
}
fn US6_TriB() US6 {
    return US6{ .tag = 1 };
}
fn US6_TriC() US6 {
    return US6{ .tag = 2 };
}
fn UH8_RegexEmpty() *UH8 {
    const shared = struct {
        var value: UH8 = UH8{ .tag = 0 };
    };
    return &shared.value;
}
fn UH8_RegexEpsilon() *UH8 {
    const shared = struct {
        var value: UH8 = UH8{ .tag = 1 };
    };
    return &shared.value;
}
fn UH8_RegexChar(a0: US6) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 2, .c2_0 = a0 });
}
fn UH8_RegexAlt(a0: *UH8, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH8_RegexCat(a0: *UH8, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH8_RegexStar(a0: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 5, .c5_0 = a0 });
}
fn regex_compare_36(p0: *UH8, p1: *UH8) US1 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v59: *UH8 = undefined; _ = &v59;
    var v60: *UH8 = undefined; _ = &v60;
    var v61: *UH8 = undefined; _ = &v61;
    var v62: *UH8 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v40: *UH8 = undefined; _ = &v40;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: US1 = undefined; _ = &v42;
    var v38: US6 = undefined; _ = &v38;
    var v10: US6 = undefined; _ = &v10;
    var v13: US6 = undefined; _ = &v13;
    var v50: *UH8 = undefined; _ = &v50;
    var v51: *UH8 = undefined; _ = &v51;
    var v52: *UH8 = undefined; _ = &v52;
    var v54: *UH8 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_36(v59, v61);
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
                        v42 = regex_compare_36(v34, v40);
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
fn alt_insert_sorted_35(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH8 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_36(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_35(v0, v3);
                    return UH8_RegexAlt(v2, v6);
                },
                0 => {
                    return UH8_RegexAlt(v0, v1);
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
            v11 = regex_compare_36(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH8_RegexAlt(v1, v0);
                },
                0 => {
                    return UH8_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_34(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_35(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_35(v0, v1);
            },
        }
    }
}
fn regex_equal_38(p0: *UH8, p1: *UH8) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v24: *UH8 = undefined; _ = &v24;
    var v25: *UH8 = undefined; _ = &v25;
    var v26: *UH8 = undefined; _ = &v26;
    var v27: *UH8 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH8 = undefined; _ = &v32;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US6 = undefined; _ = &v4;
    var v5: US6 = undefined; _ = &v5;
    var v21: US1 = undefined; _ = &v21;
    var v40: *UH8 = undefined; _ = &v40;
    var v41: *UH8 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_38(v24, v26);
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
                        v36 = regex_equal_38(v32, v34);
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
fn make_cat_37(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: *UH8 = undefined; _ = &v14;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH8_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH8_RegexEmpty();
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
                                            v14 = make_cat_37(v13, v1);
                                            return UH8_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_38(v4, v5);
                                                    if (v6) {
                                                        return UH8_RegexStar(v4);
                                                    } else {
                                                        return UH8_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH8_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH8_RegexCat(v0, v1);
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
fn make_star_39(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v3: *UH8 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH8_RegexEpsilon();
        },
        1 => {
            return UH8_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH8_RegexStar(v3);
        },
        else => {
            return UH8_RegexStar(v0);
        },
    }
}
fn normalize_33(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v10: *UH8 = undefined; _ = &v10;
    var v11: *UH8 = undefined; _ = &v11;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v3: US6 = undefined; _ = &v3;
    var v15: *UH8 = undefined; _ = &v15;
    var v16: *UH8 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_33(v5);
            v8 = normalize_33(v6);
            return make_alt_34(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_33(v10);
            v13 = normalize_33(v11);
            return make_cat_37(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH8_RegexChar(v3);
        },
        0 => {
            return UH8_RegexEmpty();
        },
        1 => {
            return UH8_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_33(v15);
            return make_star_39(v16);
        },
        else => unreachable,
    }
}
fn regex_position_count_40(p0: *UH8) *UH1 {
    var v0: *UH8 = p0; _ = &v0;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v11: *UH8 = undefined; _ = &v11;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v3: US6 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v16: *UH8 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_40(v6);
                v9 = regex_position_count_40(v7);
                return state_budget_add_8(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_40(v11);
                v14 = regex_position_count_40(v12);
                return state_budget_add_8(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH1_StateBudgetZero();
                return UH1_StateBudgetSucc(v4);
            },
            0 => {
                return UH1_StateBudgetZero();
            },
            1 => {
                return UH1_StateBudgetZero();
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
fn UH9_SymbolListNil() *UH9 {
    const shared = struct {
        var value: UH9 = UH9{ .tag = 0 };
    };
    return &shared.value;
}
fn UH9_SymbolListCons(a0: US6, a1: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH10_RegexListNil() *UH10 {
    const shared = struct {
        var value: UH10 = UH10{ .tag = 0 };
    };
    return &shared.value;
}
fn UH10_RegexListCons(a0: *UH8, a1: *UH10) *UH10 {
    return spiralCreate(UH10, UH10{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US7_DfaClosureComplete(a0: *UH10) US7 {
    return US7{ .tag = 0, .c0_0 = a0 };
}
fn US7_DfaClosureBudgetExceeded(a0: *UH10) US7 {
    return US7{ .tag = 1, .c1_0 = a0 };
}
fn nullable_45(p0: *UH8) US3 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH8 = undefined; _ = &v16;
    var v17: *UH8 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US6 = undefined; _ = &v3;
    var v25: *UH8 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_45(v5);
            v8 = nullable_45(v6);
            switch (v7.tag) {
                0 => {
                    return US3_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US3_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US3_NonNullable();
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
        4 => {
            v16 = v0.c4_0;
            v17 = v0.c4_1;
            v18 = nullable_45(v16);
            v19 = nullable_45(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US3_Nullable();
                        },
                        else => {
                            return US3_NonNullable();
                        },
                    }
                },
                else => {
                    return US3_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US3_NonNullable();
        },
        0 => {
            return US3_NonNullable();
        },
        1 => {
            return US3_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US3_Nullable();
        },
        else => unreachable,
    }
}
fn derivative_44(p0: *UH8, p1: US6) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US6 = p1; _ = &v1;
    var v25: *UH8 = undefined; _ = &v25;
    var v26: *UH8 = undefined; _ = &v26;
    var v27: *UH8 = undefined; _ = &v27;
    var v28: *UH8 = undefined; _ = &v28;
    var v30: *UH8 = undefined; _ = &v30;
    var v31: *UH8 = undefined; _ = &v31;
    var v32: US3 = undefined; _ = &v32;
    var v37: *UH8 = undefined; _ = &v37;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v4: US6 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: *UH8 = undefined; _ = &v42;
    var v43: *UH8 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_44(v25, v1);
            v28 = derivative_44(v26, v1);
            return make_alt_34(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_45(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_44(v30, v1);
                    return make_cat_37(v37, v31);
                },
                0 => {
                    v33 = derivative_44(v30, v1);
                    v34 = make_cat_37(v33, v31);
                    v35 = derivative_44(v31, v1);
                    return make_alt_34(v34, v35);
                },
                else => unreachable,
            }
        },
        2 => {
            v4 = v0.c2_0;
            switch (v4.tag) {
                0 => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US1_SymbolSame();
                        },
                        else => {
                            v20 = US1_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US1_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US1_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US1_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US1_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US1_SymbolSame();
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
            switch (v20.tag) {
                1 => {
                    v21 = true;
                },
                else => {
                    v21 = false;
                },
            }
            if (v21) {
                return UH8_RegexEpsilon();
            } else {
                return UH8_RegexEmpty();
            }
        },
        0 => {
            return UH8_RegexEmpty();
        },
        1 => {
            return UH8_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_44(v41, v1);
            v43 = make_star_39(v41);
            return make_cat_37(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_43(p0: *UH8, p1: US6) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US6 = p1; _ = &v1;
    const v2: *UH8 = normalize_33(v0);
    const v3: *UH8 = derivative_44(v2, v1);
    return normalize_33(v3);
}
fn regex_list_contains_46(p0: *UH8, p1: *UH10) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_38(v0, v2);
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
fn dfa_enqueue_symbols_42(p0: *UH8, p1: *UH9, p2: *UH10, p3: *UH10) Tuple2 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH10 = p3; _ = &v3;
    var v4: US6 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH10 = undefined; _ = &v10;
    var v11: *UH10 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_43(v0, v4);
                v7 = regex_list_contains_46(v6, v2);
                if (v7) {
                    v1 = v5;
                    continue;
                } else {
                    v10 = UH10_RegexListCons(v6, v2);
                    v11 = UH10_RegexListCons(v6, v3);
                    v1 = v5;
                    v2 = v10;
                    v3 = v11;
                    continue;
                }
            },
            0 => {
                return Tuple2{ .f0 = v2, .f1 = v3 };
            },
            else => unreachable,
        }
    }
}
fn dfa_closure_loop_bounded_41(p0: *UH9, p1: *UH1, p2: *UH10, p3: *UH10) US7 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH10 = p3; _ = &v3;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH10 = undefined; _ = &v6;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH10 = undefined; _ = &v9;
    var v10: *UH10 = undefined; _ = &v10;
    var tmp5: Tuple2 = undefined; _ = &tmp5;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                switch (v1.tag) {
                    1 => {
                        v8 = v1.c1_0;
                        tmp5 = dfa_enqueue_symbols_42(v5, v0, v2, v6);
                        v9 = tmp5.f0;
                        v10 = tmp5.f1;
                        v1 = v8;
                        v2 = v9;
                        v3 = v10;
                        continue;
                    },
                    0 => {
                        return US7_DfaClosureBudgetExceeded(v2);
                    },
                    else => unreachable,
                }
            },
            0 => {
                return US7_DfaClosureComplete(v2);
            },
            else => unreachable,
        }
    }
}
fn US8_DfaRepresentativeFound(a0: *UH8) US8 {
    return US8{ .tag = 0, .c0_0 = a0 };
}
fn US8_DfaRepresentativeMissing() US8 {
    return US8{ .tag = 1 };
}
fn UH11_DfaStatePairNil() *UH11 {
    const shared = struct {
        var value: UH11 = UH11{ .tag = 0 };
    };
    return &shared.value;
}
fn UH11_DfaStatePairCons(a0: *UH8, a1: *UH8, a2: *UH11) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 });
}
fn dfa_state_pair_list_contains_50(p0: *UH8, p1: *UH8, p2: *UH11) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v11: bool = undefined; _ = &v11;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = v2.c1_2;
                v6 = regex_equal_38(v0, v3);
                if (v6) {
                    v11 = regex_equal_38(v1, v4);
                } else {
                    v8 = regex_equal_38(v0, v4);
                    if (v8) {
                        v11 = regex_equal_38(v1, v3);
                    } else {
                        v11 = false;
                    }
                }
                if (v11) {
                    return true;
                } else {
                    v2 = v5;
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
fn dfa_state_pair_enqueue_symbols_51(p0: *UH8, p1: *UH8, p2: *UH9, p3: *UH11) *UH11 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH11 = p3; _ = &v3;
    var v4: US6 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = canonical_derivative_43(v0, v4);
                v7 = canonical_derivative_43(v1, v4);
                v8 = UH11_DfaStatePairCons(v6, v7, v3);
                v2 = v5;
                v3 = v8;
                continue;
            },
            0 => {
                return v3;
            },
            else => unreachable,
        }
    }
}
fn dfa_bisimulation_work_49(p0: *UH9, p1: *UH11, p2: *UH11) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v8: bool = undefined; _ = &v8;
    var v10: US3 = undefined; _ = &v10;
    var v11: US3 = undefined; _ = &v11;
    var v15: bool = undefined; _ = &v15;
    var v16: *UH11 = undefined; _ = &v16;
    var v17: *UH11 = undefined; _ = &v17;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = v1.c1_2;
                v6 = regex_equal_38(v3, v4);
                if (v6) {
                    v1 = v5;
                    continue;
                } else {
                    v8 = dfa_state_pair_list_contains_50(v3, v4, v2);
                    if (v8) {
                        v1 = v5;
                        continue;
                    } else {
                        v10 = nullable_45(v3);
                        v11 = nullable_45(v4);
                        switch (v10.tag) {
                            1 => {
                                switch (v11.tag) {
                                    1 => {
                                        v15 = true;
                                    },
                                    else => {
                                        v15 = false;
                                    },
                                }
                            },
                            0 => {
                                switch (v11.tag) {
                                    0 => {
                                        v15 = true;
                                    },
                                    else => {
                                        v15 = false;
                                    },
                                }
                            },
                            else => unreachable,
                        }
                        if (v15) {
                            v16 = dfa_state_pair_enqueue_symbols_51(v3, v4, v0, v5);
                            v17 = UH11_DfaStatePairCons(v3, v4, v2);
                            v1 = v16;
                            v2 = v17;
                            continue;
                        } else {
                            return false;
                        }
                    }
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn dfa_find_bisimilar_representative_48(p0: *UH8, p1: *UH10, p2: *UH9) US8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH10 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    var v9: *UH11 = undefined; _ = &v9;
    var v10: *UH11 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = normalize_33(v0);
                v7 = normalize_33(v4);
                v8 = UH11_DfaStatePairNil();
                v9 = UH11_DfaStatePairCons(v6, v7, v8);
                v10 = UH11_DfaStatePairNil();
                v11 = dfa_bisimulation_work_49(v2, v9, v10);
                if (v11) {
                    return US8_DfaRepresentativeFound(v4);
                } else {
                    v1 = v5;
                    continue;
                }
            },
            0 => {
                return US8_DfaRepresentativeMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_minimize_states_loop_47(p0: *UH10, p1: *UH9, p2: *UH10) *UH10 {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: US8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v8: *UH10 = undefined; _ = &v8;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_48(v3, v2, v1);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v0 = v4;
                        continue;
                    },
                    1 => {
                        v8 = UH10_RegexListCons(v3, v2);
                        v0 = v4;
                        v2 = v8;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn UH12_InputEmpty() *UH12 {
    const shared = struct {
        var value: UH12 = UH12{ .tag = 0 };
    };
    return &shared.value;
}
fn UH12_InputCons(a0: US6, a1: *UH12) *UH12 {
    return spiralCreate(UH12, UH12{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH13_DfaConstructivePairTraceNil() *UH13 {
    const shared = struct {
        var value: UH13 = UH13{ .tag = 0 };
    };
    return &shared.value;
}
fn UH13_DfaConstructivePairTraceCons(a0: *UH8, a1: *UH8, a2: *UH12, a3: *UH13) *UH13 {
    return spiralCreate(UH13, UH13{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2, .c1_3 = a3 });
}
fn US9_DfaConstructiveEquivalent() US9 {
    return US9{ .tag = 0 };
}
fn US9_DfaConstructiveDistinguished(a0: *UH12) US9 {
    return US9{ .tag = 1, .c1_0 = a0 };
}
fn dfa_constructive_input_snoc_56(p0: *UH12, p1: US6) *UH12 {
    var v0: *UH12 = p0; _ = &v0;
    var v1: US6 = p1; _ = &v1;
    var v4: US6 = undefined; _ = &v4;
    var v5: *UH12 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    var v2: *UH12 = undefined; _ = &v2;
    switch (v0.tag) {
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            v6 = dfa_constructive_input_snoc_56(v5, v1);
            return UH12_InputCons(v4, v6);
        },
        0 => {
            v2 = UH12_InputEmpty();
            return UH12_InputCons(v1, v2);
        },
        else => unreachable,
    }
}
fn dfa_constructive_pair_trace_enqueue_symbols_55(p0: *UH8, p1: *UH8, p2: *UH12, p3: *UH9, p4: *UH13) *UH13 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH12 = p2; _ = &v2;
    var v3: *UH9 = p3; _ = &v3;
    var v4: *UH13 = p4; _ = &v4;
    var v5: US6 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH12 = undefined; _ = &v9;
    var v10: *UH13 = undefined; _ = &v10;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                v7 = canonical_derivative_43(v0, v5);
                v8 = canonical_derivative_43(v1, v5);
                v9 = dfa_constructive_input_snoc_56(v2, v5);
                v10 = UH13_DfaConstructivePairTraceCons(v7, v8, v9, v4);
                v3 = v6;
                v4 = v10;
                continue;
            },
            0 => {
                return v4;
            },
            else => unreachable,
        }
    }
}
fn dfa_constructive_distinguishing_work_54(p0: *UH9, p1: *UH13, p2: *UH11) US9 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH13 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    var v7: *UH13 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v10: bool = undefined; _ = &v10;
    var v12: US3 = undefined; _ = &v12;
    var v13: US3 = undefined; _ = &v13;
    var v17: bool = undefined; _ = &v17;
    var v18: *UH13 = undefined; _ = &v18;
    var v19: *UH11 = undefined; _ = &v19;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = v1.c1_2;
                v7 = v1.c1_3;
                v8 = regex_equal_38(v4, v5);
                if (v8) {
                    v1 = v7;
                    continue;
                } else {
                    v10 = dfa_state_pair_list_contains_50(v4, v5, v2);
                    if (v10) {
                        v1 = v7;
                        continue;
                    } else {
                        v12 = nullable_45(v4);
                        v13 = nullable_45(v5);
                        switch (v12.tag) {
                            1 => {
                                switch (v13.tag) {
                                    1 => {
                                        v17 = true;
                                    },
                                    else => {
                                        v17 = false;
                                    },
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    0 => {
                                        v17 = true;
                                    },
                                    else => {
                                        v17 = false;
                                    },
                                }
                            },
                            else => unreachable,
                        }
                        if (v17) {
                            v18 = dfa_constructive_pair_trace_enqueue_symbols_55(v4, v5, v6, v0, v7);
                            v19 = UH11_DfaStatePairCons(v4, v5, v2);
                            v1 = v18;
                            v2 = v19;
                            continue;
                        } else {
                            return US9_DfaConstructiveDistinguished(v6);
                        }
                    }
                }
            },
            0 => {
                return US9_DfaConstructiveEquivalent();
            },
            else => unreachable,
        }
    }
}
fn UH14_InputListNil() *UH14 {
    const shared = struct {
        var value: UH14 = UH14{ .tag = 0 };
    };
    return &shared.value;
}
fn UH14_InputListCons(a0: *UH12, a1: *UH14) *UH14 {
    return spiralCreate(UH14, UH14{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_list_append_58(p0: *UH14, p1: *UH14) *UH14 {
    var v0: *UH14 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v2: *UH12 = undefined; _ = &v2;
    var v3: *UH14 = undefined; _ = &v3;
    var v4: *UH14 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_58(v3, v1);
            return UH14_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_59(p0: *UH8, p1: *UH14) *UH14 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v3: *UH12 = undefined; _ = &v3;
    var v4: *UH14 = undefined; _ = &v4;
    var v5: *UH14 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_57(v0, v3);
            v6 = consume_right_59(v0, v4);
            return input_list_append_58(v5, v6);
        },
        0 => {
            return UH14_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_63(p0: *UH12, p1: *UH12) bool {
    var v0: *UH12 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    var v3: US6 = undefined; _ = &v3;
    var v4: *UH12 = undefined; _ = &v4;
    var v5: US6 = undefined; _ = &v5;
    var v6: *UH12 = undefined; _ = &v6;
    var v22: US1 = undefined; _ = &v22;
    var v23: bool = undefined; _ = &v23;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v6 = v1.c1_1;
                        switch (v3.tag) {
                            0 => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US1_SymbolSame();
                                    },
                                    else => {
                                        v22 = US1_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US1_SymbolGreater();
                                    },
                                    else => {
                                        switch (v3.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US1_SymbolSame();
                                                    },
                                                    2 => {
                                                        v22 = US1_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US1_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v22 = US1_SymbolSame();
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
                        switch (v22.tag) {
                            1 => {
                                v23 = true;
                            },
                            else => {
                                v23 = false;
                            },
                        }
                        if (v23) {
                            v0 = v4;
                            v1 = v6;
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
fn input_list_contains_62(p0: *UH12, p1: *UH14) bool {
    var v0: *UH12 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v2: *UH12 = undefined; _ = &v2;
    var v3: *UH14 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_63(v0, v2);
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
fn input_list_enqueue_new_61(p0: *UH14, p1: *UH14, p2: *UH14) Tuple3 {
    var v0: *UH14 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v3: *UH12 = undefined; _ = &v3;
    var v4: *UH14 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH14 = undefined; _ = &v8;
    var v9: *UH14 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_62(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH14_InputListCons(v3, v1);
                    v9 = UH14_InputListCons(v3, v2);
                    v0 = v4;
                    v1 = v8;
                    v2 = v9;
                    continue;
                }
            },
            0 => {
                return Tuple3{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_60(p0: *UH8, p1: *UH14, p2: *UH14) *UH14 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v3: *UH12 = undefined; _ = &v3;
    var v4: *UH14 = undefined; _ = &v4;
    var v5: *UH14 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    var v7: *UH14 = undefined; _ = &v7;
    var tmp5: Tuple3 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_57(v0, v3);
                tmp5 = input_list_enqueue_new_61(v5, v2, v4);
                v6 = tmp5.f0;
                v7 = tmp5.f1;
                v1 = v7;
                v2 = v6;
                continue;
            },
            0 => {
                return v2;
            },
            else => unreachable,
        }
    }
}
fn language_remainders_57(p0: *UH8, p1: *UH12) *UH14 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    var v32: *UH8 = undefined; _ = &v32;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH14 = undefined; _ = &v34;
    var v35: *UH14 = undefined; _ = &v35;
    var v37: *UH8 = undefined; _ = &v37;
    var v38: *UH8 = undefined; _ = &v38;
    var v39: *UH14 = undefined; _ = &v39;
    var v5: US6 = undefined; _ = &v5;
    var v7: US6 = undefined; _ = &v7;
    var v8: *UH12 = undefined; _ = &v8;
    var v24: US1 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH14 = undefined; _ = &v26;
    var v3: *UH14 = undefined; _ = &v3;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: *UH14 = undefined; _ = &v42;
    var v43: *UH14 = undefined; _ = &v43;
    var v44: *UH14 = undefined; _ = &v44;
    var v45: *UH14 = undefined; _ = &v45;
    switch (v0.tag) {
        3 => {
            v32 = v0.c3_0;
            v33 = v0.c3_1;
            v34 = language_remainders_57(v32, v1);
            v35 = language_remainders_57(v33, v1);
            return input_list_append_58(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = language_remainders_57(v37, v1);
            return consume_right_59(v38, v39);
        },
        2 => {
            v5 = v0.c2_0;
            switch (v1.tag) {
                1 => {
                    v7 = v1.c1_0;
                    v8 = v1.c1_1;
                    switch (v5.tag) {
                        0 => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US1_SymbolSame();
                                },
                                else => {
                                    v24 = US1_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US1_SymbolGreater();
                                },
                                else => {
                                    switch (v5.tag) {
                                        1 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US1_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US1_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US1_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US1_SymbolSame();
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
                    switch (v24.tag) {
                        1 => {
                            v25 = true;
                        },
                        else => {
                            v25 = false;
                        },
                    }
                    if (v25) {
                        v26 = UH14_InputListNil();
                        return UH14_InputListCons(v8, v26);
                    } else {
                        return UH14_InputListNil();
                    }
                },
                0 => {
                    return UH14_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH14_InputListNil();
        },
        1 => {
            v3 = UH14_InputListNil();
            return UH14_InputListCons(v1, v3);
        },
        5 => {
            v41 = v0.c5_0;
            v42 = UH14_InputListNil();
            v43 = UH14_InputListCons(v1, v42);
            v44 = UH14_InputListNil();
            v45 = UH14_InputListCons(v1, v44);
            return closure_60(v41, v43, v45);
        },
        else => unreachable,
    }
}
fn dfa_state_distinct_with_witness_against_53(p0: *UH8, p1: *UH10, p2: *UH9) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH12 = undefined; _ = &v7;
    var v8: *UH13 = undefined; _ = &v8;
    var v9: *UH13 = undefined; _ = &v9;
    var v10: *UH11 = undefined; _ = &v10;
    var v11: US9 = undefined; _ = &v11;
    var v12: *UH12 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: *UH12 = undefined; _ = &v14;
    var v15: *UH14 = undefined; _ = &v15;
    var v16: bool = undefined; _ = &v16;
    var v17: *UH8 = undefined; _ = &v17;
    var v18: *UH12 = undefined; _ = &v18;
    var v19: *UH14 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v22: bool = undefined; _ = &v22;
    var v21: bool = undefined; _ = &v21;
    var v23: bool = undefined; _ = &v23;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = normalize_33(v0);
                v6 = normalize_33(v3);
                v7 = UH12_InputEmpty();
                v8 = UH13_DfaConstructivePairTraceNil();
                v9 = UH13_DfaConstructivePairTraceCons(v5, v6, v7, v8);
                v10 = UH11_DfaStatePairNil();
                v11 = dfa_constructive_distinguishing_work_54(v2, v9, v10);
                switch (v11.tag) {
                    1 => {
                        v12 = v11.c1_0;
                        v13 = normalize_33(v0);
                        v14 = UH12_InputEmpty();
                        v15 = language_remainders_57(v13, v12);
                        v16 = input_list_contains_62(v14, v15);
                        v17 = normalize_33(v3);
                        v18 = UH12_InputEmpty();
                        v19 = language_remainders_57(v17, v12);
                        v20 = input_list_contains_62(v18, v19);
                        if (v16) {
                            v22 = v20;
                        } else {
                            v21 = false == v20;
                            v22 = v21;
                        }
                        v23 = v22 == false;
                        if (v23) {
                            v1 = v4;
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
fn dfa_minimal_with_distinguishing_witnesses_52(p0: *UH10, p1: *UH9) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_distinct_with_witness_against_53(v2, v3, v1);
                if (v4) {
                    v0 = v3;
                    continue;
                } else {
                    return false;
                }
            },
            0 => {
                return true;
            },
            else => unreachable,
        }
    }
}
fn regex_list_exact_budget_64(p0: *UH3, p1: *UH1) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v0 = v4;
                        v1 = v5;
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
fn regex_list_exact_budget_65(p0: *UH10, p1: *UH1) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v5 = v1.c1_0;
                        v0 = v4;
                        v1 = v5;
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
fn spiralMainValue() []const u8 {
    var v41: bool = undefined; _ = &v41;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: *UH3 = undefined; _ = &v26;
    var v27: US0 = undefined; _ = &v27;
    var v28: US0 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: *UH3 = undefined; _ = &v32;
    var v33: *UH3 = undefined; _ = &v33;
    var v34: US0 = undefined; _ = &v34;
    var v35: US0 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: *UH2 = undefined; _ = &v38;
    var v83: bool = undefined; _ = &v83;
    var v63: *UH10 = undefined; _ = &v63;
    var v64: *UH10 = undefined; _ = &v64;
    var v65: US6 = undefined; _ = &v65;
    var v66: US6 = undefined; _ = &v66;
    var v67: US6 = undefined; _ = &v67;
    var v68: *UH9 = undefined; _ = &v68;
    var v69: *UH9 = undefined; _ = &v69;
    var v70: *UH9 = undefined; _ = &v70;
    var v71: *UH9 = undefined; _ = &v71;
    var v72: *UH10 = undefined; _ = &v72;
    var v73: *UH10 = undefined; _ = &v73;
    var v74: US6 = undefined; _ = &v74;
    var v75: US6 = undefined; _ = &v75;
    var v76: US6 = undefined; _ = &v76;
    var v77: *UH9 = undefined; _ = &v77;
    var v78: *UH9 = undefined; _ = &v78;
    var v79: *UH9 = undefined; _ = &v79;
    var v80: *UH9 = undefined; _ = &v80;
    var v142: bool = undefined; _ = &v142;
    var v122: *UH10 = undefined; _ = &v122;
    var v123: *UH10 = undefined; _ = &v123;
    var v124: US6 = undefined; _ = &v124;
    var v125: US6 = undefined; _ = &v125;
    var v126: US6 = undefined; _ = &v126;
    var v127: *UH9 = undefined; _ = &v127;
    var v128: *UH9 = undefined; _ = &v128;
    var v129: *UH9 = undefined; _ = &v129;
    var v130: *UH9 = undefined; _ = &v130;
    var v131: *UH10 = undefined; _ = &v131;
    var v132: *UH10 = undefined; _ = &v132;
    var v133: US6 = undefined; _ = &v133;
    var v134: US6 = undefined; _ = &v134;
    var v135: US6 = undefined; _ = &v135;
    var v136: *UH9 = undefined; _ = &v136;
    var v137: *UH9 = undefined; _ = &v137;
    var v138: *UH9 = undefined; _ = &v138;
    var v139: *UH9 = undefined; _ = &v139;
    var v182: bool = undefined; _ = &v182;
    var v168: *UH3 = undefined; _ = &v168;
    var v169: *UH3 = undefined; _ = &v169;
    var v170: US0 = undefined; _ = &v170;
    var v171: US0 = undefined; _ = &v171;
    var v172: *UH2 = undefined; _ = &v172;
    var v173: *UH2 = undefined; _ = &v173;
    var v174: *UH2 = undefined; _ = &v174;
    var v175: *UH3 = undefined; _ = &v175;
    var v176: *UH3 = undefined; _ = &v176;
    var v177: *UH1 = undefined; _ = &v177;
    var v178: *UH1 = undefined; _ = &v178;
    var v179: *UH1 = undefined; _ = &v179;
    var v220: bool = undefined; _ = &v220;
    var v204: *UH10 = undefined; _ = &v204;
    var v205: *UH10 = undefined; _ = &v205;
    var v206: US6 = undefined; _ = &v206;
    var v207: US6 = undefined; _ = &v207;
    var v208: US6 = undefined; _ = &v208;
    var v209: *UH9 = undefined; _ = &v209;
    var v210: *UH9 = undefined; _ = &v210;
    var v211: *UH9 = undefined; _ = &v211;
    var v212: *UH9 = undefined; _ = &v212;
    var v213: *UH10 = undefined; _ = &v213;
    var v214: *UH10 = undefined; _ = &v214;
    var v215: *UH1 = undefined; _ = &v215;
    var v216: *UH1 = undefined; _ = &v216;
    var v217: *UH1 = undefined; _ = &v217;
    var v276: bool = undefined; _ = &v276;
    var v259: *UH10 = undefined; _ = &v259;
    var v260: *UH10 = undefined; _ = &v260;
    var v261: US6 = undefined; _ = &v261;
    var v262: US6 = undefined; _ = &v262;
    var v263: US6 = undefined; _ = &v263;
    var v264: *UH9 = undefined; _ = &v264;
    var v265: *UH9 = undefined; _ = &v265;
    var v266: *UH9 = undefined; _ = &v266;
    var v267: *UH9 = undefined; _ = &v267;
    var v268: *UH10 = undefined; _ = &v268;
    var v269: *UH10 = undefined; _ = &v269;
    var v270: *UH1 = undefined; _ = &v270;
    var v271: *UH1 = undefined; _ = &v271;
    var v272: *UH1 = undefined; _ = &v272;
    var v273: *UH1 = undefined; _ = &v273;
    var v319: bool = undefined; _ = &v319;
    var v304: *UH5 = undefined; _ = &v304;
    var v305: *UH0 = undefined; _ = &v305;
    var v306: *UH0 = undefined; _ = &v306;
    var v307: *UH5 = undefined; _ = &v307;
    var v308: *UH7 = undefined; _ = &v308;
    var v309: bool = undefined; _ = &v309;
    var v310: *UH0 = undefined; _ = &v310;
    var v311: *UH0 = undefined; _ = &v311;
    var v312: *UH5 = undefined; _ = &v312;
    var v313: *UH7 = undefined; _ = &v313;
    var v314: bool = undefined; _ = &v314;
    var v316: bool = undefined; _ = &v316;
    var v315: bool = undefined; _ = &v315;
    var v317: bool = undefined; _ = &v317;
    var v291: *UH0 = undefined; _ = &v291;
    var v292: *UH0 = undefined; _ = &v292;
    var v293: *UH0 = undefined; _ = &v293;
    var v294: *UH0 = undefined; _ = &v294;
    var v295: US0 = undefined; _ = &v295;
    var v296: US0 = undefined; _ = &v296;
    var v297: *UH2 = undefined; _ = &v297;
    var v298: *UH2 = undefined; _ = &v298;
    var v299: *UH2 = undefined; _ = &v299;
    var v300: *UH4 = undefined; _ = &v300;
    var v301: *UH4 = undefined; _ = &v301;
    var v302: *UH4 = undefined; _ = &v302;
    var v337: bool = undefined; _ = &v337;
    var v336: bool = undefined; _ = &v336;
    var v397: bool = undefined; _ = &v397;
    var v377: *UH5 = undefined; _ = &v377;
    var v378: US0 = undefined; _ = &v378;
    var v379: *UH0 = undefined; _ = &v379;
    var v380: US0 = undefined; _ = &v380;
    var v381: *UH0 = undefined; _ = &v381;
    var v382: *UH0 = undefined; _ = &v382;
    var v383: *UH0 = undefined; _ = &v383;
    var v384: *UH5 = undefined; _ = &v384;
    var v385: *UH7 = undefined; _ = &v385;
    var v386: bool = undefined; _ = &v386;
    var v387: US0 = undefined; _ = &v387;
    var v388: *UH0 = undefined; _ = &v388;
    var v389: *UH0 = undefined; _ = &v389;
    var v390: *UH5 = undefined; _ = &v390;
    var v391: *UH7 = undefined; _ = &v391;
    var v392: bool = undefined; _ = &v392;
    var v394: bool = undefined; _ = &v394;
    var v393: bool = undefined; _ = &v393;
    var v395: bool = undefined; _ = &v395;
    var v359: US0 = undefined; _ = &v359;
    var v360: *UH0 = undefined; _ = &v360;
    var v361: US0 = undefined; _ = &v361;
    var v362: *UH0 = undefined; _ = &v362;
    var v363: *UH0 = undefined; _ = &v363;
    var v364: *UH0 = undefined; _ = &v364;
    var v365: US0 = undefined; _ = &v365;
    var v366: *UH0 = undefined; _ = &v366;
    var v367: *UH0 = undefined; _ = &v367;
    var v368: US0 = undefined; _ = &v368;
    var v369: US0 = undefined; _ = &v369;
    var v370: *UH2 = undefined; _ = &v370;
    var v371: *UH2 = undefined; _ = &v371;
    var v372: *UH2 = undefined; _ = &v372;
    var v373: *UH4 = undefined; _ = &v373;
    var v374: *UH4 = undefined; _ = &v374;
    var v375: *UH4 = undefined; _ = &v375;
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
    const v11: *UH1 = regex_position_count_7(v10);
    const v12: *UH1 = UH1_StateBudgetSucc(v11);
    const v13: *UH1 = state_budget_pow2_9(v12);
    const v14: *UH0 = normalize_0(v10);
    const v15: US0 = US0_BitZero();
    const v16: US0 = US0_BitOne();
    const v17: *UH2 = UH2_SymbolListNil();
    const v18: *UH2 = UH2_SymbolListCons(v16, v17);
    const v19: *UH2 = UH2_SymbolListCons(v15, v18);
    const v20: *UH3 = UH3_RegexListNil();
    const v21: *UH3 = UH3_RegexListCons(v14, v20);
    const v22: *UH3 = UH3_RegexListNil();
    const v23: *UH3 = UH3_RegexListCons(v14, v22);
    const v24: US2 = dfa_closure_loop_bounded_10(v19, v13, v21, v23);
    switch (v24.tag) {
        1 => {
            v25 = v24.c1_0;
            v41 = false;
        },
        0 => {
            v26 = v24.c0_0;
            v27 = US0_BitZero();
            v28 = US0_BitOne();
            v29 = UH2_SymbolListNil();
            v30 = UH2_SymbolListCons(v28, v29);
            v31 = UH2_SymbolListCons(v27, v30);
            v32 = UH3_RegexListNil();
            v33 = dfa_minimize_states_loop_16(v26, v31, v32);
            v34 = US0_BitZero();
            v35 = US0_BitOne();
            v36 = UH2_SymbolListNil();
            v37 = UH2_SymbolListCons(v35, v36);
            v38 = UH2_SymbolListCons(v34, v37);
            v41 = dfa_minimal_with_distinguishing_witnesses_21(v33, v38);
        },
        else => unreachable,
    }
    if (v41) {
    } else {
        if (spiral_true) spiralFail("bit minimized DFA representatives should carry independent distinguishing words");
    }
    const v42: US6 = US6_TriA();
    const v43: *UH8 = UH8_RegexChar(v42);
    const v44: *UH8 = UH8_RegexStar(v43);
    const v45: *UH8 = normalize_33(v44);
    const v46: *UH8 = normalize_33(v45);
    const v47: *UH1 = regex_position_count_40(v46);
    const v48: *UH1 = UH1_StateBudgetSucc(v47);
    const v49: *UH1 = state_budget_pow2_9(v48);
    const v50: *UH8 = normalize_33(v46);
    const v51: US6 = US6_TriA();
    const v52: US6 = US6_TriB();
    const v53: US6 = US6_TriC();
    const v54: *UH9 = UH9_SymbolListNil();
    const v55: *UH9 = UH9_SymbolListCons(v53, v54);
    const v56: *UH9 = UH9_SymbolListCons(v52, v55);
    const v57: *UH9 = UH9_SymbolListCons(v51, v56);
    const v58: *UH10 = UH10_RegexListNil();
    const v59: *UH10 = UH10_RegexListCons(v50, v58);
    const v60: *UH10 = UH10_RegexListNil();
    const v61: *UH10 = UH10_RegexListCons(v50, v60);
    const v62: US7 = dfa_closure_loop_bounded_41(v57, v49, v59, v61);
    switch (v62.tag) {
        1 => {
            v63 = v62.c1_0;
            v83 = false;
        },
        0 => {
            v64 = v62.c0_0;
            v65 = US6_TriA();
            v66 = US6_TriB();
            v67 = US6_TriC();
            v68 = UH9_SymbolListNil();
            v69 = UH9_SymbolListCons(v67, v68);
            v70 = UH9_SymbolListCons(v66, v69);
            v71 = UH9_SymbolListCons(v65, v70);
            v72 = UH10_RegexListNil();
            v73 = dfa_minimize_states_loop_47(v64, v71, v72);
            v74 = US6_TriA();
            v75 = US6_TriB();
            v76 = US6_TriC();
            v77 = UH9_SymbolListNil();
            v78 = UH9_SymbolListCons(v76, v77);
            v79 = UH9_SymbolListCons(v75, v78);
            v80 = UH9_SymbolListCons(v74, v79);
            v83 = dfa_minimal_with_distinguishing_witnesses_52(v73, v80);
        },
        else => unreachable,
    }
    if (v83) {
    } else {
        if (spiral_true) spiralFail("ternary star minimized DFA representatives should carry independent distinguishing words");
    }
    const v84: US6 = US6_TriA();
    const v85: *UH8 = UH8_RegexChar(v84);
    const v86: US6 = US6_TriA();
    const v87: *UH8 = UH8_RegexChar(v86);
    const v88: *UH8 = UH8_RegexStar(v87);
    const v89: *UH8 = UH8_RegexCat(v85, v88);
    const v90: US6 = US6_TriB();
    const v91: *UH8 = UH8_RegexChar(v90);
    const v92: US6 = US6_TriA();
    const v93: *UH8 = UH8_RegexChar(v92);
    const v94: US6 = US6_TriA();
    const v95: *UH8 = UH8_RegexChar(v94);
    const v96: *UH8 = UH8_RegexCat(v93, v95);
    const v97: *UH8 = UH8_RegexStar(v96);
    const v98: US6 = US6_TriA();
    const v99: *UH8 = UH8_RegexChar(v98);
    const v100: *UH8 = UH8_RegexCat(v99, v97);
    const v101: *UH8 = UH8_RegexAlt(v97, v100);
    const v102: *UH8 = UH8_RegexCat(v91, v101);
    const v103: *UH8 = UH8_RegexAlt(v89, v102);
    const v104: *UH8 = normalize_33(v103);
    const v105: *UH8 = normalize_33(v104);
    const v106: *UH1 = regex_position_count_40(v105);
    const v107: *UH1 = UH1_StateBudgetSucc(v106);
    const v108: *UH1 = state_budget_pow2_9(v107);
    const v109: *UH8 = normalize_33(v105);
    const v110: US6 = US6_TriA();
    const v111: US6 = US6_TriB();
    const v112: US6 = US6_TriC();
    const v113: *UH9 = UH9_SymbolListNil();
    const v114: *UH9 = UH9_SymbolListCons(v112, v113);
    const v115: *UH9 = UH9_SymbolListCons(v111, v114);
    const v116: *UH9 = UH9_SymbolListCons(v110, v115);
    const v117: *UH10 = UH10_RegexListNil();
    const v118: *UH10 = UH10_RegexListCons(v109, v117);
    const v119: *UH10 = UH10_RegexListNil();
    const v120: *UH10 = UH10_RegexListCons(v109, v119);
    const v121: US7 = dfa_closure_loop_bounded_41(v116, v108, v118, v120);
    switch (v121.tag) {
        1 => {
            v122 = v121.c1_0;
            v142 = false;
        },
        0 => {
            v123 = v121.c0_0;
            v124 = US6_TriA();
            v125 = US6_TriB();
            v126 = US6_TriC();
            v127 = UH9_SymbolListNil();
            v128 = UH9_SymbolListCons(v126, v127);
            v129 = UH9_SymbolListCons(v125, v128);
            v130 = UH9_SymbolListCons(v124, v129);
            v131 = UH10_RegexListNil();
            v132 = dfa_minimize_states_loop_47(v123, v130, v131);
            v133 = US6_TriA();
            v134 = US6_TriB();
            v135 = US6_TriC();
            v136 = UH9_SymbolListNil();
            v137 = UH9_SymbolListCons(v135, v136);
            v138 = UH9_SymbolListCons(v134, v137);
            v139 = UH9_SymbolListCons(v133, v138);
            v142 = dfa_minimal_with_distinguishing_witnesses_52(v132, v139);
        },
        else => unreachable,
    }
    if (v142) {
    } else {
        if (spiral_true) spiralFail("cyclic quotient representatives should carry independent distinguishing words");
    }
    const v143: US0 = US0_BitZero();
    const v144: *UH0 = UH0_RegexChar(v143);
    const v145: US0 = US0_BitOne();
    const v146: *UH0 = UH0_RegexChar(v145);
    const v147: *UH0 = UH0_RegexAlt(v144, v146);
    const v148: *UH0 = UH0_RegexStar(v147);
    const v149: US0 = US0_BitZero();
    const v150: *UH0 = UH0_RegexChar(v149);
    const v151: *UH0 = UH0_RegexCat(v148, v150);
    const v152: *UH0 = normalize_0(v151);
    const v153: *UH0 = normalize_0(v152);
    const v154: *UH1 = regex_position_count_7(v153);
    const v155: *UH1 = UH1_StateBudgetSucc(v154);
    const v156: *UH1 = state_budget_pow2_9(v155);
    const v157: *UH0 = normalize_0(v153);
    const v158: US0 = US0_BitZero();
    const v159: US0 = US0_BitOne();
    const v160: *UH2 = UH2_SymbolListNil();
    const v161: *UH2 = UH2_SymbolListCons(v159, v160);
    const v162: *UH2 = UH2_SymbolListCons(v158, v161);
    const v163: *UH3 = UH3_RegexListNil();
    const v164: *UH3 = UH3_RegexListCons(v157, v163);
    const v165: *UH3 = UH3_RegexListNil();
    const v166: *UH3 = UH3_RegexListCons(v157, v165);
    const v167: US2 = dfa_closure_loop_bounded_10(v162, v156, v164, v166);
    switch (v167.tag) {
        1 => {
            v168 = v167.c1_0;
            v182 = false;
        },
        0 => {
            v169 = v167.c0_0;
            v170 = US0_BitZero();
            v171 = US0_BitOne();
            v172 = UH2_SymbolListNil();
            v173 = UH2_SymbolListCons(v171, v172);
            v174 = UH2_SymbolListCons(v170, v173);
            v175 = UH3_RegexListNil();
            v176 = dfa_minimize_states_loop_16(v169, v174, v175);
            v177 = UH1_StateBudgetZero();
            v178 = UH1_StateBudgetSucc(v177);
            v179 = UH1_StateBudgetSucc(v178);
            v182 = regex_list_exact_budget_64(v176, v179);
        },
        else => unreachable,
    }
    if (v182) {
    } else {
        if (spiral_true) spiralFail("bit minimized DFA should match the independent two-state reference quotient");
    }
    const v183: US6 = US6_TriA();
    const v184: *UH8 = UH8_RegexChar(v183);
    const v185: *UH8 = UH8_RegexStar(v184);
    const v186: *UH8 = normalize_33(v185);
    const v187: *UH8 = normalize_33(v186);
    const v188: *UH1 = regex_position_count_40(v187);
    const v189: *UH1 = UH1_StateBudgetSucc(v188);
    const v190: *UH1 = state_budget_pow2_9(v189);
    const v191: *UH8 = normalize_33(v187);
    const v192: US6 = US6_TriA();
    const v193: US6 = US6_TriB();
    const v194: US6 = US6_TriC();
    const v195: *UH9 = UH9_SymbolListNil();
    const v196: *UH9 = UH9_SymbolListCons(v194, v195);
    const v197: *UH9 = UH9_SymbolListCons(v193, v196);
    const v198: *UH9 = UH9_SymbolListCons(v192, v197);
    const v199: *UH10 = UH10_RegexListNil();
    const v200: *UH10 = UH10_RegexListCons(v191, v199);
    const v201: *UH10 = UH10_RegexListNil();
    const v202: *UH10 = UH10_RegexListCons(v191, v201);
    const v203: US7 = dfa_closure_loop_bounded_41(v198, v190, v200, v202);
    switch (v203.tag) {
        1 => {
            v204 = v203.c1_0;
            v220 = false;
        },
        0 => {
            v205 = v203.c0_0;
            v206 = US6_TriA();
            v207 = US6_TriB();
            v208 = US6_TriC();
            v209 = UH9_SymbolListNil();
            v210 = UH9_SymbolListCons(v208, v209);
            v211 = UH9_SymbolListCons(v207, v210);
            v212 = UH9_SymbolListCons(v206, v211);
            v213 = UH10_RegexListNil();
            v214 = dfa_minimize_states_loop_47(v205, v212, v213);
            v215 = UH1_StateBudgetZero();
            v216 = UH1_StateBudgetSucc(v215);
            v217 = UH1_StateBudgetSucc(v216);
            v220 = regex_list_exact_budget_65(v214, v217);
        },
        else => unreachable,
    }
    if (v220) {
    } else {
        if (spiral_true) spiralFail("ternary star minimized DFA should match the independent two-state reference quotient");
    }
    const v221: US6 = US6_TriA();
    const v222: *UH8 = UH8_RegexChar(v221);
    const v223: US6 = US6_TriA();
    const v224: *UH8 = UH8_RegexChar(v223);
    const v225: *UH8 = UH8_RegexStar(v224);
    const v226: *UH8 = UH8_RegexCat(v222, v225);
    const v227: US6 = US6_TriB();
    const v228: *UH8 = UH8_RegexChar(v227);
    const v229: US6 = US6_TriA();
    const v230: *UH8 = UH8_RegexChar(v229);
    const v231: US6 = US6_TriA();
    const v232: *UH8 = UH8_RegexChar(v231);
    const v233: *UH8 = UH8_RegexCat(v230, v232);
    const v234: *UH8 = UH8_RegexStar(v233);
    const v235: US6 = US6_TriA();
    const v236: *UH8 = UH8_RegexChar(v235);
    const v237: *UH8 = UH8_RegexCat(v236, v234);
    const v238: *UH8 = UH8_RegexAlt(v234, v237);
    const v239: *UH8 = UH8_RegexCat(v228, v238);
    const v240: *UH8 = UH8_RegexAlt(v226, v239);
    const v241: *UH8 = normalize_33(v240);
    const v242: *UH8 = normalize_33(v241);
    const v243: *UH1 = regex_position_count_40(v242);
    const v244: *UH1 = UH1_StateBudgetSucc(v243);
    const v245: *UH1 = state_budget_pow2_9(v244);
    const v246: *UH8 = normalize_33(v242);
    const v247: US6 = US6_TriA();
    const v248: US6 = US6_TriB();
    const v249: US6 = US6_TriC();
    const v250: *UH9 = UH9_SymbolListNil();
    const v251: *UH9 = UH9_SymbolListCons(v249, v250);
    const v252: *UH9 = UH9_SymbolListCons(v248, v251);
    const v253: *UH9 = UH9_SymbolListCons(v247, v252);
    const v254: *UH10 = UH10_RegexListNil();
    const v255: *UH10 = UH10_RegexListCons(v246, v254);
    const v256: *UH10 = UH10_RegexListNil();
    const v257: *UH10 = UH10_RegexListCons(v246, v256);
    const v258: US7 = dfa_closure_loop_bounded_41(v253, v245, v255, v257);
    switch (v258.tag) {
        1 => {
            v259 = v258.c1_0;
            v276 = false;
        },
        0 => {
            v260 = v258.c0_0;
            v261 = US6_TriA();
            v262 = US6_TriB();
            v263 = US6_TriC();
            v264 = UH9_SymbolListNil();
            v265 = UH9_SymbolListCons(v263, v264);
            v266 = UH9_SymbolListCons(v262, v265);
            v267 = UH9_SymbolListCons(v261, v266);
            v268 = UH10_RegexListNil();
            v269 = dfa_minimize_states_loop_47(v260, v267, v268);
            v270 = UH1_StateBudgetZero();
            v271 = UH1_StateBudgetSucc(v270);
            v272 = UH1_StateBudgetSucc(v271);
            v273 = UH1_StateBudgetSucc(v272);
            v276 = regex_list_exact_budget_65(v269, v273);
        },
        else => unreachable,
    }
    if (v276) {
    } else {
        if (spiral_true) spiralFail("cyclic minimized DFA should match the independent three-state reference quotient");
    }
    const v277: *UH0 = UH0_RegexEpsilon();
    const v278: *UH0 = normalize_0(v277);
    const v279: *UH0 = UH0_RegexEmpty();
    const v280: *UH0 = normalize_0(v279);
    const v281: US0 = US0_BitZero();
    const v282: US0 = US0_BitOne();
    const v283: *UH2 = UH2_SymbolListNil();
    const v284: *UH2 = UH2_SymbolListCons(v282, v283);
    const v285: *UH2 = UH2_SymbolListCons(v281, v284);
    const v286: *UH5 = UH5_InputEmpty();
    const v287: *UH6 = UH6_DfaConstructivePairTraceNil();
    const v288: *UH6 = UH6_DfaConstructivePairTraceCons(v278, v280, v286, v287);
    const v289: *UH4 = UH4_DfaStatePairNil();
    const v290: US5 = dfa_constructive_distinguishing_work_23(v285, v288, v289);
    switch (v290.tag) {
        1 => {
            v304 = v290.c1_0;
            v305 = UH0_RegexEpsilon();
            v306 = normalize_0(v305);
            v307 = UH5_InputEmpty();
            v308 = language_remainders_26(v306, v304);
            v309 = input_list_contains_31(v307, v308);
            v310 = UH0_RegexEmpty();
            v311 = normalize_0(v310);
            v312 = UH5_InputEmpty();
            v313 = language_remainders_26(v311, v304);
            v314 = input_list_contains_31(v312, v313);
            if (v309) {
                v316 = v314;
            } else {
                v315 = false == v314;
                v316 = v315;
            }
            v317 = v316 == false;
            v319 = v317;
        },
        0 => {
            v291 = UH0_RegexEpsilon();
            v292 = normalize_0(v291);
            v293 = UH0_RegexEmpty();
            v294 = normalize_0(v293);
            v295 = US0_BitZero();
            v296 = US0_BitOne();
            v297 = UH2_SymbolListNil();
            v298 = UH2_SymbolListCons(v296, v297);
            v299 = UH2_SymbolListCons(v295, v298);
            v300 = UH4_DfaStatePairNil();
            v301 = UH4_DfaStatePairCons(v292, v294, v300);
            v302 = UH4_DfaStatePairNil();
            v319 = dfa_bisimulation_work_18(v299, v301, v302);
        },
        else => unreachable,
    }
    if (v319) {
    } else {
        if (spiral_true) spiralFail("nullable mismatch should produce a language-valid distinguishing word");
    }
    const v320: *UH0 = UH0_RegexEpsilon();
    const v321: *UH0 = normalize_0(v320);
    const v322: *UH5 = UH5_InputEmpty();
    const v323: US0 = US0_BitZero();
    const v324: *UH5 = UH5_InputEmpty();
    const v325: *UH5 = UH5_InputCons(v323, v324);
    const v326: *UH7 = language_remainders_26(v321, v325);
    const v327: bool = input_list_contains_31(v322, v326);
    const v328: *UH0 = UH0_RegexEmpty();
    const v329: *UH0 = normalize_0(v328);
    const v330: *UH5 = UH5_InputEmpty();
    const v331: US0 = US0_BitZero();
    const v332: *UH5 = UH5_InputEmpty();
    const v333: *UH5 = UH5_InputCons(v331, v332);
    const v334: *UH7 = language_remainders_26(v329, v333);
    const v335: bool = input_list_contains_31(v330, v334);
    if (v327) {
        v337 = v335;
    } else {
        v336 = false == v335;
        v337 = v336;
    }
    const v338: bool = v337 == false;
    const v339: bool = v338 == false;
    if (v339) {
    } else {
        if (spiral_true) spiralFail("independent language semantics must reject a forged non-distinguishing word");
    }
    const v340: US0 = US0_BitZero();
    const v341: *UH0 = UH0_RegexChar(v340);
    const v342: US0 = US0_BitZero();
    const v343: *UH0 = UH0_RegexChar(v342);
    const v344: *UH0 = UH0_RegexAlt(v341, v343);
    const v345: *UH0 = normalize_0(v344);
    const v346: US0 = US0_BitZero();
    const v347: *UH0 = UH0_RegexChar(v346);
    const v348: *UH0 = normalize_0(v347);
    const v349: US0 = US0_BitZero();
    const v350: US0 = US0_BitOne();
    const v351: *UH2 = UH2_SymbolListNil();
    const v352: *UH2 = UH2_SymbolListCons(v350, v351);
    const v353: *UH2 = UH2_SymbolListCons(v349, v352);
    const v354: *UH5 = UH5_InputEmpty();
    const v355: *UH6 = UH6_DfaConstructivePairTraceNil();
    const v356: *UH6 = UH6_DfaConstructivePairTraceCons(v345, v348, v354, v355);
    const v357: *UH4 = UH4_DfaStatePairNil();
    const v358: US5 = dfa_constructive_distinguishing_work_23(v353, v356, v357);
    switch (v358.tag) {
        1 => {
            v377 = v358.c1_0;
            v378 = US0_BitZero();
            v379 = UH0_RegexChar(v378);
            v380 = US0_BitZero();
            v381 = UH0_RegexChar(v380);
            v382 = UH0_RegexAlt(v379, v381);
            v383 = normalize_0(v382);
            v384 = UH5_InputEmpty();
            v385 = language_remainders_26(v383, v377);
            v386 = input_list_contains_31(v384, v385);
            v387 = US0_BitZero();
            v388 = UH0_RegexChar(v387);
            v389 = normalize_0(v388);
            v390 = UH5_InputEmpty();
            v391 = language_remainders_26(v389, v377);
            v392 = input_list_contains_31(v390, v391);
            if (v386) {
                v394 = v392;
            } else {
                v393 = false == v392;
                v394 = v393;
            }
            v395 = v394 == false;
            v397 = v395;
        },
        0 => {
            v359 = US0_BitZero();
            v360 = UH0_RegexChar(v359);
            v361 = US0_BitZero();
            v362 = UH0_RegexChar(v361);
            v363 = UH0_RegexAlt(v360, v362);
            v364 = normalize_0(v363);
            v365 = US0_BitZero();
            v366 = UH0_RegexChar(v365);
            v367 = normalize_0(v366);
            v368 = US0_BitZero();
            v369 = US0_BitOne();
            v370 = UH2_SymbolListNil();
            v371 = UH2_SymbolListCons(v369, v370);
            v372 = UH2_SymbolListCons(v368, v371);
            v373 = UH4_DfaStatePairNil();
            v374 = UH4_DfaStatePairCons(v364, v367, v373);
            v375 = UH4_DfaStatePairNil();
            v397 = dfa_bisimulation_work_18(v372, v374, v375);
        },
        else => unreachable,
    }
    if (v397) {
    } else {
        if (spiral_true) spiralFail("normalized language-equivalent states should remain bisimilar");
    }
    const v398: []const u8 = "brzozowski-minimization-witness-green";
    return v398;
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
