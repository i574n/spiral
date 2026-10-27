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
const UH2 = struct { tag: i32, c1_0: US0 = undefined, c1_1: *UH2 = undefined };
const UH1 = struct { tag: i32, c1_0: *UH2 = undefined, c1_1: *UH1 = undefined };
const US1 = struct { tag: i32 };
const UH3 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH3 = undefined };
const UH5 = struct { tag: i32, c1_0: US1 = undefined, c1_1: *UH5 = undefined };
const UH4 = struct { tag: i32, c1_0: *UH5 = undefined, c1_1: *UH4 = undefined };
const UH6 = struct { tag: i32, c2_0: US0 = undefined, c3_0: *UH6 = undefined, c3_1: *UH6 = undefined, c4_0: *UH6 = undefined, c4_1: *UH6 = undefined, c5_0: *UH6 = undefined };
const US2 = struct { tag: i32 };
const UH7 = struct { tag: i32, c0_0: US0 = undefined, c0_1: *UH2 = undefined, c1_0: US0 = undefined, c1_1: *UH2 = undefined, c2_0: US0 = undefined, c2_1: US0 = undefined, c2_2: *UH2 = undefined, c3_0: US0 = undefined, c3_1: *UH2 = undefined, c3_2: *UH7 = undefined, c3_3: *UH7 = undefined, c4_0: US0 = undefined, c4_1: *UH2 = undefined, c4_2: US2 = undefined, c4_3: *UH7 = undefined, c4_4: *UH7 = undefined, c5_0: US0 = undefined, c5_1: *UH2 = undefined, c5_2: *UH7 = undefined };
const US3 = struct { tag: i32 };
const US4 = struct { tag: i32 };
const Tuple0 = struct { f0: *UH1, f1: *UH1 };
const UH8 = struct { tag: i32, c2_0: US1 = undefined, c3_0: *UH8 = undefined, c3_1: *UH8 = undefined, c4_0: *UH8 = undefined, c4_1: *UH8 = undefined, c5_0: *UH8 = undefined };
const UH9 = struct { tag: i32, c0_0: US1 = undefined, c0_1: *UH5 = undefined, c1_0: US1 = undefined, c1_1: *UH5 = undefined, c2_0: US1 = undefined, c2_1: US1 = undefined, c2_2: *UH5 = undefined, c3_0: US1 = undefined, c3_1: *UH5 = undefined, c3_2: *UH9 = undefined, c3_3: *UH9 = undefined, c4_0: US1 = undefined, c4_1: *UH5 = undefined, c4_2: US2 = undefined, c4_3: *UH9 = undefined, c4_4: *UH9 = undefined, c5_0: US1 = undefined, c5_1: *UH5 = undefined, c5_2: *UH9 = undefined };
const Tuple1 = struct { f0: *UH4, f1: *UH4 };
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
fn UH2_InputEmpty() *UH2 {
    const shared = struct {
        var value: UH2 = UH2{ .tag = 0 };
    };
    return &shared.value;
}
fn UH2_InputCons(a0: US0, a1: *UH2) *UH2 {
    return spiralCreate(UH2, UH2{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH1_InputListNil() *UH1 {
    const shared = struct {
        var value: UH1 = UH1{ .tag = 0 };
    };
    return &shared.value;
}
fn UH1_InputListCons(a0: *UH2, a1: *UH1) *UH1 {
    return spiralCreate(UH1, UH1{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_singletons_from_symbols_0(p0: *UH0) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH0 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_0(v3);
            v5 = UH2_InputEmpty();
            v6 = UH2_InputCons(v2, v5);
            return UH1_InputListCons(v6, v4);
        },
        0 => {
            return UH1_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_append_2(p0: *UH1, p1: *UH1) *UH1 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_2(v3, v1);
            return UH1_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_3(p0: US0, p1: *UH1) *UH1 {
    var v0: US0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_3(v0, v4);
            v6 = UH2_InputCons(v0, v3);
            return UH1_InputListCons(v6, v5);
        },
        0 => {
            return UH1_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_1(p0: *UH0, p1: *UH1) *UH1 {
    var v0: *UH0 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_3(v3, v1);
            v6 = input_prepend_symbols_to_corpus_1(v4, v1);
            return input_list_append_2(v5, v6);
        },
        0 => {
            return UH1_InputListNil();
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
fn UH5_InputEmpty() *UH5 {
    const shared = struct {
        var value: UH5 = UH5{ .tag = 0 };
    };
    return &shared.value;
}
fn UH5_InputCons(a0: US1, a1: *UH5) *UH5 {
    return spiralCreate(UH5, UH5{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH4_InputListNil() *UH4 {
    const shared = struct {
        var value: UH4 = UH4{ .tag = 0 };
    };
    return &shared.value;
}
fn UH4_InputListCons(a0: *UH5, a1: *UH4) *UH4 {
    return spiralCreate(UH4, UH4{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn input_singletons_from_symbols_4(p0: *UH3) *UH4 {
    var v0: *UH3 = p0; _ = &v0;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH3 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_singletons_from_symbols_4(v3);
            v5 = UH5_InputEmpty();
            v6 = UH5_InputCons(v2, v5);
            return UH4_InputListCons(v6, v4);
        },
        0 => {
            return UH4_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_append_6(p0: *UH4, p1: *UH4) *UH4 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    switch (v0.tag) {
        1 => {
            v2 = v0.c1_0;
            v3 = v0.c1_1;
            v4 = input_list_append_6(v3, v1);
            return UH4_InputListCons(v2, v4);
        },
        0 => {
            return v1;
        },
        else => unreachable,
    }
}
fn input_prepend_symbol_to_corpus_7(p0: US1, p1: *UH4) *UH4 {
    var v0: US1 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = input_prepend_symbol_to_corpus_7(v0, v4);
            v6 = UH5_InputCons(v0, v3);
            return UH4_InputListCons(v6, v5);
        },
        0 => {
            return UH4_InputListNil();
        },
        else => unreachable,
    }
}
fn input_prepend_symbols_to_corpus_5(p0: *UH3, p1: *UH4) *UH4 {
    var v0: *UH3 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    switch (v0.tag) {
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            v5 = input_prepend_symbol_to_corpus_7(v3, v1);
            v6 = input_prepend_symbols_to_corpus_5(v4, v1);
            return input_list_append_6(v5, v6);
        },
        0 => {
            return UH4_InputListNil();
        },
        else => unreachable,
    }
}
fn UH6_RegexEmpty() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 0 };
    };
    return &shared.value;
}
fn UH6_RegexEpsilon() *UH6 {
    const shared = struct {
        var value: UH6 = UH6{ .tag = 1 };
    };
    return &shared.value;
}
fn UH6_RegexChar(a0: US0) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 2, .c2_0 = a0 });
}
fn UH6_RegexAlt(a0: *UH6, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 3, .c3_0 = a0, .c3_1 = a1 });
}
fn UH6_RegexCat(a0: *UH6, a1: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 4, .c4_0 = a0, .c4_1 = a1 });
}
fn UH6_RegexStar(a0: *UH6) *UH6 {
    return spiralCreate(UH6, UH6{ .tag = 5, .c5_0 = a0 });
}
fn US2_RemainderCatNullable() US2 {
    return US2{ .tag = 0 };
}
fn US2_RemainderCatNonNullable() US2 {
    return US2{ .tag = 1 };
}
fn UH7_RemainderProofEmpty(a0: US0, a1: *UH2) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH7_RemainderProofEpsilon(a0: US0, a1: *UH2) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH7_RemainderProofChar(a0: US0, a1: US0, a2: *UH2) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 2, .c2_0 = a0, .c2_1 = a1, .c2_2 = a2 });
}
fn UH7_RemainderProofAlt(a0: US0, a1: *UH2, a2: *UH7, a3: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 3, .c3_0 = a0, .c3_1 = a1, .c3_2 = a2, .c3_3 = a3 });
}
fn UH7_RemainderProofCat(a0: US0, a1: *UH2, a2: US2, a3: *UH7, a4: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 4, .c4_0 = a0, .c4_1 = a1, .c4_2 = a2, .c4_3 = a3, .c4_4 = a4 });
}
fn UH7_RemainderProofStar(a0: US0, a1: *UH2, a2: *UH7) *UH7 {
    return spiralCreate(UH7, UH7{ .tag = 5, .c5_0 = a0, .c5_1 = a1, .c5_2 = a2 });
}
fn US3_Nullable() US3 {
    return US3{ .tag = 0 };
}
fn US3_NonNullable() US3 {
    return US3{ .tag = 1 };
}
fn nullable_11(p0: *UH6) US3 {
    var v0: *UH6 = p0; _ = &v0;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH6 = undefined; _ = &v16;
    var v17: *UH6 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US0 = undefined; _ = &v3;
    var v25: *UH6 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_11(v5);
            v8 = nullable_11(v6);
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
            v18 = nullable_11(v16);
            v19 = nullable_11(v17);
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
fn derivative_remainder_proof_make_10(p0: *UH6, p1: US0, p2: *UH2) *UH7 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH2 = p2; _ = &v2;
    var v7: *UH6 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v9: *UH7 = undefined; _ = &v9;
    var v10: *UH7 = undefined; _ = &v10;
    var v12: *UH6 = undefined; _ = &v12;
    var v13: *UH6 = undefined; _ = &v13;
    var v14: US3 = undefined; _ = &v14;
    var v18: US2 = undefined; _ = &v18;
    var v19: *UH7 = undefined; _ = &v19;
    var v20: *UH7 = undefined; _ = &v20;
    var v5: US0 = undefined; _ = &v5;
    var v22: *UH6 = undefined; _ = &v22;
    var v23: *UH7 = undefined; _ = &v23;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = derivative_remainder_proof_make_10(v7, v1, v2);
            v10 = derivative_remainder_proof_make_10(v8, v1, v2);
            return UH7_RemainderProofAlt(v1, v2, v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = nullable_11(v12);
            switch (v14.tag) {
                1 => {
                    v18 = US2_RemainderCatNonNullable();
                },
                0 => {
                    v18 = US2_RemainderCatNullable();
                },
                else => unreachable,
            }
            v19 = derivative_remainder_proof_make_10(v12, v1, v2);
            v20 = derivative_remainder_proof_make_10(v13, v1, v2);
            return UH7_RemainderProofCat(v1, v2, v18, v19, v20);
        },
        2 => {
            v5 = v0.c2_0;
            return UH7_RemainderProofChar(v5, v1, v2);
        },
        0 => {
            return UH7_RemainderProofEmpty(v1, v2);
        },
        1 => {
            return UH7_RemainderProofEpsilon(v1, v2);
        },
        5 => {
            v22 = v0.c5_0;
            v23 = derivative_remainder_proof_make_10(v22, v1, v2);
            return UH7_RemainderProofStar(v1, v2, v23);
        },
        else => unreachable,
    }
}
fn derivative_remainder_proof_source_12(p0: *UH7) *UH6 {
    var v0: *UH7 = p0; _ = &v0;
    var v11: US0 = undefined; _ = &v11;
    var v12: *UH2 = undefined; _ = &v12;
    var v13: *UH7 = undefined; _ = &v13;
    var v14: *UH7 = undefined; _ = &v14;
    var v15: *UH6 = undefined; _ = &v15;
    var v16: *UH6 = undefined; _ = &v16;
    var v18: US0 = undefined; _ = &v18;
    var v19: *UH2 = undefined; _ = &v19;
    var v20: US2 = undefined; _ = &v20;
    var v21: *UH7 = undefined; _ = &v21;
    var v22: *UH7 = undefined; _ = &v22;
    var v23: *UH6 = undefined; _ = &v23;
    var v24: *UH6 = undefined; _ = &v24;
    var v7: US0 = undefined; _ = &v7;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v26: US0 = undefined; _ = &v26;
    var v27: *UH2 = undefined; _ = &v27;
    var v28: *UH7 = undefined; _ = &v28;
    var v29: *UH6 = undefined; _ = &v29;
    switch (v0.tag) {
        3 => {
            v11 = v0.c3_0;
            v12 = v0.c3_1;
            v13 = v0.c3_2;
            v14 = v0.c3_3;
            v15 = derivative_remainder_proof_source_12(v13);
            v16 = derivative_remainder_proof_source_12(v14);
            return UH6_RegexAlt(v15, v16);
        },
        4 => {
            v18 = v0.c4_0;
            v19 = v0.c4_1;
            v20 = v0.c4_2;
            v21 = v0.c4_3;
            v22 = v0.c4_4;
            v23 = derivative_remainder_proof_source_12(v21);
            v24 = derivative_remainder_proof_source_12(v22);
            return UH6_RegexCat(v23, v24);
        },
        2 => {
            v7 = v0.c2_0;
            v8 = v0.c2_1;
            v9 = v0.c2_2;
            return UH6_RegexChar(v7);
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return UH6_RegexEmpty();
        },
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            return UH6_RegexEpsilon();
        },
        5 => {
            v26 = v0.c5_0;
            v27 = v0.c5_1;
            v28 = v0.c5_2;
            v29 = derivative_remainder_proof_source_12(v28);
            return UH6_RegexStar(v29);
        },
        else => unreachable,
    }
}
fn US4_SymbolLess() US4 {
    return US4{ .tag = 0 };
}
fn US4_SymbolSame() US4 {
    return US4{ .tag = 1 };
}
fn US4_SymbolGreater() US4 {
    return US4{ .tag = 2 };
}
fn regex_equal_13(p0: *UH6, p1: *UH6) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v18: *UH6 = undefined; _ = &v18;
    var v19: *UH6 = undefined; _ = &v19;
    var v20: *UH6 = undefined; _ = &v20;
    var v21: *UH6 = undefined; _ = &v21;
    var v22: bool = undefined; _ = &v22;
    var v26: *UH6 = undefined; _ = &v26;
    var v27: *UH6 = undefined; _ = &v27;
    var v28: *UH6 = undefined; _ = &v28;
    var v29: *UH6 = undefined; _ = &v29;
    var v30: bool = undefined; _ = &v30;
    var v4: US0 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v15: US4 = undefined; _ = &v15;
    var v34: *UH6 = undefined; _ = &v34;
    var v35: *UH6 = undefined; _ = &v35;
    while (true) {
        switch (v0.tag) {
            3 => {
                v18 = v0.c3_0;
                v19 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v20 = v1.c3_0;
                        v21 = v1.c3_1;
                        v22 = regex_equal_13(v18, v20);
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
                        v30 = regex_equal_13(v26, v28);
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
                                        v15 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v15 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v15 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v15 = US4_SymbolSame();
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
fn derivative_remainder_proof_symbol_14(p0: *UH7) US0 {
    var v0: *UH7 = p0; _ = &v0;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v10: *UH7 = undefined; _ = &v10;
    var v11: *UH7 = undefined; _ = &v11;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: US2 = undefined; _ = &v14;
    var v15: *UH7 = undefined; _ = &v15;
    var v16: *UH7 = undefined; _ = &v16;
    var v5: US0 = undefined; _ = &v5;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH2 = undefined; _ = &v18;
    var v19: *UH7 = undefined; _ = &v19;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = v0.c3_3;
            return v8;
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = v0.c4_2;
            v15 = v0.c4_3;
            v16 = v0.c4_4;
            return v12;
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            v7 = v0.c2_2;
            return v6;
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return v1;
        },
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            return v3;
        },
        5 => {
            v17 = v0.c5_0;
            v18 = v0.c5_1;
            v19 = v0.c5_2;
            return v17;
        },
        else => unreachable,
    }
}
fn derivative_remainder_proof_suffix_15(p0: *UH7) *UH2 {
    var v0: *UH7 = p0; _ = &v0;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v10: *UH7 = undefined; _ = &v10;
    var v11: *UH7 = undefined; _ = &v11;
    var v12: US0 = undefined; _ = &v12;
    var v13: *UH2 = undefined; _ = &v13;
    var v14: US2 = undefined; _ = &v14;
    var v15: *UH7 = undefined; _ = &v15;
    var v16: *UH7 = undefined; _ = &v16;
    var v5: US0 = undefined; _ = &v5;
    var v6: US0 = undefined; _ = &v6;
    var v7: *UH2 = undefined; _ = &v7;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v17: US0 = undefined; _ = &v17;
    var v18: *UH2 = undefined; _ = &v18;
    var v19: *UH7 = undefined; _ = &v19;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = v0.c3_3;
            return v9;
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = v0.c4_2;
            v15 = v0.c4_3;
            v16 = v0.c4_4;
            return v13;
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            v7 = v0.c2_2;
            return v7;
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return v2;
        },
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            return v4;
        },
        5 => {
            v17 = v0.c5_0;
            v18 = v0.c5_1;
            v19 = v0.c5_2;
            return v18;
        },
        else => unreachable,
    }
}
fn input_equal_16(p0: *UH2, p1: *UH2) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH2 = undefined; _ = &v4;
    var v5: US0 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v16: US4 = undefined; _ = &v16;
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
                                        v16 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v16 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v5.tag) {
                                    1 => {
                                        v16 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v16 = US4_SymbolSame();
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
fn regex_compare_21(p0: *UH6, p1: *UH6) US4 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v53: *UH6 = undefined; _ = &v53;
    var v54: *UH6 = undefined; _ = &v54;
    var v55: *UH6 = undefined; _ = &v55;
    var v56: *UH6 = undefined; _ = &v56;
    var v57: US4 = undefined; _ = &v57;
    var v28: *UH6 = undefined; _ = &v28;
    var v29: *UH6 = undefined; _ = &v29;
    var v34: *UH6 = undefined; _ = &v34;
    var v35: *UH6 = undefined; _ = &v35;
    var v36: US4 = undefined; _ = &v36;
    var v32: US0 = undefined; _ = &v32;
    var v10: US0 = undefined; _ = &v10;
    var v13: US0 = undefined; _ = &v13;
    var v44: *UH6 = undefined; _ = &v44;
    var v45: *UH6 = undefined; _ = &v45;
    var v46: *UH6 = undefined; _ = &v46;
    var v48: *UH6 = undefined; _ = &v48;
    while (true) {
        switch (v0.tag) {
            3 => {
                v53 = v0.c3_0;
                v54 = v0.c3_1;
                switch (v1.tag) {
                    3 => {
                        v55 = v1.c3_0;
                        v56 = v1.c3_1;
                        v57 = regex_compare_21(v53, v55);
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
                        return US4_SymbolGreater();
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
                        v36 = regex_compare_21(v28, v34);
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
                        return US4_SymbolGreater();
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
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
                                        return US4_SymbolSame();
                                    },
                                    0 => {
                                        return US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v13.tag) {
                                    1 => {
                                        return US4_SymbolLess();
                                    },
                                    0 => {
                                        return US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            5 => {
                v44 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v45 = v1.c3_0;
                        v46 = v1.c3_1;
                        return US4_SymbolLess();
                    },
                    5 => {
                        v48 = v1.c5_0;
                        v0 = v44;
                        v1 = v48;
                        continue;
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_20(p0: *UH6, p1: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH6 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_21(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_20(v0, v3);
                    return UH6_RegexAlt(v2, v6);
                },
                0 => {
                    return UH6_RegexAlt(v0, v1);
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
            v11 = regex_compare_21(v0, v1);
            switch (v11.tag) {
                2 => {
                    return UH6_RegexAlt(v1, v0);
                },
                0 => {
                    return UH6_RegexAlt(v0, v1);
                },
                1 => {
                    return v1;
                },
                else => unreachable,
            }
        },
    }
}
fn make_alt_19(p0: *UH6, p1: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v2: *UH6 = undefined; _ = &v2;
    var v3: *UH6 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            3 => {
                v2 = v0.c3_0;
                v3 = v0.c3_1;
                v4 = alt_insert_sorted_20(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_20(v0, v1);
            },
        }
    }
}
fn make_cat_22(p0: *UH6, p1: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH6 = p1; _ = &v1;
    var v12: *UH6 = undefined; _ = &v12;
    var v13: *UH6 = undefined; _ = &v13;
    var v14: *UH6 = undefined; _ = &v14;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: bool = undefined; _ = &v6;
    switch (v0.tag) {
        0 => {
            return UH6_RegexEmpty();
        },
        else => {
            switch (v1.tag) {
                0 => {
                    return UH6_RegexEmpty();
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
                                            v14 = make_cat_22(v13, v1);
                                            return UH6_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_13(v4, v5);
                                                    if (v6) {
                                                        return UH6_RegexStar(v4);
                                                    } else {
                                                        return UH6_RegexCat(v0, v1);
                                                    }
                                                },
                                                else => {
                                                    return UH6_RegexCat(v0, v1);
                                                },
                                            }
                                        },
                                        else => {
                                            return UH6_RegexCat(v0, v1);
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
fn make_star_23(p0: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v3: *UH6 = undefined; _ = &v3;
    switch (v0.tag) {
        0 => {
            return UH6_RegexEpsilon();
        },
        1 => {
            return UH6_RegexEpsilon();
        },
        5 => {
            v3 = v0.c5_0;
            return UH6_RegexStar(v3);
        },
        else => {
            return UH6_RegexStar(v0);
        },
    }
}
fn normalize_18(p0: *UH6) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v5: *UH6 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    var v7: *UH6 = undefined; _ = &v7;
    var v8: *UH6 = undefined; _ = &v8;
    var v10: *UH6 = undefined; _ = &v10;
    var v11: *UH6 = undefined; _ = &v11;
    var v12: *UH6 = undefined; _ = &v12;
    var v13: *UH6 = undefined; _ = &v13;
    var v3: US0 = undefined; _ = &v3;
    var v15: *UH6 = undefined; _ = &v15;
    var v16: *UH6 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_18(v5);
            v8 = normalize_18(v6);
            return make_alt_19(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_18(v10);
            v13 = normalize_18(v11);
            return make_cat_22(v12, v13);
        },
        2 => {
            v3 = v0.c2_0;
            return UH6_RegexChar(v3);
        },
        0 => {
            return UH6_RegexEmpty();
        },
        1 => {
            return UH6_RegexEpsilon();
        },
        5 => {
            v15 = v0.c5_0;
            v16 = normalize_18(v15);
            return make_star_23(v16);
        },
        else => unreachable,
    }
}
fn derivative_24(p0: *UH6, p1: US0) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v19: *UH6 = undefined; _ = &v19;
    var v20: *UH6 = undefined; _ = &v20;
    var v21: *UH6 = undefined; _ = &v21;
    var v22: *UH6 = undefined; _ = &v22;
    var v24: *UH6 = undefined; _ = &v24;
    var v25: *UH6 = undefined; _ = &v25;
    var v26: US3 = undefined; _ = &v26;
    var v31: *UH6 = undefined; _ = &v31;
    var v27: *UH6 = undefined; _ = &v27;
    var v28: *UH6 = undefined; _ = &v28;
    var v29: *UH6 = undefined; _ = &v29;
    var v4: US0 = undefined; _ = &v4;
    var v14: US4 = undefined; _ = &v14;
    var v15: bool = undefined; _ = &v15;
    var v35: *UH6 = undefined; _ = &v35;
    var v36: *UH6 = undefined; _ = &v36;
    var v37: *UH6 = undefined; _ = &v37;
    switch (v0.tag) {
        3 => {
            v19 = v0.c3_0;
            v20 = v0.c3_1;
            v21 = derivative_24(v19, v1);
            v22 = derivative_24(v20, v1);
            return make_alt_19(v21, v22);
        },
        4 => {
            v24 = v0.c4_0;
            v25 = v0.c4_1;
            v26 = nullable_11(v24);
            switch (v26.tag) {
                1 => {
                    v31 = derivative_24(v24, v1);
                    return make_cat_22(v31, v25);
                },
                0 => {
                    v27 = derivative_24(v24, v1);
                    v28 = make_cat_22(v27, v25);
                    v29 = derivative_24(v25, v1);
                    return make_alt_19(v28, v29);
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
                            v14 = US4_SymbolSame();
                        },
                        0 => {
                            v14 = US4_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v1.tag) {
                        1 => {
                            v14 = US4_SymbolLess();
                        },
                        0 => {
                            v14 = US4_SymbolSame();
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
                return UH6_RegexEpsilon();
            } else {
                return UH6_RegexEmpty();
            }
        },
        0 => {
            return UH6_RegexEmpty();
        },
        1 => {
            return UH6_RegexEmpty();
        },
        5 => {
            v35 = v0.c5_0;
            v36 = derivative_24(v35, v1);
            v37 = make_star_23(v35);
            return make_cat_22(v36, v37);
        },
        else => unreachable,
    }
}
fn canonical_derivative_17(p0: *UH6, p1: US0) *UH6 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    const v2: *UH6 = normalize_18(v0);
    const v3: *UH6 = derivative_24(v2, v1);
    return normalize_18(v3);
}
fn derivative_remainder_proof_candidate_25(p0: *UH7) *UH6 {
    var v0: *UH7 = p0; _ = &v0;
    var v24: US0 = undefined; _ = &v24;
    var v25: *UH2 = undefined; _ = &v25;
    var v26: *UH7 = undefined; _ = &v26;
    var v27: *UH7 = undefined; _ = &v27;
    var v28: *UH6 = undefined; _ = &v28;
    var v29: *UH6 = undefined; _ = &v29;
    var v31: US0 = undefined; _ = &v31;
    var v32: *UH2 = undefined; _ = &v32;
    var v33: US2 = undefined; _ = &v33;
    var v34: *UH7 = undefined; _ = &v34;
    var v35: *UH7 = undefined; _ = &v35;
    var v36: *UH6 = undefined; _ = &v36;
    var v37: *UH6 = undefined; _ = &v37;
    var v38: *UH6 = undefined; _ = &v38;
    var v39: *UH6 = undefined; _ = &v39;
    var v7: US0 = undefined; _ = &v7;
    var v8: US0 = undefined; _ = &v8;
    var v9: *UH2 = undefined; _ = &v9;
    var v19: US4 = undefined; _ = &v19;
    var v20: bool = undefined; _ = &v20;
    var v1: US0 = undefined; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v4: US0 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v44: US0 = undefined; _ = &v44;
    var v45: *UH2 = undefined; _ = &v45;
    var v46: *UH7 = undefined; _ = &v46;
    var v47: *UH6 = undefined; _ = &v47;
    var v48: *UH6 = undefined; _ = &v48;
    var v49: *UH6 = undefined; _ = &v49;
    switch (v0.tag) {
        3 => {
            v24 = v0.c3_0;
            v25 = v0.c3_1;
            v26 = v0.c3_2;
            v27 = v0.c3_3;
            v28 = derivative_remainder_proof_candidate_25(v26);
            v29 = derivative_remainder_proof_candidate_25(v27);
            return UH6_RegexAlt(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = v0.c4_2;
            v34 = v0.c4_3;
            v35 = v0.c4_4;
            v36 = derivative_remainder_proof_candidate_25(v34);
            v37 = derivative_remainder_proof_candidate_25(v35);
            v38 = derivative_remainder_proof_source_12(v35);
            switch (v33.tag) {
                1 => {
                    return UH6_RegexCat(v36, v38);
                },
                0 => {
                    v39 = UH6_RegexCat(v36, v38);
                    return UH6_RegexAlt(v39, v37);
                },
                else => unreachable,
            }
        },
        2 => {
            v7 = v0.c2_0;
            v8 = v0.c2_1;
            v9 = v0.c2_2;
            switch (v7.tag) {
                1 => {
                    switch (v8.tag) {
                        1 => {
                            v19 = US4_SymbolSame();
                        },
                        0 => {
                            v19 = US4_SymbolGreater();
                        },
                        else => unreachable,
                    }
                },
                0 => {
                    switch (v8.tag) {
                        1 => {
                            v19 = US4_SymbolLess();
                        },
                        0 => {
                            v19 = US4_SymbolSame();
                        },
                        else => unreachable,
                    }
                },
                else => unreachable,
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
                return UH6_RegexEpsilon();
            } else {
                return UH6_RegexEmpty();
            }
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return UH6_RegexEmpty();
        },
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            return UH6_RegexEmpty();
        },
        5 => {
            v44 = v0.c5_0;
            v45 = v0.c5_1;
            v46 = v0.c5_2;
            v47 = derivative_remainder_proof_candidate_25(v46);
            v48 = derivative_remainder_proof_source_12(v46);
            v49 = UH6_RegexStar(v48);
            return UH6_RegexCat(v47, v49);
        },
        else => unreachable,
    }
}
fn consume_right_28(p0: *UH6, p1: *UH1) *UH1 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_27(v0, v3);
            v6 = consume_right_28(v0, v4);
            return input_list_append_2(v5, v6);
        },
        0 => {
            return UH1_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_contains_31(p0: *UH2, p1: *UH1) bool {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
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
fn input_list_enqueue_new_30(p0: *UH1, p1: *UH1, p2: *UH1) Tuple0 {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
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
                    v8 = UH1_InputListCons(v3, v1);
                    v9 = UH1_InputListCons(v3, v2);
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
fn closure_29(p0: *UH6, p1: *UH1, p2: *UH1) *UH1 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH1 = undefined; _ = &v5;
    var v6: *UH1 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var tmp5: Tuple0 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_27(v0, v3);
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
fn language_remainders_27(p0: *UH6, p1: *UH2) *UH1 {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH2 = p1; _ = &v1;
    var v26: *UH6 = undefined; _ = &v26;
    var v27: *UH6 = undefined; _ = &v27;
    var v28: *UH1 = undefined; _ = &v28;
    var v29: *UH1 = undefined; _ = &v29;
    var v31: *UH6 = undefined; _ = &v31;
    var v32: *UH6 = undefined; _ = &v32;
    var v33: *UH1 = undefined; _ = &v33;
    var v5: US0 = undefined; _ = &v5;
    var v7: US0 = undefined; _ = &v7;
    var v8: *UH2 = undefined; _ = &v8;
    var v18: US4 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH1 = undefined; _ = &v20;
    var v3: *UH1 = undefined; _ = &v3;
    var v35: *UH6 = undefined; _ = &v35;
    var v36: *UH1 = undefined; _ = &v36;
    var v37: *UH1 = undefined; _ = &v37;
    var v38: *UH1 = undefined; _ = &v38;
    var v39: *UH1 = undefined; _ = &v39;
    switch (v0.tag) {
        3 => {
            v26 = v0.c3_0;
            v27 = v0.c3_1;
            v28 = language_remainders_27(v26, v1);
            v29 = language_remainders_27(v27, v1);
            return input_list_append_2(v28, v29);
        },
        4 => {
            v31 = v0.c4_0;
            v32 = v0.c4_1;
            v33 = language_remainders_27(v31, v1);
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
                                    v18 = US4_SymbolSame();
                                },
                                0 => {
                                    v18 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v7.tag) {
                                1 => {
                                    v18 = US4_SymbolLess();
                                },
                                0 => {
                                    v18 = US4_SymbolSame();
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
                        v20 = UH1_InputListNil();
                        return UH1_InputListCons(v8, v20);
                    } else {
                        return UH1_InputListNil();
                    }
                },
                0 => {
                    return UH1_InputListNil();
                },
                else => unreachable,
            }
        },
        0 => {
            return UH1_InputListNil();
        },
        1 => {
            v3 = UH1_InputListNil();
            return UH1_InputListCons(v1, v3);
        },
        5 => {
            v35 = v0.c5_0;
            v36 = UH1_InputListNil();
            v37 = UH1_InputListCons(v1, v36);
            v38 = UH1_InputListNil();
            v39 = UH1_InputListCons(v1, v38);
            return closure_29(v35, v37, v39);
        },
        else => unreachable,
    }
}
fn input_list_remove_32(p0: *UH2, p1: *UH1) *UH1 {
    var v0: *UH2 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH1 = undefined; _ = &v7;
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
                    v7 = input_list_remove_32(v0, v4);
                    return UH1_InputListCons(v3, v7);
                }
            },
            0 => {
                return UH1_InputListNil();
            },
            else => unreachable,
        }
    }
}
fn input_list_subset_33(p0: *UH1, p1: *UH1) bool {
    var v0: *UH1 = p0; _ = &v0;
    var v1: *UH1 = p1; _ = &v1;
    var v2: *UH2 = undefined; _ = &v2;
    var v3: *UH1 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_31(v2, v1);
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
fn derivative_remainder_proof_valid_26(p0: *UH7) bool {
    var v0: *UH7 = p0; _ = &v0;
    var v1: *UH6 = undefined; _ = &v1;
    var v2: US0 = undefined; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH6 = undefined; _ = &v4;
    var v5: *UH2 = undefined; _ = &v5;
    var v6: *UH2 = undefined; _ = &v6;
    var v7: *UH1 = undefined; _ = &v7;
    var v8: *UH1 = undefined; _ = &v8;
    var v9: *UH1 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v20: US0 = undefined; _ = &v20;
    var v21: *UH2 = undefined; _ = &v21;
    var v22: *UH7 = undefined; _ = &v22;
    var v23: *UH7 = undefined; _ = &v23;
    var v24: US0 = undefined; _ = &v24;
    var v25: US0 = undefined; _ = &v25;
    var v35: US4 = undefined; _ = &v35;
    var v36: bool = undefined; _ = &v36;
    var v40: bool = undefined; _ = &v40;
    var v37: *UH2 = undefined; _ = &v37;
    var v38: *UH2 = undefined; _ = &v38;
    var v41: US0 = undefined; _ = &v41;
    var v42: US0 = undefined; _ = &v42;
    var v52: US4 = undefined; _ = &v52;
    var v53: bool = undefined; _ = &v53;
    var v57: bool = undefined; _ = &v57;
    var v54: *UH2 = undefined; _ = &v54;
    var v55: *UH2 = undefined; _ = &v55;
    var v58: bool = undefined; _ = &v58;
    var v63: US0 = undefined; _ = &v63;
    var v64: *UH2 = undefined; _ = &v64;
    var v65: US2 = undefined; _ = &v65;
    var v66: *UH7 = undefined; _ = &v66;
    var v67: *UH7 = undefined; _ = &v67;
    var v68: *UH6 = undefined; _ = &v68;
    var v69: US3 = undefined; _ = &v69;
    var v73: US2 = undefined; _ = &v73;
    var v77: bool = undefined; _ = &v77;
    var v78: US0 = undefined; _ = &v78;
    var v79: US0 = undefined; _ = &v79;
    var v89: US4 = undefined; _ = &v89;
    var v90: bool = undefined; _ = &v90;
    var v94: bool = undefined; _ = &v94;
    var v91: *UH2 = undefined; _ = &v91;
    var v92: *UH2 = undefined; _ = &v92;
    var v95: US0 = undefined; _ = &v95;
    var v96: US0 = undefined; _ = &v96;
    var v106: US4 = undefined; _ = &v106;
    var v107: bool = undefined; _ = &v107;
    var v111: bool = undefined; _ = &v111;
    var v108: *UH2 = undefined; _ = &v108;
    var v109: *UH2 = undefined; _ = &v109;
    var v112: bool = undefined; _ = &v112;
    var v17: US0 = undefined; _ = &v17;
    var v18: US0 = undefined; _ = &v18;
    var v19: *UH2 = undefined; _ = &v19;
    var v13: US0 = undefined; _ = &v13;
    var v14: *UH2 = undefined; _ = &v14;
    var v15: US0 = undefined; _ = &v15;
    var v16: *UH2 = undefined; _ = &v16;
    var v118: US0 = undefined; _ = &v118;
    var v119: *UH2 = undefined; _ = &v119;
    var v120: *UH7 = undefined; _ = &v120;
    var v121: US0 = undefined; _ = &v121;
    var v122: US0 = undefined; _ = &v122;
    var v132: US4 = undefined; _ = &v132;
    var v133: bool = undefined; _ = &v133;
    var v137: bool = undefined; _ = &v137;
    var v134: *UH2 = undefined; _ = &v134;
    var v135: *UH2 = undefined; _ = &v135;
    while (true) {
        v1 = derivative_remainder_proof_source_12(v0);
        v2 = derivative_remainder_proof_symbol_14(v0);
        v3 = derivative_remainder_proof_suffix_15(v0);
        v4 = derivative_remainder_proof_candidate_25(v0);
        v5 = UH2_InputCons(v2, v3);
        v6 = UH2_InputCons(v2, v3);
        v7 = language_remainders_27(v1, v6);
        v8 = input_list_remove_32(v5, v7);
        v9 = language_remainders_27(v4, v3);
        v10 = input_list_subset_33(v8, v9);
        if (v10) {
            v12 = input_list_subset_33(v9, v8);
        } else {
            v12 = false;
        }
        if (v12) {
            switch (v0.tag) {
                3 => {
                    v20 = v0.c3_0;
                    v21 = v0.c3_1;
                    v22 = v0.c3_2;
                    v23 = v0.c3_3;
                    v24 = derivative_remainder_proof_symbol_14(v0);
                    v25 = derivative_remainder_proof_symbol_14(v22);
                    switch (v24.tag) {
                        1 => {
                            switch (v25.tag) {
                                1 => {
                                    v35 = US4_SymbolSame();
                                },
                                0 => {
                                    v35 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v25.tag) {
                                1 => {
                                    v35 = US4_SymbolLess();
                                },
                                0 => {
                                    v35 = US4_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v35.tag) {
                        1 => {
                            v36 = true;
                        },
                        else => {
                            v36 = false;
                        },
                    }
                    if (v36) {
                        v37 = derivative_remainder_proof_suffix_15(v0);
                        v38 = derivative_remainder_proof_suffix_15(v22);
                        v40 = input_equal_16(v37, v38);
                    } else {
                        v40 = false;
                    }
                    if (v40) {
                        v41 = derivative_remainder_proof_symbol_14(v0);
                        v42 = derivative_remainder_proof_symbol_14(v23);
                        switch (v41.tag) {
                            1 => {
                                switch (v42.tag) {
                                    1 => {
                                        v52 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v52 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v42.tag) {
                                    1 => {
                                        v52 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v52 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v52.tag) {
                            1 => {
                                v53 = true;
                            },
                            else => {
                                v53 = false;
                            },
                        }
                        if (v53) {
                            v54 = derivative_remainder_proof_suffix_15(v0);
                            v55 = derivative_remainder_proof_suffix_15(v23);
                            v57 = input_equal_16(v54, v55);
                        } else {
                            v57 = false;
                        }
                        if (v57) {
                            v58 = derivative_remainder_proof_valid_26(v22);
                            if (v58) {
                                v0 = v23;
                                continue;
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                },
                4 => {
                    v63 = v0.c4_0;
                    v64 = v0.c4_1;
                    v65 = v0.c4_2;
                    v66 = v0.c4_3;
                    v67 = v0.c4_4;
                    v68 = derivative_remainder_proof_source_12(v66);
                    v69 = nullable_11(v68);
                    switch (v69.tag) {
                        1 => {
                            v73 = US2_RemainderCatNonNullable();
                        },
                        0 => {
                            v73 = US2_RemainderCatNullable();
                        },
                        else => unreachable,
                    }
                    switch (v65.tag) {
                        1 => {
                            switch (v73.tag) {
                                1 => {
                                    v77 = true;
                                },
                                else => {
                                    v77 = false;
                                },
                            }
                        },
                        0 => {
                            switch (v73.tag) {
                                0 => {
                                    v77 = true;
                                },
                                else => {
                                    v77 = false;
                                },
                            }
                        },
                        else => unreachable,
                    }
                    if (v77) {
                        v78 = derivative_remainder_proof_symbol_14(v0);
                        v79 = derivative_remainder_proof_symbol_14(v66);
                        switch (v78.tag) {
                            1 => {
                                switch (v79.tag) {
                                    1 => {
                                        v89 = US4_SymbolSame();
                                    },
                                    0 => {
                                        v89 = US4_SymbolGreater();
                                    },
                                    else => unreachable,
                                }
                            },
                            0 => {
                                switch (v79.tag) {
                                    1 => {
                                        v89 = US4_SymbolLess();
                                    },
                                    0 => {
                                        v89 = US4_SymbolSame();
                                    },
                                    else => unreachable,
                                }
                            },
                            else => unreachable,
                        }
                        switch (v89.tag) {
                            1 => {
                                v90 = true;
                            },
                            else => {
                                v90 = false;
                            },
                        }
                        if (v90) {
                            v91 = derivative_remainder_proof_suffix_15(v0);
                            v92 = derivative_remainder_proof_suffix_15(v66);
                            v94 = input_equal_16(v91, v92);
                        } else {
                            v94 = false;
                        }
                        if (v94) {
                            v95 = derivative_remainder_proof_symbol_14(v0);
                            v96 = derivative_remainder_proof_symbol_14(v67);
                            switch (v95.tag) {
                                1 => {
                                    switch (v96.tag) {
                                        1 => {
                                            v106 = US4_SymbolSame();
                                        },
                                        0 => {
                                            v106 = US4_SymbolGreater();
                                        },
                                        else => unreachable,
                                    }
                                },
                                0 => {
                                    switch (v96.tag) {
                                        1 => {
                                            v106 = US4_SymbolLess();
                                        },
                                        0 => {
                                            v106 = US4_SymbolSame();
                                        },
                                        else => unreachable,
                                    }
                                },
                                else => unreachable,
                            }
                            switch (v106.tag) {
                                1 => {
                                    v107 = true;
                                },
                                else => {
                                    v107 = false;
                                },
                            }
                            if (v107) {
                                v108 = derivative_remainder_proof_suffix_15(v0);
                                v109 = derivative_remainder_proof_suffix_15(v67);
                                v111 = input_equal_16(v108, v109);
                            } else {
                                v111 = false;
                            }
                            if (v111) {
                                v112 = derivative_remainder_proof_valid_26(v66);
                                if (v112) {
                                    v0 = v67;
                                    continue;
                                } else {
                                    return false;
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
                },
                2 => {
                    v17 = v0.c2_0;
                    v18 = v0.c2_1;
                    v19 = v0.c2_2;
                    return true;
                },
                0 => {
                    v13 = v0.c0_0;
                    v14 = v0.c0_1;
                    return true;
                },
                1 => {
                    v15 = v0.c1_0;
                    v16 = v0.c1_1;
                    return true;
                },
                5 => {
                    v118 = v0.c5_0;
                    v119 = v0.c5_1;
                    v120 = v0.c5_2;
                    v121 = derivative_remainder_proof_symbol_14(v0);
                    v122 = derivative_remainder_proof_symbol_14(v120);
                    switch (v121.tag) {
                        1 => {
                            switch (v122.tag) {
                                1 => {
                                    v132 = US4_SymbolSame();
                                },
                                0 => {
                                    v132 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v122.tag) {
                                1 => {
                                    v132 = US4_SymbolLess();
                                },
                                0 => {
                                    v132 = US4_SymbolSame();
                                },
                                else => unreachable,
                            }
                        },
                        else => unreachable,
                    }
                    switch (v132.tag) {
                        1 => {
                            v133 = true;
                        },
                        else => {
                            v133 = false;
                        },
                    }
                    if (v133) {
                        v134 = derivative_remainder_proof_suffix_15(v0);
                        v135 = derivative_remainder_proof_suffix_15(v120);
                        v137 = input_equal_16(v134, v135);
                    } else {
                        v137 = false;
                    }
                    if (v137) {
                        v0 = v120;
                        continue;
                    } else {
                        return false;
                    }
                },
                else => unreachable,
            }
        } else {
            return false;
        }
    }
}
fn derivative_remainder_theorem_suffixes_9(p0: *UH6, p1: US0, p2: *UH1) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: US0 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: *UH2 = undefined; _ = &v3;
    var v4: *UH1 = undefined; _ = &v4;
    var v5: *UH7 = undefined; _ = &v5;
    var v6: *UH6 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v30: bool = undefined; _ = &v30;
    var v8: US0 = undefined; _ = &v8;
    var v18: US4 = undefined; _ = &v18;
    var v19: bool = undefined; _ = &v19;
    var v20: *UH2 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v22: *UH6 = undefined; _ = &v22;
    var v23: *UH6 = undefined; _ = &v23;
    var v24: *UH6 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = derivative_remainder_proof_make_10(v0, v1, v3);
                v6 = derivative_remainder_proof_source_12(v5);
                v7 = regex_equal_13(v0, v6);
                if (v7) {
                    v8 = derivative_remainder_proof_symbol_14(v5);
                    switch (v1.tag) {
                        1 => {
                            switch (v8.tag) {
                                1 => {
                                    v18 = US4_SymbolSame();
                                },
                                0 => {
                                    v18 = US4_SymbolGreater();
                                },
                                else => unreachable,
                            }
                        },
                        0 => {
                            switch (v8.tag) {
                                1 => {
                                    v18 = US4_SymbolLess();
                                },
                                0 => {
                                    v18 = US4_SymbolSame();
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
                        v20 = derivative_remainder_proof_suffix_15(v5);
                        v21 = input_equal_16(v3, v20);
                        if (v21) {
                            v22 = canonical_derivative_17(v0, v1);
                            v23 = derivative_remainder_proof_candidate_25(v5);
                            v24 = normalize_18(v23);
                            v25 = regex_equal_13(v22, v24);
                            if (v25) {
                                v30 = derivative_remainder_proof_valid_26(v5);
                            } else {
                                v30 = false;
                            }
                        } else {
                            v30 = false;
                        }
                    } else {
                        v30 = false;
                    }
                } else {
                    v30 = false;
                }
                if (v30) {
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
fn derivative_remainder_theorem_symbols_8(p0: *UH6, p1: *UH0, p2: *UH1) bool {
    var v0: *UH6 = p0; _ = &v0;
    var v1: *UH0 = p1; _ = &v1;
    var v2: *UH1 = p2; _ = &v2;
    var v3: US0 = undefined; _ = &v3;
    var v4: *UH0 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_remainder_theorem_suffixes_9(v0, v3, v2);
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
fn UH8_RegexChar(a0: US1) *UH8 {
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
fn UH9_RemainderProofEmpty(a0: US1, a1: *UH5) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 0, .c0_0 = a0, .c0_1 = a1 });
}
fn UH9_RemainderProofEpsilon(a0: US1, a1: *UH5) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 1, .c1_0 = a0, .c1_1 = a1 });
}
fn UH9_RemainderProofChar(a0: US1, a1: US1, a2: *UH5) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 2, .c2_0 = a0, .c2_1 = a1, .c2_2 = a2 });
}
fn UH9_RemainderProofAlt(a0: US1, a1: *UH5, a2: *UH9, a3: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 3, .c3_0 = a0, .c3_1 = a1, .c3_2 = a2, .c3_3 = a3 });
}
fn UH9_RemainderProofCat(a0: US1, a1: *UH5, a2: US2, a3: *UH9, a4: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 4, .c4_0 = a0, .c4_1 = a1, .c4_2 = a2, .c4_3 = a3, .c4_4 = a4 });
}
fn UH9_RemainderProofStar(a0: US1, a1: *UH5, a2: *UH9) *UH9 {
    return spiralCreate(UH9, UH9{ .tag = 5, .c5_0 = a0, .c5_1 = a1, .c5_2 = a2 });
}
fn nullable_37(p0: *UH8) US3 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: US3 = undefined; _ = &v7;
    var v8: US3 = undefined; _ = &v8;
    var v16: *UH8 = undefined; _ = &v16;
    var v17: *UH8 = undefined; _ = &v17;
    var v18: US3 = undefined; _ = &v18;
    var v19: US3 = undefined; _ = &v19;
    var v3: US1 = undefined; _ = &v3;
    var v25: *UH8 = undefined; _ = &v25;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = nullable_37(v5);
            v8 = nullable_37(v6);
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
            v18 = nullable_37(v16);
            v19 = nullable_37(v17);
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
fn derivative_remainder_proof_make_36(p0: *UH8, p1: US1, p2: *UH5) *UH9 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH5 = p2; _ = &v2;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v9: *UH9 = undefined; _ = &v9;
    var v10: *UH9 = undefined; _ = &v10;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v14: US3 = undefined; _ = &v14;
    var v18: US2 = undefined; _ = &v18;
    var v19: *UH9 = undefined; _ = &v19;
    var v20: *UH9 = undefined; _ = &v20;
    var v5: US1 = undefined; _ = &v5;
    var v22: *UH8 = undefined; _ = &v22;
    var v23: *UH9 = undefined; _ = &v23;
    switch (v0.tag) {
        3 => {
            v7 = v0.c3_0;
            v8 = v0.c3_1;
            v9 = derivative_remainder_proof_make_36(v7, v1, v2);
            v10 = derivative_remainder_proof_make_36(v8, v1, v2);
            return UH9_RemainderProofAlt(v1, v2, v9, v10);
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = nullable_37(v12);
            switch (v14.tag) {
                1 => {
                    v18 = US2_RemainderCatNonNullable();
                },
                0 => {
                    v18 = US2_RemainderCatNullable();
                },
                else => unreachable,
            }
            v19 = derivative_remainder_proof_make_36(v12, v1, v2);
            v20 = derivative_remainder_proof_make_36(v13, v1, v2);
            return UH9_RemainderProofCat(v1, v2, v18, v19, v20);
        },
        2 => {
            v5 = v0.c2_0;
            return UH9_RemainderProofChar(v5, v1, v2);
        },
        0 => {
            return UH9_RemainderProofEmpty(v1, v2);
        },
        1 => {
            return UH9_RemainderProofEpsilon(v1, v2);
        },
        5 => {
            v22 = v0.c5_0;
            v23 = derivative_remainder_proof_make_36(v22, v1, v2);
            return UH9_RemainderProofStar(v1, v2, v23);
        },
        else => unreachable,
    }
}
fn derivative_remainder_proof_source_38(p0: *UH9) *UH8 {
    var v0: *UH9 = p0; _ = &v0;
    var v11: US1 = undefined; _ = &v11;
    var v12: *UH5 = undefined; _ = &v12;
    var v13: *UH9 = undefined; _ = &v13;
    var v14: *UH9 = undefined; _ = &v14;
    var v15: *UH8 = undefined; _ = &v15;
    var v16: *UH8 = undefined; _ = &v16;
    var v18: US1 = undefined; _ = &v18;
    var v19: *UH5 = undefined; _ = &v19;
    var v20: US2 = undefined; _ = &v20;
    var v21: *UH9 = undefined; _ = &v21;
    var v22: *UH9 = undefined; _ = &v22;
    var v23: *UH8 = undefined; _ = &v23;
    var v24: *UH8 = undefined; _ = &v24;
    var v7: US1 = undefined; _ = &v7;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v1: US1 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v26: US1 = undefined; _ = &v26;
    var v27: *UH5 = undefined; _ = &v27;
    var v28: *UH9 = undefined; _ = &v28;
    var v29: *UH8 = undefined; _ = &v29;
    switch (v0.tag) {
        3 => {
            v11 = v0.c3_0;
            v12 = v0.c3_1;
            v13 = v0.c3_2;
            v14 = v0.c3_3;
            v15 = derivative_remainder_proof_source_38(v13);
            v16 = derivative_remainder_proof_source_38(v14);
            return UH8_RegexAlt(v15, v16);
        },
        4 => {
            v18 = v0.c4_0;
            v19 = v0.c4_1;
            v20 = v0.c4_2;
            v21 = v0.c4_3;
            v22 = v0.c4_4;
            v23 = derivative_remainder_proof_source_38(v21);
            v24 = derivative_remainder_proof_source_38(v22);
            return UH8_RegexCat(v23, v24);
        },
        2 => {
            v7 = v0.c2_0;
            v8 = v0.c2_1;
            v9 = v0.c2_2;
            return UH8_RegexChar(v7);
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return UH8_RegexEmpty();
        },
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            return UH8_RegexEpsilon();
        },
        5 => {
            v26 = v0.c5_0;
            v27 = v0.c5_1;
            v28 = v0.c5_2;
            v29 = derivative_remainder_proof_source_38(v28);
            return UH8_RegexStar(v29);
        },
        else => unreachable,
    }
}
fn regex_equal_39(p0: *UH8, p1: *UH8) bool {
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
    var v4: US1 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v21: US4 = undefined; _ = &v21;
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
                        v28 = regex_equal_39(v24, v26);
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
                        v36 = regex_equal_39(v32, v34);
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
                                        v21 = US4_SymbolSame();
                                    },
                                    else => {
                                        v21 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v21 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v4.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v21 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v21 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v21 = US4_SymbolSame();
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
fn derivative_remainder_proof_symbol_40(p0: *UH9) US1 {
    var v0: *UH9 = p0; _ = &v0;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH9 = undefined; _ = &v10;
    var v11: *UH9 = undefined; _ = &v11;
    var v12: US1 = undefined; _ = &v12;
    var v13: *UH5 = undefined; _ = &v13;
    var v14: US2 = undefined; _ = &v14;
    var v15: *UH9 = undefined; _ = &v15;
    var v16: *UH9 = undefined; _ = &v16;
    var v5: US1 = undefined; _ = &v5;
    var v6: US1 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v1: US1 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v17: US1 = undefined; _ = &v17;
    var v18: *UH5 = undefined; _ = &v18;
    var v19: *UH9 = undefined; _ = &v19;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = v0.c3_3;
            return v8;
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = v0.c4_2;
            v15 = v0.c4_3;
            v16 = v0.c4_4;
            return v12;
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            v7 = v0.c2_2;
            return v6;
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return v1;
        },
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            return v3;
        },
        5 => {
            v17 = v0.c5_0;
            v18 = v0.c5_1;
            v19 = v0.c5_2;
            return v17;
        },
        else => unreachable,
    }
}
fn derivative_remainder_proof_suffix_41(p0: *UH9) *UH5 {
    var v0: *UH9 = p0; _ = &v0;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v10: *UH9 = undefined; _ = &v10;
    var v11: *UH9 = undefined; _ = &v11;
    var v12: US1 = undefined; _ = &v12;
    var v13: *UH5 = undefined; _ = &v13;
    var v14: US2 = undefined; _ = &v14;
    var v15: *UH9 = undefined; _ = &v15;
    var v16: *UH9 = undefined; _ = &v16;
    var v5: US1 = undefined; _ = &v5;
    var v6: US1 = undefined; _ = &v6;
    var v7: *UH5 = undefined; _ = &v7;
    var v1: US1 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v17: US1 = undefined; _ = &v17;
    var v18: *UH5 = undefined; _ = &v18;
    var v19: *UH9 = undefined; _ = &v19;
    switch (v0.tag) {
        3 => {
            v8 = v0.c3_0;
            v9 = v0.c3_1;
            v10 = v0.c3_2;
            v11 = v0.c3_3;
            return v9;
        },
        4 => {
            v12 = v0.c4_0;
            v13 = v0.c4_1;
            v14 = v0.c4_2;
            v15 = v0.c4_3;
            v16 = v0.c4_4;
            return v13;
        },
        2 => {
            v5 = v0.c2_0;
            v6 = v0.c2_1;
            v7 = v0.c2_2;
            return v7;
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return v2;
        },
        1 => {
            v3 = v0.c1_0;
            v4 = v0.c1_1;
            return v4;
        },
        5 => {
            v17 = v0.c5_0;
            v18 = v0.c5_1;
            v19 = v0.c5_2;
            return v18;
        },
        else => unreachable,
    }
}
fn input_equal_42(p0: *UH5, p1: *UH5) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH5 = undefined; _ = &v4;
    var v5: US1 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v22: US4 = undefined; _ = &v22;
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
                                        v22 = US4_SymbolSame();
                                    },
                                    else => {
                                        v22 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v5.tag) {
                                    0 => {
                                        v22 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v3.tag) {
                                            1 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v22 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v5.tag) {
                                                    1 => {
                                                        v22 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v22 = US4_SymbolSame();
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
fn regex_compare_47(p0: *UH8, p1: *UH8) US4 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v59: *UH8 = undefined; _ = &v59;
    var v60: *UH8 = undefined; _ = &v60;
    var v61: *UH8 = undefined; _ = &v61;
    var v62: *UH8 = undefined; _ = &v62;
    var v63: US4 = undefined; _ = &v63;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v40: *UH8 = undefined; _ = &v40;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: US4 = undefined; _ = &v42;
    var v38: US1 = undefined; _ = &v38;
    var v10: US1 = undefined; _ = &v10;
    var v13: US1 = undefined; _ = &v13;
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
                        v63 = regex_compare_47(v59, v61);
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
                        return US4_SymbolGreater();
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
                        v42 = regex_compare_47(v34, v40);
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
                        return US4_SymbolGreater();
                    },
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
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
                                        return US4_SymbolSame();
                                    },
                                    else => {
                                        return US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v13.tag) {
                                    0 => {
                                        return US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v10.tag) {
                                            1 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        return US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v13.tag) {
                                                    1 => {
                                                        return US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        return US4_SymbolSame();
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
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolGreater();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            0 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            1 => {
                switch (v1.tag) {
                    0 => {
                        return US4_SymbolGreater();
                    },
                    1 => {
                        return US4_SymbolSame();
                    },
                    else => {
                        return US4_SymbolLess();
                    },
                }
            },
            5 => {
                v50 = v0.c5_0;
                switch (v1.tag) {
                    3 => {
                        v51 = v1.c3_0;
                        v52 = v1.c3_1;
                        return US4_SymbolLess();
                    },
                    5 => {
                        v54 = v1.c5_0;
                        v0 = v50;
                        v1 = v54;
                        continue;
                    },
                    else => {
                        return US4_SymbolGreater();
                    },
                }
            },
            else => unreachable,
        }
    }
}
fn alt_insert_sorted_46(p0: *UH8, p1: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH8 = p1; _ = &v1;
    var v2: *UH8 = undefined; _ = &v2;
    var v3: *UH8 = undefined; _ = &v3;
    var v4: US4 = undefined; _ = &v4;
    var v6: *UH8 = undefined; _ = &v6;
    var v11: US4 = undefined; _ = &v11;
    switch (v1.tag) {
        3 => {
            v2 = v1.c3_0;
            v3 = v1.c3_1;
            v4 = regex_compare_47(v0, v2);
            switch (v4.tag) {
                2 => {
                    v6 = alt_insert_sorted_46(v0, v3);
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
            v11 = regex_compare_47(v0, v1);
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
fn make_alt_45(p0: *UH8, p1: *UH8) *UH8 {
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
                v4 = alt_insert_sorted_46(v2, v1);
                v0 = v3;
                v1 = v4;
                continue;
            },
            0 => {
                return v1;
            },
            else => {
                return alt_insert_sorted_46(v0, v1);
            },
        }
    }
}
fn make_cat_48(p0: *UH8, p1: *UH8) *UH8 {
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
                                            v14 = make_cat_48(v13, v1);
                                            return UH8_RegexCat(v12, v14);
                                        },
                                        5 => {
                                            v4 = v0.c5_0;
                                            switch (v1.tag) {
                                                5 => {
                                                    v5 = v1.c5_0;
                                                    v6 = regex_equal_39(v4, v5);
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
fn make_star_49(p0: *UH8) *UH8 {
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
fn normalize_44(p0: *UH8) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v5: *UH8 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: *UH8 = undefined; _ = &v7;
    var v8: *UH8 = undefined; _ = &v8;
    var v10: *UH8 = undefined; _ = &v10;
    var v11: *UH8 = undefined; _ = &v11;
    var v12: *UH8 = undefined; _ = &v12;
    var v13: *UH8 = undefined; _ = &v13;
    var v3: US1 = undefined; _ = &v3;
    var v15: *UH8 = undefined; _ = &v15;
    var v16: *UH8 = undefined; _ = &v16;
    switch (v0.tag) {
        3 => {
            v5 = v0.c3_0;
            v6 = v0.c3_1;
            v7 = normalize_44(v5);
            v8 = normalize_44(v6);
            return make_alt_45(v7, v8);
        },
        4 => {
            v10 = v0.c4_0;
            v11 = v0.c4_1;
            v12 = normalize_44(v10);
            v13 = normalize_44(v11);
            return make_cat_48(v12, v13);
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
            v16 = normalize_44(v15);
            return make_star_49(v16);
        },
        else => unreachable,
    }
}
fn derivative_50(p0: *UH8, p1: US1) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
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
    var v4: US1 = undefined; _ = &v4;
    var v20: US4 = undefined; _ = &v20;
    var v21: bool = undefined; _ = &v21;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: *UH8 = undefined; _ = &v42;
    var v43: *UH8 = undefined; _ = &v43;
    switch (v0.tag) {
        3 => {
            v25 = v0.c3_0;
            v26 = v0.c3_1;
            v27 = derivative_50(v25, v1);
            v28 = derivative_50(v26, v1);
            return make_alt_45(v27, v28);
        },
        4 => {
            v30 = v0.c4_0;
            v31 = v0.c4_1;
            v32 = nullable_37(v30);
            switch (v32.tag) {
                1 => {
                    v37 = derivative_50(v30, v1);
                    return make_cat_48(v37, v31);
                },
                0 => {
                    v33 = derivative_50(v30, v1);
                    v34 = make_cat_48(v33, v31);
                    v35 = derivative_50(v31, v1);
                    return make_alt_45(v34, v35);
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
                            v20 = US4_SymbolSame();
                        },
                        else => {
                            v20 = US4_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v1.tag) {
                        0 => {
                            v20 = US4_SymbolGreater();
                        },
                        else => {
                            switch (v4.tag) {
                                1 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolSame();
                                        },
                                        2 => {
                                            v20 = US4_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v1.tag) {
                                        1 => {
                                            v20 = US4_SymbolGreater();
                                        },
                                        2 => {
                                            v20 = US4_SymbolSame();
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
            v42 = derivative_50(v41, v1);
            v43 = make_star_49(v41);
            return make_cat_48(v42, v43);
        },
        else => unreachable,
    }
}
fn canonical_derivative_43(p0: *UH8, p1: US1) *UH8 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    const v2: *UH8 = normalize_44(v0);
    const v3: *UH8 = derivative_50(v2, v1);
    return normalize_44(v3);
}
fn derivative_remainder_proof_candidate_51(p0: *UH9) *UH8 {
    var v0: *UH9 = p0; _ = &v0;
    var v30: US1 = undefined; _ = &v30;
    var v31: *UH5 = undefined; _ = &v31;
    var v32: *UH9 = undefined; _ = &v32;
    var v33: *UH9 = undefined; _ = &v33;
    var v34: *UH8 = undefined; _ = &v34;
    var v35: *UH8 = undefined; _ = &v35;
    var v37: US1 = undefined; _ = &v37;
    var v38: *UH5 = undefined; _ = &v38;
    var v39: US2 = undefined; _ = &v39;
    var v40: *UH9 = undefined; _ = &v40;
    var v41: *UH9 = undefined; _ = &v41;
    var v42: *UH8 = undefined; _ = &v42;
    var v43: *UH8 = undefined; _ = &v43;
    var v44: *UH8 = undefined; _ = &v44;
    var v45: *UH8 = undefined; _ = &v45;
    var v7: US1 = undefined; _ = &v7;
    var v8: US1 = undefined; _ = &v8;
    var v9: *UH5 = undefined; _ = &v9;
    var v25: US4 = undefined; _ = &v25;
    var v26: bool = undefined; _ = &v26;
    var v1: US1 = undefined; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v4: US1 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v50: US1 = undefined; _ = &v50;
    var v51: *UH5 = undefined; _ = &v51;
    var v52: *UH9 = undefined; _ = &v52;
    var v53: *UH8 = undefined; _ = &v53;
    var v54: *UH8 = undefined; _ = &v54;
    var v55: *UH8 = undefined; _ = &v55;
    switch (v0.tag) {
        3 => {
            v30 = v0.c3_0;
            v31 = v0.c3_1;
            v32 = v0.c3_2;
            v33 = v0.c3_3;
            v34 = derivative_remainder_proof_candidate_51(v32);
            v35 = derivative_remainder_proof_candidate_51(v33);
            return UH8_RegexAlt(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = v0.c4_2;
            v40 = v0.c4_3;
            v41 = v0.c4_4;
            v42 = derivative_remainder_proof_candidate_51(v40);
            v43 = derivative_remainder_proof_candidate_51(v41);
            v44 = derivative_remainder_proof_source_38(v41);
            switch (v39.tag) {
                1 => {
                    return UH8_RegexCat(v42, v44);
                },
                0 => {
                    v45 = UH8_RegexCat(v42, v44);
                    return UH8_RegexAlt(v45, v43);
                },
                else => unreachable,
            }
        },
        2 => {
            v7 = v0.c2_0;
            v8 = v0.c2_1;
            v9 = v0.c2_2;
            switch (v7.tag) {
                0 => {
                    switch (v8.tag) {
                        0 => {
                            v25 = US4_SymbolSame();
                        },
                        else => {
                            v25 = US4_SymbolLess();
                        },
                    }
                },
                else => {
                    switch (v8.tag) {
                        0 => {
                            v25 = US4_SymbolGreater();
                        },
                        else => {
                            switch (v7.tag) {
                                1 => {
                                    switch (v8.tag) {
                                        1 => {
                                            v25 = US4_SymbolSame();
                                        },
                                        2 => {
                                            v25 = US4_SymbolLess();
                                        },
                                        else => unreachable,
                                    }
                                },
                                2 => {
                                    switch (v8.tag) {
                                        1 => {
                                            v25 = US4_SymbolGreater();
                                        },
                                        2 => {
                                            v25 = US4_SymbolSame();
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
            switch (v25.tag) {
                1 => {
                    v26 = true;
                },
                else => {
                    v26 = false;
                },
            }
            if (v26) {
                return UH8_RegexEpsilon();
            } else {
                return UH8_RegexEmpty();
            }
        },
        0 => {
            v1 = v0.c0_0;
            v2 = v0.c0_1;
            return UH8_RegexEmpty();
        },
        1 => {
            v4 = v0.c1_0;
            v5 = v0.c1_1;
            return UH8_RegexEmpty();
        },
        5 => {
            v50 = v0.c5_0;
            v51 = v0.c5_1;
            v52 = v0.c5_2;
            v53 = derivative_remainder_proof_candidate_51(v52);
            v54 = derivative_remainder_proof_source_38(v52);
            v55 = UH8_RegexStar(v54);
            return UH8_RegexCat(v53, v55);
        },
        else => unreachable,
    }
}
fn consume_right_54(p0: *UH8, p1: *UH4) *UH4 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    switch (v1.tag) {
        1 => {
            v3 = v1.c1_0;
            v4 = v1.c1_1;
            v5 = language_remainders_53(v0, v3);
            v6 = consume_right_54(v0, v4);
            return input_list_append_6(v5, v6);
        },
        0 => {
            return UH4_InputListNil();
        },
        else => unreachable,
    }
}
fn input_list_contains_57(p0: *UH5, p1: *UH4) bool {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v1.tag) {
            1 => {
                v2 = v1.c1_0;
                v3 = v1.c1_1;
                v4 = input_equal_42(v0, v2);
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
fn input_list_enqueue_new_56(p0: *UH4, p1: *UH4, p2: *UH4) Tuple1 {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH4 = undefined; _ = &v9;
    while (true) {
        switch (v0.tag) {
            1 => {
                v3 = v0.c1_0;
                v4 = v0.c1_1;
                v5 = input_list_contains_57(v3, v1);
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
                return Tuple1{ .f0 = v1, .f1 = v2 };
            },
            else => unreachable,
        }
    }
}
fn closure_55(p0: *UH8, p1: *UH4, p2: *UH4) *UH4 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH4 = undefined; _ = &v5;
    var v6: *UH4 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var tmp5: Tuple1 = undefined; _ = &tmp5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = language_remainders_53(v0, v3);
                tmp5 = input_list_enqueue_new_56(v5, v2, v4);
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
fn language_remainders_53(p0: *UH8, p1: *UH5) *UH4 {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH5 = p1; _ = &v1;
    var v32: *UH8 = undefined; _ = &v32;
    var v33: *UH8 = undefined; _ = &v33;
    var v34: *UH4 = undefined; _ = &v34;
    var v35: *UH4 = undefined; _ = &v35;
    var v37: *UH8 = undefined; _ = &v37;
    var v38: *UH8 = undefined; _ = &v38;
    var v39: *UH4 = undefined; _ = &v39;
    var v5: US1 = undefined; _ = &v5;
    var v7: US1 = undefined; _ = &v7;
    var v8: *UH5 = undefined; _ = &v8;
    var v24: US4 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH4 = undefined; _ = &v26;
    var v3: *UH4 = undefined; _ = &v3;
    var v41: *UH8 = undefined; _ = &v41;
    var v42: *UH4 = undefined; _ = &v42;
    var v43: *UH4 = undefined; _ = &v43;
    var v44: *UH4 = undefined; _ = &v44;
    var v45: *UH4 = undefined; _ = &v45;
    switch (v0.tag) {
        3 => {
            v32 = v0.c3_0;
            v33 = v0.c3_1;
            v34 = language_remainders_53(v32, v1);
            v35 = language_remainders_53(v33, v1);
            return input_list_append_6(v34, v35);
        },
        4 => {
            v37 = v0.c4_0;
            v38 = v0.c4_1;
            v39 = language_remainders_53(v37, v1);
            return consume_right_54(v38, v39);
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
                                    v24 = US4_SymbolSame();
                                },
                                else => {
                                    v24 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v7.tag) {
                                0 => {
                                    v24 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v5.tag) {
                                        1 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v7.tag) {
                                                1 => {
                                                    v24 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolSame();
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
                        v26 = UH4_InputListNil();
                        return UH4_InputListCons(v8, v26);
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
            v41 = v0.c5_0;
            v42 = UH4_InputListNil();
            v43 = UH4_InputListCons(v1, v42);
            v44 = UH4_InputListNil();
            v45 = UH4_InputListCons(v1, v44);
            return closure_55(v41, v43, v45);
        },
        else => unreachable,
    }
}
fn input_list_remove_58(p0: *UH5, p1: *UH4) *UH4 {
    var v0: *UH5 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    var v7: *UH4 = undefined; _ = &v7;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = input_equal_42(v0, v3);
                if (v5) {
                    v1 = v4;
                    continue;
                } else {
                    v7 = input_list_remove_58(v0, v4);
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
fn input_list_subset_59(p0: *UH4, p1: *UH4) bool {
    var v0: *UH4 = p0; _ = &v0;
    var v1: *UH4 = p1; _ = &v1;
    var v2: *UH5 = undefined; _ = &v2;
    var v3: *UH4 = undefined; _ = &v3;
    var v4: bool = undefined; _ = &v4;
    while (true) {
        switch (v0.tag) {
            1 => {
                v2 = v0.c1_0;
                v3 = v0.c1_1;
                v4 = input_list_contains_57(v2, v1);
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
fn derivative_remainder_proof_valid_52(p0: *UH9) bool {
    var v0: *UH9 = p0; _ = &v0;
    var v1: *UH8 = undefined; _ = &v1;
    var v2: US1 = undefined; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH8 = undefined; _ = &v4;
    var v5: *UH5 = undefined; _ = &v5;
    var v6: *UH5 = undefined; _ = &v6;
    var v7: *UH4 = undefined; _ = &v7;
    var v8: *UH4 = undefined; _ = &v8;
    var v9: *UH4 = undefined; _ = &v9;
    var v10: bool = undefined; _ = &v10;
    var v12: bool = undefined; _ = &v12;
    var v20: US1 = undefined; _ = &v20;
    var v21: *UH5 = undefined; _ = &v21;
    var v22: *UH9 = undefined; _ = &v22;
    var v23: *UH9 = undefined; _ = &v23;
    var v24: US1 = undefined; _ = &v24;
    var v25: US1 = undefined; _ = &v25;
    var v41: US4 = undefined; _ = &v41;
    var v42: bool = undefined; _ = &v42;
    var v46: bool = undefined; _ = &v46;
    var v43: *UH5 = undefined; _ = &v43;
    var v44: *UH5 = undefined; _ = &v44;
    var v47: US1 = undefined; _ = &v47;
    var v48: US1 = undefined; _ = &v48;
    var v64: US4 = undefined; _ = &v64;
    var v65: bool = undefined; _ = &v65;
    var v69: bool = undefined; _ = &v69;
    var v66: *UH5 = undefined; _ = &v66;
    var v67: *UH5 = undefined; _ = &v67;
    var v70: bool = undefined; _ = &v70;
    var v75: US1 = undefined; _ = &v75;
    var v76: *UH5 = undefined; _ = &v76;
    var v77: US2 = undefined; _ = &v77;
    var v78: *UH9 = undefined; _ = &v78;
    var v79: *UH9 = undefined; _ = &v79;
    var v80: *UH8 = undefined; _ = &v80;
    var v81: US3 = undefined; _ = &v81;
    var v85: US2 = undefined; _ = &v85;
    var v89: bool = undefined; _ = &v89;
    var v90: US1 = undefined; _ = &v90;
    var v91: US1 = undefined; _ = &v91;
    var v107: US4 = undefined; _ = &v107;
    var v108: bool = undefined; _ = &v108;
    var v112: bool = undefined; _ = &v112;
    var v109: *UH5 = undefined; _ = &v109;
    var v110: *UH5 = undefined; _ = &v110;
    var v113: US1 = undefined; _ = &v113;
    var v114: US1 = undefined; _ = &v114;
    var v130: US4 = undefined; _ = &v130;
    var v131: bool = undefined; _ = &v131;
    var v135: bool = undefined; _ = &v135;
    var v132: *UH5 = undefined; _ = &v132;
    var v133: *UH5 = undefined; _ = &v133;
    var v136: bool = undefined; _ = &v136;
    var v17: US1 = undefined; _ = &v17;
    var v18: US1 = undefined; _ = &v18;
    var v19: *UH5 = undefined; _ = &v19;
    var v13: US1 = undefined; _ = &v13;
    var v14: *UH5 = undefined; _ = &v14;
    var v15: US1 = undefined; _ = &v15;
    var v16: *UH5 = undefined; _ = &v16;
    var v142: US1 = undefined; _ = &v142;
    var v143: *UH5 = undefined; _ = &v143;
    var v144: *UH9 = undefined; _ = &v144;
    var v145: US1 = undefined; _ = &v145;
    var v146: US1 = undefined; _ = &v146;
    var v162: US4 = undefined; _ = &v162;
    var v163: bool = undefined; _ = &v163;
    var v167: bool = undefined; _ = &v167;
    var v164: *UH5 = undefined; _ = &v164;
    var v165: *UH5 = undefined; _ = &v165;
    while (true) {
        v1 = derivative_remainder_proof_source_38(v0);
        v2 = derivative_remainder_proof_symbol_40(v0);
        v3 = derivative_remainder_proof_suffix_41(v0);
        v4 = derivative_remainder_proof_candidate_51(v0);
        v5 = UH5_InputCons(v2, v3);
        v6 = UH5_InputCons(v2, v3);
        v7 = language_remainders_53(v1, v6);
        v8 = input_list_remove_58(v5, v7);
        v9 = language_remainders_53(v4, v3);
        v10 = input_list_subset_59(v8, v9);
        if (v10) {
            v12 = input_list_subset_59(v9, v8);
        } else {
            v12 = false;
        }
        if (v12) {
            switch (v0.tag) {
                3 => {
                    v20 = v0.c3_0;
                    v21 = v0.c3_1;
                    v22 = v0.c3_2;
                    v23 = v0.c3_3;
                    v24 = derivative_remainder_proof_symbol_40(v0);
                    v25 = derivative_remainder_proof_symbol_40(v22);
                    switch (v24.tag) {
                        0 => {
                            switch (v25.tag) {
                                0 => {
                                    v41 = US4_SymbolSame();
                                },
                                else => {
                                    v41 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v25.tag) {
                                0 => {
                                    v41 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v24.tag) {
                                        1 => {
                                            switch (v25.tag) {
                                                1 => {
                                                    v41 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v41 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v25.tag) {
                                                1 => {
                                                    v41 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v41 = US4_SymbolSame();
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
                    switch (v41.tag) {
                        1 => {
                            v42 = true;
                        },
                        else => {
                            v42 = false;
                        },
                    }
                    if (v42) {
                        v43 = derivative_remainder_proof_suffix_41(v0);
                        v44 = derivative_remainder_proof_suffix_41(v22);
                        v46 = input_equal_42(v43, v44);
                    } else {
                        v46 = false;
                    }
                    if (v46) {
                        v47 = derivative_remainder_proof_symbol_40(v0);
                        v48 = derivative_remainder_proof_symbol_40(v23);
                        switch (v47.tag) {
                            0 => {
                                switch (v48.tag) {
                                    0 => {
                                        v64 = US4_SymbolSame();
                                    },
                                    else => {
                                        v64 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v48.tag) {
                                    0 => {
                                        v64 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v47.tag) {
                                            1 => {
                                                switch (v48.tag) {
                                                    1 => {
                                                        v64 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v64 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v48.tag) {
                                                    1 => {
                                                        v64 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v64 = US4_SymbolSame();
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
                        switch (v64.tag) {
                            1 => {
                                v65 = true;
                            },
                            else => {
                                v65 = false;
                            },
                        }
                        if (v65) {
                            v66 = derivative_remainder_proof_suffix_41(v0);
                            v67 = derivative_remainder_proof_suffix_41(v23);
                            v69 = input_equal_42(v66, v67);
                        } else {
                            v69 = false;
                        }
                        if (v69) {
                            v70 = derivative_remainder_proof_valid_52(v22);
                            if (v70) {
                                v0 = v23;
                                continue;
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                },
                4 => {
                    v75 = v0.c4_0;
                    v76 = v0.c4_1;
                    v77 = v0.c4_2;
                    v78 = v0.c4_3;
                    v79 = v0.c4_4;
                    v80 = derivative_remainder_proof_source_38(v78);
                    v81 = nullable_37(v80);
                    switch (v81.tag) {
                        1 => {
                            v85 = US2_RemainderCatNonNullable();
                        },
                        0 => {
                            v85 = US2_RemainderCatNullable();
                        },
                        else => unreachable,
                    }
                    switch (v77.tag) {
                        1 => {
                            switch (v85.tag) {
                                1 => {
                                    v89 = true;
                                },
                                else => {
                                    v89 = false;
                                },
                            }
                        },
                        0 => {
                            switch (v85.tag) {
                                0 => {
                                    v89 = true;
                                },
                                else => {
                                    v89 = false;
                                },
                            }
                        },
                        else => unreachable,
                    }
                    if (v89) {
                        v90 = derivative_remainder_proof_symbol_40(v0);
                        v91 = derivative_remainder_proof_symbol_40(v78);
                        switch (v90.tag) {
                            0 => {
                                switch (v91.tag) {
                                    0 => {
                                        v107 = US4_SymbolSame();
                                    },
                                    else => {
                                        v107 = US4_SymbolLess();
                                    },
                                }
                            },
                            else => {
                                switch (v91.tag) {
                                    0 => {
                                        v107 = US4_SymbolGreater();
                                    },
                                    else => {
                                        switch (v90.tag) {
                                            1 => {
                                                switch (v91.tag) {
                                                    1 => {
                                                        v107 = US4_SymbolSame();
                                                    },
                                                    2 => {
                                                        v107 = US4_SymbolLess();
                                                    },
                                                    else => unreachable,
                                                }
                                            },
                                            2 => {
                                                switch (v91.tag) {
                                                    1 => {
                                                        v107 = US4_SymbolGreater();
                                                    },
                                                    2 => {
                                                        v107 = US4_SymbolSame();
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
                        switch (v107.tag) {
                            1 => {
                                v108 = true;
                            },
                            else => {
                                v108 = false;
                            },
                        }
                        if (v108) {
                            v109 = derivative_remainder_proof_suffix_41(v0);
                            v110 = derivative_remainder_proof_suffix_41(v78);
                            v112 = input_equal_42(v109, v110);
                        } else {
                            v112 = false;
                        }
                        if (v112) {
                            v113 = derivative_remainder_proof_symbol_40(v0);
                            v114 = derivative_remainder_proof_symbol_40(v79);
                            switch (v113.tag) {
                                0 => {
                                    switch (v114.tag) {
                                        0 => {
                                            v130 = US4_SymbolSame();
                                        },
                                        else => {
                                            v130 = US4_SymbolLess();
                                        },
                                    }
                                },
                                else => {
                                    switch (v114.tag) {
                                        0 => {
                                            v130 = US4_SymbolGreater();
                                        },
                                        else => {
                                            switch (v113.tag) {
                                                1 => {
                                                    switch (v114.tag) {
                                                        1 => {
                                                            v130 = US4_SymbolSame();
                                                        },
                                                        2 => {
                                                            v130 = US4_SymbolLess();
                                                        },
                                                        else => unreachable,
                                                    }
                                                },
                                                2 => {
                                                    switch (v114.tag) {
                                                        1 => {
                                                            v130 = US4_SymbolGreater();
                                                        },
                                                        2 => {
                                                            v130 = US4_SymbolSame();
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
                            switch (v130.tag) {
                                1 => {
                                    v131 = true;
                                },
                                else => {
                                    v131 = false;
                                },
                            }
                            if (v131) {
                                v132 = derivative_remainder_proof_suffix_41(v0);
                                v133 = derivative_remainder_proof_suffix_41(v79);
                                v135 = input_equal_42(v132, v133);
                            } else {
                                v135 = false;
                            }
                            if (v135) {
                                v136 = derivative_remainder_proof_valid_52(v78);
                                if (v136) {
                                    v0 = v79;
                                    continue;
                                } else {
                                    return false;
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
                },
                2 => {
                    v17 = v0.c2_0;
                    v18 = v0.c2_1;
                    v19 = v0.c2_2;
                    return true;
                },
                0 => {
                    v13 = v0.c0_0;
                    v14 = v0.c0_1;
                    return true;
                },
                1 => {
                    v15 = v0.c1_0;
                    v16 = v0.c1_1;
                    return true;
                },
                5 => {
                    v142 = v0.c5_0;
                    v143 = v0.c5_1;
                    v144 = v0.c5_2;
                    v145 = derivative_remainder_proof_symbol_40(v0);
                    v146 = derivative_remainder_proof_symbol_40(v144);
                    switch (v145.tag) {
                        0 => {
                            switch (v146.tag) {
                                0 => {
                                    v162 = US4_SymbolSame();
                                },
                                else => {
                                    v162 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v146.tag) {
                                0 => {
                                    v162 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v145.tag) {
                                        1 => {
                                            switch (v146.tag) {
                                                1 => {
                                                    v162 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v162 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v146.tag) {
                                                1 => {
                                                    v162 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v162 = US4_SymbolSame();
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
                    switch (v162.tag) {
                        1 => {
                            v163 = true;
                        },
                        else => {
                            v163 = false;
                        },
                    }
                    if (v163) {
                        v164 = derivative_remainder_proof_suffix_41(v0);
                        v165 = derivative_remainder_proof_suffix_41(v144);
                        v167 = input_equal_42(v164, v165);
                    } else {
                        v167 = false;
                    }
                    if (v167) {
                        v0 = v144;
                        continue;
                    } else {
                        return false;
                    }
                },
                else => unreachable,
            }
        } else {
            return false;
        }
    }
}
fn derivative_remainder_theorem_suffixes_35(p0: *UH8, p1: US1, p2: *UH4) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: US1 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: *UH5 = undefined; _ = &v3;
    var v4: *UH4 = undefined; _ = &v4;
    var v5: *UH9 = undefined; _ = &v5;
    var v6: *UH8 = undefined; _ = &v6;
    var v7: bool = undefined; _ = &v7;
    var v36: bool = undefined; _ = &v36;
    var v8: US1 = undefined; _ = &v8;
    var v24: US4 = undefined; _ = &v24;
    var v25: bool = undefined; _ = &v25;
    var v26: *UH5 = undefined; _ = &v26;
    var v27: bool = undefined; _ = &v27;
    var v28: *UH8 = undefined; _ = &v28;
    var v29: *UH8 = undefined; _ = &v29;
    var v30: *UH8 = undefined; _ = &v30;
    var v31: bool = undefined; _ = &v31;
    while (true) {
        switch (v2.tag) {
            1 => {
                v3 = v2.c1_0;
                v4 = v2.c1_1;
                v5 = derivative_remainder_proof_make_36(v0, v1, v3);
                v6 = derivative_remainder_proof_source_38(v5);
                v7 = regex_equal_39(v0, v6);
                if (v7) {
                    v8 = derivative_remainder_proof_symbol_40(v5);
                    switch (v1.tag) {
                        0 => {
                            switch (v8.tag) {
                                0 => {
                                    v24 = US4_SymbolSame();
                                },
                                else => {
                                    v24 = US4_SymbolLess();
                                },
                            }
                        },
                        else => {
                            switch (v8.tag) {
                                0 => {
                                    v24 = US4_SymbolGreater();
                                },
                                else => {
                                    switch (v1.tag) {
                                        1 => {
                                            switch (v8.tag) {
                                                1 => {
                                                    v24 = US4_SymbolSame();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolLess();
                                                },
                                                else => unreachable,
                                            }
                                        },
                                        2 => {
                                            switch (v8.tag) {
                                                1 => {
                                                    v24 = US4_SymbolGreater();
                                                },
                                                2 => {
                                                    v24 = US4_SymbolSame();
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
                        v26 = derivative_remainder_proof_suffix_41(v5);
                        v27 = input_equal_42(v3, v26);
                        if (v27) {
                            v28 = canonical_derivative_43(v0, v1);
                            v29 = derivative_remainder_proof_candidate_51(v5);
                            v30 = normalize_44(v29);
                            v31 = regex_equal_39(v28, v30);
                            if (v31) {
                                v36 = derivative_remainder_proof_valid_52(v5);
                            } else {
                                v36 = false;
                            }
                        } else {
                            v36 = false;
                        }
                    } else {
                        v36 = false;
                    }
                } else {
                    v36 = false;
                }
                if (v36) {
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
fn derivative_remainder_theorem_symbols_34(p0: *UH8, p1: *UH3, p2: *UH4) bool {
    var v0: *UH8 = p0; _ = &v0;
    var v1: *UH3 = p1; _ = &v1;
    var v2: *UH4 = p2; _ = &v2;
    var v3: US1 = undefined; _ = &v3;
    var v4: *UH3 = undefined; _ = &v4;
    var v5: bool = undefined; _ = &v5;
    while (true) {
        switch (v1.tag) {
            1 => {
                v3 = v1.c1_0;
                v4 = v1.c1_1;
                v5 = derivative_remainder_theorem_suffixes_35(v0, v3, v2);
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
fn spiralMainValue() []const u8 {
    var v142: bool = undefined; _ = &v142;
    var v111: US0 = undefined; _ = &v111;
    var v115: US4 = undefined; _ = &v115;
    var v116: bool = undefined; _ = &v116;
    var v117: US0 = undefined; _ = &v117;
    var v118: US0 = undefined; _ = &v118;
    var v119: *UH2 = undefined; _ = &v119;
    var v120: *UH2 = undefined; _ = &v120;
    var v121: *UH2 = undefined; _ = &v121;
    var v122: *UH2 = undefined; _ = &v122;
    var v123: bool = undefined; _ = &v123;
    var v124: US0 = undefined; _ = &v124;
    var v125: *UH6 = undefined; _ = &v125;
    var v126: US0 = undefined; _ = &v126;
    var v127: *UH6 = undefined; _ = &v127;
    var v128: *UH6 = undefined; _ = &v128;
    var v129: *UH6 = undefined; _ = &v129;
    var v130: US0 = undefined; _ = &v130;
    var v131: *UH6 = undefined; _ = &v131;
    var v132: *UH6 = undefined; _ = &v132;
    var v133: US0 = undefined; _ = &v133;
    var v134: *UH6 = undefined; _ = &v134;
    var v135: *UH6 = undefined; _ = &v135;
    var v136: *UH6 = undefined; _ = &v136;
    var v137: bool = undefined; _ = &v137;
    var v162: bool = undefined; _ = &v162;
    var v161: bool = undefined; _ = &v161;
    var v185: bool = undefined; _ = &v185;
    var v226: bool = undefined; _ = &v226;
    var v207: US0 = undefined; _ = &v207;
    var v211: US4 = undefined; _ = &v211;
    var v212: bool = undefined; _ = &v212;
    var v213: *UH2 = undefined; _ = &v213;
    var v214: *UH2 = undefined; _ = &v214;
    var v215: bool = undefined; _ = &v215;
    var v216: *UH6 = undefined; _ = &v216;
    var v217: US0 = undefined; _ = &v217;
    var v218: *UH6 = undefined; _ = &v218;
    var v219: *UH6 = undefined; _ = &v219;
    var v220: *UH6 = undefined; _ = &v220;
    var v221: bool = undefined; _ = &v221;
    var v257: bool = undefined; _ = &v257;
    var v237: US0 = undefined; _ = &v237;
    var v241: US4 = undefined; _ = &v241;
    var v242: bool = undefined; _ = &v242;
    var v243: *UH2 = undefined; _ = &v243;
    var v244: *UH2 = undefined; _ = &v244;
    var v245: bool = undefined; _ = &v245;
    var v246: US0 = undefined; _ = &v246;
    var v247: *UH6 = undefined; _ = &v247;
    var v248: US0 = undefined; _ = &v248;
    var v249: *UH6 = undefined; _ = &v249;
    var v250: *UH6 = undefined; _ = &v250;
    var v251: *UH6 = undefined; _ = &v251;
    var v252: bool = undefined; _ = &v252;
    const v0: US0 = US0_BitZero();
    const v1: US0 = US0_BitOne();
    const v2: *UH0 = UH0_SymbolListNil();
    const v3: *UH0 = UH0_SymbolListCons(v1, v2);
    const v4: *UH0 = UH0_SymbolListCons(v0, v3);
    const v5: *UH1 = input_singletons_from_symbols_0(v4);
    const v6: *UH2 = UH2_InputEmpty();
    const v7: *UH1 = UH1_InputListCons(v6, v5);
    const v8: US0 = US0_BitZero();
    const v9: US0 = US0_BitOne();
    const v10: *UH0 = UH0_SymbolListNil();
    const v11: *UH0 = UH0_SymbolListCons(v9, v10);
    const v12: *UH0 = UH0_SymbolListCons(v8, v11);
    const v13: US0 = US0_BitZero();
    const v14: US0 = US0_BitOne();
    const v15: *UH0 = UH0_SymbolListNil();
    const v16: *UH0 = UH0_SymbolListCons(v14, v15);
    const v17: *UH0 = UH0_SymbolListCons(v13, v16);
    const v18: *UH1 = input_singletons_from_symbols_0(v17);
    const v19: *UH1 = input_prepend_symbols_to_corpus_1(v12, v18);
    const v20: *UH1 = input_list_append_2(v7, v19);
    const v21: US1 = US1_TriA();
    const v22: US1 = US1_TriB();
    const v23: US1 = US1_TriC();
    const v24: *UH3 = UH3_SymbolListNil();
    const v25: *UH3 = UH3_SymbolListCons(v23, v24);
    const v26: *UH3 = UH3_SymbolListCons(v22, v25);
    const v27: *UH3 = UH3_SymbolListCons(v21, v26);
    const v28: *UH4 = input_singletons_from_symbols_4(v27);
    const v29: *UH5 = UH5_InputEmpty();
    const v30: *UH4 = UH4_InputListCons(v29, v28);
    const v31: US1 = US1_TriA();
    const v32: US1 = US1_TriB();
    const v33: US1 = US1_TriC();
    const v34: *UH3 = UH3_SymbolListNil();
    const v35: *UH3 = UH3_SymbolListCons(v33, v34);
    const v36: *UH3 = UH3_SymbolListCons(v32, v35);
    const v37: *UH3 = UH3_SymbolListCons(v31, v36);
    const v38: US1 = US1_TriA();
    const v39: US1 = US1_TriB();
    const v40: US1 = US1_TriC();
    const v41: *UH3 = UH3_SymbolListNil();
    const v42: *UH3 = UH3_SymbolListCons(v40, v41);
    const v43: *UH3 = UH3_SymbolListCons(v39, v42);
    const v44: *UH3 = UH3_SymbolListCons(v38, v43);
    const v45: *UH4 = input_singletons_from_symbols_4(v44);
    const v46: *UH4 = input_prepend_symbols_to_corpus_5(v37, v45);
    const v47: *UH4 = input_list_append_6(v30, v46);
    const v48: *UH6 = UH6_RegexEmpty();
    const v49: *UH6 = UH6_RegexEpsilon();
    const v50: US0 = US0_BitZero();
    const v51: *UH6 = UH6_RegexChar(v50);
    const v52: US0 = US0_BitOne();
    const v53: *UH6 = UH6_RegexChar(v52);
    const v54: *UH6 = UH6_RegexAlt(v51, v53);
    const v55: *UH6 = UH6_RegexStar(v54);
    const v56: US0 = US0_BitZero();
    const v57: *UH6 = UH6_RegexChar(v56);
    const v58: *UH6 = UH6_RegexCat(v55, v57);
    const v59: *UH6 = UH6_RegexAlt(v49, v58);
    const v60: *UH6 = UH6_RegexAlt(v48, v59);
    const v61: US0 = US0_BitZero();
    const v62: US0 = US0_BitOne();
    const v63: *UH0 = UH0_SymbolListNil();
    const v64: *UH0 = UH0_SymbolListCons(v62, v63);
    const v65: *UH0 = UH0_SymbolListCons(v61, v64);
    const v66: bool = derivative_remainder_theorem_symbols_8(v60, v65, v20);
    if (v66) {
    } else {
        if (spiral_true) spiralFail("structural remainder theorem certificate should cover every regex constructor");
    }
    const v67: US1 = US1_TriA();
    const v68: *UH8 = UH8_RegexChar(v67);
    const v69: US1 = US1_TriB();
    const v70: *UH8 = UH8_RegexChar(v69);
    const v71: *UH8 = UH8_RegexAlt(v68, v70);
    const v72: *UH8 = UH8_RegexStar(v71);
    const v73: US1 = US1_TriC();
    const v74: *UH8 = UH8_RegexChar(v73);
    const v75: *UH8 = UH8_RegexCat(v72, v74);
    const v76: US1 = US1_TriA();
    const v77: US1 = US1_TriB();
    const v78: US1 = US1_TriC();
    const v79: *UH3 = UH3_SymbolListNil();
    const v80: *UH3 = UH3_SymbolListCons(v78, v79);
    const v81: *UH3 = UH3_SymbolListCons(v77, v80);
    const v82: *UH3 = UH3_SymbolListCons(v76, v81);
    const v83: bool = derivative_remainder_theorem_symbols_34(v75, v82, v47);
    if (v83) {
    } else {
        if (spiral_true) spiralFail("structural remainder theorem certificate should generalize across nominal alphabets");
    }
    const v84: US0 = US0_BitZero();
    const v85: *UH6 = UH6_RegexChar(v84);
    const v86: US0 = US0_BitOne();
    const v87: *UH6 = UH6_RegexChar(v86);
    const v88: *UH6 = UH6_RegexAlt(v85, v87);
    const v89: *UH6 = UH6_RegexStar(v88);
    const v90: US0 = US0_BitZero();
    const v91: *UH6 = UH6_RegexChar(v90);
    const v92: *UH6 = UH6_RegexCat(v89, v91);
    const v93: US0 = US0_BitOne();
    const v94: US0 = US0_BitOne();
    const v95: US0 = US0_BitZero();
    const v96: *UH2 = UH2_InputEmpty();
    const v97: *UH2 = UH2_InputCons(v95, v96);
    const v98: *UH2 = UH2_InputCons(v94, v97);
    const v99: *UH7 = derivative_remainder_proof_make_10(v92, v93, v98);
    const v100: US0 = US0_BitZero();
    const v101: *UH6 = UH6_RegexChar(v100);
    const v102: US0 = US0_BitOne();
    const v103: *UH6 = UH6_RegexChar(v102);
    const v104: *UH6 = UH6_RegexAlt(v101, v103);
    const v105: *UH6 = UH6_RegexStar(v104);
    const v106: US0 = US0_BitZero();
    const v107: *UH6 = UH6_RegexChar(v106);
    const v108: *UH6 = UH6_RegexCat(v105, v107);
    const v109: *UH6 = derivative_remainder_proof_source_12(v99);
    const v110: bool = regex_equal_13(v108, v109);
    if (v110) {
        v111 = derivative_remainder_proof_symbol_14(v99);
        switch (v111.tag) {
            1 => {
                v115 = US4_SymbolSame();
            },
            0 => {
                v115 = US4_SymbolGreater();
            },
            else => unreachable,
        }
        switch (v115.tag) {
            1 => {
                v116 = true;
            },
            else => {
                v116 = false;
            },
        }
        if (v116) {
            v117 = US0_BitOne();
            v118 = US0_BitZero();
            v119 = UH2_InputEmpty();
            v120 = UH2_InputCons(v118, v119);
            v121 = UH2_InputCons(v117, v120);
            v122 = derivative_remainder_proof_suffix_15(v99);
            v123 = input_equal_16(v121, v122);
            if (v123) {
                v124 = US0_BitZero();
                v125 = UH6_RegexChar(v124);
                v126 = US0_BitOne();
                v127 = UH6_RegexChar(v126);
                v128 = UH6_RegexAlt(v125, v127);
                v129 = UH6_RegexStar(v128);
                v130 = US0_BitZero();
                v131 = UH6_RegexChar(v130);
                v132 = UH6_RegexCat(v129, v131);
                v133 = US0_BitOne();
                v134 = canonical_derivative_17(v132, v133);
                v135 = derivative_remainder_proof_candidate_25(v99);
                v136 = normalize_18(v135);
                v137 = regex_equal_13(v134, v136);
                if (v137) {
                    v142 = derivative_remainder_proof_valid_26(v99);
                } else {
                    v142 = false;
                }
            } else {
                v142 = false;
            }
        } else {
            v142 = false;
        }
    } else {
        v142 = false;
    }
    if (v142) {
    } else {
        if (spiral_true) spiralFail("well-formed derivative remainder theorem certificate should validate");
    }
    const v143: *UH2 = UH2_InputEmpty();
    const v144: US0 = US0_BitZero();
    const v145: *UH6 = UH6_RegexChar(v144);
    const v146: *UH6 = UH6_RegexStar(v145);
    const v147: US0 = US0_BitZero();
    const v148: US0 = US0_BitOne();
    const v149: *UH2 = UH2_InputEmpty();
    const v150: *UH2 = UH2_InputCons(v148, v149);
    const v151: *UH2 = UH2_InputCons(v147, v150);
    const v152: *UH1 = language_remainders_27(v146, v151);
    const v153: bool = input_list_contains_31(v143, v152);
    const v154: *UH2 = UH2_InputEmpty();
    const v155: *UH6 = UH6_RegexEmpty();
    const v156: US0 = US0_BitOne();
    const v157: *UH2 = UH2_InputEmpty();
    const v158: *UH2 = UH2_InputCons(v156, v157);
    const v159: *UH1 = language_remainders_27(v155, v158);
    const v160: bool = input_list_contains_31(v154, v159);
    if (v153) {
        v162 = v160;
    } else {
        v161 = false == v160;
        v162 = v161;
    }
    if (v162) {
    } else {
        if (spiral_true) spiralFail("acceptance-only derivative law should miss a partial-remainder mutant when both decisions reject");
    }
    const v163: US0 = US0_BitZero();
    const v164: US0 = US0_BitOne();
    const v165: *UH2 = UH2_InputEmpty();
    const v166: *UH2 = UH2_InputCons(v164, v165);
    const v167: *UH2 = UH2_InputCons(v163, v166);
    const v168: US0 = US0_BitZero();
    const v169: *UH6 = UH6_RegexChar(v168);
    const v170: *UH6 = UH6_RegexStar(v169);
    const v171: US0 = US0_BitZero();
    const v172: US0 = US0_BitOne();
    const v173: *UH2 = UH2_InputEmpty();
    const v174: *UH2 = UH2_InputCons(v172, v173);
    const v175: *UH2 = UH2_InputCons(v171, v174);
    const v176: *UH1 = language_remainders_27(v170, v175);
    const v177: *UH1 = input_list_remove_32(v167, v176);
    const v178: *UH6 = UH6_RegexEmpty();
    const v179: US0 = US0_BitOne();
    const v180: *UH2 = UH2_InputEmpty();
    const v181: *UH2 = UH2_InputCons(v179, v180);
    const v182: *UH1 = language_remainders_27(v178, v181);
    const v183: bool = input_list_subset_33(v177, v182);
    if (v183) {
        v185 = input_list_subset_33(v182, v177);
    } else {
        v185 = false;
    }
    const v186: bool = v185 == false;
    if (v186) {
    } else {
        if (spiral_true) spiralFail("remainder-set derivative law should reject the same partial-remainder mutant");
    }
    const v187: US0 = US0_BitZero();
    const v188: *UH2 = UH2_InputEmpty();
    const v189: US0 = US0_BitZero();
    const v190: US0 = US0_BitZero();
    const v191: *UH2 = UH2_InputEmpty();
    const v192: *UH7 = UH7_RemainderProofChar(v189, v190, v191);
    const v193: US0 = US0_BitOne();
    const v194: US0 = US0_BitOne();
    const v195: *UH2 = UH2_InputEmpty();
    const v196: *UH7 = UH7_RemainderProofChar(v193, v194, v195);
    const v197: *UH7 = UH7_RemainderProofAlt(v187, v188, v192, v196);
    const v198: bool = derivative_remainder_proof_valid_26(v197);
    const v199: bool = v198 == false;
    if (v199) {
    } else {
        if (spiral_true) spiralFail("certificate validation should reject a child proof from a different derivative context");
    }
    const v200: *UH6 = UH6_RegexEpsilon();
    const v201: US0 = US0_BitZero();
    const v202: *UH2 = UH2_InputEmpty();
    const v203: *UH7 = derivative_remainder_proof_make_10(v200, v201, v202);
    const v204: *UH6 = UH6_RegexEmpty();
    const v205: *UH6 = derivative_remainder_proof_source_12(v203);
    const v206: bool = regex_equal_13(v204, v205);
    if (v206) {
        v207 = derivative_remainder_proof_symbol_14(v203);
        switch (v207.tag) {
            1 => {
                v211 = US4_SymbolLess();
            },
            0 => {
                v211 = US4_SymbolSame();
            },
            else => unreachable,
        }
        switch (v211.tag) {
            1 => {
                v212 = true;
            },
            else => {
                v212 = false;
            },
        }
        if (v212) {
            v213 = UH2_InputEmpty();
            v214 = derivative_remainder_proof_suffix_15(v203);
            v215 = input_equal_16(v213, v214);
            if (v215) {
                v216 = UH6_RegexEmpty();
                v217 = US0_BitZero();
                v218 = canonical_derivative_17(v216, v217);
                v219 = derivative_remainder_proof_candidate_25(v203);
                v220 = normalize_18(v219);
                v221 = regex_equal_13(v218, v220);
                if (v221) {
                    v226 = derivative_remainder_proof_valid_26(v203);
                } else {
                    v226 = false;
                }
            } else {
                v226 = false;
            }
        } else {
            v226 = false;
        }
    } else {
        v226 = false;
    }
    const v227: bool = v226 == false;
    if (v227) {
    } else {
        if (spiral_true) spiralFail("certificate validation should reject a forged source binding");
    }
    const v228: US0 = US0_BitZero();
    const v229: *UH6 = UH6_RegexChar(v228);
    const v230: US0 = US0_BitZero();
    const v231: *UH2 = UH2_InputEmpty();
    const v232: *UH7 = derivative_remainder_proof_make_10(v229, v230, v231);
    const v233: US0 = US0_BitZero();
    const v234: *UH6 = UH6_RegexChar(v233);
    const v235: *UH6 = derivative_remainder_proof_source_12(v232);
    const v236: bool = regex_equal_13(v234, v235);
    if (v236) {
        v237 = derivative_remainder_proof_symbol_14(v232);
        switch (v237.tag) {
            1 => {
                v241 = US4_SymbolSame();
            },
            0 => {
                v241 = US4_SymbolGreater();
            },
            else => unreachable,
        }
        switch (v241.tag) {
            1 => {
                v242 = true;
            },
            else => {
                v242 = false;
            },
        }
        if (v242) {
            v243 = UH2_InputEmpty();
            v244 = derivative_remainder_proof_suffix_15(v232);
            v245 = input_equal_16(v243, v244);
            if (v245) {
                v246 = US0_BitZero();
                v247 = UH6_RegexChar(v246);
                v248 = US0_BitOne();
                v249 = canonical_derivative_17(v247, v248);
                v250 = derivative_remainder_proof_candidate_25(v232);
                v251 = normalize_18(v250);
                v252 = regex_equal_13(v249, v251);
                if (v252) {
                    v257 = derivative_remainder_proof_valid_26(v232);
                } else {
                    v257 = false;
                }
            } else {
                v257 = false;
            }
        } else {
            v257 = false;
        }
    } else {
        v257 = false;
    }
    const v258: bool = v257 == false;
    if (v258) {
    } else {
        if (spiral_true) spiralFail("certificate validation should reject a forged symbol binding");
    }
    const v259: *UH6 = UH6_RegexEpsilon();
    const v260: US0 = US0_BitZero();
    const v261: *UH2 = UH2_InputEmpty();
    const v262: *UH7 = derivative_remainder_proof_make_10(v259, v260, v261);
    const v263: US0 = US0_BitZero();
    const v264: *UH6 = UH6_RegexChar(v263);
    const v265: US0 = US0_BitZero();
    const v266: *UH2 = UH2_InputEmpty();
    const v267: *UH7 = derivative_remainder_proof_make_10(v264, v265, v266);
    const v268: US0 = US0_BitZero();
    const v269: *UH2 = UH2_InputEmpty();
    const v270: US2 = US2_RemainderCatNonNullable();
    const v271: *UH7 = UH7_RemainderProofCat(v268, v269, v270, v262, v267);
    const v272: bool = derivative_remainder_proof_valid_26(v271);
    const v273: bool = v272 == false;
    if (v273) {
    } else {
        if (spiral_true) spiralFail("certificate validation should reject a forged nullable concatenation branch");
    }
    const v274: []const u8 = "brzozowski-remainder-theorem-green";
    return v274;
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
