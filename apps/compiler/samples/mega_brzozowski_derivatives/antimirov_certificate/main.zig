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
const UH2 = struct { tag: i32, c1_0: *UH2 = undefined };
const UH3 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH3 = undefined };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
const UH4 = struct { tag: i32, c2_0: US3 = undefined, c3_0: *UH4 = undefined, c3_1: *UH4 = undefined, c4_0: *UH4 = undefined, c4_1: *UH4 = undefined, c5_0: *UH4 = undefined };
const UH5 = struct { tag: i32, c1_0: *UH4 = undefined, c1_1: *UH5 = undefined };
const UH6 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH6 = undefined };
const UH7 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH7 = undefined };
const US5 = struct { tag: i32, c0_0: *UH0 = undefined, c0_1: US0 = undefined, c0_2: *UH0 = undefined };
const US4 = struct { tag: i32, c1_0: US5 = undefined };
const UH8 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH8 = undefined };
const US7 = struct { tag: i32, c0_0: *UH4 = undefined, c0_1: US3 = undefined, c0_2: *UH4 = undefined };
const US6 = struct { tag: i32, c1_0: US7 = undefined };
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
fn antimirov_origin_append_13(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = antimirov_origin_append_13(v3, v1);
            return UH1_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn antimirov_origin_map_cat_right_14(p0: *UH1, p1: *UH0) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = make_cat_4(v3, v1);
            v6 = normalize_0(v5);
            v7 = antimirov_origin_map_cat_right_14(v4, v1);
            return UH1_RegexListCons(v6, v7);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_position_origins_12(p0: *UH0) *UH1 {
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
            v9 = antimirov_position_origins_12(v7);
            v10 = antimirov_position_origins_12(v8);
            return antimirov_origin_append_13(v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = antimirov_position_origins_12(v12);
            v15 = antimirov_origin_map_cat_right_14(v14, v13);
            v16 = antimirov_position_origins_12(v13);
            return antimirov_origin_append_13(v15, v16);
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
            v19 = antimirov_position_origins_12(v18);
            v20 = UH0_RegexStar(v18);
            return antimirov_origin_map_cat_right_14(v19, v20);
        },
        else => unreachable,
    }
}
fn regex_list_distinct_15(p0: *UH1) bool {
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
fn antimirov_subset_16(p0: *UH1, p1: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = normalize_0(v2);
                v5 = regex_list_contains_10(v4, v1);
                if (v5) {
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
fn UH2_StateBudgetZero() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_StateBudgetSucc(a0: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0 });
}
fn state_budget_add_18(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = state_budget_add_18(v2, v1);
            return UH2_StateBudgetSucc(v3);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_position_count_17(p0: *UH0) *UH2 {
    var v0: *UH0 = p0; _ = &v0;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v11: *UH0 = undefined; _ = &v11;
    var v12: *UH0 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v16: *UH0 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_17(v6);
                v9 = regex_position_count_17(v7);
                return state_budget_add_18(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_17(v11);
                v14 = regex_position_count_17(v12);
                return state_budget_add_18(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH2_StateBudgetZero();
                return UH2_StateBudgetSucc(v4);
            },
            0 => {
                return UH2_StateBudgetZero();
            },
            1 => {
                return UH2_StateBudgetZero();
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
fn regex_list_exact_budget_19(p0: *UH1, p1: *UH2) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
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
fn UH3_SymbolListNil() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 0 };
    };
    return &shared.value;
}
fn UH3_SymbolListCons(a0: US0, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US2_Nullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_NonNullable() US2 {
    return US2{ .tag = 1 };
}
fn nullable_22(p0: *UH0) US2 {
    var v0: *UH0 = p0; _ = &v0;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH0 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH0 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_22(v5);
            v8 = nullable_22(v6);
            switch (v7.tag) {
                0 => {
                    return US2_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_NonNullable();
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
            v18 = nullable_22(v16);
            v19 = nullable_22(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            return US2_NonNullable();
                        },
                    }
                },
                else => {
                    return US2_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_NonNullable();
        },
        0 => {
            return US2_NonNullable();
        },
        1 => {
            return US2_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_Nullable();
        },
        else => unreachable,
    }
}
fn antimirov_partial_derivative_21(p0: *UH0, p1: US0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v23: *UH1 = undefined; _ = &v23;
    var v24: *UH1 = undefined; _ = &v24;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH1 = undefined; _ = &v28;
    var v29: *UH1 = undefined; _ = &v29;
    var v30: US2 = undefined; _ = &v30;
    var v31: *UH1 = undefined; _ = &v31;
    var v4: US0 = undefined; _ = &v4;
    var v14: US1 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v16: *UH0 = undefined; _ = &v16;
    var v17: *UH1 = undefined; _ = &v17;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH1 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v21 = v0.c3_0;
            v22 = v0.c3_1;
            v23 = antimirov_partial_derivative_21(v21, v1);
            v24 = antimirov_partial_derivative_21(v22, v1);
            return antimirov_union_8(v23, v24);
        },
        4 => {
            v26 = v0.c4_0;
            v27 = v0.c4_1;
            v28 = antimirov_partial_derivative_21(v26, v1);
            v29 = antimirov_map_cat_right_11(v28, v27);
            v30 = nullable_22(v26);
            switch (v30.tag) {
                1 => {
                    return v29;
                },
                0 => {
                    v31 = antimirov_partial_derivative_21(v27, v1);
                    return antimirov_union_8(v29, v31);
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
                v16 = UH0_RegexEpsilon();
                v17 = UH1_RegexListNil();
                return UH1_RegexListCons(v16, v17);
            } else {
                return UH1_RegexListNil();
            }
        },
        0 => {
            return UH1_RegexListNil();
        },
        1 => {
            return UH1_RegexListNil();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = antimirov_partial_derivative_21(v35, v1);
            v37 = UH0_RegexStar(v35);
            return antimirov_map_cat_right_11(v36, v37);
        },
        else => unreachable,
    }
}
fn antimirov_partial_derivatives_origin_supported_20(p0: *UH0, p1: *UH3) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_0(v0);
                v5 = antimirov_partial_derivative_21(v4, v2);
                v6 = antimirov_position_origins_12(v4);
                v7 = antimirov_subset_16(v5, v6);
                if (v7) {
                    v1 = v3;
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
fn antimirov_value_supported_for_symbols_24(p0: *UH0, p1: *UH0, p2: *UH3) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH3 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = normalize_0(v1);
                v6 = antimirov_partial_derivative_21(v5, v3);
                v7 = normalize_0(v0);
                v8 = antimirov_residual_support_7(v7);
                v9 = antimirov_insert_unique_9(v7, v8);
                v10 = antimirov_subset_16(v6, v9);
                if (v10) {
                    v2 = v4;
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
fn antimirov_support_closed_23(p0: *UH0, p1: *UH1, p2: *UH3) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH3 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = antimirov_value_supported_for_symbols_24(v0, v3, v2);
                if (v5) {
                    v1 = v4;
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
fn antimirov_state_regex_26(p0: *UH1) *UH0 {
    var v0: *UH1 = p0; _ = &v0;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = antimirov_state_regex_26(v3);
            return make_alt_1(v2, v4);
        },
        0 => {
            return UH0_RegexEmpty();
        },
        else => unreachable,
    }
}
fn derivative_28(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
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
            v21 = derivative_28(v19, v1);
            v22 = derivative_28(v20, v1);
            return make_alt_1(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_22(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_28(v24, v1);
                    return make_cat_4(v31, v25);
                },
                0 => {
                    v27 = derivative_28(v24, v1);
                    v28 = make_cat_4(v27, v25);
                    v29 = derivative_28(v25, v1);
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
            v36 = derivative_28(v35, v1);
            v37 = make_star_6(v35);
            return make_cat_4(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_27(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_0(v0);
    const v3: *UH0 = derivative_28(v2, v1);
    return normalize_0(v3);
}
fn antimirov_reconstruction_symbols_25(p0: *UH0, p1: *UH3) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_0(v0);
                v5 = antimirov_partial_derivative_21(v4, v2);
                v6 = antimirov_state_regex_26(v5);
                v7 = normalize_0(v6);
                v8 = canonical_derivative_27(v4, v2);
                v9 = regex_equal_5(v7, v8);
                if (v9) {
                    v1 = v3;
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
fn US3_TriA() US3 {
    return US3{ .tag = 0 };
}
fn US3_TriB() US3 {
    return US3{ .tag = 1 };
}
fn US3_TriC() US3 {
    return US3{ .tag = 2 };
}
fn UH4_RegexEmpty() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_RegexEpsilon() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 1 };
    };
    return &shared.value;
}
fn UH4_RegexChar(a0: US3) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 2, .c2_0 = a0 });
}
fn UH4_RegexAlt(a0: *UH4, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH4_RegexCat(a0: *UH4, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH4_RegexStar(a0: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 5, .c5_0 = a0 });
}
fn regex_compare_32(p0: *UH4, p1: *UH4) US1 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v59: *UH4 = undefined; _ = &v59;
    var v60: *UH4 = undefined; _ = &v60;
    var v61: *UH4 = undefined; _ = &v61;
    var v62: *UH4 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var v34: *UH4 = undefined; _ = &v34;
    var v35: *UH4 = undefined; _ = &v35;
    var v40: *UH4 = undefined; _ = &v40;
    var v41: *UH4 = undefined; _ = &v41;
    var v42: US1 = undefined; _ = &v42;
    var v38: US3 = undefined; _ = &v38;
    var v10: US3 = undefined; _ = &v10;
    var v13: US3 = undefined; _ = &v13;
    var v50: *UH4 = undefined; _ = &v50;
    var v51: *UH4 = undefined; _ = &v51;
    var v52: *UH4 = undefined; _ = &v52;
    var v54: *UH4 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_32(v59, v61);
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
                        v42 = regex_compare_32(v34, v40);
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
fn alt_insert_sorted_31(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH4 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_32(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_31(v0, v3);
                    return UH4_RegexAlt(v2, v6);
                },
                0 => {
                    return UH4_RegexAlt(v0, v1);
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
            v11 = regex_compare_32(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH4_RegexAlt(v1, v0);
                },
                0 => {
                    return UH4_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_30(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_31(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_31(v0, v1);
            },
        }
    }
}
fn regex_equal_34(p0: *UH4, p1: *UH4) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v24: *UH4 = undefined; _ = &v24;
    var v25: *UH4 = undefined; _ = &v25;
    var v26: *UH4 = undefined; _ = &v26;
    var v27: *UH4 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH4 = undefined; _ = &v32;
    var v33: *UH4 = undefined; _ = &v33;
    var v34: *UH4 = undefined; _ = &v34;
    var v35: *UH4 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v21: US1 = undefined; _ = &v21;
    var v40: *UH4 = undefined; _ = &v40;
    var v41: *UH4 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_34(v24, v26);
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
                        v36 = regex_equal_34(v32, v34);
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
fn make_cat_33(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v12: *UH4 = undefined; _ = &v12;
    var v13: *UH4 = undefined; _ = &v13;
    var v14: *UH4 = undefined; _ = &v14;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH4_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH4_RegexEmpty();
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
                                            v14 = make_cat_33(v13, v1);
                                            return UH4_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_34(v4, v5);
                                                    if (v6) {
                                                        return UH4_RegexStar(v4);
                                                    } else {
                                                        return UH4_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH4_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH4_RegexCat(v0, v1);
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
fn make_star_35(p0: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v3: *UH4 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH4_RegexEpsilon();
        },
        1 => {
            return UH4_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH4_RegexStar(v3);
        },
        else => {
            return UH4_RegexStar(v0);
        },
    }
}
fn normalize_29(p0: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v10: *UH4 = undefined; _ = &v10;
    var v11: *UH4 = undefined; _ = &v11;
    var v12: *UH4 = undefined; _ = &v12;
    var v13: *UH4 = undefined; _ = &v13;
    var v3: US3 = undefined; _ = &v3;
    var v15: *UH4 = undefined; _ = &v15;
    var v16: *UH4 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_29(v5);
            v8 = normalize_29(v6);
            return make_alt_30(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_29(v10);
            v13 = normalize_29(v11);
            return make_cat_33(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH4_RegexChar(v3);
        },
        0 => {
            return UH4_RegexEmpty();
        },
        1 => {
            return UH4_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_29(v15);
            return make_star_35(v16);
        },
        else => unreachable,
    }
}
fn UH5_RegexListNil() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_RegexListCons(a0: *UH4, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn regex_list_contains_39(p0: *UH4, p1: *UH5) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_34(v0, v2);
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
fn antimirov_insert_unique_38(p0: *UH4, p1: *UH5) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    const v2: *UH4 = normalize_29(v0);
    const v3: bool = regex_list_contains_39(v2, v1);
    if (v3) {
        return v1;
    } else {
        return UH5_RegexListCons(v2, v1);
    }
}
fn antimirov_union_37(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = antimirov_insert_unique_38(v2, v1);
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
fn antimirov_map_cat_right_40(p0: *UH5, p1: *UH4) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = make_cat_33(v3, v1);
            v6 = antimirov_map_cat_right_40(v4, v1);
            return antimirov_insert_unique_38(v5, v6);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_residual_support_36(p0: *UH4) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH5 = undefined; _ = &v10;
    var v12: *UH4 = undefined; _ = &v12;
    var v13: *UH4 = undefined; _ = &v13;
    var v14: *UH5 = undefined; _ = &v14;
    var v15: *UH5 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v18: *UH4 = undefined; _ = &v18;
    var v19: *UH5 = undefined; _ = &v19;
    var v20: *UH4 = undefined; _ = &v20;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = antimirov_residual_support_36(v7);
            v10 = antimirov_residual_support_36(v8);
            return antimirov_union_37(v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = antimirov_residual_support_36(v12);
            v15 = antimirov_map_cat_right_40(v14, v13);
            v16 = antimirov_residual_support_36(v13);
            return antimirov_union_37(v15, v16);
        },
        2 => {
            v3 = v0.c2_0;
            v4 = UH4_RegexEpsilon();
            v5 = UH5_RegexListNil();
            return UH5_RegexListCons(v4, v5);
        },
        0 => {
            return UH5_RegexListNil();
        },
        1 => {
            return UH5_RegexListNil();
        },
        5 => {
            v18 = v0.c5_0;
            v19 = antimirov_residual_support_36(v18);
            v20 = UH4_RegexStar(v18);
            return antimirov_map_cat_right_40(v19, v20);
        },
        else => unreachable,
    }
}
fn antimirov_origin_append_42(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = antimirov_origin_append_42(v3, v1);
            return UH5_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn antimirov_origin_map_cat_right_43(p0: *UH5, p1: *UH4) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = make_cat_33(v3, v1);
            v6 = normalize_29(v5);
            v7 = antimirov_origin_map_cat_right_43(v4, v1);
            return UH5_RegexListCons(v6, v7);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_position_origins_41(p0: *UH4) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH5 = undefined; _ = &v10;
    var v12: *UH4 = undefined; _ = &v12;
    var v13: *UH4 = undefined; _ = &v13;
    var v14: *UH5 = undefined; _ = &v14;
    var v15: *UH5 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v18: *UH4 = undefined; _ = &v18;
    var v19: *UH5 = undefined; _ = &v19;
    var v20: *UH4 = undefined; _ = &v20;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = antimirov_position_origins_41(v7);
            v10 = antimirov_position_origins_41(v8);
            return antimirov_origin_append_42(v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = antimirov_position_origins_41(v12);
            v15 = antimirov_origin_map_cat_right_43(v14, v13);
            v16 = antimirov_position_origins_41(v13);
            return antimirov_origin_append_42(v15, v16);
        },
        2 => {
            v3 = v0.c2_0;
            v4 = UH4_RegexEpsilon();
            v5 = UH5_RegexListNil();
            return UH5_RegexListCons(v4, v5);
        },
        0 => {
            return UH5_RegexListNil();
        },
        1 => {
            return UH5_RegexListNil();
        },
        5 => {
            v18 = v0.c5_0;
            v19 = antimirov_position_origins_41(v18);
            v20 = UH4_RegexStar(v18);
            return antimirov_origin_map_cat_right_43(v19, v20);
        },
        else => unreachable,
    }
}
fn regex_list_distinct_44(p0: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_list_contains_39(v1, v2);
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
fn antimirov_subset_45(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = normalize_29(v2);
                v5 = regex_list_contains_39(v4, v1);
                if (v5) {
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
fn regex_position_count_46(p0: *UH4) *UH2 {
    var v0: *UH4 = p0; _ = &v0;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v11: *UH4 = undefined; _ = &v11;
    var v12: *UH4 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v16: *UH4 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_46(v6);
                v9 = regex_position_count_46(v7);
                return state_budget_add_18(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_46(v11);
                v14 = regex_position_count_46(v12);
                return state_budget_add_18(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH2_StateBudgetZero();
                return UH2_StateBudgetSucc(v4);
            },
            0 => {
                return UH2_StateBudgetZero();
            },
            1 => {
                return UH2_StateBudgetZero();
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
fn regex_list_exact_budget_47(p0: *UH5, p1: *UH2) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
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
fn UH6_SymbolListNil() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_SymbolListCons(a0: US3, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn nullable_50(p0: *UH4) US2 {
    var v0: *UH4 = p0; _ = &v0;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH4 = undefined; _ = &v16;
    var v17: *UH4 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US3 = undefined; _ = &v3;
    var v25: *UH4 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_50(v5);
            v8 = nullable_50(v6);
            switch (v7.tag) {
                0 => {
                    return US2_Nullable();
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            return US2_NonNullable();
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
            v18 = nullable_50(v16);
            v19 = nullable_50(v17);
            switch (v18.tag) {
                0 => {
                    switch (v19.tag) {
                        0 => {
                            return US2_Nullable();
                        },
                        else => {
                            return US2_NonNullable();
                        },
                    }
                },
                else => {
                    return US2_NonNullable();
                },
            }
        },
        2 => {
            v3 = v0.c2_0;
            return US2_NonNullable();
        },
        0 => {
            return US2_NonNullable();
        },
        1 => {
            return US2_Nullable();
        },
        5 => {
            v25 = v0.c5_0;
            return US2_Nullable();
        },
        else => unreachable,
    }
}
fn antimirov_partial_derivative_49(p0: *UH4, p1: US3) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v27: *UH4 = undefined; _ = &v27;
    var v28: *UH4 = undefined; _ = &v28;
    var v29: *UH5 = undefined; _ = &v29;
    var v30: *UH5 = undefined; _ = &v30;
    var v32: *UH4 = undefined; _ = &v32;
    var v33: *UH4 = undefined; _ = &v33;
    var v34: *UH5 = undefined; _ = &v34;
    var v35: *UH5 = undefined; _ = &v35;
    var v36: US2 = undefined; _ = &v36;
    var v37: *UH5 = undefined; _ = &v37;
    var v4: US3 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: *UH4 = undefined; _ = &v22;
    var v23: *UH5 = undefined; _ = &v23;
    var v41: *UH4 = undefined; _ = &v41;
    var v42: *UH5 = undefined; _ = &v42;
    var v43: *UH4 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v27 = v0.c3_0;
            v28 = v0.c3_1;
            v29 = antimirov_partial_derivative_49(v27, v1);
            v30 = antimirov_partial_derivative_49(v28, v1);
            return antimirov_union_37(v29, v30);
        },
        4 => {
            v32 = v0.c4_0;
            v33 = v0.c4_1;
            v34 = antimirov_partial_derivative_49(v32, v1);
            v35 = antimirov_map_cat_right_40(v34, v33);
            v36 = nullable_50(v32);
            switch (v36.tag) {
                1 => {
                    return v35;
                },
                0 => {
                    v37 = antimirov_partial_derivative_49(v33, v1);
                    return antimirov_union_37(v35, v37);
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
                v22 = UH4_RegexEpsilon();
                v23 = UH5_RegexListNil();
                return UH5_RegexListCons(v22, v23);
            } else {
                return UH5_RegexListNil();
            }
        },
        0 => {
            return UH5_RegexListNil();
        },
        1 => {
            return UH5_RegexListNil();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = antimirov_partial_derivative_49(v41, v1);
            v43 = UH4_RegexStar(v41);
            return antimirov_map_cat_right_40(v42, v43);
        },
        else => unreachable,
    }
}
fn antimirov_partial_derivatives_origin_supported_48(p0: *UH4, p1: *UH6) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_29(v0);
                v5 = antimirov_partial_derivative_49(v4, v2);
                v6 = antimirov_position_origins_41(v4);
                v7 = antimirov_subset_45(v5, v6);
                if (v7) {
                    v1 = v3;
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
fn antimirov_value_supported_for_symbols_52(p0: *UH4, p1: *UH4, p2: *UH6) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: US3 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = normalize_29(v1);
                v6 = antimirov_partial_derivative_49(v5, v3);
                v7 = normalize_29(v0);
                v8 = antimirov_residual_support_36(v7);
                v9 = antimirov_insert_unique_38(v7, v8);
                v10 = antimirov_subset_45(v6, v9);
                if (v10) {
                    v2 = v4;
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
fn antimirov_support_closed_51(p0: *UH4, p1: *UH5, p2: *UH6) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = antimirov_value_supported_for_symbols_52(v0, v3, v2);
                if (v5) {
                    v1 = v4;
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
fn antimirov_state_regex_54(p0: *UH5) *UH4 {
    var v0: *UH5 = p0; _ = &v0;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = antimirov_state_regex_54(v3);
            return make_alt_30(v2, v4);
        },
        0 => {
            return UH4_RegexEmpty();
        },
        else => unreachable,
    }
}
fn derivative_56(p0: *UH4, p1: US3) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH4 = undefined; _ = &v25;
    var v26: *UH4 = undefined; _ = &v26;
    var v27: *UH4 = undefined; _ = &v27;
    var v28: *UH4 = undefined; _ = &v28;
    var v30: *UH4 = undefined; _ = &v30;
    var v31: *UH4 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH4 = undefined; _ = &v37;
    var v33: *UH4 = undefined; _ = &v33;
    var v34: *UH4 = undefined; _ = &v34;
    var v35: *UH4 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH4 = undefined; _ = &v41;
    var v42: *UH4 = undefined; _ = &v42;
    var v43: *UH4 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_56(v25, v1);
            v28 = derivative_56(v26, v1);
            return make_alt_30(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_50(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_56(v30, v1);
                    return make_cat_33(v37, v31);
                },
                0 => {
                    v33 = derivative_56(v30, v1);
                    v34 = make_cat_33(v33, v31);
                    v35 = derivative_56(v31, v1);
                    return make_alt_30(v34, v35);
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
                return UH4_RegexEpsilon();
            } else {
                return UH4_RegexEmpty();
            }
        },
        0 => {
            return UH4_RegexEmpty();
        },
        1 => {
            return UH4_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_56(v41, v1);
            v43 = make_star_35(v41);
            return make_cat_33(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_55(p0: *UH4, p1: US3) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    const v2: *UH4 = normalize_29(v0);
    const v3: *UH4 = derivative_56(v2, v1);
    return normalize_29(v3);
}
fn antimirov_reconstruction_symbols_53(p0: *UH4, p1: *UH6) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_29(v0);
                v5 = antimirov_partial_derivative_49(v4, v2);
                v6 = antimirov_state_regex_54(v5);
                v7 = normalize_29(v6);
                v8 = canonical_derivative_55(v4, v2);
                v9 = regex_equal_34(v7, v8);
                if (v9) {
                    v1 = v3;
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
fn regex_chars_from_symbols_57(p0: *UH3) *UH1 {
    var v0: *UH3 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_chars_from_symbols_57(v3);
            v5 = UH0_RegexChar(v2);
            return UH1_RegexListCons(v5, v4);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_star_corpus_58(p0: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_star_corpus_58(v3);
            v5 = UH0_RegexStar(v2);
            return UH1_RegexListCons(v5, v4);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_list_append_60(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_list_append_60(v3, v1);
            return UH1_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_pairs_with_61(p0: *UH0, p1: *UH1) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = regex_pairs_with_61(v0, v4);
            v6 = UH0_RegexAlt(v0, v3);
            v7 = UH0_RegexCat(v0, v3);
            v8 = UH1_RegexListCons(v7, v5);
            return UH1_RegexListCons(v6, v8);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_binary_corpus_59(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = regex_pairs_with_61(v3, v1);
            v6 = regex_binary_corpus_59(v4, v1);
            return regex_list_append_60(v5, v6);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_chars_from_symbols_62(p0: *UH6) *UH5 {
    var v0: *UH6 = p0; _ = &v0;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_chars_from_symbols_62(v3);
            v5 = UH4_RegexChar(v2);
            return UH5_RegexListCons(v5, v4);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_star_corpus_63(p0: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_star_corpus_63(v3);
            v5 = UH4_RegexStar(v2);
            return UH5_RegexListCons(v5, v4);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_list_append_65(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_list_append_65(v3, v1);
            return UH5_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_pairs_with_66(p0: *UH4, p1: *UH5) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = regex_pairs_with_66(v0, v4);
            v6 = UH4_RegexAlt(v0, v3);
            v7 = UH4_RegexCat(v0, v3);
            v8 = UH5_RegexListCons(v7, v5);
            return UH5_RegexListCons(v6, v8);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_binary_corpus_64(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = regex_pairs_with_66(v3, v1);
            v6 = regex_binary_corpus_64(v4, v1);
            return regex_list_append_65(v5, v6);
        },
        0 => {
            return UH5_RegexListNil();
        },
        else => unreachable,
    }
}
fn antimirov_corpus_certificate_67(p0: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = undefined; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v15: bool = undefined; _ = &v15;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v18: *UH1 = undefined; _ = &v18;
    var v23: bool = undefined; _ = &v23;
    var v21: *UH2 = undefined; _ = &v21;
    var v28: bool = undefined; _ = &v28;
    var v24: *UH1 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v49: bool = undefined; _ = &v49;
    var v29: US0 = undefined; _ = &v29;
    var v30: US0 = undefined; _ = &v30;
    var v31: *UH3 = undefined; _ = &v31;
    var v32: *UH3 = undefined; _ = &v32;
    var v33: *UH3 = undefined; _ = &v33;
    var v34: bool = undefined; _ = &v34;
    var v35: US0 = undefined; _ = &v35;
    var v36: US0 = undefined; _ = &v36;
    var v37: *UH3 = undefined; _ = &v37;
    var v38: *UH3 = undefined; _ = &v38;
    var v39: *UH3 = undefined; _ = &v39;
    var v40: bool = undefined; _ = &v40;
    var v41: US0 = undefined; _ = &v41;
    var v42: US0 = undefined; _ = &v42;
    var v43: *UH3 = undefined; _ = &v43;
    var v44: *UH3 = undefined; _ = &v44;
    var v45: *UH3 = undefined; _ = &v45;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_0(v1);
                v4 = antimirov_residual_support_7(v3);
                v5 = antimirov_insert_unique_9(v3, v4);
                v6 = normalize_0(v1);
                v7 = antimirov_position_origins_12(v6);
                v8 = normalize_0(v1);
                v9 = antimirov_residual_support_7(v8);
                v10 = normalize_0(v8);
                v11 = antimirov_residual_support_7(v10);
                v12 = antimirov_insert_unique_9(v10, v11);
                v13 = regex_list_distinct_15(v12);
                if (v13) {
                    v15 = antimirov_subset_16(v9, v7);
                } else {
                    v15 = false;
                }
                if (v15) {
                    v17 = antimirov_subset_16(v7, v9);
                } else {
                    v17 = false;
                }
                if (v17) {
                    v18 = UH1_RegexListCons(v8, v7);
                    v20 = antimirov_subset_16(v12, v18);
                } else {
                    v20 = false;
                }
                if (v20) {
                    v21 = regex_position_count_17(v8);
                    v23 = regex_list_exact_budget_19(v7, v21);
                } else {
                    v23 = false;
                }
                if (v23) {
                    v24 = UH1_RegexListCons(v8, v7);
                    v25 = regex_position_count_17(v8);
                    v26 = UH2_StateBudgetSucc(v25);
                    v28 = regex_list_exact_budget_19(v24, v26);
                } else {
                    v28 = false;
                }
                if (v28) {
                    v29 = US0_BitZero();
                    v30 = US0_BitOne();
                    v31 = UH3_SymbolListNil();
                    v32 = UH3_SymbolListCons(v30, v31);
                    v33 = UH3_SymbolListCons(v29, v32);
                    v34 = antimirov_partial_derivatives_origin_supported_20(v1, v33);
                    if (v34) {
                        v35 = US0_BitZero();
                        v36 = US0_BitOne();
                        v37 = UH3_SymbolListNil();
                        v38 = UH3_SymbolListCons(v36, v37);
                        v39 = UH3_SymbolListCons(v35, v38);
                        v40 = antimirov_support_closed_23(v1, v5, v39);
                        if (v40) {
                            v41 = US0_BitZero();
                            v42 = US0_BitOne();
                            v43 = UH3_SymbolListNil();
                            v44 = UH3_SymbolListCons(v42, v43);
                            v45 = UH3_SymbolListCons(v41, v44);
                            v49 = antimirov_reconstruction_symbols_25(v1, v45);
                        } else {
                            v49 = false;
                        }
                    } else {
                        v49 = false;
                    }
                } else {
                    v49 = false;
                }
                if (v49) {
                    v0 = v2;
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
fn antimirov_corpus_certificate_68(p0: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH4 = undefined; _ = &v10;
    var v11: *UH5 = undefined; _ = &v11;
    var v12: *UH5 = undefined; _ = &v12;
    var v13: bool = undefined; _ = &v13;
    var v15: bool = undefined; _ = &v15;
    var v17: bool = undefined; _ = &v17;
    var v20: bool = undefined; _ = &v20;
    var v18: *UH5 = undefined; _ = &v18;
    var v23: bool = undefined; _ = &v23;
    var v21: *UH2 = undefined; _ = &v21;
    var v28: bool = undefined; _ = &v28;
    var v24: *UH5 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v55: bool = undefined; _ = &v55;
    var v29: US3 = undefined; _ = &v29;
    var v30: US3 = undefined; _ = &v30;
    var v31: US3 = undefined; _ = &v31;
    var v32: *UH6 = undefined; _ = &v32;
    var v33: *UH6 = undefined; _ = &v33;
    var v34: *UH6 = undefined; _ = &v34;
    var v35: *UH6 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v37: US3 = undefined; _ = &v37;
    var v38: US3 = undefined; _ = &v38;
    var v39: US3 = undefined; _ = &v39;
    var v40: *UH6 = undefined; _ = &v40;
    var v41: *UH6 = undefined; _ = &v41;
    var v42: *UH6 = undefined; _ = &v42;
    var v43: *UH6 = undefined; _ = &v43;
    var v44: bool = undefined; _ = &v44;
    var v45: US3 = undefined; _ = &v45;
    var v46: US3 = undefined; _ = &v46;
    var v47: US3 = undefined; _ = &v47;
    var v48: *UH6 = undefined; _ = &v48;
    var v49: *UH6 = undefined; _ = &v49;
    var v50: *UH6 = undefined; _ = &v50;
    var v51: *UH6 = undefined; _ = &v51;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_29(v1);
                v4 = antimirov_residual_support_36(v3);
                v5 = antimirov_insert_unique_38(v3, v4);
                v6 = normalize_29(v1);
                v7 = antimirov_position_origins_41(v6);
                v8 = normalize_29(v1);
                v9 = antimirov_residual_support_36(v8);
                v10 = normalize_29(v8);
                v11 = antimirov_residual_support_36(v10);
                v12 = antimirov_insert_unique_38(v10, v11);
                v13 = regex_list_distinct_44(v12);
                if (v13) {
                    v15 = antimirov_subset_45(v9, v7);
                } else {
                    v15 = false;
                }
                if (v15) {
                    v17 = antimirov_subset_45(v7, v9);
                } else {
                    v17 = false;
                }
                if (v17) {
                    v18 = UH5_RegexListCons(v8, v7);
                    v20 = antimirov_subset_45(v12, v18);
                } else {
                    v20 = false;
                }
                if (v20) {
                    v21 = regex_position_count_46(v8);
                    v23 = regex_list_exact_budget_47(v7, v21);
                } else {
                    v23 = false;
                }
                if (v23) {
                    v24 = UH5_RegexListCons(v8, v7);
                    v25 = regex_position_count_46(v8);
                    v26 = UH2_StateBudgetSucc(v25);
                    v28 = regex_list_exact_budget_47(v24, v26);
                } else {
                    v28 = false;
                }
                if (v28) {
                    v29 = US3_TriA();
                    v30 = US3_TriB();
                    v31 = US3_TriC();
                    v32 = UH6_SymbolListNil();
                    v33 = UH6_SymbolListCons(v31, v32);
                    v34 = UH6_SymbolListCons(v30, v33);
                    v35 = UH6_SymbolListCons(v29, v34);
                    v36 = antimirov_partial_derivatives_origin_supported_48(v1, v35);
                    if (v36) {
                        v37 = US3_TriA();
                        v38 = US3_TriB();
                        v39 = US3_TriC();
                        v40 = UH6_SymbolListNil();
                        v41 = UH6_SymbolListCons(v39, v40);
                        v42 = UH6_SymbolListCons(v38, v41);
                        v43 = UH6_SymbolListCons(v37, v42);
                        v44 = antimirov_support_closed_51(v1, v5, v43);
                        if (v44) {
                            v45 = US3_TriA();
                            v46 = US3_TriB();
                            v47 = US3_TriC();
                            v48 = UH6_SymbolListNil();
                            v49 = UH6_SymbolListCons(v47, v48);
                            v50 = UH6_SymbolListCons(v46, v49);
                            v51 = UH6_SymbolListCons(v45, v50);
                            v55 = antimirov_reconstruction_symbols_53(v1, v51);
                        } else {
                            v55 = false;
                        }
                    } else {
                        v55 = false;
                    }
                } else {
                    v55 = false;
                }
                if (v55) {
                    v0 = v2;
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
fn reference_derivative_69(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH0 = undefined; _ = &v19;
    var v20: *UH0 = undefined; _ = &v20;
    var v21: *UH0 = undefined; _ = &v21;
    var v22: *UH0 = undefined; _ = &v22;
    var v24: *UH0 = undefined; _ = &v24;
    var v25: *UH0 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
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
            v21 = reference_derivative_69(v19, v1);
            v22 = reference_derivative_69(v20, v1);
            return UH0_RegexAlt(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_22(v24);
            switch (v26.tag) {
                1 => {
                    v31 = reference_derivative_69(v24, v1);
                    return UH0_RegexCat(v31, v25);
                },
                0 => {
                    v27 = reference_derivative_69(v24, v1);
                    v28 = reference_derivative_69(v25, v1);
                    v29 = UH0_RegexCat(v27, v25);
                    return UH0_RegexAlt(v29, v28);
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
            v36 = reference_derivative_69(v35, v1);
            v37 = UH0_RegexStar(v35);
            return UH0_RegexCat(v36, v37);
        },
        else => unreachable,
    }
}
fn UH7_InputEmpty() *UH7 {
    const shared = struct {
        var value: UH7 = UH7{ .tag = 0 };
    };
    return &shared.value;
}
fn UH7_InputCons(a0: US0, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn contains_71(p0: US0, p1: *UH3) bool {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v13: US1 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                switch (v0.tag) {
                    1 => {
                        switch (v2.tag) {
                            1 => {
                                v13 = US1_SymbolSame();
                            },
                            0 => {
                                v13 = US1_SymbolGreater();
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        switch (v2.tag) {
                            1 => {
                                v13 = US1_SymbolLess();
                            },
                            0 => {
                                v13 = US1_SymbolSame();
                            },
                            else => unreachable,
                        }
                    },
                    else => unreachable,
                }
                switch (v13.tag) {
                    1 => {
                        v14 = true;
                    },
                    else => {
                        v14 = false;
                    },
                }
                if (v14) {
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
fn input_symbols_covered_70(p0: *UH7, p1: *UH3) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = contains_71(v2, v1);
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
fn US5_DerivativeVerified(a0: *UH0, a1: US0, a2: *UH0) US5 {
    return US5{ .tag = 0, .c0_0 = a0, .c0_1 = a1, .c0_2 = a2 };
}
fn US4_DerivativePipelineRejected() US4 {
    return US4{ .tag = 0 };
}
fn US4_DerivativePipelineVerified(a0: US5) US4 {
    return US4{ .tag = 1, .c1_0 = a0 };
}
fn reference_derivative_72(p0: *UH4, p1: US3) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH4 = undefined; _ = &v25;
    var v26: *UH4 = undefined; _ = &v26;
    var v27: *UH4 = undefined; _ = &v27;
    var v28: *UH4 = undefined; _ = &v28;
    var v30: *UH4 = undefined; _ = &v30;
    var v31: *UH4 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH4 = undefined; _ = &v37;
    var v33: *UH4 = undefined; _ = &v33;
    var v34: *UH4 = undefined; _ = &v34;
    var v35: *UH4 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH4 = undefined; _ = &v41;
    var v42: *UH4 = undefined; _ = &v42;
    var v43: *UH4 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = reference_derivative_72(v25, v1);
            v28 = reference_derivative_72(v26, v1);
            return UH4_RegexAlt(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_50(v30);
            switch (v32.tag) {
                1 => {
                    v37 = reference_derivative_72(v30, v1);
                    return UH4_RegexCat(v37, v31);
                },
                0 => {
                    v33 = reference_derivative_72(v30, v1);
                    v34 = reference_derivative_72(v31, v1);
                    v35 = UH4_RegexCat(v33, v31);
                    return UH4_RegexAlt(v35, v34);
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
                return UH4_RegexEpsilon();
            } else {
                return UH4_RegexEmpty();
            }
        },
        0 => {
            return UH4_RegexEmpty();
        },
        1 => {
            return UH4_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = reference_derivative_72(v41, v1);
            v43 = UH4_RegexStar(v41);
            return UH4_RegexCat(v42, v43);
        },
        else => unreachable,
    }
}
fn UH8_InputEmpty() *UH8 {
    const shared = struct {
        var value: UH8 = UH8{ .tag = 0 };
    };
    return &shared.value;
}
fn UH8_InputCons(a0: US3, a1: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn contains_74(p0: US3, p1: *UH6) bool {
    var v0: US3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v19: US1 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                switch (v0.tag) {
                    0 => {
                        switch (v2.tag) {
                            0 => {
                                v19 = US1_SymbolSame();
                            },
                            else => {
                                v19 = US1_SymbolLess();
                            },
                        }
                    },
                    else => {
                        switch (v2.tag) {
                            0 => {
                                v19 = US1_SymbolGreater();
                            },
                            else => {
                                switch (v0.tag) {
                                    1 => {
                                        switch (v2.tag) {
                                            1 => {
                                                v19 = US1_SymbolSame();
                                            },
                                            2 => {
                                                v19 = US1_SymbolLess();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    2 => {
                                        switch (v2.tag) {
                                            1 => {
                                                v19 = US1_SymbolGreater();
                                            },
                                            2 => {
                                                v19 = US1_SymbolSame();
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
                switch (v19.tag) {
                    1 => {
                        v20 = true;
                    },
                    else => {
                        v20 = false;
                    },
                }
                if (v20) {
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
fn input_symbols_covered_73(p0: *UH8, p1: *UH6) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US3 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = contains_74(v2, v1);
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
fn US7_DerivativeVerified(a0: *UH4, a1: US3, a2: *UH4) US7 {
    return US7{ .tag = 0, .c0_0 = a0, .c0_1 = a1, .c0_2 = a2 };
}
fn US6_DerivativePipelineRejected() US6 {
    return US6{ .tag = 0 };
}
fn US6_DerivativePipelineVerified(a0: US7) US6 {
    return US6{ .tag = 1, .c1_0 = a0 };
}
fn spiralMainValue() []const u8 {
    var v39: bool = undefined; _ = &v39;
    var v41: bool = undefined; _ = &v41;
    var v44: bool = undefined; _ = &v44;
    var v42: *UH1 = undefined; _ = &v42;
    var v47: bool = undefined; _ = &v47;
    var v45: *UH2 = undefined; _ = &v45;
    var v52: bool = undefined; _ = &v52;
    var v48: *UH1 = undefined; _ = &v48;
    var v49: *UH2 = undefined; _ = &v49;
    var v50: *UH2 = undefined; _ = &v50;
    var v100: bool = undefined; _ = &v100;
    var v53: US0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: US0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: *UH0 = undefined; _ = &v57;
    var v58: *UH0 = undefined; _ = &v58;
    var v59: US0 = undefined; _ = &v59;
    var v60: *UH0 = undefined; _ = &v60;
    var v61: *UH0 = undefined; _ = &v61;
    var v62: US0 = undefined; _ = &v62;
    var v63: US0 = undefined; _ = &v63;
    var v64: *UH3 = undefined; _ = &v64;
    var v65: *UH3 = undefined; _ = &v65;
    var v66: *UH3 = undefined; _ = &v66;
    var v67: bool = undefined; _ = &v67;
    var v68: US0 = undefined; _ = &v68;
    var v69: *UH0 = undefined; _ = &v69;
    var v70: US0 = undefined; _ = &v70;
    var v71: *UH0 = undefined; _ = &v71;
    var v72: *UH0 = undefined; _ = &v72;
    var v73: *UH0 = undefined; _ = &v73;
    var v74: US0 = undefined; _ = &v74;
    var v75: *UH0 = undefined; _ = &v75;
    var v76: *UH0 = undefined; _ = &v76;
    var v77: US0 = undefined; _ = &v77;
    var v78: US0 = undefined; _ = &v78;
    var v79: *UH3 = undefined; _ = &v79;
    var v80: *UH3 = undefined; _ = &v80;
    var v81: *UH3 = undefined; _ = &v81;
    var v82: bool = undefined; _ = &v82;
    var v83: US0 = undefined; _ = &v83;
    var v84: *UH0 = undefined; _ = &v84;
    var v85: US0 = undefined; _ = &v85;
    var v86: *UH0 = undefined; _ = &v86;
    var v87: *UH0 = undefined; _ = &v87;
    var v88: *UH0 = undefined; _ = &v88;
    var v89: US0 = undefined; _ = &v89;
    var v90: *UH0 = undefined; _ = &v90;
    var v91: *UH0 = undefined; _ = &v91;
    var v92: US0 = undefined; _ = &v92;
    var v93: US0 = undefined; _ = &v93;
    var v94: *UH3 = undefined; _ = &v94;
    var v95: *UH3 = undefined; _ = &v95;
    var v96: *UH3 = undefined; _ = &v96;
    var v118: bool = undefined; _ = &v118;
    var v112: *UH0 = undefined; _ = &v112;
    var v113: *UH1 = undefined; _ = &v113;
    var v114: *UH2 = undefined; _ = &v114;
    var v115: bool = undefined; _ = &v115;
    var v116: bool = undefined; _ = &v116;
    var v155: bool = undefined; _ = &v155;
    var v120: *UH0 = undefined; _ = &v120;
    var v121: *UH1 = undefined; _ = &v121;
    var v122: *UH0 = undefined; _ = &v122;
    var v123: *UH1 = undefined; _ = &v123;
    var v124: *UH0 = undefined; _ = &v124;
    var v125: *UH1 = undefined; _ = &v125;
    var v126: *UH1 = undefined; _ = &v126;
    var v127: bool = undefined; _ = &v127;
    var v131: bool = undefined; _ = &v131;
    var v128: *UH0 = undefined; _ = &v128;
    var v129: *UH1 = undefined; _ = &v129;
    var v135: bool = undefined; _ = &v135;
    var v132: *UH0 = undefined; _ = &v132;
    var v133: *UH1 = undefined; _ = &v133;
    var v140: bool = undefined; _ = &v140;
    var v136: *UH0 = undefined; _ = &v136;
    var v137: *UH1 = undefined; _ = &v137;
    var v138: *UH1 = undefined; _ = &v138;
    var v145: bool = undefined; _ = &v145;
    var v141: *UH0 = undefined; _ = &v141;
    var v142: *UH1 = undefined; _ = &v142;
    var v143: *UH2 = undefined; _ = &v143;
    var v152: bool = undefined; _ = &v152;
    var v146: *UH0 = undefined; _ = &v146;
    var v147: *UH1 = undefined; _ = &v147;
    var v148: *UH1 = undefined; _ = &v148;
    var v149: *UH2 = undefined; _ = &v149;
    var v150: *UH2 = undefined; _ = &v150;
    var v153: bool = undefined; _ = &v153;
    var v177: bool = undefined; _ = &v177;
    var v179: bool = undefined; _ = &v179;
    var v182: bool = undefined; _ = &v182;
    var v180: *UH5 = undefined; _ = &v180;
    var v185: bool = undefined; _ = &v185;
    var v183: *UH2 = undefined; _ = &v183;
    var v190: bool = undefined; _ = &v190;
    var v186: *UH5 = undefined; _ = &v186;
    var v187: *UH2 = undefined; _ = &v187;
    var v188: *UH2 = undefined; _ = &v188;
    var v226: bool = undefined; _ = &v226;
    var v191: US3 = undefined; _ = &v191;
    var v192: *UH4 = undefined; _ = &v192;
    var v193: *UH4 = undefined; _ = &v193;
    var v194: US3 = undefined; _ = &v194;
    var v195: US3 = undefined; _ = &v195;
    var v196: US3 = undefined; _ = &v196;
    var v197: *UH6 = undefined; _ = &v197;
    var v198: *UH6 = undefined; _ = &v198;
    var v199: *UH6 = undefined; _ = &v199;
    var v200: *UH6 = undefined; _ = &v200;
    var v201: bool = undefined; _ = &v201;
    var v202: US3 = undefined; _ = &v202;
    var v203: *UH4 = undefined; _ = &v203;
    var v204: *UH4 = undefined; _ = &v204;
    var v205: US3 = undefined; _ = &v205;
    var v206: US3 = undefined; _ = &v206;
    var v207: US3 = undefined; _ = &v207;
    var v208: *UH6 = undefined; _ = &v208;
    var v209: *UH6 = undefined; _ = &v209;
    var v210: *UH6 = undefined; _ = &v210;
    var v211: *UH6 = undefined; _ = &v211;
    var v212: bool = undefined; _ = &v212;
    var v213: US3 = undefined; _ = &v213;
    var v214: *UH4 = undefined; _ = &v214;
    var v215: *UH4 = undefined; _ = &v215;
    var v216: US3 = undefined; _ = &v216;
    var v217: US3 = undefined; _ = &v217;
    var v218: US3 = undefined; _ = &v218;
    var v219: *UH6 = undefined; _ = &v219;
    var v220: *UH6 = undefined; _ = &v220;
    var v221: *UH6 = undefined; _ = &v221;
    var v222: *UH6 = undefined; _ = &v222;
    var v266: bool = undefined; _ = &v266;
    var v268: bool = undefined; _ = &v268;
    var v271: bool = undefined; _ = &v271;
    var v269: *UH5 = undefined; _ = &v269;
    var v274: bool = undefined; _ = &v274;
    var v272: *UH2 = undefined; _ = &v272;
    var v279: bool = undefined; _ = &v279;
    var v275: *UH5 = undefined; _ = &v275;
    var v276: *UH2 = undefined; _ = &v276;
    var v277: *UH2 = undefined; _ = &v277;
    var v333: bool = undefined; _ = &v333;
    var v280: US3 = undefined; _ = &v280;
    var v281: *UH4 = undefined; _ = &v281;
    var v282: US3 = undefined; _ = &v282;
    var v283: *UH4 = undefined; _ = &v283;
    var v284: *UH4 = undefined; _ = &v284;
    var v285: *UH4 = undefined; _ = &v285;
    var v286: US3 = undefined; _ = &v286;
    var v287: *UH4 = undefined; _ = &v287;
    var v288: *UH4 = undefined; _ = &v288;
    var v289: US3 = undefined; _ = &v289;
    var v290: US3 = undefined; _ = &v290;
    var v291: US3 = undefined; _ = &v291;
    var v292: *UH6 = undefined; _ = &v292;
    var v293: *UH6 = undefined; _ = &v293;
    var v294: *UH6 = undefined; _ = &v294;
    var v295: *UH6 = undefined; _ = &v295;
    var v296: bool = undefined; _ = &v296;
    var v297: US3 = undefined; _ = &v297;
    var v298: *UH4 = undefined; _ = &v298;
    var v299: US3 = undefined; _ = &v299;
    var v300: *UH4 = undefined; _ = &v300;
    var v301: *UH4 = undefined; _ = &v301;
    var v302: *UH4 = undefined; _ = &v302;
    var v303: US3 = undefined; _ = &v303;
    var v304: *UH4 = undefined; _ = &v304;
    var v305: *UH4 = undefined; _ = &v305;
    var v306: US3 = undefined; _ = &v306;
    var v307: US3 = undefined; _ = &v307;
    var v308: US3 = undefined; _ = &v308;
    var v309: *UH6 = undefined; _ = &v309;
    var v310: *UH6 = undefined; _ = &v310;
    var v311: *UH6 = undefined; _ = &v311;
    var v312: *UH6 = undefined; _ = &v312;
    var v313: bool = undefined; _ = &v313;
    var v314: US3 = undefined; _ = &v314;
    var v315: *UH4 = undefined; _ = &v315;
    var v316: US3 = undefined; _ = &v316;
    var v317: *UH4 = undefined; _ = &v317;
    var v318: *UH4 = undefined; _ = &v318;
    var v319: *UH4 = undefined; _ = &v319;
    var v320: US3 = undefined; _ = &v320;
    var v321: *UH4 = undefined; _ = &v321;
    var v322: *UH4 = undefined; _ = &v322;
    var v323: US3 = undefined; _ = &v323;
    var v324: US3 = undefined; _ = &v324;
    var v325: US3 = undefined; _ = &v325;
    var v326: *UH6 = undefined; _ = &v326;
    var v327: *UH6 = undefined; _ = &v327;
    var v328: *UH6 = undefined; _ = &v328;
    var v329: *UH6 = undefined; _ = &v329;
    var v351: bool = undefined; _ = &v351;
    var v345: *UH4 = undefined; _ = &v345;
    var v346: *UH5 = undefined; _ = &v346;
    var v347: *UH2 = undefined; _ = &v347;
    var v348: bool = undefined; _ = &v348;
    var v349: bool = undefined; _ = &v349;
    var v447: bool = undefined; _ = &v447;
    var v449: bool = undefined; _ = &v449;
    var v452: bool = undefined; _ = &v452;
    var v450: *UH1 = undefined; _ = &v450;
    var v455: bool = undefined; _ = &v455;
    var v453: *UH2 = undefined; _ = &v453;
    var v460: bool = undefined; _ = &v460;
    var v456: *UH1 = undefined; _ = &v456;
    var v457: *UH2 = undefined; _ = &v457;
    var v458: *UH2 = undefined; _ = &v458;
    var v508: bool = undefined; _ = &v508;
    var v461: US0 = undefined; _ = &v461;
    var v462: *UH0 = undefined; _ = &v462;
    var v463: US0 = undefined; _ = &v463;
    var v464: *UH0 = undefined; _ = &v464;
    var v465: *UH0 = undefined; _ = &v465;
    var v466: *UH0 = undefined; _ = &v466;
    var v467: US0 = undefined; _ = &v467;
    var v468: *UH0 = undefined; _ = &v468;
    var v469: *UH0 = undefined; _ = &v469;
    var v470: US0 = undefined; _ = &v470;
    var v471: US0 = undefined; _ = &v471;
    var v472: *UH3 = undefined; _ = &v472;
    var v473: *UH3 = undefined; _ = &v473;
    var v474: *UH3 = undefined; _ = &v474;
    var v475: bool = undefined; _ = &v475;
    var v476: US0 = undefined; _ = &v476;
    var v477: *UH0 = undefined; _ = &v477;
    var v478: US0 = undefined; _ = &v478;
    var v479: *UH0 = undefined; _ = &v479;
    var v480: *UH0 = undefined; _ = &v480;
    var v481: *UH0 = undefined; _ = &v481;
    var v482: US0 = undefined; _ = &v482;
    var v483: *UH0 = undefined; _ = &v483;
    var v484: *UH0 = undefined; _ = &v484;
    var v485: US0 = undefined; _ = &v485;
    var v486: US0 = undefined; _ = &v486;
    var v487: *UH3 = undefined; _ = &v487;
    var v488: *UH3 = undefined; _ = &v488;
    var v489: *UH3 = undefined; _ = &v489;
    var v490: bool = undefined; _ = &v490;
    var v491: US0 = undefined; _ = &v491;
    var v492: *UH0 = undefined; _ = &v492;
    var v493: US0 = undefined; _ = &v493;
    var v494: *UH0 = undefined; _ = &v494;
    var v495: *UH0 = undefined; _ = &v495;
    var v496: *UH0 = undefined; _ = &v496;
    var v497: US0 = undefined; _ = &v497;
    var v498: *UH0 = undefined; _ = &v498;
    var v499: *UH0 = undefined; _ = &v499;
    var v500: US0 = undefined; _ = &v500;
    var v501: US0 = undefined; _ = &v501;
    var v502: *UH3 = undefined; _ = &v502;
    var v503: *UH3 = undefined; _ = &v503;
    var v504: *UH3 = undefined; _ = &v504;
    var v616: bool = undefined; _ = &v616;
    var v509: US3 = undefined; _ = &v509;
    var v510: *UH4 = undefined; _ = &v510;
    var v511: US3 = undefined; _ = &v511;
    var v512: *UH4 = undefined; _ = &v512;
    var v513: *UH4 = undefined; _ = &v513;
    var v514: *UH4 = undefined; _ = &v514;
    var v515: US3 = undefined; _ = &v515;
    var v516: *UH4 = undefined; _ = &v516;
    var v517: *UH4 = undefined; _ = &v517;
    var v518: *UH4 = undefined; _ = &v518;
    var v519: *UH5 = undefined; _ = &v519;
    var v520: *UH5 = undefined; _ = &v520;
    var v521: US3 = undefined; _ = &v521;
    var v522: *UH4 = undefined; _ = &v522;
    var v523: US3 = undefined; _ = &v523;
    var v524: *UH4 = undefined; _ = &v524;
    var v525: *UH4 = undefined; _ = &v525;
    var v526: *UH4 = undefined; _ = &v526;
    var v527: US3 = undefined; _ = &v527;
    var v528: *UH4 = undefined; _ = &v528;
    var v529: *UH4 = undefined; _ = &v529;
    var v530: *UH4 = undefined; _ = &v530;
    var v531: *UH5 = undefined; _ = &v531;
    var v532: US3 = undefined; _ = &v532;
    var v533: *UH4 = undefined; _ = &v533;
    var v534: US3 = undefined; _ = &v534;
    var v535: *UH4 = undefined; _ = &v535;
    var v536: *UH4 = undefined; _ = &v536;
    var v537: *UH4 = undefined; _ = &v537;
    var v538: US3 = undefined; _ = &v538;
    var v539: *UH4 = undefined; _ = &v539;
    var v540: *UH4 = undefined; _ = &v540;
    var v541: *UH4 = undefined; _ = &v541;
    var v542: *UH5 = undefined; _ = &v542;
    var v543: *UH4 = undefined; _ = &v543;
    var v544: *UH5 = undefined; _ = &v544;
    var v545: *UH5 = undefined; _ = &v545;
    var v546: bool = undefined; _ = &v546;
    var v548: bool = undefined; _ = &v548;
    var v550: bool = undefined; _ = &v550;
    var v553: bool = undefined; _ = &v553;
    var v551: *UH5 = undefined; _ = &v551;
    var v556: bool = undefined; _ = &v556;
    var v554: *UH2 = undefined; _ = &v554;
    var v561: bool = undefined; _ = &v561;
    var v557: *UH5 = undefined; _ = &v557;
    var v558: *UH2 = undefined; _ = &v558;
    var v559: *UH2 = undefined; _ = &v559;
    var v562: US3 = undefined; _ = &v562;
    var v563: *UH4 = undefined; _ = &v563;
    var v564: US3 = undefined; _ = &v564;
    var v565: *UH4 = undefined; _ = &v565;
    var v566: *UH4 = undefined; _ = &v566;
    var v567: *UH4 = undefined; _ = &v567;
    var v568: US3 = undefined; _ = &v568;
    var v569: *UH4 = undefined; _ = &v569;
    var v570: *UH4 = undefined; _ = &v570;
    var v571: US3 = undefined; _ = &v571;
    var v572: US3 = undefined; _ = &v572;
    var v573: US3 = undefined; _ = &v573;
    var v574: *UH6 = undefined; _ = &v574;
    var v575: *UH6 = undefined; _ = &v575;
    var v576: *UH6 = undefined; _ = &v576;
    var v577: *UH6 = undefined; _ = &v577;
    var v578: bool = undefined; _ = &v578;
    var v579: US3 = undefined; _ = &v579;
    var v580: *UH4 = undefined; _ = &v580;
    var v581: US3 = undefined; _ = &v581;
    var v582: *UH4 = undefined; _ = &v582;
    var v583: *UH4 = undefined; _ = &v583;
    var v584: *UH4 = undefined; _ = &v584;
    var v585: US3 = undefined; _ = &v585;
    var v586: *UH4 = undefined; _ = &v586;
    var v587: *UH4 = undefined; _ = &v587;
    var v588: US3 = undefined; _ = &v588;
    var v589: US3 = undefined; _ = &v589;
    var v590: US3 = undefined; _ = &v590;
    var v591: *UH6 = undefined; _ = &v591;
    var v592: *UH6 = undefined; _ = &v592;
    var v593: *UH6 = undefined; _ = &v593;
    var v594: *UH6 = undefined; _ = &v594;
    var v595: bool = undefined; _ = &v595;
    var v596: US3 = undefined; _ = &v596;
    var v597: *UH4 = undefined; _ = &v597;
    var v598: US3 = undefined; _ = &v598;
    var v599: *UH4 = undefined; _ = &v599;
    var v600: *UH4 = undefined; _ = &v600;
    var v601: *UH4 = undefined; _ = &v601;
    var v602: US3 = undefined; _ = &v602;
    var v603: *UH4 = undefined; _ = &v603;
    var v604: *UH4 = undefined; _ = &v604;
    var v605: US3 = undefined; _ = &v605;
    var v606: US3 = undefined; _ = &v606;
    var v607: US3 = undefined; _ = &v607;
    var v608: *UH6 = undefined; _ = &v608;
    var v609: *UH6 = undefined; _ = &v609;
    var v610: *UH6 = undefined; _ = &v610;
    var v611: *UH6 = undefined; _ = &v611;
    var v662: bool = undefined; _ = &v662;
    var v639: *UH0 = undefined; _ = &v639;
    var v640: *UH1 = undefined; _ = &v640;
    var v641: *UH0 = undefined; _ = &v641;
    var v642: *UH1 = undefined; _ = &v642;
    var v643: *UH0 = undefined; _ = &v643;
    var v644: *UH1 = undefined; _ = &v644;
    var v645: *UH1 = undefined; _ = &v645;
    var v646: bool = undefined; _ = &v646;
    var v648: bool = undefined; _ = &v648;
    var v650: bool = undefined; _ = &v650;
    var v653: bool = undefined; _ = &v653;
    var v651: *UH1 = undefined; _ = &v651;
    var v656: bool = undefined; _ = &v656;
    var v654: *UH2 = undefined; _ = &v654;
    var v657: *UH1 = undefined; _ = &v657;
    var v658: *UH2 = undefined; _ = &v658;
    var v659: *UH2 = undefined; _ = &v659;
    var v668: bool = undefined; _ = &v668;
    var v663: *UH0 = undefined; _ = &v663;
    var v664: US0 = undefined; _ = &v664;
    var v665: *UH1 = undefined; _ = &v665;
    var v666: *UH1 = undefined; _ = &v666;
    var v670: bool = undefined; _ = &v670;
    var v672: bool = undefined; _ = &v672;
    var v677: US4 = undefined; _ = &v677;
    var v673: US0 = undefined; _ = &v673;
    var v674: US5 = undefined; _ = &v674;
    var v680: bool = undefined; _ = &v680;
    var v678: US5 = undefined; _ = &v678;
    var v747: bool = undefined; _ = &v747;
    var v681: US3 = undefined; _ = &v681;
    var v682: *UH4 = undefined; _ = &v682;
    var v683: *UH4 = undefined; _ = &v683;
    var v684: *UH4 = undefined; _ = &v684;
    var v685: US3 = undefined; _ = &v685;
    var v686: *UH4 = undefined; _ = &v686;
    var v687: US3 = undefined; _ = &v687;
    var v688: *UH4 = undefined; _ = &v688;
    var v689: *UH4 = undefined; _ = &v689;
    var v690: US3 = undefined; _ = &v690;
    var v691: *UH5 = undefined; _ = &v691;
    var v692: *UH4 = undefined; _ = &v692;
    var v693: *UH4 = undefined; _ = &v693;
    var v694: US3 = undefined; _ = &v694;
    var v695: *UH8 = undefined; _ = &v695;
    var v696: *UH8 = undefined; _ = &v696;
    var v697: US3 = undefined; _ = &v697;
    var v698: US3 = undefined; _ = &v698;
    var v699: US3 = undefined; _ = &v699;
    var v700: *UH6 = undefined; _ = &v700;
    var v701: *UH6 = undefined; _ = &v701;
    var v702: *UH6 = undefined; _ = &v702;
    var v703: *UH6 = undefined; _ = &v703;
    var v704: bool = undefined; _ = &v704;
    var v728: bool = undefined; _ = &v728;
    var v705: *UH4 = undefined; _ = &v705;
    var v706: *UH5 = undefined; _ = &v706;
    var v707: *UH4 = undefined; _ = &v707;
    var v708: *UH5 = undefined; _ = &v708;
    var v709: *UH4 = undefined; _ = &v709;
    var v710: *UH5 = undefined; _ = &v710;
    var v711: *UH5 = undefined; _ = &v711;
    var v712: bool = undefined; _ = &v712;
    var v714: bool = undefined; _ = &v714;
    var v716: bool = undefined; _ = &v716;
    var v719: bool = undefined; _ = &v719;
    var v717: *UH5 = undefined; _ = &v717;
    var v722: bool = undefined; _ = &v722;
    var v720: *UH2 = undefined; _ = &v720;
    var v723: *UH5 = undefined; _ = &v723;
    var v724: *UH2 = undefined; _ = &v724;
    var v725: *UH2 = undefined; _ = &v725;
    var v734: bool = undefined; _ = &v734;
    var v729: *UH4 = undefined; _ = &v729;
    var v730: US3 = undefined; _ = &v730;
    var v731: *UH5 = undefined; _ = &v731;
    var v732: *UH5 = undefined; _ = &v732;
    var v736: bool = undefined; _ = &v736;
    var v738: bool = undefined; _ = &v738;
    var v743: US6 = undefined; _ = &v743;
    var v739: US3 = undefined; _ = &v739;
    var v740: US7 = undefined; _ = &v740;
    var v746: bool = undefined; _ = &v746;
    var v744: US7 = undefined; _ = &v744;
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
    const v10: *UH1 = antimirov_residual_support_7(v9);
    const v11: *UH1 = antimirov_insert_unique_9(v9, v10);
    const v12: US0 = US0_BitZero();
    const v13: *UH0 = UH0_RegexChar(v12);
    const v14: US0 = US0_BitOne();
    const v15: *UH0 = UH0_RegexChar(v14);
    const v16: *UH0 = UH0_RegexAlt(v13, v15);
    const v17: *UH0 = UH0_RegexStar(v16);
    const v18: US0 = US0_BitZero();
    const v19: *UH0 = UH0_RegexChar(v18);
    const v20: *UH0 = UH0_RegexCat(v17, v19);
    const v21: *UH0 = normalize_0(v20);
    const v22: *UH1 = antimirov_position_origins_12(v21);
    const v23: US0 = US0_BitZero();
    const v24: *UH0 = UH0_RegexChar(v23);
    const v25: US0 = US0_BitOne();
    const v26: *UH0 = UH0_RegexChar(v25);
    const v27: *UH0 = UH0_RegexAlt(v24, v26);
    const v28: *UH0 = UH0_RegexStar(v27);
    const v29: US0 = US0_BitZero();
    const v30: *UH0 = UH0_RegexChar(v29);
    const v31: *UH0 = UH0_RegexCat(v28, v30);
    const v32: *UH0 = normalize_0(v31);
    const v33: *UH1 = antimirov_residual_support_7(v32);
    const v34: *UH0 = normalize_0(v32);
    const v35: *UH1 = antimirov_residual_support_7(v34);
    const v36: *UH1 = antimirov_insert_unique_9(v34, v35);
    const v37: bool = regex_list_distinct_15(v36);
    if (v37) {
        v39 = antimirov_subset_16(v33, v22);
    } else {
        v39 = false;
    }
    if (v39) {
        v41 = antimirov_subset_16(v22, v33);
    } else {
        v41 = false;
    }
    if (v41) {
        v42 = UH1_RegexListCons(v32, v22);
        v44 = antimirov_subset_16(v36, v42);
    } else {
        v44 = false;
    }
    if (v44) {
        v45 = regex_position_count_17(v32);
        v47 = regex_list_exact_budget_19(v22, v45);
    } else {
        v47 = false;
    }
    if (v47) {
        v48 = UH1_RegexListCons(v32, v22);
        v49 = regex_position_count_17(v32);
        v50 = UH2_StateBudgetSucc(v49);
        v52 = regex_list_exact_budget_19(v48, v50);
    } else {
        v52 = false;
    }
    if (v52) {
        v53 = US0_BitZero();
        v54 = UH0_RegexChar(v53);
        v55 = US0_BitOne();
        v56 = UH0_RegexChar(v55);
        v57 = UH0_RegexAlt(v54, v56);
        v58 = UH0_RegexStar(v57);
        v59 = US0_BitZero();
        v60 = UH0_RegexChar(v59);
        v61 = UH0_RegexCat(v58, v60);
        v62 = US0_BitZero();
        v63 = US0_BitOne();
        v64 = UH3_SymbolListNil();
        v65 = UH3_SymbolListCons(v63, v64);
        v66 = UH3_SymbolListCons(v62, v65);
        v67 = antimirov_partial_derivatives_origin_supported_20(v61, v66);
        if (v67) {
            v68 = US0_BitZero();
            v69 = UH0_RegexChar(v68);
            v70 = US0_BitOne();
            v71 = UH0_RegexChar(v70);
            v72 = UH0_RegexAlt(v69, v71);
            v73 = UH0_RegexStar(v72);
            v74 = US0_BitZero();
            v75 = UH0_RegexChar(v74);
            v76 = UH0_RegexCat(v73, v75);
            v77 = US0_BitZero();
            v78 = US0_BitOne();
            v79 = UH3_SymbolListNil();
            v80 = UH3_SymbolListCons(v78, v79);
            v81 = UH3_SymbolListCons(v77, v80);
            v82 = antimirov_support_closed_23(v76, v11, v81);
            if (v82) {
                v83 = US0_BitZero();
                v84 = UH0_RegexChar(v83);
                v85 = US0_BitOne();
                v86 = UH0_RegexChar(v85);
                v87 = UH0_RegexAlt(v84, v86);
                v88 = UH0_RegexStar(v87);
                v89 = US0_BitZero();
                v90 = UH0_RegexChar(v89);
                v91 = UH0_RegexCat(v88, v90);
                v92 = US0_BitZero();
                v93 = US0_BitOne();
                v94 = UH3_SymbolListNil();
                v95 = UH3_SymbolListCons(v93, v94);
                v96 = UH3_SymbolListCons(v92, v95);
                v100 = antimirov_reconstruction_symbols_25(v91, v96);
            } else {
                v100 = false;
            }
        } else {
            v100 = false;
        }
    } else {
        v100 = false;
    }
    if (v100) {
    } else {
        if (spiral_true) spiralFail("Brzozowski state must reconstruct from its Antimirov partial-derivative subset");
    }
    const v101: US0 = US0_BitZero();
    const v102: *UH0 = UH0_RegexChar(v101);
    const v103: US0 = US0_BitOne();
    const v104: *UH0 = UH0_RegexChar(v103);
    const v105: *UH0 = UH0_RegexAlt(v102, v104);
    const v106: *UH0 = UH0_RegexStar(v105);
    const v107: US0 = US0_BitZero();
    const v108: *UH0 = UH0_RegexChar(v107);
    const v109: *UH0 = UH0_RegexCat(v106, v108);
    const v110: *UH0 = normalize_0(v109);
    const v111: *UH1 = antimirov_position_origins_12(v110);
    switch (v111.tag) {
        1 => {
            v112 = v111.c1_0;
            v113 = v111.c1_1;
            v114 = regex_position_count_17(v110);
            v115 = regex_list_exact_budget_19(v113, v114);
            v116 = v115 == false;
            v118 = v116;
        },
        0 => {
            v118 = false;
        },
        else => unreachable,
    }
    if (v118) {
    } else {
        if (spiral_true) spiralFail("removing one concrete bit origin must violate the exact position count");
    }
    const v119: *UH1 = antimirov_position_origins_12(v110);
    switch (v119.tag) {
        1 => {
            v120 = v119.c1_0;
            v121 = v119.c1_1;
            v122 = normalize_0(v110);
            v123 = antimirov_residual_support_7(v122);
            v124 = normalize_0(v122);
            v125 = antimirov_residual_support_7(v124);
            v126 = antimirov_insert_unique_9(v124, v125);
            v127 = regex_list_distinct_15(v126);
            if (v127) {
                v128 = UH0_RegexEmpty();
                v129 = UH1_RegexListCons(v128, v121);
                v131 = antimirov_subset_16(v123, v129);
            } else {
                v131 = false;
            }
            if (v131) {
                v132 = UH0_RegexEmpty();
                v133 = UH1_RegexListCons(v132, v121);
                v135 = antimirov_subset_16(v133, v123);
            } else {
                v135 = false;
            }
            if (v135) {
                v136 = UH0_RegexEmpty();
                v137 = UH1_RegexListCons(v136, v121);
                v138 = UH1_RegexListCons(v122, v137);
                v140 = antimirov_subset_16(v126, v138);
            } else {
                v140 = false;
            }
            if (v140) {
                v141 = UH0_RegexEmpty();
                v142 = UH1_RegexListCons(v141, v121);
                v143 = regex_position_count_17(v122);
                v145 = regex_list_exact_budget_19(v142, v143);
            } else {
                v145 = false;
            }
            if (v145) {
                v146 = UH0_RegexEmpty();
                v147 = UH1_RegexListCons(v146, v121);
                v148 = UH1_RegexListCons(v122, v147);
                v149 = regex_position_count_17(v122);
                v150 = UH2_StateBudgetSucc(v149);
                v152 = regex_list_exact_budget_19(v148, v150);
            } else {
                v152 = false;
            }
            v153 = v152 == false;
            v155 = v153;
        },
        0 => {
            v155 = false;
        },
        else => unreachable,
    }
    if (v155) {
    } else {
        if (spiral_true) spiralFail("a same-cardinality forged origin set must fail semantic origin validation");
    }
    const v156: US3 = US3_TriA();
    const v157: *UH4 = UH4_RegexChar(v156);
    const v158: *UH4 = UH4_RegexStar(v157);
    const v159: *UH4 = normalize_29(v158);
    const v160: *UH5 = antimirov_residual_support_36(v159);
    const v161: *UH5 = antimirov_insert_unique_38(v159, v160);
    const v162: US3 = US3_TriA();
    const v163: *UH4 = UH4_RegexChar(v162);
    const v164: *UH4 = UH4_RegexStar(v163);
    const v165: *UH4 = normalize_29(v164);
    const v166: *UH5 = antimirov_position_origins_41(v165);
    const v167: US3 = US3_TriA();
    const v168: *UH4 = UH4_RegexChar(v167);
    const v169: *UH4 = UH4_RegexStar(v168);
    const v170: *UH4 = normalize_29(v169);
    const v171: *UH5 = antimirov_residual_support_36(v170);
    const v172: *UH4 = normalize_29(v170);
    const v173: *UH5 = antimirov_residual_support_36(v172);
    const v174: *UH5 = antimirov_insert_unique_38(v172, v173);
    const v175: bool = regex_list_distinct_44(v174);
    if (v175) {
        v177 = antimirov_subset_45(v171, v166);
    } else {
        v177 = false;
    }
    if (v177) {
        v179 = antimirov_subset_45(v166, v171);
    } else {
        v179 = false;
    }
    if (v179) {
        v180 = UH5_RegexListCons(v170, v166);
        v182 = antimirov_subset_45(v174, v180);
    } else {
        v182 = false;
    }
    if (v182) {
        v183 = regex_position_count_46(v170);
        v185 = regex_list_exact_budget_47(v166, v183);
    } else {
        v185 = false;
    }
    if (v185) {
        v186 = UH5_RegexListCons(v170, v166);
        v187 = regex_position_count_46(v170);
        v188 = UH2_StateBudgetSucc(v187);
        v190 = regex_list_exact_budget_47(v186, v188);
    } else {
        v190 = false;
    }
    if (v190) {
        v191 = US3_TriA();
        v192 = UH4_RegexChar(v191);
        v193 = UH4_RegexStar(v192);
        v194 = US3_TriA();
        v195 = US3_TriB();
        v196 = US3_TriC();
        v197 = UH6_SymbolListNil();
        v198 = UH6_SymbolListCons(v196, v197);
        v199 = UH6_SymbolListCons(v195, v198);
        v200 = UH6_SymbolListCons(v194, v199);
        v201 = antimirov_partial_derivatives_origin_supported_48(v193, v200);
        if (v201) {
            v202 = US3_TriA();
            v203 = UH4_RegexChar(v202);
            v204 = UH4_RegexStar(v203);
            v205 = US3_TriA();
            v206 = US3_TriB();
            v207 = US3_TriC();
            v208 = UH6_SymbolListNil();
            v209 = UH6_SymbolListCons(v207, v208);
            v210 = UH6_SymbolListCons(v206, v209);
            v211 = UH6_SymbolListCons(v205, v210);
            v212 = antimirov_support_closed_51(v204, v161, v211);
            if (v212) {
                v213 = US3_TriA();
                v214 = UH4_RegexChar(v213);
                v215 = UH4_RegexStar(v214);
                v216 = US3_TriA();
                v217 = US3_TriB();
                v218 = US3_TriC();
                v219 = UH6_SymbolListNil();
                v220 = UH6_SymbolListCons(v218, v219);
                v221 = UH6_SymbolListCons(v217, v220);
                v222 = UH6_SymbolListCons(v216, v221);
                v226 = antimirov_reconstruction_symbols_53(v215, v222);
            } else {
                v226 = false;
            }
        } else {
            v226 = false;
        }
    } else {
        v226 = false;
    }
    if (v226) {
    } else {
        if (spiral_true) spiralFail("ternary star partial-derivative support must remain bounded and closed");
    }
    const v227: US3 = US3_TriA();
    const v228: *UH4 = UH4_RegexChar(v227);
    const v229: US3 = US3_TriB();
    const v230: *UH4 = UH4_RegexChar(v229);
    const v231: *UH4 = UH4_RegexAlt(v228, v230);
    const v232: *UH4 = UH4_RegexStar(v231);
    const v233: US3 = US3_TriC();
    const v234: *UH4 = UH4_RegexChar(v233);
    const v235: *UH4 = UH4_RegexCat(v232, v234);
    const v236: *UH4 = normalize_29(v235);
    const v237: *UH5 = antimirov_residual_support_36(v236);
    const v238: *UH5 = antimirov_insert_unique_38(v236, v237);
    const v239: US3 = US3_TriA();
    const v240: *UH4 = UH4_RegexChar(v239);
    const v241: US3 = US3_TriB();
    const v242: *UH4 = UH4_RegexChar(v241);
    const v243: *UH4 = UH4_RegexAlt(v240, v242);
    const v244: *UH4 = UH4_RegexStar(v243);
    const v245: US3 = US3_TriC();
    const v246: *UH4 = UH4_RegexChar(v245);
    const v247: *UH4 = UH4_RegexCat(v244, v246);
    const v248: *UH4 = normalize_29(v247);
    const v249: *UH5 = antimirov_position_origins_41(v248);
    const v250: US3 = US3_TriA();
    const v251: *UH4 = UH4_RegexChar(v250);
    const v252: US3 = US3_TriB();
    const v253: *UH4 = UH4_RegexChar(v252);
    const v254: *UH4 = UH4_RegexAlt(v251, v253);
    const v255: *UH4 = UH4_RegexStar(v254);
    const v256: US3 = US3_TriC();
    const v257: *UH4 = UH4_RegexChar(v256);
    const v258: *UH4 = UH4_RegexCat(v255, v257);
    const v259: *UH4 = normalize_29(v258);
    const v260: *UH5 = antimirov_residual_support_36(v259);
    const v261: *UH4 = normalize_29(v259);
    const v262: *UH5 = antimirov_residual_support_36(v261);
    const v263: *UH5 = antimirov_insert_unique_38(v261, v262);
    const v264: bool = regex_list_distinct_44(v263);
    if (v264) {
        v266 = antimirov_subset_45(v260, v249);
    } else {
        v266 = false;
    }
    if (v266) {
        v268 = antimirov_subset_45(v249, v260);
    } else {
        v268 = false;
    }
    if (v268) {
        v269 = UH5_RegexListCons(v259, v249);
        v271 = antimirov_subset_45(v263, v269);
    } else {
        v271 = false;
    }
    if (v271) {
        v272 = regex_position_count_46(v259);
        v274 = regex_list_exact_budget_47(v249, v272);
    } else {
        v274 = false;
    }
    if (v274) {
        v275 = UH5_RegexListCons(v259, v249);
        v276 = regex_position_count_46(v259);
        v277 = UH2_StateBudgetSucc(v276);
        v279 = regex_list_exact_budget_47(v275, v277);
    } else {
        v279 = false;
    }
    if (v279) {
        v280 = US3_TriA();
        v281 = UH4_RegexChar(v280);
        v282 = US3_TriB();
        v283 = UH4_RegexChar(v282);
        v284 = UH4_RegexAlt(v281, v283);
        v285 = UH4_RegexStar(v284);
        v286 = US3_TriC();
        v287 = UH4_RegexChar(v286);
        v288 = UH4_RegexCat(v285, v287);
        v289 = US3_TriA();
        v290 = US3_TriB();
        v291 = US3_TriC();
        v292 = UH6_SymbolListNil();
        v293 = UH6_SymbolListCons(v291, v292);
        v294 = UH6_SymbolListCons(v290, v293);
        v295 = UH6_SymbolListCons(v289, v294);
        v296 = antimirov_partial_derivatives_origin_supported_48(v288, v295);
        if (v296) {
            v297 = US3_TriA();
            v298 = UH4_RegexChar(v297);
            v299 = US3_TriB();
            v300 = UH4_RegexChar(v299);
            v301 = UH4_RegexAlt(v298, v300);
            v302 = UH4_RegexStar(v301);
            v303 = US3_TriC();
            v304 = UH4_RegexChar(v303);
            v305 = UH4_RegexCat(v302, v304);
            v306 = US3_TriA();
            v307 = US3_TriB();
            v308 = US3_TriC();
            v309 = UH6_SymbolListNil();
            v310 = UH6_SymbolListCons(v308, v309);
            v311 = UH6_SymbolListCons(v307, v310);
            v312 = UH6_SymbolListCons(v306, v311);
            v313 = antimirov_support_closed_51(v305, v238, v312);
            if (v313) {
                v314 = US3_TriA();
                v315 = UH4_RegexChar(v314);
                v316 = US3_TriB();
                v317 = UH4_RegexChar(v316);
                v318 = UH4_RegexAlt(v315, v317);
                v319 = UH4_RegexStar(v318);
                v320 = US3_TriC();
                v321 = UH4_RegexChar(v320);
                v322 = UH4_RegexCat(v319, v321);
                v323 = US3_TriA();
                v324 = US3_TriB();
                v325 = US3_TriC();
                v326 = UH6_SymbolListNil();
                v327 = UH6_SymbolListCons(v325, v326);
                v328 = UH6_SymbolListCons(v324, v327);
                v329 = UH6_SymbolListCons(v323, v328);
                v333 = antimirov_reconstruction_symbols_53(v322, v329);
            } else {
                v333 = false;
            }
        } else {
            v333 = false;
        }
    } else {
        v333 = false;
    }
    if (v333) {
    } else {
        if (spiral_true) spiralFail("ternary concatenation/alt/star support must remain bounded and closed");
    }
    const v334: US3 = US3_TriA();
    const v335: *UH4 = UH4_RegexChar(v334);
    const v336: US3 = US3_TriB();
    const v337: *UH4 = UH4_RegexChar(v336);
    const v338: *UH4 = UH4_RegexAlt(v335, v337);
    const v339: *UH4 = UH4_RegexStar(v338);
    const v340: US3 = US3_TriC();
    const v341: *UH4 = UH4_RegexChar(v340);
    const v342: *UH4 = UH4_RegexCat(v339, v341);
    const v343: *UH4 = normalize_29(v342);
    const v344: *UH5 = antimirov_position_origins_41(v343);
    switch (v344.tag) {
        1 => {
            v345 = v344.c1_0;
            v346 = v344.c1_1;
            v347 = regex_position_count_46(v343);
            v348 = regex_list_exact_budget_47(v346, v347);
            v349 = v348 == false;
            v351 = v349;
        },
        0 => {
            v351 = false;
        },
        else => unreachable,
    }
    if (v351) {
    } else {
        if (spiral_true) spiralFail("removing one concrete ternary origin must violate the exact position count");
    }
    const v352: US0 = US0_BitZero();
    const v353: US0 = US0_BitOne();
    const v354: *UH3 = UH3_SymbolListNil();
    const v355: *UH3 = UH3_SymbolListCons(v353, v354);
    const v356: *UH3 = UH3_SymbolListCons(v352, v355);
    const v357: *UH1 = regex_chars_from_symbols_57(v356);
    const v358: *UH0 = UH0_RegexEmpty();
    const v359: *UH0 = UH0_RegexEpsilon();
    const v360: *UH1 = UH1_RegexListCons(v359, v357);
    const v361: *UH1 = UH1_RegexListCons(v358, v360);
    const v362: *UH0 = UH0_RegexEmpty();
    const v363: *UH0 = UH0_RegexEpsilon();
    const v364: *UH1 = UH1_RegexListCons(v363, v357);
    const v365: *UH1 = UH1_RegexListCons(v362, v364);
    const v366: *UH1 = regex_star_corpus_58(v365);
    const v367: *UH0 = UH0_RegexEmpty();
    const v368: *UH0 = UH0_RegexEpsilon();
    const v369: *UH1 = UH1_RegexListCons(v368, v357);
    const v370: *UH1 = UH1_RegexListCons(v367, v369);
    const v371: *UH0 = UH0_RegexEmpty();
    const v372: *UH0 = UH0_RegexEpsilon();
    const v373: *UH1 = UH1_RegexListCons(v372, v357);
    const v374: *UH1 = UH1_RegexListCons(v371, v373);
    const v375: *UH1 = regex_binary_corpus_59(v370, v374);
    const v376: *UH1 = regex_list_append_60(v366, v375);
    const v377: *UH1 = regex_list_append_60(v361, v376);
    const v378: US3 = US3_TriA();
    const v379: US3 = US3_TriB();
    const v380: US3 = US3_TriC();
    const v381: *UH6 = UH6_SymbolListNil();
    const v382: *UH6 = UH6_SymbolListCons(v380, v381);
    const v383: *UH6 = UH6_SymbolListCons(v379, v382);
    const v384: *UH6 = UH6_SymbolListCons(v378, v383);
    const v385: *UH5 = regex_chars_from_symbols_62(v384);
    const v386: *UH4 = UH4_RegexEmpty();
    const v387: *UH4 = UH4_RegexEpsilon();
    const v388: *UH5 = UH5_RegexListCons(v387, v385);
    const v389: *UH5 = UH5_RegexListCons(v386, v388);
    const v390: *UH4 = UH4_RegexEmpty();
    const v391: *UH4 = UH4_RegexEpsilon();
    const v392: *UH5 = UH5_RegexListCons(v391, v385);
    const v393: *UH5 = UH5_RegexListCons(v390, v392);
    const v394: *UH5 = regex_star_corpus_63(v393);
    const v395: *UH4 = UH4_RegexEmpty();
    const v396: *UH4 = UH4_RegexEpsilon();
    const v397: *UH5 = UH5_RegexListCons(v396, v385);
    const v398: *UH5 = UH5_RegexListCons(v395, v397);
    const v399: *UH4 = UH4_RegexEmpty();
    const v400: *UH4 = UH4_RegexEpsilon();
    const v401: *UH5 = UH5_RegexListCons(v400, v385);
    const v402: *UH5 = UH5_RegexListCons(v399, v401);
    const v403: *UH5 = regex_binary_corpus_64(v398, v402);
    const v404: *UH5 = regex_list_append_65(v394, v403);
    const v405: *UH5 = regex_list_append_65(v389, v404);
    const v406: bool = antimirov_corpus_certificate_67(v377);
    if (v406) {
    } else {
        if (spiral_true) spiralFail("depth-one bit corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound");
    }
    const v407: bool = antimirov_corpus_certificate_68(v405);
    if (v407) {
    } else {
        if (spiral_true) spiralFail("depth-one ternary corpus must satisfy Antimirov reconstruction, support closure and positions-plus-one bound");
    }
    const v408: US0 = US0_BitZero();
    const v409: *UH0 = UH0_RegexChar(v408);
    const v410: US0 = US0_BitOne();
    const v411: *UH0 = UH0_RegexChar(v410);
    const v412: *UH0 = UH0_RegexAlt(v409, v411);
    const v413: *UH0 = UH0_RegexStar(v412);
    const v414: US0 = US0_BitZero();
    const v415: *UH0 = UH0_RegexChar(v414);
    const v416: *UH0 = UH0_RegexCat(v413, v415);
    const v417: *UH0 = normalize_0(v416);
    const v418: *UH1 = antimirov_residual_support_7(v417);
    const v419: *UH1 = antimirov_insert_unique_9(v417, v418);
    const v420: US0 = US0_BitZero();
    const v421: *UH0 = UH0_RegexChar(v420);
    const v422: US0 = US0_BitOne();
    const v423: *UH0 = UH0_RegexChar(v422);
    const v424: *UH0 = UH0_RegexAlt(v421, v423);
    const v425: *UH0 = UH0_RegexStar(v424);
    const v426: US0 = US0_BitZero();
    const v427: *UH0 = UH0_RegexChar(v426);
    const v428: *UH0 = UH0_RegexCat(v425, v427);
    const v429: *UH0 = normalize_0(v428);
    const v430: *UH1 = antimirov_position_origins_12(v429);
    const v431: US0 = US0_BitZero();
    const v432: *UH0 = UH0_RegexChar(v431);
    const v433: US0 = US0_BitOne();
    const v434: *UH0 = UH0_RegexChar(v433);
    const v435: *UH0 = UH0_RegexAlt(v432, v434);
    const v436: *UH0 = UH0_RegexStar(v435);
    const v437: US0 = US0_BitZero();
    const v438: *UH0 = UH0_RegexChar(v437);
    const v439: *UH0 = UH0_RegexCat(v436, v438);
    const v440: *UH0 = normalize_0(v439);
    const v441: *UH1 = antimirov_residual_support_7(v440);
    const v442: *UH0 = normalize_0(v440);
    const v443: *UH1 = antimirov_residual_support_7(v442);
    const v444: *UH1 = antimirov_insert_unique_9(v442, v443);
    const v445: bool = regex_list_distinct_15(v444);
    if (v445) {
        v447 = antimirov_subset_16(v441, v430);
    } else {
        v447 = false;
    }
    if (v447) {
        v449 = antimirov_subset_16(v430, v441);
    } else {
        v449 = false;
    }
    if (v449) {
        v450 = UH1_RegexListCons(v440, v430);
        v452 = antimirov_subset_16(v444, v450);
    } else {
        v452 = false;
    }
    if (v452) {
        v453 = regex_position_count_17(v440);
        v455 = regex_list_exact_budget_19(v430, v453);
    } else {
        v455 = false;
    }
    if (v455) {
        v456 = UH1_RegexListCons(v440, v430);
        v457 = regex_position_count_17(v440);
        v458 = UH2_StateBudgetSucc(v457);
        v460 = regex_list_exact_budget_19(v456, v458);
    } else {
        v460 = false;
    }
    if (v460) {
        v461 = US0_BitZero();
        v462 = UH0_RegexChar(v461);
        v463 = US0_BitOne();
        v464 = UH0_RegexChar(v463);
        v465 = UH0_RegexAlt(v462, v464);
        v466 = UH0_RegexStar(v465);
        v467 = US0_BitZero();
        v468 = UH0_RegexChar(v467);
        v469 = UH0_RegexCat(v466, v468);
        v470 = US0_BitZero();
        v471 = US0_BitOne();
        v472 = UH3_SymbolListNil();
        v473 = UH3_SymbolListCons(v471, v472);
        v474 = UH3_SymbolListCons(v470, v473);
        v475 = antimirov_partial_derivatives_origin_supported_20(v469, v474);
        if (v475) {
            v476 = US0_BitZero();
            v477 = UH0_RegexChar(v476);
            v478 = US0_BitOne();
            v479 = UH0_RegexChar(v478);
            v480 = UH0_RegexAlt(v477, v479);
            v481 = UH0_RegexStar(v480);
            v482 = US0_BitZero();
            v483 = UH0_RegexChar(v482);
            v484 = UH0_RegexCat(v481, v483);
            v485 = US0_BitZero();
            v486 = US0_BitOne();
            v487 = UH3_SymbolListNil();
            v488 = UH3_SymbolListCons(v486, v487);
            v489 = UH3_SymbolListCons(v485, v488);
            v490 = antimirov_support_closed_23(v484, v419, v489);
            if (v490) {
                v491 = US0_BitZero();
                v492 = UH0_RegexChar(v491);
                v493 = US0_BitOne();
                v494 = UH0_RegexChar(v493);
                v495 = UH0_RegexAlt(v492, v494);
                v496 = UH0_RegexStar(v495);
                v497 = US0_BitZero();
                v498 = UH0_RegexChar(v497);
                v499 = UH0_RegexCat(v496, v498);
                v500 = US0_BitZero();
                v501 = US0_BitOne();
                v502 = UH3_SymbolListNil();
                v503 = UH3_SymbolListCons(v501, v502);
                v504 = UH3_SymbolListCons(v500, v503);
                v508 = antimirov_reconstruction_symbols_25(v499, v504);
            } else {
                v508 = false;
            }
        } else {
            v508 = false;
        }
    } else {
        v508 = false;
    }
    if (v508) {
        v509 = US3_TriA();
        v510 = UH4_RegexChar(v509);
        v511 = US3_TriB();
        v512 = UH4_RegexChar(v511);
        v513 = UH4_RegexAlt(v510, v512);
        v514 = UH4_RegexStar(v513);
        v515 = US3_TriC();
        v516 = UH4_RegexChar(v515);
        v517 = UH4_RegexCat(v514, v516);
        v518 = normalize_29(v517);
        v519 = antimirov_residual_support_36(v518);
        v520 = antimirov_insert_unique_38(v518, v519);
        v521 = US3_TriA();
        v522 = UH4_RegexChar(v521);
        v523 = US3_TriB();
        v524 = UH4_RegexChar(v523);
        v525 = UH4_RegexAlt(v522, v524);
        v526 = UH4_RegexStar(v525);
        v527 = US3_TriC();
        v528 = UH4_RegexChar(v527);
        v529 = UH4_RegexCat(v526, v528);
        v530 = normalize_29(v529);
        v531 = antimirov_position_origins_41(v530);
        v532 = US3_TriA();
        v533 = UH4_RegexChar(v532);
        v534 = US3_TriB();
        v535 = UH4_RegexChar(v534);
        v536 = UH4_RegexAlt(v533, v535);
        v537 = UH4_RegexStar(v536);
        v538 = US3_TriC();
        v539 = UH4_RegexChar(v538);
        v540 = UH4_RegexCat(v537, v539);
        v541 = normalize_29(v540);
        v542 = antimirov_residual_support_36(v541);
        v543 = normalize_29(v541);
        v544 = antimirov_residual_support_36(v543);
        v545 = antimirov_insert_unique_38(v543, v544);
        v546 = regex_list_distinct_44(v545);
        if (v546) {
            v548 = antimirov_subset_45(v542, v531);
        } else {
            v548 = false;
        }
        if (v548) {
            v550 = antimirov_subset_45(v531, v542);
        } else {
            v550 = false;
        }
        if (v550) {
            v551 = UH5_RegexListCons(v541, v531);
            v553 = antimirov_subset_45(v545, v551);
        } else {
            v553 = false;
        }
        if (v553) {
            v554 = regex_position_count_46(v541);
            v556 = regex_list_exact_budget_47(v531, v554);
        } else {
            v556 = false;
        }
        if (v556) {
            v557 = UH5_RegexListCons(v541, v531);
            v558 = regex_position_count_46(v541);
            v559 = UH2_StateBudgetSucc(v558);
            v561 = regex_list_exact_budget_47(v557, v559);
        } else {
            v561 = false;
        }
        if (v561) {
            v562 = US3_TriA();
            v563 = UH4_RegexChar(v562);
            v564 = US3_TriB();
            v565 = UH4_RegexChar(v564);
            v566 = UH4_RegexAlt(v563, v565);
            v567 = UH4_RegexStar(v566);
            v568 = US3_TriC();
            v569 = UH4_RegexChar(v568);
            v570 = UH4_RegexCat(v567, v569);
            v571 = US3_TriA();
            v572 = US3_TriB();
            v573 = US3_TriC();
            v574 = UH6_SymbolListNil();
            v575 = UH6_SymbolListCons(v573, v574);
            v576 = UH6_SymbolListCons(v572, v575);
            v577 = UH6_SymbolListCons(v571, v576);
            v578 = antimirov_partial_derivatives_origin_supported_48(v570, v577);
            if (v578) {
                v579 = US3_TriA();
                v580 = UH4_RegexChar(v579);
                v581 = US3_TriB();
                v582 = UH4_RegexChar(v581);
                v583 = UH4_RegexAlt(v580, v582);
                v584 = UH4_RegexStar(v583);
                v585 = US3_TriC();
                v586 = UH4_RegexChar(v585);
                v587 = UH4_RegexCat(v584, v586);
                v588 = US3_TriA();
                v589 = US3_TriB();
                v590 = US3_TriC();
                v591 = UH6_SymbolListNil();
                v592 = UH6_SymbolListCons(v590, v591);
                v593 = UH6_SymbolListCons(v589, v592);
                v594 = UH6_SymbolListCons(v588, v593);
                v595 = antimirov_support_closed_51(v587, v520, v594);
                if (v595) {
                    v596 = US3_TriA();
                    v597 = UH4_RegexChar(v596);
                    v598 = US3_TriB();
                    v599 = UH4_RegexChar(v598);
                    v600 = UH4_RegexAlt(v597, v599);
                    v601 = UH4_RegexStar(v600);
                    v602 = US3_TriC();
                    v603 = UH4_RegexChar(v602);
                    v604 = UH4_RegexCat(v601, v603);
                    v605 = US3_TriA();
                    v606 = US3_TriB();
                    v607 = US3_TriC();
                    v608 = UH6_SymbolListNil();
                    v609 = UH6_SymbolListCons(v607, v608);
                    v610 = UH6_SymbolListCons(v606, v609);
                    v611 = UH6_SymbolListCons(v605, v610);
                    v616 = antimirov_reconstruction_symbols_53(v604, v611);
                } else {
                    v616 = false;
                }
            } else {
                v616 = false;
            }
        } else {
            v616 = false;
        }
    } else {
        v616 = false;
    }
    if (v616) {
    } else {
        if (spiral_true) spiralFail("higher-ranked Antimirov programs must execute alphabet-indexed certificates without erasing their family");
    }
    const v617: US0 = US0_BitZero();
    const v618: *UH0 = UH0_RegexChar(v617);
    const v619: *UH0 = UH0_RegexStar(v618);
    const v620: *UH0 = normalize_0(v619);
    const v621: US0 = US0_BitZero();
    const v622: *UH0 = canonical_derivative_27(v620, v621);
    const v623: US0 = US0_BitZero();
    const v624: *UH0 = reference_derivative_69(v620, v623);
    const v625: *UH0 = normalize_0(v624);
    const v626: US0 = US0_BitZero();
    const v627: *UH1 = antimirov_partial_derivative_21(v620, v626);
    const v628: *UH0 = antimirov_state_regex_26(v627);
    const v629: *UH0 = normalize_0(v628);
    const v630: US0 = US0_BitZero();
    const v631: *UH7 = UH7_InputEmpty();
    const v632: *UH7 = UH7_InputCons(v630, v631);
    const v633: US0 = US0_BitZero();
    const v634: US0 = US0_BitOne();
    const v635: *UH3 = UH3_SymbolListNil();
    const v636: *UH3 = UH3_SymbolListCons(v634, v635);
    const v637: *UH3 = UH3_SymbolListCons(v633, v636);
    const v638: bool = input_symbols_covered_70(v632, v637);
    if (v638) {
        v639 = normalize_0(v620);
        v640 = antimirov_position_origins_12(v639);
        v641 = normalize_0(v620);
        v642 = antimirov_residual_support_7(v641);
        v643 = normalize_0(v641);
        v644 = antimirov_residual_support_7(v643);
        v645 = antimirov_insert_unique_9(v643, v644);
        v646 = regex_list_distinct_15(v645);
        if (v646) {
            v648 = antimirov_subset_16(v642, v640);
        } else {
            v648 = false;
        }
        if (v648) {
            v650 = antimirov_subset_16(v640, v642);
        } else {
            v650 = false;
        }
        if (v650) {
            v651 = UH1_RegexListCons(v641, v640);
            v653 = antimirov_subset_16(v645, v651);
        } else {
            v653 = false;
        }
        if (v653) {
            v654 = regex_position_count_17(v641);
            v656 = regex_list_exact_budget_19(v640, v654);
        } else {
            v656 = false;
        }
        if (v656) {
            v657 = UH1_RegexListCons(v641, v640);
            v658 = regex_position_count_17(v641);
            v659 = UH2_StateBudgetSucc(v658);
            v662 = regex_list_exact_budget_19(v657, v659);
        } else {
            v662 = false;
        }
    } else {
        v662 = false;
    }
    if (v662) {
        v663 = normalize_0(v620);
        v664 = US0_BitZero();
        v665 = antimirov_partial_derivative_21(v663, v664);
        v666 = antimirov_position_origins_12(v663);
        v668 = antimirov_subset_16(v665, v666);
    } else {
        v668 = false;
    }
    if (v668) {
        v670 = regex_equal_5(v622, v625);
    } else {
        v670 = false;
    }
    if (v670) {
        v672 = regex_equal_5(v622, v629);
    } else {
        v672 = false;
    }
    if (v672) {
        v673 = US0_BitZero();
        v674 = US5_DerivativeVerified(v620, v673, v622);
        v677 = US4_DerivativePipelineVerified(v674);
    } else {
        v677 = US4_DerivativePipelineRejected();
    }
    switch (v677.tag) {
        0 => {
            v680 = false;
        },
        1 => {
            v678 = v677.c1_0;
            v680 = true;
        },
        else => unreachable,
    }
    if (v680) {
        v681 = US3_TriA();
        v682 = UH4_RegexChar(v681);
        v683 = UH4_RegexStar(v682);
        v684 = normalize_29(v683);
        v685 = US3_TriA();
        v686 = canonical_derivative_55(v684, v685);
        v687 = US3_TriA();
        v688 = reference_derivative_72(v684, v687);
        v689 = normalize_29(v688);
        v690 = US3_TriA();
        v691 = antimirov_partial_derivative_49(v684, v690);
        v692 = antimirov_state_regex_54(v691);
        v693 = normalize_29(v692);
        v694 = US3_TriA();
        v695 = UH8_InputEmpty();
        v696 = UH8_InputCons(v694, v695);
        v697 = US3_TriA();
        v698 = US3_TriB();
        v699 = US3_TriC();
        v700 = UH6_SymbolListNil();
        v701 = UH6_SymbolListCons(v699, v700);
        v702 = UH6_SymbolListCons(v698, v701);
        v703 = UH6_SymbolListCons(v697, v702);
        v704 = input_symbols_covered_73(v696, v703);
        if (v704) {
            v705 = normalize_29(v684);
            v706 = antimirov_position_origins_41(v705);
            v707 = normalize_29(v684);
            v708 = antimirov_residual_support_36(v707);
            v709 = normalize_29(v707);
            v710 = antimirov_residual_support_36(v709);
            v711 = antimirov_insert_unique_38(v709, v710);
            v712 = regex_list_distinct_44(v711);
            if (v712) {
                v714 = antimirov_subset_45(v708, v706);
            } else {
                v714 = false;
            }
            if (v714) {
                v716 = antimirov_subset_45(v706, v708);
            } else {
                v716 = false;
            }
            if (v716) {
                v717 = UH5_RegexListCons(v707, v706);
                v719 = antimirov_subset_45(v711, v717);
            } else {
                v719 = false;
            }
            if (v719) {
                v720 = regex_position_count_46(v707);
                v722 = regex_list_exact_budget_47(v706, v720);
            } else {
                v722 = false;
            }
            if (v722) {
                v723 = UH5_RegexListCons(v707, v706);
                v724 = regex_position_count_46(v707);
                v725 = UH2_StateBudgetSucc(v724);
                v728 = regex_list_exact_budget_47(v723, v725);
            } else {
                v728 = false;
            }
        } else {
            v728 = false;
        }
        if (v728) {
            v729 = normalize_29(v684);
            v730 = US3_TriA();
            v731 = antimirov_partial_derivative_49(v729, v730);
            v732 = antimirov_position_origins_41(v729);
            v734 = antimirov_subset_45(v731, v732);
        } else {
            v734 = false;
        }
        if (v734) {
            v736 = regex_equal_34(v686, v689);
        } else {
            v736 = false;
        }
        if (v736) {
            v738 = regex_equal_34(v686, v693);
        } else {
            v738 = false;
        }
        if (v738) {
            v739 = US3_TriA();
            v740 = US7_DerivativeVerified(v684, v739, v686);
            v743 = US6_DerivativePipelineVerified(v740);
        } else {
            v743 = US6_DerivativePipelineRejected();
        }
        switch (v743.tag) {
            0 => {
                v746 = false;
            },
            1 => {
                v744 = v743.c1_0;
                v746 = true;
            },
            else => unreachable,
        }
        v747 = v746;
    } else {
        v747 = false;
    }
    if (v747) {
    } else {
        if (spiral_true) spiralFail("higher-ranked derivative programs must enforce normalize-then-verify before sealing across alphabets");
    }
    const v748: US0 = US0_BitZero();
    const v749: *UH0 = UH0_RegexChar(v748);
    const v750: *UH0 = UH0_RegexStar(v749);
    const v751: *UH0 = normalize_0(v750); _ = &v751;
    const v752: []const u8 = "brzozowski-antimirov-certificate-green";
    return v752;
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
