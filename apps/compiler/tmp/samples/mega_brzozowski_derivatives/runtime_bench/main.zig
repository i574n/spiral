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
const US1 = struct { tag: i32 };
const US2 = struct { tag: i32 };
const UH2 = struct { tag: i32, c1_0: *UH0 = undefined, c1_1: *UH2 = undefined };
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
fn random_bit_input_1(p0: u64, p1: i32, p2: *UH1) Tuple0 {
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
fn US1_SymbolLess() US1 {
    return US1{ .tag = 0 };
}
fn US1_SymbolSame() US1 {
    return US1{ .tag = 1 };
}
fn US1_SymbolGreater() US1 {
    return US1{ .tag = 2 };
}
fn regex_compare_7(p0: *UH0, p1: *UH0) US1 {
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
fn alt_insert_sorted_6(p0: *UH0, p1: *UH0) *UH0 {
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
            v4 = regex_compare_7(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_6(v0, v3);
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
            v11 = regex_compare_7(v0, v1);
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
fn make_alt_5(p0: *UH0, p1: *UH0) *UH0 {
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
fn regex_equal_9(p0: *UH0, p1: *UH0) bool {
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
fn make_cat_8(p0: *UH0, p1: *UH0) *UH0 {
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
                                            v14 = make_cat_8(v13, v1);
                                            return UH0_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_9(v4, v5);
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
fn make_star_10(p0: *UH0) *UH0 {
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
fn normalize_4(p0: *UH0) *UH0 {
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
            v16 = normalize_4(v15);
            return make_star_10(v16);
        },
        else => unreachable,
    }
}
fn US2_Nullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_NonNullable() US2 {
    return US2{ .tag = 1 };
}
fn nullable_12(p0: *UH0) US2 {
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
            v7 = nullable_12(v5);
            v8 = nullable_12(v6);
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
            v18 = nullable_12(v16);
            v19 = nullable_12(v17);
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
fn derivative_11(p0: *UH0, p1: US0) *UH0 {
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
            v21 = derivative_11(v19, v1);
            v22 = derivative_11(v20, v1);
            return make_alt_5(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_12(v24);
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
            v36 = derivative_11(v35, v1);
            v37 = make_star_10(v35);
            return make_cat_8(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_3(p0: *UH0, p1: US0) *UH0 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH0 = normalize_4(v0);
    const v3: *UH0 = derivative_11(v2, v1);
    return normalize_4(v3);
}
fn accepts_2(p0: *UH0, p1: *UH1) bool {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH0 = undefined; _ = &v8;
    var v2: *UH0 = undefined; _ = &v2;
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
                v3 = nullable_12(v2);
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
fn loop_0(p0: *UH0, p1: i32, p2: i32, p3: u64, p4: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: i32 = undefined; _ = &v12;
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_InputEmpty();
            tmp4 = random_bit_input_1(v3, v1, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = accepts_2(v0, v7);
            if (v9) {
                v10 = v4 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v4;
            }
            v12 = v2 -% @as(i32, 1);
            v2 = v12;
            v3 = v8;
            v4 = v11;
            continue;
        } else {
            return v4;
        }
    }
}
fn zeros_input_14(p0: i32, p1: *UH1) *UH1 {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: bool = undefined; _ = &v2;
    var v3: i32 = undefined; _ = &v3;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    while (true) {
        v2 = @as(i32, 0) < v0;
        if (v2) {
            v3 = v0 -% @as(i32, 1);
            v4 = US0_BitZero();
            v5 = UH1_InputCons(v4, v1);
            v0 = v3;
            v1 = v5;
            continue;
        } else {
            return v1;
        }
    }
}
fn loop_13(p0: *UH0, p1: i32, p2: i32, p3: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v8: i32 = undefined; _ = &v8;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: i32 = undefined; _ = &v16;
    var v15: i32 = undefined; _ = &v15;
    var v17: i32 = undefined; _ = &v17;
    while (true) {
        v4 = v1 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_InputEmpty();
            v6 = zeros_input_14(v2, v5);
            v7 = accepts_2(v0, v6);
            if (v7) {
                v8 = v3 +% @as(i32, 1);
                v9 = v8;
            } else {
                v9 = v3;
            }
            v10 = US0_BitOne();
            v11 = UH1_InputEmpty();
            v12 = UH1_InputCons(v10, v11);
            v13 = zeros_input_14(v2, v12);
            v14 = accepts_2(v0, v13);
            if (v14) {
                v15 = v9 +% @as(i32, 1);
                v16 = v15;
            } else {
                v16 = v9;
            }
            v17 = v2 +% @as(i32, 1);
            v2 = v17;
            v3 = v16;
            continue;
        }
    }
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
fn backtrack_stack_16(p0: *UH2, p1: *UH1) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v6: *UH0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v27: *UH0 = undefined; _ = &v27;
    var v28: *UH0 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v31: *UH2 = undefined; _ = &v31;
    var v34: *UH0 = undefined; _ = &v34;
    var v35: *UH0 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    var v9: US0 = undefined; _ = &v9;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v21: US1 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v39: *UH0 = undefined; _ = &v39;
    var v40: *UH2 = undefined; _ = &v40;
    var v41: bool = undefined; _ = &v41;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    while (true) {
        switch (v0.tag) {
            1 => {
                v6 = v0.c1_0;
                v7 = v0.c1_1;
                switch (v6.tag) {
                    3 => {
                        v27 = v6.c3_0;
                        v28 = v6.c3_1;
                        v29 = UH2_RegexListCons(v27, v7);
                        v30 = backtrack_stack_16(v29, v1);
                        if (v30) {
                            return true;
                        } else {
                            v31 = UH2_RegexListCons(v28, v7);
                            v0 = v31;
                            continue;
                        }
                    },
                    4 => {
                        v34 = v6.c4_0;
                        v35 = v6.c4_1;
                        v36 = UH2_RegexListCons(v35, v7);
                        v37 = UH2_RegexListCons(v34, v36);
                        v0 = v37;
                        continue;
                    },
                    2 => {
                        v9 = v6.c2_0;
                        switch (v1.tag) {
                            1 => {
                                v10 = v1.c1_0;
                                v11 = v1.c1_1;
                                switch (v9.tag) {
                                    1 => {
                                        switch (v10.tag) {
                                            1 => {
                                                v21 = US1_SymbolSame();
                                            },
                                            0 => {
                                                v21 = US1_SymbolGreater();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    0 => {
                                        switch (v10.tag) {
                                            1 => {
                                                v21 = US1_SymbolLess();
                                            },
                                            0 => {
                                                v21 = US1_SymbolSame();
                                            },
                                            else => unreachable,
                                        }
                                    },
                                    else => unreachable,
                                }
                                switch (v21.tag) {
                                    1 => {
                                        v22 = true;
                                    },
                                    else => {
                                        v22 = false;
                                    },
                                }
                                if (v22) {
                                    v0 = v7;
                                    v1 = v11;
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
                        return false;
                    },
                    1 => {
                        v0 = v7;
                        continue;
                    },
                    5 => {
                        v39 = v6.c5_0;
                        v40 = UH2_RegexListCons(v39, v0);
                        v41 = backtrack_stack_16(v40, v1);
                        if (v41) {
                            return true;
                        } else {
                            v0 = v7;
                            continue;
                        }
                    },
                    else => unreachable,
                }
            },
            0 => {
                switch (v1.tag) {
                    1 => {
                        v2 = v1.c1_0;
                        v3 = v1.c1_1;
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
fn loop_15(p0: *UH0, p1: i32, p2: i32, p3: u64, p4: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: u64 = p3; _ = &v3;
    var v4: i32 = p4; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: u64 = undefined; _ = &v8;
    var tmp4: Tuple0 = undefined; _ = &tmp4;
    var v9: *UH2 = undefined; _ = &v9;
    var v10: *UH2 = undefined; _ = &v10;
    var v11: bool = undefined; _ = &v11;
    var v13: i32 = undefined; _ = &v13;
    var v12: i32 = undefined; _ = &v12;
    var v14: i32 = undefined; _ = &v14;
    while (true) {
        v5 = @as(i32, 0) < v2;
        if (v5) {
            v6 = UH1_InputEmpty();
            tmp4 = random_bit_input_1(v3, v1, v6);
            v7 = tmp4.f0;
            v8 = tmp4.f1;
            v9 = UH2_RegexListNil();
            v10 = UH2_RegexListCons(v0, v9);
            v11 = backtrack_stack_16(v10, v7);
            if (v11) {
                v12 = v4 +% @as(i32, 1);
                v13 = v12;
            } else {
                v13 = v4;
            }
            v14 = v2 -% @as(i32, 1);
            v2 = v14;
            v3 = v8;
            v4 = v13;
            continue;
        } else {
            return v4;
        }
    }
}
fn loop_17(p0: *UH0, p1: i32, p2: i32, p3: i32) i32 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v9: bool = undefined; _ = &v9;
    var v11: i32 = undefined; _ = &v11;
    var v10: i32 = undefined; _ = &v10;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: *UH1 = undefined; _ = &v14;
    var v15: *UH1 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: bool = undefined; _ = &v18;
    var v20: i32 = undefined; _ = &v20;
    var v19: i32 = undefined; _ = &v19;
    var v21: i32 = undefined; _ = &v21;
    while (true) {
        v4 = v1 < v2;
        if (v4) {
            return v3;
        } else {
            v5 = UH1_InputEmpty();
            v6 = zeros_input_14(v2, v5);
            v7 = UH2_RegexListNil();
            v8 = UH2_RegexListCons(v0, v7);
            v9 = backtrack_stack_16(v8, v6);
            if (v9) {
                v10 = v3 +% @as(i32, 1);
                v11 = v10;
            } else {
                v11 = v3;
            }
            v12 = US0_BitOne();
            v13 = UH1_InputEmpty();
            v14 = UH1_InputCons(v12, v13);
            v15 = zeros_input_14(v2, v14);
            v16 = UH2_RegexListNil();
            v17 = UH2_RegexListCons(v0, v16);
            v18 = backtrack_stack_16(v17, v15);
            if (v18) {
                v19 = v11 +% @as(i32, 1);
                v20 = v19;
            } else {
                v20 = v11;
            }
            v21 = v2 +% @as(i32, 1);
            v2 = v21;
            v3 = v20;
            continue;
        }
    }
}
fn run_19(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
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
fn loop_18(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
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
            v5 = UH1_InputEmpty();
            tmp4 = random_bit_input_1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = run_19(v8, v6);
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
fn run_21(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
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
fn loop_20(p0: i32, p1: i32, p2: u64, p3: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: u64 = p2; _ = &v2;
    var v3: i32 = p3; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
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
            v5 = UH1_InputEmpty();
            tmp4 = random_bit_input_1(v2, v0, v5);
            v6 = tmp4.f0;
            v7 = tmp4.f1;
            v8 = @as(i32, 0);
            v9 = run_21(v8, v6);
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
fn run_23(p0: i32, p1: *UH1) bool {
    var v0: i32 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v13: bool = undefined; _ = &v13;
    var v19: i32 = undefined; _ = &v19;
    var v14: bool = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v5: bool = undefined; _ = &v5;
    var v11: i32 = undefined; _ = &v11;
    var v6: bool = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v2: bool = undefined; _ = &v2;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                switch (v3.tag) {
                    1 => {
                        v13 = v0 == @as(i32, 0);
                        if (v13) {
                            v19 = @as(i32, 3);
                        } else {
                            v14 = v0 == @as(i32, 1);
                            if (v14) {
                                v19 = @as(i32, 3);
                            } else {
                                v15 = v0 == @as(i32, 2);
                                if (v15) {
                                    v19 = @as(i32, 3);
                                } else {
                                    v19 = @as(i32, 4);
                                }
                            }
                        }
                        v0 = v19;
                        v1 = v4;
                        continue;
                    },
                    0 => {
                        v5 = v0 == @as(i32, 0);
                        if (v5) {
                            v11 = @as(i32, 1);
                        } else {
                            v6 = v0 == @as(i32, 1);
                            if (v6) {
                                v11 = @as(i32, 2);
                            } else {
                                v7 = v0 == @as(i32, 2);
                                if (v7) {
                                    v11 = @as(i32, 2);
                                } else {
                                    v11 = @as(i32, 4);
                                }
                            }
                        }
                        v0 = v11;
                        v1 = v4;
                        continue;
                    },
                    else => unreachable,
                }
            },
            0 => {
                v2 = v0 == @as(i32, 3);
                return v2;
            },
            else => unreachable,
        }
    }
}
fn loop_22(p0: i32, p1: i32, p2: i32) i32 {
    var v0: i32 = p0; _ = &v0;
    var v1: i32 = p1; _ = &v1;
    var v2: i32 = p2; _ = &v2;
    var v3: bool = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: i32 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v9: i32 = undefined; _ = &v9;
    var v8: i32 = undefined; _ = &v8;
    var v10: US0 = undefined; _ = &v10;
    var v11: *UH1 = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: i32 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v17: i32 = undefined; _ = &v17;
    var v16: i32 = undefined; _ = &v16;
    var v18: i32 = undefined; _ = &v18;
    while (true) {
        v3 = v0 < v1;
        if (v3) {
            return v2;
        } else {
            v4 = UH1_InputEmpty();
            v5 = zeros_input_14(v1, v4);
            v6 = @as(i32, 0);
            v7 = run_23(v6, v5);
            if (v7) {
                v8 = v2 +% @as(i32, 1);
                v9 = v8;
            } else {
                v9 = v2;
            }
            v10 = US0_BitOne();
            v11 = UH1_InputEmpty();
            v12 = UH1_InputCons(v10, v11);
            v13 = zeros_input_14(v1, v12);
            v14 = @as(i32, 0);
            v15 = run_23(v14, v13);
            if (v15) {
                v16 = v9 +% @as(i32, 1);
                v17 = v16;
            } else {
                v17 = v9;
            }
            v18 = v1 +% @as(i32, 1);
            v1 = v18;
            v2 = v17;
            continue;
        }
    }
}
fn loop_24(p0: []i32, p1: i32) void {
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
fn loop_25(p0: []i32, p1: i32) void {
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
fn probe_27(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: i32) i32 {
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
fn interned_node_26(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32) i32 {
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
    return probe_27(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v14);
}
fn interned_alt_insert_30(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
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
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v14, v7, v8);
            } else {
                v16 = v7 == v12;
                if (v16) {
                    return v8;
                } else {
                    v17 = @as(i32, 3);
                    v18 = v2[spiralIndex(v2.len, v8)];
                    v19 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v18);
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v17, v12, v19);
                }
            }
        } else {
            v23 = v7 < v8;
            if (v23) {
                v24 = @as(i32, 3);
                return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v24, v7, v8);
            } else {
                v26 = v7 == v8;
                if (v26) {
                    return v8;
                } else {
                    v27 = @as(i32, 3);
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v27, v8, v7);
                }
            }
        }
    }
}
fn interned_make_alt_29(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
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
                v14 = interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v13, v8);
                v7 = v12;
                v8 = v14;
                continue;
            } else {
                return interned_alt_insert_30(v0, v1, v2, v3, v4, v5, v6, v7, v8);
            }
        }
    }
}
fn interned_make_cat_31(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
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
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v21, v7, v8);
                        }
                    } else {
                        v24 = v0[spiralIndex(v0.len, v7)];
                        v25 = v24 == @as(i32, 4);
                        if (v25) {
                            v26 = @as(i32, 4);
                            v27 = v1[spiralIndex(v1.len, v7)];
                            v28 = v2[spiralIndex(v2.len, v7)];
                            v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v8);
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v26, v27, v29);
                        } else {
                            v31 = @as(i32, 4);
                            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v31, v7, v8);
                        }
                    }
                }
            }
        }
    }
}
fn interned_of_regex_raw_28(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: *UH0) i32 {
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
            v16 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v14);
            v17 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v15);
            return interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v16, v17);
        },
        4 => {
            v19 = v7.c4_0;
            v20 = v7.c4_1;
            v21 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v19);
            v22 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v20);
            return interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v21, v22);
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
            return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v9, v11, v12);
        },
        0 => {
            return @as(i32, 0);
        },
        1 => {
            return @as(i32, 1);
        },
        5 => {
            v24 = v7.c5_0;
            v25 = interned_of_regex_raw_28(v0, v1, v2, v3, v4, v5, v6, v24);
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
                    return interned_node_26(v0, v1, v2, v3, v4, v5, v6, v29, v25, v30);
                }
            }
        },
        else => unreachable,
    }
}
fn interned_derivative_raw_35(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32) i32 {
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
                    v21 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v20, v8);
                    v22 = v2[spiralIndex(v2.len, v7)];
                    v23 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v22, v8);
                    v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v21, v23);
                } else {
                    v25 = v13 == @as(i32, 4);
                    if (v25) {
                        v26 = v1[spiralIndex(v1.len, v7)];
                        v27 = v2[spiralIndex(v2.len, v7)];
                        v28 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v26, v8);
                        v29 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v28, v27);
                        v30 = v3[spiralIndex(v3.len, v26)];
                        v31 = v30 == @as(i32, 1);
                        if (v31) {
                            v32 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v27, v8);
                            v41 = interned_make_alt_29(v0, v1, v2, v3, v4, v5, v6, v29, v32);
                        } else {
                            v41 = v29;
                        }
                    } else {
                        v35 = v1[spiralIndex(v1.len, v7)];
                        v36 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v35, v8);
                        v41 = interned_make_cat_31(v0, v1, v2, v3, v4, v5, v6, v36, v7);
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
fn loop_34(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
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
                    v16 = interned_derivative_raw_35(v0, v1, v2, v3, v4, v5, v6, v7, v15);
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
fn interned_accepts_33(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: *UH1) bool {
    var v0: []i32 = p0; _ = &v0;
    var v1: []i32 = p1; _ = &v1;
    var v2: []i32 = p2; _ = &v2;
    var v3: []i32 = p3; _ = &v3;
    var v4: []i32 = p4; _ = &v4;
    var v5: []i32 = p5; _ = &v5;
    var v6: []i32 = p6; _ = &v6;
    var v7: i32 = p7; _ = &v7;
    var v8: *UH1 = p8; _ = &v8;
    return loop_34(v0, v1, v2, v3, v4, v5, v6, v7, v8);
}
fn loop_32(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: u64, p11: i32) i32 {
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
            tmp4 = random_bit_input_1(v10, v7, v13);
            v14 = tmp4.f0;
            v15 = tmp4.f1;
            v16 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v14);
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
fn loop_36(p0: []i32, p1: []i32, p2: []i32, p3: []i32, p4: []i32, p5: []i32, p6: []i32, p7: i32, p8: i32, p9: i32, p10: i32) i32 {
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
    var v11: bool = undefined; _ = &v11;
    var v12: *UH1 = undefined; _ = &v12;
    var v13: *UH1 = undefined; _ = &v13;
    var v14: bool = undefined; _ = &v14;
    var v16: i32 = undefined; _ = &v16;
    var v15: i32 = undefined; _ = &v15;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH1 = undefined; _ = &v18;
    var v19: *UH1 = undefined; _ = &v19;
    var v20: *UH1 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v23: i32 = undefined; _ = &v23;
    var v22: i32 = undefined; _ = &v22;
    var v24: i32 = undefined; _ = &v24;
    while (true) {
        v11 = v7 < v9;
        if (v11) {
            return v10;
        } else {
            v12 = UH1_InputEmpty();
            v13 = zeros_input_14(v9, v12);
            v14 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v13);
            if (v14) {
                v15 = v10 +% @as(i32, 1);
                v16 = v15;
            } else {
                v16 = v10;
            }
            v17 = US0_BitOne();
            v18 = UH1_InputEmpty();
            v19 = UH1_InputCons(v17, v18);
            v20 = zeros_input_14(v9, v19);
            v21 = interned_accepts_33(v0, v1, v2, v3, v4, v5, v6, v8, v20);
            if (v21) {
                v22 = v16 +% @as(i32, 1);
                v23 = v22;
            } else {
                v23 = v16;
            }
            v24 = v9 +% @as(i32, 1);
            v9 = v24;
            v10 = v23;
            continue;
        }
    }
}
fn spiralMain() i32 {
    var v118: bool = undefined; _ = &v118;
    var v117: bool = undefined; _ = &v117;
    var v120: bool = undefined; _ = &v120;
    var v119: bool = undefined; _ = &v119;
    var v133: bool = undefined; _ = &v133;
    var v132: bool = undefined; _ = &v132;
    var v135: bool = undefined; _ = &v135;
    var v134: bool = undefined; _ = &v134;
    var v158: bool = undefined; _ = &v158;
    var v157: bool = undefined; _ = &v157;
    var v166: []i32 = undefined; _ = &v166;
    var v167: []i32 = undefined; _ = &v167;
    var v168: []i32 = undefined; _ = &v168;
    var v169: []i32 = undefined; _ = &v169;
    var v170: []i32 = undefined; _ = &v170;
    var v171: []i32 = undefined; _ = &v171;
    var v172: []i32 = undefined; _ = &v172;
    var v238: bool = undefined; _ = &v238;
    var v237: bool = undefined; _ = &v237;
    var v246: []i32 = undefined; _ = &v246;
    var v247: []i32 = undefined; _ = &v247;
    var v248: []i32 = undefined; _ = &v248;
    var v249: []i32 = undefined; _ = &v249;
    var v250: []i32 = undefined; _ = &v250;
    var v251: []i32 = undefined; _ = &v251;
    var v252: []i32 = undefined; _ = &v252;
    var v271: bool = undefined; _ = &v271;
    var v270: bool = undefined; _ = &v270;
    var v273: bool = undefined; _ = &v273;
    var v272: bool = undefined; _ = &v272;
    const v0: i32 = @as(i32, 200);
    const v1: i32 = @as(i32, 32);
    const v2: US0 = US0_BitZero();
    const v3: *UH0 = UH0_RegexChar(v2);
    const v4: US0 = US0_BitOne();
    const v5: *UH0 = UH0_RegexChar(v4);
    const v6: *UH0 = UH0_RegexAlt(v3, v5);
    const v7: *UH0 = UH0_RegexStar(v6);
    const v8: US0 = US0_BitZero();
    const v9: *UH0 = UH0_RegexChar(v8);
    const v10: *UH0 = UH0_RegexCat(v7, v9);
    const v11: US0 = US0_BitZero();
    const v12: *UH0 = UH0_RegexChar(v11);
    const v13: US0 = US0_BitOne();
    const v14: *UH0 = UH0_RegexChar(v13);
    const v15: *UH0 = UH0_RegexAlt(v12, v14);
    const v16: *UH0 = UH0_RegexStar(v15);
    const v17: US0 = US0_BitOne();
    const v18: *UH0 = UH0_RegexChar(v17);
    const v19: US0 = US0_BitZero();
    const v20: *UH0 = UH0_RegexChar(v19);
    const v21: US0 = US0_BitOne();
    const v22: *UH0 = UH0_RegexChar(v21);
    const v23: *UH0 = UH0_RegexAlt(v20, v22);
    const v24: US0 = US0_BitZero();
    const v25: *UH0 = UH0_RegexChar(v24);
    const v26: US0 = US0_BitOne();
    const v27: *UH0 = UH0_RegexChar(v26);
    const v28: *UH0 = UH0_RegexAlt(v25, v27);
    const v29: US0 = US0_BitZero();
    const v30: *UH0 = UH0_RegexChar(v29);
    const v31: US0 = US0_BitOne();
    const v32: *UH0 = UH0_RegexChar(v31);
    const v33: *UH0 = UH0_RegexAlt(v30, v32);
    const v34: *UH0 = UH0_RegexCat(v28, v33);
    const v35: *UH0 = UH0_RegexCat(v23, v34);
    const v36: *UH0 = UH0_RegexCat(v18, v35);
    const v37: *UH0 = UH0_RegexCat(v16, v36);
    const v38: u64 = @as(u64, 1);
    const v39: i32 = @as(i32, 0);
    const v40: i32 = loop_0(v10, v1, v0, v38, v39);
    const v41: i32 = loop_0(v37, v1, v0, v38, v39);
    const v42: i32 = @as(i32, 16);
    const v43: US0 = US0_BitZero();
    const v44: *UH0 = UH0_RegexChar(v43);
    const v45: US0 = US0_BitZero();
    const v46: *UH0 = UH0_RegexChar(v45);
    const v47: US0 = US0_BitZero();
    const v48: *UH0 = UH0_RegexChar(v47);
    const v49: *UH0 = UH0_RegexCat(v46, v48);
    const v50: *UH0 = UH0_RegexAlt(v44, v49);
    const v51: *UH0 = UH0_RegexStar(v50);
    const v52: US0 = US0_BitOne();
    const v53: *UH0 = UH0_RegexChar(v52);
    const v54: *UH0 = UH0_RegexCat(v51, v53);
    const v55: i32 = @as(i32, 0);
    const v56: i32 = @as(i32, 1);
    const v57: i32 = loop_13(v54, v42, v56, v55);
    const v58: i32 = @as(i32, 200);
    const v59: i32 = @as(i32, 32);
    const v60: US0 = US0_BitZero();
    const v61: *UH0 = UH0_RegexChar(v60);
    const v62: US0 = US0_BitOne();
    const v63: *UH0 = UH0_RegexChar(v62);
    const v64: *UH0 = UH0_RegexAlt(v61, v63);
    const v65: *UH0 = UH0_RegexStar(v64);
    const v66: US0 = US0_BitZero();
    const v67: *UH0 = UH0_RegexChar(v66);
    const v68: *UH0 = UH0_RegexCat(v65, v67);
    const v69: US0 = US0_BitZero();
    const v70: *UH0 = UH0_RegexChar(v69);
    const v71: US0 = US0_BitOne();
    const v72: *UH0 = UH0_RegexChar(v71);
    const v73: *UH0 = UH0_RegexAlt(v70, v72);
    const v74: *UH0 = UH0_RegexStar(v73);
    const v75: US0 = US0_BitOne();
    const v76: *UH0 = UH0_RegexChar(v75);
    const v77: US0 = US0_BitZero();
    const v78: *UH0 = UH0_RegexChar(v77);
    const v79: US0 = US0_BitOne();
    const v80: *UH0 = UH0_RegexChar(v79);
    const v81: *UH0 = UH0_RegexAlt(v78, v80);
    const v82: US0 = US0_BitZero();
    const v83: *UH0 = UH0_RegexChar(v82);
    const v84: US0 = US0_BitOne();
    const v85: *UH0 = UH0_RegexChar(v84);
    const v86: *UH0 = UH0_RegexAlt(v83, v85);
    const v87: US0 = US0_BitZero();
    const v88: *UH0 = UH0_RegexChar(v87);
    const v89: US0 = US0_BitOne();
    const v90: *UH0 = UH0_RegexChar(v89);
    const v91: *UH0 = UH0_RegexAlt(v88, v90);
    const v92: *UH0 = UH0_RegexCat(v86, v91);
    const v93: *UH0 = UH0_RegexCat(v81, v92);
    const v94: *UH0 = UH0_RegexCat(v76, v93);
    const v95: *UH0 = UH0_RegexCat(v74, v94);
    const v96: u64 = @as(u64, 1);
    const v97: i32 = @as(i32, 0);
    const v98: i32 = loop_15(v68, v59, v58, v96, v97);
    const v99: i32 = loop_15(v95, v59, v58, v96, v97);
    const v100: i32 = @as(i32, 16);
    const v101: US0 = US0_BitZero();
    const v102: *UH0 = UH0_RegexChar(v101);
    const v103: US0 = US0_BitZero();
    const v104: *UH0 = UH0_RegexChar(v103);
    const v105: US0 = US0_BitZero();
    const v106: *UH0 = UH0_RegexChar(v105);
    const v107: *UH0 = UH0_RegexCat(v104, v106);
    const v108: *UH0 = UH0_RegexAlt(v102, v107);
    const v109: *UH0 = UH0_RegexStar(v108);
    const v110: US0 = US0_BitOne();
    const v111: *UH0 = UH0_RegexChar(v110);
    const v112: *UH0 = UH0_RegexCat(v109, v111);
    const v113: i32 = @as(i32, 0);
    const v114: i32 = @as(i32, 1);
    const v115: i32 = loop_17(v112, v100, v114, v113);
    const v116: bool = v40 == v98;
    if (v116) {
        v117 = v41 == v99;
        v118 = v117;
    } else {
        v118 = false;
    }
    if (v118) {
        v119 = v57 == v115;
        v120 = v119;
    } else {
        v120 = false;
    }
    if (v120) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    const v121: i32 = @as(i32, 200);
    const v122: i32 = @as(i32, 32);
    const v123: u64 = @as(u64, 1);
    const v124: i32 = @as(i32, 0);
    const v125: i32 = loop_18(v122, v121, v123, v124);
    const v126: i32 = loop_20(v122, v121, v123, v124);
    const v127: i32 = @as(i32, 16);
    const v128: i32 = @as(i32, 0);
    const v129: i32 = @as(i32, 1);
    const v130: i32 = loop_22(v127, v129, v128);
    const v131: bool = v40 == v125;
    if (v131) {
        v132 = v41 == v126;
        v133 = v132;
    } else {
        v133 = false;
    }
    if (v133) {
        v134 = v57 == v130;
        v135 = v134;
    } else {
        v135 = false;
    }
    if (v135) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    const v136: i32 = @as(i32, 200);
    const v137: i32 = @as(i32, 32);
    const v138: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v139: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v140: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v141: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v142: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v143: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v144: []i32 = spiralNewArray(i32, @as(i32, 1));
    const v145: i32 = @as(i32, 0);
    _ = loop_24(v142, v145);
    const v146: i32 = @as(i32, 0);
    _ = loop_24(v143, v146);
    const v147: i32 = @as(i32, 0);
    _ = loop_25(v144, v147);
    const v148: i32 = @as(i32, 0);
    const v149: i32 = @as(i32, 0);
    const v150: i32 = @as(i32, 0);
    const v151: i32 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v148, v149, v150);
    const v152: i32 = @as(i32, 1);
    const v153: i32 = @as(i32, 0);
    const v154: i32 = @as(i32, 0);
    const v155: i32 = interned_node_26(v138, v139, v140, v141, v142, v143, v144, v152, v153, v154);
    const v156: bool = v151 == @as(i32, 0);
    if (v156) {
        v157 = v155 == @as(i32, 1);
        v158 = v157;
    } else {
        v158 = false;
    }
    if (v158) {
        v166 = v138;
        v167 = v139;
        v168 = v140;
        v169 = v141;
        v170 = v142;
        v171 = v143;
        v172 = v144;
    } else {
        if (spiral_true) spiralFail("brzozowski-interned-store-init");
    }
    const v173: US0 = US0_BitZero();
    const v174: *UH0 = UH0_RegexChar(v173);
    const v175: US0 = US0_BitOne();
    const v176: *UH0 = UH0_RegexChar(v175);
    const v177: *UH0 = UH0_RegexAlt(v174, v176);
    const v178: *UH0 = UH0_RegexStar(v177);
    const v179: US0 = US0_BitZero();
    const v180: *UH0 = UH0_RegexChar(v179);
    const v181: *UH0 = UH0_RegexCat(v178, v180);
    const v182: i32 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v181);
    const v183: u64 = @as(u64, 1);
    const v184: i32 = @as(i32, 0);
    const v185: i32 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v182, v136, v183, v184);
    const v186: US0 = US0_BitZero();
    const v187: *UH0 = UH0_RegexChar(v186);
    const v188: US0 = US0_BitOne();
    const v189: *UH0 = UH0_RegexChar(v188);
    const v190: *UH0 = UH0_RegexAlt(v187, v189);
    const v191: *UH0 = UH0_RegexStar(v190);
    const v192: US0 = US0_BitOne();
    const v193: *UH0 = UH0_RegexChar(v192);
    const v194: US0 = US0_BitZero();
    const v195: *UH0 = UH0_RegexChar(v194);
    const v196: US0 = US0_BitOne();
    const v197: *UH0 = UH0_RegexChar(v196);
    const v198: *UH0 = UH0_RegexAlt(v195, v197);
    const v199: US0 = US0_BitZero();
    const v200: *UH0 = UH0_RegexChar(v199);
    const v201: US0 = US0_BitOne();
    const v202: *UH0 = UH0_RegexChar(v201);
    const v203: *UH0 = UH0_RegexAlt(v200, v202);
    const v204: US0 = US0_BitZero();
    const v205: *UH0 = UH0_RegexChar(v204);
    const v206: US0 = US0_BitOne();
    const v207: *UH0 = UH0_RegexChar(v206);
    const v208: *UH0 = UH0_RegexAlt(v205, v207);
    const v209: *UH0 = UH0_RegexCat(v203, v208);
    const v210: *UH0 = UH0_RegexCat(v198, v209);
    const v211: *UH0 = UH0_RegexCat(v193, v210);
    const v212: *UH0 = UH0_RegexCat(v191, v211);
    const v213: i32 = interned_of_regex_raw_28(v166, v167, v168, v169, v170, v171, v172, v212);
    const v214: u64 = @as(u64, 1);
    const v215: i32 = @as(i32, 0);
    const v216: i32 = loop_32(v166, v167, v168, v169, v170, v171, v172, v137, v213, v136, v214, v215);
    const v217: i32 = @as(i32, 16);
    const v218: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v219: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v220: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v221: []i32 = spiralNewArray(i32, @as(i32, 4096));
    const v222: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v223: []i32 = spiralNewArray(i32, @as(i32, 8192));
    const v224: []i32 = spiralNewArray(i32, @as(i32, 1));
    const v225: i32 = @as(i32, 0);
    _ = loop_24(v222, v225);
    const v226: i32 = @as(i32, 0);
    _ = loop_24(v223, v226);
    const v227: i32 = @as(i32, 0);
    _ = loop_25(v224, v227);
    const v228: i32 = @as(i32, 0);
    const v229: i32 = @as(i32, 0);
    const v230: i32 = @as(i32, 0);
    const v231: i32 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v228, v229, v230);
    const v232: i32 = @as(i32, 1);
    const v233: i32 = @as(i32, 0);
    const v234: i32 = @as(i32, 0);
    const v235: i32 = interned_node_26(v218, v219, v220, v221, v222, v223, v224, v232, v233, v234);
    const v236: bool = v231 == @as(i32, 0);
    if (v236) {
        v237 = v235 == @as(i32, 1);
        v238 = v237;
    } else {
        v238 = false;
    }
    if (v238) {
        v246 = v218;
        v247 = v219;
        v248 = v220;
        v249 = v221;
        v250 = v222;
        v251 = v223;
        v252 = v224;
    } else {
        if (spiral_true) spiralFail("brzozowski-interned-store-init");
    }
    const v253: US0 = US0_BitZero();
    const v254: *UH0 = UH0_RegexChar(v253);
    const v255: US0 = US0_BitZero();
    const v256: *UH0 = UH0_RegexChar(v255);
    const v257: US0 = US0_BitZero();
    const v258: *UH0 = UH0_RegexChar(v257);
    const v259: *UH0 = UH0_RegexCat(v256, v258);
    const v260: *UH0 = UH0_RegexAlt(v254, v259);
    const v261: *UH0 = UH0_RegexStar(v260);
    const v262: US0 = US0_BitOne();
    const v263: *UH0 = UH0_RegexChar(v262);
    const v264: *UH0 = UH0_RegexCat(v261, v263);
    const v265: i32 = interned_of_regex_raw_28(v246, v247, v248, v249, v250, v251, v252, v264);
    const v266: i32 = @as(i32, 1);
    const v267: i32 = @as(i32, 0);
    const v268: i32 = loop_36(v246, v247, v248, v249, v250, v251, v252, v217, v265, v266, v267);
    const v269: bool = v40 == v185;
    if (v269) {
        v270 = v41 == v216;
        v271 = v270;
    } else {
        v271 = false;
    }
    if (v271) {
        v272 = v57 == v268;
        v273 = v272;
    } else {
        v273 = false;
    }
    if (v273) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-engines-disagree");
    }
    const v274: bool = v57 == @as(i32, 16);
    if (v274) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-zero-runs-count");
    }
    const v275: bool = v40 == @as(i32, 93);
    if (v275) {
    } else {
        if (spiral_true) spiralFail("brzozowski-bench-ends-with-zero-count");
    }
    const v276: bool = v41 == @as(i32, 97);
    if (v276) {
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
