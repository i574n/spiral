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
const UH2 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH2 = undefined, c3_1: *UH2 = undefined, c4_0: *UH2 = undefined, c4_1: *UH2 = undefined, c5_0: *UH2 = undefined };
const UH1 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: *UH1 = undefined };
const US1 = struct { tag: i32 };
const UH3 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH3 = undefined };
const UH5 = struct { tag: i32, c2_0: US1 = undefined, c3_0: *UH5 = undefined, c3_1: *UH5 = undefined, c4_0: *UH5 = undefined, c4_1: *UH5 = undefined, c5_0: *UH5 = undefined };
const UH4 = struct { tag: i32, c1_0: *UH5 = undefined, c1_1: *UH4 = undefined };
const US2 = struct { tag: i32 };
const US3 = struct { tag: i32 };
fn US0_BitZero() US0 {
    return US0{ .tag = 0 };
}
fn US0_BitOne() US0 {
    return US0{ .tag = 1 };
}
fn UH0_SymbolListNil() *UH0 {
    const shared = struct {
        var value: UH0 = UH0{ .tag = 0 };
    };
    return &shared.value;
}
fn UH0_SymbolListCons(a0: US0, a1: *UH0) *UH0 {
    return spiralCreate(UH0, UH0{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
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
fn UH1_RegexListNil() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_RegexListCons(a0: *UH2, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn regex_chars_from_symbols_0(p0: *UH0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_chars_from_symbols_0(v3);
            v5 = UH2_RegexChar(v2);
            return UH1_RegexListCons(v5, v4);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_star_corpus_1(p0: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_star_corpus_1(v3);
            v5 = UH2_RegexStar(v2);
            return UH1_RegexListCons(v5, v4);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_list_append_3(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_list_append_3(v3, v1);
            return UH1_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_pairs_with_4(p0: *UH2, p1: *UH1) *UH1 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = regex_pairs_with_4(v0, v4);
            v6 = UH2_RegexAlt(v0, v3);
            v7 = UH2_RegexCat(v0, v3);
            v8 = UH1_RegexListCons(v7, v5);
            return UH1_RegexListCons(v6, v8);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_binary_corpus_2(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = regex_pairs_with_4(v3, v1);
            v6 = regex_binary_corpus_2(v4, v1);
            return regex_list_append_3(v5, v6);
        },
        0 => {
            return UH1_RegexListNil();
        },
        else => unreachable,
    }
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
fn UH3_SymbolListNil() *UH3 {
    const shared = struct {
        var value: UH3 = UH3{ .tag = 0 };
    };
    return &shared.value;
}
fn UH3_SymbolListCons(a0: US1, a1: *UH3) *UH3 {
    return spiralCreate(UH3, UH3{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH5_RegexEmpty() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_RegexEpsilon() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 1 };
    };
    return &shared.value;
}
fn UH5_RegexChar(a0: US1) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 2, .c2_0 = a0 });
}
fn UH5_RegexAlt(a0: *UH5, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH5_RegexCat(a0: *UH5, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH5_RegexStar(a0: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 5, .c5_0 = a0 });
}
fn UH4_RegexListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_RegexListCons(a0: *UH5, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn regex_chars_from_symbols_5(p0: *UH3) *UH4 {
    var v0: *UH3 = p0; _ = &v0;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_chars_from_symbols_5(v3);
            v5 = UH5_RegexChar(v2);
            return UH4_RegexListCons(v5, v4);
        },
        0 => {
            return UH4_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_star_corpus_6(p0: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_star_corpus_6(v3);
            v5 = UH5_RegexStar(v2);
            return UH4_RegexListCons(v5, v4);
        },
        0 => {
            return UH4_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_list_append_8(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = regex_list_append_8(v3, v1);
            return UH4_RegexListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn regex_pairs_with_9(p0: *UH5, p1: *UH4) *UH4 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = regex_pairs_with_9(v0, v4);
            v6 = UH5_RegexAlt(v0, v3);
            v7 = UH5_RegexCat(v0, v3);
            v8 = UH4_RegexListCons(v7, v5);
            return UH4_RegexListCons(v6, v8);
        },
        0 => {
            return UH4_RegexListNil();
        },
        else => unreachable,
    }
}
fn regex_binary_corpus_7(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = regex_pairs_with_9(v3, v1);
            v6 = regex_binary_corpus_7(v4, v1);
            return regex_list_append_8(v5, v6);
        },
        0 => {
            return UH4_RegexListNil();
        },
        else => unreachable,
    }
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
fn regex_compare_14(p0: *UH2, p1: *UH2) US2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v53: *UH2 = undefined; _ = &v53;
    var v54: *UH2 = undefined; _ = &v54;
    var v55: *UH2 = undefined; _ = &v55;
    var v56: *UH2 = undefined; _ = &v56;
    var v57: US2 = undefined; _ = &v57;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v34: *UH2 = undefined; _ = &v34;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: US2 = undefined; _ = &v36;
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
                        v57 = regex_compare_14(v53, v55);
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
                        v36 = regex_compare_14(v28, v34);
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
fn alt_insert_sorted_13(p0: *UH2, p1: *UH2) *UH2 {
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
            v4 = regex_compare_14(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_13(v0, v3);
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
            v11 = regex_compare_14(v0, v1);
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
fn make_alt_12(p0: *UH2, p1: *UH2) *UH2 {
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
                v4 = alt_insert_sorted_13(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_13(v0, v1);
            },
        }
    }
}
fn regex_equal_16(p0: *UH2, p1: *UH2) bool {
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
    var v15: US2 = undefined; _ = &v15;
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
                        v22 = regex_equal_16(v18, v20);
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
                        v30 = regex_equal_16(v26, v28);
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
fn make_cat_15(p0: *UH2, p1: *UH2) *UH2 {
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
                                            v14 = make_cat_15(v13, v1);
                                            return UH2_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_16(v4, v5);
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
fn make_star_17(p0: *UH2) *UH2 {
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
fn normalize_11(p0: *UH2) *UH2 {
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
            v7 = normalize_11(v5);
            v8 = normalize_11(v6);
            return make_alt_12(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_11(v10);
            v13 = normalize_11(v11);
            return make_cat_15(v12, v13);
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
            v16 = normalize_11(v15);
            return make_star_17(v16);
        },
        else => unreachable,
    }
}
fn canonical_alt_ordered_19(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: US2 = undefined; _ = &v4;
    var v7: US2 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            3 => {
                v2 = v1.c3_0;
                v3 = v1.c3_1;
                v4 = regex_compare_14(v0, v2);
                switch (v4.tag) {
                    0 => {
                        v0 = v2;
                        v1 = v3;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                return false;
            },
            else => {
                v7 = regex_compare_14(v0, v1);
                switch (v7.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
        }
    }
}
fn canonical_regex_form_18(p0: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v7: bool = undefined; _ = &v7;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v9: bool = undefined; _ = &v9;
    var v11: bool = undefined; _ = &v11;
    var v14: *UH2 = undefined; _ = &v14;
    var v15: *UH2 = undefined; _ = &v15;
    var v20: bool = undefined; _ = &v20;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v23: bool = undefined; _ = &v23;
    var v30: bool = undefined; _ = &v30;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v32: bool = undefined; _ = &v32;
    var v1: US0 = undefined; _ = &v1;
    var v35: *UH2 = undefined; _ = &v35;
    var v39: bool = undefined; _ = &v39;
    var v36: *UH2 = undefined; _ = &v36;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                switch (v2.tag) {
                    3 => {
                        v4 = v2.c3_0;
                        v5 = v2.c3_1;
                        v7 = false;
                    },
                    0 => {
                        v7 = false;
                    },
                    else => {
                        v7 = true;
                    },
                }
                if (v7) {
                    v9 = canonical_regex_form_18(v2);
                } else {
                    v9 = false;
                }
                if (v9) {
                    v11 = canonical_regex_form_18(v3);
                } else {
                    v11 = false;
                }
                if (v11) {
                    return canonical_alt_ordered_19(v2, v3);
                } else {
                    return false;
                }
            },
            4 => {
                v14 = v0.c4_0;
                v15 = v0.c4_1;
                switch (v14.tag) {
                    4 => {
                        v16 = v14.c4_0;
                        v17 = v14.c4_1;
                        v20 = false;
                    },
                    0 => {
                        v20 = false;
                    },
                    1 => {
                        v20 = false;
                    },
                    else => {
                        v20 = true;
                    },
                }
                if (v20) {
                    switch (v15.tag) {
                        0 => {
                            v23 = false;
                        },
                        1 => {
                            v23 = false;
                        },
                        else => {
                            v23 = true;
                        },
                    }
                } else {
                    v23 = false;
                }
                if (v23) {
                    switch (v14.tag) {
                        5 => {
                            v24 = v14.c5_0;
                            switch (v15.tag) {
                                5 => {
                                    v25 = v15.c5_0;
                                    v26 = regex_equal_16(v24, v25);
                                    v27 = v26 == false;
                                    v30 = v27;
                                },
                                else => {
                                    v30 = true;
                                },
                            }
                        },
                        else => {
                            v30 = true;
                        },
                    }
                } else {
                    v30 = false;
                }
                if (v30) {
                    v32 = canonical_regex_form_18(v14);
                } else {
                    v32 = false;
                }
                if (v32) {
                    v0 = v15;
                    continue;
                } else {
                    return false;
                }
            },
            2 => {
                v1 = v0.c2_0;
                return true;
            },
            0 => {
                return true;
            },
            1 => {
                return true;
            },
            5 => {
                v35 = v0.c5_0;
                switch (v35.tag) {
                    0 => {
                        v39 = false;
                    },
                    1 => {
                        v39 = false;
                    },
                    5 => {
                        v36 = v35.c5_0;
                        v39 = false;
                    },
                    else => {
                        v39 = true;
                    },
                }
                if (v39) {
                    v0 = v35;
                    continue;
                } else {
                    return false;
                }
            },
            else => unreachable,
        }
    }
}
fn normalized_corpus_is_canonical_10(p0: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH2 = undefined; _ = &v1;
    var v2: *UH1 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_11(v1);
                v4 = canonical_regex_form_18(v3);
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
fn regex_compare_24(p0: *UH5, p1: *UH5) US2 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v59: *UH5 = undefined; _ = &v59;
    var v60: *UH5 = undefined; _ = &v60;
    var v61: *UH5 = undefined; _ = &v61;
    var v62: *UH5 = undefined; _ = &v62;
    var v63: US2 = undefined; _ = &v63;
    var v34: *UH5 = undefined; _ = &v34;
    var v35: *UH5 = undefined; _ = &v35;
    var v40: *UH5 = undefined; _ = &v40;
    var v41: *UH5 = undefined; _ = &v41;
    var v42: US2 = undefined; _ = &v42;
    var v38: US1 = undefined; _ = &v38;
    var v10: US1 = undefined; _ = &v10;
    var v13: US1 = undefined; _ = &v13;
    var v50: *UH5 = undefined; _ = &v50;
    var v51: *UH5 = undefined; _ = &v51;
    var v52: *UH5 = undefined; _ = &v52;
    var v54: *UH5 = undefined; _ = &v54;
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
fn alt_insert_sorted_23(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: US2 = undefined; _ = &v4;
    var v6: *UH5 = undefined; _ = &v6;
    var v11: US2 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_24(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_23(v0, v3);
                    return UH5_RegexAlt(v2, v6);
                },
                0 => {
                    return UH5_RegexAlt(v0, v1);
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
                    return UH5_RegexAlt(v1, v0);
                },
                0 => {
                    return UH5_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_22(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
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
fn regex_equal_26(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v24: *UH5 = undefined; _ = &v24;
    var v25: *UH5 = undefined; _ = &v25;
    var v26: *UH5 = undefined; _ = &v26;
    var v27: *UH5 = undefined; _ = &v27;
    var v28: bool = undefined; _ = &v28;
    var v32: *UH5 = undefined; _ = &v32;
    var v33: *UH5 = undefined; _ = &v33;
    var v34: *UH5 = undefined; _ = &v34;
    var v35: *UH5 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v4: US1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v21: US2 = undefined; _ = &v21;
    var v40: *UH5 = undefined; _ = &v40;
    var v41: *UH5 = undefined; _ = &v41;
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
fn make_cat_25(p0: *UH5, p1: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v12: *UH5 = undefined; _ = &v12;
    var v13: *UH5 = undefined; _ = &v13;
    var v14: *UH5 = undefined; _ = &v14;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH5_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH5_RegexEmpty();
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
                                            return UH5_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_26(v4, v5);
                                                    if (v6) {
                                                        return UH5_RegexStar(v4);
                                                    } else {
                                                        return UH5_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH5_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH5_RegexCat(v0, v1);
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
fn make_star_27(p0: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v3: *UH5 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH5_RegexEpsilon();
        },
        1 => {
            return UH5_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH5_RegexStar(v3);
        },
        else => {
            return UH5_RegexStar(v0);
        },
    }
}
fn normalize_21(p0: *UH5) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v10: *UH5 = undefined; _ = &v10;
    var v11: *UH5 = undefined; _ = &v11;
    var v12: *UH5 = undefined; _ = &v12;
    var v13: *UH5 = undefined; _ = &v13;
    var v3: US1 = undefined; _ = &v3;
    var v15: *UH5 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
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
            return UH5_RegexChar(v3);
        },
        0 => {
            return UH5_RegexEmpty();
        },
        1 => {
            return UH5_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_21(v15);
            return make_star_27(v16);
        },
        else => unreachable,
    }
}
fn canonical_alt_ordered_29(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: US2 = undefined; _ = &v4;
    var v7: US2 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            3 => {
                v2 = v1.c3_0;
                v3 = v1.c3_1;
                v4 = regex_compare_24(v0, v2);
                switch (v4.tag) {
                    0 => {
                        v0 = v2;
                        v1 = v3;
                        continue;
                    },
                    else => {
                        return false;
                    },
                }
            },
            0 => {
                return false;
            },
            else => {
                v7 = regex_compare_24(v0, v1);
                switch (v7.tag) {
                    0 => {
                        return true;
                    },
                    else => {
                        return false;
                    },
                }
            },
        }
    }
}
fn canonical_regex_form_28(p0: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v7: bool = undefined; _ = &v7;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v9: bool = undefined; _ = &v9;
    var v11: bool = undefined; _ = &v11;
    var v14: *UH5 = undefined; _ = &v14;
    var v15: *UH5 = undefined; _ = &v15;
    var v20: bool = undefined; _ = &v20;
    var v16: *UH5 = undefined; _ = &v16;
    var v17: *UH5 = undefined; _ = &v17;
    var v23: bool = undefined; _ = &v23;
    var v30: bool = undefined; _ = &v30;
    var v24: *UH5 = undefined; _ = &v24;
    var v25: *UH5 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v32: bool = undefined; _ = &v32;
    var v1: US1 = undefined; _ = &v1;
    var v35: *UH5 = undefined; _ = &v35;
    var v39: bool = undefined; _ = &v39;
    var v36: *UH5 = undefined; _ = &v36;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                switch (v2.tag) {
                    3 => {
                        v4 = v2.c3_0;
                        v5 = v2.c3_1;
                        v7 = false;
                    },
                    0 => {
                        v7 = false;
                    },
                    else => {
                        v7 = true;
                    },
                }
                if (v7) {
                    v9 = canonical_regex_form_28(v2);
                } else {
                    v9 = false;
                }
                if (v9) {
                    v11 = canonical_regex_form_28(v3);
                } else {
                    v11 = false;
                }
                if (v11) {
                    return canonical_alt_ordered_29(v2, v3);
                } else {
                    return false;
                }
            },
            4 => {
                v14 = v0.c4_0;
                v15 = v0.c4_1;
                switch (v14.tag) {
                    4 => {
                        v16 = v14.c4_0;
                        v17 = v14.c4_1;
                        v20 = false;
                    },
                    0 => {
                        v20 = false;
                    },
                    1 => {
                        v20 = false;
                    },
                    else => {
                        v20 = true;
                    },
                }
                if (v20) {
                    switch (v15.tag) {
                        0 => {
                            v23 = false;
                        },
                        1 => {
                            v23 = false;
                        },
                        else => {
                            v23 = true;
                        },
                    }
                } else {
                    v23 = false;
                }
                if (v23) {
                    switch (v14.tag) {
                        5 => {
                            v24 = v14.c5_0;
                            switch (v15.tag) {
                                5 => {
                                    v25 = v15.c5_0;
                                    v26 = regex_equal_26(v24, v25);
                                    v27 = v26 == false;
                                    v30 = v27;
                                },
                                else => {
                                    v30 = true;
                                },
                            }
                        },
                        else => {
                            v30 = true;
                        },
                    }
                } else {
                    v30 = false;
                }
                if (v30) {
                    v32 = canonical_regex_form_28(v14);
                } else {
                    v32 = false;
                }
                if (v32) {
                    v0 = v15;
                    continue;
                } else {
                    return false;
                }
            },
            2 => {
                v1 = v0.c2_0;
                return true;
            },
            0 => {
                return true;
            },
            1 => {
                return true;
            },
            5 => {
                v35 = v0.c5_0;
                switch (v35.tag) {
                    0 => {
                        v39 = false;
                    },
                    1 => {
                        v39 = false;
                    },
                    5 => {
                        v36 = v35.c5_0;
                        v39 = false;
                    },
                    else => {
                        v39 = true;
                    },
                }
                if (v39) {
                    v0 = v35;
                    continue;
                } else {
                    return false;
                }
            },
            else => unreachable,
        }
    }
}
fn normalized_corpus_is_canonical_20(p0: *UH4) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH5 = undefined; _ = &v1;
    var v2: *UH4 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v1 = v0.c1_0;
                v2 = v0.c1_1;
                v3 = normalize_21(v1);
                v4 = canonical_regex_form_28(v3);
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
fn US3_Nullable() US3 {
    return US3{ .tag = 0 };
}
fn US3_NonNullable() US3 {
    return US3{ .tag = 1 };
}
fn nullable_34(p0: *UH2) US3 {
    var v0: *UH2 = p0; _ = &v0;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH2 = undefined; _ = &v16;
    var v17: *UH2 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH2 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_34(v5);
            v8 = nullable_34(v6);
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
            v18 = nullable_34(v16);
            v19 = nullable_34(v17);
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
fn derivative_33(p0: *UH2, p1: US0) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH2 = undefined; _ = &v19;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: *UH2 = undefined; _ = &v22;
    var v24: *UH2 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: US3 = undefined; _ = &v26;
    var v31: *UH2 = undefined; _ = &v31;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH2 = undefined; _ = &v28;
    var v29: *UH2 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US2 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH2 = undefined; _ = &v35;
    var v36: *UH2 = undefined; _ = &v36;
    var v37: *UH2 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_33(v19, v1);
            v22 = derivative_33(v20, v1);
            return make_alt_12(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_34(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_33(v24, v1);
                    return make_cat_15(v31, v25);
                },
                0 => {
                    v27 = derivative_33(v24, v1);
                    v28 = make_cat_15(v27, v25);
                    v29 = derivative_33(v25, v1);
                    return make_alt_12(v28, v29);
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
            v36 = derivative_33(v35, v1);
            v37 = make_star_17(v35);
            return make_cat_15(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_32(p0: *UH2, p1: US0) *UH2 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH2 = normalize_11(v0);
    const v3: *UH2 = derivative_33(v2, v1);
    return normalize_11(v3);
}
fn canonical_derivatives_are_canonical_symbols_31(p0: *UH2, p1: *UH0) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = canonical_derivative_32(v0, v2);
                v5 = canonical_regex_form_18(v4);
                if (v5) {
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
fn canonical_derivatives_are_canonical_corpus_30(p0: *UH1, p1: *UH0) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = canonical_derivatives_are_canonical_symbols_31(v2, v1);
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
fn nullable_39(p0: *UH5) US3 {
    var v0: *UH5 = p0; _ = &v0;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH5 = undefined; _ = &v16;
    var v17: *UH5 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US1 = undefined; _ = &v3;
    var v25: *UH5 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_39(v5);
            v8 = nullable_39(v6);
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
            v18 = nullable_39(v16);
            v19 = nullable_39(v17);
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
fn derivative_38(p0: *UH5, p1: US1) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v25: *UH5 = undefined; _ = &v25;
    var v26: *UH5 = undefined; _ = &v26;
    var v27: *UH5 = undefined; _ = &v27;
    var v28: *UH5 = undefined; _ = &v28;
    var v30: *UH5 = undefined; _ = &v30;
    var v31: *UH5 = undefined; _ = &v31;
    var v32: US3 = undefined; _ = &v32;
    var v37: *UH5 = undefined; _ = &v37;
    var v33: *UH5 = undefined; _ = &v33;
    var v34: *UH5 = undefined; _ = &v34;
    var v35: *UH5 = undefined; _ = &v35;
    var v4: US1 = undefined; _ = &v4;
    var v20: US2 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH5 = undefined; _ = &v41;
    var v42: *UH5 = undefined; _ = &v42;
    var v43: *UH5 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_38(v25, v1);
            v28 = derivative_38(v26, v1);
            return make_alt_22(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_39(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_38(v30, v1);
                    return make_cat_25(v37, v31);
                },
                0 => {
                    v33 = derivative_38(v30, v1);
                    v34 = make_cat_25(v33, v31);
                    v35 = derivative_38(v31, v1);
                    return make_alt_22(v34, v35);
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
                return UH5_RegexEpsilon();
            } else {
                return UH5_RegexEmpty();
            }
        },
        0 => {
            return UH5_RegexEmpty();
        },
        1 => {
            return UH5_RegexEmpty();
        },
        5 => {
            v41 = v0.c5_0;
            v42 = derivative_38(v41, v1);
            v43 = make_star_27(v41);
            return make_cat_25(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_37(p0: *UH5, p1: US1) *UH5 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    const v2: *UH5 = normalize_21(v0);
    const v3: *UH5 = derivative_38(v2, v1);
    return normalize_21(v3);
}
fn canonical_derivatives_are_canonical_symbols_36(p0: *UH5, p1: *UH3) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = canonical_derivative_37(v0, v2);
                v5 = canonical_regex_form_28(v4);
                if (v5) {
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
fn canonical_derivatives_are_canonical_corpus_35(p0: *UH4, p1: *UH3) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = canonical_derivatives_are_canonical_symbols_36(v2, v1);
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
    const v0: US0 = US0_BitZero();
    const v1: US0 = US0_BitOne();
    const v2: *UH0 = UH0_SymbolListNil();
    const v3: *UH0 = UH0_SymbolListCons(v1, v2);
    const v4: *UH0 = UH0_SymbolListCons(v0, v3);
    const v5: *UH1 = regex_chars_from_symbols_0(v4);
    const v6: *UH2 = UH2_RegexEmpty();
    const v7: *UH2 = UH2_RegexEpsilon();
    const v8: *UH1 = UH1_RegexListCons(v7, v5);
    const v9: *UH1 = UH1_RegexListCons(v6, v8);
    const v10: *UH2 = UH2_RegexEmpty();
    const v11: *UH2 = UH2_RegexEpsilon();
    const v12: *UH1 = UH1_RegexListCons(v11, v5);
    const v13: *UH1 = UH1_RegexListCons(v10, v12);
    const v14: *UH1 = regex_star_corpus_1(v13);
    const v15: *UH2 = UH2_RegexEmpty();
    const v16: *UH2 = UH2_RegexEpsilon();
    const v17: *UH1 = UH1_RegexListCons(v16, v5);
    const v18: *UH1 = UH1_RegexListCons(v15, v17);
    const v19: *UH2 = UH2_RegexEmpty();
    const v20: *UH2 = UH2_RegexEpsilon();
    const v21: *UH1 = UH1_RegexListCons(v20, v5);
    const v22: *UH1 = UH1_RegexListCons(v19, v21);
    const v23: *UH1 = regex_binary_corpus_2(v18, v22);
    const v24: *UH1 = regex_list_append_3(v14, v23);
    const v25: *UH1 = regex_list_append_3(v9, v24);
    const v26: US1 = US1_TriA();
    const v27: US1 = US1_TriB();
    const v28: US1 = US1_TriC();
    const v29: *UH3 = UH3_SymbolListNil();
    const v30: *UH3 = UH3_SymbolListCons(v28, v29);
    const v31: *UH3 = UH3_SymbolListCons(v27, v30);
    const v32: *UH3 = UH3_SymbolListCons(v26, v31);
    const v33: *UH4 = regex_chars_from_symbols_5(v32);
    const v34: *UH5 = UH5_RegexEmpty();
    const v35: *UH5 = UH5_RegexEpsilon();
    const v36: *UH4 = UH4_RegexListCons(v35, v33);
    const v37: *UH4 = UH4_RegexListCons(v34, v36);
    const v38: *UH5 = UH5_RegexEmpty();
    const v39: *UH5 = UH5_RegexEpsilon();
    const v40: *UH4 = UH4_RegexListCons(v39, v33);
    const v41: *UH4 = UH4_RegexListCons(v38, v40);
    const v42: *UH4 = regex_star_corpus_6(v41);
    const v43: *UH5 = UH5_RegexEmpty();
    const v44: *UH5 = UH5_RegexEpsilon();
    const v45: *UH4 = UH4_RegexListCons(v44, v33);
    const v46: *UH4 = UH4_RegexListCons(v43, v45);
    const v47: *UH5 = UH5_RegexEmpty();
    const v48: *UH5 = UH5_RegexEpsilon();
    const v49: *UH4 = UH4_RegexListCons(v48, v33);
    const v50: *UH4 = UH4_RegexListCons(v47, v49);
    const v51: *UH4 = regex_binary_corpus_7(v46, v50);
    const v52: *UH4 = regex_list_append_8(v42, v51);
    const v53: *UH4 = regex_list_append_8(v37, v52);
    const v54: bool = normalized_corpus_is_canonical_10(v25);
    if (v54) {
    } else {
        if (spiral_true) spiralFail("every normalized bit corpus term must satisfy structural canonical form");
    }
    const v55: bool = normalized_corpus_is_canonical_20(v53);
    if (v55) {
    } else {
        if (spiral_true) spiralFail("every normalized ternary corpus term must satisfy structural canonical form");
    }
    const v56: US0 = US0_BitZero();
    const v57: US0 = US0_BitOne();
    const v58: *UH0 = UH0_SymbolListNil();
    const v59: *UH0 = UH0_SymbolListCons(v57, v58);
    const v60: *UH0 = UH0_SymbolListCons(v56, v59);
    const v61: bool = canonical_derivatives_are_canonical_corpus_30(v25, v60);
    if (v61) {
    } else {
        if (spiral_true) spiralFail("every canonical bit derivative must already satisfy structural canonical form");
    }
    const v62: US1 = US1_TriA();
    const v63: US1 = US1_TriB();
    const v64: US1 = US1_TriC();
    const v65: *UH3 = UH3_SymbolListNil();
    const v66: *UH3 = UH3_SymbolListCons(v64, v65);
    const v67: *UH3 = UH3_SymbolListCons(v63, v66);
    const v68: *UH3 = UH3_SymbolListCons(v62, v67);
    const v69: bool = canonical_derivatives_are_canonical_corpus_35(v53, v68);
    if (v69) {
    } else {
        if (spiral_true) spiralFail("every canonical ternary derivative must already satisfy structural canonical form");
    }
    const v70: US0 = US0_BitOne();
    const v71: *UH2 = UH2_RegexChar(v70);
    const v72: US0 = US0_BitZero();
    const v73: *UH2 = UH2_RegexChar(v72);
    const v74: *UH2 = UH2_RegexAlt(v71, v73);
    const v75: bool = canonical_regex_form_18(v74);
    const v76: bool = v75 == false;
    if (v76) {
    } else {
        if (spiral_true) spiralFail("unsorted alternation must not be canonical");
    }
    const v77: US0 = US0_BitZero();
    const v78: *UH2 = UH2_RegexChar(v77);
    const v79: *UH2 = UH2_RegexAlt(v78, v78);
    const v80: bool = canonical_regex_form_18(v79);
    const v81: bool = v80 == false;
    if (v81) {
    } else {
        if (spiral_true) spiralFail("duplicate alternation must not be canonical");
    }
    const v82: US0 = US0_BitZero();
    const v83: *UH2 = UH2_RegexChar(v82);
    const v84: US0 = US0_BitOne();
    const v85: *UH2 = UH2_RegexChar(v84);
    const v86: *UH2 = UH2_RegexAlt(v83, v85);
    const v87: *UH2 = UH2_RegexEpsilon();
    const v88: *UH2 = UH2_RegexAlt(v86, v87);
    const v89: bool = canonical_regex_form_18(v88);
    const v90: bool = v89 == false;
    if (v90) {
    } else {
        if (spiral_true) spiralFail("left-nested alternation must not be canonical");
    }
    const v91: *UH2 = UH2_RegexEpsilon();
    const v92: US0 = US0_BitZero();
    const v93: *UH2 = UH2_RegexChar(v92);
    const v94: *UH2 = UH2_RegexCat(v91, v93);
    const v95: bool = canonical_regex_form_18(v94);
    const v96: bool = v95 == false;
    if (v96) {
    } else {
        if (spiral_true) spiralFail("epsilon concatenation identity must not remain in canonical form");
    }
    const v97: US0 = US0_BitZero();
    const v98: *UH2 = UH2_RegexChar(v97);
    const v99: US0 = US0_BitOne();
    const v100: *UH2 = UH2_RegexChar(v99);
    const v101: *UH2 = UH2_RegexCat(v98, v100);
    const v102: *UH2 = UH2_RegexCat(v101, v98);
    const v103: bool = canonical_regex_form_18(v102);
    const v104: bool = v103 == false;
    if (v104) {
    } else {
        if (spiral_true) spiralFail("left-associated concatenation must not remain in canonical form");
    }
    const v105: *UH2 = UH2_RegexEmpty();
    const v106: *UH2 = UH2_RegexStar(v105);
    const v107: bool = canonical_regex_form_18(v106);
    const v108: bool = v107 == false;
    if (v108) {
    } else {
        if (spiral_true) spiralFail("star of empty must not remain in canonical form");
    }
    const v109: US0 = US0_BitZero();
    const v110: *UH2 = UH2_RegexChar(v109);
    const v111: *UH2 = UH2_RegexStar(v110);
    const v112: *UH2 = UH2_RegexStar(v111);
    const v113: bool = canonical_regex_form_18(v112);
    const v114: bool = v113 == false;
    if (v114) {
    } else {
        if (spiral_true) spiralFail("nested star must not remain in canonical form");
    }
    const v115: US0 = US0_BitZero();
    const v116: *UH2 = UH2_RegexChar(v115);
    const v117: *UH2 = UH2_RegexStar(v116);
    const v118: *UH2 = UH2_RegexCat(v117, v117);
    const v119: bool = canonical_regex_form_18(v118);
    const v120: bool = v119 == false;
    if (v120) {
    } else {
        if (spiral_true) spiralFail("duplicate adjacent stars must be reduced in canonical form");
    }
    const v121: US0 = US0_BitOne();
    const v122: *UH2 = UH2_RegexChar(v121);
    const v123: US0 = US0_BitZero();
    const v124: *UH2 = UH2_RegexChar(v123);
    const v125: *UH2 = UH2_RegexAlt(v122, v124);
    const v126: *UH2 = normalize_11(v125);
    const v127: bool = canonical_regex_form_18(v126);
    if (v127) {
    } else {
        if (spiral_true) spiralFail("normalization must repair unsorted alternation");
    }
    const v128: US0 = US0_BitZero();
    const v129: *UH2 = UH2_RegexChar(v128);
    const v130: *UH2 = UH2_RegexAlt(v129, v129);
    const v131: *UH2 = normalize_11(v130);
    const v132: bool = canonical_regex_form_18(v131);
    if (v132) {
    } else {
        if (spiral_true) spiralFail("normalization must remove duplicate alternation");
    }
    const v133: *UH2 = UH2_RegexEpsilon();
    const v134: US0 = US0_BitZero();
    const v135: *UH2 = UH2_RegexChar(v134);
    const v136: *UH2 = UH2_RegexCat(v133, v135);
    const v137: *UH2 = normalize_11(v136);
    const v138: bool = canonical_regex_form_18(v137);
    if (v138) {
    } else {
        if (spiral_true) spiralFail("normalization must remove concatenation identity");
    }
    const v139: US0 = US0_BitZero();
    const v140: *UH2 = UH2_RegexChar(v139);
    const v141: *UH2 = UH2_RegexStar(v140);
    const v142: *UH2 = UH2_RegexStar(v141);
    const v143: *UH2 = normalize_11(v142);
    const v144: bool = canonical_regex_form_18(v143);
    if (v144) {
    } else {
        if (spiral_true) spiralFail("normalization must collapse nested star");
    }
    const v145: US0 = US0_BitZero();
    const v146: *UH2 = UH2_RegexChar(v145);
    const v147: *UH2 = UH2_RegexStar(v146);
    const v148: *UH2 = UH2_RegexCat(v147, v147);
    const v149: *UH2 = normalize_11(v148);
    const v150: bool = canonical_regex_form_18(v149);
    if (v150) {
    } else {
        if (spiral_true) spiralFail("normalization must collapse duplicate adjacent stars");
    }
    const v151: []const u8 = "brzozowski-canonical-form-certificate-green";
    return v151;
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
