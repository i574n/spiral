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
const UH1 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH1 = undefined };
const UH2 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH2 = undefined };
const Tuple0 = struct { f0: *UH2, f1: *UH2 };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
const UH3 = struct { tag: i32, c2_0: US3 = undefined, c3_0: *UH3 = undefined, c3_1: *UH3 = undefined, c4_0: *UH3 = undefined, c4_1: *UH3 = undefined, c5_0: *UH3 = undefined };
const UH4 = struct { tag: i32, c1_0: US3 = undefined, c1_1: *UH4 = undefined };
const UH5 = struct { tag: i32, c1_0: *UH3 = undefined, c1_1: *UH5 = undefined };
const Tuple1 = struct { f0: *UH5, f1: *UH5 };
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
fn UH1_SymbolListNil() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_SymbolListCons(a0: US0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH2_RegexListNil() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_RegexListCons(a0: *UH0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US2_Nullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_NonNullable() US2 {
    return US2{ .tag = 1 };
}
fn nullable_11(p0: *UH0) US2 {
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
            v7 = nullable_11(v5);
            v8 = nullable_11(v6);
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
            v18 = nullable_11(v16);
            v19 = nullable_11(v17);
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
fn derivative_10(p0: *UH0, p1: US0) *UH0 {
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
            v21 = derivative_10(v19, v1);
            v22 = derivative_10(v20, v1);
            return make_alt_1(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_11(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_10(v24, v1);
                    return make_cat_4(v31, v25);
                },
                0 => {
                    v27 = derivative_10(v24, v1);
                    v28 = make_cat_4(v27, v25);
                    v29 = derivative_10(v25, v1);
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
            v36 = derivative_10(v35, v1);
            v37 = make_star_6(v35);
            return make_cat_4(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_9(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_0(v0);
    const v3: *UH0 = derivative_10(v2, v1);
    return normalize_0(v3);
}
fn regex_list_contains_12(p0: *UH0, p1: *UH2) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
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
fn dfa_enqueue_symbols_8(p0: *UH0, p1: *UH1, p2: *UH2, p3: *UH2) Tuple0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v3: *UH2 = p3; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_9(v0, v4);
                v7 = regex_list_contains_12(v6, v2);
                if (v7) {
                    v1 = v5;
                    continue;
                } else {
                    v10 = UH2_RegexListCons(v6, v2);
                    v11 = UH2_RegexListCons(v6, v3);
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
fn dfa_closure_loop_7(p0: *UH1, p1: *UH2, p2: *UH2) *UH2 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                tmp4 = dfa_enqueue_symbols_8(v3, v0, v1, v4);
                v5 = tmp4.f0;
                v6 = tmp4.f1;
                v1 = v5;
                v2 = v6;
                continue;
            },
            0 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn regex_list_subset_13(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = regex_list_contains_12(v2, v1);
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
fn US3_TriA() US3 {
    return US3{ .tag = 0 };
}
fn US3_TriB() US3 {
    return US3{ .tag = 1 };
}
fn US3_TriC() US3 {
    return US3{ .tag = 2 };
}
fn UH3_RegexEmpty() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 0 };
    };
    return &shared.value;
}
fn UH3_RegexEpsilon() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 1 };
    };
    return &shared.value;
}
fn UH3_RegexChar(a0: US3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 2, .c2_0 = a0 });
}
fn UH3_RegexAlt(a0: *UH3, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH3_RegexCat(a0: *UH3, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH3_RegexStar(a0: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 5, .c5_0 = a0 });
}
fn regex_compare_17(p0: *UH3, p1: *UH3) US1 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v59: *UH3 = undefined; _ = &v59;
    var v60: *UH3 = undefined; _ = &v60;
    var v61: *UH3 = undefined; _ = &v61;
    var v62: *UH3 = undefined; _ = &v62;
    var v63: US1 = undefined; _ = &v63;
    var v34: *UH3 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v40: *UH3 = undefined; _ = &v40;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: US1 = undefined; _ = &v42;
    var v38: US3 = undefined; _ = &v38;
    var v10: US3 = undefined; _ = &v10;
    var v13: US3 = undefined; _ = &v13;
    var v50: *UH3 = undefined; _ = &v50;
    var v51: *UH3 = undefined; _ = &v51;
    var v52: *UH3 = undefined; _ = &v52;
    var v54: *UH3 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_17(v59, v61);
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
                        v42 = regex_compare_17(v34, v40);
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
fn alt_insert_sorted_16(p0: *UH3, p1: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v6: *UH3 = undefined; _ = &v6;
    var v11: US1 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_17(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_16(v0, v3);
                    return UH3_RegexAlt(v2, v6);
                },
                0 => {
                    return UH3_RegexAlt(v0, v1);
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
            v11 = regex_compare_17(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH3_RegexAlt(v1, v0);
                },
                0 => {
                    return UH3_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_15(p0: *UH3, p1: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_16(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_16(v0, v1);
            },
        }
    }
}
fn regex_equal_19(p0: *UH3, p1: *UH3) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v24: *UH3 = undefined; _ = &v24;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: *UH3 = undefined; _ = &v26;
    var v27: *UH3 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH3 = undefined; _ = &v32;
    var v33: *UH3 = undefined; _ = &v33;
    var v34: *UH3 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v21: US1 = undefined; _ = &v21;
    var v40: *UH3 = undefined; _ = &v40;
    var v41: *UH3 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_19(v24, v26);
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
                        v36 = regex_equal_19(v32, v34);
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
fn make_cat_18(p0: *UH3, p1: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v12: *UH3 = undefined; _ = &v12;
    var v13: *UH3 = undefined; _ = &v13;
    var v14: *UH3 = undefined; _ = &v14;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH3_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH3_RegexEmpty();
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
                                            v14 = make_cat_18(v13, v1);
                                            return UH3_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_19(v4, v5);
                                                    if (v6) {
                                                        return UH3_RegexStar(v4);
                                                    } else {
                                                        return UH3_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH3_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH3_RegexCat(v0, v1);
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
fn make_star_20(p0: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v3: *UH3 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH3_RegexEpsilon();
        },
        1 => {
            return UH3_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH3_RegexStar(v3);
        },
        else => {
            return UH3_RegexStar(v0);
        },
    }
}
fn normalize_14(p0: *UH3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH3 = undefined; _ = &v8;
    var v10: *UH3 = undefined; _ = &v10;
    var v11: *UH3 = undefined; _ = &v11;
    var v12: *UH3 = undefined; _ = &v12;
    var v13: *UH3 = undefined; _ = &v13;
    var v3: US3 = undefined; _ = &v3;
    var v15: *UH3 = undefined; _ = &v15;
    var v16: *UH3 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_14(v5);
            v8 = normalize_14(v6);
            return make_alt_15(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_14(v10);
            v13 = normalize_14(v11);
            return make_cat_18(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH3_RegexChar(v3);
        },
        0 => {
            return UH3_RegexEmpty();
        },
        1 => {
            return UH3_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_14(v15);
            return make_star_20(v16);
        },
        else => unreachable,
    }
}
fn UH4_SymbolListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_SymbolListCons(a0: US3, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH5_RegexListNil() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_RegexListCons(a0: *UH3, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn nullable_25(p0: *UH3) US2 {
    var v0: *UH3 = p0; _ = &v0;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH3 = undefined; _ = &v16;
    var v17: *UH3 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US3 = undefined; _ = &v3;
    var v25: *UH3 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_25(v5);
            v8 = nullable_25(v6);
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
            v18 = nullable_25(v16);
            v19 = nullable_25(v17);
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
fn derivative_24(p0: *UH3, p1: US3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: *UH3 = undefined; _ = &v26;
    var v27: *UH3 = undefined; _ = &v27;
    var v28: *UH3 = undefined; _ = &v28;
    var v30: *UH3 = undefined; _ = &v30;
    var v31: *UH3 = undefined; _ = &v31;
    var v32: US2 = undefined; _ = &v32;
    var v37: *UH3 = undefined; _ = &v37;
    var v33: *UH3 = undefined; _ = &v33;
    var v34: *UH3 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v4: US3 = undefined; _ = &v4;
    var v20: US1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: *UH3 = undefined; _ = &v42;
    var v43: *UH3 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_24(v25, v1);
            v28 = derivative_24(v26, v1);
            return make_alt_15(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_25(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_24(v30, v1);
                    return make_cat_18(v37, v31);
                },
                0 => {
                    v33 = derivative_24(v30, v1);
                    v34 = make_cat_18(v33, v31);
                    v35 = derivative_24(v31, v1);
                    return make_alt_15(v34, v35);
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
                return UH3_RegexEpsilon();
            } else {
                return UH3_RegexEmpty();
            }
        },
        0 => {
            return UH3_RegexEmpty();
        },
        1 => {
            return UH3_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_24(v41, v1);
            v43 = make_star_20(v41);
            return make_cat_18(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_23(p0: *UH3, p1: US3) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US3 = p1; _ = &v1;
    const v2: *UH3 = normalize_14(v0);
    const v3: *UH3 = derivative_24(v2, v1);
    return normalize_14(v3);
}
fn regex_list_contains_26(p0: *UH3, p1: *UH5) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_19(v0, v2);
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
fn dfa_enqueue_symbols_22(p0: *UH3, p1: *UH4, p2: *UH5, p3: *UH5) Tuple1 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH5 = p3; _ = &v3;
    var v4: US3 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH5 = undefined; _ = &v10;
    var v11: *UH5 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_23(v0, v4);
                v7 = regex_list_contains_26(v6, v2);
                if (v7) {
                    v1 = v5;
                    continue;
                } else {
                    v10 = UH5_RegexListCons(v6, v2);
                    v11 = UH5_RegexListCons(v6, v3);
                    v1 = v5;
                    v2 = v10;
                    v3 = v11;
                    continue;
                }
            },
            0 => {
                return Tuple1{ .f0 = v2, .f1 = v3 };
            },
            else => unreachable,
        }
    }
}
fn dfa_closure_loop_21(p0: *UH4, p1: *UH5, p2: *UH5) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var tmp4: Tuple1 = undefined; _ = &tmp4;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                tmp4 = dfa_enqueue_symbols_22(v3, v0, v1, v4);
                v5 = tmp4.f0;
                v6 = tmp4.f1;
                v1 = v5;
                v2 = v6;
                continue;
            },
            0 => {
                return v1;
            },
            else => unreachable,
        }
    }
}
fn regex_list_subset_27(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = regex_list_contains_26(v2, v1);
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
fn spiralMainValue() []const u8 {
    var v62: bool = undefined; _ = &v62;
    var v41: *UH0 = undefined; _ = &v41;
    var v42: US0 = undefined; _ = &v42;
    var v43: *UH0 = undefined; _ = &v43;
    var v44: US0 = undefined; _ = &v44;
    var v45: *UH0 = undefined; _ = &v45;
    var v46: *UH0 = undefined; _ = &v46;
    var v47: *UH0 = undefined; _ = &v47;
    var v48: US0 = undefined; _ = &v48;
    var v49: *UH0 = undefined; _ = &v49;
    var v50: *UH0 = undefined; _ = &v50;
    var v51: *UH0 = undefined; _ = &v51;
    var v52: *UH0 = undefined; _ = &v52;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: *UH0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: *UH0 = undefined; _ = &v57;
    var v58: *UH2 = undefined; _ = &v58;
    var v59: *UH2 = undefined; _ = &v59;
    var v60: *UH2 = undefined; _ = &v60;
    var v138: bool = undefined; _ = &v138;
    var v122: *UH3 = undefined; _ = &v122;
    var v123: *UH3 = undefined; _ = &v123;
    var v124: US3 = undefined; _ = &v124;
    var v125: *UH3 = undefined; _ = &v125;
    var v126: US3 = undefined; _ = &v126;
    var v127: *UH3 = undefined; _ = &v127;
    var v128: *UH3 = undefined; _ = &v128;
    var v129: *UH3 = undefined; _ = &v129;
    var v130: US3 = undefined; _ = &v130;
    var v131: *UH3 = undefined; _ = &v131;
    var v132: *UH3 = undefined; _ = &v132;
    var v133: *UH5 = undefined; _ = &v133;
    var v134: *UH5 = undefined; _ = &v134;
    var v135: *UH5 = undefined; _ = &v135;
    var v136: *UH5 = undefined; _ = &v136;
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
    const v10: US0 = US0_BitZero();
    const v11: US0 = US0_BitOne();
    const v12: *UH1 = UH1_SymbolListNil();
    const v13: *UH1 = UH1_SymbolListCons(v11, v12);
    const v14: *UH1 = UH1_SymbolListCons(v10, v13);
    const v15: *UH2 = UH2_RegexListNil();
    const v16: *UH2 = UH2_RegexListCons(v9, v15);
    const v17: *UH2 = UH2_RegexListNil();
    const v18: *UH2 = UH2_RegexListCons(v9, v17);
    const v19: *UH2 = dfa_closure_loop_7(v14, v16, v18);
    const v20: *UH0 = UH0_RegexEpsilon();
    const v21: US0 = US0_BitZero();
    const v22: *UH0 = UH0_RegexChar(v21);
    const v23: US0 = US0_BitOne();
    const v24: *UH0 = UH0_RegexChar(v23);
    const v25: *UH0 = UH0_RegexAlt(v22, v24);
    const v26: *UH0 = UH0_RegexStar(v25);
    const v27: US0 = US0_BitZero();
    const v28: *UH0 = UH0_RegexChar(v27);
    const v29: *UH0 = UH0_RegexCat(v26, v28);
    const v30: *UH0 = UH0_RegexAlt(v20, v29);
    const v31: *UH0 = UH0_RegexChar(v21);
    const v32: *UH0 = UH0_RegexChar(v23);
    const v33: *UH0 = UH0_RegexAlt(v31, v32);
    const v34: *UH0 = UH0_RegexStar(v33);
    const v35: *UH0 = UH0_RegexChar(v27);
    const v36: *UH0 = UH0_RegexCat(v34, v35);
    const v37: *UH2 = UH2_RegexListNil();
    const v38: *UH2 = UH2_RegexListCons(v36, v37);
    const v39: *UH2 = UH2_RegexListCons(v30, v38);
    const v40: bool = regex_list_subset_13(v39, v19);
    if (v40) {
        v41 = UH0_RegexEpsilon();
        v42 = US0_BitZero();
        v43 = UH0_RegexChar(v42);
        v44 = US0_BitOne();
        v45 = UH0_RegexChar(v44);
        v46 = UH0_RegexAlt(v43, v45);
        v47 = UH0_RegexStar(v46);
        v48 = US0_BitZero();
        v49 = UH0_RegexChar(v48);
        v50 = UH0_RegexCat(v47, v49);
        v51 = UH0_RegexAlt(v41, v50);
        v52 = UH0_RegexChar(v42);
        v53 = UH0_RegexChar(v44);
        v54 = UH0_RegexAlt(v52, v53);
        v55 = UH0_RegexStar(v54);
        v56 = UH0_RegexChar(v48);
        v57 = UH0_RegexCat(v55, v56);
        v58 = UH2_RegexListNil();
        v59 = UH2_RegexListCons(v57, v58);
        v60 = UH2_RegexListCons(v51, v59);
        v62 = regex_list_subset_13(v19, v60);
    } else {
        v62 = false;
    }
    if (v62) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v63: US0 = US0_BitZero();
    const v64: *UH0 = UH0_RegexChar(v63);
    const v65: US0 = US0_BitOne();
    const v66: *UH0 = UH0_RegexChar(v65);
    const v67: *UH0 = UH0_RegexAlt(v64, v66);
    const v68: *UH0 = UH0_RegexStar(v67);
    const v69: US0 = US0_BitZero();
    const v70: *UH0 = UH0_RegexChar(v69);
    const v71: *UH0 = UH0_RegexCat(v68, v70);
    const v72: US0 = US0_BitZero();
    const v73: *UH0 = UH0_RegexChar(v72);
    const v74: US0 = US0_BitOne();
    const v75: *UH0 = UH0_RegexChar(v74);
    const v76: *UH0 = UH0_RegexAlt(v73, v75);
    const v77: *UH0 = UH0_RegexStar(v76);
    const v78: US0 = US0_BitZero();
    const v79: *UH0 = UH0_RegexChar(v78);
    const v80: *UH0 = UH0_RegexCat(v77, v79);
    const v81: US0 = US0_BitOne();
    const v82: *UH0 = canonical_derivative_9(v80, v81);
    const v83: bool = regex_equal_5(v71, v82);
    if (v83) {
    } else {
        if (spiral_true) spiralFail("typed transition target must be the derivative for its indexed symbol");
    }
    const v84: US3 = US3_TriA();
    const v85: *UH3 = UH3_RegexChar(v84);
    const v86: US3 = US3_TriB();
    const v87: *UH3 = UH3_RegexChar(v86);
    const v88: *UH3 = UH3_RegexAlt(v85, v87);
    const v89: *UH3 = UH3_RegexStar(v88);
    const v90: US3 = US3_TriC();
    const v91: *UH3 = UH3_RegexChar(v90);
    const v92: *UH3 = UH3_RegexCat(v89, v91);
    const v93: *UH3 = normalize_14(v92);
    const v94: US3 = US3_TriA();
    const v95: US3 = US3_TriB();
    const v96: US3 = US3_TriC();
    const v97: *UH4 = UH4_SymbolListNil();
    const v98: *UH4 = UH4_SymbolListCons(v96, v97);
    const v99: *UH4 = UH4_SymbolListCons(v95, v98);
    const v100: *UH4 = UH4_SymbolListCons(v94, v99);
    const v101: *UH5 = UH5_RegexListNil();
    const v102: *UH5 = UH5_RegexListCons(v93, v101);
    const v103: *UH5 = UH5_RegexListNil();
    const v104: *UH5 = UH5_RegexListCons(v93, v103);
    const v105: *UH5 = dfa_closure_loop_21(v100, v102, v104);
    const v106: *UH3 = UH3_RegexEmpty();
    const v107: *UH3 = UH3_RegexEpsilon();
    const v108: US3 = US3_TriA();
    const v109: *UH3 = UH3_RegexChar(v108);
    const v110: US3 = US3_TriB();
    const v111: *UH3 = UH3_RegexChar(v110);
    const v112: *UH3 = UH3_RegexAlt(v109, v111);
    const v113: *UH3 = UH3_RegexStar(v112);
    const v114: US3 = US3_TriC();
    const v115: *UH3 = UH3_RegexChar(v114);
    const v116: *UH3 = UH3_RegexCat(v113, v115);
    const v117: *UH5 = UH5_RegexListNil();
    const v118: *UH5 = UH5_RegexListCons(v116, v117);
    const v119: *UH5 = UH5_RegexListCons(v107, v118);
    const v120: *UH5 = UH5_RegexListCons(v106, v119);
    const v121: bool = regex_list_subset_27(v120, v105);
    if (v121) {
        v122 = UH3_RegexEmpty();
        v123 = UH3_RegexEpsilon();
        v124 = US3_TriA();
        v125 = UH3_RegexChar(v124);
        v126 = US3_TriB();
        v127 = UH3_RegexChar(v126);
        v128 = UH3_RegexAlt(v125, v127);
        v129 = UH3_RegexStar(v128);
        v130 = US3_TriC();
        v131 = UH3_RegexChar(v130);
        v132 = UH3_RegexCat(v129, v131);
        v133 = UH5_RegexListNil();
        v134 = UH5_RegexListCons(v132, v133);
        v135 = UH5_RegexListCons(v123, v134);
        v136 = UH5_RegexListCons(v122, v135);
        v138 = regex_list_subset_27(v105, v136);
    } else {
        v138 = false;
    }
    if (v138) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v139: []const u8 = "brzozowski-indexed-dfa-contract-green";
    return v139;
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
