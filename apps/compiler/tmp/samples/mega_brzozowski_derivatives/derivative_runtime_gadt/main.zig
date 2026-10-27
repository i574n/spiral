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
const US0 = struct { tag: i32 };
const UH0 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH0 = undefined, c3_1: *UH0 = undefined, c4_0: *UH0 = undefined, c4_1: *UH0 = undefined, c5_0: *UH0 = undefined };
const UH1 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH1 = undefined };
const US1 = struct { tag: i32 };
const UH2 = struct { tag: i32, c2_0: US1 = undefined, c3_0: *UH2 = undefined, c3_1: *UH2 = undefined, c4_0: *UH2 = undefined, c4_1: *UH2 = undefined, c5_0: *UH2 = undefined };
const UH3 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH3 = undefined };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
const UH4 = struct { tag: i32, c1_0: *UH1 = undefined, c1_1: *UH4 = undefined };
const Tuple0 = struct { f0: *UH4, f1: *UH4 };
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
fn UH1_InputEmpty() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_InputCons(a0: US0, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US1_TriA() US1 {
    return US1{ .tag = 0 };
}
fn US1_TriB() US1 {
    return US1{ .tag = 1 };
}
fn US1_TriC() US1 {
    return US1{ .tag = 2 };
}
fn UH2_RegexEmpty() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_RegexEpsilon() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 1 };
    };
    return &shared.value;
}
fn UH2_RegexChar(a0: US1) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 2, .c2_0 = a0 });
}
fn UH2_RegexAlt(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH2_RegexCat(a0: *UH2, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH2_RegexStar(a0: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 5, .c5_0 = a0 });
}
fn UH3_InputEmpty() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 0 };
    };
    return &shared.value;
}
fn UH3_InputCons(a0: US1, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US2_SymbolLess() US2 {
    return US2{ .tag = 0 };
}
fn US2_SymbolSame() US2 {
    return US2{ .tag = 1 };
}
fn US2_SymbolGreater() US2 {
    return US2{ .tag = 2 };
}
fn regex_compare_4(p0: *UH0, p1: *UH0) US2 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v53: *UH0 = undefined; _ = &v53;
    var v54: *UH0 = undefined; _ = &v54;
    var v55: *UH0 = undefined; _ = &v55;
    var v56: *UH0 = undefined; _ = &v56;
    var v57: US2 = undefined; _ = &v57;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH0 = undefined; _ = &v29;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: US2 = undefined; _ = &v36;
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
                        v57 = regex_compare_4(v53, v55);
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
                        return US2_SymbolGreater();
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
                        v36 = regex_compare_4(v28, v34);
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
                        return US2_SymbolGreater();
                    },
                    0 => {
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolGreater();
                    },
                    else => {
                        return US2_SymbolLess();
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
                                        return US2_SymbolSame();
                                    },
                                    0 => {
                                        return US2_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US2_SymbolLess();
                                    },
                                    0 => {
                                        return US2_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolGreater();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US2_SymbolSame();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolSame();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US2_SymbolLess();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        v0 = v44;
                        v1 = v48;
                        continue;
                    },
                    else => {
                        return US2_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_3(p0: *UH0, p1: *UH0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: US2 = undefined; _ = &v4;
    var v6: *UH0 = undefined; _ = &v6;
    var v11: US2 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_4(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_3(v0, v3);
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
            v11 = regex_compare_4(v0, v1);
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
fn make_alt_2(p0: *UH0, p1: *UH0) *UH0 {
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
                v4 = alt_insert_sorted_3(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_3(v0, v1);
            },
        }
    }
}
fn regex_equal_6(p0: *UH0, p1: *UH0) bool {
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
    var v15: US2 = undefined; _ = &v15;
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
                        v22 = regex_equal_6(v18, v20);
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
                        v30 = regex_equal_6(v26, v28);
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
                                        v15 = US2_SymbolSame();
                                    },
                                    0 => {
                                        v15 = US2_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US2_SymbolLess();
                                    },
                                    0 => {
                                        v15 = US2_SymbolSame();
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
fn make_cat_5(p0: *UH0, p1: *UH0) *UH0 {
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
                                            v14 = make_cat_5(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_6(v4, v5);
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
fn make_star_7(p0: *UH0) *UH0 {
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
fn normalize_1(p0: *UH0) *UH0 {
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
            v7 = normalize_1(v5);
            v8 = normalize_1(v6);
            return make_alt_2(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_1(v10);
            v13 = normalize_1(v11);
            return make_cat_5(v12, v13);
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
            v16 = normalize_1(v15);
            return make_star_7(v16);
        },
        else => unreachable,
    }
}
fn US3_Nullable() US3 {
    return US3{ .tag = 0 };
}
fn US3_NonNullable() US3 {
    return US3{ .tag = 1 };
}
fn nullable_9(p0: *UH0) US3 {
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
            v7 = nullable_9(v5);
            v8 = nullable_9(v6);
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
            v18 = nullable_9(v16);
            v19 = nullable_9(v17);
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
fn derivative_8(p0: *UH0, p1: US0) *UH0 {
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
    var v14: US2 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH0 = undefined; _ = &v36;
    var v37: *UH0 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_8(v19, v1);
            v22 = derivative_8(v20, v1);
            return make_alt_2(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_9(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_8(v24, v1);
                    return make_cat_5(v31, v25);
                },
                0 => {
                    v27 = derivative_8(v24, v1);
                    v28 = make_cat_5(v27, v25);
                    v29 = derivative_8(v25, v1);
                    return make_alt_2(v28, v29);
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
                            v14 = US2_SymbolSame();
                        },
                        0 => {
                            v14 = US2_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US2_SymbolLess();
                        },
                        0 => {
                            v14 = US2_SymbolSame();
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
            v36 = derivative_8(v35, v1);
            v37 = make_star_7(v35);
            return make_cat_5(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_0(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_1(v0);
    const v3: *UH0 = derivative_8(v2, v1);
    return normalize_1(v3);
}
fn UH4_InputListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_InputListCons(a0: *UH1, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_list_append_11(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_11(v3, v1);
            return UH4_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_12(p0: *UH0, p1: *UH4) *UH4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_10(v0, v3);
            v6 = consume_right_12(v0, v4);
            return input_list_append_11(v5, v6);
        },
        0 => {
            return UH4_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_16(p0: *UH1, p1: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v16: US2 = undefined; _ = &v16;
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
                                        v16 = US2_SymbolSame();
                                    },
                                    0 => {
                                        v16 = US2_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US2_SymbolLess();
                                    },
                                    0 => {
                                        v16 = US2_SymbolSame();
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
fn input_list_contains_15(p0: *UH1, p1: *UH4) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_16(v0, v2);
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
fn input_list_enqueue_new_14(p0: *UH4, p1: *UH4, p2: *UH4) Tuple0 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH4 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_15(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH4_InputListCons(v3, v1);
                    v9 = UH4_InputListCons(v3, v2);
                    v0 = v4;
                    v1 = v8;
                    v2 = v9;
                    continue;
                }
            },
            0 => {
                return Tuple0{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_13(p0: *UH0, p1: *UH4, p2: *UH4) *UH4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_10(v0, v3);
                tmp5 = input_list_enqueue_new_14(v5, v2, v4);
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
fn language_remainders_10(p0: *UH0, p1: *UH1) *UH4 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v26: *UH0 = undefined; _ = &v26;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH4 = undefined; _ = &v28;
    var v29: *UH4 = undefined; _ = &v29;
    var v31: *UH0 = undefined; _ = &v31;
    var v32: *UH0 = undefined; _ = &v32;
    var v33: *UH4 = undefined; _ = &v33;
    var v5: US0 = undefined; _ = &v5;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v18: US2 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH4 = undefined; _ = &v20;
    var v3: *UH4 = undefined; _ = &v3;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH4 = undefined; _ = &v36;
    var v37: *UH4 = undefined; _ = &v37;
    var v38: *UH4 = undefined; _ = &v38;
    var v39: *UH4 = undefined; _ = &v39;
    switch (v0.tag) {
        3 => {
            v26 = v0.c3_0;
            v27 = v0.c3_1;
            v28 = language_remainders_10(v26, v1);
            v29 = language_remainders_10(v27, v1);
            return input_list_append_11(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = language_remainders_10(v31, v1);
            return consume_right_12(v32, v33);
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
                                    v18 = US2_SymbolSame();
                                },
                                0 => {
                                    v18 = US2_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US2_SymbolLess();
                                },
                                0 => {
                                    v18 = US2_SymbolSame();
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
                        v20 = UH4_InputListNil();
                        return UH4_InputListCons(v8, v20);
                    } else {
                        return UH4_InputListNil();
                    }
                },
                0 => {
                    return UH4_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH4_InputListNil();
        },
        1 => {
            v3 = UH4_InputListNil();
            return UH4_InputListCons(v1, v3);
        },
        5 => {
            v35 = v0.c5_0;
            v36 = UH4_InputListNil();
            v37 = UH4_InputListCons(v1, v36);
            v38 = UH4_InputListNil();
            v39 = UH4_InputListCons(v1, v38);
            return closure_13(v35, v37, v39);
        },
        else => unreachable,
    }
}
fn input_list_remove_17(p0: *UH1, p1: *UH4) *UH4 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH4 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_16(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_17(v0, v4);
                    return UH4_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH4_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_18(p0: *UH4, p1: *UH4) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_15(v2, v1);
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
fn regex_compare_23(p0: *UH2, p1: *UH2) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v59: *UH2 = undefined; _ = &v59;
    var v60: *UH2 = undefined; _ = &v60;
    var v61: *UH2 = undefined; _ = &v61;
    var v62: *UH2 = undefined; _ = &v62;
    var v63: US2 = undefined; _ = &v63;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: US2 = undefined; _ = &v42;
    var v38: US1 = undefined; _ = &v38;
    var v10: US1 = undefined; _ = &v10;
    var v13: US1 = undefined; _ = &v13;
    var v50: *UH2 = undefined; _ = &v50;
    var v51: *UH2 = undefined; _ = &v51;
    var v52: *UH2 = undefined; _ = &v52;
    var v54: *UH2 = undefined; _ = &v54;
    while (true) {
        switch (v0.tag) {
            3 => {
                v59 = v0.c3_0;
                v60 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v61 = v1.c3_0;
                        v62 = v1.c3_1;
                        v63 = regex_compare_23(v59, v61);
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
                        return US2_SymbolGreater();
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
                        v42 = regex_compare_23(v34, v40);
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
                        return US2_SymbolGreater();
                    },
                    0 => {
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolGreater();
                    },
                    else => {
                        return US2_SymbolLess();
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
                                        return US2_SymbolSame();
                                    },
                                    else => {
                                        return US2_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US2_SymbolGreater();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US2_SymbolSame();
                                                    },
                                                    2 => {
                                                        return US2_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US2_SymbolGreater();
                                                    },
                                                    2 => {
                                                        return US2_SymbolSame();
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
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolGreater();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US2_SymbolSame();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US2_SymbolGreater();
                    },
                    1 => {
                        return US2_SymbolSame();
                    },
                    else => {
                        return US2_SymbolLess();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US2_SymbolLess();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        v0 = v50;
                        v1 = v54;
                        continue;
                    },
                    else => {
                        return US2_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_22(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US2 = undefined; _ = &v4;
    var v6: *UH2 = undefined; _ = &v6;
    var v11: US2 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_23(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_22(v0, v3);
                    return UH2_RegexAlt(v2, v6);
                },
                0 => {
                    return UH2_RegexAlt(v0, v1);
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
            v11 = regex_compare_23(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH2_RegexAlt(v1, v0);
                },
                0 => {
                    return UH2_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_21(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_22(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_22(v0, v1);
            },
        }
    }
}
fn regex_equal_25(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v21: US2 = undefined; _ = &v21;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: *UH2 = undefined; _ = &v41;
    while (true) {
        switch (v0.tag) {
            3 => {
                v24 = v0.c3_0;
                v25 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v26 = v1.c3_0;
                        v27 = v1.c3_1;
                        v28 = regex_equal_25(v24, v26);
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
                        v36 = regex_equal_25(v32, v34);
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
                                        v21 = US2_SymbolSame();
                                    },
                                    else => {
                                        v21 = US2_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US2_SymbolGreater();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US2_SymbolSame();
                                                    },
                                                    2 => {
                                                        v21 = US2_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US2_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v21 = US2_SymbolSame();
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
fn make_cat_24(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH2_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH2_RegexEmpty();
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
                                            v14 = make_cat_24(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_25(v4, v5);
                                                    if (v6) {
                                                        return UH2_RegexStar(v4);
                                                    } else {
                                                        return UH2_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH2_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH2_RegexCat(v0, v1);
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
fn make_star_26(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v3: *UH2 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH2_RegexEpsilon();
        },
        1 => {
            return UH2_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH2_RegexStar(v3);
        },
        else => {
            return UH2_RegexStar(v0);
        },
    }
}
fn normalize_20(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v3: US1 = undefined; _ = &v3;
    var v15: *UH2 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_20(v5);
            v8 = normalize_20(v6);
            return make_alt_21(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_20(v10);
            v13 = normalize_20(v11);
            return make_cat_24(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH2_RegexChar(v3);
        },
        0 => {
            return UH2_RegexEmpty();
        },
        1 => {
            return UH2_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_20(v15);
            return make_star_26(v16);
        },
        else => unreachable,
    }
}
fn nullable_28(p0: *UH2) US3 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US1 = undefined; _ = &v3;
    var v25: *UH2 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_28(v5);
            v8 = nullable_28(v6);
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
            v18 = nullable_28(v16);
            v19 = nullable_28(v17);
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
fn derivative_27(p0: *UH2, p1: US1) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: US3 = undefined; _ = &v32;
    var v37: *UH2 = undefined; _ = &v37;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v4: US1 = undefined; _ = &v4;
    var v20: US2 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH2 = undefined; _ = &v42;
    var v43: *UH2 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_27(v25, v1);
            v28 = derivative_27(v26, v1);
            return make_alt_21(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_28(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_27(v30, v1);
                    return make_cat_24(v37, v31);
                },
                0 => {
                    v33 = derivative_27(v30, v1);
                    v34 = make_cat_24(v33, v31);
                    v35 = derivative_27(v31, v1);
                    return make_alt_21(v34, v35);
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
                            v20 = US2_SymbolSame();
                        },
                        else => {
                            v20 = US2_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US2_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US2_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US2_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US2_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US2_SymbolSame();
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
                return UH2_RegexEpsilon();
            } else {
                return UH2_RegexEmpty();
            }
        },
        0 => {
            return UH2_RegexEmpty();
        },
        1 => {
            return UH2_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_27(v41, v1);
            v43 = make_star_26(v41);
            return make_cat_24(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_19(p0: *UH2, p1: US1) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    const v2: *UH2 = normalize_20(v0);
    const v3: *UH2 = derivative_27(v2, v1);
    return normalize_20(v3);
}
fn UH5_InputListNil() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_InputListCons(a0: *UH3, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_list_append_30(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_30(v3, v1);
            return UH5_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_31(p0: *UH2, p1: *UH5) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_29(v0, v3);
            v6 = consume_right_31(v0, v4);
            return input_list_append_30(v5, v6);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_35(p0: *UH3, p1: *UH3) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v22: US2 = undefined; _ = &v22;
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
                                        v22 = US2_SymbolSame();
                                    },
                                    else => {
                                        v22 = US2_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US2_SymbolGreater();
                                    },
                                    else => {
                                        switch (v3.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US2_SymbolSame();
                                                    },
                                                    2 => {
                                                        v22 = US2_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US2_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v22 = US2_SymbolSame();
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
fn input_list_contains_34(p0: *UH3, p1: *UH5) bool {
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
                v4 = input_equal_35(v0, v2);
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
fn input_list_enqueue_new_33(p0: *UH5, p1: *UH5, p2: *UH5) Tuple1 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_34(v3, v1);
                if (v5) {
                    v0 = v4;
                    continue;
                } else {
                    v8 = UH5_InputListCons(v3, v1);
                    v9 = UH5_InputListCons(v3, v2);
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
fn closure_32(p0: *UH2, p1: *UH5, p2: *UH5) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var tmp5: Tuple1 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_29(v0, v3);
                tmp5 = input_list_enqueue_new_33(v5, v2, v4);
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
fn language_remainders_29(p0: *UH2, p1: *UH3) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH2 = undefined; _ = &v33;
    var v34: *UH5 = undefined; _ = &v34;
    var v35: *UH5 = undefined; _ = &v35;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: *UH2 = undefined; _ = &v38;
    var v39: *UH5 = undefined; _ = &v39;
    var v5: US1 = undefined; _ = &v5;
    var v7: US1 = undefined; _ = &v7;
    var v8: *UH3 = undefined; _ = &v8;
    var v24: US2 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH5 = undefined; _ = &v26;
    var v3: *UH5 = undefined; _ = &v3;
    var v41: *UH2 = undefined; _ = &v41;
    var v42: *UH5 = undefined; _ = &v42;
    var v43: *UH5 = undefined; _ = &v43;
    var v44: *UH5 = undefined; _ = &v44;
    var v45: *UH5 = undefined; _ = &v45;
    switch (v0.tag) {
        3 => {
            v32 = v0.c3_0;
            v33 = v0.c3_1;
            v34 = language_remainders_29(v32, v1);
            v35 = language_remainders_29(v33, v1);
            return input_list_append_30(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = language_remainders_29(v37, v1);
            return consume_right_31(v38, v39);
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
                                    v24 = US2_SymbolSame();
                                },
                                else => {
                                    v24 = US2_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US2_SymbolGreater();
                                },
                                else => {
                                    switch (v5.tag) {
                                        1 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US2_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US2_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US2_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US2_SymbolSame();
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
                        v26 = UH5_InputListNil();
                        return UH5_InputListCons(v8, v26);
                    } else {
                        return UH5_InputListNil();
                    }
                },
                0 => {
                    return UH5_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH5_InputListNil();
        },
        1 => {
            v3 = UH5_InputListNil();
            return UH5_InputListCons(v1, v3);
        },
        5 => {
            v41 = v0.c5_0;
            v42 = UH5_InputListNil();
            v43 = UH5_InputListCons(v1, v42);
            v44 = UH5_InputListNil();
            v45 = UH5_InputListCons(v1, v44);
            return closure_32(v41, v43, v45);
        },
        else => unreachable,
    }
}
fn input_list_remove_36(p0: *UH3, p1: *UH5) *UH5 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH5 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_35(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_36(v0, v4);
                    return UH5_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH5_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_37(p0: *UH5, p1: *UH5) bool {
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
                v4 = input_list_contains_34(v2, v1);
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
fn spiralMainValue() bool {
    var v40: bool = undefined; _ = &v40;
    var v49: bool = undefined; _ = &v49;
    const v0: US0 = US0_BitZero();
    const v1: *UH0 = UH0_RegexChar(v0);
    const v2: US0 = US0_BitOne();
    const v3: *UH0 = UH0_RegexChar(v2);
    const v4: *UH0 = UH0_RegexAlt(v1, v3);
    const v5: *UH0 = UH0_RegexStar(v4);
    const v6: US0 = US0_BitZero();
    const v7: *UH0 = UH0_RegexChar(v6);
    const v8: *UH0 = UH0_RegexCat(v5, v7);
    const v9: US0 = US0_BitZero();
    const v10: US0 = US0_BitOne();
    const v11: US0 = US0_BitOne();
    const v12: US0 = US0_BitZero();
    const v13: *UH1 = UH1_InputEmpty();
    const v14: *UH1 = UH1_InputCons(v12, v13);
    const v15: *UH1 = UH1_InputCons(v11, v14);
    const v16: *UH1 = UH1_InputCons(v10, v15);
    const v17: US1 = US1_TriA();
    const v18: *UH2 = UH2_RegexChar(v17);
    const v19: US1 = US1_TriB();
    const v20: *UH2 = UH2_RegexChar(v19);
    const v21: *UH2 = UH2_RegexAlt(v18, v20);
    const v22: *UH2 = UH2_RegexStar(v21);
    const v23: US1 = US1_TriC();
    const v24: *UH2 = UH2_RegexChar(v23);
    const v25: *UH2 = UH2_RegexCat(v22, v24);
    const v26: US1 = US1_TriA();
    const v27: US1 = US1_TriB();
    const v28: US1 = US1_TriC();
    const v29: *UH3 = UH3_InputEmpty();
    const v30: *UH3 = UH3_InputCons(v28, v29);
    const v31: *UH3 = UH3_InputCons(v27, v30);
    const v32: *UH0 = canonical_derivative_0(v8, v9);
    const v33: *UH1 = UH1_InputCons(v9, v16);
    const v34: *UH1 = UH1_InputCons(v9, v16);
    const v35: *UH4 = language_remainders_10(v8, v34);
    const v36: *UH4 = input_list_remove_17(v33, v35);
    const v37: *UH4 = language_remainders_10(v32, v16);
    const v38: bool = input_list_subset_18(v36, v37);
    if (v38) {
        v40 = input_list_subset_18(v37, v36);
    } else {
        v40 = false;
    }
    const v41: *UH2 = canonical_derivative_19(v25, v26);
    const v42: *UH3 = UH3_InputCons(v26, v31);
    const v43: *UH3 = UH3_InputCons(v26, v31);
    const v44: *UH5 = language_remainders_29(v25, v43);
    const v45: *UH5 = input_list_remove_36(v42, v44);
    const v46: *UH5 = language_remainders_29(v41, v31);
    const v47: bool = input_list_subset_37(v45, v46);
    if (v47) {
        v49 = input_list_subset_37(v46, v45);
    } else {
        v49 = false;
    }
    const v50: bool = (v40 and v49);
    return v50;
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
