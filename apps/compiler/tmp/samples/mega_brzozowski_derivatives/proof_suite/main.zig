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
const US1 = struct { tag: i32 };
const UH1 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH1 = undefined };
const UH2 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH2 = undefined, c3_1: *UH2 = undefined, c4_0: *UH2 = undefined, c4_1: *UH2 = undefined, c5_0: *UH2 = undefined };
const US2 = struct { tag: i32 };
const UH3 = struct { tag: i32, c2_0: US1 = undefined, c3_0: *UH3 = undefined, c3_1: *UH3 = undefined, c4_0: *UH3 = undefined, c4_1: *UH3 = undefined, c5_0: *UH3 = undefined };
const US3 = struct { tag: i32 };
const UH4 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH4 = undefined };
const UH5 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH5 = undefined };
const Tuple0 = struct { f0: *UH5, f1: *UH5 };
const UH6 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH6 = undefined };
const UH7 = struct { tag: i32, c1_0: *UH1 = undefined, c1_1: *UH7 = undefined };
const Tuple1 = struct { f0: *UH7, f1: *UH7 };
const UH8 = struct { tag: i32, c1_0: *UH8 = undefined };
const UH9 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: *UH9 = undefined };
const US4 = struct { tag: i32, c0_0: *UH9 = undefined, c1_0: *UH9 = undefined };
const Tuple2 = struct { f0: *UH9, f1: *UH9 };
const UH10 = struct { tag: i32, c1_0: *UH3 = undefined, c1_1: *UH10 = undefined };
const Tuple3 = struct { f0: *UH10, f1: *UH10 };
const UH11 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: *UH2 = undefined, c1_2: *UH11 = undefined };
const UH12 = struct { tag: i32, c1_0: *UH3 = undefined, c1_1: *UH3 = undefined, c1_2: *UH12 = undefined };
const US5 = struct { tag: i32, c0_0: *UH2 = undefined, c0_1: *UH0 = undefined };
const US6 = struct { tag: i32, c0_0: *UH2 = undefined, c0_1: *UH0 = undefined, c0_2: bool = undefined };
const UH13 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: US0 = undefined, c1_2: *UH2 = undefined, c1_3: *UH13 = undefined };
const US7 = struct { tag: i32, c0_0: *UH2 = undefined };
const US8 = struct { tag: i32, c0_0: *UH10 = undefined, c1_0: *UH10 = undefined };
const UH14 = struct { tag: i32, c1_0: *UH3 = undefined, c1_1: US1 = undefined, c1_2: *UH3 = undefined, c1_3: *UH14 = undefined };
const US9 = struct { tag: i32, c0_0: *UH3 = undefined };
const US10 = struct { tag: i32, c0_0: *UH2 = undefined };
const US11 = struct { tag: i32, c0_0: *UH3 = undefined };
const US12 = struct { tag: i32 };
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
fn US1_TriA() US1 {
    return US1{ .tag = 0 };
}
fn US1_TriB() US1 {
    return US1{ .tag = 1 };
}
fn US1_TriC() US1 {
    return US1{ .tag = 2 };
}
fn UH1_InputEmpty() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_InputCons(a0: US1, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
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
fn UH2_RegexChar(a0: US0) *UH2 {
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
fn US2_Nullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_NonNullable() US2 {
    return US2{ .tag = 1 };
}
fn nullable_0(p0: *UH2) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH2 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_0(v5);
            v8 = nullable_0(v6);
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
            v18 = nullable_0(v16);
            v19 = nullable_0(v17);
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
fn UH3_RegexChar(a0: US1) *UH3 {
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
fn nullable_1(p0: *UH3) US2 {
    var v0: *UH3 = p0; _ = &v0;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: US2 = undefined; _ = &v7;
    var v8: US2 = undefined; _ = &v8;
    var v16: *UH3 = undefined; _ = &v16;
    var v17: *UH3 = undefined; _ = &v17;
    var v18: US2 = undefined; _ = &v18;
    var v19: US2 = undefined; _ = &v19;
    var v3: US1 = undefined; _ = &v3;
    var v25: *UH3 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_1(v5);
            v8 = nullable_1(v6);
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
            v18 = nullable_1(v16);
            v19 = nullable_1(v17);
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
fn US3_SymbolLess() US3 {
    return US3{ .tag = 0 };
}
fn US3_SymbolSame() US3 {
    return US3{ .tag = 1 };
}
fn US3_SymbolGreater() US3 {
    return US3{ .tag = 2 };
}
fn regex_compare_7(p0: *UH2, p1: *UH2) US3 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v53: *UH2 = undefined; _ = &v53;
    var v54: *UH2 = undefined; _ = &v54;
    var v55: *UH2 = undefined; _ = &v55;
    var v56: *UH2 = undefined; _ = &v56;
    var v57: US3 = undefined; _ = &v57;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: US3 = undefined; _ = &v36;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH2 = undefined; _ = &v44;
    var v45: *UH2 = undefined; _ = &v45;
    var v46: *UH2 = undefined; _ = &v46;
    var v48: *UH2 = undefined; _ = &v48;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = regex_compare_7(v53, v55);
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
                        return US3_SymbolGreater();
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
                        v36 = regex_compare_7(v28, v34);
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
                        return US3_SymbolGreater();
                    },
                    0 => {
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolGreater();
                    },
                    else => {
                        return US3_SymbolLess();
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
                                        return US3_SymbolSame();
                                    },
                                    0 => {
                                        return US3_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US3_SymbolLess();
                                    },
                                    0 => {
                                        return US3_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolGreater();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US3_SymbolSame();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolSame();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US3_SymbolLess();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        v0 = v44;
                        v1 = v48;
                        continue;
                    },
                    else => {
                        return US3_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_6(p0: *UH2, p1: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US3 = undefined; _ = &v4;
    var v6: *UH2 = undefined; _ = &v6;
    var v11: US3 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_7(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_6(v0, v3);
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
            v11 = regex_compare_7(v0, v1);
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
fn make_alt_5(p0: *UH2, p1: *UH2) *UH2 {
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
                v4 = alt_insert_sorted_6(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_6(v0, v1);
            },
        }
    }
}
fn regex_equal_9(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v18: *UH2 = undefined; _ = &v18;
    var v19: *UH2 = undefined; _ = &v19;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US3 = undefined; _ = &v15;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = regex_equal_9(v18, v20);
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
                        v30 = regex_equal_9(v26, v28);
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
                                        v15 = US3_SymbolSame();
                                    },
                                    0 => {
                                        v15 = US3_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US3_SymbolLess();
                                    },
                                    0 => {
                                        v15 = US3_SymbolSame();
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
fn make_cat_8(p0: *UH2, p1: *UH2) *UH2 {
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
                                            v14 = make_cat_8(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_9(v4, v5);
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
fn make_star_10(p0: *UH2) *UH2 {
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
fn normalize_4(p0: *UH2) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH2 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_4(v5);
            v8 = normalize_4(v6);
            return make_alt_5(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_4(v10);
            v13 = normalize_4(v11);
            return make_cat_8(v12, v13);
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
            v16 = normalize_4(v15);
            return make_star_10(v16);
        },
        else => unreachable,
    }
}
fn derivative_11(p0: *UH2, p1: US0) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH2 = undefined; _ = &v19;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: *UH2 = undefined; _ = &v22;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
    var v31: *UH2 = undefined; _ = &v31;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US3 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_11(v19, v1);
            v22 = derivative_11(v20, v1);
            return make_alt_5(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_0(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_11(v24, v1);
                    return make_cat_8(v31, v25);
                },
                0 => {
                    v27 = derivative_11(v24, v1);
                    v28 = make_cat_8(v27, v25);
                    v29 = derivative_11(v25, v1);
                    return make_alt_5(v28, v29);
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
                            v14 = US3_SymbolSame();
                        },
                        0 => {
                            v14 = US3_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US3_SymbolLess();
                        },
                        0 => {
                            v14 = US3_SymbolSame();
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
            v35 = v0.c5_0;
            v36 = derivative_11(v35, v1);
            v37 = make_star_10(v35);
            return make_cat_8(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_3(p0: *UH2, p1: US0) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH2 = normalize_4(v0);
    const v3: *UH2 = derivative_11(v2, v1);
    return normalize_4(v3);
}
fn accepts_2(p0: *UH2, p1: *UH0) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = canonical_derivative_3(v0, v6);
                v0 = v8;
                v1 = v7;
                continue;
            },
            0 => {
                v2 = normalize_4(v0);
                v3 = nullable_0(v2);
                switch (v3.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn regex_compare_17(p0: *UH3, p1: *UH3) US3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v59: *UH3 = undefined; _ = &v59;
    var v60: *UH3 = undefined; _ = &v60;
    var v61: *UH3 = undefined; _ = &v61;
    var v62: *UH3 = undefined; _ = &v62;
    var v63: US3 = undefined; _ = &v63;
    var v34: *UH3 = undefined; _ = &v34;
    var v35: *UH3 = undefined; _ = &v35;
    var v40: *UH3 = undefined; _ = &v40;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: US3 = undefined; _ = &v42;
    var v38: US1 = undefined; _ = &v38;
    var v10: US1 = undefined; _ = &v10;
    var v13: US1 = undefined; _ = &v13;
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
                        return US3_SymbolGreater();
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
                        return US3_SymbolGreater();
                    },
                    0 => {
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolGreater();
                    },
                    else => {
                        return US3_SymbolLess();
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
                                        return US3_SymbolSame();
                                    },
                                    else => {
                                        return US3_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US3_SymbolGreater();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US3_SymbolSame();
                                                    },
                                                    2 => {
                                                        return US3_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US3_SymbolGreater();
                                                    },
                                                    2 => {
                                                        return US3_SymbolSame();
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
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolGreater();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US3_SymbolSame();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US3_SymbolGreater();
                    },
                    1 => {
                        return US3_SymbolSame();
                    },
                    else => {
                        return US3_SymbolLess();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US3_SymbolLess();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        v0 = v50;
                        v1 = v54;
                        continue;
                    },
                    else => {
                        return US3_SymbolGreater();
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
    var v4: US3 = undefined; _ = &v4;
    var v6: *UH3 = undefined; _ = &v6;
    var v11: US3 = undefined; _ = &v11;
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
    var v4: US1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v21: US3 = undefined; _ = &v21;
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
                                        v21 = US3_SymbolSame();
                                    },
                                    else => {
                                        v21 = US3_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US3_SymbolGreater();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US3_SymbolSame();
                                                    },
                                                    2 => {
                                                        v21 = US3_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US3_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v21 = US3_SymbolSame();
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
    var v3: US1 = undefined; _ = &v3;
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
fn derivative_21(p0: *UH3, p1: US1) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
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
    var v4: US1 = undefined; _ = &v4;
    var v20: US3 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: *UH3 = undefined; _ = &v42;
    var v43: *UH3 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_21(v25, v1);
            v28 = derivative_21(v26, v1);
            return make_alt_15(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_1(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_21(v30, v1);
                    return make_cat_18(v37, v31);
                },
                0 => {
                    v33 = derivative_21(v30, v1);
                    v34 = make_cat_18(v33, v31);
                    v35 = derivative_21(v31, v1);
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
                            v20 = US3_SymbolSame();
                        },
                        else => {
                            v20 = US3_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US3_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US3_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US3_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US3_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US3_SymbolSame();
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
            v42 = derivative_21(v41, v1);
            v43 = make_star_20(v41);
            return make_cat_18(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_13(p0: *UH3, p1: US1) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    const v2: *UH3 = normalize_14(v0);
    const v3: *UH3 = derivative_21(v2, v1);
    return normalize_14(v3);
}
fn accepts_12(p0: *UH3, p1: *UH1) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: US1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH3 = undefined; _ = &v8;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v1.tag) {
            1 => {
                v6 = v1.c1_0;
                v7 = v1.c1_1;
                v8 = canonical_derivative_13(v0, v6);
                v0 = v8;
                v1 = v7;
                continue;
            },
            0 => {
                v2 = normalize_14(v0);
                v3 = nullable_1(v2);
                switch (v3.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn UH4_SymbolListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_SymbolListCons(a0: US0, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH5_InputListNil() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_InputListCons(a0: *UH0, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_suffixes_22(p0: *UH0) *UH5 {
    var v0: *UH0 = p0; _ = &v0;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v1: *UH0 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    switch (v0.tag) {
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            v6 = input_suffixes_22(v5);
            return UH5_InputListCons(v0, v6);
        },
        0 => {
            v1 = UH0_InputEmpty();
            v2 = UH5_InputListNil();
            return UH5_InputListCons(v1, v2);
        },
        else => unreachable,
    }
}
fn reference_derivative_26(p0: *UH2, p1: US0) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH2 = undefined; _ = &v19;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: *UH2 = undefined; _ = &v22;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: US2 = undefined; _ = &v26;
    var v31: *UH2 = undefined; _ = &v31;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US3 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = reference_derivative_26(v19, v1);
            v22 = reference_derivative_26(v20, v1);
            return UH2_RegexAlt(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_0(v24);
            switch (v26.tag) {
                1 => {
                    v31 = reference_derivative_26(v24, v1);
                    return UH2_RegexCat(v31, v25);
                },
                0 => {
                    v27 = reference_derivative_26(v24, v1);
                    v28 = reference_derivative_26(v25, v1);
                    v29 = UH2_RegexCat(v27, v25);
                    return UH2_RegexAlt(v29, v28);
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
                            v14 = US3_SymbolSame();
                        },
                        0 => {
                            v14 = US3_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US3_SymbolLess();
                        },
                        0 => {
                            v14 = US3_SymbolSame();
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
            v35 = v0.c5_0;
            v36 = reference_derivative_26(v35, v1);
            v37 = UH2_RegexStar(v35);
            return UH2_RegexCat(v36, v37);
        },
        else => unreachable,
    }
}
fn input_list_append_28(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_28(v3, v1);
            return UH5_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_29(p0: *UH2, p1: *UH5) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_27(v0, v3);
            v6 = consume_right_29(v0, v4);
            return input_list_append_28(v5, v6);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_33(p0: *UH0, p1: *UH0) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v16: US3 = undefined; _ = &v16;
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
                                        v16 = US3_SymbolSame();
                                    },
                                    0 => {
                                        v16 = US3_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US3_SymbolLess();
                                    },
                                    0 => {
                                        v16 = US3_SymbolSame();
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
fn input_list_contains_32(p0: *UH0, p1: *UH5) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_33(v0, v2);
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
fn input_list_enqueue_new_31(p0: *UH5, p1: *UH5, p2: *UH5) Tuple0 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_32(v3, v1);
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
                return Tuple0{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_30(p0: *UH2, p1: *UH5, p2: *UH5) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_27(v0, v3);
                tmp5 = input_list_enqueue_new_31(v5, v2, v4);
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
fn language_remainders_27(p0: *UH2, p1: *UH0) *UH5 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v26: *UH2 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH5 = undefined; _ = &v28;
    var v29: *UH5 = undefined; _ = &v29;
    var v31: *UH2 = undefined; _ = &v31;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: *UH5 = undefined; _ = &v33;
    var v5: US0 = undefined; _ = &v5;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v18: US3 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH5 = undefined; _ = &v20;
    var v3: *UH5 = undefined; _ = &v3;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: *UH5 = undefined; _ = &v36;
    var v37: *UH5 = undefined; _ = &v37;
    var v38: *UH5 = undefined; _ = &v38;
    var v39: *UH5 = undefined; _ = &v39;
    switch (v0.tag) {
        3 => {
            v26 = v0.c3_0;
            v27 = v0.c3_1;
            v28 = language_remainders_27(v26, v1);
            v29 = language_remainders_27(v27, v1);
            return input_list_append_28(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = language_remainders_27(v31, v1);
            return consume_right_29(v32, v33);
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
                                    v18 = US3_SymbolSame();
                                },
                                0 => {
                                    v18 = US3_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US3_SymbolLess();
                                },
                                0 => {
                                    v18 = US3_SymbolSame();
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
                        v20 = UH5_InputListNil();
                        return UH5_InputListCons(v8, v20);
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
            v35 = v0.c5_0;
            v36 = UH5_InputListNil();
            v37 = UH5_InputListCons(v1, v36);
            v38 = UH5_InputListNil();
            v39 = UH5_InputListCons(v1, v38);
            return closure_30(v35, v37, v39);
        },
        else => unreachable,
    }
}
fn input_list_remove_34(p0: *UH0, p1: *UH5) *UH5 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH5 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_33(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_34(v0, v4);
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
fn input_list_subset_35(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_32(v2, v1);
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
fn derivative_semantic_triangle_25(p0: *UH2, p1: US0, p2: *UH0) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH0 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v13: *UH0 = undefined; _ = &v13;
    var v14: *UH0 = undefined; _ = &v14;
    var v15: *UH5 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
    var v17: *UH5 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: bool = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: *UH2 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v23: US0 = undefined; _ = &v23;
    var v34: *UH2 = undefined; _ = &v34;
    while (true) {
        v3 = canonical_derivative_3(v0, v1);
        v4 = reference_derivative_26(v0, v1);
        v5 = UH0_InputCons(v1, v2);
        v6 = UH0_InputCons(v1, v2);
        v7 = language_remainders_27(v0, v6);
        v8 = input_list_remove_34(v5, v7);
        v9 = language_remainders_27(v3, v2);
        v10 = input_list_subset_35(v8, v9);
        if (v10) {
            v12 = input_list_subset_35(v9, v8);
        } else {
            v12 = false;
        }
        if (v12) {
            v13 = UH0_InputCons(v1, v2);
            v14 = UH0_InputCons(v1, v2);
            v15 = language_remainders_27(v0, v14);
            v16 = input_list_remove_34(v13, v15);
            v17 = language_remainders_27(v4, v2);
            v18 = input_list_subset_35(v16, v17);
            if (v18) {
                v20 = input_list_subset_35(v17, v16);
            } else {
                v20 = false;
            }
            if (v20) {
                v21 = normalize_4(v4);
                v22 = regex_equal_9(v3, v21);
                if (v22) {
                    switch (v0.tag) {
                        3 => {
                            v24 = v0.c3_0;
                            v25 = v0.c3_1;
                            v26 = derivative_semantic_triangle_25(v24, v1, v2);
                            if (v26) {
                                v0 = v25;
                                continue;
                            } else {
                                return false;
                            }
                        },
                        4 => {
                            v29 = v0.c4_0;
                            v30 = v0.c4_1;
                            v31 = derivative_semantic_triangle_25(v29, v1, v2);
                            if (v31) {
                                v0 = v30;
                                continue;
                            } else {
                                return false;
                            }
                        },
                        2 => {
                            v23 = v0.c2_0;
                            return true;
                        },
                        0 => {
                            return true;
                        },
                        1 => {
                            return true;
                        },
                        5 => {
                            v34 = v0.c5_0;
                            v0 = v34;
                            continue;
                        },
                        else => unreachable,
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
}
fn derivative_semantic_triangle_suffixes_24(p0: *UH2, p1: US0, p2: *UH5) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = derivative_semantic_triangle_25(v0, v1, v3);
                if (v5) {
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
fn derivative_semantic_triangle_symbols_23(p0: *UH2, p1: *UH4, p2: *UH5) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_semantic_triangle_suffixes_24(v0, v3, v2);
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
fn UH6_SymbolListNil() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_SymbolListCons(a0: US1, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH7_InputListNil() *UH7 {
    const shared = struct {
        var value: UH7 = UH7{ .tag = 0 };
    };
    return &shared.value;
}
fn UH7_InputListCons(a0: *UH1, a1: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_suffixes_36(p0: *UH1) *UH7 {
    var v0: *UH1 = p0; _ = &v0;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v1: *UH1 = undefined; _ = &v1;
    var v2: *UH7 = undefined; _ = &v2;
    switch (v0.tag) {
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            v6 = input_suffixes_36(v5);
            return UH7_InputListCons(v0, v6);
        },
        0 => {
            v1 = UH1_InputEmpty();
            v2 = UH7_InputListNil();
            return UH7_InputListCons(v1, v2);
        },
        else => unreachable,
    }
}
fn reference_derivative_40(p0: *UH3, p1: US1) *UH3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
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
    var v4: US1 = undefined; _ = &v4;
    var v20: US3 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: *UH3 = undefined; _ = &v42;
    var v43: *UH3 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = reference_derivative_40(v25, v1);
            v28 = reference_derivative_40(v26, v1);
            return UH3_RegexAlt(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_1(v30);
            switch (v32.tag) {
                1 => {
                    v37 = reference_derivative_40(v30, v1);
                    return UH3_RegexCat(v37, v31);
                },
                0 => {
                    v33 = reference_derivative_40(v30, v1);
                    v34 = reference_derivative_40(v31, v1);
                    v35 = UH3_RegexCat(v33, v31);
                    return UH3_RegexAlt(v35, v34);
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
                            v20 = US3_SymbolSame();
                        },
                        else => {
                            v20 = US3_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US3_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US3_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US3_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US3_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US3_SymbolSame();
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
            v42 = reference_derivative_40(v41, v1);
            v43 = UH3_RegexStar(v41);
            return UH3_RegexCat(v42, v43);
        },
        else => unreachable,
    }
}
fn input_list_append_42(p0: *UH7, p1: *UH7) *UH7 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_42(v3, v1);
            return UH7_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn consume_right_43(p0: *UH3, p1: *UH7) *UH7 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_41(v0, v3);
            v6 = consume_right_43(v0, v4);
            return input_list_append_42(v5, v6);
        },
        0 => {
            return UH7_InputListNil();
        },
        else => unreachable,
    }
}
fn input_equal_47(p0: *UH1, p1: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v22: US3 = undefined; _ = &v22;
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
                                        v22 = US3_SymbolSame();
                                    },
                                    else => {
                                        v22 = US3_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US3_SymbolGreater();
                                    },
                                    else => {
                                        switch (v3.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US3_SymbolSame();
                                                    },
                                                    2 => {
                                                        v22 = US3_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US3_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v22 = US3_SymbolSame();
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
fn input_list_contains_46(p0: *UH1, p1: *UH7) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_47(v0, v2);
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
fn input_list_enqueue_new_45(p0: *UH7, p1: *UH7, p2: *UH7) Tuple1 {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH7 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_46(v3, v1);
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
fn closure_44(p0: *UH3, p1: *UH7, p2: *UH7) *UH7 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
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
                v5 = language_remainders_41(v0, v3);
                tmp5 = input_list_enqueue_new_45(v5, v2, v4);
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
fn language_remainders_41(p0: *UH3, p1: *UH1) *UH7 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v32: *UH3 = undefined; _ = &v32;
    var v33: *UH3 = undefined; _ = &v33;
    var v34: *UH7 = undefined; _ = &v34;
    var v35: *UH7 = undefined; _ = &v35;
    var v37: *UH3 = undefined; _ = &v37;
    var v38: *UH3 = undefined; _ = &v38;
    var v39: *UH7 = undefined; _ = &v39;
    var v5: US1 = undefined; _ = &v5;
    var v7: US1 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v24: US3 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH7 = undefined; _ = &v26;
    var v3: *UH7 = undefined; _ = &v3;
    var v41: *UH3 = undefined; _ = &v41;
    var v42: *UH7 = undefined; _ = &v42;
    var v43: *UH7 = undefined; _ = &v43;
    var v44: *UH7 = undefined; _ = &v44;
    var v45: *UH7 = undefined; _ = &v45;
    switch (v0.tag) {
        3 => {
            v32 = v0.c3_0;
            v33 = v0.c3_1;
            v34 = language_remainders_41(v32, v1);
            v35 = language_remainders_41(v33, v1);
            return input_list_append_42(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = language_remainders_41(v37, v1);
            return consume_right_43(v38, v39);
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
                                    v24 = US3_SymbolSame();
                                },
                                else => {
                                    v24 = US3_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US3_SymbolGreater();
                                },
                                else => {
                                    switch (v5.tag) {
                                        1 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US3_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US3_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US3_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US3_SymbolSame();
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
                        v26 = UH7_InputListNil();
                        return UH7_InputListCons(v8, v26);
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
            v41 = v0.c5_0;
            v42 = UH7_InputListNil();
            v43 = UH7_InputListCons(v1, v42);
            v44 = UH7_InputListNil();
            v45 = UH7_InputListCons(v1, v44);
            return closure_44(v41, v43, v45);
        },
        else => unreachable,
    }
}
fn input_list_remove_48(p0: *UH1, p1: *UH7) *UH7 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH7 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_47(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_48(v0, v4);
                    return UH7_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH7_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_49(p0: *UH7, p1: *UH7) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_46(v2, v1);
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
fn derivative_semantic_triangle_39(p0: *UH3, p1: US1, p2: *UH1) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH7 = undefined; _ = &v7;
    var v8: *UH7 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: *UH7 = undefined; _ = &v15;
    var v16: *UH7 = undefined; _ = &v16;
    var v17: *UH7 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: bool = undefined; _ = &v20;
    var v21: *UH3 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v24: *UH3 = undefined; _ = &v24;
    var v25: *UH3 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v29: *UH3 = undefined; _ = &v29;
    var v30: *UH3 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    var v23: US1 = undefined; _ = &v23;
    var v34: *UH3 = undefined; _ = &v34;
    while (true) {
        v3 = canonical_derivative_13(v0, v1);
        v4 = reference_derivative_40(v0, v1);
        v5 = UH1_InputCons(v1, v2);
        v6 = UH1_InputCons(v1, v2);
        v7 = language_remainders_41(v0, v6);
        v8 = input_list_remove_48(v5, v7);
        v9 = language_remainders_41(v3, v2);
        v10 = input_list_subset_49(v8, v9);
        if (v10) {
            v12 = input_list_subset_49(v9, v8);
        } else {
            v12 = false;
        }
        if (v12) {
            v13 = UH1_InputCons(v1, v2);
            v14 = UH1_InputCons(v1, v2);
            v15 = language_remainders_41(v0, v14);
            v16 = input_list_remove_48(v13, v15);
            v17 = language_remainders_41(v4, v2);
            v18 = input_list_subset_49(v16, v17);
            if (v18) {
                v20 = input_list_subset_49(v17, v16);
            } else {
                v20 = false;
            }
            if (v20) {
                v21 = normalize_14(v4);
                v22 = regex_equal_19(v3, v21);
                if (v22) {
                    switch (v0.tag) {
                        3 => {
                            v24 = v0.c3_0;
                            v25 = v0.c3_1;
                            v26 = derivative_semantic_triangle_39(v24, v1, v2);
                            if (v26) {
                                v0 = v25;
                                continue;
                            } else {
                                return false;
                            }
                        },
                        4 => {
                            v29 = v0.c4_0;
                            v30 = v0.c4_1;
                            v31 = derivative_semantic_triangle_39(v29, v1, v2);
                            if (v31) {
                                v0 = v30;
                                continue;
                            } else {
                                return false;
                            }
                        },
                        2 => {
                            v23 = v0.c2_0;
                            return true;
                        },
                        0 => {
                            return true;
                        },
                        1 => {
                            return true;
                        },
                        5 => {
                            v34 = v0.c5_0;
                            v0 = v34;
                            continue;
                        },
                        else => unreachable,
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        } else {
            return false;
        }
    }
}
fn derivative_semantic_triangle_suffixes_38(p0: *UH3, p1: US1, p2: *UH7) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = derivative_semantic_triangle_39(v0, v1, v3);
                if (v5) {
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
fn derivative_semantic_triangle_symbols_37(p0: *UH3, p1: *UH6, p2: *UH7) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_semantic_triangle_suffixes_38(v0, v3, v2);
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
fn normalization_language_law_suffixes_50(p0: *UH2, p1: *UH5) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_4(v0);
                v5 = language_remainders_27(v0, v2);
                v6 = language_remainders_27(v4, v2);
                v7 = input_list_subset_35(v5, v6);
                if (v7) {
                    v9 = input_list_subset_35(v6, v5);
                } else {
                    v9 = false;
                }
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
fn normalization_language_law_suffixes_51(p0: *UH3, p1: *UH7) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH7 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_14(v0);
                v5 = language_remainders_41(v0, v2);
                v6 = language_remainders_41(v4, v2);
                v7 = input_list_subset_49(v5, v6);
                if (v7) {
                    v9 = input_list_subset_49(v6, v5);
                } else {
                    v9 = false;
                }
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
fn contains_53(p0: US0, p1: *UH4) bool {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v13: US3 = undefined; _ = &v13;
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
                                v13 = US3_SymbolSame();
                            },
                            0 => {
                                v13 = US3_SymbolGreater();
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        switch (v2.tag) {
                            1 => {
                                v13 = US3_SymbolLess();
                            },
                            0 => {
                                v13 = US3_SymbolSame();
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
fn input_symbols_covered_52(p0: *UH0, p1: *UH4) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = contains_53(v2, v1);
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
fn UH8_StateBudgetZero() *UH8 {
    const shared = struct {
        var value: UH8 = UH8{ .tag = 0 };
    };
    return &shared.value;
}
fn UH8_StateBudgetSucc(a0: *UH8) *UH8 {
    return spiralCreate(UH8, UH8{ .tag = 1, .c1_0 = a0 });
}
fn UH9_RegexListNil() *UH9 {
    const shared = struct {
        var value: UH9 = UH9{ .tag = 0 };
    };
    return &shared.value;
}
fn UH9_RegexListCons(a0: *UH2, a1: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn US4_DfaClosureComplete(a0: *UH9) US4 {
    return US4{ .tag = 0, .c0_0 = a0 };
}
fn US4_DfaClosureBudgetExceeded(a0: *UH9) US4 {
    return US4{ .tag = 1, .c1_0 = a0 };
}
fn regex_list_contains_56(p0: *UH2, p1: *UH9) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_equal_9(v0, v2);
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
fn dfa_enqueue_symbols_55(p0: *UH2, p1: *UH4, p2: *UH9, p3: *UH9) Tuple2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH9 = p3; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH9 = undefined; _ = &v10;
    var v11: *UH9 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_3(v0, v4);
                v7 = regex_list_contains_56(v6, v2);
                if (v7) {
                    v1 = v5;
                    continue;
                } else {
                    v10 = UH9_RegexListCons(v6, v2);
                    v11 = UH9_RegexListCons(v6, v3);
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
fn dfa_closure_loop_bounded_54(p0: *UH4, p1: *UH8, p2: *UH9, p3: *UH9) US4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH9 = p3; _ = &v3;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH9 = undefined; _ = &v9;
    var v10: *UH9 = undefined; _ = &v10;
    var tmp5: Tuple2 = undefined; _ = &tmp5;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                switch (v1.tag) {
                    1 => {
                        v8 = v1.c1_0;
                        tmp5 = dfa_enqueue_symbols_55(v5, v0, v2, v6);
                        v9 = tmp5.f0;
                        v10 = tmp5.f1;
                        v1 = v8;
                        v2 = v9;
                        v3 = v10;
                        continue;
                    },
                    0 => {
                        return US4_DfaClosureBudgetExceeded(v2);
                    },
                    else => unreachable,
                }
            },
            0 => {
                return US4_DfaClosureComplete(v2);
            },
            else => unreachable,
        }
    }
}
fn regex_chars_from_symbols_57(p0: *UH4) *UH9 {
    var v0: *UH4 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_chars_from_symbols_57(v3);
            v5 = UH2_RegexChar(v2);
            return UH9_RegexListCons(v5, v4);
        },
        0 => {
            return UH9_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_star_corpus_58(p0: *UH9) *UH9 {
    var v0: *UH9 = p0; _ = &v0;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_star_corpus_58(v3);
            v5 = UH2_RegexStar(v2);
            return UH9_RegexListCons(v5, v4);
        },
        0 => {
            return UH9_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_list_append_60(p0: *UH9, p1: *UH9) *UH9 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_list_append_60(v3, v1);
            return UH9_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_pairs_with_61(p0: *UH2, p1: *UH9) *UH9 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH9 = undefined; _ = &v8;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = regex_pairs_with_61(v0, v4);
            v6 = UH2_RegexAlt(v0, v3);
            v7 = UH2_RegexCat(v0, v3);
            v8 = UH9_RegexListCons(v7, v5);
            return UH9_RegexListCons(v6, v8);
        },
        0 => {
            return UH9_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_binary_corpus_59(p0: *UH9, p1: *UH9) *UH9 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = regex_pairs_with_61(v3, v1);
            v6 = regex_binary_corpus_59(v4, v1);
            return regex_list_append_60(v5, v6);
        },
        0 => {
            return UH9_RegexListNil();
        },
        else => unreachable,
    }
}
fn derivative_language_law_suffixes_64(p0: *UH2, p1: US0, p2: *UH5) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH0 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH5 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v13: bool = undefined; _ = &v13;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = canonical_derivative_3(v0, v1);
                v6 = UH0_InputCons(v1, v3);
                v7 = UH0_InputCons(v1, v3);
                v8 = language_remainders_27(v0, v7);
                v9 = input_list_remove_34(v6, v8);
                v10 = language_remainders_27(v5, v3);
                v11 = input_list_subset_35(v9, v10);
                if (v11) {
                    v13 = input_list_subset_35(v10, v9);
                } else {
                    v13 = false;
                }
                if (v13) {
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
fn derivative_language_law_symbols_63(p0: *UH2, p1: *UH4, p2: *UH5) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_language_law_suffixes_64(v0, v3, v2);
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
fn derivative_language_law_corpus_62(p0: *UH9, p1: *UH4, p2: *UH5) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = derivative_language_law_symbols_63(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn UH10_RegexListNil() *UH10 {
    const shared = struct {
        var value: UH10 = UH10{ .tag = 0 };
    };
    return &shared.value;
}
fn UH10_RegexListCons(a0: *UH3, a1: *UH10) *UH10 {
    return spiralCreate(UH10, UH10{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn derivative_language_law_suffixes_67(p0: *UH3, p1: US1, p2: *UH7) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH7 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    var v10: *UH7 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v13: bool = undefined; _ = &v13;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = canonical_derivative_13(v0, v1);
                v6 = UH1_InputCons(v1, v3);
                v7 = UH1_InputCons(v1, v3);
                v8 = language_remainders_41(v0, v7);
                v9 = input_list_remove_48(v6, v8);
                v10 = language_remainders_41(v5, v3);
                v11 = input_list_subset_49(v9, v10);
                if (v11) {
                    v13 = input_list_subset_49(v10, v9);
                } else {
                    v13 = false;
                }
                if (v13) {
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
fn derivative_language_law_symbols_66(p0: *UH3, p1: *UH6, p2: *UH7) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_language_law_suffixes_67(v0, v3, v2);
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
fn derivative_language_law_corpus_65(p0: *UH10, p1: *UH6, p2: *UH7) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH7 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = derivative_language_law_symbols_66(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn normalization_language_law_corpus_68(p0: *UH9, p1: *UH5) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = normalization_language_law_suffixes_50(v2, v1);
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
fn normalization_language_law_corpus_69(p0: *UH10, p1: *UH7) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = normalization_language_law_suffixes_51(v2, v1);
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
fn input_singletons_from_symbols_71(p0: *UH4) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_71(v3);
            v5 = UH0_InputEmpty();
            v6 = UH0_InputCons(v2, v5);
            return UH5_InputListCons(v6, v4);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_73(p0: US0, p1: *UH5) *UH5 {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_73(v0, v4);
            v6 = UH0_InputCons(v0, v3);
            return UH5_InputListCons(v6, v5);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_72(p0: *UH4, p1: *UH5) *UH5 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_73(v3, v1);
            v6 = input_prepend_symbols_to_corpus_72(v4, v1);
            return input_list_append_28(v5, v6);
        },
        0 => {
            return UH5_InputListNil();
        },
        else => unreachable,
    }
}
fn dfa_formula_consistent_70(p0: *UH9, p1: *UH4) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH0 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_singletons_from_symbols_71(v1);
                v5 = UH0_InputEmpty();
                v6 = UH5_InputListCons(v5, v4);
                v7 = input_singletons_from_symbols_71(v1);
                v8 = input_prepend_symbols_to_corpus_72(v1, v7);
                v9 = input_list_append_28(v6, v8);
                v10 = derivative_semantic_triangle_symbols_23(v2, v1, v9);
                if (v10) {
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
fn dfa_states_nullable_preserved_74(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: US2 = undefined; _ = &v5;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = nullable_0(v1);
                v4 = normalize_4(v1);
                v5 = nullable_0(v4);
                switch (v3.tag) {
                    1 => {
                        switch (v5.tag) {
                            1 => {
                                v9 = true;
                            },
                            else => {
                                v9 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v5.tag) {
                            0 => {
                                v9 = true;
                            },
                            else => {
                                v9 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v9) {
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
fn regex_list_normalization_idempotent_75(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_4(v1);
                v4 = normalize_4(v1);
                v5 = normalize_4(v4);
                v6 = regex_equal_9(v3, v5);
                if (v6) {
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
fn canonical_derivative_coherent_symbols_77(p0: *UH2, p1: *UH4) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_4(v0);
                v5 = derivative_11(v4, v2);
                v6 = normalize_4(v5);
                v7 = derivative_11(v0, v2);
                v8 = normalize_4(v7);
                v9 = regex_equal_9(v6, v8);
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
fn canonical_derivative_coherent_corpus_76(p0: *UH9, p1: *UH4) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = canonical_derivative_coherent_symbols_77(v2, v1);
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
fn canonical_derivative_coherent_symbols_79(p0: *UH3, p1: *UH6) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH3 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = normalize_14(v0);
                v5 = derivative_21(v4, v2);
                v6 = normalize_14(v5);
                v7 = derivative_21(v0, v2);
                v8 = normalize_14(v7);
                v9 = regex_equal_19(v6, v8);
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
fn canonical_derivative_coherent_corpus_78(p0: *UH10, p1: *UH6) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = canonical_derivative_coherent_symbols_79(v2, v1);
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
fn dfa_closure_loop_80(p0: *UH4, p1: *UH9, p2: *UH9) *UH9 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH9 = undefined; _ = &v6;
    var tmp4: Tuple2 = undefined; _ = &tmp4;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                tmp4 = dfa_enqueue_symbols_55(v3, v0, v1, v4);
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
fn dfa_state_signature_transitions_same_83(p0: *UH2, p1: *UH2, p2: *UH4) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = canonical_derivative_3(v0, v3);
                v6 = canonical_derivative_3(v1, v3);
                v7 = regex_equal_9(v5, v6);
                if (v7) {
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
fn dfa_state_signature_against_82(p0: *UH2, p1: *UH9, p2: *UH4) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: US2 = undefined; _ = &v5;
    var v6: US2 = undefined; _ = &v6;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = nullable_0(v0);
                v6 = nullable_0(v3);
                switch (v5.tag) {
                    1 => {
                        switch (v6.tag) {
                            1 => {
                                v10 = true;
                            },
                            else => {
                                v10 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v6.tag) {
                            0 => {
                                v10 = true;
                            },
                            else => {
                                v10 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v10) {
                    v12 = dfa_state_signature_transitions_same_83(v0, v3, v2);
                } else {
                    v12 = false;
                }
                if (v12) {
                    return false;
                } else {
                    v1 = v4;
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
fn dfa_partition_one_distinct_81(p0: *UH9, p1: *UH4) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_signature_against_82(v2, v3, v1);
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
fn regex_list_contains_86(p0: *UH3, p1: *UH10) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
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
fn dfa_enqueue_symbols_85(p0: *UH3, p1: *UH6, p2: *UH10, p3: *UH10) Tuple3 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH10 = p3; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v10: *UH10 = undefined; _ = &v10;
    var v11: *UH10 = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = canonical_derivative_13(v0, v4);
                v7 = regex_list_contains_86(v6, v2);
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
                return Tuple3{ .f0 = v2, .f1 = v3 };
            },
            else => unreachable,
        }
    }
}
fn dfa_closure_loop_84(p0: *UH6, p1: *UH10, p2: *UH10) *UH10 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: *UH10 = undefined; _ = &v5;
    var v6: *UH10 = undefined; _ = &v6;
    var tmp4: Tuple3 = undefined; _ = &tmp4;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                tmp4 = dfa_enqueue_symbols_85(v3, v0, v1, v4);
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
fn dfa_state_signature_transitions_same_89(p0: *UH3, p1: *UH3, p2: *UH6) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = canonical_derivative_13(v0, v3);
                v6 = canonical_derivative_13(v1, v3);
                v7 = regex_equal_19(v5, v6);
                if (v7) {
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
fn dfa_state_signature_against_88(p0: *UH3, p1: *UH10, p2: *UH6) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: US2 = undefined; _ = &v5;
    var v6: US2 = undefined; _ = &v6;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = nullable_1(v0);
                v6 = nullable_1(v3);
                switch (v5.tag) {
                    1 => {
                        switch (v6.tag) {
                            1 => {
                                v10 = true;
                            },
                            else => {
                                v10 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v6.tag) {
                            0 => {
                                v10 = true;
                            },
                            else => {
                                v10 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v10) {
                    v12 = dfa_state_signature_transitions_same_89(v0, v3, v2);
                } else {
                    v12 = false;
                }
                if (v12) {
                    return false;
                } else {
                    v1 = v4;
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
fn dfa_partition_one_distinct_87(p0: *UH10, p1: *UH6) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_signature_against_88(v2, v3, v1);
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
fn UH11_DfaStatePairNil() *UH11 {
    const shared = struct {
        var value: UH11 = UH11{ .tag = 0 };
    };
    return &shared.value;
}
fn UH11_DfaStatePairCons(a0: *UH2, a1: *UH2, a2: *UH11) *UH11 {
    return spiralCreate(UH11, UH11{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 });
}
fn dfa_state_pair_list_contains_93(p0: *UH2, p1: *UH2, p2: *UH11) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
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
                v6 = regex_equal_9(v0, v3);
                if (v6) {
                    v11 = regex_equal_9(v1, v4);
                } else {
                    v8 = regex_equal_9(v0, v4);
                    if (v8) {
                        v11 = regex_equal_9(v1, v3);
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
fn dfa_state_pair_enqueue_symbols_94(p0: *UH2, p1: *UH2, p2: *UH4, p3: *UH11) *UH11 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH11 = p3; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = canonical_derivative_3(v0, v4);
                v7 = canonical_derivative_3(v1, v4);
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
fn dfa_bisimulation_work_92(p0: *UH4, p1: *UH11, p2: *UH11) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH11 = p1; _ = &v1;
    var v2: *UH11 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH11 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v8: bool = undefined; _ = &v8;
    var v10: US2 = undefined; _ = &v10;
    var v11: US2 = undefined; _ = &v11;
    var v15: bool = undefined; _ = &v15;
    var v16: *UH11 = undefined; _ = &v16;
    var v17: *UH11 = undefined; _ = &v17;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = v1.c1_2;
                v6 = regex_equal_9(v3, v4);
                if (v6) {
                    v1 = v5;
                    continue;
                } else {
                    v8 = dfa_state_pair_list_contains_93(v3, v4, v2);
                    if (v8) {
                        v1 = v5;
                        continue;
                    } else {
                        v10 = nullable_0(v3);
                        v11 = nullable_0(v4);
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
                            v16 = dfa_state_pair_enqueue_symbols_94(v3, v4, v0, v5);
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
fn dfa_state_behaviorally_distinct_against_91(p0: *UH2, p1: *UH9, p2: *UH4) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH11 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    var v9: *UH11 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = normalize_4(v0);
                v6 = normalize_4(v3);
                v7 = UH11_DfaStatePairNil();
                v8 = UH11_DfaStatePairCons(v5, v6, v7);
                v9 = UH11_DfaStatePairNil();
                v10 = dfa_bisimulation_work_92(v2, v8, v9);
                if (v10) {
                    return false;
                } else {
                    v1 = v4;
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
fn dfa_minimal_by_bisimulation_90(p0: *UH9, p1: *UH4) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_behaviorally_distinct_against_91(v2, v3, v1);
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
fn UH12_DfaStatePairNil() *UH12 {
    const shared = struct {
        var value: UH12 = UH12{ .tag = 0 };
    };
    return &shared.value;
}
fn UH12_DfaStatePairCons(a0: *UH3, a1: *UH3, a2: *UH12) *UH12 {
    return spiralCreate(UH12, UH12{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 });
}
fn dfa_state_pair_list_contains_98(p0: *UH3, p1: *UH3, p2: *UH12) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH12 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH12 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v11: bool = undefined; _ = &v11;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = v2.c1_2;
                v6 = regex_equal_19(v0, v3);
                if (v6) {
                    v11 = regex_equal_19(v1, v4);
                } else {
                    v8 = regex_equal_19(v0, v4);
                    if (v8) {
                        v11 = regex_equal_19(v1, v3);
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
fn dfa_state_pair_enqueue_symbols_99(p0: *UH3, p1: *UH3, p2: *UH6, p3: *UH12) *UH12 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH12 = p3; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH12 = undefined; _ = &v8;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = canonical_derivative_13(v0, v4);
                v7 = canonical_derivative_13(v1, v4);
                v8 = UH12_DfaStatePairCons(v6, v7, v3);
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
fn dfa_bisimulation_work_97(p0: *UH6, p1: *UH12, p2: *UH12) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH12 = p1; _ = &v1;
    var v2: *UH12 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH12 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    var v8: bool = undefined; _ = &v8;
    var v10: US2 = undefined; _ = &v10;
    var v11: US2 = undefined; _ = &v11;
    var v15: bool = undefined; _ = &v15;
    var v16: *UH12 = undefined; _ = &v16;
    var v17: *UH12 = undefined; _ = &v17;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = v1.c1_2;
                v6 = regex_equal_19(v3, v4);
                if (v6) {
                    v1 = v5;
                    continue;
                } else {
                    v8 = dfa_state_pair_list_contains_98(v3, v4, v2);
                    if (v8) {
                        v1 = v5;
                        continue;
                    } else {
                        v10 = nullable_1(v3);
                        v11 = nullable_1(v4);
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
                            v16 = dfa_state_pair_enqueue_symbols_99(v3, v4, v0, v5);
                            v17 = UH12_DfaStatePairCons(v3, v4, v2);
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
fn dfa_state_behaviorally_distinct_against_96(p0: *UH3, p1: *UH10, p2: *UH6) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH12 = undefined; _ = &v7;
    var v8: *UH12 = undefined; _ = &v8;
    var v9: *UH12 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = normalize_14(v0);
                v6 = normalize_14(v3);
                v7 = UH12_DfaStatePairNil();
                v8 = UH12_DfaStatePairCons(v5, v6, v7);
                v9 = UH12_DfaStatePairNil();
                v10 = dfa_bisimulation_work_97(v2, v8, v9);
                if (v10) {
                    return false;
                } else {
                    v1 = v4;
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
fn dfa_minimal_by_bisimulation_95(p0: *UH10, p1: *UH6) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = dfa_state_behaviorally_distinct_against_96(v2, v3, v1);
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
fn US5_BitMatcherRaw(a0: *UH2, a1: *UH0) US5 {
    return US5{ .tag = 0, .c0_0 = a0, .c0_1 = a1 };
}
fn US6_BitMatcherDecided(a0: *UH2, a1: *UH0, a2: bool) US6 {
    return US6{ .tag = 0, .c0_0 = a0, .c0_1 = a1, .c0_2 = a2 };
}
fn decide_bit_match_100(p0: US5) US6 {
    var v0: US5 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = accepts_2(v1, v2);
            return US6_BitMatcherDecided(v1, v2, v3);
        },
        else => unreachable,
    }
}
fn bit_match_value_101(p0: US6) bool {
    var v0: US6 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH0 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            v3 = v0.c0_2;
            return v3;
        },
        else => unreachable,
    }
}
fn state_budget_add_103(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = state_budget_add_103(v2, v1);
            return UH8_StateBudgetSucc(v3);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_position_count_102(p0: *UH2) *UH8 {
    var v0: *UH2 = p0; _ = &v0;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH8 = undefined; _ = &v9;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: *UH8 = undefined; _ = &v14;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v16: *UH2 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_102(v6);
                v9 = regex_position_count_102(v7);
                return state_budget_add_103(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_102(v11);
                v14 = regex_position_count_102(v12);
                return state_budget_add_103(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH8_StateBudgetZero();
                return UH8_StateBudgetSucc(v4);
            },
            0 => {
                return UH8_StateBudgetZero();
            },
            1 => {
                return UH8_StateBudgetZero();
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
fn state_budget_pow2_104(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v1: *UH8 = undefined; _ = &v1;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = state_budget_pow2_104(v3);
            return state_budget_add_103(v4, v4);
        },
        0 => {
            v1 = UH8_StateBudgetZero();
            return UH8_StateBudgetSucc(v1);
        },
        else => unreachable,
    }
}
fn UH13_DfaTransitionNil() *UH13 {
    const shared = struct {
        var value: UH13 = UH13{ .tag = 0 };
    };
    return &shared.value;
}
fn UH13_DfaTransitionCons(a0: *UH2, a1: US0, a2: *UH2, a3: *UH13) *UH13 {
    return spiralCreate(UH13, UH13{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2, .c1_3 = a3 });
}
fn dfa_transition_append_106(p0: *UH13, p1: *UH13) *UH13 {
    var v0: *UH13 = p0; _ = &v0;
    var v1: *UH13 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH13 = undefined; _ = &v5;
    var v6: *UH13 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = v0.c1_2;
            v5 = v0.c1_3;
            v6 = dfa_transition_append_106(v5, v1);
            return UH13_DfaTransitionCons(v2, v3, v4, v6);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn dfa_transitions_from_state_107(p0: *UH2, p1: *UH4) *UH13 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH13 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = canonical_derivative_3(v0, v3);
            v6 = dfa_transitions_from_state_107(v0, v4);
            return UH13_DfaTransitionCons(v0, v3, v5, v6);
        },
        0 => {
            return UH13_DfaTransitionNil();
        },
        else => unreachable,
    }
}
fn dfa_transition_table_105(p0: *UH9, p1: *UH4) *UH13 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: *UH13 = undefined; _ = &v5;
    var v6: *UH13 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = dfa_transitions_from_state_107(v3, v1);
            v6 = dfa_transition_table_105(v4, v1);
            return dfa_transition_append_106(v5, v6);
        },
        0 => {
            return UH13_DfaTransitionNil();
        },
        else => unreachable,
    }
}
fn dfa_state_closed_109(p0: *UH2, p1: *UH4, p2: *UH9) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = canonical_derivative_3(v0, v3);
                v6 = regex_list_contains_56(v5, v2);
                if (v6) {
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
fn dfa_closure_closed_108(p0: *UH9, p1: *UH4, p2: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_state_closed_109(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn regex_list_distinct_110(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_list_contains_56(v1, v2);
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
fn US7_DfaTransitionFound(a0: *UH2) US7 {
    return US7{ .tag = 0, .c0_0 = a0 };
}
fn US7_DfaTransitionMissing() US7 {
    return US7{ .tag = 1 };
}
fn dfa_transition_lookup_value_113(p0: *UH2, p1: US0, p2: *UH13) US7 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH13 = p2; _ = &v2;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH13 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v18: US3 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = v2.c1_2;
                v7 = v2.c1_3;
                v8 = regex_equal_9(v0, v4);
                if (v8) {
                    switch (v1.tag) {
                        1 => {
                            switch (v5.tag) {
                                1 => {
                                    v18 = US3_SymbolSame();
                                },
                                0 => {
                                    v18 = US3_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v5.tag) {
                                1 => {
                                    v18 = US3_SymbolLess();
                                },
                                0 => {
                                    v18 = US3_SymbolSame();
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
                        return US7_DfaTransitionFound(v6);
                    } else {
                        v2 = v7;
                        continue;
                    }
                } else {
                    v2 = v7;
                    continue;
                }
            },
            0 => {
                return US7_DfaTransitionMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_state_transition_total_112(p0: *UH2, p1: *UH4, p2: *UH13) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH13 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: US7 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = dfa_transition_lookup_value_113(v0, v3, v2);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v7 = canonical_derivative_3(v0, v3);
                        v8 = regex_equal_9(v6, v7);
                        if (v8) {
                            v1 = v4;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    1 => {
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
fn dfa_transition_table_total_111(p0: *UH9, p1: *UH4, p2: *UH13) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH13 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_state_transition_total_112(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn dfa_transition_key_present_115(p0: *UH2, p1: US0, p2: *UH13) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH13 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH13 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v17: US3 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = v2.c1_2;
                v6 = v2.c1_3;
                v7 = regex_equal_9(v0, v3);
                if (v7) {
                    switch (v1.tag) {
                        1 => {
                            switch (v4.tag) {
                                1 => {
                                    v17 = US3_SymbolSame();
                                },
                                0 => {
                                    v17 = US3_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v4.tag) {
                                1 => {
                                    v17 = US3_SymbolLess();
                                },
                                0 => {
                                    v17 = US3_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v17.tag) {
                        1 => {
                            v18 = true;
                        },
                        else => {
                            v18 = false;
                        },
                    }
                    if (v18) {
                        return true;
                    } else {
                        v2 = v6;
                        continue;
                    }
                } else {
                    v2 = v6;
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
fn dfa_transition_keys_distinct_114(p0: *UH13) bool {
    var v0: *UH13 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH13 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = v0.c1_2;
                v4 = v0.c1_3;
                v5 = dfa_transition_key_present_115(v1, v2, v4);
                if (v5) {
                    return false;
                } else {
                    v0 = v4;
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
fn regex_list_within_budget_116(p0: *UH9, p1: *UH8) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v4 = v1.c1_0;
                        v0 = v3;
                        v1 = v4;
                        continue;
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
fn dfa_states_normalized_117(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_4(v1);
                v4 = regex_equal_9(v1, v3);
                if (v4) {
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
fn regex_compare_against_119(p0: *UH2, p1: *UH9) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH9 = undefined; _ = &v3;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v12: bool = undefined; _ = &v12;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_compare_7(v0, v2);
                v5 = regex_compare_7(v2, v0);
                switch (v4.tag) {
                    2 => {
                        switch (v5.tag) {
                            0 => {
                                v12 = true;
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v5.tag) {
                            2 => {
                                v12 = true;
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    1 => {
                        switch (v5.tag) {
                            1 => {
                                v12 = regex_equal_9(v0, v2);
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v12) {
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
fn regex_order_laws_118(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH9 = undefined; _ = &v2;
    var v3: US3 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_compare_7(v1, v1);
                switch (v3.tag) {
                    1 => {
                        v4 = regex_compare_against_119(v1, v2);
                        if (v4) {
                            v0 = v2;
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
                return true;
            },
            else => unreachable,
        }
    }
}
fn regex_position_count_120(p0: *UH3) *UH8 {
    var v0: *UH3 = p0; _ = &v0;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH8 = undefined; _ = &v9;
    var v11: *UH3 = undefined; _ = &v11;
    var v12: *UH3 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: *UH8 = undefined; _ = &v14;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v16: *UH3 = undefined; _ = &v16;
    while (true) {
        switch (v0.tag) {
            3 => {
                v6 = v0.c3_0;
                v7 = v0.c3_1;
                v8 = regex_position_count_120(v6);
                v9 = regex_position_count_120(v7);
                return state_budget_add_103(v8, v9);
            },
            4 => {
                v11 = v0.c4_0;
                v12 = v0.c4_1;
                v13 = regex_position_count_120(v11);
                v14 = regex_position_count_120(v12);
                return state_budget_add_103(v13, v14);
            },
            2 => {
                v3 = v0.c2_0;
                v4 = UH8_StateBudgetZero();
                return UH8_StateBudgetSucc(v4);
            },
            0 => {
                return UH8_StateBudgetZero();
            },
            1 => {
                return UH8_StateBudgetZero();
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
fn US8_DfaClosureComplete(a0: *UH10) US8 {
    return US8{ .tag = 0, .c0_0 = a0 };
}
fn US8_DfaClosureBudgetExceeded(a0: *UH10) US8 {
    return US8{ .tag = 1, .c1_0 = a0 };
}
fn dfa_closure_loop_bounded_121(p0: *UH6, p1: *UH8, p2: *UH10, p3: *UH10) US8 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH10 = p3; _ = &v3;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH10 = undefined; _ = &v6;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH10 = undefined; _ = &v9;
    var v10: *UH10 = undefined; _ = &v10;
    var tmp5: Tuple3 = undefined; _ = &tmp5;
    while (true) {
        switch (v3.tag) {
            1 => {
                v5 = v3.c1_0;
                v6 = v3.c1_1;
                switch (v1.tag) {
                    1 => {
                        v8 = v1.c1_0;
                        tmp5 = dfa_enqueue_symbols_85(v5, v0, v2, v6);
                        v9 = tmp5.f0;
                        v10 = tmp5.f1;
                        v1 = v8;
                        v2 = v9;
                        v3 = v10;
                        continue;
                    },
                    0 => {
                        return US8_DfaClosureBudgetExceeded(v2);
                    },
                    else => unreachable,
                }
            },
            0 => {
                return US8_DfaClosureComplete(v2);
            },
            else => unreachable,
        }
    }
}
fn UH14_DfaTransitionNil() *UH14 {
    const shared = struct {
        var value: UH14 = UH14{ .tag = 0 };
    };
    return &shared.value;
}
fn UH14_DfaTransitionCons(a0: *UH3, a1: US1, a2: *UH3, a3: *UH14) *UH14 {
    return spiralCreate(UH14, UH14{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2, .c1_3 = a3 });
}
fn dfa_transition_append_123(p0: *UH14, p1: *UH14) *UH14 {
    var v0: *UH14 = p0; _ = &v0;
    var v1: *UH14 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH14 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = v0.c1_2;
            v5 = v0.c1_3;
            v6 = dfa_transition_append_123(v5, v1);
            return UH14_DfaTransitionCons(v2, v3, v4, v6);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn dfa_transitions_from_state_124(p0: *UH3, p1: *UH6) *UH14 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = canonical_derivative_13(v0, v3);
            v6 = dfa_transitions_from_state_124(v0, v4);
            return UH14_DfaTransitionCons(v0, v3, v5, v6);
        },
        0 => {
            return UH14_DfaTransitionNil();
        },
        else => unreachable,
    }
}
fn dfa_transition_table_122(p0: *UH10, p1: *UH6) *UH14 {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: *UH14 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = dfa_transitions_from_state_124(v3, v1);
            v6 = dfa_transition_table_122(v4, v1);
            return dfa_transition_append_123(v5, v6);
        },
        0 => {
            return UH14_DfaTransitionNil();
        },
        else => unreachable,
    }
}
fn dfa_state_closed_126(p0: *UH3, p1: *UH6, p2: *UH10) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = canonical_derivative_13(v0, v3);
                v6 = regex_list_contains_86(v5, v2);
                if (v6) {
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
fn dfa_closure_closed_125(p0: *UH10, p1: *UH6, p2: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_state_closed_126(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn regex_list_distinct_127(p0: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    var v2: *UH10 = undefined; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_list_contains_86(v1, v2);
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
fn input_singletons_from_symbols_129(p0: *UH6) *UH7 {
    var v0: *UH6 = p0; _ = &v0;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_129(v3);
            v5 = UH1_InputEmpty();
            v6 = UH1_InputCons(v2, v5);
            return UH7_InputListCons(v6, v4);
        },
        0 => {
            return UH7_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_131(p0: US1, p1: *UH7) *UH7 {
    var v0: US1 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_131(v0, v4);
            v6 = UH1_InputCons(v0, v3);
            return UH7_InputListCons(v6, v5);
        },
        0 => {
            return UH7_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_130(p0: *UH6, p1: *UH7) *UH7 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH7 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_131(v3, v1);
            v6 = input_prepend_symbols_to_corpus_130(v4, v1);
            return input_list_append_42(v5, v6);
        },
        0 => {
            return UH7_InputListNil();
        },
        else => unreachable,
    }
}
fn dfa_formula_consistent_128(p0: *UH10, p1: *UH6) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: *UH7 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH7 = undefined; _ = &v6;
    var v7: *UH7 = undefined; _ = &v7;
    var v8: *UH7 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_singletons_from_symbols_129(v1);
                v5 = UH1_InputEmpty();
                v6 = UH7_InputListCons(v5, v4);
                v7 = input_singletons_from_symbols_129(v1);
                v8 = input_prepend_symbols_to_corpus_130(v1, v7);
                v9 = input_list_append_42(v6, v8);
                v10 = derivative_semantic_triangle_symbols_37(v2, v1, v9);
                if (v10) {
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
fn US9_DfaTransitionFound(a0: *UH3) US9 {
    return US9{ .tag = 0, .c0_0 = a0 };
}
fn US9_DfaTransitionMissing() US9 {
    return US9{ .tag = 1 };
}
fn dfa_transition_lookup_value_134(p0: *UH3, p1: US1, p2: *UH14) US9 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH14 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    var v24: US3 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    while (true) {
        switch (v2.tag) {
            1 => {
                v4 = v2.c1_0;
                v5 = v2.c1_1;
                v6 = v2.c1_2;
                v7 = v2.c1_3;
                v8 = regex_equal_19(v0, v4);
                if (v8) {
                    switch (v1.tag) {
                        0 => {
                            switch (v5.tag) {
                                0 => {
                                    v24 = US3_SymbolSame();
                                },
                                else => {
                                    v24 = US3_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v5.tag) {
                                0 => {
                                    v24 = US3_SymbolGreater();
                                },
                                else => {
                                    switch (v1.tag) {
                                        1 => {
                                            switch (v5.tag) {
                                                1 => {
                                                    v24 = US3_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US3_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v5.tag) {
                                                1 => {
                                                    v24 = US3_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US3_SymbolSame();
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
                        return US9_DfaTransitionFound(v6);
                    } else {
                        v2 = v7;
                        continue;
                    }
                } else {
                    v2 = v7;
                    continue;
                }
            },
            0 => {
                return US9_DfaTransitionMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_state_transition_total_133(p0: *UH3, p1: *UH6, p2: *UH14) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: US9 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: bool = undefined; _ = &v8;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = dfa_transition_lookup_value_134(v0, v3, v2);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v7 = canonical_derivative_13(v0, v3);
                        v8 = regex_equal_19(v6, v7);
                        if (v8) {
                            v1 = v4;
                            continue;
                        } else {
                            return false;
                        }
                    },
                    1 => {
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
fn dfa_transition_table_total_132(p0: *UH10, p1: *UH6, p2: *UH14) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_state_transition_total_133(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn dfa_transition_key_present_136(p0: *UH3, p1: US1, p2: *UH14) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH14 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: *UH14 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v23: US3 = undefined; _ = &v23;
    var v24: bool = undefined; _ = &v24;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = v2.c1_2;
                v6 = v2.c1_3;
                v7 = regex_equal_19(v0, v3);
                if (v7) {
                    switch (v1.tag) {
                        0 => {
                            switch (v4.tag) {
                                0 => {
                                    v23 = US3_SymbolSame();
                                },
                                else => {
                                    v23 = US3_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v4.tag) {
                                0 => {
                                    v23 = US3_SymbolGreater();
                                },
                                else => {
                                    switch (v1.tag) {
                                        1 => {
                                            switch (v4.tag) {
                                                1 => {
                                                    v23 = US3_SymbolSame();
                                                },
                                                2 => {
                                                    v23 = US3_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v4.tag) {
                                                1 => {
                                                    v23 = US3_SymbolGreater();
                                                },
                                                2 => {
                                                    v23 = US3_SymbolSame();
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
                    switch (v23.tag) {
                        1 => {
                            v24 = true;
                        },
                        else => {
                            v24 = false;
                        },
                    }
                    if (v24) {
                        return true;
                    } else {
                        v2 = v6;
                        continue;
                    }
                } else {
                    v2 = v6;
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
fn dfa_transition_keys_distinct_135(p0: *UH14) bool {
    var v0: *UH14 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH14 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = v0.c1_2;
                v4 = v0.c1_3;
                v5 = dfa_transition_key_present_136(v1, v2, v4);
                if (v5) {
                    return false;
                } else {
                    v0 = v4;
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
fn regex_list_within_budget_137(p0: *UH10, p1: *UH8) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                switch (v1.tag) {
                    1 => {
                        v4 = v1.c1_0;
                        v0 = v3;
                        v1 = v4;
                        continue;
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
fn dfa_states_normalized_138(p0: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    var v2: *UH10 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_14(v1);
                v4 = regex_equal_19(v1, v3);
                if (v4) {
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
fn dfa_states_nullable_preserved_139(p0: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    var v2: *UH10 = undefined; _ = &v2;
    var v3: US2 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: US2 = undefined; _ = &v5;
    var v9: bool = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = nullable_1(v1);
                v4 = normalize_14(v1);
                v5 = nullable_1(v4);
                switch (v3.tag) {
                    1 => {
                        switch (v5.tag) {
                            1 => {
                                v9 = true;
                            },
                            else => {
                                v9 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v5.tag) {
                            0 => {
                                v9 = true;
                            },
                            else => {
                                v9 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v9) {
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
fn regex_compare_against_141(p0: *UH3, p1: *UH10) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH3 = undefined; _ = &v2;
    var v3: *UH10 = undefined; _ = &v3;
    var v4: US3 = undefined; _ = &v4;
    var v5: US3 = undefined; _ = &v5;
    var v12: bool = undefined; _ = &v12;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = regex_compare_17(v0, v2);
                v5 = regex_compare_17(v2, v0);
                switch (v4.tag) {
                    2 => {
                        switch (v5.tag) {
                            0 => {
                                v12 = true;
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    0 => {
                        switch (v5.tag) {
                            2 => {
                                v12 = true;
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    1 => {
                        switch (v5.tag) {
                            1 => {
                                v12 = regex_equal_19(v0, v2);
                            },
                            else => {
                                v12 = false;
                            },
                        }
                    },
                    else => unreachable,
                }
                if (v12) {
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
fn regex_order_laws_140(p0: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH3 = undefined; _ = &v1;
    var v2: *UH10 = undefined; _ = &v2;
    var v3: US3 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = regex_compare_17(v1, v1);
                switch (v3.tag) {
                    1 => {
                        v4 = regex_compare_against_141(v1, v2);
                        if (v4) {
                            v0 = v2;
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
                return true;
            },
            else => unreachable,
        }
    }
}
fn US10_DfaRepresentativeFound(a0: *UH2) US10 {
    return US10{ .tag = 0, .c0_0 = a0 };
}
fn US10_DfaRepresentativeMissing() US10 {
    return US10{ .tag = 1 };
}
fn dfa_find_bisimilar_representative_143(p0: *UH2, p1: *UH9, p2: *UH4) US10 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH11 = undefined; _ = &v8;
    var v9: *UH11 = undefined; _ = &v9;
    var v10: *UH11 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = normalize_4(v0);
                v7 = normalize_4(v4);
                v8 = UH11_DfaStatePairNil();
                v9 = UH11_DfaStatePairCons(v6, v7, v8);
                v10 = UH11_DfaStatePairNil();
                v11 = dfa_bisimulation_work_92(v2, v9, v10);
                if (v11) {
                    return US10_DfaRepresentativeFound(v4);
                } else {
                    v1 = v5;
                    continue;
                }
            },
            0 => {
                return US10_DfaRepresentativeMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_minimize_states_loop_142(p0: *UH9, p1: *UH4, p2: *UH9) *UH9 {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: US10 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v8: *UH9 = undefined; _ = &v8;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_143(v3, v2, v1);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v0 = v4;
                        continue;
                    },
                    1 => {
                        v8 = UH9_RegexListCons(v3, v2);
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
fn dfa_states_have_representative_144(p0: *UH9, p1: *UH9, p2: *UH4) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: US10 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_143(v3, v1, v2);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v0 = v4;
                        continue;
                    },
                    1 => {
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
fn dfa_quotient_state_closed_146(p0: *UH2, p1: *UH4, p2: *UH9) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: US10 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = canonical_derivative_3(v0, v3);
                v6 = dfa_find_bisimilar_representative_143(v5, v2, v1);
                switch (v6.tag) {
                    0 => {
                        v7 = v6.c0_0;
                        v1 = v4;
                        continue;
                    },
                    1 => {
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
fn dfa_quotient_closed_145(p0: *UH9, p1: *UH4, p2: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH9 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH9 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_quotient_state_closed_146(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn US11_DfaRepresentativeFound(a0: *UH3) US11 {
    return US11{ .tag = 0, .c0_0 = a0 };
}
fn US11_DfaRepresentativeMissing() US11 {
    return US11{ .tag = 1 };
}
fn dfa_find_bisimilar_representative_148(p0: *UH3, p1: *UH10, p2: *UH6) US11 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH10 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v8: *UH12 = undefined; _ = &v8;
    var v9: *UH12 = undefined; _ = &v9;
    var v10: *UH12 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    while (true) {
        switch (v1.tag) {
            1 => {
                v4 = v1.c1_0;
                v5 = v1.c1_1;
                v6 = normalize_14(v0);
                v7 = normalize_14(v4);
                v8 = UH12_DfaStatePairNil();
                v9 = UH12_DfaStatePairCons(v6, v7, v8);
                v10 = UH12_DfaStatePairNil();
                v11 = dfa_bisimulation_work_97(v2, v9, v10);
                if (v11) {
                    return US11_DfaRepresentativeFound(v4);
                } else {
                    v1 = v5;
                    continue;
                }
            },
            0 => {
                return US11_DfaRepresentativeMissing();
            },
            else => unreachable,
        }
    }
}
fn dfa_minimize_states_loop_147(p0: *UH10, p1: *UH6, p2: *UH10) *UH10 {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: US11 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    var v8: *UH10 = undefined; _ = &v8;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_148(v3, v2, v1);
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
fn dfa_states_have_representative_149(p0: *UH10, p1: *UH10, p2: *UH6) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: US11 = undefined; _ = &v5;
    var v6: *UH3 = undefined; _ = &v6;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_find_bisimilar_representative_148(v3, v1, v2);
                switch (v5.tag) {
                    0 => {
                        v6 = v5.c0_0;
                        v0 = v4;
                        continue;
                    },
                    1 => {
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
fn dfa_quotient_state_closed_151(p0: *UH3, p1: *UH6, p2: *UH10) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH3 = undefined; _ = &v5;
    var v6: US11 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = canonical_derivative_13(v0, v3);
                v6 = dfa_find_bisimilar_representative_148(v5, v2, v1);
                switch (v6.tag) {
                    0 => {
                        v7 = v6.c0_0;
                        v1 = v4;
                        continue;
                    },
                    1 => {
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
fn dfa_quotient_closed_150(p0: *UH10, p1: *UH6, p2: *UH10) bool {
    var v0: *UH10 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH10 = p2; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH10 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = dfa_quotient_state_closed_151(v3, v1, v2);
                if (v5) {
                    v0 = v4;
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
fn US12_DfaAccepted() US12 {
    return US12{ .tag = 0 };
}
fn US12_DfaRejected() US12 {
    return US12{ .tag = 1 };
}
fn US12_DfaEscapedClosure() US12 {
    return US12{ .tag = 2 };
}
fn dfa_run_in_closure_152(p0: *UH2, p1: *UH9, p2: *UH0) US12 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH0 = p2; _ = &v2;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH0 = undefined; _ = &v9;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v2.tag) {
            1 => {
                v8 = v2.c1_0;
                v9 = v2.c1_1;
                v10 = canonical_derivative_3(v0, v8);
                v11 = regex_list_contains_56(v10, v1);
                if (v11) {
                    v0 = v10;
                    v2 = v9;
                    continue;
                } else {
                    return US12_DfaEscapedClosure();
                }
            },
            0 => {
                v3 = nullable_0(v0);
                switch (v3.tag) {
                    1 => {
                        return US12_DfaRejected();
                    },
                    0 => {
                        return US12_DfaAccepted();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn contains_154(p0: US1, p1: *UH6) bool {
    var v0: US1 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v19: US3 = undefined; _ = &v19;
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
                                v19 = US3_SymbolSame();
                            },
                            else => {
                                v19 = US3_SymbolLess();
                            },
                        }
                    },
                    else => {
                        switch (v2.tag) {
                            0 => {
                                v19 = US3_SymbolGreater();
                            },
                            else => {
                                switch (v0.tag) {
                                    1 => {
                                        switch (v2.tag) {
                                            1 => {
                                                v19 = US3_SymbolSame();
                                            },
                                            2 => {
                                                v19 = US3_SymbolLess();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    2 => {
                                        switch (v2.tag) {
                                            1 => {
                                                v19 = US3_SymbolGreater();
                                            },
                                            2 => {
                                                v19 = US3_SymbolSame();
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
fn input_symbols_covered_153(p0: *UH1, p1: *UH6) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = contains_154(v2, v1);
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
fn dfa_run_in_closure_155(p0: *UH3, p1: *UH10, p2: *UH1) US12 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: *UH3 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v3: US2 = undefined; _ = &v3;
    while (true) {
        switch (v2.tag) {
            1 => {
                v8 = v2.c1_0;
                v9 = v2.c1_1;
                v10 = canonical_derivative_13(v0, v8);
                v11 = regex_list_contains_86(v10, v1);
                if (v11) {
                    v0 = v10;
                    v2 = v9;
                    continue;
                } else {
                    return US12_DfaEscapedClosure();
                }
            },
            0 => {
                v3 = nullable_1(v0);
                switch (v3.tag) {
                    1 => {
                        return US12_DfaRejected();
                    },
                    0 => {
                        return US12_DfaAccepted();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn dfa_run_minimized_in_representatives_156(p0: *UH2, p1: *UH9, p2: *UH4, p3: *UH0) US12 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH9 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH0 = p3; _ = &v3;
    var v9: US0 = undefined; _ = &v9;
    var v10: *UH0 = undefined; _ = &v10;
    var v11: *UH2 = undefined; _ = &v11;
    var v12: US10 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v4: US2 = undefined; _ = &v4;
    while (true) {
        switch (v3.tag) {
            1 => {
                v9 = v3.c1_0;
                v10 = v3.c1_1;
                v11 = canonical_derivative_3(v0, v9);
                v12 = dfa_find_bisimilar_representative_143(v11, v1, v2);
                switch (v12.tag) {
                    0 => {
                        v13 = v12.c0_0;
                        v0 = v13;
                        v3 = v10;
                        continue;
                    },
                    1 => {
                        return US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            0 => {
                v4 = nullable_0(v0);
                switch (v4.tag) {
                    1 => {
                        return US12_DfaRejected();
                    },
                    0 => {
                        return US12_DfaAccepted();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn dfa_run_minimized_in_representatives_157(p0: *UH3, p1: *UH10, p2: *UH6, p3: *UH1) US12 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH10 = p1; _ = &v1;
    var v2: *UH6 = p2; _ = &v2;
    var v3: *UH1 = p3; _ = &v3;
    var v9: US1 = undefined; _ = &v9;
    var v10: *UH1 = undefined; _ = &v10;
    var v11: *UH3 = undefined; _ = &v11;
    var v12: US11 = undefined; _ = &v12;
    var v13: *UH3 = undefined; _ = &v13;
    var v4: US2 = undefined; _ = &v4;
    while (true) {
        switch (v3.tag) {
            1 => {
                v9 = v3.c1_0;
                v10 = v3.c1_1;
                v11 = canonical_derivative_13(v0, v9);
                v12 = dfa_find_bisimilar_representative_148(v11, v1, v2);
                switch (v12.tag) {
                    0 => {
                        v13 = v12.c0_0;
                        v0 = v13;
                        v3 = v10;
                        continue;
                    },
                    1 => {
                        return US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            0 => {
                v4 = nullable_1(v0);
                switch (v4.tag) {
                    1 => {
                        return US12_DfaRejected();
                    },
                    0 => {
                        return US12_DfaAccepted();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn reference_accepts_158(p0: *UH2, p1: *UH0) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v2: US2 = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v5 = v1.c1_0;
                v6 = v1.c1_1;
                v7 = reference_derivative_26(v0, v5);
                v0 = v7;
                v1 = v6;
                continue;
            },
            0 => {
                v2 = nullable_0(v0);
                switch (v2.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn reference_accepts_159(p0: *UH3, p1: *UH1) bool {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v5: US1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH3 = undefined; _ = &v7;
    var v2: US2 = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v5 = v1.c1_0;
                v6 = v1.c1_1;
                v7 = reference_derivative_40(v0, v5);
                v0 = v7;
                v1 = v6;
                continue;
            },
            0 => {
                v2 = nullable_1(v0);
                switch (v2.tag) {
                    1 => {
                        return false;
                    },
                    0 => {
                        return true;
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    }
}
fn spiralMainValue() []const u8 {
    var v54: bool = undefined; _ = &v54;
    var v60: bool = undefined; _ = &v60;
    var v151: bool = undefined; _ = &v151;
    var v139: US1 = undefined; _ = &v139;
    var v140: *UH3 = undefined; _ = &v140;
    var v141: *UH3 = undefined; _ = &v141;
    var v142: US1 = undefined; _ = &v142;
    var v143: US1 = undefined; _ = &v143;
    var v144: US1 = undefined; _ = &v144;
    var v145: *UH1 = undefined; _ = &v145;
    var v146: *UH1 = undefined; _ = &v146;
    var v147: *UH1 = undefined; _ = &v147;
    var v148: *UH1 = undefined; _ = &v148;
    var v149: bool = undefined; _ = &v149;
    var v150: bool = undefined; _ = &v150;
    var v215: bool = undefined; _ = &v215;
    var v197: US1 = undefined; _ = &v197;
    var v198: *UH3 = undefined; _ = &v198;
    var v199: US1 = undefined; _ = &v199;
    var v200: *UH3 = undefined; _ = &v200;
    var v201: *UH3 = undefined; _ = &v201;
    var v202: *UH3 = undefined; _ = &v202;
    var v203: US1 = undefined; _ = &v203;
    var v204: *UH3 = undefined; _ = &v204;
    var v205: *UH3 = undefined; _ = &v205;
    var v206: US1 = undefined; _ = &v206;
    var v207: US1 = undefined; _ = &v207;
    var v208: US1 = undefined; _ = &v208;
    var v209: *UH6 = undefined; _ = &v209;
    var v210: *UH6 = undefined; _ = &v210;
    var v211: *UH6 = undefined; _ = &v211;
    var v212: *UH6 = undefined; _ = &v212;
    var v213: *UH7 = undefined; _ = &v213;
    var v308: bool = undefined; _ = &v308;
    var v306: *UH9 = undefined; _ = &v306;
    var v305: *UH9 = undefined; _ = &v305;
    var v803: *UH9 = undefined; _ = &v803;
    var v801: *UH9 = undefined; _ = &v801;
    var v800: *UH9 = undefined; _ = &v800;
    var v807: bool = undefined; _ = &v807;
    var v805: *UH9 = undefined; _ = &v805;
    var v804: *UH9 = undefined; _ = &v804;
    var v820: bool = undefined; _ = &v820;
    var v814: US0 = undefined; _ = &v814;
    var v815: US0 = undefined; _ = &v815;
    var v816: *UH4 = undefined; _ = &v816;
    var v817: *UH4 = undefined; _ = &v817;
    var v818: *UH4 = undefined; _ = &v818;
    var v828: bool = undefined; _ = &v828;
    var v822: US0 = undefined; _ = &v822;
    var v823: US0 = undefined; _ = &v823;
    var v824: *UH4 = undefined; _ = &v824;
    var v825: *UH4 = undefined; _ = &v825;
    var v826: *UH4 = undefined; _ = &v826;
    var v835: bool = undefined; _ = &v835;
    var v829: US0 = undefined; _ = &v829;
    var v830: US0 = undefined; _ = &v830;
    var v831: *UH4 = undefined; _ = &v831;
    var v832: *UH4 = undefined; _ = &v832;
    var v833: *UH4 = undefined; _ = &v833;
    var v841: bool = undefined; _ = &v841;
    var v837: *UH8 = undefined; _ = &v837;
    var v838: *UH8 = undefined; _ = &v838;
    var v839: *UH8 = undefined; _ = &v839;
    var v869: *UH10 = undefined; _ = &v869;
    var v867: *UH10 = undefined; _ = &v867;
    var v866: *UH10 = undefined; _ = &v866;
    var v873: bool = undefined; _ = &v873;
    var v871: *UH10 = undefined; _ = &v871;
    var v870: *UH10 = undefined; _ = &v870;
    var v890: bool = undefined; _ = &v890;
    var v882: US1 = undefined; _ = &v882;
    var v883: US1 = undefined; _ = &v883;
    var v884: US1 = undefined; _ = &v884;
    var v885: *UH6 = undefined; _ = &v885;
    var v886: *UH6 = undefined; _ = &v886;
    var v887: *UH6 = undefined; _ = &v887;
    var v888: *UH6 = undefined; _ = &v888;
    var v900: bool = undefined; _ = &v900;
    var v892: US1 = undefined; _ = &v892;
    var v893: US1 = undefined; _ = &v893;
    var v894: US1 = undefined; _ = &v894;
    var v895: *UH6 = undefined; _ = &v895;
    var v896: *UH6 = undefined; _ = &v896;
    var v897: *UH6 = undefined; _ = &v897;
    var v898: *UH6 = undefined; _ = &v898;
    var v909: bool = undefined; _ = &v909;
    var v901: US1 = undefined; _ = &v901;
    var v902: US1 = undefined; _ = &v902;
    var v903: US1 = undefined; _ = &v903;
    var v904: *UH6 = undefined; _ = &v904;
    var v905: *UH6 = undefined; _ = &v905;
    var v906: *UH6 = undefined; _ = &v906;
    var v907: *UH6 = undefined; _ = &v907;
    var v915: bool = undefined; _ = &v915;
    var v911: *UH8 = undefined; _ = &v911;
    var v912: *UH8 = undefined; _ = &v912;
    var v913: *UH8 = undefined; _ = &v913;
    var v949: *UH10 = undefined; _ = &v949;
    var v947: *UH10 = undefined; _ = &v947;
    var v946: *UH10 = undefined; _ = &v946;
    var v953: bool = undefined; _ = &v953;
    var v951: *UH10 = undefined; _ = &v951;
    var v950: *UH10 = undefined; _ = &v950;
    var v970: bool = undefined; _ = &v970;
    var v962: US1 = undefined; _ = &v962;
    var v963: US1 = undefined; _ = &v963;
    var v964: US1 = undefined; _ = &v964;
    var v965: *UH6 = undefined; _ = &v965;
    var v966: *UH6 = undefined; _ = &v966;
    var v967: *UH6 = undefined; _ = &v967;
    var v968: *UH6 = undefined; _ = &v968;
    var v980: bool = undefined; _ = &v980;
    var v972: US1 = undefined; _ = &v972;
    var v973: US1 = undefined; _ = &v973;
    var v974: US1 = undefined; _ = &v974;
    var v975: *UH6 = undefined; _ = &v975;
    var v976: *UH6 = undefined; _ = &v976;
    var v977: *UH6 = undefined; _ = &v977;
    var v978: *UH6 = undefined; _ = &v978;
    var v989: bool = undefined; _ = &v989;
    var v981: US1 = undefined; _ = &v981;
    var v982: US1 = undefined; _ = &v982;
    var v983: US1 = undefined; _ = &v983;
    var v984: *UH6 = undefined; _ = &v984;
    var v985: *UH6 = undefined; _ = &v985;
    var v986: *UH6 = undefined; _ = &v986;
    var v987: *UH6 = undefined; _ = &v987;
    var v995: bool = undefined; _ = &v995;
    var v991: *UH8 = undefined; _ = &v991;
    var v992: *UH8 = undefined; _ = &v992;
    var v993: *UH8 = undefined; _ = &v993;
    var v1027: *UH9 = undefined; _ = &v1027;
    var v1025: *UH9 = undefined; _ = &v1025;
    var v1024: *UH9 = undefined; _ = &v1024;
    var v1031: bool = undefined; _ = &v1031;
    var v1029: *UH9 = undefined; _ = &v1029;
    var v1028: *UH9 = undefined; _ = &v1028;
    var v1045: bool = undefined; _ = &v1045;
    var v1039: US0 = undefined; _ = &v1039;
    var v1040: US0 = undefined; _ = &v1040;
    var v1041: *UH4 = undefined; _ = &v1041;
    var v1042: *UH4 = undefined; _ = &v1042;
    var v1043: *UH4 = undefined; _ = &v1043;
    var v1052: bool = undefined; _ = &v1052;
    var v1046: US0 = undefined; _ = &v1046;
    var v1047: US0 = undefined; _ = &v1047;
    var v1048: *UH4 = undefined; _ = &v1048;
    var v1049: *UH4 = undefined; _ = &v1049;
    var v1050: *UH4 = undefined; _ = &v1050;
    var v1059: bool = undefined; _ = &v1059;
    var v1053: US0 = undefined; _ = &v1053;
    var v1054: US0 = undefined; _ = &v1054;
    var v1055: *UH4 = undefined; _ = &v1055;
    var v1056: *UH4 = undefined; _ = &v1056;
    var v1057: *UH4 = undefined; _ = &v1057;
    var v1084: *UH10 = undefined; _ = &v1084;
    var v1082: *UH10 = undefined; _ = &v1082;
    var v1081: *UH10 = undefined; _ = &v1081;
    var v1088: bool = undefined; _ = &v1088;
    var v1086: *UH10 = undefined; _ = &v1086;
    var v1085: *UH10 = undefined; _ = &v1085;
    var v1106: bool = undefined; _ = &v1106;
    var v1098: US1 = undefined; _ = &v1098;
    var v1099: US1 = undefined; _ = &v1099;
    var v1100: US1 = undefined; _ = &v1100;
    var v1101: *UH6 = undefined; _ = &v1101;
    var v1102: *UH6 = undefined; _ = &v1102;
    var v1103: *UH6 = undefined; _ = &v1103;
    var v1104: *UH6 = undefined; _ = &v1104;
    var v1115: bool = undefined; _ = &v1115;
    var v1107: US1 = undefined; _ = &v1107;
    var v1108: US1 = undefined; _ = &v1108;
    var v1109: US1 = undefined; _ = &v1109;
    var v1110: *UH6 = undefined; _ = &v1110;
    var v1111: *UH6 = undefined; _ = &v1111;
    var v1112: *UH6 = undefined; _ = &v1112;
    var v1113: *UH6 = undefined; _ = &v1113;
    var v1124: bool = undefined; _ = &v1124;
    var v1116: US1 = undefined; _ = &v1116;
    var v1117: US1 = undefined; _ = &v1117;
    var v1118: US1 = undefined; _ = &v1118;
    var v1119: *UH6 = undefined; _ = &v1119;
    var v1120: *UH6 = undefined; _ = &v1120;
    var v1121: *UH6 = undefined; _ = &v1121;
    var v1122: *UH6 = undefined; _ = &v1122;
    var v1155: *UH10 = undefined; _ = &v1155;
    var v1153: *UH10 = undefined; _ = &v1153;
    var v1152: *UH10 = undefined; _ = &v1152;
    var v1159: bool = undefined; _ = &v1159;
    var v1157: *UH10 = undefined; _ = &v1157;
    var v1156: *UH10 = undefined; _ = &v1156;
    var v1177: bool = undefined; _ = &v1177;
    var v1169: US1 = undefined; _ = &v1169;
    var v1170: US1 = undefined; _ = &v1170;
    var v1171: US1 = undefined; _ = &v1171;
    var v1172: *UH6 = undefined; _ = &v1172;
    var v1173: *UH6 = undefined; _ = &v1173;
    var v1174: *UH6 = undefined; _ = &v1174;
    var v1175: *UH6 = undefined; _ = &v1175;
    var v1186: bool = undefined; _ = &v1186;
    var v1178: US1 = undefined; _ = &v1178;
    var v1179: US1 = undefined; _ = &v1179;
    var v1180: US1 = undefined; _ = &v1180;
    var v1181: *UH6 = undefined; _ = &v1181;
    var v1182: *UH6 = undefined; _ = &v1182;
    var v1183: *UH6 = undefined; _ = &v1183;
    var v1184: *UH6 = undefined; _ = &v1184;
    var v1195: bool = undefined; _ = &v1195;
    var v1187: US1 = undefined; _ = &v1187;
    var v1188: US1 = undefined; _ = &v1188;
    var v1189: US1 = undefined; _ = &v1189;
    var v1190: *UH6 = undefined; _ = &v1190;
    var v1191: *UH6 = undefined; _ = &v1191;
    var v1192: *UH6 = undefined; _ = &v1192;
    var v1193: *UH6 = undefined; _ = &v1193;
    var v1237: *UH10 = undefined; _ = &v1237;
    var v1235: *UH10 = undefined; _ = &v1235;
    var v1234: *UH10 = undefined; _ = &v1234;
    var v1241: bool = undefined; _ = &v1241;
    var v1239: *UH10 = undefined; _ = &v1239;
    var v1238: *UH10 = undefined; _ = &v1238;
    var v1259: bool = undefined; _ = &v1259;
    var v1251: US1 = undefined; _ = &v1251;
    var v1252: US1 = undefined; _ = &v1252;
    var v1253: US1 = undefined; _ = &v1253;
    var v1254: *UH6 = undefined; _ = &v1254;
    var v1255: *UH6 = undefined; _ = &v1255;
    var v1256: *UH6 = undefined; _ = &v1256;
    var v1257: *UH6 = undefined; _ = &v1257;
    var v1268: bool = undefined; _ = &v1268;
    var v1260: US1 = undefined; _ = &v1260;
    var v1261: US1 = undefined; _ = &v1261;
    var v1262: US1 = undefined; _ = &v1262;
    var v1263: *UH6 = undefined; _ = &v1263;
    var v1264: *UH6 = undefined; _ = &v1264;
    var v1265: *UH6 = undefined; _ = &v1265;
    var v1266: *UH6 = undefined; _ = &v1266;
    var v1277: bool = undefined; _ = &v1277;
    var v1269: US1 = undefined; _ = &v1269;
    var v1270: US1 = undefined; _ = &v1270;
    var v1271: US1 = undefined; _ = &v1271;
    var v1272: *UH6 = undefined; _ = &v1272;
    var v1273: *UH6 = undefined; _ = &v1273;
    var v1274: *UH6 = undefined; _ = &v1274;
    var v1275: *UH6 = undefined; _ = &v1275;
    var v1279: bool = undefined; _ = &v1279;
    var v1278: bool = undefined; _ = &v1278;
    var v1281: bool = undefined; _ = &v1281;
    var v1280: bool = undefined; _ = &v1280;
    var v1283: bool = undefined; _ = &v1283;
    var v1282: bool = undefined; _ = &v1282;
    var v1285: bool = undefined; _ = &v1285;
    var v1284: bool = undefined; _ = &v1284;
    var v1293: bool = undefined; _ = &v1293;
    var v1286: bool = undefined; _ = &v1286;
    var v1301: bool = undefined; _ = &v1301;
    var v1294: bool = undefined; _ = &v1294;
    var v1309: bool = undefined; _ = &v1309;
    var v1302: bool = undefined; _ = &v1302;
    var v1380: bool = undefined; _ = &v1380;
    var v1378: *UH9 = undefined; _ = &v1378;
    var v1373: *UH9 = undefined; _ = &v1373;
    var v1374: *UH8 = undefined; _ = &v1374;
    var v1375: *UH8 = undefined; _ = &v1375;
    var v1376: *UH8 = undefined; _ = &v1376;
    var v1415: bool = undefined; _ = &v1415;
    var v1413: *UH10 = undefined; _ = &v1413;
    var v1408: *UH10 = undefined; _ = &v1408;
    var v1409: *UH8 = undefined; _ = &v1409;
    var v1410: *UH8 = undefined; _ = &v1410;
    var v1411: *UH8 = undefined; _ = &v1411;
    var v1455: bool = undefined; _ = &v1455;
    var v1453: *UH9 = undefined; _ = &v1453;
    var v1441: *UH9 = undefined; _ = &v1441;
    var v1442: US0 = undefined; _ = &v1442;
    var v1443: US0 = undefined; _ = &v1443;
    var v1444: *UH4 = undefined; _ = &v1444;
    var v1445: *UH4 = undefined; _ = &v1445;
    var v1446: *UH4 = undefined; _ = &v1446;
    var v1447: *UH9 = undefined; _ = &v1447;
    var v1448: *UH9 = undefined; _ = &v1448;
    var v1449: *UH8 = undefined; _ = &v1449;
    var v1450: *UH8 = undefined; _ = &v1450;
    var v1451: *UH8 = undefined; _ = &v1451;
    var v1510: bool = undefined; _ = &v1510;
    var v1508: *UH10 = undefined; _ = &v1508;
    var v1494: *UH10 = undefined; _ = &v1494;
    var v1495: US1 = undefined; _ = &v1495;
    var v1496: US1 = undefined; _ = &v1496;
    var v1497: US1 = undefined; _ = &v1497;
    var v1498: *UH6 = undefined; _ = &v1498;
    var v1499: *UH6 = undefined; _ = &v1499;
    var v1500: *UH6 = undefined; _ = &v1500;
    var v1501: *UH6 = undefined; _ = &v1501;
    var v1502: *UH10 = undefined; _ = &v1502;
    var v1503: *UH10 = undefined; _ = &v1503;
    var v1504: *UH8 = undefined; _ = &v1504;
    var v1505: *UH8 = undefined; _ = &v1505;
    var v1506: *UH8 = undefined; _ = &v1506;
    var v1563: US12 = undefined; _ = &v1563;
    var v1524: US0 = undefined; _ = &v1524;
    var v1525: *UH2 = undefined; _ = &v1525;
    var v1526: US0 = undefined; _ = &v1526;
    var v1527: *UH2 = undefined; _ = &v1527;
    var v1528: *UH2 = undefined; _ = &v1528;
    var v1529: *UH2 = undefined; _ = &v1529;
    var v1530: US0 = undefined; _ = &v1530;
    var v1531: *UH2 = undefined; _ = &v1531;
    var v1532: *UH2 = undefined; _ = &v1532;
    var v1533: *UH2 = undefined; _ = &v1533;
    var v1534: *UH2 = undefined; _ = &v1534;
    var v1535: *UH8 = undefined; _ = &v1535;
    var v1536: *UH8 = undefined; _ = &v1536;
    var v1537: *UH8 = undefined; _ = &v1537;
    var v1538: *UH2 = undefined; _ = &v1538;
    var v1539: US0 = undefined; _ = &v1539;
    var v1540: US0 = undefined; _ = &v1540;
    var v1541: *UH4 = undefined; _ = &v1541;
    var v1542: *UH4 = undefined; _ = &v1542;
    var v1543: *UH4 = undefined; _ = &v1543;
    var v1544: *UH9 = undefined; _ = &v1544;
    var v1545: *UH9 = undefined; _ = &v1545;
    var v1546: *UH9 = undefined; _ = &v1546;
    var v1547: *UH9 = undefined; _ = &v1547;
    var v1548: US4 = undefined; _ = &v1548;
    var v1558: *UH9 = undefined; _ = &v1558;
    var v1549: *UH9 = undefined; _ = &v1549;
    var v1550: US0 = undefined; _ = &v1550;
    var v1551: US0 = undefined; _ = &v1551;
    var v1552: US0 = undefined; _ = &v1552;
    var v1553: *UH0 = undefined; _ = &v1553;
    var v1554: *UH0 = undefined; _ = &v1554;
    var v1555: *UH0 = undefined; _ = &v1555;
    var v1556: *UH0 = undefined; _ = &v1556;
    var v1583: bool = undefined; _ = &v1583;
    var v1581: bool = undefined; _ = &v1581;
    var v1636: US12 = undefined; _ = &v1636;
    var v1597: US0 = undefined; _ = &v1597;
    var v1598: *UH2 = undefined; _ = &v1598;
    var v1599: US0 = undefined; _ = &v1599;
    var v1600: *UH2 = undefined; _ = &v1600;
    var v1601: *UH2 = undefined; _ = &v1601;
    var v1602: *UH2 = undefined; _ = &v1602;
    var v1603: US0 = undefined; _ = &v1603;
    var v1604: *UH2 = undefined; _ = &v1604;
    var v1605: *UH2 = undefined; _ = &v1605;
    var v1606: *UH2 = undefined; _ = &v1606;
    var v1607: *UH2 = undefined; _ = &v1607;
    var v1608: *UH8 = undefined; _ = &v1608;
    var v1609: *UH8 = undefined; _ = &v1609;
    var v1610: *UH8 = undefined; _ = &v1610;
    var v1611: *UH2 = undefined; _ = &v1611;
    var v1612: US0 = undefined; _ = &v1612;
    var v1613: US0 = undefined; _ = &v1613;
    var v1614: *UH4 = undefined; _ = &v1614;
    var v1615: *UH4 = undefined; _ = &v1615;
    var v1616: *UH4 = undefined; _ = &v1616;
    var v1617: *UH9 = undefined; _ = &v1617;
    var v1618: *UH9 = undefined; _ = &v1618;
    var v1619: *UH9 = undefined; _ = &v1619;
    var v1620: *UH9 = undefined; _ = &v1620;
    var v1621: US4 = undefined; _ = &v1621;
    var v1631: *UH9 = undefined; _ = &v1631;
    var v1622: *UH9 = undefined; _ = &v1622;
    var v1623: US0 = undefined; _ = &v1623;
    var v1624: US0 = undefined; _ = &v1624;
    var v1625: US0 = undefined; _ = &v1625;
    var v1626: *UH0 = undefined; _ = &v1626;
    var v1627: *UH0 = undefined; _ = &v1627;
    var v1628: *UH0 = undefined; _ = &v1628;
    var v1629: *UH0 = undefined; _ = &v1629;
    var v1656: bool = undefined; _ = &v1656;
    var v1654: bool = undefined; _ = &v1654;
    var v1707: US12 = undefined; _ = &v1707;
    var v1672: US1 = undefined; _ = &v1672;
    var v1673: *UH3 = undefined; _ = &v1673;
    var v1674: *UH3 = undefined; _ = &v1674;
    var v1675: *UH3 = undefined; _ = &v1675;
    var v1676: *UH3 = undefined; _ = &v1676;
    var v1677: *UH8 = undefined; _ = &v1677;
    var v1678: *UH8 = undefined; _ = &v1678;
    var v1679: *UH8 = undefined; _ = &v1679;
    var v1680: *UH3 = undefined; _ = &v1680;
    var v1681: US1 = undefined; _ = &v1681;
    var v1682: US1 = undefined; _ = &v1682;
    var v1683: US1 = undefined; _ = &v1683;
    var v1684: *UH6 = undefined; _ = &v1684;
    var v1685: *UH6 = undefined; _ = &v1685;
    var v1686: *UH6 = undefined; _ = &v1686;
    var v1687: *UH6 = undefined; _ = &v1687;
    var v1688: *UH10 = undefined; _ = &v1688;
    var v1689: *UH10 = undefined; _ = &v1689;
    var v1690: *UH10 = undefined; _ = &v1690;
    var v1691: *UH10 = undefined; _ = &v1691;
    var v1692: US8 = undefined; _ = &v1692;
    var v1702: *UH10 = undefined; _ = &v1702;
    var v1693: *UH10 = undefined; _ = &v1693;
    var v1694: US1 = undefined; _ = &v1694;
    var v1695: US1 = undefined; _ = &v1695;
    var v1696: US1 = undefined; _ = &v1696;
    var v1697: *UH1 = undefined; _ = &v1697;
    var v1698: *UH1 = undefined; _ = &v1698;
    var v1699: *UH1 = undefined; _ = &v1699;
    var v1700: *UH1 = undefined; _ = &v1700;
    var v1721: bool = undefined; _ = &v1721;
    var v1719: bool = undefined; _ = &v1719;
    var v1772: US12 = undefined; _ = &v1772;
    var v1737: US1 = undefined; _ = &v1737;
    var v1738: *UH3 = undefined; _ = &v1738;
    var v1739: *UH3 = undefined; _ = &v1739;
    var v1740: *UH3 = undefined; _ = &v1740;
    var v1741: *UH3 = undefined; _ = &v1741;
    var v1742: *UH8 = undefined; _ = &v1742;
    var v1743: *UH8 = undefined; _ = &v1743;
    var v1744: *UH8 = undefined; _ = &v1744;
    var v1745: *UH3 = undefined; _ = &v1745;
    var v1746: US1 = undefined; _ = &v1746;
    var v1747: US1 = undefined; _ = &v1747;
    var v1748: US1 = undefined; _ = &v1748;
    var v1749: *UH6 = undefined; _ = &v1749;
    var v1750: *UH6 = undefined; _ = &v1750;
    var v1751: *UH6 = undefined; _ = &v1751;
    var v1752: *UH6 = undefined; _ = &v1752;
    var v1753: *UH10 = undefined; _ = &v1753;
    var v1754: *UH10 = undefined; _ = &v1754;
    var v1755: *UH10 = undefined; _ = &v1755;
    var v1756: *UH10 = undefined; _ = &v1756;
    var v1757: US8 = undefined; _ = &v1757;
    var v1767: *UH10 = undefined; _ = &v1767;
    var v1758: *UH10 = undefined; _ = &v1758;
    var v1759: US1 = undefined; _ = &v1759;
    var v1760: US1 = undefined; _ = &v1760;
    var v1761: US1 = undefined; _ = &v1761;
    var v1762: *UH1 = undefined; _ = &v1762;
    var v1763: *UH1 = undefined; _ = &v1763;
    var v1764: *UH1 = undefined; _ = &v1764;
    var v1765: *UH1 = undefined; _ = &v1765;
    var v1786: bool = undefined; _ = &v1786;
    var v1784: bool = undefined; _ = &v1784;
    var v1847: US12 = undefined; _ = &v1847;
    var v1804: US1 = undefined; _ = &v1804;
    var v1805: *UH3 = undefined; _ = &v1805;
    var v1806: US1 = undefined; _ = &v1806;
    var v1807: *UH3 = undefined; _ = &v1807;
    var v1808: *UH3 = undefined; _ = &v1808;
    var v1809: *UH3 = undefined; _ = &v1809;
    var v1810: US1 = undefined; _ = &v1810;
    var v1811: *UH3 = undefined; _ = &v1811;
    var v1812: *UH3 = undefined; _ = &v1812;
    var v1813: *UH3 = undefined; _ = &v1813;
    var v1814: *UH3 = undefined; _ = &v1814;
    var v1815: *UH8 = undefined; _ = &v1815;
    var v1816: *UH8 = undefined; _ = &v1816;
    var v1817: *UH8 = undefined; _ = &v1817;
    var v1818: *UH3 = undefined; _ = &v1818;
    var v1819: US1 = undefined; _ = &v1819;
    var v1820: US1 = undefined; _ = &v1820;
    var v1821: US1 = undefined; _ = &v1821;
    var v1822: *UH6 = undefined; _ = &v1822;
    var v1823: *UH6 = undefined; _ = &v1823;
    var v1824: *UH6 = undefined; _ = &v1824;
    var v1825: *UH6 = undefined; _ = &v1825;
    var v1826: *UH10 = undefined; _ = &v1826;
    var v1827: *UH10 = undefined; _ = &v1827;
    var v1828: *UH10 = undefined; _ = &v1828;
    var v1829: *UH10 = undefined; _ = &v1829;
    var v1830: US8 = undefined; _ = &v1830;
    var v1842: *UH10 = undefined; _ = &v1842;
    var v1831: *UH10 = undefined; _ = &v1831;
    var v1832: US1 = undefined; _ = &v1832;
    var v1833: US1 = undefined; _ = &v1833;
    var v1834: US1 = undefined; _ = &v1834;
    var v1835: US1 = undefined; _ = &v1835;
    var v1836: *UH1 = undefined; _ = &v1836;
    var v1837: *UH1 = undefined; _ = &v1837;
    var v1838: *UH1 = undefined; _ = &v1838;
    var v1839: *UH1 = undefined; _ = &v1839;
    var v1840: *UH1 = undefined; _ = &v1840;
    var v1869: bool = undefined; _ = &v1869;
    var v1867: bool = undefined; _ = &v1867;
    var v1930: US12 = undefined; _ = &v1930;
    var v1887: US1 = undefined; _ = &v1887;
    var v1888: *UH3 = undefined; _ = &v1888;
    var v1889: US1 = undefined; _ = &v1889;
    var v1890: *UH3 = undefined; _ = &v1890;
    var v1891: *UH3 = undefined; _ = &v1891;
    var v1892: *UH3 = undefined; _ = &v1892;
    var v1893: US1 = undefined; _ = &v1893;
    var v1894: *UH3 = undefined; _ = &v1894;
    var v1895: *UH3 = undefined; _ = &v1895;
    var v1896: *UH3 = undefined; _ = &v1896;
    var v1897: *UH3 = undefined; _ = &v1897;
    var v1898: *UH8 = undefined; _ = &v1898;
    var v1899: *UH8 = undefined; _ = &v1899;
    var v1900: *UH8 = undefined; _ = &v1900;
    var v1901: *UH3 = undefined; _ = &v1901;
    var v1902: US1 = undefined; _ = &v1902;
    var v1903: US1 = undefined; _ = &v1903;
    var v1904: US1 = undefined; _ = &v1904;
    var v1905: *UH6 = undefined; _ = &v1905;
    var v1906: *UH6 = undefined; _ = &v1906;
    var v1907: *UH6 = undefined; _ = &v1907;
    var v1908: *UH6 = undefined; _ = &v1908;
    var v1909: *UH10 = undefined; _ = &v1909;
    var v1910: *UH10 = undefined; _ = &v1910;
    var v1911: *UH10 = undefined; _ = &v1911;
    var v1912: *UH10 = undefined; _ = &v1912;
    var v1913: US8 = undefined; _ = &v1913;
    var v1925: *UH10 = undefined; _ = &v1925;
    var v1914: *UH10 = undefined; _ = &v1914;
    var v1915: US1 = undefined; _ = &v1915;
    var v1916: US1 = undefined; _ = &v1916;
    var v1917: US1 = undefined; _ = &v1917;
    var v1918: US1 = undefined; _ = &v1918;
    var v1919: *UH1 = undefined; _ = &v1919;
    var v1920: *UH1 = undefined; _ = &v1920;
    var v1921: *UH1 = undefined; _ = &v1921;
    var v1922: *UH1 = undefined; _ = &v1922;
    var v1923: *UH1 = undefined; _ = &v1923;
    var v1952: bool = undefined; _ = &v1952;
    var v1950: bool = undefined; _ = &v1950;
    var v2027: US12 = undefined; _ = &v2027;
    var v1966: US0 = undefined; _ = &v1966;
    var v1967: *UH2 = undefined; _ = &v1967;
    var v1968: US0 = undefined; _ = &v1968;
    var v1969: *UH2 = undefined; _ = &v1969;
    var v1970: *UH2 = undefined; _ = &v1970;
    var v1971: *UH2 = undefined; _ = &v1971;
    var v1972: US0 = undefined; _ = &v1972;
    var v1973: *UH2 = undefined; _ = &v1973;
    var v1974: *UH2 = undefined; _ = &v1974;
    var v1975: *UH2 = undefined; _ = &v1975;
    var v1976: *UH2 = undefined; _ = &v1976;
    var v1977: *UH8 = undefined; _ = &v1977;
    var v1978: *UH8 = undefined; _ = &v1978;
    var v1979: *UH8 = undefined; _ = &v1979;
    var v1980: *UH2 = undefined; _ = &v1980;
    var v1981: US0 = undefined; _ = &v1981;
    var v1982: US0 = undefined; _ = &v1982;
    var v1983: *UH4 = undefined; _ = &v1983;
    var v1984: *UH4 = undefined; _ = &v1984;
    var v1985: *UH4 = undefined; _ = &v1985;
    var v1986: *UH9 = undefined; _ = &v1986;
    var v1987: *UH9 = undefined; _ = &v1987;
    var v1988: *UH9 = undefined; _ = &v1988;
    var v1989: *UH9 = undefined; _ = &v1989;
    var v1990: US4 = undefined; _ = &v1990;
    var v2022: *UH9 = undefined; _ = &v2022;
    var v1991: *UH9 = undefined; _ = &v1991;
    var v1992: US0 = undefined; _ = &v1992;
    var v1993: US0 = undefined; _ = &v1993;
    var v1994: *UH4 = undefined; _ = &v1994;
    var v1995: *UH4 = undefined; _ = &v1995;
    var v1996: *UH4 = undefined; _ = &v1996;
    var v1997: *UH9 = undefined; _ = &v1997;
    var v1998: *UH9 = undefined; _ = &v1998;
    var v1999: US0 = undefined; _ = &v1999;
    var v2000: US0 = undefined; _ = &v2000;
    var v2001: *UH4 = undefined; _ = &v2001;
    var v2002: *UH4 = undefined; _ = &v2002;
    var v2003: *UH4 = undefined; _ = &v2003;
    var v2004: US10 = undefined; _ = &v2004;
    var v2005: *UH2 = undefined; _ = &v2005;
    var v2006: US0 = undefined; _ = &v2006;
    var v2007: US0 = undefined; _ = &v2007;
    var v2008: *UH4 = undefined; _ = &v2008;
    var v2009: *UH4 = undefined; _ = &v2009;
    var v2010: *UH4 = undefined; _ = &v2010;
    var v2011: US0 = undefined; _ = &v2011;
    var v2012: US0 = undefined; _ = &v2012;
    var v2013: US0 = undefined; _ = &v2013;
    var v2014: *UH0 = undefined; _ = &v2014;
    var v2015: *UH0 = undefined; _ = &v2015;
    var v2016: *UH0 = undefined; _ = &v2016;
    var v2017: *UH0 = undefined; _ = &v2017;
    var v2047: bool = undefined; _ = &v2047;
    var v2045: bool = undefined; _ = &v2045;
    var v2126: US12 = undefined; _ = &v2126;
    var v2063: US1 = undefined; _ = &v2063;
    var v2064: *UH3 = undefined; _ = &v2064;
    var v2065: *UH3 = undefined; _ = &v2065;
    var v2066: *UH3 = undefined; _ = &v2066;
    var v2067: *UH3 = undefined; _ = &v2067;
    var v2068: *UH8 = undefined; _ = &v2068;
    var v2069: *UH8 = undefined; _ = &v2069;
    var v2070: *UH8 = undefined; _ = &v2070;
    var v2071: *UH3 = undefined; _ = &v2071;
    var v2072: US1 = undefined; _ = &v2072;
    var v2073: US1 = undefined; _ = &v2073;
    var v2074: US1 = undefined; _ = &v2074;
    var v2075: *UH6 = undefined; _ = &v2075;
    var v2076: *UH6 = undefined; _ = &v2076;
    var v2077: *UH6 = undefined; _ = &v2077;
    var v2078: *UH6 = undefined; _ = &v2078;
    var v2079: *UH10 = undefined; _ = &v2079;
    var v2080: *UH10 = undefined; _ = &v2080;
    var v2081: *UH10 = undefined; _ = &v2081;
    var v2082: *UH10 = undefined; _ = &v2082;
    var v2083: US8 = undefined; _ = &v2083;
    var v2121: *UH10 = undefined; _ = &v2121;
    var v2084: *UH10 = undefined; _ = &v2084;
    var v2085: US1 = undefined; _ = &v2085;
    var v2086: US1 = undefined; _ = &v2086;
    var v2087: US1 = undefined; _ = &v2087;
    var v2088: *UH6 = undefined; _ = &v2088;
    var v2089: *UH6 = undefined; _ = &v2089;
    var v2090: *UH6 = undefined; _ = &v2090;
    var v2091: *UH6 = undefined; _ = &v2091;
    var v2092: *UH10 = undefined; _ = &v2092;
    var v2093: *UH10 = undefined; _ = &v2093;
    var v2094: US1 = undefined; _ = &v2094;
    var v2095: US1 = undefined; _ = &v2095;
    var v2096: US1 = undefined; _ = &v2096;
    var v2097: *UH6 = undefined; _ = &v2097;
    var v2098: *UH6 = undefined; _ = &v2098;
    var v2099: *UH6 = undefined; _ = &v2099;
    var v2100: *UH6 = undefined; _ = &v2100;
    var v2101: US11 = undefined; _ = &v2101;
    var v2102: *UH3 = undefined; _ = &v2102;
    var v2103: US1 = undefined; _ = &v2103;
    var v2104: US1 = undefined; _ = &v2104;
    var v2105: US1 = undefined; _ = &v2105;
    var v2106: *UH6 = undefined; _ = &v2106;
    var v2107: *UH6 = undefined; _ = &v2107;
    var v2108: *UH6 = undefined; _ = &v2108;
    var v2109: *UH6 = undefined; _ = &v2109;
    var v2110: US1 = undefined; _ = &v2110;
    var v2111: US1 = undefined; _ = &v2111;
    var v2112: US1 = undefined; _ = &v2112;
    var v2113: *UH1 = undefined; _ = &v2113;
    var v2114: *UH1 = undefined; _ = &v2114;
    var v2115: *UH1 = undefined; _ = &v2115;
    var v2116: *UH1 = undefined; _ = &v2116;
    var v2140: bool = undefined; _ = &v2140;
    var v2138: bool = undefined; _ = &v2138;
    var v2236: US12 = undefined; _ = &v2236;
    var v2156: US1 = undefined; _ = &v2156;
    var v2157: *UH3 = undefined; _ = &v2157;
    var v2158: US1 = undefined; _ = &v2158;
    var v2159: *UH3 = undefined; _ = &v2159;
    var v2160: *UH3 = undefined; _ = &v2160;
    var v2161: *UH3 = undefined; _ = &v2161;
    var v2162: US1 = undefined; _ = &v2162;
    var v2163: *UH3 = undefined; _ = &v2163;
    var v2164: US1 = undefined; _ = &v2164;
    var v2165: *UH3 = undefined; _ = &v2165;
    var v2166: US1 = undefined; _ = &v2166;
    var v2167: *UH3 = undefined; _ = &v2167;
    var v2168: *UH3 = undefined; _ = &v2168;
    var v2169: *UH3 = undefined; _ = &v2169;
    var v2170: US1 = undefined; _ = &v2170;
    var v2171: *UH3 = undefined; _ = &v2171;
    var v2172: *UH3 = undefined; _ = &v2172;
    var v2173: *UH3 = undefined; _ = &v2173;
    var v2174: *UH3 = undefined; _ = &v2174;
    var v2175: *UH3 = undefined; _ = &v2175;
    var v2176: *UH3 = undefined; _ = &v2176;
    var v2177: *UH3 = undefined; _ = &v2177;
    var v2178: *UH8 = undefined; _ = &v2178;
    var v2179: *UH8 = undefined; _ = &v2179;
    var v2180: *UH8 = undefined; _ = &v2180;
    var v2181: *UH3 = undefined; _ = &v2181;
    var v2182: US1 = undefined; _ = &v2182;
    var v2183: US1 = undefined; _ = &v2183;
    var v2184: US1 = undefined; _ = &v2184;
    var v2185: *UH6 = undefined; _ = &v2185;
    var v2186: *UH6 = undefined; _ = &v2186;
    var v2187: *UH6 = undefined; _ = &v2187;
    var v2188: *UH6 = undefined; _ = &v2188;
    var v2189: *UH10 = undefined; _ = &v2189;
    var v2190: *UH10 = undefined; _ = &v2190;
    var v2191: *UH10 = undefined; _ = &v2191;
    var v2192: *UH10 = undefined; _ = &v2192;
    var v2193: US8 = undefined; _ = &v2193;
    var v2231: *UH10 = undefined; _ = &v2231;
    var v2194: *UH10 = undefined; _ = &v2194;
    var v2195: US1 = undefined; _ = &v2195;
    var v2196: US1 = undefined; _ = &v2196;
    var v2197: US1 = undefined; _ = &v2197;
    var v2198: *UH6 = undefined; _ = &v2198;
    var v2199: *UH6 = undefined; _ = &v2199;
    var v2200: *UH6 = undefined; _ = &v2200;
    var v2201: *UH6 = undefined; _ = &v2201;
    var v2202: *UH10 = undefined; _ = &v2202;
    var v2203: *UH10 = undefined; _ = &v2203;
    var v2204: US1 = undefined; _ = &v2204;
    var v2205: US1 = undefined; _ = &v2205;
    var v2206: US1 = undefined; _ = &v2206;
    var v2207: *UH6 = undefined; _ = &v2207;
    var v2208: *UH6 = undefined; _ = &v2208;
    var v2209: *UH6 = undefined; _ = &v2209;
    var v2210: *UH6 = undefined; _ = &v2210;
    var v2211: US11 = undefined; _ = &v2211;
    var v2212: *UH3 = undefined; _ = &v2212;
    var v2213: US1 = undefined; _ = &v2213;
    var v2214: US1 = undefined; _ = &v2214;
    var v2215: US1 = undefined; _ = &v2215;
    var v2216: *UH6 = undefined; _ = &v2216;
    var v2217: *UH6 = undefined; _ = &v2217;
    var v2218: *UH6 = undefined; _ = &v2218;
    var v2219: *UH6 = undefined; _ = &v2219;
    var v2220: US1 = undefined; _ = &v2220;
    var v2221: US1 = undefined; _ = &v2221;
    var v2222: US1 = undefined; _ = &v2222;
    var v2223: *UH1 = undefined; _ = &v2223;
    var v2224: *UH1 = undefined; _ = &v2224;
    var v2225: *UH1 = undefined; _ = &v2225;
    var v2226: *UH1 = undefined; _ = &v2226;
    var v2267: bool = undefined; _ = &v2267;
    var v2265: bool = undefined; _ = &v2265;
    var v2363: US12 = undefined; _ = &v2363;
    var v2283: US1 = undefined; _ = &v2283;
    var v2284: *UH3 = undefined; _ = &v2284;
    var v2285: US1 = undefined; _ = &v2285;
    var v2286: *UH3 = undefined; _ = &v2286;
    var v2287: *UH3 = undefined; _ = &v2287;
    var v2288: *UH3 = undefined; _ = &v2288;
    var v2289: US1 = undefined; _ = &v2289;
    var v2290: *UH3 = undefined; _ = &v2290;
    var v2291: US1 = undefined; _ = &v2291;
    var v2292: *UH3 = undefined; _ = &v2292;
    var v2293: US1 = undefined; _ = &v2293;
    var v2294: *UH3 = undefined; _ = &v2294;
    var v2295: *UH3 = undefined; _ = &v2295;
    var v2296: *UH3 = undefined; _ = &v2296;
    var v2297: US1 = undefined; _ = &v2297;
    var v2298: *UH3 = undefined; _ = &v2298;
    var v2299: *UH3 = undefined; _ = &v2299;
    var v2300: *UH3 = undefined; _ = &v2300;
    var v2301: *UH3 = undefined; _ = &v2301;
    var v2302: *UH3 = undefined; _ = &v2302;
    var v2303: *UH3 = undefined; _ = &v2303;
    var v2304: *UH3 = undefined; _ = &v2304;
    var v2305: *UH8 = undefined; _ = &v2305;
    var v2306: *UH8 = undefined; _ = &v2306;
    var v2307: *UH8 = undefined; _ = &v2307;
    var v2308: *UH3 = undefined; _ = &v2308;
    var v2309: US1 = undefined; _ = &v2309;
    var v2310: US1 = undefined; _ = &v2310;
    var v2311: US1 = undefined; _ = &v2311;
    var v2312: *UH6 = undefined; _ = &v2312;
    var v2313: *UH6 = undefined; _ = &v2313;
    var v2314: *UH6 = undefined; _ = &v2314;
    var v2315: *UH6 = undefined; _ = &v2315;
    var v2316: *UH10 = undefined; _ = &v2316;
    var v2317: *UH10 = undefined; _ = &v2317;
    var v2318: *UH10 = undefined; _ = &v2318;
    var v2319: *UH10 = undefined; _ = &v2319;
    var v2320: US8 = undefined; _ = &v2320;
    var v2358: *UH10 = undefined; _ = &v2358;
    var v2321: *UH10 = undefined; _ = &v2321;
    var v2322: US1 = undefined; _ = &v2322;
    var v2323: US1 = undefined; _ = &v2323;
    var v2324: US1 = undefined; _ = &v2324;
    var v2325: *UH6 = undefined; _ = &v2325;
    var v2326: *UH6 = undefined; _ = &v2326;
    var v2327: *UH6 = undefined; _ = &v2327;
    var v2328: *UH6 = undefined; _ = &v2328;
    var v2329: *UH10 = undefined; _ = &v2329;
    var v2330: *UH10 = undefined; _ = &v2330;
    var v2331: US1 = undefined; _ = &v2331;
    var v2332: US1 = undefined; _ = &v2332;
    var v2333: US1 = undefined; _ = &v2333;
    var v2334: *UH6 = undefined; _ = &v2334;
    var v2335: *UH6 = undefined; _ = &v2335;
    var v2336: *UH6 = undefined; _ = &v2336;
    var v2337: *UH6 = undefined; _ = &v2337;
    var v2338: US11 = undefined; _ = &v2338;
    var v2339: *UH3 = undefined; _ = &v2339;
    var v2340: US1 = undefined; _ = &v2340;
    var v2341: US1 = undefined; _ = &v2341;
    var v2342: US1 = undefined; _ = &v2342;
    var v2343: *UH6 = undefined; _ = &v2343;
    var v2344: *UH6 = undefined; _ = &v2344;
    var v2345: *UH6 = undefined; _ = &v2345;
    var v2346: *UH6 = undefined; _ = &v2346;
    var v2347: US1 = undefined; _ = &v2347;
    var v2348: US1 = undefined; _ = &v2348;
    var v2349: US1 = undefined; _ = &v2349;
    var v2350: *UH1 = undefined; _ = &v2350;
    var v2351: *UH1 = undefined; _ = &v2351;
    var v2352: *UH1 = undefined; _ = &v2352;
    var v2353: *UH1 = undefined; _ = &v2353;
    var v2394: bool = undefined; _ = &v2394;
    var v2392: bool = undefined; _ = &v2392;
    var v2633: bool = undefined; _ = &v2633;
    var v2632: bool = undefined; _ = &v2632;
    var v2669: bool = undefined; _ = &v2669;
    var v2668: bool = undefined; _ = &v2668;
    var v2693: bool = undefined; _ = &v2693;
    var v2692: bool = undefined; _ = &v2692;
    var v2717: bool = undefined; _ = &v2717;
    var v2716: bool = undefined; _ = &v2716;
    var v2757: bool = undefined; _ = &v2757;
    var v2756: bool = undefined; _ = &v2756;
    var v2797: bool = undefined; _ = &v2797;
    var v2796: bool = undefined; _ = &v2796;
    var v2835: bool = undefined; _ = &v2835;
    var v2834: bool = undefined; _ = &v2834;
    var v2873: bool = undefined; _ = &v2873;
    var v2872: bool = undefined; _ = &v2872;
    var v2899: bool = undefined; _ = &v2899;
    var v2898: bool = undefined; _ = &v2898;
    var v2925: bool = undefined; _ = &v2925;
    var v2924: bool = undefined; _ = &v2924;
    var v2967: bool = undefined; _ = &v2967;
    var v2966: bool = undefined; _ = &v2966;
    var v3009: bool = undefined; _ = &v3009;
    var v3008: bool = undefined; _ = &v3008;
    var v3031: bool = undefined; _ = &v3031;
    var v3030: bool = undefined; _ = &v3030;
    var v3050: bool = undefined; _ = &v3050;
    var v3185: bool = undefined; _ = &v3185;
    var v3207: bool = undefined; _ = &v3207;
    var v3224: bool = undefined; _ = &v3224;
    var v3241: bool = undefined; _ = &v3241;
    var v3272: bool = undefined; _ = &v3272;
    var v3303: bool = undefined; _ = &v3303;
    var v3340: bool = undefined; _ = &v3340;
    var v3377: bool = undefined; _ = &v3377;
    var v3412: bool = undefined; _ = &v3412;
    var v3445: bool = undefined; _ = &v3445;
    var v3490: bool = undefined; _ = &v3490;
    var v3535: bool = undefined; _ = &v3535;
    var v3568: bool = undefined; _ = &v3568;
    var v3607: bool = undefined; _ = &v3607;
    const v0: US0 = US0_BitOne();
    const v1: US0 = US0_BitOne();
    const v2: US0 = US0_BitZero();
    const v3: *UH0 = UH0_InputEmpty();
    const v4: *UH0 = UH0_InputCons(v2, v3);
    const v5: *UH0 = UH0_InputCons(v1, v4);
    const v6: *UH0 = UH0_InputCons(v0, v5);
    const v7: US0 = US0_BitOne();
    const v8: US0 = US0_BitOne();
    const v9: US0 = US0_BitOne();
    const v10: *UH0 = UH0_InputEmpty();
    const v11: *UH0 = UH0_InputCons(v9, v10);
    const v12: *UH0 = UH0_InputCons(v8, v11);
    const v13: *UH0 = UH0_InputCons(v7, v12);
    const v14: *UH0 = UH0_InputEmpty();
    const v15: US1 = US1_TriA();
    const v16: US1 = US1_TriA();
    const v17: US1 = US1_TriA();
    const v18: *UH1 = UH1_InputEmpty();
    const v19: *UH1 = UH1_InputCons(v17, v18);
    const v20: *UH1 = UH1_InputCons(v16, v19);
    const v21: *UH1 = UH1_InputCons(v15, v20);
    const v22: US1 = US1_TriA();
    const v23: US1 = US1_TriA();
    const v24: US1 = US1_TriB();
    const v25: *UH1 = UH1_InputEmpty();
    const v26: *UH1 = UH1_InputCons(v24, v25);
    const v27: *UH1 = UH1_InputCons(v23, v26);
    const v28: *UH1 = UH1_InputCons(v22, v27);
    const v29: US0 = US0_BitZero();
    const v30: *UH2 = UH2_RegexChar(v29);
    const v31: US0 = US0_BitOne();
    const v32: *UH2 = UH2_RegexChar(v31);
    const v33: *UH2 = UH2_RegexAlt(v30, v32);
    const v34: *UH2 = UH2_RegexStar(v33);
    const v35: US0 = US0_BitZero();
    const v36: *UH2 = UH2_RegexChar(v35);
    const v37: *UH2 = UH2_RegexCat(v34, v36);
    const v38: US2 = nullable_0(v37); _ = &v38;
    const v39: US1 = US1_TriA();
    const v40: *UH3 = UH3_RegexChar(v39);
    const v41: *UH3 = UH3_RegexStar(v40);
    const v42: US2 = nullable_1(v41); _ = &v42;
    const v43: US0 = US0_BitZero();
    const v44: *UH2 = UH2_RegexChar(v43);
    const v45: US0 = US0_BitOne();
    const v46: *UH2 = UH2_RegexChar(v45);
    const v47: *UH2 = UH2_RegexAlt(v44, v46);
    const v48: *UH2 = UH2_RegexStar(v47);
    const v49: US0 = US0_BitZero();
    const v50: *UH2 = UH2_RegexChar(v49);
    const v51: *UH2 = UH2_RegexCat(v48, v50);
    const v52: US2 = nullable_0(v51);
    switch (v52.tag) {
        1 => {
            v54 = true;
        },
        0 => {
            v54 = false;
        },
        else => unreachable,
    }
    const v55: US1 = US1_TriA();
    const v56: *UH3 = UH3_RegexChar(v55);
    const v57: *UH3 = UH3_RegexStar(v56);
    const v58: US2 = nullable_1(v57);
    switch (v58.tag) {
        1 => {
            v60 = false;
        },
        0 => {
            v60 = true;
        },
        else => unreachable,
    }
    const v61: bool = (v54 and v60);
    if (v61) {
    } else {
        if (spiral_true) spiralFail("higher-ranked nullable batch should pass");
    }
    const v62: US0 = US0_BitZero();
    const v63: *UH2 = UH2_RegexChar(v62);
    const v64: US0 = US0_BitOne();
    const v65: *UH2 = UH2_RegexChar(v64);
    const v66: *UH2 = UH2_RegexAlt(v63, v65);
    const v67: *UH2 = UH2_RegexStar(v66);
    const v68: US0 = US0_BitZero();
    const v69: *UH2 = UH2_RegexChar(v68);
    const v70: *UH2 = UH2_RegexCat(v67, v69);
    const v71: US0 = US0_BitOne();
    const v72: US0 = US0_BitOne();
    const v73: US0 = US0_BitZero();
    const v74: *UH0 = UH0_InputEmpty();
    const v75: *UH0 = UH0_InputCons(v73, v74);
    const v76: *UH0 = UH0_InputCons(v72, v75);
    const v77: *UH0 = UH0_InputCons(v71, v76);
    const v78: bool = accepts_2(v70, v77);
    const v79: US1 = US1_TriA();
    const v80: *UH3 = UH3_RegexChar(v79);
    const v81: *UH3 = UH3_RegexStar(v80);
    const v82: US1 = US1_TriA();
    const v83: US1 = US1_TriA();
    const v84: US1 = US1_TriB();
    const v85: *UH1 = UH1_InputEmpty();
    const v86: *UH1 = UH1_InputCons(v84, v85);
    const v87: *UH1 = UH1_InputCons(v83, v86);
    const v88: *UH1 = UH1_InputCons(v82, v87);
    const v89: bool = accepts_12(v81, v88);
    const v90: bool = v89 == false;
    const v91: bool = (v78 and v90);
    if (v91) {
    } else {
        if (spiral_true) spiralFail("higher-ranked acceptance batch should preserve capability-resolved decisions");
    }
    const v92: US0 = US0_BitZero();
    const v93: *UH2 = UH2_RegexChar(v92);
    const v94: US0 = US0_BitOne();
    const v95: *UH2 = UH2_RegexChar(v94);
    const v96: *UH2 = UH2_RegexAlt(v93, v95);
    const v97: *UH2 = UH2_RegexStar(v96);
    const v98: US0 = US0_BitZero();
    const v99: *UH2 = UH2_RegexChar(v98);
    const v100: *UH2 = UH2_RegexCat(v97, v99);
    const v101: US0 = US0_BitOne();
    const v102: US0 = US0_BitOne();
    const v103: US0 = US0_BitZero();
    const v104: *UH0 = UH0_InputEmpty();
    const v105: *UH0 = UH0_InputCons(v103, v104);
    const v106: *UH0 = UH0_InputCons(v102, v105);
    const v107: *UH0 = UH0_InputCons(v101, v106);
    const v108: bool = accepts_2(v100, v107);
    const v109: US1 = US1_TriA();
    const v110: *UH3 = UH3_RegexChar(v109);
    const v111: *UH3 = UH3_RegexStar(v110);
    const v112: US1 = US1_TriA();
    const v113: US1 = US1_TriA();
    const v114: US1 = US1_TriB();
    const v115: *UH1 = UH1_InputEmpty();
    const v116: *UH1 = UH1_InputCons(v114, v115);
    const v117: *UH1 = UH1_InputCons(v113, v116);
    const v118: *UH1 = UH1_InputCons(v112, v117);
    const v119: bool = accepts_12(v111, v118);
    const v120: bool = v119 == false;
    const v121: bool = (v108 and v120);
    if (v121) {
    } else {
        if (spiral_true) spiralFail("higher-ranked matcher programs should execute captured alphabet capabilities");
    }
    const v122: US0 = US0_BitZero();
    const v123: *UH2 = UH2_RegexChar(v122);
    const v124: US0 = US0_BitOne();
    const v125: *UH2 = UH2_RegexChar(v124);
    const v126: *UH2 = UH2_RegexAlt(v123, v125);
    const v127: *UH2 = UH2_RegexStar(v126);
    const v128: US0 = US0_BitZero();
    const v129: *UH2 = UH2_RegexChar(v128);
    const v130: *UH2 = UH2_RegexCat(v127, v129);
    const v131: US0 = US0_BitOne();
    const v132: US0 = US0_BitOne();
    const v133: US0 = US0_BitZero();
    const v134: *UH0 = UH0_InputEmpty();
    const v135: *UH0 = UH0_InputCons(v133, v134);
    const v136: *UH0 = UH0_InputCons(v132, v135);
    const v137: *UH0 = UH0_InputCons(v131, v136);
    const v138: bool = accepts_2(v130, v137);
    if (v138) {
        v139 = US1_TriA();
        v140 = UH3_RegexChar(v139);
        v141 = UH3_RegexStar(v140);
        v142 = US1_TriA();
        v143 = US1_TriA();
        v144 = US1_TriB();
        v145 = UH1_InputEmpty();
        v146 = UH1_InputCons(v144, v145);
        v147 = UH1_InputCons(v143, v146);
        v148 = UH1_InputCons(v142, v147);
        v149 = accepts_12(v141, v148);
        v150 = v149 == false;
        v151 = v150;
    } else {
        v151 = false;
    }
    if (v151) {
    } else {
        if (spiral_true) spiralFail("higher-ranked batch predicate should execute alphabet-indexed programs without erasing their family");
    }
    const v152: US0 = US0_BitZero();
    const v153: *UH2 = UH2_RegexChar(v152);
    const v154: US0 = US0_BitOne();
    const v155: *UH2 = UH2_RegexChar(v154);
    const v156: *UH2 = UH2_RegexAlt(v153, v155);
    const v157: *UH2 = UH2_RegexStar(v156);
    const v158: US0 = US0_BitZero();
    const v159: *UH2 = UH2_RegexChar(v158);
    const v160: *UH2 = UH2_RegexCat(v157, v159);
    const v161: US0 = US0_BitOne();
    const v162: US0 = US0_BitOne();
    const v163: US0 = US0_BitZero();
    const v164: *UH0 = UH0_InputEmpty();
    const v165: *UH0 = UH0_InputCons(v163, v164);
    const v166: *UH0 = UH0_InputCons(v162, v165);
    const v167: *UH0 = UH0_InputCons(v161, v166);
    const v168: bool = accepts_2(v160, v167);
    const v169: US1 = US1_TriA();
    const v170: *UH3 = UH3_RegexChar(v169);
    const v171: *UH3 = UH3_RegexStar(v170);
    const v172: US1 = US1_TriA();
    const v173: US1 = US1_TriA();
    const v174: US1 = US1_TriA();
    const v175: *UH1 = UH1_InputEmpty();
    const v176: *UH1 = UH1_InputCons(v174, v175);
    const v177: *UH1 = UH1_InputCons(v173, v176);
    const v178: *UH1 = UH1_InputCons(v172, v177);
    const v179: bool = accepts_12(v171, v178);
    const v180: bool = (v168 and v179);
    if (v180) {
    } else {
        if (spiral_true) spiralFail("generic decided matcher states should coexist in a higher-ranked batch without erasing alphabet indices");
    }
    if (v168) {
    } else {
        if (spiral_true) spiralFail("generic decided matcher existential should preserve a bit decision");
    }
    if (v179) {
    } else {
        if (spiral_true) spiralFail("generic decided matcher existential should preserve a ternary decision");
    }
    const v181: US0 = US0_BitZero();
    const v182: *UH2 = UH2_RegexChar(v181);
    const v183: US0 = US0_BitOne();
    const v184: *UH2 = UH2_RegexChar(v183);
    const v185: *UH2 = UH2_RegexAlt(v182, v184);
    const v186: *UH2 = UH2_RegexStar(v185);
    const v187: US0 = US0_BitZero();
    const v188: *UH2 = UH2_RegexChar(v187);
    const v189: *UH2 = UH2_RegexCat(v186, v188);
    const v190: US0 = US0_BitZero();
    const v191: US0 = US0_BitOne();
    const v192: *UH4 = UH4_SymbolListNil();
    const v193: *UH4 = UH4_SymbolListCons(v191, v192);
    const v194: *UH4 = UH4_SymbolListCons(v190, v193);
    const v195: *UH5 = input_suffixes_22(v6);
    const v196: bool = derivative_semantic_triangle_symbols_23(v189, v194, v195);
    if (v196) {
        v197 = US1_TriA();
        v198 = UH3_RegexChar(v197);
        v199 = US1_TriB();
        v200 = UH3_RegexChar(v199);
        v201 = UH3_RegexAlt(v198, v200);
        v202 = UH3_RegexStar(v201);
        v203 = US1_TriC();
        v204 = UH3_RegexChar(v203);
        v205 = UH3_RegexCat(v202, v204);
        v206 = US1_TriA();
        v207 = US1_TriB();
        v208 = US1_TriC();
        v209 = UH6_SymbolListNil();
        v210 = UH6_SymbolListCons(v208, v209);
        v211 = UH6_SymbolListCons(v207, v210);
        v212 = UH6_SymbolListCons(v206, v211);
        v213 = input_suffixes_36(v28);
        v215 = derivative_semantic_triangle_symbols_37(v205, v212, v213);
    } else {
        v215 = false;
    }
    if (v215) {
    } else {
        if (spiral_true) spiralFail("higher-ranked derivative programs should preserve their alphabet-indexed law interpreters");
    }
    const v216: US0 = US0_BitZero();
    const v217: *UH2 = UH2_RegexChar(v216);
    const v218: US0 = US0_BitOne();
    const v219: *UH2 = UH2_RegexChar(v218);
    const v220: *UH2 = UH2_RegexAlt(v217, v219);
    const v221: *UH2 = UH2_RegexStar(v220);
    const v222: US0 = US0_BitZero();
    const v223: *UH2 = UH2_RegexChar(v222);
    const v224: *UH2 = UH2_RegexCat(v221, v223);
    const v225: US0 = US0_BitZero();
    const v226: US0 = US0_BitOne();
    const v227: *UH4 = UH4_SymbolListNil();
    const v228: *UH4 = UH4_SymbolListCons(v226, v227);
    const v229: *UH4 = UH4_SymbolListCons(v225, v228);
    const v230: *UH5 = input_suffixes_22(v6);
    const v231: bool = derivative_semantic_triangle_symbols_23(v224, v229, v230);
    if (v231) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v232: US1 = US1_TriA();
    const v233: *UH3 = UH3_RegexChar(v232);
    const v234: US1 = US1_TriB();
    const v235: *UH3 = UH3_RegexChar(v234);
    const v236: *UH3 = UH3_RegexAlt(v233, v235);
    const v237: *UH3 = UH3_RegexStar(v236);
    const v238: US1 = US1_TriC();
    const v239: *UH3 = UH3_RegexChar(v238);
    const v240: *UH3 = UH3_RegexCat(v237, v239);
    const v241: US1 = US1_TriA();
    const v242: US1 = US1_TriB();
    const v243: US1 = US1_TriC();
    const v244: *UH6 = UH6_SymbolListNil();
    const v245: *UH6 = UH6_SymbolListCons(v243, v244);
    const v246: *UH6 = UH6_SymbolListCons(v242, v245);
    const v247: *UH6 = UH6_SymbolListCons(v241, v246);
    const v248: *UH7 = input_suffixes_36(v28);
    const v249: bool = derivative_semantic_triangle_symbols_37(v240, v247, v248);
    if (v249) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v250: US0 = US0_BitZero();
    const v251: *UH2 = UH2_RegexChar(v250);
    const v252: US0 = US0_BitOne();
    const v253: *UH2 = UH2_RegexChar(v252);
    const v254: *UH2 = UH2_RegexAlt(v251, v253);
    const v255: *UH2 = UH2_RegexStar(v254);
    const v256: US0 = US0_BitZero();
    const v257: *UH2 = UH2_RegexChar(v256);
    const v258: *UH2 = UH2_RegexCat(v255, v257);
    const v259: *UH5 = input_suffixes_22(v6);
    const v260: bool = normalization_language_law_suffixes_50(v258, v259);
    if (v260) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v261: US1 = US1_TriA();
    const v262: *UH3 = UH3_RegexChar(v261);
    const v263: US1 = US1_TriB();
    const v264: *UH3 = UH3_RegexChar(v263);
    const v265: *UH3 = UH3_RegexAlt(v262, v264);
    const v266: *UH3 = UH3_RegexStar(v265);
    const v267: US1 = US1_TriC();
    const v268: *UH3 = UH3_RegexChar(v267);
    const v269: *UH3 = UH3_RegexCat(v266, v268);
    const v270: *UH7 = input_suffixes_36(v28);
    const v271: bool = normalization_language_law_suffixes_51(v269, v270);
    if (v271) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v272: US0 = US0_BitOne();
    const v273: US0 = US0_BitOne();
    const v274: US0 = US0_BitOne();
    const v275: *UH0 = UH0_InputEmpty();
    const v276: *UH0 = UH0_InputCons(v274, v275);
    const v277: *UH0 = UH0_InputCons(v273, v276);
    const v278: *UH0 = UH0_InputCons(v272, v277);
    const v279: US0 = US0_BitZero();
    const v280: *UH4 = UH4_SymbolListNil();
    const v281: *UH4 = UH4_SymbolListCons(v279, v280);
    const v282: bool = input_symbols_covered_52(v278, v281);
    const v283: bool = v282 == false;
    if (v283) {
    } else {
        if (spiral_true) spiralFail("input coverage must detect symbols omitted from the claimed inventory");
    }
    const v284: US0 = US0_BitZero();
    const v285: *UH2 = UH2_RegexChar(v284);
    const v286: US0 = US0_BitOne();
    const v287: *UH2 = UH2_RegexChar(v286);
    const v288: *UH2 = UH2_RegexAlt(v285, v287);
    const v289: *UH2 = UH2_RegexStar(v288);
    const v290: US0 = US0_BitZero();
    const v291: *UH2 = UH2_RegexChar(v290);
    const v292: *UH2 = UH2_RegexCat(v289, v291);
    const v293: *UH2 = normalize_4(v292);
    const v294: US0 = US0_BitZero();
    const v295: US0 = US0_BitOne();
    const v296: *UH4 = UH4_SymbolListNil();
    const v297: *UH4 = UH4_SymbolListCons(v295, v296);
    const v298: *UH4 = UH4_SymbolListCons(v294, v297);
    const v299: *UH8 = UH8_StateBudgetZero();
    const v300: *UH9 = UH9_RegexListNil();
    const v301: *UH9 = UH9_RegexListCons(v293, v300);
    const v302: *UH9 = UH9_RegexListNil();
    const v303: *UH9 = UH9_RegexListCons(v293, v302);
    const v304: US4 = dfa_closure_loop_bounded_54(v298, v299, v301, v303);
    switch (v304.tag) {
        1 => {
            v306 = v304.c1_0;
            v308 = false;
        },
        0 => {
            v305 = v304.c0_0;
            v308 = true;
        },
        else => unreachable,
    }
    const v309: bool = v308 == false;
    if (v309) {
    } else {
        if (spiral_true) spiralFail("zero closure budget must terminate as budget-exceeded rather than recurse without a bound");
    }
    const v310: US0 = US0_BitZero();
    const v311: US0 = US0_BitOne();
    const v312: *UH4 = UH4_SymbolListNil();
    const v313: *UH4 = UH4_SymbolListCons(v311, v312);
    const v314: *UH4 = UH4_SymbolListCons(v310, v313);
    const v315: *UH9 = regex_chars_from_symbols_57(v314);
    const v316: *UH2 = UH2_RegexEmpty();
    const v317: *UH2 = UH2_RegexEpsilon();
    const v318: *UH9 = UH9_RegexListCons(v317, v315);
    const v319: *UH9 = UH9_RegexListCons(v316, v318);
    const v320: *UH9 = regex_star_corpus_58(v319);
    const v321: *UH2 = UH2_RegexEmpty();
    const v322: *UH2 = UH2_RegexEpsilon();
    const v323: *UH9 = UH9_RegexListCons(v322, v315);
    const v324: *UH9 = UH9_RegexListCons(v321, v323);
    const v325: *UH2 = UH2_RegexEmpty();
    const v326: *UH2 = UH2_RegexEpsilon();
    const v327: *UH9 = UH9_RegexListCons(v326, v315);
    const v328: *UH9 = UH9_RegexListCons(v325, v327);
    const v329: *UH9 = regex_binary_corpus_59(v324, v328);
    const v330: US0 = US0_BitZero();
    const v331: US0 = US0_BitOne();
    const v332: *UH4 = UH4_SymbolListNil();
    const v333: *UH4 = UH4_SymbolListCons(v331, v332);
    const v334: *UH4 = UH4_SymbolListCons(v330, v333);
    const v335: *UH9 = regex_chars_from_symbols_57(v334);
    const v336: *UH2 = UH2_RegexEmpty();
    const v337: *UH2 = UH2_RegexEpsilon();
    const v338: *UH9 = UH9_RegexListCons(v337, v335);
    const v339: *UH9 = UH9_RegexListCons(v336, v338);
    const v340: *UH2 = UH2_RegexEmpty();
    const v341: *UH2 = UH2_RegexEpsilon();
    const v342: *UH9 = UH9_RegexListCons(v341, v335);
    const v343: *UH9 = UH9_RegexListCons(v340, v342);
    const v344: *UH9 = regex_star_corpus_58(v343);
    const v345: *UH2 = UH2_RegexEmpty();
    const v346: *UH2 = UH2_RegexEpsilon();
    const v347: *UH9 = UH9_RegexListCons(v346, v335);
    const v348: *UH9 = UH9_RegexListCons(v345, v347);
    const v349: *UH2 = UH2_RegexEmpty();
    const v350: *UH2 = UH2_RegexEpsilon();
    const v351: *UH9 = UH9_RegexListCons(v350, v335);
    const v352: *UH9 = UH9_RegexListCons(v349, v351);
    const v353: *UH9 = regex_binary_corpus_59(v348, v352);
    const v354: *UH9 = regex_list_append_60(v344, v353);
    const v355: *UH9 = regex_list_append_60(v339, v354);
    const v356: US0 = US0_BitZero();
    const v357: US0 = US0_BitOne();
    const v358: *UH4 = UH4_SymbolListNil();
    const v359: *UH4 = UH4_SymbolListCons(v357, v358);
    const v360: *UH4 = UH4_SymbolListCons(v356, v359);
    const v361: *UH5 = input_suffixes_22(v6);
    const v362: bool = derivative_language_law_corpus_62(v355, v360, v361);
    if (v362) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v363: *UH3 = UH3_RegexEmpty();
    const v364: *UH3 = UH3_RegexEpsilon();
    const v365: US1 = US1_TriA();
    const v366: *UH3 = UH3_RegexChar(v365);
    const v367: US1 = US1_TriA();
    const v368: *UH3 = UH3_RegexChar(v367);
    const v369: US1 = US1_TriB();
    const v370: *UH3 = UH3_RegexChar(v369);
    const v371: *UH3 = UH3_RegexAlt(v368, v370);
    const v372: US1 = US1_TriA();
    const v373: *UH3 = UH3_RegexChar(v372);
    const v374: US1 = US1_TriC();
    const v375: *UH3 = UH3_RegexChar(v374);
    const v376: *UH3 = UH3_RegexCat(v373, v375);
    const v377: US1 = US1_TriB();
    const v378: *UH3 = UH3_RegexChar(v377);
    const v379: *UH3 = UH3_RegexStar(v378);
    const v380: *UH10 = UH10_RegexListNil();
    const v381: *UH10 = UH10_RegexListCons(v379, v380);
    const v382: *UH10 = UH10_RegexListCons(v376, v381);
    const v383: *UH10 = UH10_RegexListCons(v371, v382);
    const v384: *UH10 = UH10_RegexListCons(v366, v383);
    const v385: *UH10 = UH10_RegexListCons(v364, v384);
    const v386: *UH10 = UH10_RegexListCons(v363, v385);
    const v387: US1 = US1_TriA();
    const v388: US1 = US1_TriB();
    const v389: US1 = US1_TriC();
    const v390: *UH6 = UH6_SymbolListNil();
    const v391: *UH6 = UH6_SymbolListCons(v389, v390);
    const v392: *UH6 = UH6_SymbolListCons(v388, v391);
    const v393: *UH6 = UH6_SymbolListCons(v387, v392);
    const v394: *UH7 = input_suffixes_36(v21);
    const v395: bool = derivative_language_law_corpus_65(v386, v393, v394);
    if (v395) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v396: *UH5 = input_suffixes_22(v6);
    const v397: bool = normalization_language_law_corpus_68(v355, v396);
    if (v397) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v398: *UH3 = UH3_RegexEmpty();
    const v399: *UH3 = UH3_RegexEpsilon();
    const v400: US1 = US1_TriA();
    const v401: *UH3 = UH3_RegexChar(v400);
    const v402: US1 = US1_TriA();
    const v403: *UH3 = UH3_RegexChar(v402);
    const v404: US1 = US1_TriB();
    const v405: *UH3 = UH3_RegexChar(v404);
    const v406: *UH3 = UH3_RegexAlt(v403, v405);
    const v407: US1 = US1_TriA();
    const v408: *UH3 = UH3_RegexChar(v407);
    const v409: US1 = US1_TriC();
    const v410: *UH3 = UH3_RegexChar(v409);
    const v411: *UH3 = UH3_RegexCat(v408, v410);
    const v412: US1 = US1_TriB();
    const v413: *UH3 = UH3_RegexChar(v412);
    const v414: *UH3 = UH3_RegexStar(v413);
    const v415: *UH10 = UH10_RegexListNil();
    const v416: *UH10 = UH10_RegexListCons(v414, v415);
    const v417: *UH10 = UH10_RegexListCons(v411, v416);
    const v418: *UH10 = UH10_RegexListCons(v406, v417);
    const v419: *UH10 = UH10_RegexListCons(v401, v418);
    const v420: *UH10 = UH10_RegexListCons(v399, v419);
    const v421: *UH10 = UH10_RegexListCons(v398, v420);
    const v422: *UH7 = input_suffixes_36(v21);
    const v423: bool = normalization_language_law_corpus_69(v421, v422);
    if (v423) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v424: *UH2 = UH2_RegexEmpty();
    const v425: *UH2 = UH2_RegexEpsilon();
    const v426: *UH9 = UH9_RegexListCons(v425, v315);
    const v427: *UH9 = UH9_RegexListCons(v424, v426);
    const v428: US0 = US0_BitZero();
    const v429: US0 = US0_BitOne();
    const v430: *UH4 = UH4_SymbolListNil();
    const v431: *UH4 = UH4_SymbolListCons(v429, v430);
    const v432: *UH4 = UH4_SymbolListCons(v428, v431);
    const v433: bool = dfa_formula_consistent_70(v427, v432);
    if (v433) {
    } else {
        if (spiral_true) spiralFail("base derivative equations should hold structurally");
    }
    const v434: US0 = US0_BitZero();
    const v435: US0 = US0_BitOne();
    const v436: *UH4 = UH4_SymbolListNil();
    const v437: *UH4 = UH4_SymbolListCons(v435, v436);
    const v438: *UH4 = UH4_SymbolListCons(v434, v437);
    const v439: bool = dfa_formula_consistent_70(v320, v438);
    if (v439) {
    } else {
        if (spiral_true) spiralFail("star derivative equations should hold structurally");
    }
    const v440: US0 = US0_BitZero();
    const v441: US0 = US0_BitOne();
    const v442: *UH4 = UH4_SymbolListNil();
    const v443: *UH4 = UH4_SymbolListCons(v441, v442);
    const v444: *UH4 = UH4_SymbolListCons(v440, v443);
    const v445: bool = dfa_formula_consistent_70(v329, v444);
    if (v445) {
    } else {
        if (spiral_true) spiralFail("binary derivative equations should hold structurally");
    }
    const v446: US0 = US0_BitZero();
    const v447: US0 = US0_BitOne();
    const v448: *UH4 = UH4_SymbolListNil();
    const v449: *UH4 = UH4_SymbolListCons(v447, v448);
    const v450: *UH4 = UH4_SymbolListCons(v446, v449);
    const v451: bool = dfa_formula_consistent_70(v355, v450);
    if (v451) {
    } else {
        if (spiral_true) spiralFail("generated derivative equations should hold structurally");
    }
    const v452: bool = dfa_states_nullable_preserved_74(v355);
    if (v452) {
    } else {
        if (spiral_true) spiralFail("generated corpus should preserve nullable under normalization");
    }
    const v453: bool = regex_list_normalization_idempotent_75(v355);
    if (v453) {
    } else {
        if (spiral_true) spiralFail("generated corpus normalization should be idempotent");
    }
    const v454: US0 = US0_BitZero();
    const v455: US0 = US0_BitOne();
    const v456: *UH4 = UH4_SymbolListNil();
    const v457: *UH4 = UH4_SymbolListCons(v455, v456);
    const v458: *UH4 = UH4_SymbolListCons(v454, v457);
    const v459: bool = canonical_derivative_coherent_corpus_76(v355, v458);
    if (v459) {
    } else {
        if (spiral_true) spiralFail("generated bit corpus should commute canonical derivation with prior normalization");
    }
    const v460: *UH3 = UH3_RegexEmpty();
    const v461: *UH3 = UH3_RegexEpsilon();
    const v462: US1 = US1_TriA();
    const v463: *UH3 = UH3_RegexChar(v462);
    const v464: US1 = US1_TriA();
    const v465: *UH3 = UH3_RegexChar(v464);
    const v466: US1 = US1_TriB();
    const v467: *UH3 = UH3_RegexChar(v466);
    const v468: *UH3 = UH3_RegexAlt(v465, v467);
    const v469: US1 = US1_TriA();
    const v470: *UH3 = UH3_RegexChar(v469);
    const v471: US1 = US1_TriC();
    const v472: *UH3 = UH3_RegexChar(v471);
    const v473: *UH3 = UH3_RegexCat(v470, v472);
    const v474: US1 = US1_TriB();
    const v475: *UH3 = UH3_RegexChar(v474);
    const v476: *UH3 = UH3_RegexStar(v475);
    const v477: *UH10 = UH10_RegexListNil();
    const v478: *UH10 = UH10_RegexListCons(v476, v477);
    const v479: *UH10 = UH10_RegexListCons(v473, v478);
    const v480: *UH10 = UH10_RegexListCons(v468, v479);
    const v481: *UH10 = UH10_RegexListCons(v463, v480);
    const v482: *UH10 = UH10_RegexListCons(v461, v481);
    const v483: *UH10 = UH10_RegexListCons(v460, v482);
    const v484: US1 = US1_TriA();
    const v485: US1 = US1_TriB();
    const v486: US1 = US1_TriC();
    const v487: *UH6 = UH6_SymbolListNil();
    const v488: *UH6 = UH6_SymbolListCons(v486, v487);
    const v489: *UH6 = UH6_SymbolListCons(v485, v488);
    const v490: *UH6 = UH6_SymbolListCons(v484, v489);
    const v491: bool = canonical_derivative_coherent_corpus_78(v483, v490);
    if (v491) {
    } else {
        if (spiral_true) spiralFail("ternary constructor corpus should commute canonical derivation with prior normalization");
    }
    const v492: US0 = US0_BitZero();
    const v493: *UH2 = UH2_RegexChar(v492);
    const v494: US0 = US0_BitOne();
    const v495: *UH2 = UH2_RegexChar(v494);
    const v496: *UH2 = UH2_RegexAlt(v493, v495);
    const v497: *UH2 = UH2_RegexStar(v496);
    const v498: US0 = US0_BitZero();
    const v499: *UH2 = UH2_RegexChar(v498);
    const v500: *UH2 = UH2_RegexCat(v497, v499);
    const v501: *UH2 = normalize_4(v500);
    const v502: US0 = US0_BitZero();
    const v503: US0 = US0_BitOne();
    const v504: *UH4 = UH4_SymbolListNil();
    const v505: *UH4 = UH4_SymbolListCons(v503, v504);
    const v506: *UH4 = UH4_SymbolListCons(v502, v505);
    const v507: *UH9 = UH9_RegexListNil();
    const v508: *UH9 = UH9_RegexListCons(v501, v507);
    const v509: *UH9 = UH9_RegexListNil();
    const v510: *UH9 = UH9_RegexListCons(v501, v509);
    const v511: *UH9 = dfa_closure_loop_80(v506, v508, v510);
    const v512: US0 = US0_BitZero();
    const v513: US0 = US0_BitOne();
    const v514: *UH4 = UH4_SymbolListNil();
    const v515: *UH4 = UH4_SymbolListCons(v513, v514);
    const v516: *UH4 = UH4_SymbolListCons(v512, v515);
    const v517: bool = dfa_partition_one_distinct_81(v511, v516);
    if (v517) {
    } else {
        if (spiral_true) spiralFail("bit DFA one-step signatures should be distinct");
    }
    const v518: US1 = US1_TriA();
    const v519: *UH3 = UH3_RegexChar(v518);
    const v520: *UH3 = UH3_RegexStar(v519);
    const v521: *UH3 = normalize_14(v520);
    const v522: US1 = US1_TriA();
    const v523: US1 = US1_TriB();
    const v524: US1 = US1_TriC();
    const v525: *UH6 = UH6_SymbolListNil();
    const v526: *UH6 = UH6_SymbolListCons(v524, v525);
    const v527: *UH6 = UH6_SymbolListCons(v523, v526);
    const v528: *UH6 = UH6_SymbolListCons(v522, v527);
    const v529: *UH10 = UH10_RegexListNil();
    const v530: *UH10 = UH10_RegexListCons(v521, v529);
    const v531: *UH10 = UH10_RegexListNil();
    const v532: *UH10 = UH10_RegexListCons(v521, v531);
    const v533: *UH10 = dfa_closure_loop_84(v528, v530, v532);
    const v534: US1 = US1_TriA();
    const v535: US1 = US1_TriB();
    const v536: US1 = US1_TriC();
    const v537: *UH6 = UH6_SymbolListNil();
    const v538: *UH6 = UH6_SymbolListCons(v536, v537);
    const v539: *UH6 = UH6_SymbolListCons(v535, v538);
    const v540: *UH6 = UH6_SymbolListCons(v534, v539);
    const v541: bool = dfa_partition_one_distinct_87(v533, v540);
    if (v541) {
    } else {
        if (spiral_true) spiralFail("ternary star one-step signatures should be distinct");
    }
    const v542: US1 = US1_TriA();
    const v543: *UH3 = UH3_RegexChar(v542);
    const v544: US1 = US1_TriB();
    const v545: *UH3 = UH3_RegexChar(v544);
    const v546: *UH3 = UH3_RegexAlt(v543, v545);
    const v547: *UH3 = UH3_RegexStar(v546);
    const v548: US1 = US1_TriC();
    const v549: *UH3 = UH3_RegexChar(v548);
    const v550: *UH3 = UH3_RegexCat(v547, v549);
    const v551: *UH3 = normalize_14(v550);
    const v552: US1 = US1_TriA();
    const v553: US1 = US1_TriB();
    const v554: US1 = US1_TriC();
    const v555: *UH6 = UH6_SymbolListNil();
    const v556: *UH6 = UH6_SymbolListCons(v554, v555);
    const v557: *UH6 = UH6_SymbolListCons(v553, v556);
    const v558: *UH6 = UH6_SymbolListCons(v552, v557);
    const v559: *UH10 = UH10_RegexListNil();
    const v560: *UH10 = UH10_RegexListCons(v551, v559);
    const v561: *UH10 = UH10_RegexListNil();
    const v562: *UH10 = UH10_RegexListCons(v551, v561);
    const v563: *UH10 = dfa_closure_loop_84(v558, v560, v562);
    const v564: US1 = US1_TriA();
    const v565: US1 = US1_TriB();
    const v566: US1 = US1_TriC();
    const v567: *UH6 = UH6_SymbolListNil();
    const v568: *UH6 = UH6_SymbolListCons(v566, v567);
    const v569: *UH6 = UH6_SymbolListCons(v565, v568);
    const v570: *UH6 = UH6_SymbolListCons(v564, v569);
    const v571: bool = dfa_partition_one_distinct_87(v563, v570);
    if (v571) {
    } else {
        if (spiral_true) spiralFail("ternary suffix one-step signatures should be distinct");
    }
    const v572: US0 = US0_BitZero();
    const v573: *UH2 = UH2_RegexChar(v572);
    const v574: US0 = US0_BitOne();
    const v575: *UH2 = UH2_RegexChar(v574);
    const v576: *UH2 = UH2_RegexAlt(v573, v575);
    const v577: *UH2 = UH2_RegexStar(v576);
    const v578: US0 = US0_BitZero();
    const v579: *UH2 = UH2_RegexChar(v578);
    const v580: *UH2 = UH2_RegexCat(v577, v579);
    const v581: *UH2 = normalize_4(v580);
    const v582: US0 = US0_BitZero();
    const v583: US0 = US0_BitOne();
    const v584: *UH4 = UH4_SymbolListNil();
    const v585: *UH4 = UH4_SymbolListCons(v583, v584);
    const v586: *UH4 = UH4_SymbolListCons(v582, v585);
    const v587: *UH9 = UH9_RegexListNil();
    const v588: *UH9 = UH9_RegexListCons(v581, v587);
    const v589: *UH9 = UH9_RegexListNil();
    const v590: *UH9 = UH9_RegexListCons(v581, v589);
    const v591: *UH9 = dfa_closure_loop_80(v586, v588, v590);
    const v592: US0 = US0_BitZero();
    const v593: US0 = US0_BitOne();
    const v594: *UH4 = UH4_SymbolListNil();
    const v595: *UH4 = UH4_SymbolListCons(v593, v594);
    const v596: *UH4 = UH4_SymbolListCons(v592, v595);
    const v597: bool = dfa_minimal_by_bisimulation_90(v591, v596);
    if (v597) {
    } else {
        if (spiral_true) spiralFail("bit DFA should be behaviorally minimal");
    }
    const v598: US1 = US1_TriA();
    const v599: *UH3 = UH3_RegexChar(v598);
    const v600: *UH3 = UH3_RegexStar(v599);
    const v601: *UH3 = normalize_14(v600);
    const v602: US1 = US1_TriA();
    const v603: US1 = US1_TriB();
    const v604: US1 = US1_TriC();
    const v605: *UH6 = UH6_SymbolListNil();
    const v606: *UH6 = UH6_SymbolListCons(v604, v605);
    const v607: *UH6 = UH6_SymbolListCons(v603, v606);
    const v608: *UH6 = UH6_SymbolListCons(v602, v607);
    const v609: *UH10 = UH10_RegexListNil();
    const v610: *UH10 = UH10_RegexListCons(v601, v609);
    const v611: *UH10 = UH10_RegexListNil();
    const v612: *UH10 = UH10_RegexListCons(v601, v611);
    const v613: *UH10 = dfa_closure_loop_84(v608, v610, v612);
    const v614: US1 = US1_TriA();
    const v615: US1 = US1_TriB();
    const v616: US1 = US1_TriC();
    const v617: *UH6 = UH6_SymbolListNil();
    const v618: *UH6 = UH6_SymbolListCons(v616, v617);
    const v619: *UH6 = UH6_SymbolListCons(v615, v618);
    const v620: *UH6 = UH6_SymbolListCons(v614, v619);
    const v621: bool = dfa_minimal_by_bisimulation_95(v613, v620);
    if (v621) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA should be behaviorally minimal");
    }
    const v622: US1 = US1_TriA();
    const v623: *UH3 = UH3_RegexChar(v622);
    const v624: US1 = US1_TriB();
    const v625: *UH3 = UH3_RegexChar(v624);
    const v626: *UH3 = UH3_RegexAlt(v623, v625);
    const v627: *UH3 = UH3_RegexStar(v626);
    const v628: US1 = US1_TriC();
    const v629: *UH3 = UH3_RegexChar(v628);
    const v630: *UH3 = UH3_RegexCat(v627, v629);
    const v631: *UH3 = normalize_14(v630);
    const v632: US1 = US1_TriA();
    const v633: US1 = US1_TriB();
    const v634: US1 = US1_TriC();
    const v635: *UH6 = UH6_SymbolListNil();
    const v636: *UH6 = UH6_SymbolListCons(v634, v635);
    const v637: *UH6 = UH6_SymbolListCons(v633, v636);
    const v638: *UH6 = UH6_SymbolListCons(v632, v637);
    const v639: *UH10 = UH10_RegexListNil();
    const v640: *UH10 = UH10_RegexListCons(v631, v639);
    const v641: *UH10 = UH10_RegexListNil();
    const v642: *UH10 = UH10_RegexListCons(v631, v641);
    const v643: *UH10 = dfa_closure_loop_84(v638, v640, v642);
    const v644: US1 = US1_TriA();
    const v645: US1 = US1_TriB();
    const v646: US1 = US1_TriC();
    const v647: *UH6 = UH6_SymbolListNil();
    const v648: *UH6 = UH6_SymbolListCons(v646, v647);
    const v649: *UH6 = UH6_SymbolListCons(v645, v648);
    const v650: *UH6 = UH6_SymbolListCons(v644, v649);
    const v651: bool = dfa_minimal_by_bisimulation_95(v643, v650);
    if (v651) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA should be behaviorally minimal");
    }
    const v652: US1 = US1_TriA();
    const v653: *UH3 = UH3_RegexChar(v652);
    const v654: US1 = US1_TriA();
    const v655: *UH3 = UH3_RegexChar(v654);
    const v656: *UH3 = UH3_RegexStar(v655);
    const v657: *UH3 = UH3_RegexCat(v653, v656);
    const v658: US1 = US1_TriB();
    const v659: *UH3 = UH3_RegexChar(v658);
    const v660: US1 = US1_TriA();
    const v661: *UH3 = UH3_RegexChar(v660);
    const v662: US1 = US1_TriA();
    const v663: *UH3 = UH3_RegexChar(v662);
    const v664: *UH3 = UH3_RegexCat(v661, v663);
    const v665: *UH3 = UH3_RegexStar(v664);
    const v666: US1 = US1_TriA();
    const v667: *UH3 = UH3_RegexChar(v666);
    const v668: *UH3 = UH3_RegexCat(v667, v665);
    const v669: *UH3 = UH3_RegexAlt(v665, v668);
    const v670: *UH3 = UH3_RegexCat(v659, v669);
    const v671: *UH3 = UH3_RegexAlt(v657, v670);
    const v672: *UH3 = normalize_14(v671);
    const v673: US1 = US1_TriA();
    const v674: US1 = US1_TriB();
    const v675: US1 = US1_TriC();
    const v676: *UH6 = UH6_SymbolListNil();
    const v677: *UH6 = UH6_SymbolListCons(v675, v676);
    const v678: *UH6 = UH6_SymbolListCons(v674, v677);
    const v679: *UH6 = UH6_SymbolListCons(v673, v678);
    const v680: *UH10 = UH10_RegexListNil();
    const v681: *UH10 = UH10_RegexListCons(v672, v680);
    const v682: *UH10 = UH10_RegexListNil();
    const v683: *UH10 = UH10_RegexListCons(v672, v682);
    const v684: *UH10 = dfa_closure_loop_84(v679, v681, v683);
    const v685: US1 = US1_TriA();
    const v686: US1 = US1_TriB();
    const v687: US1 = US1_TriC();
    const v688: *UH6 = UH6_SymbolListNil();
    const v689: *UH6 = UH6_SymbolListCons(v687, v688);
    const v690: *UH6 = UH6_SymbolListCons(v686, v689);
    const v691: *UH6 = UH6_SymbolListCons(v685, v690);
    const v692: bool = dfa_partition_one_distinct_87(v684, v691);
    if (v692) {
    } else {
        if (spiral_true) spiralFail("one-step partition should miss cyclic language equivalence");
    }
    const v693: US1 = US1_TriA();
    const v694: US1 = US1_TriB();
    const v695: US1 = US1_TriC();
    const v696: *UH6 = UH6_SymbolListNil();
    const v697: *UH6 = UH6_SymbolListCons(v695, v696);
    const v698: *UH6 = UH6_SymbolListCons(v694, v697);
    const v699: *UH6 = UH6_SymbolListCons(v693, v698);
    const v700: bool = dfa_minimal_by_bisimulation_95(v684, v699);
    const v701: bool = v700 == false;
    if (v701) {
    } else {
        if (spiral_true) spiralFail("bisimulation should detect cyclic language equivalence");
    }
    const v702: US0 = US0_BitZero();
    const v703: *UH2 = UH2_RegexChar(v702);
    const v704: US0 = US0_BitOne();
    const v705: *UH2 = UH2_RegexChar(v704);
    const v706: *UH2 = UH2_RegexAlt(v703, v705);
    const v707: *UH2 = UH2_RegexStar(v706);
    const v708: US0 = US0_BitZero();
    const v709: *UH2 = UH2_RegexChar(v708);
    const v710: *UH2 = UH2_RegexCat(v707, v709);
    const v711: US0 = US0_BitOne();
    const v712: US0 = US0_BitOne();
    const v713: US0 = US0_BitZero();
    const v714: *UH0 = UH0_InputEmpty();
    const v715: *UH0 = UH0_InputCons(v713, v714);
    const v716: *UH0 = UH0_InputCons(v712, v715);
    const v717: *UH0 = UH0_InputCons(v711, v716);
    const v718: US5 = US5_BitMatcherRaw(v710, v717);
    const v719: US6 = decide_bit_match_100(v718);
    const v720: US0 = US0_BitZero();
    const v721: *UH2 = UH2_RegexChar(v720);
    const v722: US0 = US0_BitOne();
    const v723: *UH2 = UH2_RegexChar(v722);
    const v724: *UH2 = UH2_RegexAlt(v721, v723);
    const v725: *UH2 = UH2_RegexStar(v724);
    const v726: US0 = US0_BitZero();
    const v727: *UH2 = UH2_RegexChar(v726);
    const v728: *UH2 = UH2_RegexCat(v725, v727);
    const v729: US0 = US0_BitOne();
    const v730: US0 = US0_BitOne();
    const v731: US0 = US0_BitOne();
    const v732: *UH0 = UH0_InputEmpty();
    const v733: *UH0 = UH0_InputCons(v731, v732);
    const v734: *UH0 = UH0_InputCons(v730, v733);
    const v735: *UH0 = UH0_InputCons(v729, v734);
    const v736: US5 = US5_BitMatcherRaw(v728, v735);
    const v737: US6 = decide_bit_match_100(v736);
    const v738: bool = bit_match_value_101(v719);
    if (v738) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v739: bool = bit_match_value_101(v737);
    if (v739) {
        if (spiral_true) spiralFail("brzozowski-expected-false");
    } else {
    }
    const v740: US0 = US0_BitZero();
    const v741: *UH2 = UH2_RegexChar(v740);
    const v742: US0 = US0_BitOne();
    const v743: *UH2 = UH2_RegexChar(v742);
    const v744: *UH2 = UH2_RegexAlt(v741, v743);
    const v745: *UH2 = UH2_RegexStar(v744);
    const v746: US0 = US0_BitZero();
    const v747: *UH2 = UH2_RegexChar(v746);
    const v748: *UH2 = UH2_RegexCat(v745, v747);
    const v749: US0 = US0_BitOne();
    const v750: US0 = US0_BitOne();
    const v751: US0 = US0_BitZero();
    const v752: *UH0 = UH0_InputEmpty();
    const v753: *UH0 = UH0_InputCons(v751, v752);
    const v754: *UH0 = UH0_InputCons(v750, v753);
    const v755: *UH0 = UH0_InputCons(v749, v754);
    const v756: bool = accepts_2(v748, v755);
    const v757: US0 = US0_BitZero();
    const v758: *UH2 = UH2_RegexChar(v757);
    const v759: US0 = US0_BitOne();
    const v760: *UH2 = UH2_RegexChar(v759);
    const v761: *UH2 = UH2_RegexAlt(v758, v760);
    const v762: *UH2 = UH2_RegexStar(v761);
    const v763: US0 = US0_BitZero();
    const v764: *UH2 = UH2_RegexChar(v763);
    const v765: *UH2 = UH2_RegexCat(v762, v764);
    const v766: US0 = US0_BitOne();
    const v767: US0 = US0_BitOne();
    const v768: US0 = US0_BitOne();
    const v769: *UH0 = UH0_InputEmpty();
    const v770: *UH0 = UH0_InputCons(v768, v769);
    const v771: *UH0 = UH0_InputCons(v767, v770);
    const v772: *UH0 = UH0_InputCons(v766, v771);
    const v773: bool = accepts_2(v765, v772);
    if (v756) {
    } else {
        if (spiral_true) spiralFail("existential match seal should preserve acceptance");
    }
    const v774: bool = v773 == false;
    if (v774) {
    } else {
        if (spiral_true) spiralFail("existential match seal should preserve rejection");
    }
    const v775: US0 = US0_BitZero();
    const v776: *UH2 = UH2_RegexChar(v775);
    const v777: US0 = US0_BitOne();
    const v778: *UH2 = UH2_RegexChar(v777);
    const v779: *UH2 = UH2_RegexAlt(v776, v778);
    const v780: *UH2 = UH2_RegexStar(v779);
    const v781: US0 = US0_BitZero();
    const v782: *UH2 = UH2_RegexChar(v781);
    const v783: *UH2 = UH2_RegexCat(v780, v782);
    const v784: *UH2 = normalize_4(v783);
    const v785: *UH2 = normalize_4(v784);
    const v786: *UH8 = regex_position_count_102(v785);
    const v787: *UH8 = UH8_StateBudgetSucc(v786);
    const v788: *UH8 = state_budget_pow2_104(v787);
    const v789: *UH2 = normalize_4(v785);
    const v790: US0 = US0_BitZero();
    const v791: US0 = US0_BitOne();
    const v792: *UH4 = UH4_SymbolListNil();
    const v793: *UH4 = UH4_SymbolListCons(v791, v792);
    const v794: *UH4 = UH4_SymbolListCons(v790, v793);
    const v795: *UH9 = UH9_RegexListNil();
    const v796: *UH9 = UH9_RegexListCons(v789, v795);
    const v797: *UH9 = UH9_RegexListNil();
    const v798: *UH9 = UH9_RegexListCons(v789, v797);
    const v799: US4 = dfa_closure_loop_bounded_54(v794, v788, v796, v798);
    switch (v799.tag) {
        1 => {
            v801 = v799.c1_0;
            v803 = v801;
        },
        0 => {
            v800 = v799.c0_0;
            v803 = v800;
        },
        else => unreachable,
    }
    switch (v799.tag) {
        1 => {
            v805 = v799.c1_0;
            v807 = false;
        },
        0 => {
            v804 = v799.c0_0;
            v807 = true;
        },
        else => unreachable,
    }
    const v808: US0 = US0_BitZero();
    const v809: US0 = US0_BitOne();
    const v810: *UH4 = UH4_SymbolListNil();
    const v811: *UH4 = UH4_SymbolListCons(v809, v810);
    const v812: *UH4 = UH4_SymbolListCons(v808, v811);
    const v813: *UH13 = dfa_transition_table_105(v803, v812);
    if (v807) {
        v814 = US0_BitZero();
        v815 = US0_BitOne();
        v816 = UH4_SymbolListNil();
        v817 = UH4_SymbolListCons(v815, v816);
        v818 = UH4_SymbolListCons(v814, v817);
        v820 = dfa_closure_closed_108(v803, v818, v803);
    } else {
        v820 = false;
    }
    const v821: bool = regex_list_distinct_110(v803);
    if (v807) {
        v822 = US0_BitZero();
        v823 = US0_BitOne();
        v824 = UH4_SymbolListNil();
        v825 = UH4_SymbolListCons(v823, v824);
        v826 = UH4_SymbolListCons(v822, v825);
        v828 = dfa_formula_consistent_70(v803, v826);
    } else {
        v828 = false;
    }
    if (v807) {
        v829 = US0_BitZero();
        v830 = US0_BitOne();
        v831 = UH4_SymbolListNil();
        v832 = UH4_SymbolListCons(v830, v831);
        v833 = UH4_SymbolListCons(v829, v832);
        v835 = dfa_transition_table_total_111(v803, v833, v813);
    } else {
        v835 = false;
    }
    const v836: bool = dfa_transition_keys_distinct_114(v813);
    if (v807) {
        v837 = regex_position_count_102(v784);
        v838 = UH8_StateBudgetSucc(v837);
        v839 = state_budget_pow2_104(v838);
        v841 = regex_list_within_budget_116(v803, v839);
    } else {
        v841 = false;
    }
    const v842: bool = dfa_states_normalized_117(v803);
    const v843: bool = dfa_states_nullable_preserved_74(v803);
    const v844: bool = regex_order_laws_118(v803);
    const v845: US1 = US1_TriA();
    const v846: *UH3 = UH3_RegexChar(v845);
    const v847: *UH3 = UH3_RegexStar(v846);
    const v848: *UH3 = normalize_14(v847);
    const v849: *UH3 = normalize_14(v848);
    const v850: *UH8 = regex_position_count_120(v849);
    const v851: *UH8 = UH8_StateBudgetSucc(v850);
    const v852: *UH8 = state_budget_pow2_104(v851);
    const v853: *UH3 = normalize_14(v849);
    const v854: US1 = US1_TriA();
    const v855: US1 = US1_TriB();
    const v856: US1 = US1_TriC();
    const v857: *UH6 = UH6_SymbolListNil();
    const v858: *UH6 = UH6_SymbolListCons(v856, v857);
    const v859: *UH6 = UH6_SymbolListCons(v855, v858);
    const v860: *UH6 = UH6_SymbolListCons(v854, v859);
    const v861: *UH10 = UH10_RegexListNil();
    const v862: *UH10 = UH10_RegexListCons(v853, v861);
    const v863: *UH10 = UH10_RegexListNil();
    const v864: *UH10 = UH10_RegexListCons(v853, v863);
    const v865: US8 = dfa_closure_loop_bounded_121(v860, v852, v862, v864);
    switch (v865.tag) {
        1 => {
            v867 = v865.c1_0;
            v869 = v867;
        },
        0 => {
            v866 = v865.c0_0;
            v869 = v866;
        },
        else => unreachable,
    }
    switch (v865.tag) {
        1 => {
            v871 = v865.c1_0;
            v873 = false;
        },
        0 => {
            v870 = v865.c0_0;
            v873 = true;
        },
        else => unreachable,
    }
    const v874: US1 = US1_TriA();
    const v875: US1 = US1_TriB();
    const v876: US1 = US1_TriC();
    const v877: *UH6 = UH6_SymbolListNil();
    const v878: *UH6 = UH6_SymbolListCons(v876, v877);
    const v879: *UH6 = UH6_SymbolListCons(v875, v878);
    const v880: *UH6 = UH6_SymbolListCons(v874, v879);
    const v881: *UH14 = dfa_transition_table_122(v869, v880);
    if (v873) {
        v882 = US1_TriA();
        v883 = US1_TriB();
        v884 = US1_TriC();
        v885 = UH6_SymbolListNil();
        v886 = UH6_SymbolListCons(v884, v885);
        v887 = UH6_SymbolListCons(v883, v886);
        v888 = UH6_SymbolListCons(v882, v887);
        v890 = dfa_closure_closed_125(v869, v888, v869);
    } else {
        v890 = false;
    }
    const v891: bool = regex_list_distinct_127(v869);
    if (v873) {
        v892 = US1_TriA();
        v893 = US1_TriB();
        v894 = US1_TriC();
        v895 = UH6_SymbolListNil();
        v896 = UH6_SymbolListCons(v894, v895);
        v897 = UH6_SymbolListCons(v893, v896);
        v898 = UH6_SymbolListCons(v892, v897);
        v900 = dfa_formula_consistent_128(v869, v898);
    } else {
        v900 = false;
    }
    if (v873) {
        v901 = US1_TriA();
        v902 = US1_TriB();
        v903 = US1_TriC();
        v904 = UH6_SymbolListNil();
        v905 = UH6_SymbolListCons(v903, v904);
        v906 = UH6_SymbolListCons(v902, v905);
        v907 = UH6_SymbolListCons(v901, v906);
        v909 = dfa_transition_table_total_132(v869, v907, v881);
    } else {
        v909 = false;
    }
    const v910: bool = dfa_transition_keys_distinct_135(v881);
    if (v873) {
        v911 = regex_position_count_120(v848);
        v912 = UH8_StateBudgetSucc(v911);
        v913 = state_budget_pow2_104(v912);
        v915 = regex_list_within_budget_137(v869, v913);
    } else {
        v915 = false;
    }
    const v916: bool = dfa_states_normalized_138(v869);
    const v917: bool = dfa_states_nullable_preserved_139(v869);
    const v918: bool = regex_order_laws_140(v869);
    const v919: US1 = US1_TriA();
    const v920: *UH3 = UH3_RegexChar(v919);
    const v921: US1 = US1_TriB();
    const v922: *UH3 = UH3_RegexChar(v921);
    const v923: *UH3 = UH3_RegexAlt(v920, v922);
    const v924: *UH3 = UH3_RegexStar(v923);
    const v925: US1 = US1_TriC();
    const v926: *UH3 = UH3_RegexChar(v925);
    const v927: *UH3 = UH3_RegexCat(v924, v926);
    const v928: *UH3 = normalize_14(v927);
    const v929: *UH3 = normalize_14(v928);
    const v930: *UH8 = regex_position_count_120(v929);
    const v931: *UH8 = UH8_StateBudgetSucc(v930);
    const v932: *UH8 = state_budget_pow2_104(v931);
    const v933: *UH3 = normalize_14(v929);
    const v934: US1 = US1_TriA();
    const v935: US1 = US1_TriB();
    const v936: US1 = US1_TriC();
    const v937: *UH6 = UH6_SymbolListNil();
    const v938: *UH6 = UH6_SymbolListCons(v936, v937);
    const v939: *UH6 = UH6_SymbolListCons(v935, v938);
    const v940: *UH6 = UH6_SymbolListCons(v934, v939);
    const v941: *UH10 = UH10_RegexListNil();
    const v942: *UH10 = UH10_RegexListCons(v933, v941);
    const v943: *UH10 = UH10_RegexListNil();
    const v944: *UH10 = UH10_RegexListCons(v933, v943);
    const v945: US8 = dfa_closure_loop_bounded_121(v940, v932, v942, v944);
    switch (v945.tag) {
        1 => {
            v947 = v945.c1_0;
            v949 = v947;
        },
        0 => {
            v946 = v945.c0_0;
            v949 = v946;
        },
        else => unreachable,
    }
    switch (v945.tag) {
        1 => {
            v951 = v945.c1_0;
            v953 = false;
        },
        0 => {
            v950 = v945.c0_0;
            v953 = true;
        },
        else => unreachable,
    }
    const v954: US1 = US1_TriA();
    const v955: US1 = US1_TriB();
    const v956: US1 = US1_TriC();
    const v957: *UH6 = UH6_SymbolListNil();
    const v958: *UH6 = UH6_SymbolListCons(v956, v957);
    const v959: *UH6 = UH6_SymbolListCons(v955, v958);
    const v960: *UH6 = UH6_SymbolListCons(v954, v959);
    const v961: *UH14 = dfa_transition_table_122(v949, v960);
    if (v953) {
        v962 = US1_TriA();
        v963 = US1_TriB();
        v964 = US1_TriC();
        v965 = UH6_SymbolListNil();
        v966 = UH6_SymbolListCons(v964, v965);
        v967 = UH6_SymbolListCons(v963, v966);
        v968 = UH6_SymbolListCons(v962, v967);
        v970 = dfa_closure_closed_125(v949, v968, v949);
    } else {
        v970 = false;
    }
    const v971: bool = regex_list_distinct_127(v949);
    if (v953) {
        v972 = US1_TriA();
        v973 = US1_TriB();
        v974 = US1_TriC();
        v975 = UH6_SymbolListNil();
        v976 = UH6_SymbolListCons(v974, v975);
        v977 = UH6_SymbolListCons(v973, v976);
        v978 = UH6_SymbolListCons(v972, v977);
        v980 = dfa_formula_consistent_128(v949, v978);
    } else {
        v980 = false;
    }
    if (v953) {
        v981 = US1_TriA();
        v982 = US1_TriB();
        v983 = US1_TriC();
        v984 = UH6_SymbolListNil();
        v985 = UH6_SymbolListCons(v983, v984);
        v986 = UH6_SymbolListCons(v982, v985);
        v987 = UH6_SymbolListCons(v981, v986);
        v989 = dfa_transition_table_total_132(v949, v987, v961);
    } else {
        v989 = false;
    }
    const v990: bool = dfa_transition_keys_distinct_135(v961);
    if (v953) {
        v991 = regex_position_count_120(v928);
        v992 = UH8_StateBudgetSucc(v991);
        v993 = state_budget_pow2_104(v992);
        v995 = regex_list_within_budget_137(v949, v993);
    } else {
        v995 = false;
    }
    const v996: bool = dfa_states_normalized_138(v949);
    const v997: bool = dfa_states_nullable_preserved_139(v949);
    const v998: bool = regex_order_laws_140(v949);
    const v999: US0 = US0_BitZero();
    const v1000: *UH2 = UH2_RegexChar(v999);
    const v1001: US0 = US0_BitOne();
    const v1002: *UH2 = UH2_RegexChar(v1001);
    const v1003: *UH2 = UH2_RegexAlt(v1000, v1002);
    const v1004: *UH2 = UH2_RegexStar(v1003);
    const v1005: US0 = US0_BitZero();
    const v1006: *UH2 = UH2_RegexChar(v1005);
    const v1007: *UH2 = UH2_RegexCat(v1004, v1006);
    const v1008: *UH2 = normalize_4(v1007);
    const v1009: *UH2 = normalize_4(v1008);
    const v1010: *UH8 = regex_position_count_102(v1009);
    const v1011: *UH8 = UH8_StateBudgetSucc(v1010);
    const v1012: *UH8 = state_budget_pow2_104(v1011);
    const v1013: *UH2 = normalize_4(v1009);
    const v1014: US0 = US0_BitZero();
    const v1015: US0 = US0_BitOne();
    const v1016: *UH4 = UH4_SymbolListNil();
    const v1017: *UH4 = UH4_SymbolListCons(v1015, v1016);
    const v1018: *UH4 = UH4_SymbolListCons(v1014, v1017);
    const v1019: *UH9 = UH9_RegexListNil();
    const v1020: *UH9 = UH9_RegexListCons(v1013, v1019);
    const v1021: *UH9 = UH9_RegexListNil();
    const v1022: *UH9 = UH9_RegexListCons(v1013, v1021);
    const v1023: US4 = dfa_closure_loop_bounded_54(v1018, v1012, v1020, v1022);
    switch (v1023.tag) {
        1 => {
            v1025 = v1023.c1_0;
            v1027 = v1025;
        },
        0 => {
            v1024 = v1023.c0_0;
            v1027 = v1024;
        },
        else => unreachable,
    }
    switch (v1023.tag) {
        1 => {
            v1029 = v1023.c1_0;
            v1031 = false;
        },
        0 => {
            v1028 = v1023.c0_0;
            v1031 = true;
        },
        else => unreachable,
    }
    const v1032: US0 = US0_BitZero();
    const v1033: US0 = US0_BitOne();
    const v1034: *UH4 = UH4_SymbolListNil();
    const v1035: *UH4 = UH4_SymbolListCons(v1033, v1034);
    const v1036: *UH4 = UH4_SymbolListCons(v1032, v1035);
    const v1037: *UH9 = UH9_RegexListNil();
    const v1038: *UH9 = dfa_minimize_states_loop_142(v1027, v1036, v1037);
    if (v1031) {
        v1039 = US0_BitZero();
        v1040 = US0_BitOne();
        v1041 = UH4_SymbolListNil();
        v1042 = UH4_SymbolListCons(v1040, v1041);
        v1043 = UH4_SymbolListCons(v1039, v1042);
        v1045 = dfa_states_have_representative_144(v1027, v1038, v1043);
    } else {
        v1045 = false;
    }
    if (v1045) {
        v1046 = US0_BitZero();
        v1047 = US0_BitOne();
        v1048 = UH4_SymbolListNil();
        v1049 = UH4_SymbolListCons(v1047, v1048);
        v1050 = UH4_SymbolListCons(v1046, v1049);
        v1052 = dfa_minimal_by_bisimulation_90(v1038, v1050);
    } else {
        v1052 = false;
    }
    if (v1052) {
        v1053 = US0_BitZero();
        v1054 = US0_BitOne();
        v1055 = UH4_SymbolListNil();
        v1056 = UH4_SymbolListCons(v1054, v1055);
        v1057 = UH4_SymbolListCons(v1053, v1056);
        v1059 = dfa_quotient_closed_145(v1038, v1057, v1038);
    } else {
        v1059 = false;
    }
    const v1060: US1 = US1_TriA();
    const v1061: *UH3 = UH3_RegexChar(v1060);
    const v1062: *UH3 = UH3_RegexStar(v1061);
    const v1063: *UH3 = normalize_14(v1062);
    const v1064: *UH3 = normalize_14(v1063);
    const v1065: *UH8 = regex_position_count_120(v1064);
    const v1066: *UH8 = UH8_StateBudgetSucc(v1065);
    const v1067: *UH8 = state_budget_pow2_104(v1066);
    const v1068: *UH3 = normalize_14(v1064);
    const v1069: US1 = US1_TriA();
    const v1070: US1 = US1_TriB();
    const v1071: US1 = US1_TriC();
    const v1072: *UH6 = UH6_SymbolListNil();
    const v1073: *UH6 = UH6_SymbolListCons(v1071, v1072);
    const v1074: *UH6 = UH6_SymbolListCons(v1070, v1073);
    const v1075: *UH6 = UH6_SymbolListCons(v1069, v1074);
    const v1076: *UH10 = UH10_RegexListNil();
    const v1077: *UH10 = UH10_RegexListCons(v1068, v1076);
    const v1078: *UH10 = UH10_RegexListNil();
    const v1079: *UH10 = UH10_RegexListCons(v1068, v1078);
    const v1080: US8 = dfa_closure_loop_bounded_121(v1075, v1067, v1077, v1079);
    switch (v1080.tag) {
        1 => {
            v1082 = v1080.c1_0;
            v1084 = v1082;
        },
        0 => {
            v1081 = v1080.c0_0;
            v1084 = v1081;
        },
        else => unreachable,
    }
    switch (v1080.tag) {
        1 => {
            v1086 = v1080.c1_0;
            v1088 = false;
        },
        0 => {
            v1085 = v1080.c0_0;
            v1088 = true;
        },
        else => unreachable,
    }
    const v1089: US1 = US1_TriA();
    const v1090: US1 = US1_TriB();
    const v1091: US1 = US1_TriC();
    const v1092: *UH6 = UH6_SymbolListNil();
    const v1093: *UH6 = UH6_SymbolListCons(v1091, v1092);
    const v1094: *UH6 = UH6_SymbolListCons(v1090, v1093);
    const v1095: *UH6 = UH6_SymbolListCons(v1089, v1094);
    const v1096: *UH10 = UH10_RegexListNil();
    const v1097: *UH10 = dfa_minimize_states_loop_147(v1084, v1095, v1096);
    if (v1088) {
        v1098 = US1_TriA();
        v1099 = US1_TriB();
        v1100 = US1_TriC();
        v1101 = UH6_SymbolListNil();
        v1102 = UH6_SymbolListCons(v1100, v1101);
        v1103 = UH6_SymbolListCons(v1099, v1102);
        v1104 = UH6_SymbolListCons(v1098, v1103);
        v1106 = dfa_states_have_representative_149(v1084, v1097, v1104);
    } else {
        v1106 = false;
    }
    if (v1106) {
        v1107 = US1_TriA();
        v1108 = US1_TriB();
        v1109 = US1_TriC();
        v1110 = UH6_SymbolListNil();
        v1111 = UH6_SymbolListCons(v1109, v1110);
        v1112 = UH6_SymbolListCons(v1108, v1111);
        v1113 = UH6_SymbolListCons(v1107, v1112);
        v1115 = dfa_minimal_by_bisimulation_95(v1097, v1113);
    } else {
        v1115 = false;
    }
    if (v1115) {
        v1116 = US1_TriA();
        v1117 = US1_TriB();
        v1118 = US1_TriC();
        v1119 = UH6_SymbolListNil();
        v1120 = UH6_SymbolListCons(v1118, v1119);
        v1121 = UH6_SymbolListCons(v1117, v1120);
        v1122 = UH6_SymbolListCons(v1116, v1121);
        v1124 = dfa_quotient_closed_150(v1097, v1122, v1097);
    } else {
        v1124 = false;
    }
    const v1125: US1 = US1_TriA();
    const v1126: *UH3 = UH3_RegexChar(v1125);
    const v1127: US1 = US1_TriB();
    const v1128: *UH3 = UH3_RegexChar(v1127);
    const v1129: *UH3 = UH3_RegexAlt(v1126, v1128);
    const v1130: *UH3 = UH3_RegexStar(v1129);
    const v1131: US1 = US1_TriC();
    const v1132: *UH3 = UH3_RegexChar(v1131);
    const v1133: *UH3 = UH3_RegexCat(v1130, v1132);
    const v1134: *UH3 = normalize_14(v1133);
    const v1135: *UH3 = normalize_14(v1134);
    const v1136: *UH8 = regex_position_count_120(v1135);
    const v1137: *UH8 = UH8_StateBudgetSucc(v1136);
    const v1138: *UH8 = state_budget_pow2_104(v1137);
    const v1139: *UH3 = normalize_14(v1135);
    const v1140: US1 = US1_TriA();
    const v1141: US1 = US1_TriB();
    const v1142: US1 = US1_TriC();
    const v1143: *UH6 = UH6_SymbolListNil();
    const v1144: *UH6 = UH6_SymbolListCons(v1142, v1143);
    const v1145: *UH6 = UH6_SymbolListCons(v1141, v1144);
    const v1146: *UH6 = UH6_SymbolListCons(v1140, v1145);
    const v1147: *UH10 = UH10_RegexListNil();
    const v1148: *UH10 = UH10_RegexListCons(v1139, v1147);
    const v1149: *UH10 = UH10_RegexListNil();
    const v1150: *UH10 = UH10_RegexListCons(v1139, v1149);
    const v1151: US8 = dfa_closure_loop_bounded_121(v1146, v1138, v1148, v1150);
    switch (v1151.tag) {
        1 => {
            v1153 = v1151.c1_0;
            v1155 = v1153;
        },
        0 => {
            v1152 = v1151.c0_0;
            v1155 = v1152;
        },
        else => unreachable,
    }
    switch (v1151.tag) {
        1 => {
            v1157 = v1151.c1_0;
            v1159 = false;
        },
        0 => {
            v1156 = v1151.c0_0;
            v1159 = true;
        },
        else => unreachable,
    }
    const v1160: US1 = US1_TriA();
    const v1161: US1 = US1_TriB();
    const v1162: US1 = US1_TriC();
    const v1163: *UH6 = UH6_SymbolListNil();
    const v1164: *UH6 = UH6_SymbolListCons(v1162, v1163);
    const v1165: *UH6 = UH6_SymbolListCons(v1161, v1164);
    const v1166: *UH6 = UH6_SymbolListCons(v1160, v1165);
    const v1167: *UH10 = UH10_RegexListNil();
    const v1168: *UH10 = dfa_minimize_states_loop_147(v1155, v1166, v1167);
    if (v1159) {
        v1169 = US1_TriA();
        v1170 = US1_TriB();
        v1171 = US1_TriC();
        v1172 = UH6_SymbolListNil();
        v1173 = UH6_SymbolListCons(v1171, v1172);
        v1174 = UH6_SymbolListCons(v1170, v1173);
        v1175 = UH6_SymbolListCons(v1169, v1174);
        v1177 = dfa_states_have_representative_149(v1155, v1168, v1175);
    } else {
        v1177 = false;
    }
    if (v1177) {
        v1178 = US1_TriA();
        v1179 = US1_TriB();
        v1180 = US1_TriC();
        v1181 = UH6_SymbolListNil();
        v1182 = UH6_SymbolListCons(v1180, v1181);
        v1183 = UH6_SymbolListCons(v1179, v1182);
        v1184 = UH6_SymbolListCons(v1178, v1183);
        v1186 = dfa_minimal_by_bisimulation_95(v1168, v1184);
    } else {
        v1186 = false;
    }
    if (v1186) {
        v1187 = US1_TriA();
        v1188 = US1_TriB();
        v1189 = US1_TriC();
        v1190 = UH6_SymbolListNil();
        v1191 = UH6_SymbolListCons(v1189, v1190);
        v1192 = UH6_SymbolListCons(v1188, v1191);
        v1193 = UH6_SymbolListCons(v1187, v1192);
        v1195 = dfa_quotient_closed_150(v1168, v1193, v1168);
    } else {
        v1195 = false;
    }
    const v1196: US1 = US1_TriA();
    const v1197: *UH3 = UH3_RegexChar(v1196);
    const v1198: US1 = US1_TriA();
    const v1199: *UH3 = UH3_RegexChar(v1198);
    const v1200: *UH3 = UH3_RegexStar(v1199);
    const v1201: *UH3 = UH3_RegexCat(v1197, v1200);
    const v1202: US1 = US1_TriB();
    const v1203: *UH3 = UH3_RegexChar(v1202);
    const v1204: US1 = US1_TriA();
    const v1205: *UH3 = UH3_RegexChar(v1204);
    const v1206: US1 = US1_TriA();
    const v1207: *UH3 = UH3_RegexChar(v1206);
    const v1208: *UH3 = UH3_RegexCat(v1205, v1207);
    const v1209: *UH3 = UH3_RegexStar(v1208);
    const v1210: US1 = US1_TriA();
    const v1211: *UH3 = UH3_RegexChar(v1210);
    const v1212: *UH3 = UH3_RegexCat(v1211, v1209);
    const v1213: *UH3 = UH3_RegexAlt(v1209, v1212);
    const v1214: *UH3 = UH3_RegexCat(v1203, v1213);
    const v1215: *UH3 = UH3_RegexAlt(v1201, v1214);
    const v1216: *UH3 = normalize_14(v1215);
    const v1217: *UH3 = normalize_14(v1216);
    const v1218: *UH8 = regex_position_count_120(v1217);
    const v1219: *UH8 = UH8_StateBudgetSucc(v1218);
    const v1220: *UH8 = state_budget_pow2_104(v1219);
    const v1221: *UH3 = normalize_14(v1217);
    const v1222: US1 = US1_TriA();
    const v1223: US1 = US1_TriB();
    const v1224: US1 = US1_TriC();
    const v1225: *UH6 = UH6_SymbolListNil();
    const v1226: *UH6 = UH6_SymbolListCons(v1224, v1225);
    const v1227: *UH6 = UH6_SymbolListCons(v1223, v1226);
    const v1228: *UH6 = UH6_SymbolListCons(v1222, v1227);
    const v1229: *UH10 = UH10_RegexListNil();
    const v1230: *UH10 = UH10_RegexListCons(v1221, v1229);
    const v1231: *UH10 = UH10_RegexListNil();
    const v1232: *UH10 = UH10_RegexListCons(v1221, v1231);
    const v1233: US8 = dfa_closure_loop_bounded_121(v1228, v1220, v1230, v1232);
    switch (v1233.tag) {
        1 => {
            v1235 = v1233.c1_0;
            v1237 = v1235;
        },
        0 => {
            v1234 = v1233.c0_0;
            v1237 = v1234;
        },
        else => unreachable,
    }
    switch (v1233.tag) {
        1 => {
            v1239 = v1233.c1_0;
            v1241 = false;
        },
        0 => {
            v1238 = v1233.c0_0;
            v1241 = true;
        },
        else => unreachable,
    }
    const v1242: US1 = US1_TriA();
    const v1243: US1 = US1_TriB();
    const v1244: US1 = US1_TriC();
    const v1245: *UH6 = UH6_SymbolListNil();
    const v1246: *UH6 = UH6_SymbolListCons(v1244, v1245);
    const v1247: *UH6 = UH6_SymbolListCons(v1243, v1246);
    const v1248: *UH6 = UH6_SymbolListCons(v1242, v1247);
    const v1249: *UH10 = UH10_RegexListNil();
    const v1250: *UH10 = dfa_minimize_states_loop_147(v1237, v1248, v1249);
    if (v1241) {
        v1251 = US1_TriA();
        v1252 = US1_TriB();
        v1253 = US1_TriC();
        v1254 = UH6_SymbolListNil();
        v1255 = UH6_SymbolListCons(v1253, v1254);
        v1256 = UH6_SymbolListCons(v1252, v1255);
        v1257 = UH6_SymbolListCons(v1251, v1256);
        v1259 = dfa_states_have_representative_149(v1237, v1250, v1257);
    } else {
        v1259 = false;
    }
    if (v1259) {
        v1260 = US1_TriA();
        v1261 = US1_TriB();
        v1262 = US1_TriC();
        v1263 = UH6_SymbolListNil();
        v1264 = UH6_SymbolListCons(v1262, v1263);
        v1265 = UH6_SymbolListCons(v1261, v1264);
        v1266 = UH6_SymbolListCons(v1260, v1265);
        v1268 = dfa_minimal_by_bisimulation_95(v1250, v1266);
    } else {
        v1268 = false;
    }
    if (v1268) {
        v1269 = US1_TriA();
        v1270 = US1_TriB();
        v1271 = US1_TriC();
        v1272 = UH6_SymbolListNil();
        v1273 = UH6_SymbolListCons(v1271, v1272);
        v1274 = UH6_SymbolListCons(v1270, v1273);
        v1275 = UH6_SymbolListCons(v1269, v1274);
        v1277 = dfa_quotient_closed_150(v1250, v1275, v1250);
    } else {
        v1277 = false;
    }
    if (v1045) {
        v1278 = (v1052 and v1059);
        v1279 = v1278;
    } else {
        v1279 = false;
    }
    if (v1279) {
    } else {
        if (spiral_true) spiralFail("bit minimized DFA should be certified");
    }
    if (v1106) {
        v1280 = (v1115 and v1124);
        v1281 = v1280;
    } else {
        v1281 = false;
    }
    if (v1281) {
    } else {
        if (spiral_true) spiralFail("ternary star minimized DFA should be certified");
    }
    if (v1177) {
        v1282 = (v1186 and v1195);
        v1283 = v1282;
    } else {
        v1283 = false;
    }
    if (v1283) {
    } else {
        if (spiral_true) spiralFail("ternary suffix minimized DFA should be certified");
    }
    if (v1259) {
        v1284 = (v1268 and v1277);
        v1285 = v1284;
    } else {
        v1285 = false;
    }
    if (v1285) {
    } else {
        if (spiral_true) spiralFail("cyclic quotient should be certified");
    }
    if (v820) {
    } else {
        if (spiral_true) spiralFail("bit DFA closure should be closed");
    }
    if (v890) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA closure should be closed");
    }
    if (v970) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA closure should be closed");
    }
    if (v821) {
    } else {
        if (spiral_true) spiralFail("bit DFA states should be distinct");
    }
    if (v891) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA states should be distinct");
    }
    if (v971) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA states should be distinct");
    }
    if (v828) {
    } else {
        if (spiral_true) spiralFail("bit DFA derivative formulas should be structurally consistent");
    }
    if (v900) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA derivative formulas should be structurally consistent");
    }
    if (v980) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA derivative formulas should be structurally consistent");
    }
    if (v835) {
    } else {
        if (spiral_true) spiralFail("bit DFA table should be total");
    }
    if (v909) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA table should be total");
    }
    if (v989) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA table should be total");
    }
    if (v836) {
    } else {
        if (spiral_true) spiralFail("bit DFA table keys should be unique");
    }
    if (v910) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA table keys should be unique");
    }
    if (v990) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA table keys should be unique");
    }
    if (v841) {
    } else {
        if (spiral_true) spiralFail("bit DFA should satisfy its structural position-subset bound");
    }
    if (v915) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA should satisfy its structural position-subset bound");
    }
    if (v995) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA should satisfy its structural position-subset bound");
    }
    if (v842) {
    } else {
        if (spiral_true) spiralFail("bit DFA states should be normalized");
    }
    if (v916) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA states should be normalized");
    }
    if (v996) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA states should be normalized");
    }
    if (v843) {
    } else {
        if (spiral_true) spiralFail("bit DFA normalization should preserve nullable");
    }
    if (v917) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA normalization should preserve nullable");
    }
    if (v997) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA normalization should preserve nullable");
    }
    if (v844) {
    } else {
        if (spiral_true) spiralFail("bit DFA ordering should be coherent");
    }
    if (v918) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA ordering should be coherent");
    }
    if (v998) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA ordering should be coherent");
    }
    if (v820) {
        if (v821) {
            if (v828) {
                if (v835) {
                    if (v836) {
                        if (v841) {
                            if (v842) {
                                v1286 = (v843 and v844);
                                v1293 = v1286;
                            } else {
                                v1293 = false;
                            }
                        } else {
                            v1293 = false;
                        }
                    } else {
                        v1293 = false;
                    }
                } else {
                    v1293 = false;
                }
            } else {
                v1293 = false;
            }
        } else {
            v1293 = false;
        }
    } else {
        v1293 = false;
    }
    if (v1293) {
    } else {
        if (spiral_true) spiralFail("bit DFA surface should be certified");
    }
    if (v890) {
        if (v891) {
            if (v900) {
                if (v909) {
                    if (v910) {
                        if (v915) {
                            if (v916) {
                                v1294 = (v917 and v918);
                                v1301 = v1294;
                            } else {
                                v1301 = false;
                            }
                        } else {
                            v1301 = false;
                        }
                    } else {
                        v1301 = false;
                    }
                } else {
                    v1301 = false;
                }
            } else {
                v1301 = false;
            }
        } else {
            v1301 = false;
        }
    } else {
        v1301 = false;
    }
    if (v1301) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA surface should be certified");
    }
    if (v970) {
        if (v971) {
            if (v980) {
                if (v989) {
                    if (v990) {
                        if (v995) {
                            if (v996) {
                                v1302 = (v997 and v998);
                                v1309 = v1302;
                            } else {
                                v1309 = false;
                            }
                        } else {
                            v1309 = false;
                        }
                    } else {
                        v1309 = false;
                    }
                } else {
                    v1309 = false;
                }
            } else {
                v1309 = false;
            }
        } else {
            v1309 = false;
        }
    } else {
        v1309 = false;
    }
    if (v1309) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA surface should be certified");
    }
    const v1310: US1 = US1_TriA();
    const v1311: *UH3 = UH3_RegexChar(v1310);
    const v1312: US1 = US1_TriB();
    const v1313: *UH3 = UH3_RegexChar(v1312);
    const v1314: US1 = US1_TriC();
    const v1315: *UH3 = UH3_RegexChar(v1314);
    const v1316: *UH3 = UH3_RegexCat(v1313, v1315);
    const v1317: *UH3 = UH3_RegexCat(v1311, v1316);
    const v1318: *UH3 = normalize_14(v1317);
    const v1319: US1 = US1_TriA();
    const v1320: US1 = US1_TriB();
    const v1321: US1 = US1_TriC();
    const v1322: *UH6 = UH6_SymbolListNil();
    const v1323: *UH6 = UH6_SymbolListCons(v1321, v1322);
    const v1324: *UH6 = UH6_SymbolListCons(v1320, v1323);
    const v1325: *UH6 = UH6_SymbolListCons(v1319, v1324);
    const v1326: *UH10 = UH10_RegexListNil();
    const v1327: *UH10 = UH10_RegexListCons(v1318, v1326);
    const v1328: *UH10 = UH10_RegexListNil();
    const v1329: *UH10 = UH10_RegexListCons(v1318, v1328);
    const v1330: *UH10 = dfa_closure_loop_84(v1325, v1327, v1329);
    const v1331: *UH8 = UH8_StateBudgetZero();
    const v1332: *UH8 = UH8_StateBudgetSucc(v1331);
    const v1333: *UH8 = UH8_StateBudgetSucc(v1332);
    const v1334: *UH8 = UH8_StateBudgetSucc(v1333);
    const v1335: *UH8 = UH8_StateBudgetSucc(v1334);
    const v1336: bool = regex_list_within_budget_137(v1330, v1335);
    const v1337: bool = v1336 == false;
    if (v1337) {
    } else {
        if (spiral_true) spiralFail("three-symbol sequence should exceed the four-state budget");
    }
    const v1338: *UH8 = UH8_StateBudgetZero();
    const v1339: *UH8 = UH8_StateBudgetSucc(v1338);
    const v1340: *UH8 = UH8_StateBudgetSucc(v1339);
    const v1341: *UH8 = UH8_StateBudgetSucc(v1340);
    const v1342: *UH8 = UH8_StateBudgetSucc(v1341);
    const v1343: *UH8 = UH8_StateBudgetSucc(v1342);
    const v1344: *UH8 = UH8_StateBudgetSucc(v1343);
    const v1345: *UH8 = UH8_StateBudgetSucc(v1344);
    const v1346: *UH8 = UH8_StateBudgetSucc(v1345);
    const v1347: bool = regex_list_within_budget_137(v1330, v1346);
    if (v1347) {
    } else {
        if (spiral_true) spiralFail("three-symbol sequence should fit the eight-state budget");
    }
    const v1348: US0 = US0_BitZero();
    const v1349: *UH2 = UH2_RegexChar(v1348);
    const v1350: US0 = US0_BitOne();
    const v1351: *UH2 = UH2_RegexChar(v1350);
    const v1352: *UH2 = UH2_RegexAlt(v1349, v1351);
    const v1353: *UH2 = UH2_RegexStar(v1352);
    const v1354: US0 = US0_BitZero();
    const v1355: *UH2 = UH2_RegexChar(v1354);
    const v1356: *UH2 = UH2_RegexCat(v1353, v1355);
    const v1357: *UH2 = normalize_4(v1356);
    const v1358: *UH2 = normalize_4(v1357);
    const v1359: *UH8 = regex_position_count_102(v1358);
    const v1360: *UH8 = UH8_StateBudgetSucc(v1359);
    const v1361: *UH8 = state_budget_pow2_104(v1360);
    const v1362: *UH2 = normalize_4(v1358);
    const v1363: US0 = US0_BitZero();
    const v1364: US0 = US0_BitOne();
    const v1365: *UH4 = UH4_SymbolListNil();
    const v1366: *UH4 = UH4_SymbolListCons(v1364, v1365);
    const v1367: *UH4 = UH4_SymbolListCons(v1363, v1366);
    const v1368: *UH9 = UH9_RegexListNil();
    const v1369: *UH9 = UH9_RegexListCons(v1362, v1368);
    const v1370: *UH9 = UH9_RegexListNil();
    const v1371: *UH9 = UH9_RegexListCons(v1362, v1370);
    const v1372: US4 = dfa_closure_loop_bounded_54(v1367, v1361, v1369, v1371);
    switch (v1372.tag) {
        1 => {
            v1378 = v1372.c1_0;
            v1380 = false;
        },
        0 => {
            v1373 = v1372.c0_0;
            v1374 = regex_position_count_102(v1357);
            v1375 = UH8_StateBudgetSucc(v1374);
            v1376 = state_budget_pow2_104(v1375);
            v1380 = regex_list_within_budget_116(v1373, v1376);
        },
        else => unreachable,
    }
    if (v1380) {
    } else {
        if (spiral_true) spiralFail("bit canonical closure should stay within its structural position-subset bound");
    }
    const v1381: US1 = US1_TriA();
    const v1382: *UH3 = UH3_RegexChar(v1381);
    const v1383: US1 = US1_TriB();
    const v1384: *UH3 = UH3_RegexChar(v1383);
    const v1385: *UH3 = UH3_RegexAlt(v1382, v1384);
    const v1386: *UH3 = UH3_RegexStar(v1385);
    const v1387: US1 = US1_TriC();
    const v1388: *UH3 = UH3_RegexChar(v1387);
    const v1389: *UH3 = UH3_RegexCat(v1386, v1388);
    const v1390: *UH3 = normalize_14(v1389);
    const v1391: *UH3 = normalize_14(v1390);
    const v1392: *UH8 = regex_position_count_120(v1391);
    const v1393: *UH8 = UH8_StateBudgetSucc(v1392);
    const v1394: *UH8 = state_budget_pow2_104(v1393);
    const v1395: *UH3 = normalize_14(v1391);
    const v1396: US1 = US1_TriA();
    const v1397: US1 = US1_TriB();
    const v1398: US1 = US1_TriC();
    const v1399: *UH6 = UH6_SymbolListNil();
    const v1400: *UH6 = UH6_SymbolListCons(v1398, v1399);
    const v1401: *UH6 = UH6_SymbolListCons(v1397, v1400);
    const v1402: *UH6 = UH6_SymbolListCons(v1396, v1401);
    const v1403: *UH10 = UH10_RegexListNil();
    const v1404: *UH10 = UH10_RegexListCons(v1395, v1403);
    const v1405: *UH10 = UH10_RegexListNil();
    const v1406: *UH10 = UH10_RegexListCons(v1395, v1405);
    const v1407: US8 = dfa_closure_loop_bounded_121(v1402, v1394, v1404, v1406);
    switch (v1407.tag) {
        1 => {
            v1413 = v1407.c1_0;
            v1415 = false;
        },
        0 => {
            v1408 = v1407.c0_0;
            v1409 = regex_position_count_120(v1390);
            v1410 = UH8_StateBudgetSucc(v1409);
            v1411 = state_budget_pow2_104(v1410);
            v1415 = regex_list_within_budget_137(v1408, v1411);
        },
        else => unreachable,
    }
    if (v1415) {
    } else {
        if (spiral_true) spiralFail("ternary suffix closure should stay within its structural position-subset bound");
    }
    const v1416: US0 = US0_BitZero();
    const v1417: *UH2 = UH2_RegexChar(v1416);
    const v1418: US0 = US0_BitOne();
    const v1419: *UH2 = UH2_RegexChar(v1418);
    const v1420: *UH2 = UH2_RegexAlt(v1417, v1419);
    const v1421: *UH2 = UH2_RegexStar(v1420);
    const v1422: US0 = US0_BitZero();
    const v1423: *UH2 = UH2_RegexChar(v1422);
    const v1424: *UH2 = UH2_RegexCat(v1421, v1423);
    const v1425: *UH2 = normalize_4(v1424);
    const v1426: *UH2 = normalize_4(v1425);
    const v1427: *UH8 = regex_position_count_102(v1426);
    const v1428: *UH8 = UH8_StateBudgetSucc(v1427);
    const v1429: *UH8 = state_budget_pow2_104(v1428);
    const v1430: *UH2 = normalize_4(v1426);
    const v1431: US0 = US0_BitZero();
    const v1432: US0 = US0_BitOne();
    const v1433: *UH4 = UH4_SymbolListNil();
    const v1434: *UH4 = UH4_SymbolListCons(v1432, v1433);
    const v1435: *UH4 = UH4_SymbolListCons(v1431, v1434);
    const v1436: *UH9 = UH9_RegexListNil();
    const v1437: *UH9 = UH9_RegexListCons(v1430, v1436);
    const v1438: *UH9 = UH9_RegexListNil();
    const v1439: *UH9 = UH9_RegexListCons(v1430, v1438);
    const v1440: US4 = dfa_closure_loop_bounded_54(v1435, v1429, v1437, v1439);
    switch (v1440.tag) {
        1 => {
            v1453 = v1440.c1_0;
            v1455 = false;
        },
        0 => {
            v1441 = v1440.c0_0;
            v1442 = US0_BitZero();
            v1443 = US0_BitOne();
            v1444 = UH4_SymbolListNil();
            v1445 = UH4_SymbolListCons(v1443, v1444);
            v1446 = UH4_SymbolListCons(v1442, v1445);
            v1447 = UH9_RegexListNil();
            v1448 = dfa_minimize_states_loop_142(v1441, v1446, v1447);
            v1449 = regex_position_count_102(v1425);
            v1450 = UH8_StateBudgetSucc(v1449);
            v1451 = state_budget_pow2_104(v1450);
            v1455 = regex_list_within_budget_116(v1448, v1451);
        },
        else => unreachable,
    }
    if (v1455) {
    } else {
        if (spiral_true) spiralFail("bit minimized DFA should stay within its structural position-subset bound");
    }
    const v1456: US1 = US1_TriA();
    const v1457: *UH3 = UH3_RegexChar(v1456);
    const v1458: US1 = US1_TriA();
    const v1459: *UH3 = UH3_RegexChar(v1458);
    const v1460: *UH3 = UH3_RegexStar(v1459);
    const v1461: *UH3 = UH3_RegexCat(v1457, v1460);
    const v1462: US1 = US1_TriB();
    const v1463: *UH3 = UH3_RegexChar(v1462);
    const v1464: US1 = US1_TriA();
    const v1465: *UH3 = UH3_RegexChar(v1464);
    const v1466: US1 = US1_TriA();
    const v1467: *UH3 = UH3_RegexChar(v1466);
    const v1468: *UH3 = UH3_RegexCat(v1465, v1467);
    const v1469: *UH3 = UH3_RegexStar(v1468);
    const v1470: US1 = US1_TriA();
    const v1471: *UH3 = UH3_RegexChar(v1470);
    const v1472: *UH3 = UH3_RegexCat(v1471, v1469);
    const v1473: *UH3 = UH3_RegexAlt(v1469, v1472);
    const v1474: *UH3 = UH3_RegexCat(v1463, v1473);
    const v1475: *UH3 = UH3_RegexAlt(v1461, v1474);
    const v1476: *UH3 = normalize_14(v1475);
    const v1477: *UH3 = normalize_14(v1476);
    const v1478: *UH8 = regex_position_count_120(v1477);
    const v1479: *UH8 = UH8_StateBudgetSucc(v1478);
    const v1480: *UH8 = state_budget_pow2_104(v1479);
    const v1481: *UH3 = normalize_14(v1477);
    const v1482: US1 = US1_TriA();
    const v1483: US1 = US1_TriB();
    const v1484: US1 = US1_TriC();
    const v1485: *UH6 = UH6_SymbolListNil();
    const v1486: *UH6 = UH6_SymbolListCons(v1484, v1485);
    const v1487: *UH6 = UH6_SymbolListCons(v1483, v1486);
    const v1488: *UH6 = UH6_SymbolListCons(v1482, v1487);
    const v1489: *UH10 = UH10_RegexListNil();
    const v1490: *UH10 = UH10_RegexListCons(v1481, v1489);
    const v1491: *UH10 = UH10_RegexListNil();
    const v1492: *UH10 = UH10_RegexListCons(v1481, v1491);
    const v1493: US8 = dfa_closure_loop_bounded_121(v1488, v1480, v1490, v1492);
    switch (v1493.tag) {
        1 => {
            v1508 = v1493.c1_0;
            v1510 = false;
        },
        0 => {
            v1494 = v1493.c0_0;
            v1495 = US1_TriA();
            v1496 = US1_TriB();
            v1497 = US1_TriC();
            v1498 = UH6_SymbolListNil();
            v1499 = UH6_SymbolListCons(v1497, v1498);
            v1500 = UH6_SymbolListCons(v1496, v1499);
            v1501 = UH6_SymbolListCons(v1495, v1500);
            v1502 = UH10_RegexListNil();
            v1503 = dfa_minimize_states_loop_147(v1494, v1501, v1502);
            v1504 = regex_position_count_120(v1476);
            v1505 = UH8_StateBudgetSucc(v1504);
            v1506 = state_budget_pow2_104(v1505);
            v1510 = regex_list_within_budget_137(v1503, v1506);
        },
        else => unreachable,
    }
    if (v1510) {
    } else {
        if (spiral_true) spiralFail("cyclic minimized DFA should stay within its structural position-subset bound");
    }
    const v1511: US0 = US0_BitOne();
    const v1512: US0 = US0_BitOne();
    const v1513: US0 = US0_BitZero();
    const v1514: *UH0 = UH0_InputEmpty();
    const v1515: *UH0 = UH0_InputCons(v1513, v1514);
    const v1516: *UH0 = UH0_InputCons(v1512, v1515);
    const v1517: *UH0 = UH0_InputCons(v1511, v1516);
    const v1518: US0 = US0_BitZero();
    const v1519: US0 = US0_BitOne();
    const v1520: *UH4 = UH4_SymbolListNil();
    const v1521: *UH4 = UH4_SymbolListCons(v1519, v1520);
    const v1522: *UH4 = UH4_SymbolListCons(v1518, v1521);
    const v1523: bool = input_symbols_covered_52(v1517, v1522);
    if (v1523) {
        v1524 = US0_BitZero();
        v1525 = UH2_RegexChar(v1524);
        v1526 = US0_BitOne();
        v1527 = UH2_RegexChar(v1526);
        v1528 = UH2_RegexAlt(v1525, v1527);
        v1529 = UH2_RegexStar(v1528);
        v1530 = US0_BitZero();
        v1531 = UH2_RegexChar(v1530);
        v1532 = UH2_RegexCat(v1529, v1531);
        v1533 = normalize_4(v1532);
        v1534 = normalize_4(v1533);
        v1535 = regex_position_count_102(v1534);
        v1536 = UH8_StateBudgetSucc(v1535);
        v1537 = state_budget_pow2_104(v1536);
        v1538 = normalize_4(v1534);
        v1539 = US0_BitZero();
        v1540 = US0_BitOne();
        v1541 = UH4_SymbolListNil();
        v1542 = UH4_SymbolListCons(v1540, v1541);
        v1543 = UH4_SymbolListCons(v1539, v1542);
        v1544 = UH9_RegexListNil();
        v1545 = UH9_RegexListCons(v1538, v1544);
        v1546 = UH9_RegexListNil();
        v1547 = UH9_RegexListCons(v1538, v1546);
        v1548 = dfa_closure_loop_bounded_54(v1543, v1537, v1545, v1547);
        switch (v1548.tag) {
            1 => {
                v1558 = v1548.c1_0;
                v1563 = US12_DfaEscapedClosure();
            },
            0 => {
                v1549 = v1548.c0_0;
                v1550 = US0_BitOne();
                v1551 = US0_BitOne();
                v1552 = US0_BitZero();
                v1553 = UH0_InputEmpty();
                v1554 = UH0_InputCons(v1552, v1553);
                v1555 = UH0_InputCons(v1551, v1554);
                v1556 = UH0_InputCons(v1550, v1555);
                v1563 = dfa_run_in_closure_152(v1533, v1549, v1556);
            },
            else => unreachable,
        }
    } else {
        v1563 = US12_DfaEscapedClosure();
    }
    const v1564: US0 = US0_BitZero();
    const v1565: *UH2 = UH2_RegexChar(v1564);
    const v1566: US0 = US0_BitOne();
    const v1567: *UH2 = UH2_RegexChar(v1566);
    const v1568: *UH2 = UH2_RegexAlt(v1565, v1567);
    const v1569: *UH2 = UH2_RegexStar(v1568);
    const v1570: US0 = US0_BitZero();
    const v1571: *UH2 = UH2_RegexChar(v1570);
    const v1572: *UH2 = UH2_RegexCat(v1569, v1571);
    const v1573: US0 = US0_BitOne();
    const v1574: US0 = US0_BitOne();
    const v1575: US0 = US0_BitZero();
    const v1576: *UH0 = UH0_InputEmpty();
    const v1577: *UH0 = UH0_InputCons(v1575, v1576);
    const v1578: *UH0 = UH0_InputCons(v1574, v1577);
    const v1579: *UH0 = UH0_InputCons(v1573, v1578);
    const v1580: bool = accepts_2(v1572, v1579);
    switch (v1563.tag) {
        0 => {
            v1583 = v1580;
        },
        1 => {
            v1581 = false == v1580;
            v1583 = v1581;
        },
        else => {
            v1583 = false;
        },
    }
    if (v1583) {
    } else {
        if (spiral_true) spiralFail("bit DFA runner should preserve acceptance");
    }
    const v1584: US0 = US0_BitOne();
    const v1585: US0 = US0_BitOne();
    const v1586: US0 = US0_BitOne();
    const v1587: *UH0 = UH0_InputEmpty();
    const v1588: *UH0 = UH0_InputCons(v1586, v1587);
    const v1589: *UH0 = UH0_InputCons(v1585, v1588);
    const v1590: *UH0 = UH0_InputCons(v1584, v1589);
    const v1591: US0 = US0_BitZero();
    const v1592: US0 = US0_BitOne();
    const v1593: *UH4 = UH4_SymbolListNil();
    const v1594: *UH4 = UH4_SymbolListCons(v1592, v1593);
    const v1595: *UH4 = UH4_SymbolListCons(v1591, v1594);
    const v1596: bool = input_symbols_covered_52(v1590, v1595);
    if (v1596) {
        v1597 = US0_BitZero();
        v1598 = UH2_RegexChar(v1597);
        v1599 = US0_BitOne();
        v1600 = UH2_RegexChar(v1599);
        v1601 = UH2_RegexAlt(v1598, v1600);
        v1602 = UH2_RegexStar(v1601);
        v1603 = US0_BitZero();
        v1604 = UH2_RegexChar(v1603);
        v1605 = UH2_RegexCat(v1602, v1604);
        v1606 = normalize_4(v1605);
        v1607 = normalize_4(v1606);
        v1608 = regex_position_count_102(v1607);
        v1609 = UH8_StateBudgetSucc(v1608);
        v1610 = state_budget_pow2_104(v1609);
        v1611 = normalize_4(v1607);
        v1612 = US0_BitZero();
        v1613 = US0_BitOne();
        v1614 = UH4_SymbolListNil();
        v1615 = UH4_SymbolListCons(v1613, v1614);
        v1616 = UH4_SymbolListCons(v1612, v1615);
        v1617 = UH9_RegexListNil();
        v1618 = UH9_RegexListCons(v1611, v1617);
        v1619 = UH9_RegexListNil();
        v1620 = UH9_RegexListCons(v1611, v1619);
        v1621 = dfa_closure_loop_bounded_54(v1616, v1610, v1618, v1620);
        switch (v1621.tag) {
            1 => {
                v1631 = v1621.c1_0;
                v1636 = US12_DfaEscapedClosure();
            },
            0 => {
                v1622 = v1621.c0_0;
                v1623 = US0_BitOne();
                v1624 = US0_BitOne();
                v1625 = US0_BitOne();
                v1626 = UH0_InputEmpty();
                v1627 = UH0_InputCons(v1625, v1626);
                v1628 = UH0_InputCons(v1624, v1627);
                v1629 = UH0_InputCons(v1623, v1628);
                v1636 = dfa_run_in_closure_152(v1606, v1622, v1629);
            },
            else => unreachable,
        }
    } else {
        v1636 = US12_DfaEscapedClosure();
    }
    const v1637: US0 = US0_BitZero();
    const v1638: *UH2 = UH2_RegexChar(v1637);
    const v1639: US0 = US0_BitOne();
    const v1640: *UH2 = UH2_RegexChar(v1639);
    const v1641: *UH2 = UH2_RegexAlt(v1638, v1640);
    const v1642: *UH2 = UH2_RegexStar(v1641);
    const v1643: US0 = US0_BitZero();
    const v1644: *UH2 = UH2_RegexChar(v1643);
    const v1645: *UH2 = UH2_RegexCat(v1642, v1644);
    const v1646: US0 = US0_BitOne();
    const v1647: US0 = US0_BitOne();
    const v1648: US0 = US0_BitOne();
    const v1649: *UH0 = UH0_InputEmpty();
    const v1650: *UH0 = UH0_InputCons(v1648, v1649);
    const v1651: *UH0 = UH0_InputCons(v1647, v1650);
    const v1652: *UH0 = UH0_InputCons(v1646, v1651);
    const v1653: bool = accepts_2(v1645, v1652);
    switch (v1636.tag) {
        0 => {
            v1656 = v1653;
        },
        1 => {
            v1654 = false == v1653;
            v1656 = v1654;
        },
        else => {
            v1656 = false;
        },
    }
    if (v1656) {
    } else {
        if (spiral_true) spiralFail("bit DFA runner should preserve rejection");
    }
    const v1657: US1 = US1_TriA();
    const v1658: US1 = US1_TriA();
    const v1659: US1 = US1_TriA();
    const v1660: *UH1 = UH1_InputEmpty();
    const v1661: *UH1 = UH1_InputCons(v1659, v1660);
    const v1662: *UH1 = UH1_InputCons(v1658, v1661);
    const v1663: *UH1 = UH1_InputCons(v1657, v1662);
    const v1664: US1 = US1_TriA();
    const v1665: US1 = US1_TriB();
    const v1666: US1 = US1_TriC();
    const v1667: *UH6 = UH6_SymbolListNil();
    const v1668: *UH6 = UH6_SymbolListCons(v1666, v1667);
    const v1669: *UH6 = UH6_SymbolListCons(v1665, v1668);
    const v1670: *UH6 = UH6_SymbolListCons(v1664, v1669);
    const v1671: bool = input_symbols_covered_153(v1663, v1670);
    if (v1671) {
        v1672 = US1_TriA();
        v1673 = UH3_RegexChar(v1672);
        v1674 = UH3_RegexStar(v1673);
        v1675 = normalize_14(v1674);
        v1676 = normalize_14(v1675);
        v1677 = regex_position_count_120(v1676);
        v1678 = UH8_StateBudgetSucc(v1677);
        v1679 = state_budget_pow2_104(v1678);
        v1680 = normalize_14(v1676);
        v1681 = US1_TriA();
        v1682 = US1_TriB();
        v1683 = US1_TriC();
        v1684 = UH6_SymbolListNil();
        v1685 = UH6_SymbolListCons(v1683, v1684);
        v1686 = UH6_SymbolListCons(v1682, v1685);
        v1687 = UH6_SymbolListCons(v1681, v1686);
        v1688 = UH10_RegexListNil();
        v1689 = UH10_RegexListCons(v1680, v1688);
        v1690 = UH10_RegexListNil();
        v1691 = UH10_RegexListCons(v1680, v1690);
        v1692 = dfa_closure_loop_bounded_121(v1687, v1679, v1689, v1691);
        switch (v1692.tag) {
            1 => {
                v1702 = v1692.c1_0;
                v1707 = US12_DfaEscapedClosure();
            },
            0 => {
                v1693 = v1692.c0_0;
                v1694 = US1_TriA();
                v1695 = US1_TriA();
                v1696 = US1_TriA();
                v1697 = UH1_InputEmpty();
                v1698 = UH1_InputCons(v1696, v1697);
                v1699 = UH1_InputCons(v1695, v1698);
                v1700 = UH1_InputCons(v1694, v1699);
                v1707 = dfa_run_in_closure_155(v1675, v1693, v1700);
            },
            else => unreachable,
        }
    } else {
        v1707 = US12_DfaEscapedClosure();
    }
    const v1708: US1 = US1_TriA();
    const v1709: *UH3 = UH3_RegexChar(v1708);
    const v1710: *UH3 = UH3_RegexStar(v1709);
    const v1711: US1 = US1_TriA();
    const v1712: US1 = US1_TriA();
    const v1713: US1 = US1_TriA();
    const v1714: *UH1 = UH1_InputEmpty();
    const v1715: *UH1 = UH1_InputCons(v1713, v1714);
    const v1716: *UH1 = UH1_InputCons(v1712, v1715);
    const v1717: *UH1 = UH1_InputCons(v1711, v1716);
    const v1718: bool = accepts_12(v1710, v1717);
    switch (v1707.tag) {
        0 => {
            v1721 = v1718;
        },
        1 => {
            v1719 = false == v1718;
            v1721 = v1719;
        },
        else => {
            v1721 = false;
        },
    }
    if (v1721) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA runner should preserve acceptance");
    }
    const v1722: US1 = US1_TriA();
    const v1723: US1 = US1_TriA();
    const v1724: US1 = US1_TriB();
    const v1725: *UH1 = UH1_InputEmpty();
    const v1726: *UH1 = UH1_InputCons(v1724, v1725);
    const v1727: *UH1 = UH1_InputCons(v1723, v1726);
    const v1728: *UH1 = UH1_InputCons(v1722, v1727);
    const v1729: US1 = US1_TriA();
    const v1730: US1 = US1_TriB();
    const v1731: US1 = US1_TriC();
    const v1732: *UH6 = UH6_SymbolListNil();
    const v1733: *UH6 = UH6_SymbolListCons(v1731, v1732);
    const v1734: *UH6 = UH6_SymbolListCons(v1730, v1733);
    const v1735: *UH6 = UH6_SymbolListCons(v1729, v1734);
    const v1736: bool = input_symbols_covered_153(v1728, v1735);
    if (v1736) {
        v1737 = US1_TriA();
        v1738 = UH3_RegexChar(v1737);
        v1739 = UH3_RegexStar(v1738);
        v1740 = normalize_14(v1739);
        v1741 = normalize_14(v1740);
        v1742 = regex_position_count_120(v1741);
        v1743 = UH8_StateBudgetSucc(v1742);
        v1744 = state_budget_pow2_104(v1743);
        v1745 = normalize_14(v1741);
        v1746 = US1_TriA();
        v1747 = US1_TriB();
        v1748 = US1_TriC();
        v1749 = UH6_SymbolListNil();
        v1750 = UH6_SymbolListCons(v1748, v1749);
        v1751 = UH6_SymbolListCons(v1747, v1750);
        v1752 = UH6_SymbolListCons(v1746, v1751);
        v1753 = UH10_RegexListNil();
        v1754 = UH10_RegexListCons(v1745, v1753);
        v1755 = UH10_RegexListNil();
        v1756 = UH10_RegexListCons(v1745, v1755);
        v1757 = dfa_closure_loop_bounded_121(v1752, v1744, v1754, v1756);
        switch (v1757.tag) {
            1 => {
                v1767 = v1757.c1_0;
                v1772 = US12_DfaEscapedClosure();
            },
            0 => {
                v1758 = v1757.c0_0;
                v1759 = US1_TriA();
                v1760 = US1_TriA();
                v1761 = US1_TriB();
                v1762 = UH1_InputEmpty();
                v1763 = UH1_InputCons(v1761, v1762);
                v1764 = UH1_InputCons(v1760, v1763);
                v1765 = UH1_InputCons(v1759, v1764);
                v1772 = dfa_run_in_closure_155(v1740, v1758, v1765);
            },
            else => unreachable,
        }
    } else {
        v1772 = US12_DfaEscapedClosure();
    }
    const v1773: US1 = US1_TriA();
    const v1774: *UH3 = UH3_RegexChar(v1773);
    const v1775: *UH3 = UH3_RegexStar(v1774);
    const v1776: US1 = US1_TriA();
    const v1777: US1 = US1_TriA();
    const v1778: US1 = US1_TriB();
    const v1779: *UH1 = UH1_InputEmpty();
    const v1780: *UH1 = UH1_InputCons(v1778, v1779);
    const v1781: *UH1 = UH1_InputCons(v1777, v1780);
    const v1782: *UH1 = UH1_InputCons(v1776, v1781);
    const v1783: bool = accepts_12(v1775, v1782);
    switch (v1772.tag) {
        0 => {
            v1786 = v1783;
        },
        1 => {
            v1784 = false == v1783;
            v1786 = v1784;
        },
        else => {
            v1786 = false;
        },
    }
    if (v1786) {
    } else {
        if (spiral_true) spiralFail("ternary star DFA runner should preserve rejection");
    }
    const v1787: US1 = US1_TriA();
    const v1788: US1 = US1_TriB();
    const v1789: US1 = US1_TriA();
    const v1790: US1 = US1_TriC();
    const v1791: *UH1 = UH1_InputEmpty();
    const v1792: *UH1 = UH1_InputCons(v1790, v1791);
    const v1793: *UH1 = UH1_InputCons(v1789, v1792);
    const v1794: *UH1 = UH1_InputCons(v1788, v1793);
    const v1795: *UH1 = UH1_InputCons(v1787, v1794);
    const v1796: US1 = US1_TriA();
    const v1797: US1 = US1_TriB();
    const v1798: US1 = US1_TriC();
    const v1799: *UH6 = UH6_SymbolListNil();
    const v1800: *UH6 = UH6_SymbolListCons(v1798, v1799);
    const v1801: *UH6 = UH6_SymbolListCons(v1797, v1800);
    const v1802: *UH6 = UH6_SymbolListCons(v1796, v1801);
    const v1803: bool = input_symbols_covered_153(v1795, v1802);
    if (v1803) {
        v1804 = US1_TriA();
        v1805 = UH3_RegexChar(v1804);
        v1806 = US1_TriB();
        v1807 = UH3_RegexChar(v1806);
        v1808 = UH3_RegexAlt(v1805, v1807);
        v1809 = UH3_RegexStar(v1808);
        v1810 = US1_TriC();
        v1811 = UH3_RegexChar(v1810);
        v1812 = UH3_RegexCat(v1809, v1811);
        v1813 = normalize_14(v1812);
        v1814 = normalize_14(v1813);
        v1815 = regex_position_count_120(v1814);
        v1816 = UH8_StateBudgetSucc(v1815);
        v1817 = state_budget_pow2_104(v1816);
        v1818 = normalize_14(v1814);
        v1819 = US1_TriA();
        v1820 = US1_TriB();
        v1821 = US1_TriC();
        v1822 = UH6_SymbolListNil();
        v1823 = UH6_SymbolListCons(v1821, v1822);
        v1824 = UH6_SymbolListCons(v1820, v1823);
        v1825 = UH6_SymbolListCons(v1819, v1824);
        v1826 = UH10_RegexListNil();
        v1827 = UH10_RegexListCons(v1818, v1826);
        v1828 = UH10_RegexListNil();
        v1829 = UH10_RegexListCons(v1818, v1828);
        v1830 = dfa_closure_loop_bounded_121(v1825, v1817, v1827, v1829);
        switch (v1830.tag) {
            1 => {
                v1842 = v1830.c1_0;
                v1847 = US12_DfaEscapedClosure();
            },
            0 => {
                v1831 = v1830.c0_0;
                v1832 = US1_TriA();
                v1833 = US1_TriB();
                v1834 = US1_TriA();
                v1835 = US1_TriC();
                v1836 = UH1_InputEmpty();
                v1837 = UH1_InputCons(v1835, v1836);
                v1838 = UH1_InputCons(v1834, v1837);
                v1839 = UH1_InputCons(v1833, v1838);
                v1840 = UH1_InputCons(v1832, v1839);
                v1847 = dfa_run_in_closure_155(v1813, v1831, v1840);
            },
            else => unreachable,
        }
    } else {
        v1847 = US12_DfaEscapedClosure();
    }
    const v1848: US1 = US1_TriA();
    const v1849: *UH3 = UH3_RegexChar(v1848);
    const v1850: US1 = US1_TriB();
    const v1851: *UH3 = UH3_RegexChar(v1850);
    const v1852: *UH3 = UH3_RegexAlt(v1849, v1851);
    const v1853: *UH3 = UH3_RegexStar(v1852);
    const v1854: US1 = US1_TriC();
    const v1855: *UH3 = UH3_RegexChar(v1854);
    const v1856: *UH3 = UH3_RegexCat(v1853, v1855);
    const v1857: US1 = US1_TriA();
    const v1858: US1 = US1_TriB();
    const v1859: US1 = US1_TriA();
    const v1860: US1 = US1_TriC();
    const v1861: *UH1 = UH1_InputEmpty();
    const v1862: *UH1 = UH1_InputCons(v1860, v1861);
    const v1863: *UH1 = UH1_InputCons(v1859, v1862);
    const v1864: *UH1 = UH1_InputCons(v1858, v1863);
    const v1865: *UH1 = UH1_InputCons(v1857, v1864);
    const v1866: bool = accepts_12(v1856, v1865);
    switch (v1847.tag) {
        0 => {
            v1869 = v1866;
        },
        1 => {
            v1867 = false == v1866;
            v1869 = v1867;
        },
        else => {
            v1869 = false;
        },
    }
    if (v1869) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA runner should preserve acceptance");
    }
    const v1870: US1 = US1_TriA();
    const v1871: US1 = US1_TriB();
    const v1872: US1 = US1_TriA();
    const v1873: US1 = US1_TriB();
    const v1874: *UH1 = UH1_InputEmpty();
    const v1875: *UH1 = UH1_InputCons(v1873, v1874);
    const v1876: *UH1 = UH1_InputCons(v1872, v1875);
    const v1877: *UH1 = UH1_InputCons(v1871, v1876);
    const v1878: *UH1 = UH1_InputCons(v1870, v1877);
    const v1879: US1 = US1_TriA();
    const v1880: US1 = US1_TriB();
    const v1881: US1 = US1_TriC();
    const v1882: *UH6 = UH6_SymbolListNil();
    const v1883: *UH6 = UH6_SymbolListCons(v1881, v1882);
    const v1884: *UH6 = UH6_SymbolListCons(v1880, v1883);
    const v1885: *UH6 = UH6_SymbolListCons(v1879, v1884);
    const v1886: bool = input_symbols_covered_153(v1878, v1885);
    if (v1886) {
        v1887 = US1_TriA();
        v1888 = UH3_RegexChar(v1887);
        v1889 = US1_TriB();
        v1890 = UH3_RegexChar(v1889);
        v1891 = UH3_RegexAlt(v1888, v1890);
        v1892 = UH3_RegexStar(v1891);
        v1893 = US1_TriC();
        v1894 = UH3_RegexChar(v1893);
        v1895 = UH3_RegexCat(v1892, v1894);
        v1896 = normalize_14(v1895);
        v1897 = normalize_14(v1896);
        v1898 = regex_position_count_120(v1897);
        v1899 = UH8_StateBudgetSucc(v1898);
        v1900 = state_budget_pow2_104(v1899);
        v1901 = normalize_14(v1897);
        v1902 = US1_TriA();
        v1903 = US1_TriB();
        v1904 = US1_TriC();
        v1905 = UH6_SymbolListNil();
        v1906 = UH6_SymbolListCons(v1904, v1905);
        v1907 = UH6_SymbolListCons(v1903, v1906);
        v1908 = UH6_SymbolListCons(v1902, v1907);
        v1909 = UH10_RegexListNil();
        v1910 = UH10_RegexListCons(v1901, v1909);
        v1911 = UH10_RegexListNil();
        v1912 = UH10_RegexListCons(v1901, v1911);
        v1913 = dfa_closure_loop_bounded_121(v1908, v1900, v1910, v1912);
        switch (v1913.tag) {
            1 => {
                v1925 = v1913.c1_0;
                v1930 = US12_DfaEscapedClosure();
            },
            0 => {
                v1914 = v1913.c0_0;
                v1915 = US1_TriA();
                v1916 = US1_TriB();
                v1917 = US1_TriA();
                v1918 = US1_TriB();
                v1919 = UH1_InputEmpty();
                v1920 = UH1_InputCons(v1918, v1919);
                v1921 = UH1_InputCons(v1917, v1920);
                v1922 = UH1_InputCons(v1916, v1921);
                v1923 = UH1_InputCons(v1915, v1922);
                v1930 = dfa_run_in_closure_155(v1896, v1914, v1923);
            },
            else => unreachable,
        }
    } else {
        v1930 = US12_DfaEscapedClosure();
    }
    const v1931: US1 = US1_TriA();
    const v1932: *UH3 = UH3_RegexChar(v1931);
    const v1933: US1 = US1_TriB();
    const v1934: *UH3 = UH3_RegexChar(v1933);
    const v1935: *UH3 = UH3_RegexAlt(v1932, v1934);
    const v1936: *UH3 = UH3_RegexStar(v1935);
    const v1937: US1 = US1_TriC();
    const v1938: *UH3 = UH3_RegexChar(v1937);
    const v1939: *UH3 = UH3_RegexCat(v1936, v1938);
    const v1940: US1 = US1_TriA();
    const v1941: US1 = US1_TriB();
    const v1942: US1 = US1_TriA();
    const v1943: US1 = US1_TriB();
    const v1944: *UH1 = UH1_InputEmpty();
    const v1945: *UH1 = UH1_InputCons(v1943, v1944);
    const v1946: *UH1 = UH1_InputCons(v1942, v1945);
    const v1947: *UH1 = UH1_InputCons(v1941, v1946);
    const v1948: *UH1 = UH1_InputCons(v1940, v1947);
    const v1949: bool = accepts_12(v1939, v1948);
    switch (v1930.tag) {
        0 => {
            v1952 = v1949;
        },
        1 => {
            v1950 = false == v1949;
            v1952 = v1950;
        },
        else => {
            v1952 = false;
        },
    }
    if (v1952) {
    } else {
        if (spiral_true) spiralFail("ternary suffix DFA runner should preserve rejection");
    }
    const v1953: US0 = US0_BitOne();
    const v1954: US0 = US0_BitOne();
    const v1955: US0 = US0_BitZero();
    const v1956: *UH0 = UH0_InputEmpty();
    const v1957: *UH0 = UH0_InputCons(v1955, v1956);
    const v1958: *UH0 = UH0_InputCons(v1954, v1957);
    const v1959: *UH0 = UH0_InputCons(v1953, v1958);
    const v1960: US0 = US0_BitZero();
    const v1961: US0 = US0_BitOne();
    const v1962: *UH4 = UH4_SymbolListNil();
    const v1963: *UH4 = UH4_SymbolListCons(v1961, v1962);
    const v1964: *UH4 = UH4_SymbolListCons(v1960, v1963);
    const v1965: bool = input_symbols_covered_52(v1959, v1964);
    if (v1965) {
        v1966 = US0_BitZero();
        v1967 = UH2_RegexChar(v1966);
        v1968 = US0_BitOne();
        v1969 = UH2_RegexChar(v1968);
        v1970 = UH2_RegexAlt(v1967, v1969);
        v1971 = UH2_RegexStar(v1970);
        v1972 = US0_BitZero();
        v1973 = UH2_RegexChar(v1972);
        v1974 = UH2_RegexCat(v1971, v1973);
        v1975 = normalize_4(v1974);
        v1976 = normalize_4(v1975);
        v1977 = regex_position_count_102(v1976);
        v1978 = UH8_StateBudgetSucc(v1977);
        v1979 = state_budget_pow2_104(v1978);
        v1980 = normalize_4(v1976);
        v1981 = US0_BitZero();
        v1982 = US0_BitOne();
        v1983 = UH4_SymbolListNil();
        v1984 = UH4_SymbolListCons(v1982, v1983);
        v1985 = UH4_SymbolListCons(v1981, v1984);
        v1986 = UH9_RegexListNil();
        v1987 = UH9_RegexListCons(v1980, v1986);
        v1988 = UH9_RegexListNil();
        v1989 = UH9_RegexListCons(v1980, v1988);
        v1990 = dfa_closure_loop_bounded_54(v1985, v1979, v1987, v1989);
        switch (v1990.tag) {
            1 => {
                v2022 = v1990.c1_0;
                v2027 = US12_DfaEscapedClosure();
            },
            0 => {
                v1991 = v1990.c0_0;
                v1992 = US0_BitZero();
                v1993 = US0_BitOne();
                v1994 = UH4_SymbolListNil();
                v1995 = UH4_SymbolListCons(v1993, v1994);
                v1996 = UH4_SymbolListCons(v1992, v1995);
                v1997 = UH9_RegexListNil();
                v1998 = dfa_minimize_states_loop_142(v1991, v1996, v1997);
                v1999 = US0_BitZero();
                v2000 = US0_BitOne();
                v2001 = UH4_SymbolListNil();
                v2002 = UH4_SymbolListCons(v2000, v2001);
                v2003 = UH4_SymbolListCons(v1999, v2002);
                v2004 = dfa_find_bisimilar_representative_143(v1975, v1998, v2003);
                switch (v2004.tag) {
                    0 => {
                        v2005 = v2004.c0_0;
                        v2006 = US0_BitZero();
                        v2007 = US0_BitOne();
                        v2008 = UH4_SymbolListNil();
                        v2009 = UH4_SymbolListCons(v2007, v2008);
                        v2010 = UH4_SymbolListCons(v2006, v2009);
                        v2011 = US0_BitOne();
                        v2012 = US0_BitOne();
                        v2013 = US0_BitZero();
                        v2014 = UH0_InputEmpty();
                        v2015 = UH0_InputCons(v2013, v2014);
                        v2016 = UH0_InputCons(v2012, v2015);
                        v2017 = UH0_InputCons(v2011, v2016);
                        v2027 = dfa_run_minimized_in_representatives_156(v2005, v1998, v2010, v2017);
                    },
                    1 => {
                        v2027 = US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    } else {
        v2027 = US12_DfaEscapedClosure();
    }
    const v2028: US0 = US0_BitZero();
    const v2029: *UH2 = UH2_RegexChar(v2028);
    const v2030: US0 = US0_BitOne();
    const v2031: *UH2 = UH2_RegexChar(v2030);
    const v2032: *UH2 = UH2_RegexAlt(v2029, v2031);
    const v2033: *UH2 = UH2_RegexStar(v2032);
    const v2034: US0 = US0_BitZero();
    const v2035: *UH2 = UH2_RegexChar(v2034);
    const v2036: *UH2 = UH2_RegexCat(v2033, v2035);
    const v2037: US0 = US0_BitOne();
    const v2038: US0 = US0_BitOne();
    const v2039: US0 = US0_BitZero();
    const v2040: *UH0 = UH0_InputEmpty();
    const v2041: *UH0 = UH0_InputCons(v2039, v2040);
    const v2042: *UH0 = UH0_InputCons(v2038, v2041);
    const v2043: *UH0 = UH0_InputCons(v2037, v2042);
    const v2044: bool = accepts_2(v2036, v2043);
    switch (v2027.tag) {
        0 => {
            v2047 = v2044;
        },
        1 => {
            v2045 = false == v2044;
            v2047 = v2045;
        },
        else => {
            v2047 = false;
        },
    }
    if (v2047) {
    } else {
        if (spiral_true) spiralFail("bit minimized runner should preserve acceptance");
    }
    const v2048: US1 = US1_TriA();
    const v2049: US1 = US1_TriA();
    const v2050: US1 = US1_TriB();
    const v2051: *UH1 = UH1_InputEmpty();
    const v2052: *UH1 = UH1_InputCons(v2050, v2051);
    const v2053: *UH1 = UH1_InputCons(v2049, v2052);
    const v2054: *UH1 = UH1_InputCons(v2048, v2053);
    const v2055: US1 = US1_TriA();
    const v2056: US1 = US1_TriB();
    const v2057: US1 = US1_TriC();
    const v2058: *UH6 = UH6_SymbolListNil();
    const v2059: *UH6 = UH6_SymbolListCons(v2057, v2058);
    const v2060: *UH6 = UH6_SymbolListCons(v2056, v2059);
    const v2061: *UH6 = UH6_SymbolListCons(v2055, v2060);
    const v2062: bool = input_symbols_covered_153(v2054, v2061);
    if (v2062) {
        v2063 = US1_TriA();
        v2064 = UH3_RegexChar(v2063);
        v2065 = UH3_RegexStar(v2064);
        v2066 = normalize_14(v2065);
        v2067 = normalize_14(v2066);
        v2068 = regex_position_count_120(v2067);
        v2069 = UH8_StateBudgetSucc(v2068);
        v2070 = state_budget_pow2_104(v2069);
        v2071 = normalize_14(v2067);
        v2072 = US1_TriA();
        v2073 = US1_TriB();
        v2074 = US1_TriC();
        v2075 = UH6_SymbolListNil();
        v2076 = UH6_SymbolListCons(v2074, v2075);
        v2077 = UH6_SymbolListCons(v2073, v2076);
        v2078 = UH6_SymbolListCons(v2072, v2077);
        v2079 = UH10_RegexListNil();
        v2080 = UH10_RegexListCons(v2071, v2079);
        v2081 = UH10_RegexListNil();
        v2082 = UH10_RegexListCons(v2071, v2081);
        v2083 = dfa_closure_loop_bounded_121(v2078, v2070, v2080, v2082);
        switch (v2083.tag) {
            1 => {
                v2121 = v2083.c1_0;
                v2126 = US12_DfaEscapedClosure();
            },
            0 => {
                v2084 = v2083.c0_0;
                v2085 = US1_TriA();
                v2086 = US1_TriB();
                v2087 = US1_TriC();
                v2088 = UH6_SymbolListNil();
                v2089 = UH6_SymbolListCons(v2087, v2088);
                v2090 = UH6_SymbolListCons(v2086, v2089);
                v2091 = UH6_SymbolListCons(v2085, v2090);
                v2092 = UH10_RegexListNil();
                v2093 = dfa_minimize_states_loop_147(v2084, v2091, v2092);
                v2094 = US1_TriA();
                v2095 = US1_TriB();
                v2096 = US1_TriC();
                v2097 = UH6_SymbolListNil();
                v2098 = UH6_SymbolListCons(v2096, v2097);
                v2099 = UH6_SymbolListCons(v2095, v2098);
                v2100 = UH6_SymbolListCons(v2094, v2099);
                v2101 = dfa_find_bisimilar_representative_148(v2066, v2093, v2100);
                switch (v2101.tag) {
                    0 => {
                        v2102 = v2101.c0_0;
                        v2103 = US1_TriA();
                        v2104 = US1_TriB();
                        v2105 = US1_TriC();
                        v2106 = UH6_SymbolListNil();
                        v2107 = UH6_SymbolListCons(v2105, v2106);
                        v2108 = UH6_SymbolListCons(v2104, v2107);
                        v2109 = UH6_SymbolListCons(v2103, v2108);
                        v2110 = US1_TriA();
                        v2111 = US1_TriA();
                        v2112 = US1_TriB();
                        v2113 = UH1_InputEmpty();
                        v2114 = UH1_InputCons(v2112, v2113);
                        v2115 = UH1_InputCons(v2111, v2114);
                        v2116 = UH1_InputCons(v2110, v2115);
                        v2126 = dfa_run_minimized_in_representatives_157(v2102, v2093, v2109, v2116);
                    },
                    1 => {
                        v2126 = US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    } else {
        v2126 = US12_DfaEscapedClosure();
    }
    const v2127: US1 = US1_TriA();
    const v2128: *UH3 = UH3_RegexChar(v2127);
    const v2129: *UH3 = UH3_RegexStar(v2128);
    const v2130: US1 = US1_TriA();
    const v2131: US1 = US1_TriA();
    const v2132: US1 = US1_TriB();
    const v2133: *UH1 = UH1_InputEmpty();
    const v2134: *UH1 = UH1_InputCons(v2132, v2133);
    const v2135: *UH1 = UH1_InputCons(v2131, v2134);
    const v2136: *UH1 = UH1_InputCons(v2130, v2135);
    const v2137: bool = accepts_12(v2129, v2136);
    switch (v2126.tag) {
        0 => {
            v2140 = v2137;
        },
        1 => {
            v2138 = false == v2137;
            v2140 = v2138;
        },
        else => {
            v2140 = false;
        },
    }
    if (v2140) {
    } else {
        if (spiral_true) spiralFail("ternary minimized runner should preserve rejection");
    }
    const v2141: US1 = US1_TriA();
    const v2142: US1 = US1_TriA();
    const v2143: US1 = US1_TriA();
    const v2144: *UH1 = UH1_InputEmpty();
    const v2145: *UH1 = UH1_InputCons(v2143, v2144);
    const v2146: *UH1 = UH1_InputCons(v2142, v2145);
    const v2147: *UH1 = UH1_InputCons(v2141, v2146);
    const v2148: US1 = US1_TriA();
    const v2149: US1 = US1_TriB();
    const v2150: US1 = US1_TriC();
    const v2151: *UH6 = UH6_SymbolListNil();
    const v2152: *UH6 = UH6_SymbolListCons(v2150, v2151);
    const v2153: *UH6 = UH6_SymbolListCons(v2149, v2152);
    const v2154: *UH6 = UH6_SymbolListCons(v2148, v2153);
    const v2155: bool = input_symbols_covered_153(v2147, v2154);
    if (v2155) {
        v2156 = US1_TriA();
        v2157 = UH3_RegexChar(v2156);
        v2158 = US1_TriA();
        v2159 = UH3_RegexChar(v2158);
        v2160 = UH3_RegexStar(v2159);
        v2161 = UH3_RegexCat(v2157, v2160);
        v2162 = US1_TriB();
        v2163 = UH3_RegexChar(v2162);
        v2164 = US1_TriA();
        v2165 = UH3_RegexChar(v2164);
        v2166 = US1_TriA();
        v2167 = UH3_RegexChar(v2166);
        v2168 = UH3_RegexCat(v2165, v2167);
        v2169 = UH3_RegexStar(v2168);
        v2170 = US1_TriA();
        v2171 = UH3_RegexChar(v2170);
        v2172 = UH3_RegexCat(v2171, v2169);
        v2173 = UH3_RegexAlt(v2169, v2172);
        v2174 = UH3_RegexCat(v2163, v2173);
        v2175 = UH3_RegexAlt(v2161, v2174);
        v2176 = normalize_14(v2175);
        v2177 = normalize_14(v2176);
        v2178 = regex_position_count_120(v2177);
        v2179 = UH8_StateBudgetSucc(v2178);
        v2180 = state_budget_pow2_104(v2179);
        v2181 = normalize_14(v2177);
        v2182 = US1_TriA();
        v2183 = US1_TriB();
        v2184 = US1_TriC();
        v2185 = UH6_SymbolListNil();
        v2186 = UH6_SymbolListCons(v2184, v2185);
        v2187 = UH6_SymbolListCons(v2183, v2186);
        v2188 = UH6_SymbolListCons(v2182, v2187);
        v2189 = UH10_RegexListNil();
        v2190 = UH10_RegexListCons(v2181, v2189);
        v2191 = UH10_RegexListNil();
        v2192 = UH10_RegexListCons(v2181, v2191);
        v2193 = dfa_closure_loop_bounded_121(v2188, v2180, v2190, v2192);
        switch (v2193.tag) {
            1 => {
                v2231 = v2193.c1_0;
                v2236 = US12_DfaEscapedClosure();
            },
            0 => {
                v2194 = v2193.c0_0;
                v2195 = US1_TriA();
                v2196 = US1_TriB();
                v2197 = US1_TriC();
                v2198 = UH6_SymbolListNil();
                v2199 = UH6_SymbolListCons(v2197, v2198);
                v2200 = UH6_SymbolListCons(v2196, v2199);
                v2201 = UH6_SymbolListCons(v2195, v2200);
                v2202 = UH10_RegexListNil();
                v2203 = dfa_minimize_states_loop_147(v2194, v2201, v2202);
                v2204 = US1_TriA();
                v2205 = US1_TriB();
                v2206 = US1_TriC();
                v2207 = UH6_SymbolListNil();
                v2208 = UH6_SymbolListCons(v2206, v2207);
                v2209 = UH6_SymbolListCons(v2205, v2208);
                v2210 = UH6_SymbolListCons(v2204, v2209);
                v2211 = dfa_find_bisimilar_representative_148(v2176, v2203, v2210);
                switch (v2211.tag) {
                    0 => {
                        v2212 = v2211.c0_0;
                        v2213 = US1_TriA();
                        v2214 = US1_TriB();
                        v2215 = US1_TriC();
                        v2216 = UH6_SymbolListNil();
                        v2217 = UH6_SymbolListCons(v2215, v2216);
                        v2218 = UH6_SymbolListCons(v2214, v2217);
                        v2219 = UH6_SymbolListCons(v2213, v2218);
                        v2220 = US1_TriA();
                        v2221 = US1_TriA();
                        v2222 = US1_TriA();
                        v2223 = UH1_InputEmpty();
                        v2224 = UH1_InputCons(v2222, v2223);
                        v2225 = UH1_InputCons(v2221, v2224);
                        v2226 = UH1_InputCons(v2220, v2225);
                        v2236 = dfa_run_minimized_in_representatives_157(v2212, v2203, v2219, v2226);
                    },
                    1 => {
                        v2236 = US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    } else {
        v2236 = US12_DfaEscapedClosure();
    }
    const v2237: US1 = US1_TriA();
    const v2238: *UH3 = UH3_RegexChar(v2237);
    const v2239: US1 = US1_TriA();
    const v2240: *UH3 = UH3_RegexChar(v2239);
    const v2241: *UH3 = UH3_RegexStar(v2240);
    const v2242: *UH3 = UH3_RegexCat(v2238, v2241);
    const v2243: US1 = US1_TriB();
    const v2244: *UH3 = UH3_RegexChar(v2243);
    const v2245: US1 = US1_TriA();
    const v2246: *UH3 = UH3_RegexChar(v2245);
    const v2247: US1 = US1_TriA();
    const v2248: *UH3 = UH3_RegexChar(v2247);
    const v2249: *UH3 = UH3_RegexCat(v2246, v2248);
    const v2250: *UH3 = UH3_RegexStar(v2249);
    const v2251: US1 = US1_TriA();
    const v2252: *UH3 = UH3_RegexChar(v2251);
    const v2253: *UH3 = UH3_RegexCat(v2252, v2250);
    const v2254: *UH3 = UH3_RegexAlt(v2250, v2253);
    const v2255: *UH3 = UH3_RegexCat(v2244, v2254);
    const v2256: *UH3 = UH3_RegexAlt(v2242, v2255);
    const v2257: US1 = US1_TriA();
    const v2258: US1 = US1_TriA();
    const v2259: US1 = US1_TriA();
    const v2260: *UH1 = UH1_InputEmpty();
    const v2261: *UH1 = UH1_InputCons(v2259, v2260);
    const v2262: *UH1 = UH1_InputCons(v2258, v2261);
    const v2263: *UH1 = UH1_InputCons(v2257, v2262);
    const v2264: bool = accepts_12(v2256, v2263);
    switch (v2236.tag) {
        0 => {
            v2267 = v2264;
        },
        1 => {
            v2265 = false == v2264;
            v2267 = v2265;
        },
        else => {
            v2267 = false;
        },
    }
    if (v2267) {
    } else {
        if (spiral_true) spiralFail("cyclic quotient should preserve acceptance");
    }
    const v2268: US1 = US1_TriA();
    const v2269: US1 = US1_TriA();
    const v2270: US1 = US1_TriB();
    const v2271: *UH1 = UH1_InputEmpty();
    const v2272: *UH1 = UH1_InputCons(v2270, v2271);
    const v2273: *UH1 = UH1_InputCons(v2269, v2272);
    const v2274: *UH1 = UH1_InputCons(v2268, v2273);
    const v2275: US1 = US1_TriA();
    const v2276: US1 = US1_TriB();
    const v2277: US1 = US1_TriC();
    const v2278: *UH6 = UH6_SymbolListNil();
    const v2279: *UH6 = UH6_SymbolListCons(v2277, v2278);
    const v2280: *UH6 = UH6_SymbolListCons(v2276, v2279);
    const v2281: *UH6 = UH6_SymbolListCons(v2275, v2280);
    const v2282: bool = input_symbols_covered_153(v2274, v2281);
    if (v2282) {
        v2283 = US1_TriA();
        v2284 = UH3_RegexChar(v2283);
        v2285 = US1_TriA();
        v2286 = UH3_RegexChar(v2285);
        v2287 = UH3_RegexStar(v2286);
        v2288 = UH3_RegexCat(v2284, v2287);
        v2289 = US1_TriB();
        v2290 = UH3_RegexChar(v2289);
        v2291 = US1_TriA();
        v2292 = UH3_RegexChar(v2291);
        v2293 = US1_TriA();
        v2294 = UH3_RegexChar(v2293);
        v2295 = UH3_RegexCat(v2292, v2294);
        v2296 = UH3_RegexStar(v2295);
        v2297 = US1_TriA();
        v2298 = UH3_RegexChar(v2297);
        v2299 = UH3_RegexCat(v2298, v2296);
        v2300 = UH3_RegexAlt(v2296, v2299);
        v2301 = UH3_RegexCat(v2290, v2300);
        v2302 = UH3_RegexAlt(v2288, v2301);
        v2303 = normalize_14(v2302);
        v2304 = normalize_14(v2303);
        v2305 = regex_position_count_120(v2304);
        v2306 = UH8_StateBudgetSucc(v2305);
        v2307 = state_budget_pow2_104(v2306);
        v2308 = normalize_14(v2304);
        v2309 = US1_TriA();
        v2310 = US1_TriB();
        v2311 = US1_TriC();
        v2312 = UH6_SymbolListNil();
        v2313 = UH6_SymbolListCons(v2311, v2312);
        v2314 = UH6_SymbolListCons(v2310, v2313);
        v2315 = UH6_SymbolListCons(v2309, v2314);
        v2316 = UH10_RegexListNil();
        v2317 = UH10_RegexListCons(v2308, v2316);
        v2318 = UH10_RegexListNil();
        v2319 = UH10_RegexListCons(v2308, v2318);
        v2320 = dfa_closure_loop_bounded_121(v2315, v2307, v2317, v2319);
        switch (v2320.tag) {
            1 => {
                v2358 = v2320.c1_0;
                v2363 = US12_DfaEscapedClosure();
            },
            0 => {
                v2321 = v2320.c0_0;
                v2322 = US1_TriA();
                v2323 = US1_TriB();
                v2324 = US1_TriC();
                v2325 = UH6_SymbolListNil();
                v2326 = UH6_SymbolListCons(v2324, v2325);
                v2327 = UH6_SymbolListCons(v2323, v2326);
                v2328 = UH6_SymbolListCons(v2322, v2327);
                v2329 = UH10_RegexListNil();
                v2330 = dfa_minimize_states_loop_147(v2321, v2328, v2329);
                v2331 = US1_TriA();
                v2332 = US1_TriB();
                v2333 = US1_TriC();
                v2334 = UH6_SymbolListNil();
                v2335 = UH6_SymbolListCons(v2333, v2334);
                v2336 = UH6_SymbolListCons(v2332, v2335);
                v2337 = UH6_SymbolListCons(v2331, v2336);
                v2338 = dfa_find_bisimilar_representative_148(v2303, v2330, v2337);
                switch (v2338.tag) {
                    0 => {
                        v2339 = v2338.c0_0;
                        v2340 = US1_TriA();
                        v2341 = US1_TriB();
                        v2342 = US1_TriC();
                        v2343 = UH6_SymbolListNil();
                        v2344 = UH6_SymbolListCons(v2342, v2343);
                        v2345 = UH6_SymbolListCons(v2341, v2344);
                        v2346 = UH6_SymbolListCons(v2340, v2345);
                        v2347 = US1_TriA();
                        v2348 = US1_TriA();
                        v2349 = US1_TriB();
                        v2350 = UH1_InputEmpty();
                        v2351 = UH1_InputCons(v2349, v2350);
                        v2352 = UH1_InputCons(v2348, v2351);
                        v2353 = UH1_InputCons(v2347, v2352);
                        v2363 = dfa_run_minimized_in_representatives_157(v2339, v2330, v2346, v2353);
                    },
                    1 => {
                        v2363 = US12_DfaEscapedClosure();
                    },
                    else => unreachable,
                }
            },
            else => unreachable,
        }
    } else {
        v2363 = US12_DfaEscapedClosure();
    }
    const v2364: US1 = US1_TriA();
    const v2365: *UH3 = UH3_RegexChar(v2364);
    const v2366: US1 = US1_TriA();
    const v2367: *UH3 = UH3_RegexChar(v2366);
    const v2368: *UH3 = UH3_RegexStar(v2367);
    const v2369: *UH3 = UH3_RegexCat(v2365, v2368);
    const v2370: US1 = US1_TriB();
    const v2371: *UH3 = UH3_RegexChar(v2370);
    const v2372: US1 = US1_TriA();
    const v2373: *UH3 = UH3_RegexChar(v2372);
    const v2374: US1 = US1_TriA();
    const v2375: *UH3 = UH3_RegexChar(v2374);
    const v2376: *UH3 = UH3_RegexCat(v2373, v2375);
    const v2377: *UH3 = UH3_RegexStar(v2376);
    const v2378: US1 = US1_TriA();
    const v2379: *UH3 = UH3_RegexChar(v2378);
    const v2380: *UH3 = UH3_RegexCat(v2379, v2377);
    const v2381: *UH3 = UH3_RegexAlt(v2377, v2380);
    const v2382: *UH3 = UH3_RegexCat(v2371, v2381);
    const v2383: *UH3 = UH3_RegexAlt(v2369, v2382);
    const v2384: US1 = US1_TriA();
    const v2385: US1 = US1_TriA();
    const v2386: US1 = US1_TriB();
    const v2387: *UH1 = UH1_InputEmpty();
    const v2388: *UH1 = UH1_InputCons(v2386, v2387);
    const v2389: *UH1 = UH1_InputCons(v2385, v2388);
    const v2390: *UH1 = UH1_InputCons(v2384, v2389);
    const v2391: bool = accepts_12(v2383, v2390);
    switch (v2363.tag) {
        0 => {
            v2394 = v2391;
        },
        1 => {
            v2392 = false == v2391;
            v2394 = v2392;
        },
        else => {
            v2394 = false;
        },
    }
    if (v2394) {
    } else {
        if (spiral_true) spiralFail("cyclic quotient should preserve rejection");
    }
    const v2395: US0 = US0_BitOne();
    const v2396: *UH2 = UH2_RegexChar(v2395);
    const v2397: US0 = US0_BitZero();
    const v2398: *UH2 = UH2_RegexChar(v2397);
    const v2399: US0 = US0_BitOne();
    const v2400: *UH2 = UH2_RegexChar(v2399);
    const v2401: *UH2 = UH2_RegexAlt(v2398, v2400);
    const v2402: *UH2 = UH2_RegexAlt(v2396, v2401);
    const v2403: *UH2 = normalize_4(v2402);
    const v2404: US0 = US0_BitZero();
    const v2405: *UH2 = UH2_RegexChar(v2404);
    const v2406: US0 = US0_BitOne();
    const v2407: *UH2 = UH2_RegexChar(v2406);
    const v2408: *UH2 = UH2_RegexAlt(v2405, v2407);
    const v2409: *UH2 = normalize_4(v2408);
    const v2410: bool = regex_equal_9(v2403, v2409);
    if (v2410) {
    } else {
        if (spiral_true) spiralFail("alternative normalization should deduplicate and order");
    }
    const v2411: US0 = US0_BitOne();
    const v2412: *UH2 = UH2_RegexChar(v2411);
    const v2413: US0 = US0_BitZero();
    const v2414: *UH2 = UH2_RegexChar(v2413);
    const v2415: *UH2 = UH2_RegexAlt(v2412, v2414);
    const v2416: *UH2 = normalize_4(v2415);
    const v2417: US0 = US0_BitZero();
    const v2418: *UH2 = UH2_RegexChar(v2417);
    const v2419: US0 = US0_BitOne();
    const v2420: *UH2 = UH2_RegexChar(v2419);
    const v2421: *UH2 = UH2_RegexAlt(v2418, v2420);
    const v2422: *UH2 = normalize_4(v2421);
    const v2423: bool = regex_equal_9(v2416, v2422);
    if (v2423) {
    } else {
        if (spiral_true) spiralFail("alternative normalization should commute canonically");
    }
    const v2424: US0 = US0_BitZero();
    const v2425: *UH2 = UH2_RegexChar(v2424);
    const v2426: *UH2 = UH2_RegexEpsilon();
    const v2427: *UH2 = UH2_RegexCat(v2425, v2426);
    const v2428: US0 = US0_BitOne();
    const v2429: *UH2 = UH2_RegexChar(v2428);
    const v2430: *UH2 = UH2_RegexCat(v2427, v2429);
    const v2431: *UH2 = normalize_4(v2430);
    const v2432: US0 = US0_BitZero();
    const v2433: *UH2 = UH2_RegexChar(v2432);
    const v2434: *UH2 = UH2_RegexEpsilon();
    const v2435: US0 = US0_BitOne();
    const v2436: *UH2 = UH2_RegexChar(v2435);
    const v2437: *UH2 = UH2_RegexCat(v2434, v2436);
    const v2438: *UH2 = UH2_RegexCat(v2433, v2437);
    const v2439: *UH2 = normalize_4(v2438);
    const v2440: bool = regex_equal_9(v2431, v2439);
    if (v2440) {
    } else {
        if (spiral_true) spiralFail("concatenation normalization should reassociate canonically");
    }
    const v2441: US0 = US0_BitZero();
    const v2442: *UH2 = UH2_RegexChar(v2441);
    const v2443: *UH2 = UH2_RegexStar(v2442);
    const v2444: *UH2 = UH2_RegexStar(v2443);
    const v2445: *UH2 = normalize_4(v2444);
    const v2446: US0 = US0_BitZero();
    const v2447: *UH2 = UH2_RegexChar(v2446);
    const v2448: *UH2 = UH2_RegexStar(v2447);
    const v2449: *UH2 = normalize_4(v2448);
    const v2450: bool = regex_equal_9(v2445, v2449);
    if (v2450) {
    } else {
        if (spiral_true) spiralFail("star normalization should collapse nested stars");
    }
    const v2451: US0 = US0_BitZero();
    const v2452: *UH2 = UH2_RegexChar(v2451);
    const v2453: *UH2 = UH2_RegexStar(v2452);
    const v2454: *UH2 = UH2_RegexCat(v2453, v2453);
    const v2455: *UH2 = normalize_4(v2454);
    const v2456: US0 = US0_BitZero();
    const v2457: *UH2 = UH2_RegexChar(v2456);
    const v2458: *UH2 = UH2_RegexStar(v2457);
    const v2459: *UH2 = normalize_4(v2458);
    const v2460: bool = regex_equal_9(v2455, v2459);
    if (v2460) {
    } else {
        if (spiral_true) spiralFail("adjacent identical stars should collapse under concatenation");
    }
    const v2461: US0 = US0_BitZero();
    const v2462: *UH2 = UH2_RegexChar(v2461);
    const v2463: *UH2 = UH2_RegexStar(v2462);
    const v2464: *UH2 = UH2_RegexStar(v2463);
    const v2465: *UH2 = normalize_4(v2464);
    const v2466: US0 = US0_BitZero();
    const v2467: *UH2 = derivative_11(v2465, v2466);
    const v2468: *UH2 = normalize_4(v2467);
    const v2469: US0 = US0_BitZero();
    const v2470: *UH2 = UH2_RegexChar(v2469);
    const v2471: *UH2 = UH2_RegexStar(v2470);
    const v2472: *UH2 = UH2_RegexStar(v2471);
    const v2473: US0 = US0_BitZero();
    const v2474: *UH2 = derivative_11(v2472, v2473);
    const v2475: *UH2 = normalize_4(v2474);
    const v2476: bool = regex_equal_9(v2468, v2475);
    if (v2476) {
    } else {
        if (spiral_true) spiralFail("nested-star canonical derivative should commute with normalization");
    }
    const v2477: US0 = US0_BitOne();
    const v2478: *UH2 = UH2_RegexChar(v2477);
    const v2479: US0 = US0_BitZero();
    const v2480: *UH2 = UH2_RegexChar(v2479);
    const v2481: US0 = US0_BitOne();
    const v2482: *UH2 = UH2_RegexChar(v2481);
    const v2483: *UH2 = UH2_RegexAlt(v2480, v2482);
    const v2484: *UH2 = UH2_RegexAlt(v2478, v2483);
    const v2485: *UH2 = normalize_4(v2484);
    const v2486: US0 = US0_BitOne();
    const v2487: *UH2 = UH2_RegexChar(v2486);
    const v2488: US0 = US0_BitZero();
    const v2489: *UH2 = UH2_RegexChar(v2488);
    const v2490: US0 = US0_BitOne();
    const v2491: *UH2 = UH2_RegexChar(v2490);
    const v2492: *UH2 = UH2_RegexAlt(v2489, v2491);
    const v2493: *UH2 = UH2_RegexAlt(v2487, v2492);
    const v2494: *UH2 = normalize_4(v2493);
    const v2495: *UH2 = normalize_4(v2494);
    const v2496: bool = regex_equal_9(v2485, v2495);
    if (v2496) {
    } else {
        if (spiral_true) spiralFail("alternative normalization should be idempotent");
    }
    const v2497: US0 = US0_BitZero();
    const v2498: *UH2 = UH2_RegexChar(v2497);
    const v2499: *UH2 = UH2_RegexEpsilon();
    const v2500: *UH2 = UH2_RegexCat(v2498, v2499);
    const v2501: US0 = US0_BitOne();
    const v2502: *UH2 = UH2_RegexChar(v2501);
    const v2503: *UH2 = UH2_RegexCat(v2500, v2502);
    const v2504: *UH2 = normalize_4(v2503);
    const v2505: US0 = US0_BitZero();
    const v2506: *UH2 = UH2_RegexChar(v2505);
    const v2507: *UH2 = UH2_RegexEpsilon();
    const v2508: *UH2 = UH2_RegexCat(v2506, v2507);
    const v2509: US0 = US0_BitOne();
    const v2510: *UH2 = UH2_RegexChar(v2509);
    const v2511: *UH2 = UH2_RegexCat(v2508, v2510);
    const v2512: *UH2 = normalize_4(v2511);
    const v2513: *UH2 = normalize_4(v2512);
    const v2514: bool = regex_equal_9(v2504, v2513);
    if (v2514) {
    } else {
        if (spiral_true) spiralFail("concatenation normalization should be idempotent");
    }
    const v2515: US0 = US0_BitZero();
    const v2516: *UH2 = UH2_RegexChar(v2515);
    const v2517: *UH2 = UH2_RegexStar(v2516);
    const v2518: *UH2 = UH2_RegexStar(v2517);
    const v2519: *UH2 = normalize_4(v2518);
    const v2520: US0 = US0_BitZero();
    const v2521: *UH2 = UH2_RegexChar(v2520);
    const v2522: *UH2 = UH2_RegexStar(v2521);
    const v2523: *UH2 = UH2_RegexStar(v2522);
    const v2524: *UH2 = normalize_4(v2523);
    const v2525: *UH2 = normalize_4(v2524);
    const v2526: bool = regex_equal_9(v2519, v2525);
    if (v2526) {
    } else {
        if (spiral_true) spiralFail("star normalization should be idempotent");
    }
    const v2527: US0 = US0_BitZero();
    const v2528: *UH2 = UH2_RegexChar(v2527);
    const v2529: US0 = US0_BitOne();
    const v2530: *UH2 = UH2_RegexChar(v2529);
    const v2531: *UH2 = UH2_RegexAlt(v2528, v2530);
    const v2532: *UH2 = UH2_RegexStar(v2531);
    const v2533: US0 = US0_BitZero();
    const v2534: *UH2 = UH2_RegexChar(v2533);
    const v2535: *UH2 = UH2_RegexCat(v2532, v2534);
    const v2536: bool = accepts_2(v2535, v6);
    if (v2536) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v2537: US0 = US0_BitZero();
    const v2538: *UH2 = UH2_RegexChar(v2537);
    const v2539: US0 = US0_BitOne();
    const v2540: *UH2 = UH2_RegexChar(v2539);
    const v2541: *UH2 = UH2_RegexAlt(v2538, v2540);
    const v2542: *UH2 = UH2_RegexStar(v2541);
    const v2543: US0 = US0_BitZero();
    const v2544: *UH2 = UH2_RegexChar(v2543);
    const v2545: *UH2 = UH2_RegexCat(v2542, v2544);
    const v2546: bool = accepts_2(v2545, v13);
    if (v2546) {
        if (spiral_true) spiralFail("brzozowski-expected-false");
    } else {
    }
    const v2547: US1 = US1_TriA();
    const v2548: *UH3 = UH3_RegexChar(v2547);
    const v2549: *UH3 = UH3_RegexStar(v2548);
    const v2550: bool = accepts_12(v2549, v21);
    if (v2550) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v2551: US1 = US1_TriA();
    const v2552: *UH3 = UH3_RegexChar(v2551);
    const v2553: *UH3 = UH3_RegexStar(v2552);
    const v2554: bool = accepts_12(v2553, v28);
    if (v2554) {
        if (spiral_true) spiralFail("brzozowski-expected-false");
    } else {
    }
    const v2555: US1 = US1_TriA();
    const v2556: *UH3 = UH3_RegexChar(v2555);
    const v2557: US1 = US1_TriB();
    const v2558: *UH3 = UH3_RegexChar(v2557);
    const v2559: *UH3 = UH3_RegexAlt(v2556, v2558);
    const v2560: *UH3 = UH3_RegexStar(v2559);
    const v2561: US1 = US1_TriC();
    const v2562: *UH3 = UH3_RegexChar(v2561);
    const v2563: *UH3 = UH3_RegexCat(v2560, v2562);
    const v2564: US1 = US1_TriA();
    const v2565: US1 = US1_TriB();
    const v2566: US1 = US1_TriA();
    const v2567: US1 = US1_TriC();
    const v2568: *UH1 = UH1_InputEmpty();
    const v2569: *UH1 = UH1_InputCons(v2567, v2568);
    const v2570: *UH1 = UH1_InputCons(v2566, v2569);
    const v2571: *UH1 = UH1_InputCons(v2565, v2570);
    const v2572: *UH1 = UH1_InputCons(v2564, v2571);
    const v2573: bool = accepts_12(v2563, v2572);
    if (v2573) {
    } else {
        if (spiral_true) spiralFail("ternary suffix matcher should accept the positive case");
    }
    const v2574: US1 = US1_TriA();
    const v2575: *UH3 = UH3_RegexChar(v2574);
    const v2576: US1 = US1_TriB();
    const v2577: *UH3 = UH3_RegexChar(v2576);
    const v2578: *UH3 = UH3_RegexAlt(v2575, v2577);
    const v2579: *UH3 = UH3_RegexStar(v2578);
    const v2580: US1 = US1_TriC();
    const v2581: *UH3 = UH3_RegexChar(v2580);
    const v2582: *UH3 = UH3_RegexCat(v2579, v2581);
    const v2583: US1 = US1_TriA();
    const v2584: US1 = US1_TriB();
    const v2585: US1 = US1_TriA();
    const v2586: US1 = US1_TriB();
    const v2587: *UH1 = UH1_InputEmpty();
    const v2588: *UH1 = UH1_InputCons(v2586, v2587);
    const v2589: *UH1 = UH1_InputCons(v2585, v2588);
    const v2590: *UH1 = UH1_InputCons(v2584, v2589);
    const v2591: *UH1 = UH1_InputCons(v2583, v2590);
    const v2592: bool = accepts_12(v2582, v2591);
    const v2593: bool = v2592 == false;
    if (v2593) {
    } else {
        if (spiral_true) spiralFail("ternary suffix matcher should reject the negative case");
    }
    const v2594: *UH2 = UH2_RegexEpsilon();
    const v2595: bool = accepts_2(v2594, v14);
    if (v2595) {
    } else {
        if (spiral_true) spiralFail("brzozowski-expected-true");
    }
    const v2596: *UH2 = UH2_RegexEmpty();
    const v2597: bool = accepts_2(v2596, v14);
    if (v2597) {
        if (spiral_true) spiralFail("brzozowski-expected-false");
    } else {
    }
    const v2598: US0 = US0_BitZero();
    const v2599: *UH2 = UH2_RegexChar(v2598);
    const v2600: US0 = US0_BitOne();
    const v2601: *UH2 = UH2_RegexChar(v2600);
    const v2602: *UH2 = UH2_RegexAlt(v2599, v2601);
    const v2603: *UH2 = UH2_RegexStar(v2602);
    const v2604: US0 = US0_BitZero();
    const v2605: *UH2 = UH2_RegexChar(v2604);
    const v2606: *UH2 = UH2_RegexCat(v2603, v2605);
    const v2607: US0 = US0_BitOne();
    const v2608: US0 = US0_BitOne();
    const v2609: US0 = US0_BitZero();
    const v2610: *UH0 = UH0_InputEmpty();
    const v2611: *UH0 = UH0_InputCons(v2609, v2610);
    const v2612: *UH0 = UH0_InputCons(v2608, v2611);
    const v2613: *UH0 = UH0_InputCons(v2607, v2612);
    const v2614: bool = reference_accepts_158(v2606, v2613);
    const v2615: US0 = US0_BitZero();
    const v2616: *UH2 = UH2_RegexChar(v2615);
    const v2617: US0 = US0_BitOne();
    const v2618: *UH2 = UH2_RegexChar(v2617);
    const v2619: *UH2 = UH2_RegexAlt(v2616, v2618);
    const v2620: *UH2 = UH2_RegexStar(v2619);
    const v2621: US0 = US0_BitZero();
    const v2622: *UH2 = UH2_RegexChar(v2621);
    const v2623: *UH2 = UH2_RegexCat(v2620, v2622);
    const v2624: US0 = US0_BitOne();
    const v2625: US0 = US0_BitOne();
    const v2626: US0 = US0_BitZero();
    const v2627: *UH0 = UH0_InputEmpty();
    const v2628: *UH0 = UH0_InputCons(v2626, v2627);
    const v2629: *UH0 = UH0_InputCons(v2625, v2628);
    const v2630: *UH0 = UH0_InputCons(v2624, v2629);
    const v2631: bool = accepts_2(v2623, v2630);
    if (v2614) {
        v2633 = v2631;
    } else {
        v2632 = false == v2631;
        v2633 = v2632;
    }
    if (v2633) {
    } else {
        if (spiral_true) spiralFail("bit reference matcher should agree on acceptance");
    }
    const v2634: US0 = US0_BitZero();
    const v2635: *UH2 = UH2_RegexChar(v2634);
    const v2636: US0 = US0_BitOne();
    const v2637: *UH2 = UH2_RegexChar(v2636);
    const v2638: *UH2 = UH2_RegexAlt(v2635, v2637);
    const v2639: *UH2 = UH2_RegexStar(v2638);
    const v2640: US0 = US0_BitZero();
    const v2641: *UH2 = UH2_RegexChar(v2640);
    const v2642: *UH2 = UH2_RegexCat(v2639, v2641);
    const v2643: US0 = US0_BitOne();
    const v2644: US0 = US0_BitOne();
    const v2645: US0 = US0_BitOne();
    const v2646: *UH0 = UH0_InputEmpty();
    const v2647: *UH0 = UH0_InputCons(v2645, v2646);
    const v2648: *UH0 = UH0_InputCons(v2644, v2647);
    const v2649: *UH0 = UH0_InputCons(v2643, v2648);
    const v2650: bool = reference_accepts_158(v2642, v2649);
    const v2651: US0 = US0_BitZero();
    const v2652: *UH2 = UH2_RegexChar(v2651);
    const v2653: US0 = US0_BitOne();
    const v2654: *UH2 = UH2_RegexChar(v2653);
    const v2655: *UH2 = UH2_RegexAlt(v2652, v2654);
    const v2656: *UH2 = UH2_RegexStar(v2655);
    const v2657: US0 = US0_BitZero();
    const v2658: *UH2 = UH2_RegexChar(v2657);
    const v2659: *UH2 = UH2_RegexCat(v2656, v2658);
    const v2660: US0 = US0_BitOne();
    const v2661: US0 = US0_BitOne();
    const v2662: US0 = US0_BitOne();
    const v2663: *UH0 = UH0_InputEmpty();
    const v2664: *UH0 = UH0_InputCons(v2662, v2663);
    const v2665: *UH0 = UH0_InputCons(v2661, v2664);
    const v2666: *UH0 = UH0_InputCons(v2660, v2665);
    const v2667: bool = accepts_2(v2659, v2666);
    if (v2650) {
        v2669 = v2667;
    } else {
        v2668 = false == v2667;
        v2669 = v2668;
    }
    if (v2669) {
    } else {
        if (spiral_true) spiralFail("bit reference matcher should agree on rejection");
    }
    const v2670: US1 = US1_TriA();
    const v2671: *UH3 = UH3_RegexChar(v2670);
    const v2672: *UH3 = UH3_RegexStar(v2671);
    const v2673: US1 = US1_TriA();
    const v2674: US1 = US1_TriA();
    const v2675: US1 = US1_TriA();
    const v2676: *UH1 = UH1_InputEmpty();
    const v2677: *UH1 = UH1_InputCons(v2675, v2676);
    const v2678: *UH1 = UH1_InputCons(v2674, v2677);
    const v2679: *UH1 = UH1_InputCons(v2673, v2678);
    const v2680: bool = reference_accepts_159(v2672, v2679);
    const v2681: US1 = US1_TriA();
    const v2682: *UH3 = UH3_RegexChar(v2681);
    const v2683: *UH3 = UH3_RegexStar(v2682);
    const v2684: US1 = US1_TriA();
    const v2685: US1 = US1_TriA();
    const v2686: US1 = US1_TriA();
    const v2687: *UH1 = UH1_InputEmpty();
    const v2688: *UH1 = UH1_InputCons(v2686, v2687);
    const v2689: *UH1 = UH1_InputCons(v2685, v2688);
    const v2690: *UH1 = UH1_InputCons(v2684, v2689);
    const v2691: bool = accepts_12(v2683, v2690);
    if (v2680) {
        v2693 = v2691;
    } else {
        v2692 = false == v2691;
        v2693 = v2692;
    }
    if (v2693) {
    } else {
        if (spiral_true) spiralFail("ternary reference matcher should agree on acceptance");
    }
    const v2694: US1 = US1_TriA();
    const v2695: *UH3 = UH3_RegexChar(v2694);
    const v2696: *UH3 = UH3_RegexStar(v2695);
    const v2697: US1 = US1_TriA();
    const v2698: US1 = US1_TriA();
    const v2699: US1 = US1_TriB();
    const v2700: *UH1 = UH1_InputEmpty();
    const v2701: *UH1 = UH1_InputCons(v2699, v2700);
    const v2702: *UH1 = UH1_InputCons(v2698, v2701);
    const v2703: *UH1 = UH1_InputCons(v2697, v2702);
    const v2704: bool = reference_accepts_159(v2696, v2703);
    const v2705: US1 = US1_TriA();
    const v2706: *UH3 = UH3_RegexChar(v2705);
    const v2707: *UH3 = UH3_RegexStar(v2706);
    const v2708: US1 = US1_TriA();
    const v2709: US1 = US1_TriA();
    const v2710: US1 = US1_TriB();
    const v2711: *UH1 = UH1_InputEmpty();
    const v2712: *UH1 = UH1_InputCons(v2710, v2711);
    const v2713: *UH1 = UH1_InputCons(v2709, v2712);
    const v2714: *UH1 = UH1_InputCons(v2708, v2713);
    const v2715: bool = accepts_12(v2707, v2714);
    if (v2704) {
        v2717 = v2715;
    } else {
        v2716 = false == v2715;
        v2717 = v2716;
    }
    if (v2717) {
    } else {
        if (spiral_true) spiralFail("ternary reference matcher should agree on rejection");
    }
    const v2718: US1 = US1_TriA();
    const v2719: *UH3 = UH3_RegexChar(v2718);
    const v2720: US1 = US1_TriB();
    const v2721: *UH3 = UH3_RegexChar(v2720);
    const v2722: *UH3 = UH3_RegexAlt(v2719, v2721);
    const v2723: *UH3 = UH3_RegexStar(v2722);
    const v2724: US1 = US1_TriC();
    const v2725: *UH3 = UH3_RegexChar(v2724);
    const v2726: *UH3 = UH3_RegexCat(v2723, v2725);
    const v2727: US1 = US1_TriA();
    const v2728: US1 = US1_TriB();
    const v2729: US1 = US1_TriA();
    const v2730: US1 = US1_TriC();
    const v2731: *UH1 = UH1_InputEmpty();
    const v2732: *UH1 = UH1_InputCons(v2730, v2731);
    const v2733: *UH1 = UH1_InputCons(v2729, v2732);
    const v2734: *UH1 = UH1_InputCons(v2728, v2733);
    const v2735: *UH1 = UH1_InputCons(v2727, v2734);
    const v2736: bool = reference_accepts_159(v2726, v2735);
    const v2737: US1 = US1_TriA();
    const v2738: *UH3 = UH3_RegexChar(v2737);
    const v2739: US1 = US1_TriB();
    const v2740: *UH3 = UH3_RegexChar(v2739);
    const v2741: *UH3 = UH3_RegexAlt(v2738, v2740);
    const v2742: *UH3 = UH3_RegexStar(v2741);
    const v2743: US1 = US1_TriC();
    const v2744: *UH3 = UH3_RegexChar(v2743);
    const v2745: *UH3 = UH3_RegexCat(v2742, v2744);
    const v2746: US1 = US1_TriA();
    const v2747: US1 = US1_TriB();
    const v2748: US1 = US1_TriA();
    const v2749: US1 = US1_TriC();
    const v2750: *UH1 = UH1_InputEmpty();
    const v2751: *UH1 = UH1_InputCons(v2749, v2750);
    const v2752: *UH1 = UH1_InputCons(v2748, v2751);
    const v2753: *UH1 = UH1_InputCons(v2747, v2752);
    const v2754: *UH1 = UH1_InputCons(v2746, v2753);
    const v2755: bool = accepts_12(v2745, v2754);
    if (v2736) {
        v2757 = v2755;
    } else {
        v2756 = false == v2755;
        v2757 = v2756;
    }
    if (v2757) {
    } else {
        if (spiral_true) spiralFail("ternary suffix reference matcher should agree on acceptance");
    }
    const v2758: US1 = US1_TriA();
    const v2759: *UH3 = UH3_RegexChar(v2758);
    const v2760: US1 = US1_TriB();
    const v2761: *UH3 = UH3_RegexChar(v2760);
    const v2762: *UH3 = UH3_RegexAlt(v2759, v2761);
    const v2763: *UH3 = UH3_RegexStar(v2762);
    const v2764: US1 = US1_TriC();
    const v2765: *UH3 = UH3_RegexChar(v2764);
    const v2766: *UH3 = UH3_RegexCat(v2763, v2765);
    const v2767: US1 = US1_TriA();
    const v2768: US1 = US1_TriB();
    const v2769: US1 = US1_TriA();
    const v2770: US1 = US1_TriB();
    const v2771: *UH1 = UH1_InputEmpty();
    const v2772: *UH1 = UH1_InputCons(v2770, v2771);
    const v2773: *UH1 = UH1_InputCons(v2769, v2772);
    const v2774: *UH1 = UH1_InputCons(v2768, v2773);
    const v2775: *UH1 = UH1_InputCons(v2767, v2774);
    const v2776: bool = reference_accepts_159(v2766, v2775);
    const v2777: US1 = US1_TriA();
    const v2778: *UH3 = UH3_RegexChar(v2777);
    const v2779: US1 = US1_TriB();
    const v2780: *UH3 = UH3_RegexChar(v2779);
    const v2781: *UH3 = UH3_RegexAlt(v2778, v2780);
    const v2782: *UH3 = UH3_RegexStar(v2781);
    const v2783: US1 = US1_TriC();
    const v2784: *UH3 = UH3_RegexChar(v2783);
    const v2785: *UH3 = UH3_RegexCat(v2782, v2784);
    const v2786: US1 = US1_TriA();
    const v2787: US1 = US1_TriB();
    const v2788: US1 = US1_TriA();
    const v2789: US1 = US1_TriB();
    const v2790: *UH1 = UH1_InputEmpty();
    const v2791: *UH1 = UH1_InputCons(v2789, v2790);
    const v2792: *UH1 = UH1_InputCons(v2788, v2791);
    const v2793: *UH1 = UH1_InputCons(v2787, v2792);
    const v2794: *UH1 = UH1_InputCons(v2786, v2793);
    const v2795: bool = accepts_12(v2785, v2794);
    if (v2776) {
        v2797 = v2795;
    } else {
        v2796 = false == v2795;
        v2797 = v2796;
    }
    if (v2797) {
    } else {
        if (spiral_true) spiralFail("ternary suffix reference matcher should agree on rejection");
    }
    const v2798: *UH0 = UH0_InputEmpty();
    const v2799: US0 = US0_BitZero();
    const v2800: *UH2 = UH2_RegexChar(v2799);
    const v2801: US0 = US0_BitOne();
    const v2802: *UH2 = UH2_RegexChar(v2801);
    const v2803: *UH2 = UH2_RegexAlt(v2800, v2802);
    const v2804: *UH2 = UH2_RegexStar(v2803);
    const v2805: US0 = US0_BitZero();
    const v2806: *UH2 = UH2_RegexChar(v2805);
    const v2807: *UH2 = UH2_RegexCat(v2804, v2806);
    const v2808: US0 = US0_BitOne();
    const v2809: US0 = US0_BitOne();
    const v2810: US0 = US0_BitZero();
    const v2811: *UH0 = UH0_InputEmpty();
    const v2812: *UH0 = UH0_InputCons(v2810, v2811);
    const v2813: *UH0 = UH0_InputCons(v2809, v2812);
    const v2814: *UH0 = UH0_InputCons(v2808, v2813);
    const v2815: *UH5 = language_remainders_27(v2807, v2814);
    const v2816: bool = input_list_contains_32(v2798, v2815);
    const v2817: US0 = US0_BitZero();
    const v2818: *UH2 = UH2_RegexChar(v2817);
    const v2819: US0 = US0_BitOne();
    const v2820: *UH2 = UH2_RegexChar(v2819);
    const v2821: *UH2 = UH2_RegexAlt(v2818, v2820);
    const v2822: *UH2 = UH2_RegexStar(v2821);
    const v2823: US0 = US0_BitZero();
    const v2824: *UH2 = UH2_RegexChar(v2823);
    const v2825: *UH2 = UH2_RegexCat(v2822, v2824);
    const v2826: US0 = US0_BitOne();
    const v2827: US0 = US0_BitOne();
    const v2828: US0 = US0_BitZero();
    const v2829: *UH0 = UH0_InputEmpty();
    const v2830: *UH0 = UH0_InputCons(v2828, v2829);
    const v2831: *UH0 = UH0_InputCons(v2827, v2830);
    const v2832: *UH0 = UH0_InputCons(v2826, v2831);
    const v2833: bool = accepts_2(v2825, v2832);
    if (v2816) {
        v2835 = v2833;
    } else {
        v2834 = false == v2833;
        v2835 = v2834;
    }
    if (v2835) {
    } else {
        if (spiral_true) spiralFail("bit direct-language oracle should agree on acceptance");
    }
    const v2836: *UH0 = UH0_InputEmpty();
    const v2837: US0 = US0_BitZero();
    const v2838: *UH2 = UH2_RegexChar(v2837);
    const v2839: US0 = US0_BitOne();
    const v2840: *UH2 = UH2_RegexChar(v2839);
    const v2841: *UH2 = UH2_RegexAlt(v2838, v2840);
    const v2842: *UH2 = UH2_RegexStar(v2841);
    const v2843: US0 = US0_BitZero();
    const v2844: *UH2 = UH2_RegexChar(v2843);
    const v2845: *UH2 = UH2_RegexCat(v2842, v2844);
    const v2846: US0 = US0_BitOne();
    const v2847: US0 = US0_BitOne();
    const v2848: US0 = US0_BitOne();
    const v2849: *UH0 = UH0_InputEmpty();
    const v2850: *UH0 = UH0_InputCons(v2848, v2849);
    const v2851: *UH0 = UH0_InputCons(v2847, v2850);
    const v2852: *UH0 = UH0_InputCons(v2846, v2851);
    const v2853: *UH5 = language_remainders_27(v2845, v2852);
    const v2854: bool = input_list_contains_32(v2836, v2853);
    const v2855: US0 = US0_BitZero();
    const v2856: *UH2 = UH2_RegexChar(v2855);
    const v2857: US0 = US0_BitOne();
    const v2858: *UH2 = UH2_RegexChar(v2857);
    const v2859: *UH2 = UH2_RegexAlt(v2856, v2858);
    const v2860: *UH2 = UH2_RegexStar(v2859);
    const v2861: US0 = US0_BitZero();
    const v2862: *UH2 = UH2_RegexChar(v2861);
    const v2863: *UH2 = UH2_RegexCat(v2860, v2862);
    const v2864: US0 = US0_BitOne();
    const v2865: US0 = US0_BitOne();
    const v2866: US0 = US0_BitOne();
    const v2867: *UH0 = UH0_InputEmpty();
    const v2868: *UH0 = UH0_InputCons(v2866, v2867);
    const v2869: *UH0 = UH0_InputCons(v2865, v2868);
    const v2870: *UH0 = UH0_InputCons(v2864, v2869);
    const v2871: bool = accepts_2(v2863, v2870);
    if (v2854) {
        v2873 = v2871;
    } else {
        v2872 = false == v2871;
        v2873 = v2872;
    }
    if (v2873) {
    } else {
        if (spiral_true) spiralFail("bit direct-language oracle should agree on rejection");
    }
    const v2874: *UH1 = UH1_InputEmpty();
    const v2875: US1 = US1_TriA();
    const v2876: *UH3 = UH3_RegexChar(v2875);
    const v2877: *UH3 = UH3_RegexStar(v2876);
    const v2878: US1 = US1_TriA();
    const v2879: US1 = US1_TriA();
    const v2880: US1 = US1_TriA();
    const v2881: *UH1 = UH1_InputEmpty();
    const v2882: *UH1 = UH1_InputCons(v2880, v2881);
    const v2883: *UH1 = UH1_InputCons(v2879, v2882);
    const v2884: *UH1 = UH1_InputCons(v2878, v2883);
    const v2885: *UH7 = language_remainders_41(v2877, v2884);
    const v2886: bool = input_list_contains_46(v2874, v2885);
    const v2887: US1 = US1_TriA();
    const v2888: *UH3 = UH3_RegexChar(v2887);
    const v2889: *UH3 = UH3_RegexStar(v2888);
    const v2890: US1 = US1_TriA();
    const v2891: US1 = US1_TriA();
    const v2892: US1 = US1_TriA();
    const v2893: *UH1 = UH1_InputEmpty();
    const v2894: *UH1 = UH1_InputCons(v2892, v2893);
    const v2895: *UH1 = UH1_InputCons(v2891, v2894);
    const v2896: *UH1 = UH1_InputCons(v2890, v2895);
    const v2897: bool = accepts_12(v2889, v2896);
    if (v2886) {
        v2899 = v2897;
    } else {
        v2898 = false == v2897;
        v2899 = v2898;
    }
    if (v2899) {
    } else {
        if (spiral_true) spiralFail("ternary direct-language oracle should agree on acceptance");
    }
    const v2900: *UH1 = UH1_InputEmpty();
    const v2901: US1 = US1_TriA();
    const v2902: *UH3 = UH3_RegexChar(v2901);
    const v2903: *UH3 = UH3_RegexStar(v2902);
    const v2904: US1 = US1_TriA();
    const v2905: US1 = US1_TriA();
    const v2906: US1 = US1_TriB();
    const v2907: *UH1 = UH1_InputEmpty();
    const v2908: *UH1 = UH1_InputCons(v2906, v2907);
    const v2909: *UH1 = UH1_InputCons(v2905, v2908);
    const v2910: *UH1 = UH1_InputCons(v2904, v2909);
    const v2911: *UH7 = language_remainders_41(v2903, v2910);
    const v2912: bool = input_list_contains_46(v2900, v2911);
    const v2913: US1 = US1_TriA();
    const v2914: *UH3 = UH3_RegexChar(v2913);
    const v2915: *UH3 = UH3_RegexStar(v2914);
    const v2916: US1 = US1_TriA();
    const v2917: US1 = US1_TriA();
    const v2918: US1 = US1_TriB();
    const v2919: *UH1 = UH1_InputEmpty();
    const v2920: *UH1 = UH1_InputCons(v2918, v2919);
    const v2921: *UH1 = UH1_InputCons(v2917, v2920);
    const v2922: *UH1 = UH1_InputCons(v2916, v2921);
    const v2923: bool = accepts_12(v2915, v2922);
    if (v2912) {
        v2925 = v2923;
    } else {
        v2924 = false == v2923;
        v2925 = v2924;
    }
    if (v2925) {
    } else {
        if (spiral_true) spiralFail("ternary direct-language oracle should agree on rejection");
    }
    const v2926: *UH1 = UH1_InputEmpty();
    const v2927: US1 = US1_TriA();
    const v2928: *UH3 = UH3_RegexChar(v2927);
    const v2929: US1 = US1_TriB();
    const v2930: *UH3 = UH3_RegexChar(v2929);
    const v2931: *UH3 = UH3_RegexAlt(v2928, v2930);
    const v2932: *UH3 = UH3_RegexStar(v2931);
    const v2933: US1 = US1_TriC();
    const v2934: *UH3 = UH3_RegexChar(v2933);
    const v2935: *UH3 = UH3_RegexCat(v2932, v2934);
    const v2936: US1 = US1_TriA();
    const v2937: US1 = US1_TriB();
    const v2938: US1 = US1_TriA();
    const v2939: US1 = US1_TriC();
    const v2940: *UH1 = UH1_InputEmpty();
    const v2941: *UH1 = UH1_InputCons(v2939, v2940);
    const v2942: *UH1 = UH1_InputCons(v2938, v2941);
    const v2943: *UH1 = UH1_InputCons(v2937, v2942);
    const v2944: *UH1 = UH1_InputCons(v2936, v2943);
    const v2945: *UH7 = language_remainders_41(v2935, v2944);
    const v2946: bool = input_list_contains_46(v2926, v2945);
    const v2947: US1 = US1_TriA();
    const v2948: *UH3 = UH3_RegexChar(v2947);
    const v2949: US1 = US1_TriB();
    const v2950: *UH3 = UH3_RegexChar(v2949);
    const v2951: *UH3 = UH3_RegexAlt(v2948, v2950);
    const v2952: *UH3 = UH3_RegexStar(v2951);
    const v2953: US1 = US1_TriC();
    const v2954: *UH3 = UH3_RegexChar(v2953);
    const v2955: *UH3 = UH3_RegexCat(v2952, v2954);
    const v2956: US1 = US1_TriA();
    const v2957: US1 = US1_TriB();
    const v2958: US1 = US1_TriA();
    const v2959: US1 = US1_TriC();
    const v2960: *UH1 = UH1_InputEmpty();
    const v2961: *UH1 = UH1_InputCons(v2959, v2960);
    const v2962: *UH1 = UH1_InputCons(v2958, v2961);
    const v2963: *UH1 = UH1_InputCons(v2957, v2962);
    const v2964: *UH1 = UH1_InputCons(v2956, v2963);
    const v2965: bool = accepts_12(v2955, v2964);
    if (v2946) {
        v2967 = v2965;
    } else {
        v2966 = false == v2965;
        v2967 = v2966;
    }
    if (v2967) {
    } else {
        if (spiral_true) spiralFail("ternary suffix direct-language oracle should agree on acceptance");
    }
    const v2968: *UH1 = UH1_InputEmpty();
    const v2969: US1 = US1_TriA();
    const v2970: *UH3 = UH3_RegexChar(v2969);
    const v2971: US1 = US1_TriB();
    const v2972: *UH3 = UH3_RegexChar(v2971);
    const v2973: *UH3 = UH3_RegexAlt(v2970, v2972);
    const v2974: *UH3 = UH3_RegexStar(v2973);
    const v2975: US1 = US1_TriC();
    const v2976: *UH3 = UH3_RegexChar(v2975);
    const v2977: *UH3 = UH3_RegexCat(v2974, v2976);
    const v2978: US1 = US1_TriA();
    const v2979: US1 = US1_TriB();
    const v2980: US1 = US1_TriA();
    const v2981: US1 = US1_TriB();
    const v2982: *UH1 = UH1_InputEmpty();
    const v2983: *UH1 = UH1_InputCons(v2981, v2982);
    const v2984: *UH1 = UH1_InputCons(v2980, v2983);
    const v2985: *UH1 = UH1_InputCons(v2979, v2984);
    const v2986: *UH1 = UH1_InputCons(v2978, v2985);
    const v2987: *UH7 = language_remainders_41(v2977, v2986);
    const v2988: bool = input_list_contains_46(v2968, v2987);
    const v2989: US1 = US1_TriA();
    const v2990: *UH3 = UH3_RegexChar(v2989);
    const v2991: US1 = US1_TriB();
    const v2992: *UH3 = UH3_RegexChar(v2991);
    const v2993: *UH3 = UH3_RegexAlt(v2990, v2992);
    const v2994: *UH3 = UH3_RegexStar(v2993);
    const v2995: US1 = US1_TriC();
    const v2996: *UH3 = UH3_RegexChar(v2995);
    const v2997: *UH3 = UH3_RegexCat(v2994, v2996);
    const v2998: US1 = US1_TriA();
    const v2999: US1 = US1_TriB();
    const v3000: US1 = US1_TriA();
    const v3001: US1 = US1_TriB();
    const v3002: *UH1 = UH1_InputEmpty();
    const v3003: *UH1 = UH1_InputCons(v3001, v3002);
    const v3004: *UH1 = UH1_InputCons(v3000, v3003);
    const v3005: *UH1 = UH1_InputCons(v2999, v3004);
    const v3006: *UH1 = UH1_InputCons(v2998, v3005);
    const v3007: bool = accepts_12(v2997, v3006);
    if (v2988) {
        v3009 = v3007;
    } else {
        v3008 = false == v3007;
        v3009 = v3008;
    }
    if (v3009) {
    } else {
        if (spiral_true) spiralFail("ternary suffix direct-language oracle should agree on rejection");
    }
    const v3010: *UH0 = UH0_InputEmpty();
    const v3011: US0 = US0_BitZero();
    const v3012: *UH2 = UH2_RegexChar(v3011);
    const v3013: *UH2 = UH2_RegexStar(v3012);
    const v3014: US0 = US0_BitZero();
    const v3015: US0 = US0_BitOne();
    const v3016: *UH0 = UH0_InputEmpty();
    const v3017: *UH0 = UH0_InputCons(v3015, v3016);
    const v3018: *UH0 = UH0_InputCons(v3014, v3017);
    const v3019: *UH5 = language_remainders_27(v3013, v3018);
    const v3020: bool = input_list_contains_32(v3010, v3019);
    const v3021: *UH0 = UH0_InputEmpty();
    const v3022: *UH2 = UH2_RegexEmpty();
    const v3023: US0 = US0_BitZero();
    const v3024: US0 = US0_BitOne();
    const v3025: *UH0 = UH0_InputEmpty();
    const v3026: *UH0 = UH0_InputCons(v3024, v3025);
    const v3027: *UH0 = UH0_InputCons(v3023, v3026);
    const v3028: *UH5 = language_remainders_27(v3022, v3027);
    const v3029: bool = input_list_contains_32(v3021, v3028);
    if (v3020) {
        v3031 = v3029;
    } else {
        v3030 = false == v3029;
        v3031 = v3030;
    }
    if (v3031) {
    } else {
        if (spiral_true) spiralFail("boolean-only normalization observation must be able to miss a bad candidate");
    }
    const v3032: US0 = US0_BitZero();
    const v3033: *UH2 = UH2_RegexChar(v3032);
    const v3034: *UH2 = UH2_RegexStar(v3033);
    const v3035: US0 = US0_BitZero();
    const v3036: US0 = US0_BitOne();
    const v3037: *UH0 = UH0_InputEmpty();
    const v3038: *UH0 = UH0_InputCons(v3036, v3037);
    const v3039: *UH0 = UH0_InputCons(v3035, v3038);
    const v3040: *UH5 = language_remainders_27(v3034, v3039);
    const v3041: *UH2 = UH2_RegexEmpty();
    const v3042: US0 = US0_BitZero();
    const v3043: US0 = US0_BitOne();
    const v3044: *UH0 = UH0_InputEmpty();
    const v3045: *UH0 = UH0_InputCons(v3043, v3044);
    const v3046: *UH0 = UH0_InputCons(v3042, v3045);
    const v3047: *UH5 = language_remainders_27(v3041, v3046);
    const v3048: bool = input_list_subset_35(v3040, v3047);
    if (v3048) {
        v3050 = input_list_subset_35(v3047, v3040);
    } else {
        v3050 = false;
    }
    const v3051: bool = v3050 == false;
    if (v3051) {
    } else {
        if (spiral_true) spiralFail("remainder-set normalization law must distinguish a bad candidate hidden by the final boolean");
    }
    const v3052: US0 = US0_BitZero();
    const v3053: US0 = US0_BitOne();
    const v3054: *UH4 = UH4_SymbolListNil();
    const v3055: *UH4 = UH4_SymbolListCons(v3053, v3054);
    const v3056: *UH4 = UH4_SymbolListCons(v3052, v3055);
    const v3057: *UH5 = input_singletons_from_symbols_71(v3056);
    const v3058: *UH0 = UH0_InputEmpty();
    const v3059: *UH5 = UH5_InputListCons(v3058, v3057);
    const v3060: US0 = US0_BitZero();
    const v3061: US0 = US0_BitOne();
    const v3062: *UH4 = UH4_SymbolListNil();
    const v3063: *UH4 = UH4_SymbolListCons(v3061, v3062);
    const v3064: *UH4 = UH4_SymbolListCons(v3060, v3063);
    const v3065: US0 = US0_BitZero();
    const v3066: US0 = US0_BitOne();
    const v3067: *UH4 = UH4_SymbolListNil();
    const v3068: *UH4 = UH4_SymbolListCons(v3066, v3067);
    const v3069: *UH4 = UH4_SymbolListCons(v3065, v3068);
    const v3070: *UH5 = input_singletons_from_symbols_71(v3069);
    const v3071: *UH5 = input_prepend_symbols_to_corpus_72(v3064, v3070);
    const v3072: *UH5 = input_list_append_28(v3059, v3071);
    const v3073: US1 = US1_TriA();
    const v3074: US1 = US1_TriB();
    const v3075: US1 = US1_TriC();
    const v3076: *UH6 = UH6_SymbolListNil();
    const v3077: *UH6 = UH6_SymbolListCons(v3075, v3076);
    const v3078: *UH6 = UH6_SymbolListCons(v3074, v3077);
    const v3079: *UH6 = UH6_SymbolListCons(v3073, v3078);
    const v3080: *UH7 = input_singletons_from_symbols_129(v3079);
    const v3081: *UH1 = UH1_InputEmpty();
    const v3082: *UH7 = UH7_InputListCons(v3081, v3080);
    const v3083: US1 = US1_TriA();
    const v3084: US1 = US1_TriB();
    const v3085: US1 = US1_TriC();
    const v3086: *UH6 = UH6_SymbolListNil();
    const v3087: *UH6 = UH6_SymbolListCons(v3085, v3086);
    const v3088: *UH6 = UH6_SymbolListCons(v3084, v3087);
    const v3089: *UH6 = UH6_SymbolListCons(v3083, v3088);
    const v3090: US1 = US1_TriA();
    const v3091: US1 = US1_TriB();
    const v3092: US1 = US1_TriC();
    const v3093: *UH6 = UH6_SymbolListNil();
    const v3094: *UH6 = UH6_SymbolListCons(v3092, v3093);
    const v3095: *UH6 = UH6_SymbolListCons(v3091, v3094);
    const v3096: *UH6 = UH6_SymbolListCons(v3090, v3095);
    const v3097: *UH7 = input_singletons_from_symbols_129(v3096);
    const v3098: *UH7 = input_prepend_symbols_to_corpus_130(v3089, v3097);
    const v3099: *UH7 = input_list_append_42(v3082, v3098);
    const v3100: *UH2 = UH2_RegexEmpty();
    const v3101: *UH2 = UH2_RegexEpsilon();
    const v3102: *UH9 = UH9_RegexListCons(v3101, v315);
    const v3103: *UH9 = UH9_RegexListCons(v3100, v3102);
    const v3104: US0 = US0_BitZero();
    const v3105: US0 = US0_BitOne();
    const v3106: *UH4 = UH4_SymbolListNil();
    const v3107: *UH4 = UH4_SymbolListCons(v3105, v3106);
    const v3108: *UH4 = UH4_SymbolListCons(v3104, v3107);
    const v3109: bool = derivative_language_law_corpus_62(v3103, v3108, v3072);
    if (v3109) {
    } else {
        if (spiral_true) spiralFail("direct-language oracle should validate bit derivative law corpus");
    }
    const v3110: US1 = US1_TriA();
    const v3111: *UH3 = UH3_RegexChar(v3110);
    const v3112: *UH3 = UH3_RegexStar(v3111);
    const v3113: US1 = US1_TriA();
    const v3114: *UH3 = UH3_RegexChar(v3113);
    const v3115: US1 = US1_TriB();
    const v3116: *UH3 = UH3_RegexChar(v3115);
    const v3117: *UH3 = UH3_RegexAlt(v3114, v3116);
    const v3118: *UH3 = UH3_RegexStar(v3117);
    const v3119: US1 = US1_TriC();
    const v3120: *UH3 = UH3_RegexChar(v3119);
    const v3121: *UH3 = UH3_RegexCat(v3118, v3120);
    const v3122: *UH10 = UH10_RegexListNil();
    const v3123: *UH10 = UH10_RegexListCons(v3121, v3122);
    const v3124: *UH10 = UH10_RegexListCons(v3112, v3123);
    const v3125: US1 = US1_TriA();
    const v3126: US1 = US1_TriB();
    const v3127: US1 = US1_TriC();
    const v3128: *UH6 = UH6_SymbolListNil();
    const v3129: *UH6 = UH6_SymbolListCons(v3127, v3128);
    const v3130: *UH6 = UH6_SymbolListCons(v3126, v3129);
    const v3131: *UH6 = UH6_SymbolListCons(v3125, v3130);
    const v3132: bool = derivative_language_law_corpus_65(v3124, v3131, v3099);
    if (v3132) {
    } else {
        if (spiral_true) spiralFail("direct-language oracle should validate ternary derivative law corpus");
    }
    const v3133: *UH2 = UH2_RegexEmpty();
    const v3134: *UH2 = UH2_RegexEpsilon();
    const v3135: US0 = US0_BitZero();
    const v3136: *UH2 = UH2_RegexChar(v3135);
    const v3137: US0 = US0_BitOne();
    const v3138: *UH2 = UH2_RegexChar(v3137);
    const v3139: *UH2 = UH2_RegexAlt(v3136, v3138);
    const v3140: *UH2 = UH2_RegexStar(v3139);
    const v3141: US0 = US0_BitZero();
    const v3142: *UH2 = UH2_RegexChar(v3141);
    const v3143: *UH2 = UH2_RegexCat(v3140, v3142);
    const v3144: *UH2 = UH2_RegexAlt(v3134, v3143);
    const v3145: *UH2 = UH2_RegexAlt(v3133, v3144);
    const v3146: US0 = US0_BitZero();
    const v3147: US0 = US0_BitOne();
    const v3148: *UH4 = UH4_SymbolListNil();
    const v3149: *UH4 = UH4_SymbolListCons(v3147, v3148);
    const v3150: *UH4 = UH4_SymbolListCons(v3146, v3149);
    const v3151: bool = derivative_semantic_triangle_symbols_23(v3145, v3150, v3072);
    if (v3151) {
    } else {
        if (spiral_true) spiralFail("structural semantic triangle should cover every regex constructor");
    }
    const v3152: US1 = US1_TriA();
    const v3153: *UH3 = UH3_RegexChar(v3152);
    const v3154: US1 = US1_TriB();
    const v3155: *UH3 = UH3_RegexChar(v3154);
    const v3156: *UH3 = UH3_RegexAlt(v3153, v3155);
    const v3157: *UH3 = UH3_RegexStar(v3156);
    const v3158: US1 = US1_TriC();
    const v3159: *UH3 = UH3_RegexChar(v3158);
    const v3160: *UH3 = UH3_RegexCat(v3157, v3159);
    const v3161: US1 = US1_TriA();
    const v3162: US1 = US1_TriB();
    const v3163: US1 = US1_TriC();
    const v3164: *UH6 = UH6_SymbolListNil();
    const v3165: *UH6 = UH6_SymbolListCons(v3163, v3164);
    const v3166: *UH6 = UH6_SymbolListCons(v3162, v3165);
    const v3167: *UH6 = UH6_SymbolListCons(v3161, v3166);
    const v3168: bool = derivative_semantic_triangle_symbols_37(v3160, v3167, v3099);
    if (v3168) {
    } else {
        if (spiral_true) spiralFail("structural semantic triangle should hold for ternary composite regex");
    }
    const v3169: US0 = US0_BitZero();
    const v3170: *UH2 = UH2_RegexChar(v3169);
    const v3171: *UH2 = UH2_RegexStar(v3170);
    const v3172: US0 = US0_BitZero();
    const v3173: *UH0 = UH0_InputEmpty();
    const v3174: *UH0 = UH0_InputCons(v3172, v3173);
    const v3175: *UH5 = language_remainders_27(v3171, v3174);
    const v3176: US0 = US0_BitZero();
    const v3177: *UH2 = UH2_RegexChar(v3176);
    const v3178: *UH2 = UH2_RegexStar(v3177);
    const v3179: US0 = US0_BitZero();
    const v3180: *UH2 = canonical_derivative_3(v3178, v3179);
    const v3181: *UH0 = UH0_InputEmpty();
    const v3182: *UH5 = language_remainders_27(v3180, v3181);
    const v3183: bool = input_list_subset_35(v3175, v3182);
    if (v3183) {
        v3185 = input_list_subset_35(v3182, v3175);
    } else {
        v3185 = false;
    }
    const v3186: bool = v3185 == false;
    if (v3186) {
    } else {
        if (spiral_true) spiralFail("raw remainder equality must expose the nullable zero-consumption remainder");
    }
    const v3187: US0 = US0_BitZero();
    const v3188: *UH2 = UH2_RegexChar(v3187);
    const v3189: *UH2 = UH2_RegexStar(v3188);
    const v3190: US0 = US0_BitZero();
    const v3191: *UH2 = canonical_derivative_3(v3189, v3190);
    const v3192: US0 = US0_BitZero();
    const v3193: *UH0 = UH0_InputEmpty();
    const v3194: *UH0 = UH0_InputCons(v3192, v3193);
    const v3195: US0 = US0_BitZero();
    const v3196: *UH2 = UH2_RegexChar(v3195);
    const v3197: *UH2 = UH2_RegexStar(v3196);
    const v3198: US0 = US0_BitZero();
    const v3199: *UH0 = UH0_InputEmpty();
    const v3200: *UH0 = UH0_InputCons(v3198, v3199);
    const v3201: *UH5 = language_remainders_27(v3197, v3200);
    const v3202: *UH5 = input_list_remove_34(v3194, v3201);
    const v3203: *UH0 = UH0_InputEmpty();
    const v3204: *UH5 = language_remainders_27(v3191, v3203);
    const v3205: bool = input_list_subset_35(v3202, v3204);
    if (v3205) {
        v3207 = input_list_subset_35(v3204, v3202);
    } else {
        v3207 = false;
    }
    if (v3207) {
    } else {
        if (spiral_true) spiralFail("derivative remainder law should remove only the zero-consumption remainder");
    }
    const v3208: *UH2 = UH2_RegexEmpty();
    const v3209: US0 = US0_BitZero();
    const v3210: *UH2 = canonical_derivative_3(v3208, v3209);
    const v3211: US0 = US0_BitZero();
    const v3212: *UH0 = UH0_InputEmpty();
    const v3213: *UH0 = UH0_InputCons(v3211, v3212);
    const v3214: *UH2 = UH2_RegexEmpty();
    const v3215: US0 = US0_BitZero();
    const v3216: *UH0 = UH0_InputEmpty();
    const v3217: *UH0 = UH0_InputCons(v3215, v3216);
    const v3218: *UH5 = language_remainders_27(v3214, v3217);
    const v3219: *UH5 = input_list_remove_34(v3213, v3218);
    const v3220: *UH0 = UH0_InputEmpty();
    const v3221: *UH5 = language_remainders_27(v3210, v3220);
    const v3222: bool = input_list_subset_35(v3219, v3221);
    if (v3222) {
        v3224 = input_list_subset_35(v3221, v3219);
    } else {
        v3224 = false;
    }
    if (v3224) {
    } else {
        if (spiral_true) spiralFail("empty derivative step should preserve language");
    }
    const v3225: *UH2 = UH2_RegexEpsilon();
    const v3226: US0 = US0_BitZero();
    const v3227: *UH2 = canonical_derivative_3(v3225, v3226);
    const v3228: US0 = US0_BitZero();
    const v3229: *UH0 = UH0_InputEmpty();
    const v3230: *UH0 = UH0_InputCons(v3228, v3229);
    const v3231: *UH2 = UH2_RegexEpsilon();
    const v3232: US0 = US0_BitZero();
    const v3233: *UH0 = UH0_InputEmpty();
    const v3234: *UH0 = UH0_InputCons(v3232, v3233);
    const v3235: *UH5 = language_remainders_27(v3231, v3234);
    const v3236: *UH5 = input_list_remove_34(v3230, v3235);
    const v3237: *UH0 = UH0_InputEmpty();
    const v3238: *UH5 = language_remainders_27(v3227, v3237);
    const v3239: bool = input_list_subset_35(v3236, v3238);
    if (v3239) {
        v3241 = input_list_subset_35(v3238, v3236);
    } else {
        v3241 = false;
    }
    if (v3241) {
    } else {
        if (spiral_true) spiralFail("epsilon derivative step should preserve language");
    }
    const v3242: US0 = US0_BitZero();
    const v3243: *UH2 = UH2_RegexChar(v3242);
    const v3244: US0 = US0_BitZero();
    const v3245: *UH2 = canonical_derivative_3(v3243, v3244);
    const v3246: US0 = US0_BitZero();
    const v3247: US0 = US0_BitOne();
    const v3248: US0 = US0_BitZero();
    const v3249: *UH0 = UH0_InputEmpty();
    const v3250: *UH0 = UH0_InputCons(v3248, v3249);
    const v3251: *UH0 = UH0_InputCons(v3247, v3250);
    const v3252: *UH0 = UH0_InputCons(v3246, v3251);
    const v3253: US0 = US0_BitZero();
    const v3254: *UH2 = UH2_RegexChar(v3253);
    const v3255: US0 = US0_BitZero();
    const v3256: US0 = US0_BitOne();
    const v3257: US0 = US0_BitZero();
    const v3258: *UH0 = UH0_InputEmpty();
    const v3259: *UH0 = UH0_InputCons(v3257, v3258);
    const v3260: *UH0 = UH0_InputCons(v3256, v3259);
    const v3261: *UH0 = UH0_InputCons(v3255, v3260);
    const v3262: *UH5 = language_remainders_27(v3254, v3261);
    const v3263: *UH5 = input_list_remove_34(v3252, v3262);
    const v3264: US0 = US0_BitOne();
    const v3265: US0 = US0_BitZero();
    const v3266: *UH0 = UH0_InputEmpty();
    const v3267: *UH0 = UH0_InputCons(v3265, v3266);
    const v3268: *UH0 = UH0_InputCons(v3264, v3267);
    const v3269: *UH5 = language_remainders_27(v3245, v3268);
    const v3270: bool = input_list_subset_35(v3263, v3269);
    if (v3270) {
        v3272 = input_list_subset_35(v3269, v3263);
    } else {
        v3272 = false;
    }
    if (v3272) {
    } else {
        if (spiral_true) spiralFail("matching-char derivative step should preserve language");
    }
    const v3273: US0 = US0_BitZero();
    const v3274: *UH2 = UH2_RegexChar(v3273);
    const v3275: US0 = US0_BitOne();
    const v3276: *UH2 = canonical_derivative_3(v3274, v3275);
    const v3277: US0 = US0_BitOne();
    const v3278: US0 = US0_BitOne();
    const v3279: US0 = US0_BitZero();
    const v3280: *UH0 = UH0_InputEmpty();
    const v3281: *UH0 = UH0_InputCons(v3279, v3280);
    const v3282: *UH0 = UH0_InputCons(v3278, v3281);
    const v3283: *UH0 = UH0_InputCons(v3277, v3282);
    const v3284: US0 = US0_BitZero();
    const v3285: *UH2 = UH2_RegexChar(v3284);
    const v3286: US0 = US0_BitOne();
    const v3287: US0 = US0_BitOne();
    const v3288: US0 = US0_BitZero();
    const v3289: *UH0 = UH0_InputEmpty();
    const v3290: *UH0 = UH0_InputCons(v3288, v3289);
    const v3291: *UH0 = UH0_InputCons(v3287, v3290);
    const v3292: *UH0 = UH0_InputCons(v3286, v3291);
    const v3293: *UH5 = language_remainders_27(v3285, v3292);
    const v3294: *UH5 = input_list_remove_34(v3283, v3293);
    const v3295: US0 = US0_BitOne();
    const v3296: US0 = US0_BitZero();
    const v3297: *UH0 = UH0_InputEmpty();
    const v3298: *UH0 = UH0_InputCons(v3296, v3297);
    const v3299: *UH0 = UH0_InputCons(v3295, v3298);
    const v3300: *UH5 = language_remainders_27(v3276, v3299);
    const v3301: bool = input_list_subset_35(v3294, v3300);
    if (v3301) {
        v3303 = input_list_subset_35(v3300, v3294);
    } else {
        v3303 = false;
    }
    if (v3303) {
    } else {
        if (spiral_true) spiralFail("mismatching-char derivative step should preserve language");
    }
    const v3304: US0 = US0_BitZero();
    const v3305: *UH2 = UH2_RegexChar(v3304);
    const v3306: US0 = US0_BitOne();
    const v3307: *UH2 = UH2_RegexChar(v3306);
    const v3308: *UH2 = UH2_RegexAlt(v3305, v3307);
    const v3309: US0 = US0_BitOne();
    const v3310: *UH2 = canonical_derivative_3(v3308, v3309);
    const v3311: US0 = US0_BitOne();
    const v3312: US0 = US0_BitOne();
    const v3313: US0 = US0_BitZero();
    const v3314: *UH0 = UH0_InputEmpty();
    const v3315: *UH0 = UH0_InputCons(v3313, v3314);
    const v3316: *UH0 = UH0_InputCons(v3312, v3315);
    const v3317: *UH0 = UH0_InputCons(v3311, v3316);
    const v3318: US0 = US0_BitZero();
    const v3319: *UH2 = UH2_RegexChar(v3318);
    const v3320: US0 = US0_BitOne();
    const v3321: *UH2 = UH2_RegexChar(v3320);
    const v3322: *UH2 = UH2_RegexAlt(v3319, v3321);
    const v3323: US0 = US0_BitOne();
    const v3324: US0 = US0_BitOne();
    const v3325: US0 = US0_BitZero();
    const v3326: *UH0 = UH0_InputEmpty();
    const v3327: *UH0 = UH0_InputCons(v3325, v3326);
    const v3328: *UH0 = UH0_InputCons(v3324, v3327);
    const v3329: *UH0 = UH0_InputCons(v3323, v3328);
    const v3330: *UH5 = language_remainders_27(v3322, v3329);
    const v3331: *UH5 = input_list_remove_34(v3317, v3330);
    const v3332: US0 = US0_BitOne();
    const v3333: US0 = US0_BitZero();
    const v3334: *UH0 = UH0_InputEmpty();
    const v3335: *UH0 = UH0_InputCons(v3333, v3334);
    const v3336: *UH0 = UH0_InputCons(v3332, v3335);
    const v3337: *UH5 = language_remainders_27(v3310, v3336);
    const v3338: bool = input_list_subset_35(v3331, v3337);
    if (v3338) {
        v3340 = input_list_subset_35(v3337, v3331);
    } else {
        v3340 = false;
    }
    if (v3340) {
    } else {
        if (spiral_true) spiralFail("alternative derivative step should preserve language");
    }
    const v3341: US0 = US0_BitZero();
    const v3342: *UH2 = UH2_RegexChar(v3341);
    const v3343: US0 = US0_BitOne();
    const v3344: *UH2 = UH2_RegexChar(v3343);
    const v3345: *UH2 = UH2_RegexCat(v3342, v3344);
    const v3346: US0 = US0_BitZero();
    const v3347: *UH2 = canonical_derivative_3(v3345, v3346);
    const v3348: US0 = US0_BitZero();
    const v3349: US0 = US0_BitOne();
    const v3350: US0 = US0_BitZero();
    const v3351: *UH0 = UH0_InputEmpty();
    const v3352: *UH0 = UH0_InputCons(v3350, v3351);
    const v3353: *UH0 = UH0_InputCons(v3349, v3352);
    const v3354: *UH0 = UH0_InputCons(v3348, v3353);
    const v3355: US0 = US0_BitZero();
    const v3356: *UH2 = UH2_RegexChar(v3355);
    const v3357: US0 = US0_BitOne();
    const v3358: *UH2 = UH2_RegexChar(v3357);
    const v3359: *UH2 = UH2_RegexCat(v3356, v3358);
    const v3360: US0 = US0_BitZero();
    const v3361: US0 = US0_BitOne();
    const v3362: US0 = US0_BitZero();
    const v3363: *UH0 = UH0_InputEmpty();
    const v3364: *UH0 = UH0_InputCons(v3362, v3363);
    const v3365: *UH0 = UH0_InputCons(v3361, v3364);
    const v3366: *UH0 = UH0_InputCons(v3360, v3365);
    const v3367: *UH5 = language_remainders_27(v3359, v3366);
    const v3368: *UH5 = input_list_remove_34(v3354, v3367);
    const v3369: US0 = US0_BitOne();
    const v3370: US0 = US0_BitZero();
    const v3371: *UH0 = UH0_InputEmpty();
    const v3372: *UH0 = UH0_InputCons(v3370, v3371);
    const v3373: *UH0 = UH0_InputCons(v3369, v3372);
    const v3374: *UH5 = language_remainders_27(v3347, v3373);
    const v3375: bool = input_list_subset_35(v3368, v3374);
    if (v3375) {
        v3377 = input_list_subset_35(v3374, v3368);
    } else {
        v3377 = false;
    }
    if (v3377) {
    } else {
        if (spiral_true) spiralFail("nonnullable concatenation derivative step should preserve language");
    }
    const v3378: *UH2 = UH2_RegexEpsilon();
    const v3379: US0 = US0_BitOne();
    const v3380: *UH2 = UH2_RegexChar(v3379);
    const v3381: *UH2 = UH2_RegexCat(v3378, v3380);
    const v3382: US0 = US0_BitOne();
    const v3383: *UH2 = canonical_derivative_3(v3381, v3382);
    const v3384: US0 = US0_BitOne();
    const v3385: US0 = US0_BitOne();
    const v3386: US0 = US0_BitZero();
    const v3387: *UH0 = UH0_InputEmpty();
    const v3388: *UH0 = UH0_InputCons(v3386, v3387);
    const v3389: *UH0 = UH0_InputCons(v3385, v3388);
    const v3390: *UH0 = UH0_InputCons(v3384, v3389);
    const v3391: *UH2 = UH2_RegexEpsilon();
    const v3392: US0 = US0_BitOne();
    const v3393: *UH2 = UH2_RegexChar(v3392);
    const v3394: *UH2 = UH2_RegexCat(v3391, v3393);
    const v3395: US0 = US0_BitOne();
    const v3396: US0 = US0_BitOne();
    const v3397: US0 = US0_BitZero();
    const v3398: *UH0 = UH0_InputEmpty();
    const v3399: *UH0 = UH0_InputCons(v3397, v3398);
    const v3400: *UH0 = UH0_InputCons(v3396, v3399);
    const v3401: *UH0 = UH0_InputCons(v3395, v3400);
    const v3402: *UH5 = language_remainders_27(v3394, v3401);
    const v3403: *UH5 = input_list_remove_34(v3390, v3402);
    const v3404: US0 = US0_BitOne();
    const v3405: US0 = US0_BitZero();
    const v3406: *UH0 = UH0_InputEmpty();
    const v3407: *UH0 = UH0_InputCons(v3405, v3406);
    const v3408: *UH0 = UH0_InputCons(v3404, v3407);
    const v3409: *UH5 = language_remainders_27(v3383, v3408);
    const v3410: bool = input_list_subset_35(v3403, v3409);
    if (v3410) {
        v3412 = input_list_subset_35(v3409, v3403);
    } else {
        v3412 = false;
    }
    if (v3412) {
    } else {
        if (spiral_true) spiralFail("nullable concatenation derivative step should preserve language");
    }
    const v3413: US0 = US0_BitZero();
    const v3414: *UH2 = UH2_RegexChar(v3413);
    const v3415: *UH2 = UH2_RegexStar(v3414);
    const v3416: US0 = US0_BitZero();
    const v3417: *UH2 = canonical_derivative_3(v3415, v3416);
    const v3418: US0 = US0_BitZero();
    const v3419: US0 = US0_BitOne();
    const v3420: US0 = US0_BitZero();
    const v3421: *UH0 = UH0_InputEmpty();
    const v3422: *UH0 = UH0_InputCons(v3420, v3421);
    const v3423: *UH0 = UH0_InputCons(v3419, v3422);
    const v3424: *UH0 = UH0_InputCons(v3418, v3423);
    const v3425: US0 = US0_BitZero();
    const v3426: *UH2 = UH2_RegexChar(v3425);
    const v3427: *UH2 = UH2_RegexStar(v3426);
    const v3428: US0 = US0_BitZero();
    const v3429: US0 = US0_BitOne();
    const v3430: US0 = US0_BitZero();
    const v3431: *UH0 = UH0_InputEmpty();
    const v3432: *UH0 = UH0_InputCons(v3430, v3431);
    const v3433: *UH0 = UH0_InputCons(v3429, v3432);
    const v3434: *UH0 = UH0_InputCons(v3428, v3433);
    const v3435: *UH5 = language_remainders_27(v3427, v3434);
    const v3436: *UH5 = input_list_remove_34(v3424, v3435);
    const v3437: US0 = US0_BitOne();
    const v3438: US0 = US0_BitZero();
    const v3439: *UH0 = UH0_InputEmpty();
    const v3440: *UH0 = UH0_InputCons(v3438, v3439);
    const v3441: *UH0 = UH0_InputCons(v3437, v3440);
    const v3442: *UH5 = language_remainders_27(v3417, v3441);
    const v3443: bool = input_list_subset_35(v3436, v3442);
    if (v3443) {
        v3445 = input_list_subset_35(v3442, v3436);
    } else {
        v3445 = false;
    }
    if (v3445) {
    } else {
        if (spiral_true) spiralFail("star derivative step should preserve language");
    }
    const v3446: US0 = US0_BitZero();
    const v3447: *UH2 = UH2_RegexChar(v3446);
    const v3448: US0 = US0_BitOne();
    const v3449: *UH2 = UH2_RegexChar(v3448);
    const v3450: *UH2 = UH2_RegexAlt(v3447, v3449);
    const v3451: *UH2 = UH2_RegexStar(v3450);
    const v3452: US0 = US0_BitZero();
    const v3453: *UH2 = UH2_RegexChar(v3452);
    const v3454: *UH2 = UH2_RegexCat(v3451, v3453);
    const v3455: US0 = US0_BitOne();
    const v3456: *UH2 = canonical_derivative_3(v3454, v3455);
    const v3457: US0 = US0_BitOne();
    const v3458: US0 = US0_BitOne();
    const v3459: US0 = US0_BitZero();
    const v3460: *UH0 = UH0_InputEmpty();
    const v3461: *UH0 = UH0_InputCons(v3459, v3460);
    const v3462: *UH0 = UH0_InputCons(v3458, v3461);
    const v3463: *UH0 = UH0_InputCons(v3457, v3462);
    const v3464: US0 = US0_BitZero();
    const v3465: *UH2 = UH2_RegexChar(v3464);
    const v3466: US0 = US0_BitOne();
    const v3467: *UH2 = UH2_RegexChar(v3466);
    const v3468: *UH2 = UH2_RegexAlt(v3465, v3467);
    const v3469: *UH2 = UH2_RegexStar(v3468);
    const v3470: US0 = US0_BitZero();
    const v3471: *UH2 = UH2_RegexChar(v3470);
    const v3472: *UH2 = UH2_RegexCat(v3469, v3471);
    const v3473: US0 = US0_BitOne();
    const v3474: US0 = US0_BitOne();
    const v3475: US0 = US0_BitZero();
    const v3476: *UH0 = UH0_InputEmpty();
    const v3477: *UH0 = UH0_InputCons(v3475, v3476);
    const v3478: *UH0 = UH0_InputCons(v3474, v3477);
    const v3479: *UH0 = UH0_InputCons(v3473, v3478);
    const v3480: *UH5 = language_remainders_27(v3472, v3479);
    const v3481: *UH5 = input_list_remove_34(v3463, v3480);
    const v3482: US0 = US0_BitOne();
    const v3483: US0 = US0_BitZero();
    const v3484: *UH0 = UH0_InputEmpty();
    const v3485: *UH0 = UH0_InputCons(v3483, v3484);
    const v3486: *UH0 = UH0_InputCons(v3482, v3485);
    const v3487: *UH5 = language_remainders_27(v3456, v3486);
    const v3488: bool = input_list_subset_35(v3481, v3487);
    if (v3488) {
        v3490 = input_list_subset_35(v3487, v3481);
    } else {
        v3490 = false;
    }
    if (v3490) {
    } else {
        if (spiral_true) spiralFail("composite one derivative step should preserve language");
    }
    const v3491: US0 = US0_BitZero();
    const v3492: *UH2 = UH2_RegexChar(v3491);
    const v3493: US0 = US0_BitOne();
    const v3494: *UH2 = UH2_RegexChar(v3493);
    const v3495: *UH2 = UH2_RegexAlt(v3492, v3494);
    const v3496: *UH2 = UH2_RegexStar(v3495);
    const v3497: US0 = US0_BitZero();
    const v3498: *UH2 = UH2_RegexChar(v3497);
    const v3499: *UH2 = UH2_RegexCat(v3496, v3498);
    const v3500: US0 = US0_BitZero();
    const v3501: *UH2 = canonical_derivative_3(v3499, v3500);
    const v3502: US0 = US0_BitZero();
    const v3503: US0 = US0_BitOne();
    const v3504: US0 = US0_BitZero();
    const v3505: *UH0 = UH0_InputEmpty();
    const v3506: *UH0 = UH0_InputCons(v3504, v3505);
    const v3507: *UH0 = UH0_InputCons(v3503, v3506);
    const v3508: *UH0 = UH0_InputCons(v3502, v3507);
    const v3509: US0 = US0_BitZero();
    const v3510: *UH2 = UH2_RegexChar(v3509);
    const v3511: US0 = US0_BitOne();
    const v3512: *UH2 = UH2_RegexChar(v3511);
    const v3513: *UH2 = UH2_RegexAlt(v3510, v3512);
    const v3514: *UH2 = UH2_RegexStar(v3513);
    const v3515: US0 = US0_BitZero();
    const v3516: *UH2 = UH2_RegexChar(v3515);
    const v3517: *UH2 = UH2_RegexCat(v3514, v3516);
    const v3518: US0 = US0_BitZero();
    const v3519: US0 = US0_BitOne();
    const v3520: US0 = US0_BitZero();
    const v3521: *UH0 = UH0_InputEmpty();
    const v3522: *UH0 = UH0_InputCons(v3520, v3521);
    const v3523: *UH0 = UH0_InputCons(v3519, v3522);
    const v3524: *UH0 = UH0_InputCons(v3518, v3523);
    const v3525: *UH5 = language_remainders_27(v3517, v3524);
    const v3526: *UH5 = input_list_remove_34(v3508, v3525);
    const v3527: US0 = US0_BitOne();
    const v3528: US0 = US0_BitZero();
    const v3529: *UH0 = UH0_InputEmpty();
    const v3530: *UH0 = UH0_InputCons(v3528, v3529);
    const v3531: *UH0 = UH0_InputCons(v3527, v3530);
    const v3532: *UH5 = language_remainders_27(v3501, v3531);
    const v3533: bool = input_list_subset_35(v3526, v3532);
    if (v3533) {
        v3535 = input_list_subset_35(v3532, v3526);
    } else {
        v3535 = false;
    }
    if (v3535) {
    } else {
        if (spiral_true) spiralFail("composite zero derivative step should preserve language");
    }
    const v3536: US1 = US1_TriA();
    const v3537: *UH3 = UH3_RegexChar(v3536);
    const v3538: *UH3 = UH3_RegexStar(v3537);
    const v3539: US1 = US1_TriA();
    const v3540: *UH3 = canonical_derivative_13(v3538, v3539);
    const v3541: US1 = US1_TriA();
    const v3542: US1 = US1_TriA();
    const v3543: US1 = US1_TriA();
    const v3544: *UH1 = UH1_InputEmpty();
    const v3545: *UH1 = UH1_InputCons(v3543, v3544);
    const v3546: *UH1 = UH1_InputCons(v3542, v3545);
    const v3547: *UH1 = UH1_InputCons(v3541, v3546);
    const v3548: US1 = US1_TriA();
    const v3549: *UH3 = UH3_RegexChar(v3548);
    const v3550: *UH3 = UH3_RegexStar(v3549);
    const v3551: US1 = US1_TriA();
    const v3552: US1 = US1_TriA();
    const v3553: US1 = US1_TriA();
    const v3554: *UH1 = UH1_InputEmpty();
    const v3555: *UH1 = UH1_InputCons(v3553, v3554);
    const v3556: *UH1 = UH1_InputCons(v3552, v3555);
    const v3557: *UH1 = UH1_InputCons(v3551, v3556);
    const v3558: *UH7 = language_remainders_41(v3550, v3557);
    const v3559: *UH7 = input_list_remove_48(v3547, v3558);
    const v3560: US1 = US1_TriA();
    const v3561: US1 = US1_TriA();
    const v3562: *UH1 = UH1_InputEmpty();
    const v3563: *UH1 = UH1_InputCons(v3561, v3562);
    const v3564: *UH1 = UH1_InputCons(v3560, v3563);
    const v3565: *UH7 = language_remainders_41(v3540, v3564);
    const v3566: bool = input_list_subset_49(v3559, v3565);
    if (v3566) {
        v3568 = input_list_subset_49(v3565, v3559);
    } else {
        v3568 = false;
    }
    if (v3568) {
    } else {
        if (spiral_true) spiralFail("ternary derivative step should preserve language");
    }
    const v3569: US0 = US0_BitZero();
    const v3570: *UH2 = UH2_RegexChar(v3569);
    const v3571: *UH2 = UH2_RegexStar(v3570);
    const v3572: US0 = US0_BitOne();
    const v3573: *UH2 = UH2_RegexChar(v3572);
    const v3574: *UH2 = UH2_RegexCat(v3571, v3573);
    const v3575: US0 = US0_BitZero();
    const v3576: *UH2 = canonical_derivative_3(v3574, v3575);
    const v3577: US0 = US0_BitZero();
    const v3578: US0 = US0_BitOne();
    const v3579: US0 = US0_BitZero();
    const v3580: *UH0 = UH0_InputEmpty();
    const v3581: *UH0 = UH0_InputCons(v3579, v3580);
    const v3582: *UH0 = UH0_InputCons(v3578, v3581);
    const v3583: *UH0 = UH0_InputCons(v3577, v3582);
    const v3584: US0 = US0_BitZero();
    const v3585: *UH2 = UH2_RegexChar(v3584);
    const v3586: *UH2 = UH2_RegexStar(v3585);
    const v3587: US0 = US0_BitOne();
    const v3588: *UH2 = UH2_RegexChar(v3587);
    const v3589: *UH2 = UH2_RegexCat(v3586, v3588);
    const v3590: US0 = US0_BitZero();
    const v3591: US0 = US0_BitOne();
    const v3592: US0 = US0_BitZero();
    const v3593: *UH0 = UH0_InputEmpty();
    const v3594: *UH0 = UH0_InputCons(v3592, v3593);
    const v3595: *UH0 = UH0_InputCons(v3591, v3594);
    const v3596: *UH0 = UH0_InputCons(v3590, v3595);
    const v3597: *UH5 = language_remainders_27(v3589, v3596);
    const v3598: *UH5 = input_list_remove_34(v3583, v3597);
    const v3599: US0 = US0_BitOne();
    const v3600: US0 = US0_BitZero();
    const v3601: *UH0 = UH0_InputEmpty();
    const v3602: *UH0 = UH0_InputCons(v3600, v3601);
    const v3603: *UH0 = UH0_InputCons(v3599, v3602);
    const v3604: *UH5 = language_remainders_27(v3576, v3603);
    const v3605: bool = input_list_subset_35(v3598, v3604);
    if (v3605) {
        v3607 = input_list_subset_35(v3604, v3598);
    } else {
        v3607 = false;
    }
    if (v3607) {
    } else {
        if (spiral_true) spiralFail("star-concatenation derivative step should preserve language");
    }
    const v3608: []const u8 = "inventory-indexed-model-green";
    return v3608;
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
